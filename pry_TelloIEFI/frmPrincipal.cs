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

            this.dgvTareasRecibido = grillaTareas ?? new DataGridView();
            this.detalles = detallesSeleccionados ?? new List<string>();
            this.comentario = comentario ?? "";

            this.FormClosing += frmPrincipal_FormClosing;
            this.Load += frmPrincipal_Load;
            timer.Tick += timer_Tick;

            if (clsSesionActual.Rol != "admin" && perfilSeleccionado != "Empleado")
            {
                MessageBox.Show("Error: Rol o perfil no válidos.");
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

            var lista = new clsUsuarioDAO().ObtenerReporteCompleto();
            var tareas = lista.Where(r => r.Usuario == clsSesionActual.Usuario).ToList();
            var auditoriaActual = new clsUsuarioDAO().ObtenerAuditoriasPorUsuario(clsSesionActual.IdUsuario).LastOrDefault();

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

                        pdfDoc.Add(new Paragraph("Reporte completo de sesión y tareas", tituloFont) { Alignment = Element.ALIGN_CENTER });
                        pdfDoc.Add(new Paragraph(" "));

                        pdfDoc.Add(new Paragraph($"Usuario: {clsSesionActual.Usuario}", font12));
                        pdfDoc.Add(new Paragraph($"Nombre completo: {clsSesionActual.NombreCompleto}", font12));
                        pdfDoc.Add(new Paragraph($"Rol: {clsSesionActual.Rol}", font12));

                        if (auditoriaActual != null)
                        {
                            pdfDoc.Add(new Paragraph($"Fecha ingreso: {auditoriaActual.FechaIngreso:dd/MM/yyyy}", font12));
                            pdfDoc.Add(new Paragraph($"Hora ingreso: {auditoriaActual.HoraIngreso:hh\\:mm}", font12));
                            pdfDoc.Add(new Paragraph($"Hora salida: {auditoriaActual.HoraSalida:hh\\:mm}", font12));
                        }
                        else
                        {
                            pdfDoc.Add(new Paragraph("No se encontró información de auditoría.", font12));
                        }

                        pdfDoc.Add(new Paragraph(" "));
                        pdfDoc.Add(new Paragraph("Tareas registradas:", font14));
                        pdfDoc.Add(new Paragraph(" "));

                        if (tareas.Count > 0)
                        {
                            PdfPTable pdfTable = new PdfPTable(10)
                            {
                                WidthPercentage = 100
                            };

                            string[] headers = { "Tarea", "Lugar", "Comentario", "Fecha", "Hora", "Insumo", "Estudio", "Vacación", "Recibo", "Salario" };
                            foreach (var header in headers)
                            {
                                pdfTable.AddCell(new PdfPCell(new Phrase(header, font12))
                                {
                                    BackgroundColor = new BaseColor(204, 229, 255) // celeste pastel
                                });
                            }

                            foreach (var tarea in tareas)
                            {
                                pdfTable.AddCell(new Phrase(tarea.Tarea ?? "", font12));
                                pdfTable.AddCell(new Phrase(tarea.Lugar ?? "", font12));
                                pdfTable.AddCell(new Phrase(tarea.Comentario ?? "", font12));
                                pdfTable.AddCell(new Phrase(tarea.FechaTarea?.ToString("dd/MM/yyyy") ?? "", font12));
                                pdfTable.AddCell(new Phrase(tarea.HoraIngreso?.ToString(@"hh\:mm") ?? "", font12));
                                pdfTable.AddCell(new Phrase(tarea.Insumo ? "Sí" : "No", font12));
                                pdfTable.AddCell(new Phrase(tarea.Estudio ? "Sí" : "No", font12));
                                pdfTable.AddCell(new Phrase(tarea.Vacacion ? "Sí" : "No", font12));
                                pdfTable.AddCell(new Phrase(tarea.Recibo ? "Sí" : "No", font12));
                                pdfTable.AddCell(new Phrase(tarea.Salario ? "Sí" : "No", font12));
                            }

                            pdfDoc.Add(pdfTable);
                        }
                        else
                        {
                            pdfDoc.Add(new Paragraph("No hay tareas registradas.", font12));
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
    }

}
    

