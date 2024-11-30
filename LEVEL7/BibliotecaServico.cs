using System;
using System.Collections.Generic;

namespace BibliotecaApp
{
    public class BibliotecaServico
    {
        private readonly BibliotecaRepositorio _repositorio;

        public BibliotecaServico(BibliotecaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void CadastrarLivro(string titulo, string autor, string isbn, int paginas, string edicao)
        {
            var livros = _repositorio.ListarLivros();
            var livro = new Livro
            {
                Id = Guid.NewGuid(),
                Titulo = titulo,
                Autor = autor,
                ISBN = isbn,
                NumeroPaginas = paginas,
                Edicao = edicao,
                Disponivel = true
            };

            livros.Add(livro);
            _repositorio.SalvarLivros(livros);
        }

        public List<Livro> ConsultarLivros() => _repositorio.ListarLivros();

        public void AtualizarLivro(Guid id, string titulo, string autor, string isbn, int paginas, string edicao)
        {
            var livros = _repositorio.ListarLivros();
            var livro = livros.Find(l => l.Id == id);

            if (livro != null)
            {
                livro.Titulo = titulo;
                livro.Autor = autor;
                livro.ISBN = isbn;
                livro.NumeroPaginas = paginas;
                livro.Edicao = edicao;
                _repositorio.SalvarLivros(livros);
            }
        }

        public void RemoverLivro(Guid id)
        {
            var livros = _repositorio.ListarLivros();
            livros.RemoveAll(l => l.Id == id);
            _repositorio.SalvarLivros(livros);
        }

        public void EmprestarLivro(Guid id)
        {
            var livros = _repositorio.ListarLivros();
            var livro = livros.Find(l => l.Id == id);

            if (livro != null && livro.Disponivel)
            {
                livro.Disponivel = false;
                _repositorio.SalvarLivros(livros);
            }
        }

        public void DevolverLivro(Guid id)
        {
            var livros = _repositorio.ListarLivros();
            var livro = livros.Find(l => l.Id == id);

            if (livro != null && !livro.Disponivel)
            {
                livro.Disponivel = true;
                _repositorio.SalvarLivros(livros);
            }
        }
    }
}
