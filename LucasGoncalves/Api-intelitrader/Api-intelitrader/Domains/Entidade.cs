using System;
using System.Collections.Generic;

#nullable disable

namespace Api_intelitrader.Domains
{
    public partial class Entidade
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public int? Age { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
