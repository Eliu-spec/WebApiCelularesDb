using WebApiCelularesDb.Commons.Models;
using WebApiCelularesDb.Entities;
using WebApiCelularesDb.Features.Celulares.DomainServices;
using WebApiCelularesDb.Features.Celulares.Interfaces;
using WebApiCelularesDb.Infrastucture.Interfaces;

namespace WebApiCelularesDb.Features.Celulares.AppServices
{
    public class CategoriasAppService : ICategoriasAppService
    {
        public readonly ICategoriasRepository categoriasRepository;
        public readonly CategoriasDomainService categoriasDomainService;
        public CategoriasAppService(ICategoriasRepository categoriasRepository, CategoriasDomainService categoriasDomainService)
        {
            this.categoriasRepository = categoriasRepository;
            this.categoriasDomainService = categoriasDomainService;
        }

        public async Task<ApiResponse<Categoria>> AgregarCategoria(Categoria categoria)
        {
            ApiResponse<Categoria> apiResponseResult =
                categoriasDomainService.AgregarCategoria(categoria);
            try
            {
                if (apiResponseResult.Success)
                {
                    await categoriasRepository.AgregarCategoria(categoria);
                }
                return apiResponseResult;
            }
            catch (Exception ex)
            {
                apiResponseResult.Success = false;
                apiResponseResult.Message = ex.Message;
                return apiResponseResult;
            }
        }

        public async Task<List<Categoria>> ObtenerCategorias()
        {
            return await categoriasRepository.ObtenerCategorias();
        }
    }
}
