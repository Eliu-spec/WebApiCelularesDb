using WebApiCelularesDb.Entities;

namespace WebApiCelularesDb.Infrastucture.Interfaces
{
    public interface ICategoriasRepository
    {
        Task<List<Categoria>> ObtenerCategorias();
        Task AgregarCategoria(Categoria categoria);
    }
}
