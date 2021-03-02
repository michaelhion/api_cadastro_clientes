
using Api_intelitrader.Domains;
using Api_intelitrader.Interface;
using Api_intelitrader.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api_intelitrader.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]

    public class EntidadeController : ControllerBase
    {
        private readonly IEntidadeRepository _entidadeRepository;

        public EntidadeController()
        {
            _entidadeRepository = new EntidadeRepository();
        }

        [HttpGet]
       
        public IActionResult Get()
        {
            return Ok(_entidadeRepository.Listar());
        }

      
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Entidade entidadeBuscada = _entidadeRepository.BuscarPorId(id);

                if (entidadeBuscada != null)
                {
                    return Ok(entidadeBuscada);
                }
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
            return BadRequest("Nenhuma usuario foi encontrado");
        }

        [HttpPost]
        public IActionResult Post(Entidade novaEntidade)
        {
            try
            {
                _entidadeRepository.Cadastrar(novaEntidade);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Entidade entidadeBuscada = _entidadeRepository.BuscarPorId(id);

                if (entidadeBuscada != null)
                {

                    _entidadeRepository.Deletar(id);

                    return StatusCode(202);
                }

                return NotFound("Nenhum filme encontrado para o ID informado.");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPut("{id}")]  
        public IActionResult Put(int id, Entidade entidadeAtualizada)
        {
            try
            {
                Entidade entidadeBuscada = _entidadeRepository.BuscarPorId(id);

                if (entidadeBuscada != null)
                {
                    _entidadeRepository.Atulizar(id, entidadeAtualizada);
                    return StatusCode(204);
                }
                return BadRequest("Usuario nao encontrado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }


}
