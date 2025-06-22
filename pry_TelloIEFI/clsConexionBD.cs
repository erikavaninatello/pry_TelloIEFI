using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace pry_TelloIEFI
{
    public class clsConexionBD : IDisposable
    {
        private OleDbConnection conexion;

        private string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.Combine(Application.StartupPath, "SistemaEmpleados.mdb")};Persist Security Info=False;";



        public OleDbConnection AbrirConexion()
        {
            try
            {
                conexion = new OleDbConnection(connectionString);
                conexion.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar conectar con la base de datos:\n{ex.Message}", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            return conexion;
        }

        public void CerrarConexion()
        {
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }
        public static OleDbConnection ObtenerConexion()
        {
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.Combine(Application.StartupPath, "SistemaEmpleados.mdb")};Persist Security Info=False;";
            OleDbConnection conexion = new OleDbConnection(connectionString);
            conexion.Open();
            return conexion;
        }

        public void Dispose()
        {
            CerrarConexion();
            GC.SuppressFinalize(this);
        }
    }
}
