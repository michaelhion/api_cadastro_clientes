using api_cadastro_cliente.Context;
using api_cadastro_cliente.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_cadastro_cliente.Repositories
{
    public class ClienteRepository : IClientes
    {
        private readonly Contexto _context;

        public ClienteRepository(Contexto context)
        {
            _context = context;
        }

        public void deleteCliente(string Id)
        {
            //using (var ctx = new Contexto())
            //{
                var existe = findById(Id);
                if (existe != null)
                {
                    
                    _context.Remove(existe);
                    _context.SaveChanges();
                }

            //}
        }

        public void editarCliente(string Id, ClienteModel cliente)
        {
            //using (Contexto ctx = new Contexto())
            //{
                var existe = findById(Id);
                if (existe != null)
                {
                    existe.FirstName = (cliente.FirstName == "" || cliente.FirstName == null) ? existe.FirstName : cliente.FirstName;
                    existe.Surname = (cliente.Surname == "" || cliente.Surname == null) ? existe.Surname : cliente.Surname;
                    existe.Age = (cliente.Age == 0) ? cliente.Age : cliente.Age;
                    existe.CreationDate = DateTime.Now;
                    _context.ClienteModels.Update(existe);
                    _context.SaveChanges();
                }

           // }
        }

        public ClienteModel findById(string Id)
        {
            //using (Contexto ctx = new Contexto())
            //{
                return _context.ClienteModels.FirstOrDefault(c => c.Id == Id);

            //}
        }

        public void inserirCliente(ClienteModel cliente)
        {
            //using (Contexto ctx = new Contexto())
            //{
                string uuid = Guid.NewGuid().ToString();
                cliente.Id = uuid;
                cliente.CreationDate = DateTime.Now;
                _context.ClienteModels.Add(cliente);
                _context.SaveChanges();

            //}
        }

        public List<ClienteModel> listarCliente()
        {
            //using (Contexto ctx = new Contexto())
            //{
                return _context.ClienteModels.ToList();
           // }
        }
    }
}

