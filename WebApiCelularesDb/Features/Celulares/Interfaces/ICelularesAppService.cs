using WebApiCelularesDb.Commons.Models;
using WebApiCelularesDb.Entities;

namespace WebApiCelularesDb.Features.Celulares.Interfaces
{
    public interface ICelularesAppService
    {
        Task<List<Celular>> ObtenerCelulares();
        Task<ApiResponse<Celular>> GuardarCelular(Celular celular);
        Task<ApiResponse<Celular>> ActualizarCelular(Celular celular);
        Task<Celular> ObtenerCelularPorId(int id);
        Task InactivarCelular(int id);
        
    }
}
