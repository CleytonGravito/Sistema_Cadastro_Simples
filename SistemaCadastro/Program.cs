using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Habilita estilos visuais modernos para os controles da aplicação.
            Application.EnableVisualStyles();

            // Define a renderização de texto como compatível com versões antigas do Windows Forms.
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicia a execução da aplicação com o formulário principal (Form1).
            Application.Run(new Form1());
        }
    }
}
