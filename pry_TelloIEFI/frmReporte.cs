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
    public partial class frmReporte : Form
    {
        private clsUsuarioDAO usuarioDAO = new clsUsuarioDAO();
        public frmReporte()
        {
            InitializeComponent();
        }

        private void frmReporte_Load(object sender, EventArgs e)
        {
            try
            {
                var lista = usuarioDAO.ObtenerReporteCompleto();

         
                if (lista != null && lista.Count > 0)
                {
                    MessageBox.Show("Cargando " + lista.Count + " registros en el DataGridView.", "Depuración", MessageBoxButtons.OK, MessageBoxIcon.Information);

                 
                    dgvReporte.DataSource = lista;

                
                    if (dgvReporte.Columns.Contains("Usuario")) dgvReporte.Columns["Usuario"].HeaderText = "Usuario";
                    if (dgvReporte.Columns.Contains("NombreCompleto")) dgvReporte.Columns["NombreCompleto"].HeaderText = "Nombre";
                    if (dgvReporte.Columns.Contains("HorarioInicio")) dgvReporte.Columns["HorarioInicio"].HeaderText = "Hora Inicio";
                    if (dgvReporte.Columns.Contains("HorarioFin")) dgvReporte.Columns["HorarioFin"].HeaderText = "Hora Fin";
                    if (dgvReporte.Columns.Contains("FechaIngreso")) dgvReporte.Columns["FechaIngreso"].HeaderText = "Fecha Ingreso";
                    if (dgvReporte.Columns.Contains("HoraIngreso")) dgvReporte.Columns["HoraIngreso"].HeaderText = "Hora Ingreso";
                    if (dgvReporte.Columns.Contains("HoraSalida")) dgvReporte.Columns["HoraSalida"].HeaderText = "Hora Salida";
                    if (dgvReporte.Columns.Contains("FechaTarea")) dgvReporte.Columns["FechaTarea"].HeaderText = "Fecha Tarea";
                    if (dgvReporte.Columns.Contains("Tarea")) dgvReporte.Columns["Tarea"].HeaderText = "Tarea";
                    if (dgvReporte.Columns.Contains("Lugar")) dgvReporte.Columns["Lugar"].HeaderText = "Lugar";
                    if (dgvReporte.Columns.Contains("Comentario")) dgvReporte.Columns["Comentario"].HeaderText = "Comentario";
                    if (dgvReporte.Columns.Contains("Insumo")) dgvReporte.Columns["Insumo"].HeaderText = "Insumo";
                    if (dgvReporte.Columns.Contains("Estudio")) dgvReporte.Columns["Estudio"].HeaderText = "Estudio";
                    if (dgvReporte.Columns.Contains("Vacacion")) dgvReporte.Columns["Vacacion"].HeaderText = "Vacación";
                    if (dgvReporte.Columns.Contains("Recibo")) dgvReporte.Columns["Recibo"].HeaderText = "Recibo";
                    if (dgvReporte.Columns.Contains("Salario")) dgvReporte.Columns["Salario"].HeaderText = "Salario";

                  
                    dgvReporte.Columns["HoraIngreso"].DefaultCellStyle.Format = @"hh\:mm";
                    dgvReporte.Columns["HoraSalida"].DefaultCellStyle.Format = @"hh\:mm";
                }
                else
                {
                    MessageBox.Show("No se encontraron datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }


}


          



    

