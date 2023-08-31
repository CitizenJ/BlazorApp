﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorApp.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public DateTime? FoundIn { get; set; }
        public string Ceo { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
