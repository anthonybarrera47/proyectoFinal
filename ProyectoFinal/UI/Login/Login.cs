using ProyectoFinal.BLL;
using ProyectoFinal.DAL;
using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.UI.Login
{
    public partial class Login : Form
    {
        public static string tipoUsuario;
        public Login()
        {
            InitializeComponent();
            Limpiar();
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
           
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            if (!Validar())
                return;
            Expression<Func<Usuario, bool>> filtro = x => true;
            List<Usuario> usuario = new List<Usuario>();
            var username = UserTextBox.Text;
            var password = PassWordTextBox.Text;
            filtro = x => x.UserName.Equals(username);
            usuario = repositorio.GetList(filtro);
            Usuario tiposUsuario = new Usuario();
            if (usuario.Exists(x => x.UserName.Equals(username)))
            {
                if (usuario.Exists(x => x.Password.Equals(password)))
                {
                    foreach (var item in repositorio.GetList(x => x.UserName.Equals(username)))
                    {
                        PesadasBLL.UsuarioParaLogin(item.Nombre, item.UsuarioId);
                        tiposUsuario = repositorio.Buscar(item.UsuarioId);
                    }
                    if (tiposUsuario.Tipo.Equals(Constantes.admi))
                        tipoUsuario = Constantes.admi;
                    else if (tiposUsuario.Tipo.Equals(Constantes.user))
                        tipoUsuario = Constantes.user;
                    this.Close();
                    Thread hilo = new Thread(AbrirMainForms);
                    hilo.Start();
                }
                else
                    MessageBox.Show("Contraseña Incorrecto!!", "AgroSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Usuario " + username + " Por Favor Consulte un Administrador", "AgroSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);

            /*
             var username = UserTextBox.Text;
             var password = PassWordTextBox.Text;

             using (Contexto db = new Contexto())
             {
                 var usuario = db.usuario.FirstOrDefault(u => u.UserName == username);
                 if (usuario != null)
                 {
                     if (usuario.Password == password)
                     {
                         MessageBox.Show("Login Exitoso!!", "Logueo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                         PesadasBLL.UsuarioParaLogin(usuario.Nombre, usuario.UsuarioId);
                         this.Close();
                         Thread hilo = new Thread(AbrirMainForms);
                         hilo.Start();

                     }
                     else
                         MessageBox.Show("Login Erroneo!!", "Logueo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
                 else
                     MessageBox.Show("Login Erroneo el usuario " + username + " No existe ", "Logueo", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }*/
        }
        private void AbrirMainForms()
        {
            Application.Run(new VentanaPrincipal());
        }
        private bool Validar()
        {
            bool paso = true;
            if (string.IsNullOrWhiteSpace(UserTextBox.Text))
            {
                errorProvider.SetError(UserTextBox, "Este Campo Esta vacio");
                UserTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(PassWordTextBox.Text))
            {
                errorProvider.SetError(PassWordTextBox, "Este Campo Esta vacio");
                PassWordTextBox.Focus();
                paso = false;
            }
            return paso;
        }
        private void Limpiar()
        {
            UserTextBox.Text = string.Empty;
            PassWordTextBox.Text = string.Empty;
        }


    }
}
