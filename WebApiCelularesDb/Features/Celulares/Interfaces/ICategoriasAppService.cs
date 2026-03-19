using WebApiCelularesDb.Commons.Models;
using WebApiCelularesDb.Entities;

namespace WebApiCelularesDb.Features.Celulares.Interfaces
{
    public interface ICategoriasAppService
    {
        Task<List<Categoria>> ObtenerCategorias();
        Task<ApiResponse<Categoria>> AgregarCategoria(Categoria categoria);
    }
}
