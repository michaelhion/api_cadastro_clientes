using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Goiabinha_API_Core.Models
{
    public class Usuario
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public DateTime creationDate { get; set; }
    }
}
