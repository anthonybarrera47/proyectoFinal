namespace ProyectoFinal.UI.Login
{
    partial class RegistroUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroUsuario));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.EliminarButton = new System.Windows.Forms.Button();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.NuevoButton = new System.Windows.Forms.Button();
            this.Nivel = new System.Windows.Forms.GroupBox();
            this.UsuarioradioButton2 = new System.Windows.Forms.RadioButton();
            this.AdministradorRadioButton = new System.Windows.Forms.RadioButton();
            this.NombreUserTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.ConfirmarPasswordTextBox = new System.Windows.Forms.TextBox();
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.FechaRegistrodateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.UsuarioTextBox = new System.Windows.Forms.TextBox();
            this.BuscarUsuarios = new System.Windows.Forms.PictureBox();
            this.Nivel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuscarUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "UsuarioID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre De usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Contraseña";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Confirmar Contraseña";
            // 
            // EliminarButton
            // 
            this.EliminarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EliminarButton.Image = global::ProyectoFinal.Properties.Resources.Eliminar;
            this.EliminarButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.EliminarButton.Location = new System.Drawing.Point(250, 216);
            this.EliminarButton.Name = "EliminarButton";
            this.EliminarButton.Size = new System.Drawing.Size(106, 63);
            this.EliminarButton.TabIndex = 8;
            this.EliminarButton.Text = "Eliminar";
            this.EliminarButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.EliminarButton.UseVisualStyleBackColor = true;
            this.EliminarButton.Click += new System.EventHandler(this.EliminarButton_Click);
            // 
            // GuardarButton
            // 
            this.GuardarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuardarButton.Image = global::ProyectoFinal.Properties.Resources.Guardar;
            this.GuardarButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.GuardarButton.Location = new System.Drawing.Point(139, 216);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(106, 63);
            this.GuardarButton.TabIndex = 7;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // NuevoButton
            // 
            this.NuevoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NuevoButton.Image = global::ProyectoFinal.Properties.Resources.nuevo;
            this.NuevoButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.NuevoButton.Location = new System.Drawing.Point(19, 216);
            this.NuevoButton.Name = "NuevoButton";
            this.NuevoButton.Size = new System.Drawing.Size(106, 63);
            this.NuevoButton.TabIndex = 6;
            this.NuevoButton.Text = "Nuevo";
            this.NuevoButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.NuevoButton.UseVisualStyleBackColor = true;
            this.NuevoButton.Click += new System.EventHandler(this.NuevoButton_Click);
            // 
            // Nivel
            // 
            this.Nivel.Controls.Add(this.UsuarioradioButton2);
            this.Nivel.Controls.Add(this.AdministradorRadioButton);
            this.Nivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nivel.Location = new System.Drawing.Point(19, 156);
            this.Nivel.Name = "Nivel";
            this.Nivel.Size = new System.Drawing.Size(339, 54);
            this.Nivel.TabIndex = 5;
            this.Nivel.TabStop = false;
            this.Nivel.Text = "Nivel";
            // 
            // UsuarioradioButton2
            // 
            this.UsuarioradioButton2.AutoSize = true;
            this.UsuarioradioButton2.Location = new System.Drawing.Point(157, 18);
            this.UsuarioradioButton2.Name = "UsuarioradioButton2";
            this.UsuarioradioButton2.Size = new System.Drawing.Size(93, 21);
            this.UsuarioradioButton2.TabIndex = 1;
            this.UsuarioradioButton2.TabStop = true;
            this.UsuarioradioButton2.Text = "Usuarios";
            this.UsuarioradioButton2.UseVisualStyleBackColor = true;
            // 
            // AdministradorRadioButton
            // 
            this.AdministradorRadioButton.AutoSize = true;
            this.AdministradorRadioButton.Location = new System.Drawing.Point(22, 18);
            this.AdministradorRadioButton.Name = "AdministradorRadioButton";
            this.AdministradorRadioButton.Size = new System.Drawing.Size(129, 21);
            this.AdministradorRadioButton.TabIndex = 0;
            this.AdministradorRadioButton.TabStop = true;
            this.AdministradorRadioButton.Text = "Administrador";
            this.AdministradorRadioButton.UseVisualStyleBackColor = true;
            // 
            // NombreUserTextBox
            // 
            this.NombreUserTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreUserTextBox.Location = new System.Drawing.Point(193, 65);
            this.NombreUserTextBox.MaxLength = 25;
            this.NombreUserTextBox.Name = "NombreUserTextBox";
            this.NombreUserTextBox.Size = new System.Drawing.Size(165, 22);
            this.NombreUserTextBox.TabIndex = 2;
            this.NombreUserTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NombreUserTextBox_KeyPress);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextBox.Location = new System.Drawing.Point(193, 86);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(165, 22);
            this.PasswordTextBox.TabIndex = 3;
            // 
            // ConfirmarPasswordTextBox
            // 
            this.ConfirmarPasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmarPasswordTextBox.Location = new System.Drawing.Point(193, 107);
            this.ConfirmarPasswordTextBox.Name = "ConfirmarPasswordTextBox";
            this.ConfirmarPasswordTextBox.PasswordChar = '*';
            this.ConfirmarPasswordTextBox.Size = new System.Drawing.Size(165, 22);
            this.ConfirmarPasswordTextBox.TabIndex = 4;
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreTextBox.Location = new System.Drawing.Point(193, 44);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(165, 22);
            this.NombreTextBox.TabIndex = 1;
            this.NombreTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NombreTextBox_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Nombre";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "Fecha de Registro";
            // 
            // FechaRegistrodateTimePicker
            // 
            this.FechaRegistrodateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.FechaRegistrodateTimePicker.Enabled = false;
            this.FechaRegistrodateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaRegistrodateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FechaRegistrodateTimePicker.Location = new System.Drawing.Point(193, 128);
            this.FechaRegistrodateTimePicker.Name = "FechaRegistrodateTimePicker";
            this.FechaRegistrodateTimePicker.Size = new System.Drawing.Size(165, 22);
            this.FechaRegistrodateTimePicker.TabIndex = 21;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // UsuarioTextBox
            // 
            this.UsuarioTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsuarioTextBox.Location = new System.Drawing.Point(193, 23);
            this.UsuarioTextBox.MaxLength = 9;
            this.UsuarioTextBox.Name = "UsuarioTextBox";
            this.UsuarioTextBox.Size = new System.Drawing.Size(165, 22);
            this.UsuarioTextBox.TabIndex = 0;
            this.UsuarioTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UsuarioTextBox_KeyPress);
            // 
            // BuscarUsuarios
            // 
            this.BuscarUsuarios.Image = global::ProyectoFinal.Properties.Resources.if_search_173095;
            this.BuscarUsuarios.Location = new System.Drawing.Point(364, 23);
            this.BuscarUsuarios.Name = "BuscarUsuarios";
            this.BuscarUsuarios.Size = new System.Drawing.Size(22, 20);
            this.BuscarUsuarios.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BuscarUsuarios.TabIndex = 62;
            this.BuscarUsuarios.TabStop = false;
            this.BuscarUsuarios.Click += new System.EventHandler(this.BuscarUsuarios_Click);
            // 
            // RegistroUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 290);
            this.Controls.Add(this.BuscarUsuarios);
            this.Controls.Add(this.UsuarioTextBox);
            this.Controls.Add(this.FechaRegistrodateTimePicker);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.NombreTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ConfirmarPasswordTextBox);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.NombreUserTextBox);
            this.Controls.Add(this.EliminarButton);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.NuevoButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Nivel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegistroUsuario";
            this.Text = "Registro Usuarios | AgroSoft";
            this.Nivel.ResumeLayout(false);
            this.Nivel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuscarUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button EliminarButton;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.Button NuevoButton;
        private System.Windows.Forms.GroupBox Nivel;
        private System.Windows.Forms.RadioButton UsuarioradioButton2;
        private System.Windows.Forms.RadioButton AdministradorRadioButton;
        private System.Windows.Forms.TextBox NombreUserTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox ConfirmarPasswordTextBox;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker FechaRegistrodateTimePicker;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox UsuarioTextBox;
        private System.Windows.Forms.PictureBox BuscarUsuarios;
    }
}