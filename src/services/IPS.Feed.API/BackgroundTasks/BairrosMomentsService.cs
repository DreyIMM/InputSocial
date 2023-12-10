using Firebase.Database;
using Firebase.Database.Query;
using IPS.Feed.Domain.Interfaces;
using IPS.Feed.Domain.Models;
using IPS.Feed.Infra.Repository;

namespace IPS.Feed.API.BackgroundTasks
{
    public class BairrosMomentsService : BackgroundService
    {
        public IServiceProvider _services { get; }
        private readonly ILogger<BairrosMomentsService> _logger;
        private const string FirebaseDatabaseUrl = "https://ips-tcc-default-rtdb.firebaseio.com/";
        private readonly FirebaseClient firebaseClient;


        public BairrosMomentsService(IServiceProvider services, ILogger<BairrosMomentsService> logger)
        {
            _services = services;
            _logger = logger;
            firebaseClient = new FirebaseClient(FirebaseDatabaseUrl);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                using (var scoped = _services.CreateScope())
                {
                    var service = scoped.ServiceProvider.GetRequiredService<IPostagemRepository>();

                    var novoMoments = (await service.ObterPostagensMoments())
                        .SelectMany(value => value.Split(";"))
                        .Where(s => !string.IsNullOrWhiteSpace(s))
                        .Distinct(StringComparer.OrdinalIgnoreCase)
                        .ToList();

                    _logger.LogInformation("Bairro Moments: {count}", novoMoments.Count);
                    if (novoMoments.Any()) { await updateFirebase(novoMoments);}
                }

                _logger.LogInformation("Firebase atualização moments: {time}", DateTimeOffset.Now);
                await Task.Delay(100000, stoppingToken);
            }
        }


        private async Task updateFirebase(List<string> novoMoments)
        {
            LinkedList<string> listaMomentsFirebase = new LinkedList<string>();

            var regiaoMoments = await firebaseClient
                                 .Child("bairroMoments")
                                 .OnceAsync<BairrosMomentsFirebaseModel>();

            foreach (FirebaseObject<BairrosMomentsFirebaseModel> bairroMoments in regiaoMoments)
            {
                //Precisa ser Last,por que o primeiro fica em primeiro hehe
                listaMomentsFirebase.AddLast(bairroMoments.Object.Nome);
            }

            foreach (string value in novoMoments)
            {
                listaMomentsFirebase.AddFirst(value);
                listaMomentsFirebase.RemoveLast();
            }

            await firebaseClient.Child("bairroMoments").DeleteAsync();

            listaMomentsFirebase.ToList().ForEach(async c =>
            {

                await firebaseClient
                    .Child("bairroMoments")
                   .PostAsync(new BairrosMomentsFirebaseModel() { Nome = c });

            });
        }
        
    }
}
