using IPS.Feed.API.Data;
using IPS.Feed.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IPS.Feed.API.Controllers
{
    
    public class FeedController
    {
        private readonly FeedContext _context;
        public FeedController(FeedContext context)
        {
            _context = context;
        }

        [HttpGet("feed")]
        public async Task<IEnumerable<Postagem>> ObterPostagens()
        {
            return await _context.Postagem.Include(p => p.Curtidas).ToListAsync();
        }



    }    
}
