using Api_intelitrader.Contexts;
using Api_intelitrader.Domains;
using Api_intelitrader.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Api_intelitrader.Repository
{
    public class EntidadeRepository : IEntidadeRepository
    {
        EntidadeContext ctx = new EntidadeContext();

        public void Atulizar(int id, Entidade entidadesAtualizada)
        {
            Entidade entidadesBuscadas = BuscarPorId(id);

            if (entidadesAtualizada.FirstName != null && entidadesAtualizada.FirstName != entidadesBuscadas.FirstName)
            {
                entidadesBuscadas.FirstName = entidadesAtualizada.FirstName;
            }

            if(entidadesAtualizada.SurName != null && entidadesAtualizada.SurName != entidadesBuscadas.SurName)
            {
                entidadesBuscadas.SurName = entidadesAtualizada.SurName;
            }

            if(entidadesAtualizada.Age != null && entidadesAtualizada.Age != entidadesBuscadas.Age)
            {
                entidadesBuscadas.Age = entidadesAtualizada.Age;
            }

            ctx.Update(entidadesBuscadas);

            ctx.SaveChanges();
        }

        public Entidade BuscarPorId(int id)
        {
            Entidade entidadeBuscada = ctx.Entidades.Find(id);

            return entidadeBuscada;
        }

        public void Cadastrar(Entidade novaEntidade)
        {

            ctx.Entidades.Add(novaEntidade);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Entidades.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Entidade> Listar()
        {
            return ctx.Entidades.ToList();  
        }
    }
}
