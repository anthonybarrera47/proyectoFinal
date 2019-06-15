namespace ProyectoFinal.UI.Reportes
{
    partial class ReporteDePesadas
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
            this.PesadascrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // PesadascrystalReportViewer
            // 
            this.PesadascrystalReportViewer.ActiveViewIndex = -1;
            this.PesadascrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PesadascrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.PesadascrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PesadascrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.PesadascrystalReportViewer.Name = "PesadascrystalReportViewer";
            this.PesadascrystalReportViewer.Size = new System.Drawing.Size(800, 450);
            this.PesadascrystalReportViewer.TabIndex = 0;
            this.PesadascrystalReportViewer.Load += new System.EventHandler(this.PesadascrystalReportViewer_Load);
            // 
            // ReporteDePesadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PesadascrystalReportViewer);
            this.Name = "ReporteDePesadas";
            this.Text = "Reporte De Pesadas | AgroSoft";
            this.Load += new System.EventHandler(this.ReporteDePesadas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer PesadascrystalReportViewer;
    }
}