using Microsoft.EntityFrameworkCore;
using WebApiCelularesDb.Entities;
using WebApiCelularesDb.Infrastucture.Databases;
using WebApiCelularesDb.Infrastucture.Interfaces;

namespace WebApiCelularesDb.Infrastucture.Repositories
{
    public class CelularesRepository : ICelularesRepository
    {
        private readonly CelularesDbContext celularesDbContext;

        public CelularesRepository(CelularesDbContext celularesDbContext)
        {
            this.celularesDbContext = celularesDbContext;
        }

        public async Task ActualizarCelular(Celular celular)
        {
            Celular celularExistente =
                celularesDbContext.Celulares
                .FirstOrDefault(x => x.Id == celular.Id)!;

            celularExistente.Marca = celular.Marca;
            celularExistente.Modelo = celular.Modelo;
            celularExistente.Descripcion = celular.Descripcion;

            await celularesDbContext.SaveChangesAsync();

        }

        public async Task EliminarCelular(int id)
        {
            Celular celularExistente =
            celularesDbContext.Celulares
            .FirstOrDefault(x => x.Id == id)!;

            await celularesDbContext.SaveChangesAsync();
        }

        public async Task GuardarCelular(Celular celular)
        {
            celularesDbContext.Celulares.Add(celular);
            await celularesDbContext.SaveChangesAsync();
        }

        public async Task<List<Celular>> ObtenerCelulares()
        {
            return await celularesDbContext.Celulares.ToListAsync();
        }

        public async Task<Celular> ObtenerCelularPorId(int id)
        {
            Celular? celular =
                await celularesDbContext.Celulares.FirstOrDefaultAsync(x => x.Id == id);
            return celular ?? new Celular();
        }
    }
}
