namespace pry_TelloIEFI
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.DatosPrincipal = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblFechaIngreso = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblHoraIngreso = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.pbReporte = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pbReportePDF = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pbTareas = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pbUsuario = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pbMenu = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblUsu = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTarea = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblPDF = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblReporte = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnCerrarSesion = new Guna.UI2.WinForms.Guna2CircleButton();
            this.DatosPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReportePDF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTareas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // DatosPrincipal
            // 
            this.DatosPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DatosPrincipal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.DatosPrincipal.Controls.Add(this.lblRol);
            this.DatosPrincipal.Controls.Add(this.lblFechaIngreso);
            this.DatosPrincipal.Controls.Add(this.lblHoraIngreso);
            this.DatosPrincipal.Controls.Add(this.lblUsuario);
            this.DatosPrincipal.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.DatosPrincipal.FillColor = System.Drawing.Color.LightCyan;
            this.DatosPrincipal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DatosPrincipal.ForeColor = System.Drawing.Color.Black;
            this.DatosPrincipal.Location = new System.Drawing.Point(399, 130);
            this.DatosPrincipal.Name = "DatosPrincipal";
            this.DatosPrincipal.Size = new System.Drawing.Size(176, 197);
            this.DatosPrincipal.TabIndex = 26;
            this.DatosPrincipal.Text = "¡Hola!";
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblRol.Location = new System.Drawing.Point(22, 91);
            this.lblRol.Name = "lblRol";
            this.lblRol.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblRol.Size = new System.Drawing.Size(10, 15);
            this.lblRol.TabIndex = 19;
            this.lblRol.Text = ".";
            // 
            // lblFechaIngreso
            // 
            this.lblFechaIngreso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblFechaIngreso.Location = new System.Drawing.Point(25, 128);
            this.lblFechaIngreso.Name = "lblFechaIngreso";
            this.lblFechaIngreso.Size = new System.Drawing.Size(6, 15);
            this.lblFechaIngreso.TabIndex = 16;
            this.lblFechaIngreso.Text = ".";
            // 
            // lblHoraIngreso
            // 
            this.lblHoraIngreso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblHoraIngreso.Location = new System.Drawing.Point(25, 165);
            this.lblHoraIngreso.Name = "lblHoraIngreso";
            this.lblHoraIngreso.Size = new System.Drawing.Size(6, 15);
            this.lblHoraIngreso.TabIndex = 17;
            this.lblHoraIngreso.Text = ".";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblUsuario.Location = new System.Drawing.Point(22, 52);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(10, 15);
            this.lblUsuario.TabIndex = 18;
            this.lblUsuario.Text = ".";
            // 
            // pbReporte
            // 
            this.pbReporte.BackColor = System.Drawing.Color.Lavender;
            this.pbReporte.Image = global::pry_TelloIEFI.Properties.Resources.icono_reporte2;
            this.pbReporte.ImageRotate = 0F;
            this.pbReporte.Location = new System.Drawing.Point(173, 306);
            this.pbReporte.Name = "pbReporte";
            this.pbReporte.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbReporte.Size = new System.Drawing.Size(88, 89);
            this.pbReporte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbReporte.TabIndex = 31;
            this.pbReporte.TabStop = false;
            this.pbReporte.Click += new System.EventHandler(this.pbReporte_Click);
            // 
            // pbReportePDF
            // 
            this.pbReportePDF.BackColor = System.Drawing.Color.Lavender;
            this.pbReportePDF.Image = global::pry_TelloIEFI.Properties.Resources.icono_reporte;
            this.pbReportePDF.ImageRotate = 0F;
            this.pbReportePDF.Location = new System.Drawing.Point(44, 306);
            this.pbReportePDF.Name = "pbReportePDF";
            this.pbReportePDF.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbReportePDF.Size = new System.Drawing.Size(88, 89);
            this.pbReportePDF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbReportePDF.TabIndex = 30;
            this.pbReportePDF.TabStop = false;
            this.pbReportePDF.Click += new System.EventHandler(this.pbReportePDF_Click);
            // 
            // pbTareas
            // 
            this.pbTareas.BackColor = System.Drawing.Color.Lavender;
            this.pbTareas.Image = global::pry_TelloIEFI.Properties.Resources.icono_tarea;
            this.pbTareas.ImageRotate = 0F;
            this.pbTareas.Location = new System.Drawing.Point(173, 129);
            this.pbTareas.Name = "pbTareas";
            this.pbTareas.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbTareas.Size = new System.Drawing.Size(88, 89);
            this.pbTareas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTareas.TabIndex = 29;
            this.pbTareas.TabStop = false;
            this.pbTareas.Click += new System.EventHandler(this.pbTareas_Click);
            // 
            // pbUsuario
            // 
            this.pbUsuario.BackColor = System.Drawing.Color.Lavender;
            this.pbUsuario.Image = global::pry_TelloIEFI.Properties.Resources.icono_usuarios;
            this.pbUsuario.ImageRotate = 0F;
            this.pbUsuario.Location = new System.Drawing.Point(44, 129);
            this.pbUsuario.Name = "pbUsuario";
            this.pbUsuario.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbUsuario.Size = new System.Drawing.Size(88, 89);
            this.pbUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUsuario.TabIndex = 28;
            this.pbUsuario.TabStop = false;
            this.pbUsuario.Click += new System.EventHandler(this.pbUsuario_Click);
            // 
            // pbMenu
            // 
            this.pbMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pbMenu.BorderRadius = 30;
            this.pbMenu.FillColor = System.Drawing.Color.Lavender;
            this.pbMenu.ImageRotate = 0F;
            this.pbMenu.Location = new System.Drawing.Point(24, 75);
            this.pbMenu.Name = "pbMenu";
            this.pbMenu.Size = new System.Drawing.Size(267, 382);
            this.pbMenu.TabIndex = 10;
            this.pbMenu.TabStop = false;
            // 
            // lblUsu
            // 
            this.lblUsu.BackColor = System.Drawing.Color.Transparent;
            this.lblUsu.Location = new System.Drawing.Point(60, 232);
            this.lblUsu.Name = "lblUsu";
            this.lblUsu.Size = new System.Drawing.Size(44, 15);
            this.lblUsu.TabIndex = 32;
            this.lblUsu.Text = "Usuarios";
            // 
            // lblTarea
            // 
            this.lblTarea.BackColor = System.Drawing.Color.Transparent;
            this.lblTarea.Location = new System.Drawing.Point(201, 232);
            this.lblTarea.Name = "lblTarea";
            this.lblTarea.Size = new System.Drawing.Size(36, 15);
            this.lblTarea.TabIndex = 33;
            this.lblTarea.Text = "Tareas";
            // 
            // lblPDF
            // 
            this.lblPDF.BackColor = System.Drawing.Color.Transparent;
            this.lblPDF.Location = new System.Drawing.Point(60, 418);
            this.lblPDF.Name = "lblPDF";
            this.lblPDF.Size = new System.Drawing.Size(65, 15);
            this.lblPDF.TabIndex = 34;
            this.lblPDF.Text = "Reporte PDF";
            // 
            // lblReporte
            // 
            this.lblReporte.BackColor = System.Drawing.Color.Transparent;
            this.lblReporte.Location = new System.Drawing.Point(182, 418);
            this.lblReporte.Name = "lblReporte";
            this.lblReporte.Size = new System.Drawing.Size(69, 15);
            this.lblReporte.TabIndex = 35;
            this.lblReporte.Text = "Reporte diario";
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BorderColor = System.Drawing.Color.Fuchsia;
            this.btnCerrarSesion.BorderThickness = 2;
            this.btnCerrarSesion.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCerrarSesion.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCerrarSesion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCerrarSesion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCerrarSesion.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.Black;
            this.btnCerrarSesion.Location = new System.Drawing.Point(693, 418);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnCerrarSesion.Size = new System.Drawing.Size(72, 74);
            this.btnCerrarSesion.TabIndex = 36;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(800, 528);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.lblReporte);
            this.Controls.Add(this.lblPDF);
            this.Controls.Add(this.lblTarea);
            this.Controls.Add(this.lblUsu);
            this.Controls.Add(this.pbReporte);
            this.Controls.Add(this.pbReportePDF);
            this.Controls.Add(this.pbTareas);
            this.Controls.Add(this.pbUsuario);
            this.Controls.Add(this.DatosPrincipal);
            this.Controls.Add(this.pbMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.DatosPrincipal.ResumeLayout(false);
            this.DatosPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReportePDF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTareas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox pbMenu;
        private Guna.UI2.WinForms.Guna2GroupBox DatosPrincipal;
        private System.Windows.Forms.Label lblRol;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFechaIngreso;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblHoraIngreso;
        private System.Windows.Forms.Label lblUsuario;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbUsuario;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbTareas;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbReportePDF;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbReporte;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUsu;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTarea;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPDF;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblReporte;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2CircleButton btnCerrarSesion;
    }
}