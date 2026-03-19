using Microsoft.EntityFrameworkCore;
using WebApiCelularesDb.Entities;
using WebApiCelularesDb.Infrastucture.Databases;
using WebApiCelularesDb.Infrastucture.Interfaces;

namespace WebApiCelularesDb.Infrastucture.Repositories
{
    public class CategoriasRepository : ICategoriasRepository
    {
        private readonly CelularesDbContext celularesDbContext;
        public CategoriasRepository(CelularesDbContext celularesDbContext)
        {
            this.celularesDbContext = celularesDbContext;
        }

        public async Task AgregarCategoria(Categoria categoria)
        {
            await celularesDbContext.Categorias.AddAsync(categoria);
            await celularesDbContext.SaveChangesAsync();
        }

        public async Task<List<Categoria>> ObtenerCategorias()
        {
            return await celularesDbContext.Categorias.ToListAsync();
        }
    }
}
