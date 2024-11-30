using System;
using System.Windows.Forms;

namespace BibliotecaApp
{
    public class FormPrincipal : Form
    {
        private readonly BibliotecaServico _servico;

        public FormPrincipal(BibliotecaServico servico)
        {
            _servico = servico;
            Text = "Gerenciador de Biblioteca";
            Width = 400;
            Height = 300;

            var btnCadastrar = new Button { Text = "Cadastrar Livro", Top = 20, Left = 20, Width = 120 };
            btnCadastrar.Click += (sender, args) =>
            {
                var formCadastro = new FormCadastro(_servico);
                formCadastro.ShowDialog();
            };

            var btnConsultar = new Button { Text = "Consultar Livros", Top = 60, Left = 20, Width = 120 };
            btnConsultar.Click += (sender, args) =>
            {
                var livros = _servico.ConsultarLivros();
                MessageBox.Show(string.Join(Environment.NewLine, livros.ConvertAll(l =>
                    $"{l.Titulo} por {l.Autor} (Disponível: {l.Disponivel})")));
            };

            Controls.Add(btnCadastrar);
            Controls.Add(btnConsultar);
        }
    }
}
