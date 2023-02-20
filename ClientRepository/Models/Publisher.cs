using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ClientRepository.Models
{
    public class Publisher
    {
        public int pub_id { get; set; }

        public string publisher_name { get; set; } = null!;

        public string city { get; set; } = null!;

        public string state { get; set; } = null!;

        public string country { get; set; } = null!;

        public ICollection<User>? User { get; set; }
    }
}
