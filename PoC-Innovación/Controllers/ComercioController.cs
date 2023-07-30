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
    public class ComercioController : ControllerBase
    {
        public readonly IComercioService _comercioService;

        // GET: api/<CreditoController>
        public ComercioController(IComercioService comercioService)
        {
            _comercioService = comercioService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<ComercioDTO>> Get()
        {
            var comercios = _comercioService.GetAll();
            return Ok(comercios);
        }
        
        [HttpGet("{id}")]
        public ActionResult<ComercioDTO> Get(int id)
        {
            try
            {
                var comercio = _comercioService.GetById(id);

                if (comercio == null)
                {
                    return NotFound(); // 404 Not Found response when the client with the given ID is not found.
                }

                return Ok(comercio); // 200 OK response with the Comercio data in the response body.
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an appropriate response (e.g., 500 Internal Server Error).
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/Comercio
        [HttpPost]
        public IActionResult Post([FromBody] Comercio comercio)
        {
            try
            {

                _comercioService.Insert(comercio);


                // If the client creation is successful, return 201 Created status code.
                // Also, include the created Comercio in the response body.
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
        public IActionResult Put(int id, [FromBody] Comercio updatedComercio)
        {
            try
            {
                var existingComercio = _comercioService.GetById(id);

                if (existingComercio == null)
                {
                    return NotFound(); // If the client with the given ID is not found, return 404 Not Found.
                }

                // Perform the update by merging the data from updatedComercio into existingComercio.
                existingComercio.Nombre = updatedComercio.Nombre ?? existingComercio.Nombre;
                existingComercio.Direccion = updatedComercio.Direccion ?? existingComercio.Direccion;
                existingComercio.Telefono = updatedComercio.Telefono ?? existingComercio.Telefono;
                

                _comercioService.Update(existingComercio); // Call the service method to update the client.

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
            _comercioService.Delete(id);
        }
    }
}

