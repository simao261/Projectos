using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuildLab
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BuildLab loginForm = new BuildLab();

            // Abre o login e mantém o programa ativo
            Application.Run(loginForm);

            // Só continua se o login for feito
            if (loginForm.Autenticado)
            {
                Form nextForm;

                if (loginForm.Role == "admin")
                    nextForm = new GestaoUtilizadores();
                else
                    nextForm = new Utilizador();

                Application.Run(nextForm);
            }

        }
    }
}
