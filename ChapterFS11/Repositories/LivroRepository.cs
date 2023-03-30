using ChapterFS11.Contexts;
using ChapterFS11.Models;

namespace ChapterFS11.Repositories
{
    // classe onde manipulamos o banco de dados
    public class LivroRepository
    {
        private readonly SqlContext _context;
        public LivroRepository(SqlContext context)
        {
            _context = context;
        }

        public List<Livro> Listar()
        {
            return _context.Livros.ToList();
        }

        public Livro BuscarPorId(int id)
        {
            return _context.Livros.Find(id);
        }

        public void Cadastrar(Livro l)
        {
            _context.Livros.Add(l);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Livro l = _context.Livros.Find(id);
            _context.Livros.Remove(l);
            _context.SaveChanges();

        }

        public void Alterar(int id, Livro l)
        {
            Livro livrobuscado = _context.Livros.Find(id);

            if (livrobuscado != null)
            {
                livrobuscado.Titulo = l.Titulo;
                livrobuscado.QuantidadePaginas = l.QuantidadePaginas;
                livrobuscado.Disponivel = l.Disponivel;

                _context.Livros.Update(livrobuscado);
                _context.SaveChanges();

            }
        }
    }
}