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
        [Key]
        public int author_id { get; set; }
        

        [ForeignKey("Book")]
        [Key]
        public int book_id { get; set; }
        

        public string? author_order { get; set; }

        public int royality_percentage { get; set; }
        public virtual Book Book { get; set; } = null!;
        public virtual Author Author { get; set; } = null!;
    }
}
