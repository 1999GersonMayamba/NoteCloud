using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Templete.Data.Interface;
using Templete.Data.Model;
using WebApi.Auth;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly ICliente _ClienteRepository;
        public ClienteController(ICliente ClienteRepository)
        {
            _ClienteRepository = ClienteRepository;
        }


      
        // GET: api/<ClienteController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Cliente> clientes = _ClienteRepository.GetAll();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
               Cliente cliente = _ClienteRepository.Get(id);
               return Ok(cliente);
            }
            catch (Exception ex)
            {
              return BadRequest(ex.Message);
            }
        }

        [HttpGet("Notes/{id}")]
        public IActionResult GetNotesCliente(Guid id)
        {
            try
            {
                Cliente cliente = _ClienteRepository.GetNote(id);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ClienteController>
        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            try
            {
                int Result = _ClienteRepository.Insert(cliente);
                if(Result == 1)
                {
                    return Created("Cliente registado com sucesso",cliente);
                }
                else
                {
                    return Ok("Erro ao tentar registar o cliente");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
