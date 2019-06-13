using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePeopleSearch.Data.Models
{
    public class Users
    {
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public int addressId { get; set; }
        public string interests { get; set; }
        public string userImage { get; set; }
        public DateTime createdDtTime { get; set; }
    }
}
