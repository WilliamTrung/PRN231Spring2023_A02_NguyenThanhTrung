using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRepository.Models
{
    public class Book
    {
        public int book_id { get; set; }

        public string title { get; set; } = null!;

        public string type { get; set; } = null!;
        [DataType(DataType.Currency)]
        public Decimal price { get; set; }

        public string advanced { get; set; } = null!;

        public string royalty { get; set; } = null!;

        public DateTime ytd_date { get; set; }

        public string? note { get; set; }
        public DateTime published_date { get; set; }

        public ICollection<BookAuthor> BookAuthor { get; set; } = null!;
    }
}
