using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCelularesDb.Entities;
using WebApiCelularesDb.Features.Celulares.Interfaces;

namespace WebApiCelularesDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
         private readonly ICategoriasAppService categoriasAppService;
        public CategoriasController(ICategoriasAppService categoriasAppService)
        {
            this.categoriasAppService = categoriasAppService;
        }
        [HttpGet]
        public async Task<IActionResult> ObtenerCategorias()
        {
            List<Categoria> categorias = await categoriasAppService.ObtenerCategorias();
            return Ok(categorias);
        }
        [HttpPost]
        public async Task<IActionResult> AgregarCategoria([FromBody] Categoria categoria)
        {
            var respuesta = await categoriasAppService.AgregarCategoria(categoria);
            return Ok(respuesta);
        }
    }
}
