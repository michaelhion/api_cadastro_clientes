using Api_intelitrader.Domains;
using Api_intelitrader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_intelitrader.Interface
{
    interface IEntidadeRepository
    {
         /// <summary>
        /// Lista as entidades
        /// </summary>
        /// <returns>A lista de usuarios</returns>
        List<Entidade> Listar();
        
        /// <summary>
        /// Busca uma entidade pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Os dados da entidade</returns>
        Entidade BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="entidades"></param>
        void Cadastrar(Entidade novaEntidade);

        /// <summary>
        /// Atualiza os dados de um usuario
        /// </summary>
        /// <param name="entidades"></param>
        void Atulizar(int id, Entidade entidades);

        /// <summary>
        /// Deleta um usuario pelo ID
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);
    }
}
