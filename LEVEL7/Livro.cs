using System;

namespace BibliotecaApp
{
    public class Livro
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int NumeroPaginas { get; set; }
        public string Edicao { get; set; }
        public bool Disponivel { get; set; }
    }
}
