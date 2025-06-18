using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pry_TelloIEFI
{
    public partial class frmInicioSesion : Form
    {
        private string perfilSeleccionado;
        public int IdUsuario { get; set; }
       
        public frmInicioSesion(string perfil)
        {
            InitializeComponent();

            perfilSeleccionado = perfil;
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuario.Text;
            string clave = txtClave.Text;


            clsUsuarioDAO dao = new clsUsuarioDAO();

            if (dao.ValidarUsuario(nombreUsuario, clave))
            {
                int idUsuario = dao.ObtenerIdUsuario(nombreUsuario);
                var usuario = dao.ObtenerUsuarios().FirstOrDefault(u => u.Id == idUsuario);

                if (usuario != null)
                {

                    clsSesionActual.IdUsuario = usuario.Id;
                    clsSesionActual.Usuario = usuario.Usuario;
                    clsSesionActual.NombreCompleto = usuario.NombreCompleto;
                    clsSesionActual.Rol = usuario.IdRol == 1 ? "admin" : "Empleado";


                    clsAuditoria auditoria = new clsAuditoria
                    {
                        IdUsuario = usuario.Id,
                        FechaIngreso = DateTime.Today,
                        HoraIngreso = DateTime.Now.TimeOfDay,
                        HoraSalida = null
                    };

                    

                    int idAuditoria = dao.RegistrarInicioSesion(auditoria);
                    clsSesionActual.IdAuditoria = idAuditoria;


                    DataGridView grillaTareas = new DataGridView();
                    this.IdUsuario = usuario.Id;
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Usuario no encontrado.");
                }
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas.");
            }
        }

        private void frmInicioSesion_Load(object sender, EventArgs e)
        {
            txtClave.PasswordChar = '*';
        }
    }
}
