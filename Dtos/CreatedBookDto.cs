using eBook.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Dtos
{
    public class CreatedBookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishedYear { get; set; }
        public string ISBN { get; set; }
        public Genre Genre { get; set; }
        public decimal Price { get; set; }
    }
}
