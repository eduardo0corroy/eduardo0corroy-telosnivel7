using System;
using System.Windows.Forms;

namespace BibliotecaApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var repositorio = new BibliotecaRepositorio();
            var servico = new BibliotecaServico(repositorio);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormPrincipal(servico));
        }
    }
}
