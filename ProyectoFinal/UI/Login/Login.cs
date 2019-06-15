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
using System.Security.Cryptography;
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
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            if (!Validar())
                return;
            Expression<Func<Usuarios, bool>> filtro = x => true;
            List<Usuarios> usuario = new List<Usuarios>();
            var username = UserTextBox.Text;
            var password = PassWordTextBox.Text;
            filtro = x => x.UserName.Equals(username);
            usuario = repositorio.GetList(filtro);
            Usuarios tiposUsuario = new Usuarios();
            if(usuario.Count > 0)
            {
                if (usuario.Exists(x => x.UserName.Equals(username)))
                {
                    if (usuario.Exists(x => x.Password.Equals(password)))
                    {
                        foreach (var item in repositorio.GetList(x => x.UserName.Equals(username)))
                        {
                            PesadasBLL.UsuarioParaLogin(item.Nombre, item.UsuarioID);
                            tiposUsuario = repositorio.Buscar(item.UsuarioID);
                        }
                        if (tiposUsuario.TipoUsuario.Equals(Constantes.admi))
                            tipoUsuario = Constantes.admi;
                        else if (tiposUsuario.TipoUsuario.Equals(Constantes.user))
                            tipoUsuario = Constantes.user;
                        this.Close();
                        Thread hilo = new Thread(AbrirMainForms);
                        hilo.Start();
                    }
                    else
                        MessageBox.Show("Contraseña Incorrecto!!", "AgroSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Usuarios " + username + " Por Favor Consulte un Administrador", "AgroSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                repositorio.Guardar(new Usuarios()
                {
                    Nombre = "Admin",
                    UserName = "root",
                    Password = "root1234",
                    TipoUsuario = "A",
                    FechaRegistro = DateTime.Now
                });;
                MessageBox.Show("Al parecer es tu primera vez ejecutando el programa," +
                    "El Username es *root* y el Password *root1234*","AgroSoft",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
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
            if(PassWordTextBox.TextLength<8)
            {
                errorProvider.SetError(PassWordTextBox, "Las contraseñas son mayor o igual a 8 caracteres");
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
        public static string SHA1(string password)
        {
            using (SHA1Managed SHa1 = new SHA1Managed())
            {
                var hash = SHa1.ComputeHash(Encoding.UTF8.GetBytes(password));
                var sb = new StringBuilder(hash.Length * 2);

                foreach(byte item in hash)
                {
                    sb.Append(item.ToString("X2"));
                }
                return sb.ToString();
            }
        }

        private void PassWordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
                LoginButton_Click(sender, e);
        }
    }
}
