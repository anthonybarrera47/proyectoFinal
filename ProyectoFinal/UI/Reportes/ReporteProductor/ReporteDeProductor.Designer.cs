namespace ProyectoFinal.UI.Reportes
{
    partial class ReporteDeProductor
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
            this.ProductorescrystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ProductorescrystalReportViewer1
            // 
            this.ProductorescrystalReportViewer1.ActiveViewIndex = -1;
            this.ProductorescrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProductorescrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.ProductorescrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductorescrystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.ProductorescrystalReportViewer1.Name = "ProductorescrystalReportViewer1";
            this.ProductorescrystalReportViewer1.Size = new System.Drawing.Size(800, 450);
            this.ProductorescrystalReportViewer1.TabIndex = 0;
            this.ProductorescrystalReportViewer1.Load += new System.EventHandler(this.ProductorescrystalReportViewer1_Load);
            // 
            // ReporteDeProductor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ProductorescrystalReportViewer1);
            this.Name = "ReporteDeProductor";
            this.Text = "Reporte De Productor | AgroSoft";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer ProductorescrystalReportViewer1;
    }
}