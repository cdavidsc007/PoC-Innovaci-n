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
                    return NotFound(); 
                }

                return Ok(comercio); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

      
        [HttpPost]
        public IActionResult Post([FromBody] Comercio comercio)
        {
            try
            {

                _comercioService.Insert(comercio);

                return Ok();
            }
            catch (Exception ex)
            {
               return StatusCode(500, ex.Message);
            }
        }


     
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Comercio updatedComercio)
        {
            try
            {
                var existingComercio = _comercioService.GetById(id);

                if (existingComercio == null)
                {
                    return NotFound();
                }

             
                existingComercio.Nombre = updatedComercio.Nombre ?? existingComercio.Nombre;
                existingComercio.Direccion = updatedComercio.Direccion ?? existingComercio.Direccion;
                existingComercio.Telefono = updatedComercio.Telefono ?? existingComercio.Telefono;
                

                _comercioService.Update(existingComercio);

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
            _comercioService.Delete(id);
        }
    }
}

