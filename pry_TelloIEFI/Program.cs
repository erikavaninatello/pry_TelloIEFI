using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pry_TelloIEFI
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmBienvenida bienvenida = new frmBienvenida();
            if (bienvenida.ShowDialog() != DialogResult.OK) return;

            string perfilSeleccionado = bienvenida.PerfilSeleccionado;

            frmInicioSesion login = new frmInicioSesion(perfilSeleccionado);
            if (login.ShowDialog() != DialogResult.OK) return;

            int idUsuario = login.IdUsuario;


            Application.Run(new frmPrincipal(idUsuario, perfilSeleccionado));

        }
    }
}
