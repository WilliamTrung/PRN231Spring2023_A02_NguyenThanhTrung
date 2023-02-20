using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{

    public class BookAuthor
    {
        [ForeignKey("Author")]
        public int author_id { get; set; }
        public Author? Author { get; set; }

        [ForeignKey("Book")]
        public int book_id { get; set; }
        public Book? Book { get; set; }

        public string? author_order { get; set; }

        public int royality_percentage { get; set; }
    }
}
