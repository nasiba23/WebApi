using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Quote
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public string? Author { get; set; }
        [Required]
        public DateTime InsertDate { get; set; }
    }
}