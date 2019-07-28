namespace ProyectoFinal.UI.Consulta
{
    partial class ConsultaDeFactorias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultaDeFactorias));
            this.FiltrocomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FactoriasdataGridView = new System.Windows.Forms.DataGridView();
            this.CriteriotextBox = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ImprimirButton = new System.Windows.Forms.Button();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.FiltracheckBox = new System.Windows.Forms.CheckBox();
            this.HastadateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.DesdedateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TotalTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FactoriasdataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // FiltrocomboBox
            // 
            this.FiltrocomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FiltrocomboBox.FormattingEnabled = true;
            this.FiltrocomboBox.Items.AddRange(new object[] {
            "Todo",
            "ID",
            "Nombre",
            "Direccion",
            "Telefono"});
            this.FiltrocomboBox.Location = new System.Drawing.Point(15, 43);
            this.FiltrocomboBox.Name = "FiltrocomboBox";
            this.FiltrocomboBox.Size = new System.Drawing.Size(121, 24);
            this.FiltrocomboBox.TabIndex = 0;
            this.FiltrocomboBox.SelectedIndexChanged += new System.EventHandler(this.FiltrocomboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filtro";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(151, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Criterio";
            // 
            // FactoriasdataGridView
            // 
            this.FactoriasdataGridView.AllowUserToAddRows = false;
            this.FactoriasdataGridView.AllowUserToDeleteRows = false;
            this.FactoriasdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FactoriasdataGridView.Location = new System.Drawing.Point(15, 104);
            this.FactoriasdataGridView.MultiSelect = false;
            this.FactoriasdataGridView.Name = "FactoriasdataGridView";
            this.FactoriasdataGridView.ReadOnly = true;
            this.FactoriasdataGridView.RowHeadersWidth = 51;
            this.FactoriasdataGridView.RowTemplate.Height = 24;
            this.FactoriasdataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FactoriasdataGridView.Size = new System.Drawing.Size(847, 503);
            this.FactoriasdataGridView.TabIndex = 8;
            // 
            // CriteriotextBox
            // 
            this.CriteriotextBox.Location = new System.Drawing.Point(154, 43);
            this.CriteriotextBox.Name = "CriteriotextBox";
            this.CriteriotextBox.Size = new System.Drawing.Size(378, 22);
            this.CriteriotextBox.TabIndex = 1;
            this.CriteriotextBox.TextChanged += new System.EventHandler(this.CriteriotextBox_TextChanged);
            this.CriteriotextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CriteriotextBox_KeyPress);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ImprimirButton
            // 
            this.ImprimirButton.Image = global::ProyectoFinal.Properties.Resources.iconfinder_006_printer_3925426;
            this.ImprimirButton.Location = new System.Drawing.Point(754, 10);
            this.ImprimirButton.Name = "ImprimirButton";
            this.ImprimirButton.Size = new System.Drawing.Size(103, 88);
            this.ImprimirButton.TabIndex = 3;
            this.ImprimirButton.UseVisualStyleBackColor = true;
            this.ImprimirButton.Click += new System.EventHandler(this.ImprimirButton_Click_1);
            // 
            // BuscarButton
            // 
            this.BuscarButton.Image = global::ProyectoFinal.Properties.Resources.if_search_1730951;
            this.BuscarButton.Location = new System.Drawing.Point(538, 22);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(52, 45);
            this.BuscarButton.TabIndex = 2;
            this.BuscarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click_1);
            // 
            // FiltracheckBox
            // 
            this.FiltracheckBox.AutoSize = true;
            this.FiltracheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FiltracheckBox.Location = new System.Drawing.Point(16, 78);
            this.FiltracheckBox.Name = "FiltracheckBox";
            this.FiltracheckBox.Size = new System.Drawing.Size(166, 22);
            this.FiltracheckBox.TabIndex = 4;
            this.FiltracheckBox.Text = "Filtrar Por Fechas";
            this.FiltracheckBox.UseVisualStyleBackColor = true;
            this.FiltracheckBox.CheckedChanged += new System.EventHandler(this.FiltracheckBox_CheckedChanged_1);
            // 
            // HastadateTimePicker1
            // 
            this.HastadateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.HastadateTimePicker1.Location = new System.Drawing.Point(468, 78);
            this.HastadateTimePicker1.Name = "HastadateTimePicker1";
            this.HastadateTimePicker1.Size = new System.Drawing.Size(122, 22);
            this.HastadateTimePicker1.TabIndex = 6;
            this.HastadateTimePicker1.ValueChanged += new System.EventHandler(this.HastadateTimePicker1_ValueChanged);
            // 
            // DesdedateTimePicker
            // 
            this.DesdedateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DesdedateTimePicker.Location = new System.Drawing.Point(282, 78);
            this.DesdedateTimePicker.Name = "DesdedateTimePicker";
            this.DesdedateTimePicker.Size = new System.Drawing.Size(112, 22);
            this.DesdedateTimePicker.TabIndex = 5;
            this.DesdedateTimePicker.ValueChanged += new System.EventHandler(this.DesdedateTimePicker_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(405, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 18);
            this.label5.TabIndex = 20;
            this.label5.Text = "Hasta";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(215, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 18);
            this.label6.TabIndex = 3;
            this.label6.Text = "Desde";
            // 
            // TotalTextBox
            // 
            this.TotalTextBox.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.TotalTextBox.Enabled = false;
            this.TotalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalTextBox.Location = new System.Drawing.Point(77, 613);
            this.TotalTextBox.Name = "TotalTextBox";
            this.TotalTextBox.Size = new System.Drawing.Size(100, 28);
            this.TotalTextBox.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 615);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 24);
            this.label3.TabIndex = 23;
            this.label3.Text = "Total";
            // 
            // ConsultaDeFactorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 645);
            this.Controls.Add(this.TotalTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FiltracheckBox);
            this.Controls.Add(this.HastadateTimePicker1);
            this.Controls.Add(this.DesdedateTimePicker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ImprimirButton);
            this.Controls.Add(this.BuscarButton);
            this.Controls.Add(this.CriteriotextBox);
            this.Controls.Add(this.FactoriasdataGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FiltrocomboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConsultaDeFactorias";
            this.Text = "Consulta De Factorias | AgroSoft";
            ((System.ComponentModel.ISupportInitialize)(this.FactoriasdataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox FiltrocomboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView FactoriasdataGridView;
        private System.Windows.Forms.TextBox CriteriotextBox;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button ImprimirButton;
        private System.Windows.Forms.CheckBox FiltracheckBox;
        private System.Windows.Forms.DateTimePicker HastadateTimePicker1;
        private System.Windows.Forms.DateTimePicker DesdedateTimePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TotalTextBox;
        private System.Windows.Forms.Label label3;
    }
}