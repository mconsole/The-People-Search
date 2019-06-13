using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePeopleSearch.Data.Models
{
    public class User
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zip { get; set; }
        public int age { get; set; }
        public string interests { get; set; }
        public string image { get; set; }
    }
}
