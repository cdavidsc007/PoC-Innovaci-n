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

        // GET: api/<CreditoController>
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
                    return NotFound(); // 404 Not Found response when the client with the given ID is not found.
                }

                return Ok(credito); // 200 OK response with the Credito data in the response body.
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an appropriate response (e.g., 500 Internal Server Error).
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/Credito
        [HttpPost]
        public IActionResult Post([FromBody] Credito credito)
        {
            try
            {

                _creditoService.New(credito);


                // If the client creation is successful, return 201 Created status code.
                // Also, include the created Credito in the response body.
                return Ok();
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an appropriate response (e.g., 500 Internal Server Error).
                return StatusCode(500, ex.Message);
            }
        }


        // PUT api/<CreditoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Credito updatedCredito)
        {
            try
            {
                var existingCredito = _creditoService.GetById(id);

                if (existingCredito == null)
                {
                    return NotFound(); // If the client with the given ID is not found, return 404 Not Found.
                }

                // Perform the update by merging the data from updatedCredito into existingCredito.
                


                _creditoService.Update(existingCredito); // Call the service method to update the client.

                return NoContent(); // 204 No Content response indicates successful update without a response body.
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an appropriate response (e.g., 500 Internal Server Error).
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<CreditoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _creditoService.Delete(id);
        }
    }
}
