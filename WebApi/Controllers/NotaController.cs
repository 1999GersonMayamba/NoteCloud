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
    [Route("api/[controller]")]
    [ApiController]
    public class NotaController : ControllerBase
    {

        private readonly INota _NotaRepository;

        public NotaController(INota nota)
        {
            _NotaRepository = nota;
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
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<NotaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
