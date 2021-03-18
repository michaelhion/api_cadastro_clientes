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
        public void deleteCliente(string Id)
        {
            using (ClienteContexto ctx = new ClienteContexto())
            {
                var existe = findById(Id);
                if (existe != null)
                {
                    ctx.Clientes.Remove(existe);
                    ctx.SaveChanges();
                }

            }
        }

        public void editarCliente(string Id, ClienteModel cliente)
        {
            using (ClienteContexto ctx = new ClienteContexto())
            {
                var existe = findById(Id);
                if (existe != null)
                {
                    existe.FirstName = (cliente.FirstName == "" || cliente.FirstName == null) ? existe.FirstName : cliente.FirstName;
                    existe.Surname = (cliente.Surname == "" || cliente.Surname == null) ? existe.Surname : cliente.Surname;
                    existe.Age = (cliente.Age == 0) ? cliente.Age : cliente.Age;
                    
                    ctx.Clientes.Update(cliente);
                    ctx.SaveChanges();
                }

            }
        }

        public ClienteModel findById(string Id)
        {
            using (ClienteContexto ctx = new ClienteContexto())
            {
                return ctx.Clientes.FirstOrDefault(c => c.Id == Id);

            }
        }

        public void inserirCliente(ClienteModel cliente)
        {
            using (ClienteContexto ctx = new ClienteContexto())
            {
                string uuid = Guid.NewGuid().ToString();
                cliente.Id = uuid;
                cliente.creationDate = DateTime.Now;
                ctx.Clientes.Add(cliente);
                ctx.SaveChanges();

            }
        }

        public List<ClienteModel> listarCliente()
        {
            using (ClienteContexto ctx = new ClienteContexto())
            {
                return ctx.Clientes.ToList();
            }
        }
    }
}

