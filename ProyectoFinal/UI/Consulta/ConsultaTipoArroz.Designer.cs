namespace ProyectoFinal.UI.Consulta
{
    partial class ConsultaTipoArroz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultaTipoArroz));
            this.FiltrocomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DesdedateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.TipodataGridView = new System.Windows.Forms.DataGridView();
            this.CriteriotextBox = new System.Windows.Forms.TextBox();
            this.HastadateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ImprimirButton = new System.Windows.Forms.Button();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.FiltracheckBox = new System.Windows.Forms.CheckBox();
            this.TotalTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TotalKGTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TipodataGridView)).BeginInit();
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
            "Descripcion",
            "Quintales"});
            this.FiltrocomboBox.Location = new System.Drawing.Point(21, 41);
            this.FiltrocomboBox.Name = "FiltrocomboBox";
            this.FiltrocomboBox.Size = new System.Drawing.Size(121, 24);
            this.FiltrocomboBox.TabIndex = 0;
            this.FiltrocomboBox.SelectedIndexChanged += new System.EventHandler(this.FiltrocomboBox_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filtro";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(157, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Criterio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(220, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Desde";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(410, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Hasta";
            // 
            // DesdedateTimePicker
            // 
            this.DesdedateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DesdedateTimePicker.Location = new System.Drawing.Point(287, 73);
            this.DesdedateTimePicker.Name = "DesdedateTimePicker";
            this.DesdedateTimePicker.Size = new System.Drawing.Size(112, 22);
            this.DesdedateTimePicker.TabIndex = 5;
            // 
            // TipodataGridView
            // 
            this.TipodataGridView.AllowUserToAddRows = false;
            this.TipodataGridView.AllowUserToDeleteRows = false;
            this.TipodataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TipodataGridView.Location = new System.Drawing.Point(21, 102);
            this.TipodataGridView.Name = "TipodataGridView";
            this.TipodataGridView.ReadOnly = true;
            this.TipodataGridView.RowHeadersWidth = 51;
            this.TipodataGridView.RowTemplate.Height = 24;
            this.TipodataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TipodataGridView.Size = new System.Drawing.Size(847, 503);
            this.TipodataGridView.TabIndex = 8;
            // 
            // CriteriotextBox
            // 
            this.CriteriotextBox.Location = new System.Drawing.Point(160, 41);
            this.CriteriotextBox.Name = "CriteriotextBox";
            this.CriteriotextBox.Size = new System.Drawing.Size(377, 22);
            this.CriteriotextBox.TabIndex = 9;
            this.CriteriotextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CriteriotextBox_KeyPress_1);
            // 
            // HastadateTimePicker
            // 
            this.HastadateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.HastadateTimePicker.Location = new System.Drawing.Point(473, 73);
            this.HastadateTimePicker.Name = "HastadateTimePicker";
            this.HastadateTimePicker.Size = new System.Drawing.Size(122, 22);
            this.HastadateTimePicker.TabIndex = 11;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ImprimirButton
            // 
            this.ImprimirButton.Image = global::ProyectoFinal.Properties.Resources.iconfinder_006_printer_3925426;
            this.ImprimirButton.Location = new System.Drawing.Point(760, 8);
            this.ImprimirButton.Name = "ImprimirButton";
            this.ImprimirButton.Size = new System.Drawing.Size(103, 88);
            this.ImprimirButton.TabIndex = 12;
            this.ImprimirButton.UseVisualStyleBackColor = true;
            this.ImprimirButton.Click += new System.EventHandler(this.ImprimirButton_Click_1);
            // 
            // BuscarButton
            // 
            this.BuscarButton.Image = global::ProyectoFinal.Properties.Resources.if_search_1730951;
            this.BuscarButton.Location = new System.Drawing.Point(543, 20);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(52, 45);
            this.BuscarButton.TabIndex = 10;
            this.BuscarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // FiltracheckBox
            // 
            this.FiltracheckBox.AutoSize = true;
            this.FiltracheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FiltracheckBox.Location = new System.Drawing.Point(21, 74);
            this.FiltracheckBox.Name = "FiltracheckBox";
            this.FiltracheckBox.Size = new System.Drawing.Size(166, 22);
            this.FiltracheckBox.TabIndex = 13;
            this.FiltracheckBox.Text = "Filtrar Por Fechas";
            this.FiltracheckBox.UseVisualStyleBackColor = true;
            this.FiltracheckBox.CheckedChanged += new System.EventHandler(this.FiltracheckBox_CheckedChanged);
            // 
            // TotalTextBox
            // 
            this.TotalTextBox.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.TotalTextBox.Enabled = false;
            this.TotalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalTextBox.Location = new System.Drawing.Point(83, 611);
            this.TotalTextBox.Name = "TotalTextBox";
            this.TotalTextBox.Size = new System.Drawing.Size(100, 28);
            this.TotalTextBox.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 613);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 24);
            this.label5.TabIndex = 21;
            this.label5.Text = "Total";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(620, 612);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 24);
            this.label6.TabIndex = 21;
            this.label6.Text = "Total de Kilos";
            // 
            // TotalKGTextBox
            // 
            this.TotalKGTextBox.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.TotalKGTextBox.Enabled = false;
            this.TotalKGTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalKGTextBox.Location = new System.Drawing.Point(763, 609);
            this.TotalKGTextBox.Name = "TotalKGTextBox";
            this.TotalKGTextBox.Size = new System.Drawing.Size(100, 28);
            this.TotalKGTextBox.TabIndex = 22;
            // 
            // ConsultaTipoArroz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 643);
            this.Controls.Add(this.TotalKGTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TotalTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FiltracheckBox);
            this.Controls.Add(this.ImprimirButton);
            this.Controls.Add(this.HastadateTimePicker);
            this.Controls.Add(this.BuscarButton);
            this.Controls.Add(this.CriteriotextBox);
            this.Controls.Add(this.TipodataGridView);
            this.Controls.Add(this.DesdedateTimePicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FiltrocomboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConsultaTipoArroz";
            this.Text = "Consulta De Tipos De Arroz | AgroSoft";
            ((System.ComponentModel.ISupportInitialize)(this.TipodataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox FiltrocomboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DesdedateTimePicker;
        private System.Windows.Forms.DataGridView TipodataGridView;
        private System.Windows.Forms.TextBox CriteriotextBox;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.DateTimePicker HastadateTimePicker;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button ImprimirButton;
        private System.Windows.Forms.CheckBox FiltracheckBox;
        private System.Windows.Forms.TextBox TotalTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TotalKGTextBox;
        private System.Windows.Forms.Label label6;
    }
}