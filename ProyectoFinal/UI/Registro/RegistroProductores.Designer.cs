namespace ProyectoFinal.UI.Registro
{
    partial class RegistroProductores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroProductores));
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.EliminarButton = new System.Windows.Forms.Button();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.NuevoButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.CedulaMasketTextBox = new System.Windows.Forms.MaskedTextBox();
            this.TelefonomaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.FechaNacimientodateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ProductorIdcomboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // EliminarButton
            // 
            this.EliminarButton.Image = global::ProyectoFinal.Properties.Resources.if_1_04_511562;
            this.EliminarButton.Location = new System.Drawing.Point(206, 178);
            this.EliminarButton.Name = "EliminarButton";
            this.EliminarButton.Size = new System.Drawing.Size(52, 45);
            this.EliminarButton.TabIndex = 7;
            this.EliminarButton.UseVisualStyleBackColor = true;
            this.EliminarButton.Click += new System.EventHandler(this.EliminarButton_Click);
            // 
            // GuardarButton
            // 
            this.GuardarButton.Image = global::ProyectoFinal.Properties.Resources.if_floppy_285657;
            this.GuardarButton.Location = new System.Drawing.Point(115, 178);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(52, 45);
            this.GuardarButton.TabIndex = 6;
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // NuevoButton
            // 
            this.NuevoButton.Image = global::ProyectoFinal.Properties.Resources.if_manilla_folder_new_23456;
            this.NuevoButton.Location = new System.Drawing.Point(17, 178);
            this.NuevoButton.Name = "NuevoButton";
            this.NuevoButton.Size = new System.Drawing.Size(52, 45);
            this.NuevoButton.TabIndex = 5;
            this.NuevoButton.UseVisualStyleBackColor = true;
            this.NuevoButton.Click += new System.EventHandler(this.NuevoButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Cedula";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Telefono";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Fecha De Nacimiento";
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.Location = new System.Drawing.Point(88, 63);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(191, 22);
            this.NombreTextBox.TabIndex = 1;
            this.NombreTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NombreTextBox_KeyPress);
            // 
            // CedulaMasketTextBox
            // 
            this.CedulaMasketTextBox.Location = new System.Drawing.Point(88, 92);
            this.CedulaMasketTextBox.Mask = "000-0000000-0";
            this.CedulaMasketTextBox.Name = "CedulaMasketTextBox";
            this.CedulaMasketTextBox.Size = new System.Drawing.Size(191, 22);
            this.CedulaMasketTextBox.TabIndex = 2;
            // 
            // TelefonomaskedTextBox
            // 
            this.TelefonomaskedTextBox.Location = new System.Drawing.Point(88, 121);
            this.TelefonomaskedTextBox.Mask = "000-000-0000";
            this.TelefonomaskedTextBox.Name = "TelefonomaskedTextBox";
            this.TelefonomaskedTextBox.Size = new System.Drawing.Size(191, 22);
            this.TelefonomaskedTextBox.TabIndex = 3;
            // 
            // FechaNacimientodateTimePicker
            // 
            this.FechaNacimientodateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.FechaNacimientodateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FechaNacimientodateTimePicker.Location = new System.Drawing.Point(173, 150);
            this.FechaNacimientodateTimePicker.Name = "FechaNacimientodateTimePicker";
            this.FechaNacimientodateTimePicker.Size = new System.Drawing.Size(106, 22);
            this.FechaNacimientodateTimePicker.TabIndex = 4;
            // 
            // ProductorIdcomboBox
            // 
            this.ProductorIdcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProductorIdcomboBox.FormattingEnabled = true;
            this.ProductorIdcomboBox.Location = new System.Drawing.Point(88, 32);
            this.ProductorIdcomboBox.Name = "ProductorIdcomboBox";
            this.ProductorIdcomboBox.Size = new System.Drawing.Size(191, 24);
            this.ProductorIdcomboBox.TabIndex = 0;
            this.ProductorIdcomboBox.SelectedIndexChanged += new System.EventHandler(this.ProductorIdcomboBox_SelectedIndexChanged);
            // 
            // RegistroProductores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 250);
            this.Controls.Add(this.ProductorIdcomboBox);
            this.Controls.Add(this.FechaNacimientodateTimePicker);
            this.Controls.Add(this.TelefonomaskedTextBox);
            this.Controls.Add(this.CedulaMasketTextBox);
            this.Controls.Add(this.NombreTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EliminarButton);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.NuevoButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RegistroProductores";
            this.Text = "Registro De Productores | AgroSoft";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button EliminarButton;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.Button NuevoButton;
        private System.Windows.Forms.MaskedTextBox TelefonomaskedTextBox;
        private System.Windows.Forms.MaskedTextBox CedulaMasketTextBox;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker FechaNacimientodateTimePicker;
        private System.Windows.Forms.ComboBox ProductorIdcomboBox;
    }
}