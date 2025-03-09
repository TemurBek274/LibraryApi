﻿using eBook.Domain.Entities;

namespace LibraryApi.Entities
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishedYear { get; set; }
        public string ISBN { get; set; }
        public Genre Genre { get; set; }
        public decimal Price { get; set; }
    }
}
