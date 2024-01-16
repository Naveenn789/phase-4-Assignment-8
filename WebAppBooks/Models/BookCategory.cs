using System;
using System.Collections.Generic;

namespace WebAppBooks.Models
{
    public partial class BookCategory
    {
        public BookCategory()
        {
            Books = new HashSet<Book>();
        }

        public int? CatId { get; set; }
        public string CatName { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
    }
}
