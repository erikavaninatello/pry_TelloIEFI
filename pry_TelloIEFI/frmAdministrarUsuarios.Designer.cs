namespace pry_TelloIEFI
{
    partial class frmAdministrarUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministrarUsuarios));
            this.dtpHorarioFin = new System.Windows.Forms.DateTimePicker();
            this.dtpHorarioInicio = new System.Windows.Forms.DateTimePicker();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.txtTarea = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbRol = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtClave = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUsuario = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnBuscar = new Guna.UI2.WinForms.Guna2Button();
            this.txtNombreCompleto = new Guna.UI2.WinForms.Guna2TextBox();
            this.GestionUsuarios = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dtpFecha = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnEliminar = new Guna.UI2.WinForms.Guna2Button();
            this.btnModificar = new Guna.UI2.WinForms.Guna2Button();
            this.btnAgregar = new Guna.UI2.WinForms.Guna2Button();
            this.btnLimpiar = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.GestionUsuarios.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpHorarioFin
            // 
            this.dtpHorarioFin.Location = new System.Drawing.Point(640, 27);
            this.dtpHorarioFin.Name = "dtpHorarioFin";
            this.dtpHorarioFin.Size = new System.Drawing.Size(200, 20);
            this.dtpHorarioFin.TabIndex = 30;
            // 
            // dtpHorarioInicio
            // 
            this.dtpHorarioInicio.Location = new System.Drawing.Point(403, 27);
            this.dtpHorarioInicio.Name = "dtpHorarioInicio";
            this.dtpHorarioInicio.Size = new System.Drawing.Size(200, 20);
            this.dtpHorarioInicio.TabIndex = 29;
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvUsuarios.Location = new System.Drawing.Point(370, 73);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(646, 497);
            this.dgvUsuarios.TabIndex = 27;
            this.dgvUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellContentClick);
            // 
            // txtTarea
            // 
            this.txtTarea.AutoRoundedCorners = true;
            this.txtTarea.BackColor = System.Drawing.Color.LightCyan;
            this.txtTarea.BorderColor = System.Drawing.Color.Fuchsia;
            this.txtTarea.BorderThickness = 2;
            this.txtTarea.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTarea.DefaultText = "";
            this.txtTarea.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTarea.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTarea.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTarea.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTarea.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTarea.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTarea.ForeColor = System.Drawing.Color.Black;
            this.txtTarea.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTarea.Location = new System.Drawing.Point(50, 350);
            this.txtTarea.Name = "txtTarea";
            this.txtTarea.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtTarea.PlaceholderText = "Tarea";
            this.txtTarea.SelectedText = "";
            this.txtTarea.Size = new System.Drawing.Size(200, 36);
            this.txtTarea.TabIndex = 26;
            // 
            // cmbRol
            // 
            this.cmbRol.AutoRoundedCorners = true;
            this.cmbRol.BackColor = System.Drawing.Color.LightCyan;
            this.cmbRol.BorderColor = System.Drawing.Color.Fuchsia;
            this.cmbRol.BorderRadius = 17;
            this.cmbRol.BorderThickness = 2;
            this.cmbRol.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRol.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbRol.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbRol.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbRol.ForeColor = System.Drawing.Color.Black;
            this.cmbRol.ItemHeight = 30;
            this.cmbRol.Location = new System.Drawing.Point(50, 420);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(200, 36);
            this.cmbRol.TabIndex = 25;
            // 
            // txtClave
            // 
            this.txtClave.AutoRoundedCorners = true;
            this.txtClave.BackColor = System.Drawing.Color.LightCyan;
            this.txtClave.BorderColor = System.Drawing.Color.Fuchsia;
            this.txtClave.BorderThickness = 2;
            this.txtClave.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtClave.DefaultText = "";
            this.txtClave.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtClave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtClave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtClave.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtClave.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtClave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtClave.ForeColor = System.Drawing.Color.Black;
            this.txtClave.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtClave.Location = new System.Drawing.Point(50, 272);
            this.txtClave.Name = "txtClave";
            this.txtClave.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtClave.PlaceholderText = "Contraseña";
            this.txtClave.SelectedText = "";
            this.txtClave.Size = new System.Drawing.Size(200, 36);
            this.txtClave.TabIndex = 24;
            // 
            // txtUsuario
            // 
            this.txtUsuario.AutoRoundedCorners = true;
            this.txtUsuario.BackColor = System.Drawing.Color.LightCyan;
            this.txtUsuario.BorderColor = System.Drawing.Color.Fuchsia;
            this.txtUsuario.BorderThickness = 2;
            this.txtUsuario.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsuario.DefaultText = "";
            this.txtUsuario.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUsuario.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUsuario.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsuario.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsuario.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUsuario.ForeColor = System.Drawing.Color.Black;
            this.txtUsuario.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsuario.Location = new System.Drawing.Point(50, 202);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtUsuario.PlaceholderText = "Usuario";
            this.txtUsuario.SelectedText = "";
            this.txtUsuario.Size = new System.Drawing.Size(200, 36);
            this.txtUsuario.TabIndex = 23;
            // 
            // btnBuscar
            // 
            this.btnBuscar.AutoRoundedCorners = true;
            this.btnBuscar.BackColor = System.Drawing.Color.LightCyan;
            this.btnBuscar.BorderColor = System.Drawing.Color.Fuchsia;
            this.btnBuscar.BorderThickness = 2;
            this.btnBuscar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBuscar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBuscar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBuscar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBuscar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.Location = new System.Drawing.Point(235, 129);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(85, 36);
            this.btnBuscar.TabIndex = 22;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.AutoRoundedCorners = true;
            this.txtNombreCompleto.BackColor = System.Drawing.Color.LightCyan;
            this.txtNombreCompleto.BorderColor = System.Drawing.Color.Fuchsia;
            this.txtNombreCompleto.BorderThickness = 2;
            this.txtNombreCompleto.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNombreCompleto.DefaultText = "";
            this.txtNombreCompleto.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNombreCompleto.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNombreCompleto.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNombreCompleto.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNombreCompleto.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNombreCompleto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNombreCompleto.ForeColor = System.Drawing.Color.Black;
            this.txtNombreCompleto.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNombreCompleto.Location = new System.Drawing.Point(50, 129);
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtNombreCompleto.PlaceholderText = "Nombre";
            this.txtNombreCompleto.SelectedText = "";
            this.txtNombreCompleto.Size = new System.Drawing.Size(200, 36);
            this.txtNombreCompleto.TabIndex = 21;
            // 
            // GestionUsuarios
            // 
            this.GestionUsuarios.BorderColor = System.Drawing.Color.Fuchsia;
            this.GestionUsuarios.Controls.Add(this.dtpFecha);
            this.GestionUsuarios.Controls.Add(this.btnBuscar);
            this.GestionUsuarios.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.GestionUsuarios.FillColor = System.Drawing.Color.LightCyan;
            this.GestionUsuarios.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GestionUsuarios.ForeColor = System.Drawing.Color.Black;
            this.GestionUsuarios.Location = new System.Drawing.Point(21, 73);
            this.GestionUsuarios.Name = "GestionUsuarios";
            this.GestionUsuarios.Size = new System.Drawing.Size(332, 497);
            this.GestionUsuarios.TabIndex = 28;
            this.GestionUsuarios.Text = "Gestion usuarios";
            // 
            // dtpFecha
            // 
            this.dtpFecha.AutoRoundedCorners = true;
            this.dtpFecha.BackColor = System.Drawing.Color.Transparent;
            this.dtpFecha.BorderColor = System.Drawing.Color.Fuchsia;
            this.dtpFecha.BorderThickness = 2;
            this.dtpFecha.Checked = true;
            this.dtpFecha.FillColor = System.Drawing.Color.WhiteSmoke;
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFecha.ForeColor = System.Drawing.Color.Black;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpFecha.Location = new System.Drawing.Point(29, 430);
            this.dtpFecha.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFecha.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(209, 36);
            this.dtpFecha.TabIndex = 14;
            this.dtpFecha.UseTransparentBackground = true;
            this.dtpFecha.Value = new System.DateTime(2025, 5, 24, 16, 20, 7, 275);
            // 
            // btnEliminar
            // 
            this.btnEliminar.AutoRoundedCorners = true;
            this.btnEliminar.BorderColor = System.Drawing.Color.Fuchsia;
            this.btnEliminar.BorderThickness = 2;
            this.btnEliminar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEliminar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEliminar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEliminar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEliminar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEliminar.ForeColor = System.Drawing.Color.Black;
            this.btnEliminar.Location = new System.Drawing.Point(433, 592);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(112, 36);
            this.btnEliminar.TabIndex = 31;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.AutoRoundedCorners = true;
            this.btnModificar.BorderColor = System.Drawing.Color.Fuchsia;
            this.btnModificar.BorderThickness = 2;
            this.btnModificar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnModificar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnModificar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnModificar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnModificar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnModificar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnModificar.ForeColor = System.Drawing.Color.Black;
            this.btnModificar.Location = new System.Drawing.Point(582, 592);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(112, 36);
            this.btnModificar.TabIndex = 32;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.AutoRoundedCorners = true;
            this.btnAgregar.BorderColor = System.Drawing.Color.Fuchsia;
            this.btnAgregar.BorderThickness = 2;
            this.btnAgregar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAgregar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAgregar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAgregar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAgregar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAgregar.ForeColor = System.Drawing.Color.Black;
            this.btnAgregar.Location = new System.Drawing.Point(728, 592);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(112, 36);
            this.btnAgregar.TabIndex = 33;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.AutoRoundedCorners = true;
            this.btnLimpiar.BackColor = System.Drawing.Color.LightCyan;
            this.btnLimpiar.BorderColor = System.Drawing.Color.Fuchsia;
            this.btnLimpiar.BorderThickness = 2;
            this.btnLimpiar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLimpiar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLimpiar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLimpiar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLimpiar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.Black;
            this.btnLimpiar.Location = new System.Drawing.Point(145, 592);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(85, 36);
            this.btnLimpiar.TabIndex = 34;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // frmAdministrarUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1028, 672);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dtpHorarioFin);
            this.Controls.Add(this.dtpHorarioInicio);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.txtTarea);
            this.Controls.Add(this.cmbRol);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtNombreCompleto);
            this.Controls.Add(this.GestionUsuarios);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdministrarUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar Usuarios";
            this.Load += new System.EventHandler(this.frmAdministrarUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.GestionUsuarios.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpHorarioFin;
        private System.Windows.Forms.DateTimePicker dtpHorarioInicio;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private Guna.UI2.WinForms.Guna2TextBox txtTarea;
        private Guna.UI2.WinForms.Guna2ComboBox cmbRol;
        private Guna.UI2.WinForms.Guna2TextBox txtClave;
        private Guna.UI2.WinForms.Guna2TextBox txtUsuario;
        private Guna.UI2.WinForms.Guna2Button btnBuscar;
        private Guna.UI2.WinForms.Guna2TextBox txtNombreCompleto;
        private Guna.UI2.WinForms.Guna2GroupBox GestionUsuarios;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFecha;
        private Guna.UI2.WinForms.Guna2Button btnEliminar;
        private Guna.UI2.WinForms.Guna2Button btnModificar;
        private Guna.UI2.WinForms.Guna2Button btnAgregar;
        private Guna.UI2.WinForms.Guna2Button btnLimpiar;
    }
}