using System;
using System.Collections.Generic;

namespace WebAppBooks.Models
{
    public partial class Book
    {
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public int? Price { get; set; }
        public string? Category { get; set; }
        public string? Publisher { get; set; }

        public virtual BookCategory? CategoryNavigation { get; set; }
        public virtual Publisher? PublisherNavigation { get; set; }
    }
}
