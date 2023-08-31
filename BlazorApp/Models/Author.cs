using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorApp.Models
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public DateTime? Birthday { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
