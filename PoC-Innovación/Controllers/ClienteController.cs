using Application.DTO;
using Application.Interfaces;
using Domain;
using Infraestructure;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PoC_Innovación.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public readonly IClienteService _clienteService;

        // GET: api/<CreditoController>
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<ClienteDTO>> Get()
        {
            var customers = _clienteService.GetAll();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public ActionResult<ClienteDTO> Get(int id)
        {
            try
            {
                var cliente = _clienteService.GetById(id);

                if (cliente == null)
                {
                    return NotFound(); // 404 Not Found response when the client with the given ID is not found.
                }

                return Ok(cliente); // 200 OK response with the cliente data in the response body.
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an appropriate response (e.g., 500 Internal Server Error).
                return StatusCode(500, ex.Message);
            }
        }


            // POST api/<CreditoController>
           
        // POST: api/cliente
        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            try
            {
                
                _clienteService.Insert(cliente);


                // If the client creation is successful, return 201 Created status code.
                // Also, include the created cliente in the response body.
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
        public IActionResult Put(int id, [FromBody] Cliente updatedCliente)
        {
            try
            {
                var existingCliente = _clienteService.GetById(id);

                if (existingCliente == null)
                {
                    return NotFound(); // If the client with the given ID is not found, return 404 Not Found.
                }

                // Perform the update by merging the data from updatedCliente into existingCliente.
                existingCliente.Nombre = updatedCliente.Nombre ?? existingCliente.Nombre;
                existingCliente.Apellido = updatedCliente.Apellido ?? existingCliente.Apellido;
                existingCliente.Direccion = updatedCliente.Direccion ?? existingCliente.Direccion;
                existingCliente.Telefono = updatedCliente.Telefono ?? existingCliente.Telefono;
                existingCliente.Cupo = updatedCliente.Cupo;
                existingCliente.Deuda = updatedCliente.Deuda;
                // Update other properties as needed...

                _clienteService.Update(existingCliente); // Call the service method to update the client.

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
            _clienteService.Delete(id);
        }
    }
}
