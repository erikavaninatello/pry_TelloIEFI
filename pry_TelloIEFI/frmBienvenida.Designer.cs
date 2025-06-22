namespace pry_TelloIEFI
{
    partial class frmBienvenida
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBienvenida));
            this.lblBienvenida = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pbUsuario = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pbBienvenida = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pbAdmin = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblPerfil = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblAdmin = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblUsuario = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnVerUsuarios = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBienvenida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdmin)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.BackColor = System.Drawing.Color.Transparent;
            this.lblBienvenida.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblBienvenida.Location = new System.Drawing.Point(51, 82);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(323, 37);
            this.lblBienvenida.TabIndex = 1;
            this.lblBienvenida.Text = "¡Bienvenido a Kids Store!";
            // 
            // pbUsuario
            // 
            this.pbUsuario.Image = global::pry_TelloIEFI.Properties.Resources.icono_usuario;
            this.pbUsuario.ImageRotate = 0F;
            this.pbUsuario.Location = new System.Drawing.Point(250, 230);
            this.pbUsuario.Name = "pbUsuario";
            this.pbUsuario.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbUsuario.Size = new System.Drawing.Size(138, 160);
            this.pbUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUsuario.TabIndex = 3;
            this.pbUsuario.TabStop = false;
            this.pbUsuario.Click += new System.EventHandler(this.pbUsuario_Click);
            // 
            // pbBienvenida
            // 
            this.pbBienvenida.Image = global::pry_TelloIEFI.Properties.Resources.frmBienvenida;
            this.pbBienvenida.ImageRotate = 0F;
            this.pbBienvenida.Location = new System.Drawing.Point(429, 1);
            this.pbBienvenida.Name = "pbBienvenida";
            this.pbBienvenida.Size = new System.Drawing.Size(408, 520);
            this.pbBienvenida.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBienvenida.TabIndex = 2;
            this.pbBienvenida.TabStop = false;
            // 
            // pbAdmin
            // 
            this.pbAdmin.Image = global::pry_TelloIEFI.Properties.Resources.icono_admin;
            this.pbAdmin.ImageRotate = 0F;
            this.pbAdmin.Location = new System.Drawing.Point(25, 230);
            this.pbAdmin.Name = "pbAdmin";
            this.pbAdmin.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbAdmin.Size = new System.Drawing.Size(138, 160);
            this.pbAdmin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAdmin.TabIndex = 0;
            this.pbAdmin.TabStop = false;
            this.pbAdmin.Click += new System.EventHandler(this.pbAdmin_Click);
            // 
            // lblPerfil
            // 
            this.lblPerfil.BackColor = System.Drawing.Color.Transparent;
            this.lblPerfil.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerfil.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPerfil.Location = new System.Drawing.Point(101, 147);
            this.lblPerfil.Name = "lblPerfil";
            this.lblPerfil.Size = new System.Drawing.Size(213, 22);
            this.lblPerfil.TabIndex = 4;
            this.lblPerfil.Text = "Elegi un perfil para comenzar";
            // 
            // lblAdmin
            // 
            this.lblAdmin.BackColor = System.Drawing.Color.Transparent;
            this.lblAdmin.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdmin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAdmin.Location = new System.Drawing.Point(72, 409);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(43, 21);
            this.lblAdmin.TabIndex = 5;
            this.lblAdmin.Text = "Admin";
            // 
            // lblUsuario
            // 
            this.lblUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblUsuario.Location = new System.Drawing.Point(289, 409);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(50, 21);
            this.lblUsuario.TabIndex = 6;
            this.lblUsuario.Text = "Usuario";
            // 
            // btnVerUsuarios
            // 
            this.btnVerUsuarios.BorderColor = System.Drawing.Color.Fuchsia;
            this.btnVerUsuarios.BorderRadius = 2;
            this.btnVerUsuarios.BorderThickness = 2;
            this.btnVerUsuarios.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnVerUsuarios.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnVerUsuarios.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnVerUsuarios.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnVerUsuarios.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnVerUsuarios.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnVerUsuarios.ForeColor = System.Drawing.Color.Black;
            this.btnVerUsuarios.Location = new System.Drawing.Point(338, 473);
            this.btnVerUsuarios.Name = "btnVerUsuarios";
            this.btnVerUsuarios.Size = new System.Drawing.Size(50, 27);
            this.btnVerUsuarios.TabIndex = 7;
            this.btnVerUsuarios.Text = "Ver";
            this.btnVerUsuarios.Click += new System.EventHandler(this.btnVerUsuarios_Click);
            // 
            // frmBienvenida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(771, 523);
            this.Controls.Add(this.btnVerUsuarios);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblAdmin);
            this.Controls.Add(this.lblPerfil);
            this.Controls.Add(this.pbUsuario);
            this.Controls.Add(this.pbBienvenida);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.pbAdmin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBienvenida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bienvenida";
            this.Load += new System.EventHandler(this.frmBienvenida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBienvenida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdmin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox pbAdmin;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblBienvenida;
        private Guna.UI2.WinForms.Guna2PictureBox pbBienvenida;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbUsuario;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPerfil;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAdmin;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUsuario;
        private Guna.UI2.WinForms.Guna2Button btnVerUsuarios;
    }
}

