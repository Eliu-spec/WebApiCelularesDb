using WebApiCelularesDb.Entities;

namespace WebApiCelularesDb.Infrastucture.Interfaces
{
    public interface ICelularesRepository
    {
        Task<List<Celular>> ObtenerCelulares();
        Task<Celular> ObtenerCelularPorId(int id);
        Task GuardarCelular(Celular celular);
        Task ActualizarCelular(Celular celular);
        Task EliminarCelular(int id);
    }
}
