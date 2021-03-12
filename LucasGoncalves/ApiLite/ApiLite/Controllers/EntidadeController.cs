using ApiLite.Models;
using IntelitraderAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiLite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EntidadeController
    {
        private readonly EntityDbContext _entidadeContext;
        private readonly ILogger<EntidadeController> _logger;

        public EntidadeController(EntityDbContext entidadeContext, ILogger<EntidadeController> logger)
        {
            _entidadeContext = entidadeContext;

            _logger = logger;
        }

        /// <summary>
        /// Lista os usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Entidade>> GetEntidade()
        {
            _logger.LogInformation("Getting all the usuarios");
            return _entidadeContext.Entidades;
        }

        /// <summary>
        /// Busca um usuario pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um usuario</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            _logger.LogInformation("Getting the usuario by id", id);
            var ent = await _entidadeContext.Entidades.FirstOrDefaultAsync(x => x.Id == id);

            return new JsonResult(ent);
        }


        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="entidade"></param>
        [HttpPost]
        public async Task<IActionResult> Post(Entidade entidade)
        {

            _logger.LogInformation("Adding an usuario");

            entidade.Id = Guid.NewGuid().ToString();
            entidade.CreationDate = DateTime.Now;

            _entidadeContext.Entidades.Add(entidade);

            await _entidadeContext.SaveChangesAsync();

            return new JsonResult(entidade.Id);
        }


        /// <summary>
        /// Atualiza um usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entidade"></param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, Entidade entidade)
        {
            _logger.LogInformation("Changing an usuario by id");
            var existingUsuario = await _entidadeContext.Entidades.FirstOrDefaultAsync(x => x.Id == id);

            existingUsuario.FirstName = entidade.FirstName;

            existingUsuario.SurName = entidade.SurName;

            existingUsuario.Age = entidade.Age;

            existingUsuario.CreationDate = DateTime.Now;

            var success = (await _entidadeContext.SaveChangesAsync());

            return new JsonResult(success);
        }


        /// <summary>
        /// Deleta um usuario
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            _logger.LogInformation("Deleting an usuario by id");

            var ent = await _entidadeContext.Entidades.FirstOrDefaultAsync(x => x.Id == id);

            _entidadeContext.Remove(ent);

            var success = (await _entidadeContext.SaveChangesAsync());

            return new JsonResult(success);

        }




    }
}
