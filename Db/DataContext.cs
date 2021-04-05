using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Db
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Quote> Quotes { get; set; }
    }
}