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
            this.UsuarioIdcomboBox = new System.Windows.Forms.ComboBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.Nivel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre De usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Contraseña";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Confirmar Contraseña";
            // 
            // EliminarButton
            // 
            this.EliminarButton.Image = global::ProyectoFinal.Properties.Resources.if_1_04_511562;
            this.EliminarButton.Location = new System.Drawing.Point(215, 260);
            this.EliminarButton.Name = "EliminarButton";
            this.EliminarButton.Size = new System.Drawing.Size(52, 45);
            this.EliminarButton.TabIndex = 13;
            this.EliminarButton.UseVisualStyleBackColor = true;
            // 
            // GuardarButton
            // 
            this.GuardarButton.Image = global::ProyectoFinal.Properties.Resources.if_floppy_285657;
            this.GuardarButton.Location = new System.Drawing.Point(121, 260);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(52, 45);
            this.GuardarButton.TabIndex = 12;
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // NuevoButton
            // 
            this.NuevoButton.Image = global::ProyectoFinal.Properties.Resources.if_manilla_folder_new_23456;
            this.NuevoButton.Location = new System.Drawing.Point(27, 260);
            this.NuevoButton.Name = "NuevoButton";
            this.NuevoButton.Size = new System.Drawing.Size(52, 45);
            this.NuevoButton.TabIndex = 11;
            this.NuevoButton.UseVisualStyleBackColor = true;
            this.NuevoButton.Click += new System.EventHandler(this.NuevoButton_Click);
            // 
            // Nivel
            // 
            this.Nivel.Controls.Add(this.UsuarioradioButton2);
            this.Nivel.Controls.Add(this.AdministradorRadioButton);
            this.Nivel.Location = new System.Drawing.Point(19, 200);
            this.Nivel.Name = "Nivel";
            this.Nivel.Size = new System.Drawing.Size(249, 54);
            this.Nivel.TabIndex = 14;
            this.Nivel.TabStop = false;
            this.Nivel.Text = "Nivel";
            // 
            // UsuarioradioButton2
            // 
            this.UsuarioradioButton2.AutoSize = true;
            this.UsuarioradioButton2.Location = new System.Drawing.Point(138, 18);
            this.UsuarioradioButton2.Name = "UsuarioradioButton2";
            this.UsuarioradioButton2.Size = new System.Drawing.Size(78, 21);
            this.UsuarioradioButton2.TabIndex = 1;
            this.UsuarioradioButton2.TabStop = true;
            this.UsuarioradioButton2.Text = "Usuario";
            this.UsuarioradioButton2.UseVisualStyleBackColor = true;
            // 
            // AdministradorRadioButton
            // 
            this.AdministradorRadioButton.AutoSize = true;
            this.AdministradorRadioButton.Location = new System.Drawing.Point(22, 18);
            this.AdministradorRadioButton.Name = "AdministradorRadioButton";
            this.AdministradorRadioButton.Size = new System.Drawing.Size(116, 21);
            this.AdministradorRadioButton.TabIndex = 0;
            this.AdministradorRadioButton.TabStop = true;
            this.AdministradorRadioButton.Text = "Administrador";
            this.AdministradorRadioButton.UseVisualStyleBackColor = true;
            // 
            // NombreUserTextBox
            // 
            this.NombreUserTextBox.Location = new System.Drawing.Point(168, 81);
            this.NombreUserTextBox.Name = "NombreUserTextBox";
            this.NombreUserTextBox.Size = new System.Drawing.Size(135, 22);
            this.NombreUserTextBox.TabIndex = 15;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(168, 111);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(135, 22);
            this.PasswordTextBox.TabIndex = 16;
            // 
            // ConfirmarPasswordTextBox
            // 
            this.ConfirmarPasswordTextBox.Location = new System.Drawing.Point(168, 141);
            this.ConfirmarPasswordTextBox.Name = "ConfirmarPasswordTextBox";
            this.ConfirmarPasswordTextBox.PasswordChar = '*';
            this.ConfirmarPasswordTextBox.Size = new System.Drawing.Size(135, 22);
            this.ConfirmarPasswordTextBox.TabIndex = 17;
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.Location = new System.Drawing.Point(168, 51);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(135, 22);
            this.NombreTextBox.TabIndex = 19;
            this.NombreTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NombreTextBox_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Nombre";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "Fecha de Registro";
            // 
            // FechaRegistrodateTimePicker
            // 
            this.FechaRegistrodateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.FechaRegistrodateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FechaRegistrodateTimePicker.Location = new System.Drawing.Point(168, 171);
            this.FechaRegistrodateTimePicker.Name = "FechaRegistrodateTimePicker";
            this.FechaRegistrodateTimePicker.Size = new System.Drawing.Size(135, 22);
            this.FechaRegistrodateTimePicker.TabIndex = 21;
            // 
            // UsuarioIdcomboBox
            // 
            this.UsuarioIdcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UsuarioIdcomboBox.FormattingEnabled = true;
            this.UsuarioIdcomboBox.Location = new System.Drawing.Point(168, 19);
            this.UsuarioIdcomboBox.Name = "UsuarioIdcomboBox";
            this.UsuarioIdcomboBox.Size = new System.Drawing.Size(121, 24);
            this.UsuarioIdcomboBox.TabIndex = 22;
            this.UsuarioIdcomboBox.SelectedIndexChanged += new System.EventHandler(this.UsuarioIdcomboBox_SelectedIndexChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // RegistroUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 324);
            this.Controls.Add(this.UsuarioIdcomboBox);
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
            this.Text = "Registro Usuario | AgroSoft";
            this.Nivel.ResumeLayout(false);
            this.Nivel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
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
        private System.Windows.Forms.ComboBox UsuarioIdcomboBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}