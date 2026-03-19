using Microsoft.EntityFrameworkCore;
using WebApiCelularesDb.Entities;

namespace WebApiCelularesDb.Infrastucture.Databases
{
    public class CelularesDbContext : DbContext
    {
        public CelularesDbContext(DbContextOptions options) : base(options)
        {
        }


        //Tablas
        public DbSet<Celular> Celulares => Set<Celular>();
        public DbSet<Categoria> Categorias => Set<Categoria>();

        //Mapeos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   //Mapeo para tabla celulares
            modelBuilder.Entity<Celular>(entity =>
            {
                entity.ToTable("Celulares");
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("INT");

                entity.Property(x => x.Marca)
                .HasColumnName("Marca")
                .HasColumnType("VARCHAR(500)");

                entity.Property(x => x.Modelo)
                .HasColumnName("Modelo")
                .HasColumnType("VARCAHR(500)");

                entity.Property(x => x.Descripcion)
                .HasColumnName("Descripcion")
                .HasColumnType("VARCHAR(500)");

                entity.Property(x => x.CategoriaId)
                .HasColumnName("CategoriaId")
                .HasColumnType("INT");

            });

            //MAPEO DE TABLA DE CATEGORIA
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("Categorias");
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("INT");

                entity.Property(x => x.Marca)
                .HasColumnName("Marca")
                .HasColumnType("VARCHAR(250)");
            });



        }
    }
}
