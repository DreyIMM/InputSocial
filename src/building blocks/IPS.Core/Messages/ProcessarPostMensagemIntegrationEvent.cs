namespace IPS.Core.Messages
{
    public class ProcessarPostMensagemIntegrationEvent : IntegrationEvent
    {
        public Guid Id { get; private set; }
        public string Mensagem { get; set; }

        public ProcessarPostMensagemIntegrationEvent(Guid id, string mensagem)
        {
            Id = id;
            Mensagem = mensagem;
        }
    }

}