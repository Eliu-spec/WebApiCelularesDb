using System.Reflection.Metadata.Ecma335;

namespace WebApiCelularesDb.Entities
{
    public class Celular
    {
        public int Id { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Descripcion { get; set; }
        public int CategoriaId { get; set; }
    }
}
