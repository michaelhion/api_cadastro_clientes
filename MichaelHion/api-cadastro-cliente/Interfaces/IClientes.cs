using api_cadastro_cliente.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_cadastro_cliente.Interfaces
{
    public interface IClientes
    {
        List<ClienteModel> listarCliente();

        ClienteModel findById(string Id);

        void inserirCliente(ClienteModel cliente);

        void editarCliente(string Id, ClienteModel cliente);

        void deleteCliente(string Id);
    }
}
