﻿using System;
using System.Collections.Generic;

namespace WebAppBooks.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        public int? Pid { get; set; }
        public string Pname { get; set; } = null!;
        public string? Paddress { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
