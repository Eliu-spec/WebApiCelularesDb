using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCelularesDb.Entities;
using WebApiCelularesDb.Features.Celulares.Interfaces;
using WebApiCelularesDb.Infrastucture.Interfaces;

namespace WebApiCelularesDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CelularesController : ControllerBase
    {
        private readonly ICelularesAppService celularesAppService;
        
        public CelularesController(ICelularesAppService celularesAppService)
        {
            this.celularesAppService = celularesAppService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerCelulares()
        {
            List<Celular> celulares = await celularesAppService.ObtenerCelulares();
            
            return Ok(celulares);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObtenerCelularPorId([FromRoute] int id)
        {
            Celular celular = await celularesAppService.ObtenerCelularPorId(id);
            return Ok(celular);
        }
        [HttpPost]
        public async Task<IActionResult> GuardarCelular([FromBody] Celular celular)
        {
            var respuesta = await celularesAppService.GuardarCelular(celular);
            return Ok(respuesta);
        }
        [HttpPut]
        public async Task<IActionResult> ActualizarCelular([FromBody] Celular celular)
        {
            var respuesta = await celularesAppService.ActualizarCelular(celular);
            return Ok(respuesta);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> InactivarCelular([FromRoute] int id)
        {
            await celularesAppService.InactivarCelular(id);
            return Ok("Celular inactivado");
        }

    }
}
