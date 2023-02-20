using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace ClientRepository.Models
{
    public class User
    {
        public int user_id { get; set; }

        [Required]        
        [EmailAddress]
        public string? email_address { get; set; }

        [Required]
        [MinLength(1)]        
        public string? password { get; set; }

        public string? source { get; set; }

        public string? first_name { get; set; }

        public string? last_name { get; set; }
        public int role_id { get; set; }
        public Role Role { get; set; } = null!;

        public int pub_id { get; set; }
        public Publisher? Publisher { get; set; }
        [DataType(DataType.Date)]

        public DateTime hire_date;
    }
}