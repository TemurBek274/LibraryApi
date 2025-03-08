using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBook.Domain.Entities
{
    public class Book
    {
        [Key]

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishedYear { get; set; }
        public string ISBN { get; set; }
        public Genre Genre { get; set; }
        public decimal Price { get; set; }
    }
    public enum Genre
    {
        Fiction, 
        NonFiction, 
        Science, 
        History, 
        Biography

    }
}
