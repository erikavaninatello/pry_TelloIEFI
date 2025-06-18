using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;


namespace pry_TelloIEFI
{
    public partial class frmPrincipal : Form
    {
        private Timer timer = new Timer();

        private DataGridView dgvTareasRecibido;
        private List<string> detalles;
        private string comentario;
        public frmPrincipal(DataGridView grillaTareas, int idUsuario, string perfilSeleccionado, List<string> detallesSeleccionados, string comentario)
        {
            InitializeComponent();

            this.dgvTareasRecibido = grillaTareas;
            this.detalles = detallesSeleccionados;
            this.comentario = comentario;


            this.FormClosing += frmPrincipal_FormClosing;
            this.Load += frmPrincipal_Load;
            timer.Tick += timer_Tick;

            this.dgvTareasRecibido = grillaTareas;
            this.detalles = detallesSeleccionados;
            this.comentario = comentario;

            if (clsSesionActual.Rol == "admin")
            {

            }
            else if (perfilSeleccionado == "Empleado")
            {

            }

            if (grillaTareas == null || detallesSeleccionados == null)
            {
                MessageBox.Show("Error al recibir los datos de tareas o detalles.");
            }
        }
        public frmPrincipal(int idUsuario, string perfilSeleccionado)
           : this(new DataGridView(), idUsuario, perfilSeleccionado, new List<string>(), "")
        {
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            lblHoraIngreso.Text = $"Hora: {DateTime.Now.ToShortTimeString()}";
        }
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = $"Usuario: {clsSesionActual.Usuario}";
            lblRol.Text = $"Rol: {clsSesionActual.Rol}";
            lblFechaIngreso.Text = $"Fecha: {DateTime.Now.ToShortDateString()}";
            lblHoraIngreso.Text = $"Hora: {DateTime.Now.ToShortTimeString()}";

            timer.Interval = 1000;
            timer.Start();


            clsAuditoria sesion = new clsAuditoria
            {
                IdUsuario = clsSesionActual.IdUsuario,
                FechaIngreso = DateTime.Now.Date,
                HoraIngreso = DateTime.Now.TimeOfDay
            };

            new clsUsuarioDAO().RegistrarInicioSesion(sesion);


            if (clsSesionActual.Rol == "admin")
            {
                pbReportePDF.Visible = true;
            }
        }

        private void pbUsuario_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ROL ACTUAL: " + clsSesionActual.Rol);
            if (clsSesionActual.Rol != "admin")
            {
                MessageBox.Show("No tiene permisos para acceder a esta sección.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmAdministrarUsuarios form = new frmAdministrarUsuarios();
            form.ShowDialog();
        }

        private void pbTareas_Click(object sender, EventArgs e)
        {
            frmRegistroTareas v = new frmRegistroTareas();
            v.ShowDialog();
        }

        private void pbReportePDF_Click(object sender, EventArgs e)
        {
            if (clsSesionActual.Rol != "admin")
            {
                MessageBox.Show("Solo los administradores pueden acceder al reporte.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvTareasRecibido == null || dgvTareasRecibido.Columns.Count == 0 || dgvTareasRecibido.Rows.Count == 0)
            {
                MessageBox.Show("No hay tareas cargadas para generar el PDF.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var auditorias = new clsUsuarioDAO().ObtenerAuditoriasPorUsuario(clsSesionActual.IdUsuario);
            var auditoriaActual = auditorias.LastOrDefault();

            SaveFileDialog saveFile = new SaveFileDialog
            {
                Filter = "PDF (*.pdf)|*.pdf",
                FileName = "ReporteCompleto.pdf"
            };

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream stream = new FileStream(saveFile.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 20f, 10f);
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();


                        var font12 = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK);
                        var font14 = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.BLACK);
                        var tituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLACK);


                        pdfDoc.Add(new Paragraph("Reporte completo de sesión y tareas", tituloFont)
                        {
                            Alignment = Element.ALIGN_CENTER
                        });
                        pdfDoc.Add(new Paragraph(" "));


                        pdfDoc.Add(new Paragraph($"Usuario: {clsSesionActual.Usuario}", font12));
                        pdfDoc.Add(new Paragraph($"Nombre completo: {clsSesionActual.NombreCompleto}", font12));
                        pdfDoc.Add(new Paragraph($"Rol: {clsSesionActual.Rol}", font12));


                        if (auditoriaActual != null)
                        {
                            string fechaIngreso = auditoriaActual.FechaIngreso.ToString("dd/MM/yyyy");
                            string horaIngreso = auditoriaActual.HoraIngreso?.ToString(@"hh\:mm") ?? "No disponible";
                            string horaSalida = auditoriaActual.HoraSalida?.ToString(@"hh\:mm") ?? "No disponible";

                            pdfDoc.Add(new Paragraph($"Fecha ingreso: {fechaIngreso}", font12));
                            pdfDoc.Add(new Paragraph($"Hora ingreso: {horaIngreso}", font12));
                            pdfDoc.Add(new Paragraph($"Hora salida: {horaSalida}", font12));
                        }
                        else
                        {
                            pdfDoc.Add(new Paragraph("No se encontró información de auditoría.", font12));
                        }

                        pdfDoc.Add(new Paragraph(" "));
                        pdfDoc.Add(new Paragraph("Tareas registradas:", font14));


                        PdfPTable pdfTable = new PdfPTable(dgvTareasRecibido.Columns.Count)
                        {
                            WidthPercentage = 100
                        };


                        foreach (DataGridViewColumn column in dgvTareasRecibido.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, font12))
                            {
                                BackgroundColor = new BaseColor(204, 229, 255)
                            };
                            pdfTable.AddCell(cell);
                        }


                        foreach (DataGridViewRow row in dgvTareasRecibido.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    string texto = cell.Value?.ToString() ?? "";
                                    pdfTable.AddCell(new Phrase(texto, font12));
                                }
                            }
                        }

                        pdfDoc.Add(pdfTable);
                        pdfDoc.Add(new Paragraph(" ", font12));
                        pdfDoc.Add(new Paragraph("Detalles adicionales:", font14));

                        if (detalles.Count > 0)
                        {
                            string detallesTexto = string.Join(", ", detalles);
                            pdfDoc.Add(new Paragraph("Detalles seleccionados: " + detallesTexto, font12));
                        }
                        else
                        {
                            pdfDoc.Add(new Paragraph("No se seleccionaron detalles adicionales.", font12));
                        }

                        if (!string.IsNullOrEmpty(comentario))
                        {
                            pdfDoc.Add(new Paragraph("Comentario: " + comentario, font12));
                        }

                        pdfDoc.Close();
                        stream.Close();
                    }

                    MessageBox.Show("Reporte PDF generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {

            if (clsSesionActual.IdAuditoria.HasValue)
            {
                clsAuditoria auditoria = new clsAuditoria
                {
                    IdUsuario = clsSesionActual.IdUsuario,
                    HoraSalida = DateTime.Now.TimeOfDay
                };

                clsUsuarioDAO dao = new clsUsuarioDAO();
                dao.RegistrarSalidaSesionPorId(clsSesionActual.IdAuditoria.Value, auditoria.HoraSalida.Value);
            }

            Application.Exit();
        }
        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegistrarSalida();
        }

        private void RegistrarSalida()
        {
            clsAuditoria auditoria = new clsAuditoria
            {
                IdUsuario = clsSesionActual.IdUsuario,
                FechaIngreso = DateTime.Now.Date,
                HoraSalida = DateTime.Now.TimeOfDay
            };

            new clsUsuarioDAO().RegistrarSalidaSesion(auditoria);
        }

        private void pbReporte_Click(object sender, EventArgs e)
        {
            frmReporte Form = new frmReporte();
            Form.ShowDialog();
        }
    }

}
    

