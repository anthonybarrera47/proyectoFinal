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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaPrincipal));
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.RegistroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CrearClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CrearFactoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CrearTiposDeArrozToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RegistroDePesadasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConsultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConsultarProductoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaFactoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaTipoArrozToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CrearUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConsultaUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HerramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desconectarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SalirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.NombretoolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MenuBar.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuBar
            // 
            this.MenuBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RegistroToolStripMenuItem,
            this.ConsultasToolStripMenuItem,
            this.UsuariosToolStripMenuItem,
            this.HerramientasToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            resources.ApplyResources(this.MenuBar, "MenuBar");
            this.MenuBar.Name = "MenuBar";
            // 
            // RegistroToolStripMenuItem
            // 
            this.RegistroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CrearClientesToolStripMenuItem,
            this.CrearFactoriasToolStripMenuItem,
            this.CrearTiposDeArrozToolStripMenuItem,
            this.RegistroDePesadasToolStripMenuItem});
            this.RegistroToolStripMenuItem.Name = "RegistroToolStripMenuItem";
            resources.ApplyResources(this.RegistroToolStripMenuItem, "RegistroToolStripMenuItem");
            // 
            // CrearClientesToolStripMenuItem
            // 
            this.CrearClientesToolStripMenuItem.Image = global::ProyectoFinal.Properties.Resources.iconfinder_users_61816;
            this.CrearClientesToolStripMenuItem.Name = "CrearClientesToolStripMenuItem";
            resources.ApplyResources(this.CrearClientesToolStripMenuItem, "CrearClientesToolStripMenuItem");
            this.CrearClientesToolStripMenuItem.Click += new System.EventHandler(this.CrearClientesToolStripMenuItem_Click);
            // 
            // CrearFactoriasToolStripMenuItem
            // 
            this.CrearFactoriasToolStripMenuItem.Image = global::ProyectoFinal.Properties.Resources.iconfinder_Factory_mill_2992445;
            this.CrearFactoriasToolStripMenuItem.Name = "CrearFactoriasToolStripMenuItem";
            resources.ApplyResources(this.CrearFactoriasToolStripMenuItem, "CrearFactoriasToolStripMenuItem");
            this.CrearFactoriasToolStripMenuItem.Click += new System.EventHandler(this.CrearFactoriasToolStripMenuItem_Click);
            // 
            // CrearTiposDeArrozToolStripMenuItem
            // 
            this.CrearTiposDeArrozToolStripMenuItem.Image = global::ProyectoFinal.Properties.Resources.wheat;
            this.CrearTiposDeArrozToolStripMenuItem.Name = "CrearTiposDeArrozToolStripMenuItem";
            resources.ApplyResources(this.CrearTiposDeArrozToolStripMenuItem, "CrearTiposDeArrozToolStripMenuItem");
            this.CrearTiposDeArrozToolStripMenuItem.Click += new System.EventHandler(this.CrearTiposDeArrozToolStripMenuItem_Click);
            // 
            // RegistroDePesadasToolStripMenuItem
            // 
            this.RegistroDePesadasToolStripMenuItem.Image = global::ProyectoFinal.Properties.Resources.invoice;
            this.RegistroDePesadasToolStripMenuItem.Name = "RegistroDePesadasToolStripMenuItem";
            resources.ApplyResources(this.RegistroDePesadasToolStripMenuItem, "RegistroDePesadasToolStripMenuItem");
            this.RegistroDePesadasToolStripMenuItem.Click += new System.EventHandler(this.RegistroDePesadasToolStripMenuItem_Click);
            // 
            // ConsultasToolStripMenuItem
            // 
            this.ConsultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConsultarProductoresToolStripMenuItem,
            this.consultaFactoriasToolStripMenuItem,
            this.consultaTipoArrozToolStripMenuItem});
            this.ConsultasToolStripMenuItem.Name = "ConsultasToolStripMenuItem";
            resources.ApplyResources(this.ConsultasToolStripMenuItem, "ConsultasToolStripMenuItem");
            // 
            // ConsultarProductoresToolStripMenuItem
            // 
            this.ConsultarProductoresToolStripMenuItem.Image = global::ProyectoFinal.Properties.Resources.iconfinder_users_61816;
            this.ConsultarProductoresToolStripMenuItem.Name = "ConsultarProductoresToolStripMenuItem";
            resources.ApplyResources(this.ConsultarProductoresToolStripMenuItem, "ConsultarProductoresToolStripMenuItem");
            this.ConsultarProductoresToolStripMenuItem.Click += new System.EventHandler(this.ConsultarProductoresToolStripMenuItem_Click);
            // 
            // consultaFactoriasToolStripMenuItem
            // 
            this.consultaFactoriasToolStripMenuItem.Image = global::ProyectoFinal.Properties.Resources.iconfinder_Factory_mill_2992445;
            this.consultaFactoriasToolStripMenuItem.Name = "consultaFactoriasToolStripMenuItem";
            resources.ApplyResources(this.consultaFactoriasToolStripMenuItem, "consultaFactoriasToolStripMenuItem");
            this.consultaFactoriasToolStripMenuItem.Click += new System.EventHandler(this.ConsultaFactoriasToolStripMenuItem_Click);
            // 
            // consultaTipoArrozToolStripMenuItem
            // 
            this.consultaTipoArrozToolStripMenuItem.Image = global::ProyectoFinal.Properties.Resources.wheat;
            this.consultaTipoArrozToolStripMenuItem.Name = "consultaTipoArrozToolStripMenuItem";
            resources.ApplyResources(this.consultaTipoArrozToolStripMenuItem, "consultaTipoArrozToolStripMenuItem");
            this.consultaTipoArrozToolStripMenuItem.Click += new System.EventHandler(this.ConsultaTipoArrozToolStripMenuItem_Click);
            // 
            // UsuariosToolStripMenuItem
            // 
            this.UsuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CrearUsuariosToolStripMenuItem,
            this.ConsultaUsuariosToolStripMenuItem});
            this.UsuariosToolStripMenuItem.Name = "UsuariosToolStripMenuItem";
            resources.ApplyResources(this.UsuariosToolStripMenuItem, "UsuariosToolStripMenuItem");
            // 
            // CrearUsuariosToolStripMenuItem
            // 
            this.CrearUsuariosToolStripMenuItem.Image = global::ProyectoFinal.Properties.Resources.iconfinder_user_group_285648;
            this.CrearUsuariosToolStripMenuItem.Name = "CrearUsuariosToolStripMenuItem";
            resources.ApplyResources(this.CrearUsuariosToolStripMenuItem, "CrearUsuariosToolStripMenuItem");
            this.CrearUsuariosToolStripMenuItem.Click += new System.EventHandler(this.CrearUsuariosToolStripMenuItem_Click);
            // 
            // ConsultaUsuariosToolStripMenuItem
            // 
            this.ConsultaUsuariosToolStripMenuItem.Image = global::ProyectoFinal.Properties.Resources.iconfinder_edit_find_118922;
            this.ConsultaUsuariosToolStripMenuItem.Name = "ConsultaUsuariosToolStripMenuItem";
            resources.ApplyResources(this.ConsultaUsuariosToolStripMenuItem, "ConsultaUsuariosToolStripMenuItem");
            this.ConsultaUsuariosToolStripMenuItem.Click += new System.EventHandler(this.ConsultaUsuariosToolStripMenuItem_Click);
            // 
            // HerramientasToolStripMenuItem
            // 
            this.HerramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.desconectarToolStripMenuItem,
            this.SalirToolStripMenuItem});
            this.HerramientasToolStripMenuItem.Name = "HerramientasToolStripMenuItem";
            resources.ApplyResources(this.HerramientasToolStripMenuItem, "HerramientasToolStripMenuItem");
            // 
            // desconectarToolStripMenuItem
            // 
            this.desconectarToolStripMenuItem.Image = global::ProyectoFinal.Properties.Resources.iconfinder_exit_3855614;
            this.desconectarToolStripMenuItem.Name = "desconectarToolStripMenuItem";
            resources.ApplyResources(this.desconectarToolStripMenuItem, "desconectarToolStripMenuItem");
            this.desconectarToolStripMenuItem.Click += new System.EventHandler(this.DesconectarToolStripMenuItem_Click);
            // 
            // SalirToolStripMenuItem
            // 
            this.SalirToolStripMenuItem.Image = global::ProyectoFinal.Properties.Resources.iconfinder_Cancel_1493282;
            this.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem";
            resources.ApplyResources(this.SalirToolStripMenuItem, "SalirToolStripMenuItem");
            this.SalirToolStripMenuItem.Click += new System.EventHandler(this.SalirToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informacionToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            resources.ApplyResources(this.ayudaToolStripMenuItem, "ayudaToolStripMenuItem");
            // 
            // informacionToolStripMenuItem
            // 
            this.informacionToolStripMenuItem.Image = global::ProyectoFinal.Properties.Resources.iconfinder_icon_29_information_315150;
            this.informacionToolStripMenuItem.Name = "informacionToolStripMenuItem";
            resources.ApplyResources(this.informacionToolStripMenuItem, "informacionToolStripMenuItem");
            this.informacionToolStripMenuItem.Click += new System.EventHandler(this.InformacionToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.NombretoolStripStatusLabel});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.Image = global::ProyectoFinal.Properties.Resources.iconfinder_users_61816;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            // 
            // NombretoolStripStatusLabel
            // 
            this.NombretoolStripStatusLabel.Name = "NombretoolStripStatusLabel";
            resources.ApplyResources(this.NombretoolStripStatusLabel, "NombretoolStripStatusLabel");
            // 
            // VentanaPrincipal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::ProyectoFinal.Properties.Resources.logo1;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MenuBar);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MenuBar;
            this.Name = "VentanaPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VentanaPrincipal_FormClosed);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.ToolStripMenuItem RegistroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CrearClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CrearFactoriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConsultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HerramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SalirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CrearTiposDeArrozToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConsultarProductoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RegistroDePesadasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CrearUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConsultaUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desconectarToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel NombretoolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem consultaFactoriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaTipoArrozToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informacionToolStripMenuItem;
    }
}

