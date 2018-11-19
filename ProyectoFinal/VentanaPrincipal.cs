using ProyectoFinal.UI.Consulta;
using ProyectoFinal.UI.Login;
using ProyectoFinal.UI.Registro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class VentanaPrincipal : Form
    {
        public VentanaPrincipal()
        {
            InitializeComponent();
        }

        private void crearFactoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroFactoria registroFactoria = new RegistroFactoria();
            registroFactoria.MdiParent = this;
            registroFactoria.Show();
        }

        private void VentanaPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void crearTiposDeArrozToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroTiposArroz registroTiposArroz = new RegistroTiposArroz();
            registroTiposArroz.MdiParent = this;
            registroTiposArroz.Show();
        }

        private void crearClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroProductores registroProductores = new RegistroProductores();
            registroProductores.MdiParent = this;
            registroProductores.Show();
        }

        private void consultarProductoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaProductores consultaProductores = new ConsultaProductores();
            consultaProductores.MdiParent = this;
            consultaProductores.Show();
        }

        private void registroDePesadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroDePesadas registroDePesadas = new RegistroDePesadas();
            registroDePesadas.MdiParent = this;
            registroDePesadas.Show();
        }
    }
}
