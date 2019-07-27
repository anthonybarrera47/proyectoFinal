using ProyectoFinal.BLL;
using ProyectoFinal.DAL;
using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace ProyectoFinal.UI.Login
{
    public partial class RegistroUsuario : Form
    {
        public RegistroUsuario()
        {
            InitializeComponent();
            AdministradorRadioButton.Checked = true;
            Limpiar();
        }
       
        private void Limpiar()
        {
            errorProvider.Clear();
            UsuarioTextBox.Text = 0.ToString();
            NombreTextBox.Text = string.Empty;
            NombreUserTextBox.Text = string.Empty;
            PasswordTextBox.Text = string.Empty;
            ConfirmarPasswordTextBox.Text = string.Empty;  
        }
        public String Checke()
        {
            string tipos =string.Empty;
            if (AdministradorRadioButton.Checked == true)
                tipos= Constantes.admi;
            else if (UsuarioradioButton2.Checked == true)
                tipos = Constantes.user;
            return tipos;
        }
        private Usuarios LlenaClase()
        {
            Usuarios usuario = new Usuarios();
            usuario.UsuarioID = Convert.ToInt32(UsuarioTextBox.Text);
            usuario.UserName = NombreUserTextBox.Text;
            usuario.Nombre = NombreTextBox.Text;
            usuario.Password = Constantes.SHA1(PasswordTextBox.Text);
            usuario.TipoUsuario = Checke();
            usuario.FechaRegistro = FechaRegistrodateTimePicker.Value;
            return usuario;
        }
        private void LlenaCampo(Usuarios usuario)
        {
            NombreTextBox.Text = usuario.Nombre;
            NombreUserTextBox.Text = usuario.UserName;
            PasswordTextBox.Text = usuario.Password;
            ConfirmarPasswordTextBox.Text = usuario.Password;
            FechaRegistrodateTimePicker.Value = usuario.FechaRegistro;
        }
        private bool Validar()
        {
            bool paso = true;
            if(String.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                errorProvider.SetError(NombreTextBox, "Campo Vacio!!");
                paso = false;
            }
            if(String.IsNullOrWhiteSpace(NombreUserTextBox.Text) || NombreUserTextBox.Text.Contains(" "))
            {
                errorProvider.SetError(NombreUserTextBox, "Este Campo Esta Vacio o Contiene Espacios En Blancos");
                paso = false;
            }
            if(String.IsNullOrWhiteSpace(PasswordTextBox.Text)|| PasswordTextBox.Text.Contains(" "))
            {
                errorProvider.SetError(PasswordTextBox, "Este Campo Esta Vacio o Contiene Espacios En Blancos");
                paso = false;
            }
            if(PasswordTextBox.TextLength<8)
            {
                errorProvider.SetError(ConfirmarPasswordTextBox, "La Contraseña debe tener mas de 8 caracteres");
                paso = false;
            }
            if(!Constantes.SHA1(PasswordTextBox.Text).Equals(Constantes.SHA1(ConfirmarPasswordTextBox.Text)))
            {
                errorProvider.SetError(ConfirmarPasswordTextBox, "Las Contraseñas Deben ser Iguales");
                paso = false;
            }
            return paso;
        }
        public bool ValidarUsuario()
        {
            bool paso = true;
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            List<Usuarios> usuario = new List<Usuarios>();
            Expression<Func<Usuarios, bool>> filtro = x => true;
            var username = NombreUserTextBox.Text;
            filtro = x => x.UserName.Equals(username);
            usuario = repositorio.GetList(filtro);
            if (usuario.Exists(x => username.Equals(username)))
            {
                errorProvider.SetError(NombreUserTextBox, "Nombre De Usuarios Existente!!");
                paso = false;
            }
            return paso;
        }
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            int.TryParse(UsuarioTextBox.Text, out int ID); 
            Usuarios usuario = repositorio.Buscar(Convert.ToInt32(ID));
            return (usuario != null);
        }
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuario;
            bool paso = false;
            usuario = LlenaClase();
            if (Convert.ToInt32(UsuarioTextBox.Text) == 0)
            {
                if (!ValidarUsuario())
                    return;
                paso = repositorio.Guardar(usuario);
            }   
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No Puedes Modificar un Usuario Inexistente, Verifique Los Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();
                Usuarios OldUser = db.Buscar(usuario.UsuarioID);
                if(OldUser.UserName.Equals(usuario.UserName))
                    paso = repositorio.Modificar(usuario);
                else
                {
                    if (!ValidarUsuario())
                        return;
                    paso = repositorio.Modificar(usuario);
                }
                if (paso)
                {
                    MessageBox.Show("Usuario Modificado Exitosamente!!", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    return;
                }
            }
            if (paso)
            {
                MessageBox.Show("Usuarios Guardado Exitosamente!!", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
                MessageBox.Show("No Se Pudo Guardar!!", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //Este Es el Metodo Buscar utilizado manejando un evento de cambio de Index En el ComboBox De los PesadaDetalleID
        private void NombreTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Constantes.ValidarNombreTextBox(sender, e);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            errorProvider.Clear();
            int.TryParse(UsuarioTextBox.Text, out int ID);
            if (!ExisteEnLaBaseDeDatos())
            {
                errorProvider.SetError(UsuarioTextBox, "No Puede Borrar Un Usuario Inexistente");
                return;
            }
            if (repositorio.Eliminar(ID))
            {
                Limpiar();
                MessageBox.Show("Usuario Eliminada Exitosamente!!", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BuscarUsuarios_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            errorProvider.Clear();
            int.TryParse(UsuarioTextBox.Text, out int ID);
            Usuarios usuario = repositorio.Buscar(ID);
            if (usuario != null)
            {
                errorProvider.Clear();
                LlenaCampo(usuario);
            }
            else
                MessageBox.Show("Usuario no Encontrado!!", "AgroSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void UsuarioTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
                BuscarUsuarios_Click(sender, e);
            Constantes.ValidarSoloNumeros(sender, e);
        }

        private void NombreUserTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Constantes.ValidarNoEspaciosEnBlancos(sender, e);
        }
    }
}
