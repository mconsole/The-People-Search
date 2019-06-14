using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePeopleSearch.Data.Models
{
    public class Error
    {
        public int errorId { get; set; }
        public string message { get; set; }
        public string stackTrace { get; set; }
        public DateTime createdDtTime { get; set; }
    }
}
