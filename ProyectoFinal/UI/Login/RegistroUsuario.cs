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
            LlenarComboBox();
            AdministradorRadioButton.Checked = true;
        }
        private void LlenarComboBox()
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            UsuarioIdcomboBox.Items.Clear();
            foreach(var item in repositorio.GetList(x=>true))
            {
                UsuarioIdcomboBox.Items.Add(item.UsuarioID);
            }
        }
        private void Limpiar()
        {
            UsuarioIdcomboBox.Items.Clear();
            UsuarioIdcomboBox.Text = string.Empty;
            NombreTextBox.Text = string.Empty;
            NombreUserTextBox.Text = string.Empty;
            PasswordTextBox.Text = string.Empty;
            ConfirmarPasswordTextBox.Text = string.Empty;
            LlenarComboBox();
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
            if (UsuarioIdcomboBox.Text.Equals(string.Empty))
                usuario.UsuarioID = 0;
            else
                usuario.UsuarioID = Convert.ToInt32(UsuarioIdcomboBox.Text);
            usuario.UserName = NombreUserTextBox.Text;
            usuario.Nombre = NombreTextBox.Text;
            usuario.Password = Constantes.SHA1(PasswordTextBox.Text);
            usuario.TipoUsuario = Checke();
            usuario.FechaRegistro = FechaRegistrodateTimePicker.Value;
            return usuario;
        }
        private bool Validar()
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            List<Usuarios> usuario = new List<Usuarios>();
            Expression<Func<Usuarios, bool>> filtro = x => true;
            var username = NombreUserTextBox.Text;
            filtro = x => x.UserName.Equals(username);
            usuario = repositorio.GetList(filtro);

            bool paso = true;
            if (usuario.Exists(x=>username.Equals(username)))
            {
                errorProvider.SetError(NombreUserTextBox,"Nombre De Usuarios Existente!!");
                paso = false;
            }
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
            if(!PasswordTextBox.Text.Equals(ConfirmarPasswordTextBox.Text))
            {
                errorProvider.SetError(ConfirmarPasswordTextBox, "Las Contraseñas Deben ser Iguales");
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
            Usuarios usuario = repositorio.Buscar(Convert.ToInt32(UsuarioIdcomboBox.Text));
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
            if (UsuarioIdcomboBox.Text == string.Empty)
                paso = repositorio.Guardar(usuario);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No Puedes Modificar un Usuarios Inexistente, Verifique Los Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = repositorio.Modificar(usuario);
                if (paso)
                {
                    MessageBox.Show("Productor Modificado Exitosamente!!", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    return;
                }
            }
            if (paso)
            {
                MessageBox.Show("Usuarios Guardado Exitosamente!!", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UsuarioIdcomboBox.DataSource = null;
                LlenarComboBox();
                Limpiar();
            }
            else
                MessageBox.Show("No Se Pudo Guardar!!", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //Este Es el Metodo Buscar utilizado manejando un evento de cambio de Index En el ComboBox De los PesadaDetalleID
        private void UsuarioIdcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuario = repositorio.Buscar(Convert.ToInt32(UsuarioIdcomboBox.Text));
            NombreTextBox.Text = usuario.Nombre;
            NombreUserTextBox.Text = usuario.UserName;
            PasswordTextBox.Text = usuario.Password;
            ConfirmarPasswordTextBox.Text = usuario.Password;
            FechaRegistrodateTimePicker.Value = usuario.FechaRegistro;
        }

        private void NombreTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Constantes.ValidarNombreTextBox(sender, e);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            errorProvider.Clear();
            int.TryParse(UsuarioIdcomboBox.Text, out int ID);
            if (!ExisteEnLaBaseDeDatos())
            {
                errorProvider.SetError(UsuarioIdcomboBox, "No Puede Borrar Una Factoria Inexistente");
                return;
            }
            if (repositorio.Eliminar(ID))
            {
                Limpiar();
                MessageBox.Show("Factoria Eliminada Exitosamente!!", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
