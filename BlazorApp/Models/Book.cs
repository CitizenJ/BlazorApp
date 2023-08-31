using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorApp.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? PageCount { get; set; }
        public DateTime? PublicationDate { get; set; }
        public float? Price { get; set; }
        public int? InStock { get; set; }

        public virtual Author Author { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
