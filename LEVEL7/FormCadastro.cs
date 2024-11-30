using System;
using System.Windows.Forms;

namespace BibliotecaApp
{
    public class FormCadastro : Form
    {
        private readonly BibliotecaServico _servico;

        private TextBox txtTitulo;
        private TextBox txtAutor;
        private TextBox txtISBN;
        private TextBox txtPaginas;
        private TextBox txtEdicao;

        public FormCadastro(BibliotecaServico servico)
        {
            _servico = servico;

            Text = "Cadastro de Livro";
            Width = 300;
            Height = 250;

            Label lblTitulo = new Label { Text = "Título:", Top = 20, Left = 20 };
            txtTitulo = new TextBox { Top = 20, Left = 80, Width = 180 };

            Label lblAutor = new Label { Text = "Autor:", Top = 60, Left = 20 };
            txtAutor = new TextBox { Top = 60, Left = 80, Width = 180 };

            Label lblISBN = new Label { Text = "ISBN:", Top = 100, Left = 20 };
            txtISBN = new TextBox { Top = 100, Left = 80, Width = 180 };

            Label lblPaginas = new Label { Text = "Páginas:", Top = 140, Left = 20 };
            txtPaginas = new TextBox { Top = 140, Left = 80, Width = 180 };

            Label lblEdicao = new Label { Text = "Edição:", Top = 180, Left = 20 };
            txtEdicao = new TextBox { Top = 180, Left = 80, Width = 180 };

            var btnSalvar = new Button { Text = "Salvar", Top = 220, Left = 100, Width = 80 };
            btnSalvar.Click += (sender, args) =>
            {
                _servico.CadastrarLivro(txtTitulo.Text, txtAutor.Text, txtISBN.Text,
                    int.Parse(txtPaginas.Text), txtEdicao.Text);
                MessageBox.Show("Livro cadastrado com sucesso!");
                Close();
            };

            Controls.Add(lblTitulo);
            Controls.Add(txtTitulo);
            Controls.Add(lblAutor);
            Controls.Add(txtAutor);
            Controls.Add(lblISBN);
            Controls.Add(txtISBN);
            Controls.Add(lblPaginas);
            Controls.Add(txtPaginas);
            Controls.Add(lblEdicao);
            Controls.Add(txtEdicao);
            Controls.Add(btnSalvar);
        }
    }
}
