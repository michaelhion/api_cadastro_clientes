using Goiabinha_API_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Goiabinha_API_Core.Interfaces
{
    public interface IUsuario
    {
        /// <summary>
        /// Listar todos os usuários
        /// </summary>
        List<Usuario> get();

        /// <summary>
        /// Buscar um usuário
        /// </summary>
        Usuario getById(string id);

        /// <summary>
        /// Cadastrar um usuário
        /// </summary>
        void post(Usuario Usuario);
        /// <summary>
        /// Atualizar um usuário 
        /// </summary>
        void update(string id, Usuario Usuario);

        /// <summary>
        /// Deletar um usuário
        /// </summary>
        void delete(string id);
    }
}
