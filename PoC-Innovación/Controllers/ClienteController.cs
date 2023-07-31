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
                    return NotFound();
                }

                return Ok(cliente);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }





        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            try
            {
                _clienteService.Insert(cliente);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }



        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Cliente updatedCliente)
        {
            try
            {
                var existingCliente = _clienteService.GetById(id);

                if (existingCliente == null)
                {
                    return NotFound();
                }


                existingCliente.Nombre = updatedCliente.Nombre ?? existingCliente.Nombre;
                existingCliente.Apellido = updatedCliente.Apellido ?? existingCliente.Apellido;
                existingCliente.Direccion = updatedCliente.Direccion ?? existingCliente.Direccion;
                existingCliente.Telefono = updatedCliente.Telefono ?? existingCliente.Telefono;
                existingCliente.Cupo = updatedCliente.Cupo;
                existingCliente.Deuda = updatedCliente.Deuda;


                _clienteService.Update(existingCliente);

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
            _clienteService.Delete(id);
        }
    }
}
