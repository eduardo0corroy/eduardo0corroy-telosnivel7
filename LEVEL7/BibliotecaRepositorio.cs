using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace BibliotecaApp
{
    public class BibliotecaRepositorio
    {
        private readonly string _arquivoJson = "biblioteca.json";

        public List<Livro> ListarLivros()
        {
            if (!File.Exists(_arquivoJson))
                return new List<Livro>();

            var json = File.ReadAllText(_arquivoJson);
            return JsonSerializer.Deserialize<List<Livro>>(json) ?? new List<Livro>();
        }

        public void SalvarLivros(List<Livro> livros)
        {
            var json = JsonSerializer.Serialize(livros, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_arquivoJson, json);
        }
    }
}
