using System.Security.Cryptography.X509Certificates;

namespace ChapterFS11.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public int QuantidadePaginas { get; set; }
        public bool Disponivel { get; set; }
    }
}
