namespace ProyectoFinal.UI.Reportes
{
    partial class ReportePesadaDetalles
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
            this.PesadaDetallecrystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // PesadaDetallecrystalReportViewer1
            // 
            this.PesadaDetallecrystalReportViewer1.ActiveViewIndex = -1;
            this.PesadaDetallecrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PesadaDetallecrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.PesadaDetallecrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PesadaDetallecrystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.PesadaDetallecrystalReportViewer1.Name = "PesadaDetallecrystalReportViewer1";
            this.PesadaDetallecrystalReportViewer1.Size = new System.Drawing.Size(1002, 730);
            this.PesadaDetallecrystalReportViewer1.TabIndex = 0;
            this.PesadaDetallecrystalReportViewer1.Load += new System.EventHandler(this.PesadaDetallecrystalReportViewer1_Load);
            // 
            // ReportePesadaDetalles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 730);
            this.Controls.Add(this.PesadaDetallecrystalReportViewer1);
            this.Name = "ReportePesadaDetalles";
            this.Text = "ReportePesadaDetalles";
            this.Load += new System.EventHandler(this.ReportePesadaDetalles_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer PesadaDetallecrystalReportViewer1;
    }
}