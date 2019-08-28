namespace ProyectoFinal.UI.Reportes.ReporteDeUsuarios
{
    partial class ReporteDeUsuario
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
            this.UsuariocrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // UsuariocrystalReportViewer
            // 
            this.UsuariocrystalReportViewer.ActiveViewIndex = -1;
            this.UsuariocrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UsuariocrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.UsuariocrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsuariocrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.UsuariocrystalReportViewer.Name = "UsuariocrystalReportViewer";
            this.UsuariocrystalReportViewer.Size = new System.Drawing.Size(800, 450);
            this.UsuariocrystalReportViewer.TabIndex = 0;
            this.UsuariocrystalReportViewer.Load += new System.EventHandler(this.UsuariocrystalReportViewer_Load);
            // 
            // ReporteDeUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UsuariocrystalReportViewer);
            this.Name = "ReporteDeUsuario";
            this.Text = "ReporteDeUsuario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReporteDeUsuario_FormClosed);
            this.Load += new System.EventHandler(this.ReporteDeUsuario_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer UsuariocrystalReportViewer;
    }
}