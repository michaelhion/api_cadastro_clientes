using Goiabinha_WebApi.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Goiabinha_WebApi.Interfaces
{
    public interface IUsuario
    {
        /// <summary>
        /// Listar todos os usuários
        /// </summary>
        List<Usuarios> get();

        /// <summary>
        /// Buscar um usuário
        /// </summary>
        Usuarios getById(string id);

        /// <summary>
        /// Cadastrar um usuário
        /// </summary>
        void post(Usuarios Usuario);
        /// <summary>
        /// Atualizar um usuário 
        /// </summary>
        void update(string id, Usuarios Usuario);

        /// <summary>
        /// Deletar um usuário
        /// </summary>
        void delete(string id);
    }
}
