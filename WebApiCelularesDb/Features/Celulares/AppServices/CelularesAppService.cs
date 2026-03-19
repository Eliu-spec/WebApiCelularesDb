using WebApiCelularesDb.Commons.Models;
using WebApiCelularesDb.Entities;
using WebApiCelularesDb.Features.Celulares.DomainServices;
using WebApiCelularesDb.Features.Celulares.Interfaces;
using WebApiCelularesDb.Infrastucture.Interfaces;
using WebApiCelularesDb.Infrastucture.Repositories;

namespace WebApiCelularesDb.Features.Celulares.AppServices
{
    public class CelularesAppService : ICelularesAppService
    {
        private readonly CelularesDomainService celularesDomainService;
        private readonly ICelularesRepository celularesRepository;
        private readonly ICategoriasRepository categoriasRepository;

        public CelularesAppService(ICelularesRepository celularesRepository)
        {
            this.celularesRepository = celularesRepository;
            this.celularesDomainService = celularesDomainService;
            this.categoriasRepository = categoriasRepository;
        }

        public async Task<ApiResponse<Celular>> ActualizarCelular(Celular celular)
        {
            ApiResponse<Celular> apiResponseResult =
                celularesDomainService.GuardarCelular(celular);
            try
            {
                if (apiResponseResult.Success)
                {
                    await celularesRepository.GuardarCelular(celular);
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
        public async Task<ApiResponse<Celular>> GuardarCelular(Celular celular)
        {

            ApiResponse<Celular> apiResponseResult =
                celularesDomainService.GuardarCelular(celular);
            try
            {
                if (apiResponseResult.Success)
                {
                    await celularesRepository.GuardarCelular(celular);
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

        public async Task InactivarCelular(int id)
        {
            await celularesRepository.EliminarCelular(id);
        }
        public async Task<List<Celular>> ObtenerCelulares()
        {
            List<Categoria> categorias = await categoriasRepository.ObtenerCategorias();
            List<Celular> celulares = await celularesRepository.ObtenerCelulares();

            var celularesConCategorias =
                (from p in celulares
                 join c in categorias on p.CategoriaId equals c.Id
                 select new
                 {
                     p.Marca,
                     p.Descripcion,
                     c.Id

                 }).ToList();
            return await celularesRepository.ObtenerCelulares();
        }

        public async Task<Celular> ObtenerCelularPorId(int id)
        {
            return await celularesRepository.ObtenerCelularPorId(id);
        }

    }
}
