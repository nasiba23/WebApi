using System;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quote>().HasData(
                new Quote
                {
                    Id = 1,
                    Text = "The greatest glory in living lies not in never falling, but in rising every time we fall.",
                    Author = "Nelson Mandela",
                    InsertDate = DateTime.Now,

                },
                new Quote
                {
                    Id = 2,
                    Text = "The way to get started is to quit talking and begin doing.",
                    Author = "Walt Disney",
                    InsertDate = DateTime.Now,

                },
                new Quote
                {
                    Id = 3,
                    Text = "If life were predictable it would cease to be life, and be without flavor.",
                    Author = "Eleanor Roosevelt",
                    InsertDate = DateTime.Now,
                },
                new Quote
                {
                    Id = 4,
                    Text = "Life is what happens when you're busy making other plans.",
                    Author = "John Lennon",
                    InsertDate = DateTime.Now,
                },
                new Quote
                {
                    Id = 5,
                    Text = "When you reach the end of your rope, tie a knot in it and hang on.",
                    Author = "Franklin D. Roosevelt",
                    InsertDate = DateTime.Now,
                });
        }
    }
}