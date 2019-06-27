namespace ProyectoFinal.UI.Reportes
{
    partial class ReportesDeTipoArroz
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
            this.TipoArrozcrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // TipoArrozcrystalReportViewer
            // 
            this.TipoArrozcrystalReportViewer.ActiveViewIndex = -1;
            this.TipoArrozcrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TipoArrozcrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.TipoArrozcrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TipoArrozcrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.TipoArrozcrystalReportViewer.Name = "TipoArrozcrystalReportViewer";
            this.TipoArrozcrystalReportViewer.Size = new System.Drawing.Size(800, 450);
            this.TipoArrozcrystalReportViewer.TabIndex = 0;
            this.TipoArrozcrystalReportViewer.Load += new System.EventHandler(this.TipoArrozcrystalReportViewer_Load);
            // 
            // ReportesDeTipoArroz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TipoArrozcrystalReportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ReportesDeTipoArroz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportesDeTipoArroz";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReportesDeTipoArroz_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer TipoArrozcrystalReportViewer;
    }
}