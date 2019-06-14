using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePeopleSearch.Data.Models
{
    public class UsersVw
    {
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public string interests { get; set; }
        public string userImage { get; set; }
        public string streetAddr { get; set; }
        public string cityName { get; set; }
        public string statename { get; set; }
        public int zipCode { get; set; }
        public string countryName { get; set; }
    }
}
