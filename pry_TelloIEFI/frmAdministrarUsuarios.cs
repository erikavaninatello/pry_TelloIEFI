using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace pry_TelloIEFI
{
    public partial class frmAdministrarUsuarios : Form
    {
        private clsUsuarioDAO usuarioDAO = new clsUsuarioDAO();
        private int idSeleccionado = -1;
        public frmAdministrarUsuarios()
        {
            InitializeComponent();

            CargarUsuarios();
            CargarRoles();
            this.dgvUsuarios.CellContentClick += new DataGridViewCellEventHandler(this.dgvUsuarios_CellContentClick);

        }
        private void CargarUsuarios()
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = usuarioDAO.ObtenerUsuarios();

            dgvUsuarios.Columns["Id"].Visible = false;
            dgvUsuarios.Columns["Usuario"].Visible = true;
            dgvUsuarios.Columns["Clave"].Visible = true;
            dgvUsuarios.Columns["NombreCompleto"].Visible = true;
            dgvUsuarios.Columns["IdRol"].Visible = true;
            dgvUsuarios.Columns["Tarea"].Visible = true;
            dgvUsuarios.Columns["Fecha"].Visible = true;
            dgvUsuarios.Columns["HorarioInicio"].Visible = true;
            dgvUsuarios.Columns["HorarioFin"].Visible = true;
            dgvUsuarios.Columns["HorarioInicio"].DefaultCellStyle.Format = "HH:mm";
            dgvUsuarios.Columns["HorarioFin"].DefaultCellStyle.Format = "HH:mm";


        }

        private void CargarRoles()
        {
              List<clsRol> roles = new List<clsRol>
              {
               new clsRol { Id = 1, Nombre = "Admin" },
               new clsRol { Id = 2, Nombre = "Usuario" }
              };


            cmbRol.DataSource = roles;
            cmbRol.DisplayMember = "Nombre";
            cmbRol.ValueMember = "Id";
            cmbRol.SelectedIndex = 0;
        }
        private void frmAdministrarUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();

            dtpHorarioInicio.Format = DateTimePickerFormat.Time;
            dtpHorarioInicio.ShowUpDown = true;

            dtpHorarioFin.Format = DateTimePickerFormat.Time;
            dtpHorarioFin.ShowUpDown = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dtpHorarioInicio.Text) || string.IsNullOrEmpty(dtpHorarioFin.Text))
            {
                MessageBox.Show("Por favor, asigne un horario de ingreso y salida para el nuevo usuario.",
                                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsUsuario usuario = ObtenerDatosFormulario();

            if (string.IsNullOrEmpty(usuario.Usuario) || string.IsNullOrEmpty(usuario.Clave) ||
                string.IsNullOrEmpty(usuario.NombreCompleto) || string.IsNullOrEmpty(usuario.Tarea))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de agregar un usuario.",
                                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            usuarioDAO.AgregarUsuario(usuario);
            CargarUsuarios();


            MessageBox.Show("Usuario agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            if (idSeleccionado == -1)
            {
                MessageBox.Show("Seleccioná un usuario.");
                return;
            }


            dtpHorarioInicio.Format = DateTimePickerFormat.Time;
            dtpHorarioInicio.ShowUpDown = true;

            dtpHorarioFin.Format = DateTimePickerFormat.Time;
            dtpHorarioFin.ShowUpDown = true;

            clsUsuario usuario = ObtenerDatosFormulario();
            usuario.Id = idSeleccionado;


            usuarioDAO.ModificarUsuario(usuario);
            CargarUsuarios();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (idSeleccionado == -1)
            {
                MessageBox.Show("Seleccioná un usuario para eliminar.");
                return;
            }

            usuarioDAO.EliminarUsuario(idSeleccionado);
            CargarUsuarios();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string buscarTermino = txtUsuario.Text.Trim();

            if (string.IsNullOrEmpty(buscarTermino))
            {
                MessageBox.Show("Por favor ingrese un término de búsqueda.");
                return;
            }


            var usuariosFiltrados = usuarioDAO.ObtenerUsuarios()
                                               .Where(u => u.Usuario.Contains(buscarTermino))
                                               .ToList();


            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = usuariosFiltrados;
            dgvUsuarios.Columns["Id"].Visible = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles(this);
        }
        private void LimpiarControles(Control control)
        {
            foreach (Control ctrl in control.Controls)
            {
                if (ctrl is TextBox txt)
                {
                    txt.Clear();
                }
                else if (ctrl is ComboBox cb)
                {
                    cb.SelectedIndex = -1;
                }
                else if (ctrl is DateTimePicker dtp)
                {
                    dtp.Value = DateTime.Now;
                }
                else if (ctrl.HasChildren)
                {
                    LimpiarControles(ctrl); 
                }
            }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];

                idSeleccionado = Convert.ToInt32(fila.Cells["Id"].Value);
                txtUsuario.Text = fila.Cells["Usuario"].Value.ToString();
                txtClave.Text = fila.Cells["Clave"].Value.ToString();
                txtNombreCompleto.Text = fila.Cells["NombreCompleto"].Value.ToString();
                txtTarea.Text = fila.Cells["Tarea"].Value.ToString();
                dtpFecha.Value = Convert.ToDateTime(fila.Cells["Fecha"].Value);

              
                cmbRol.SelectedValue = Convert.ToInt32(fila.Cells["IdRol"].Value);

                if (fila.Cells["HorarioInicio"].Value != DBNull.Value && fila.Cells["HorarioInicio"].Value != null)
                {
                    dtpHorarioInicio.Value = DateTime.ParseExact(fila.Cells["HorarioInicio"].Value.ToString(), "HH:mm", null);
                }

                if (fila.Cells["HorarioFin"].Value != DBNull.Value && fila.Cells["HorarioFin"].Value != null)
                {
                    dtpHorarioFin.Value = DateTime.ParseExact(fila.Cells["HorarioFin"].Value.ToString(), "HH:mm", null);
                }
            }
        }
        private clsUsuario ObtenerDatosFormulario()
        {
            return new clsUsuario
            {
                Usuario = txtUsuario.Text,
                Clave = txtClave.Text,
                NombreCompleto = txtNombreCompleto.Text,
                IdRol = Convert.ToInt32(cmbRol.SelectedValue),
                Tarea = txtTarea.Text,
                Fecha = dtpFecha.Value,

                HorarioInicio = dtpHorarioInicio.Value.ToString("HH:mm"),
                HorarioFin = dtpHorarioFin.Value.ToString("HH:mm")
            };
        }
    }

}




