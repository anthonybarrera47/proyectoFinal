namespace ProyectoFinal.UI.Reportes
{
    partial class ReportesDeFactoria
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
            this.FactoriacrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // FactoriacrystalReportViewer
            // 
            this.FactoriacrystalReportViewer.ActiveViewIndex = -1;
            this.FactoriacrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FactoriacrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.FactoriacrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FactoriacrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.FactoriacrystalReportViewer.Name = "FactoriacrystalReportViewer";
            this.FactoriacrystalReportViewer.Size = new System.Drawing.Size(800, 450);
            this.FactoriacrystalReportViewer.TabIndex = 0;
            this.FactoriacrystalReportViewer.Load += new System.EventHandler(this.FactoriacrystalReportViewer_Load);
            // 
            // ReportesDeFactoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FactoriacrystalReportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ReportesDeFactoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportesDeFactoria";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReportesDeFactoria_FormClosed);
            this.Load += new System.EventHandler(this.ReportesDeFactoria_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer FactoriacrystalReportViewer;
    }
}