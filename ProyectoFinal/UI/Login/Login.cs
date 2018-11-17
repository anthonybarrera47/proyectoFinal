using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.UI.Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            var username = UserTextBox.Text;
            var password = PassWordTextBox.Text;
            
            using (ModeloDeUsuarioContainer db = new ModeloDeUsuarioContainer())
            {
                var usuario = db.Usuarios.FirstOrDefault(u => u.UserName == username);
                if(usuario!=null)
                {
                    if (usuario.Password == password)
                    {
                        MessageBox.Show("Login Exitoso!!", "Logueo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        Thread hilo = new Thread(AbrirMainForms);
                        hilo.Start();
                       
                    }
                    else
                        MessageBox.Show("Login Erroneo!!", "Logueo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Login Erroneo el usuario "+username+" No existe ", "Logueo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AbrirMainForms()
        {
            Application.Run(new VentanaPrincipal());
        }
    }
}
