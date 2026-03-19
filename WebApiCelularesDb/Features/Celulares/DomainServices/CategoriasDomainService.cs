using WebApiCelularesDb.Commons.Models;
using WebApiCelularesDb.Entities;

namespace WebApiCelularesDb.Features.Celulares.DomainServices
{
    public class CategoriasDomainService
    {
        public ApiResponse<Categoria> AgregarCategoria(Categoria categoria)
        {
            ApiResponse<Categoria> apiResponse = new ApiResponse<Categoria>();
            apiResponse.Success = true;
            if (string.IsNullOrEmpty(categoria.Marca))
            {
                apiResponse.Success = false;
                apiResponse.Message = "La marca no puede ir vacia";
            }
            apiResponse.Data = categoria;
            return apiResponse;

        }
    }
}
