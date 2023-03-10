using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRepository.Models
{
    public class User
    {
        public int user_id { get; set; }

        [Required]
        public string? email_address { get; set; }

        [Required]
        [MinLength(1)]
        public string? password { get; set; }

        public string? source { get; set; }

        public string? first_name { get; set; }

        public string? last_name { get; set; }

        [ForeignKey("Role")]
        public int role_id { get; set; }
        public Role? Role { get; set; }

        [ForeignKey("Publisher")]
        public int pub_id { get; set; }
        public Publisher? Publisher { get; set; }
        [Column(TypeName = "date")]

        public DateTime hire_date;
    }
}
