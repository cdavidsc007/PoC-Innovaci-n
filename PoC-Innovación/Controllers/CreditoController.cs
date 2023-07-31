using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Infraestructure;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PoC_Innovación.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditoController : ControllerBase
    {
        public readonly ICreditoService _creditoService;

        public CreditoController(ICreditoService creditoService)
        {
            _creditoService = creditoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CreditoDTO>> Get()
        {
            var creditos = _creditoService.GetAll();
            return Ok(creditos);
        }

        [HttpGet("{id}")]
        public ActionResult<CreditoDTO> Get(int id)
        {
            try
            {
                var credito = _creditoService.GetById(id);

                if (credito == null)
                {
                    return NotFound(); 
                }

                return Ok(credito); 
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Credito credito)
        {
            try
            {
               var result = _creditoService.New(credito);

                if(result == 1)
                {
                    return Ok(credito);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Credito updatedCredito)
        {
            try
            {
                var existingCredito = _creditoService.GetById(id);

                if (existingCredito == null)
                {
                    return NotFound();
                }

              
                _creditoService.Update(existingCredito); 

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _creditoService.Delete(id);
        }
    }
}
