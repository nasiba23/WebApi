using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Db
{
    public class QuoteController
    {
        private DataContext _db;

        public QuoteController(DataContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quote>>> Get()
        {
            return await _db.Quotes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Quote>> Get(int id)
        {
            Quote quote = await _db.Quotes.FirstOrDefaultAsync(q => q.Id == id);
            if (quote == null)
            {
                return new NotFoundResult();
            }
            return new ObjectResult(quote);
        }

        [HttpPost]
        public async Task<ActionResult<Quote>> Post(Quote quote)
        {
            if (quote == null)
            {
                return new BadRequestResult();
            }
            
            _db.Quotes.Add(quote);
            await _db.SaveChangesAsync();
            return new OkObjectResult(quote);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Quote>> Delete(int id)
        {
            Quote quote = await _db.Quotes.FirstOrDefaultAsync(q => q.Id == id);
            if (quote == null)
            {
                return new NotFoundResult();
            }

            _db.Remove(quote);
            await _db.SaveChangesAsync();
            return new OkObjectResult(quote);
        }
    }
}