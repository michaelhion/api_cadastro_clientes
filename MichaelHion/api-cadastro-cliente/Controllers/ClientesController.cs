using api_cadastro_cliente.Context;
using api_cadastro_cliente.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_cadastro_cliente.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientes _iclientes;

        public ClientesController(IClientes iclientes)
        {
            _iclientes = iclientes;
        }

        [HttpGet]
        public ActionResult listarCliente()
        {
            var buscar = _iclientes.listarCliente();
            if (buscar.Count != 0)
            {
                return Ok(buscar);
            }
            else
            {
                return NotFound("Nenhum usuário encontrado!!!");
            }
        }

        [HttpGet("{id}")]
        public IActionResult buscarPorId(string Id)
        {
            var buscar = _iclientes.findById(Id);
            if (buscar != null)
            {
                return Ok(buscar);
            }
            else
            {
                return StatusCode(404, "Usuario não encontrado!!!");
            }
        }


        [HttpDelete("{Id}")]
        public ActionResult deleteCliente(string Id)
        {
            var existe = _iclientes.findById(Id);
            if (existe != null)
            {
                _iclientes.deleteCliente(Id);
                return StatusCode(200, "Cliente deletado com sucesso!");
            }
            else
            {
                return StatusCode(404, "cliente não encontrado!");
            }


        }

        [HttpPost]
        public ActionResult inserir(ClienteModel cliente)
        {
            if ((cliente.FirstName != "" && cliente.FirstName != null) && (cliente.Surname != "" && cliente.Surname != null) && cliente.Age != 0)
            {

                _iclientes.inserirCliente(cliente);

                return StatusCode(201, "Usuário criado com sucesso!!!");
            }
            else
            {
                return StatusCode(400, "Erro com formato de dados recebido!!!");
            }
        }

        [HttpPut("{Id}")]
        public IActionResult put(string Id, ClienteModel cliente)
        {
            var buscar = _iclientes.findById(Id);
            if (buscar != null)
            {
                cliente.creationDate = DateTime.Now;
                _iclientes.editarCliente(cliente.Id, cliente);
                return StatusCode(202, "Usuario atualizado com suceso!");
            }
            else
            {
                return StatusCode(404, "Usuario não encontrado");
            }
        }

    }
}

