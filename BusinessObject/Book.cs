using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Book
    {
        [Key]
        public int book_id { get; set; }
        [ForeignKey("Publisher")]
        public int pub_id { get; set; } 

        public string title { get; set; } = null!;

        public string type { get; set; } = null!;
        [Column(TypeName ="money")]

        public Decimal price { get; set; }

        public string advanced { get; set; } = null!;

        public string royalty { get; set; } = null!;
        [Column(TypeName = "date")]

        public DateTime ytd_date { get; set; }

        public string? note { get; set; }
        [Column(TypeName = "date")]

        public DateTime published_date { get; set; }

        public virtual ICollection<BookAuthor>? BookAuthor { get; set; }
        
        public virtual Publisher? Publisher { get; set; }
    }
}
