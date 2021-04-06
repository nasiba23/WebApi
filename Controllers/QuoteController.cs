using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Db;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class QuoteController : ControllerBase
    {
        private DataContext _db;

        public QuoteController(DataContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quote>>> Get()
        {
            var quotes = await _db.Quotes.ToListAsync();
            var quotesForDelete = quotes.Where(q => DateTime.Now - q.InsertDate > new TimeSpan(30, 0, 0));
            foreach (var x in quotesForDelete)
            {
                _db.Quotes.Remove(x);
            }
            return quotes;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Quote>> Get(int id)
        {
            Quote quote = await _db.Quotes.FirstOrDefaultAsync(q => q.Id == id);
            if (quote == null)
            {
                return NotFound();
            }
            return new ObjectResult(quote);
        }

        [HttpPost]
        public async Task<ActionResult<Quote>> Post(Quote quote)
        {
            if (quote == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.Quotes.Add(quote);
            await _db.SaveChangesAsync();
            return new OkObjectResult(quote);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Quote>> Put(Quote quote)
        {
            if (quote == null)
            {
                return BadRequest();
            }
            if (!_db.Quotes.Any(q => q.Id == quote.Id))
            {
                return NotFound();
            }

            _db.Update(quote);
            await _db.SaveChangesAsync();
            return Ok(quote);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Quote>> Delete(int id)
        {
            Quote quote = await _db.Quotes.FirstOrDefaultAsync(q => q.Id == id);
            if (quote == null)
            {
                return NotFound();
            }
            _db.Remove(quote);
            await _db.SaveChangesAsync();
            return new OkObjectResult(quote);
        }
    }
}