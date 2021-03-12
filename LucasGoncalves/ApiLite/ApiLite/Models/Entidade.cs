using System;

namespace ApiLite.Models
{
    public class Entidade
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public int? Age { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
