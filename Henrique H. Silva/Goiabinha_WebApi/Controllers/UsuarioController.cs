using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Goiabinha_WebApi.Context;
using Goiabinha_WebApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Goiabinha_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuario;

        public UsuarioController(IUsuario usuario)
        {
            _usuario = usuario;
        }

        /// <summary>
        /// Método de listar todos os usuários do sistema.
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet]
        public IActionResult get()
        {
            var buscar = _usuario.get();
            if (buscar.Count != 0)
            {
                return Ok(buscar);
            }
            else
            {
                return NotFound("Nenhum usuário encontrado!!!");
            }
        }

        /// <summary>
        /// Método de buscar um usuário pelo ID.
        /// </summary>
        /// <returns>Return user by ID</returns>
        [HttpGet("{id}")]
        public IActionResult getById(string id)
        {
            var buscar = _usuario.getById(id);
            if (buscar != null)
            {
                return Ok(buscar);
            }
            else
            {
                return StatusCode(400, "Erro ao buscar um usuário!!!");
            }
        }

        /// <summary>
        /// Método de cadastrar um novo usuário no sistema.
        /// </summary>
        [HttpPost]
        public IActionResult post(Usuarios newUser)
        {
            if ((newUser.firstName != "" && newUser.firstName != null) && (newUser.surname != "" && newUser.surname != null) && newUser.age != 0)
            {
                _usuario.post(newUser);
                return StatusCode(201, "Usuário criado com sucesso!!!");
            }
            else
            {
                return StatusCode(400, "Erro com formato de dados recebido!!!");
            }
        }

        /// <summary>
        /// Método de atualizar um usuário no sistema.
        /// </summary>
        [HttpPut]
        public IActionResult put(Usuarios putUser)
        {
            var buscar = _usuario.getById(putUser.id);
            if (buscar != null)
            {
                _usuario.update(putUser.id, putUser);
                return StatusCode(202, "Usuário atualizado com sucesso!!!");
            }
            else
            {
                return StatusCode(400, "Erro ao atualizar usuário!!!");
            }
        }

        /// <summary>
        /// Método de deletar um usuário no sistema.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult delete(string id)
        {
            var buscar = _usuario.getById(id);
            if (buscar != null)
            {
                _usuario.delete(id);
                return StatusCode(202, "Usuário deletado com sucesso!!!");
            }
            else
            {
                return StatusCode(403, "Erro ao deletar usuário!!!");
            }
        }
    }
}