using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_cadastro_cliente.Context
{
    public class ClienteModel
{
        public string Id { get; set; }
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public DateTime creationDate { get; set; }
    }
}
