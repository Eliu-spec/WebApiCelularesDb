using WebApiCelularesDb.Commons.Models;
using WebApiCelularesDb.Entities;

namespace WebApiCelularesDb.Features.Celulares.DomainServices
{
    public class CelularesDomainService
    {
        public ApiResponse<Celular> GuardarCelular(Celular celular)
        {
            ApiResponse<Celular> apiResponse = new ApiResponse<Celular>();
            apiResponse.Success = true;
            if (string.IsNullOrEmpty(celular.Marca))
            {
                apiResponse.Success = false;
                apiResponse.Message = "El nombre del celular no puede ir vacio";
            }
            if (int.IsNegative(celular.CategoriaId))
            {
                apiResponse.Success = false;
                apiResponse.Message = "La Categoria del celular no puede ser negativo";
            }
            apiResponse.Data = celular;
            return apiResponse;

        }
    }
}
