using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Templete.Data.Interface;
using Templete.Data.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class NotaController : ControllerBase
    {

        private readonly INota _NotaRepository;
        private readonly ICliente _ClienteRepository;

        public NotaController(INota nota, ICliente cliente)
        {
            _NotaRepository = nota;
            _ClienteRepository = cliente;
        }
        // GET: api/<NotaController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Nota> clientes = _NotaRepository.GetAll();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<NotaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Nota cliente = _NotaRepository.Get(id);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<NotaController>
        [HttpPost]
        public IActionResult Post([FromBody] Nota nota)
        {
            try
            {
                Cliente findClient = _ClienteRepository.GetClinteByEmail(nota.IdClienteNavigation.Email);
                nota.IdCliente = findClient.Id;
                nota.IdClienteNavigation = null;
                int Result = _NotaRepository.Insert(nota);
                if (Result == 1)
                {
                    return Created("Nota gravado com sucesso", nota);
                }
                else
                {
                    return Ok("Erro ao tentar registar a nota");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<NotaController>/5
        [HttpPost("update")]
        public IActionResult UpdateNote([FromBody] Nota nota)
        {
            try
            {
                int Result = _NotaRepository.Update(nota);
                if (Result == 1)
                {
                    Nota nota1 = _NotaRepository.FindNoteById(nota.Id);
                    return Ok(nota);
                }
                else
                {
                    Nota nota1 = _NotaRepository.FindNoteById(nota.Id);
                    return BadRequest(nota1);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<NotaController>/5
        [HttpGet("delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var result = _NotaRepository.Remove(id);
                if(result == 1)
                {
                    return Ok("Nota eliminado com sucesso");
                }
                else
                {
                    return BadRequest("Não foi possivél a nota");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
