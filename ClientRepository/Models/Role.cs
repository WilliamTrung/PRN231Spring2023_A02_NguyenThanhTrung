using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRepository.Models
{
    public class Role
    {
        public int role_id { get; set; }

        public string? role_desc { get; set; }

        public ICollection<User>? User { get; set; }
    }
}
