using ProyectoFinal.BLL;
using ProyectoFinal.DAL;
using ProyectoFinal.UI.Consulta;
using ProyectoFinal.UI.Login;
using ProyectoFinal.UI.Registro;
using System;
using System.Threading;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class VentanaPrincipal : Form
    {
        public string tipousuario = Login.tipoUsuario;

        public void Comprobar()
        {
            UsuariosToolStripMenuItem.Visible = tipousuario.Equals(Constantes.admi);
            NombretoolStripStatusLabel.Text =PesadasBLL.GetUsuario().Nombre;
        }
        public VentanaPrincipal()
        {
            InitializeComponent();
            //Comprobar();
        }
        private void CrearFactoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroFactoria registroFactoria = new RegistroFactoria
            {
                MdiParent = this
            };
            registroFactoria.Show();
        }
        private void VentanaPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void CrearTiposDeArrozToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroTiposArroz registroTiposArroz = new RegistroTiposArroz
            {
                MdiParent = this
            };
            registroTiposArroz.Show();
        }
        private void CrearClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroProductores registroProductores = new RegistroProductores
            {
                MdiParent = this
            };
            registroProductores.Show();
        }
        private void ConsultarProductoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaProductores consultaProductores = new ConsultaProductores
            {
                MdiParent = this
            };
            consultaProductores.Show();
        }
        private void RegistroDePesadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroDePesadas registroDePesadas = new RegistroDePesadas
            {
                MdiParent = this
            };
            registroDePesadas.Show();
        }
        private void CrearUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroUsuario registroUsuario = new RegistroUsuario
            {
                MdiParent = this
            };
            registroUsuario.Show();
        }
        private void ConsultaUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaDeUsuarios consulta = new ConsultaDeUsuarios
            {
                MdiParent = this
            };
            consulta.Show();
        }

        private void DesconectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread hilo = new Thread(AbrirLogin);
            hilo.Start();
        }
        public void AbrirLogin()
        {
            Application.Run(new Login());
        }

        private void ConsultaFactoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaDeFactorias consulta = new ConsultaDeFactorias()
            {
                MdiParent = this
            };
            consulta.Show();
        }

        private void ConsultaTipoArrozToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaTipoArroz consulta = new ConsultaTipoArroz()
            {
                MdiParent = this
            };
            consulta.Show();
        }

        private void informacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Este Es un proyecto creado por Anthony Manuel Barrera Hildago " +
                "Estudiante de la carrera de Ingenieria En Sistema en la" +
                " Universidad Catolica Nordestana", "INFORMACION DEL CREADOR", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}