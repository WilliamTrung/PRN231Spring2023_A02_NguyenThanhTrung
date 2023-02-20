using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Author
    {
        [Key]
        public int author_id { get; set; }

        public string last_name { get; set; } = null!;

        public string first_name { get; set; } = null!;
        [Phone]

        public string phone { get; set; } = null!;

        public string address { get; set; } = null!;

        public string city { get; set; } = null!;

        public string state { get; set; } = null!;       

        public string zip { get; set; } = null!;

        public string email_address { get; set; } = null!;

        public BookAuthor? BookAuthor { get; set; }
    }
}
