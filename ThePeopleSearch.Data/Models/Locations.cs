using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePeopleSearch.Data.Models
{
    public class Locations
    {
        public int locationId { get; set; }
        public string streetAddr { get; set; }
        public string cityName { get; set; }
        public string stateName { get; set; }
        public int zipCode { get; set; }
        public string countryname { get; set; }
        public DateTime createdDtTime { get; set; }
    }
}
