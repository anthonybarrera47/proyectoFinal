namespace ProyectoFinal
{
    partial class VentanaPrincipal
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
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.registroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearFactoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuBar
            // 
            this.MenuBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registroToolStripMenuItem,
            this.consultasToolStripMenuItem,
            this.herramientasToolStripMenuItem});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(800, 28);
            this.MenuBar.TabIndex = 2;
            this.MenuBar.Text = "menuStrip1";
            // 
            // registroToolStripMenuItem
            // 
            this.registroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearClientesToolStripMenuItem,
            this.crearFactoriasToolStripMenuItem});
            this.registroToolStripMenuItem.Name = "registroToolStripMenuItem";
            this.registroToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.registroToolStripMenuItem.Text = "Registro";
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(110, 24);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // crearClientesToolStripMenuItem
            // 
            this.crearClientesToolStripMenuItem.Name = "crearClientesToolStripMenuItem";
            this.crearClientesToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.crearClientesToolStripMenuItem.Text = "Crear Clientes";
            // 
            // crearFactoriasToolStripMenuItem
            // 
            this.crearFactoriasToolStripMenuItem.Name = "crearFactoriasToolStripMenuItem";
            this.crearFactoriasToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.crearFactoriasToolStripMenuItem.Text = "Crear Factorias";
            // 
            // VentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MenuBar);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MenuBar;
            this.Name = "VentanaPrincipal";
            this.Text = "AgroComercial Barrera";
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.ToolStripMenuItem registroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearFactoriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
    }
}

