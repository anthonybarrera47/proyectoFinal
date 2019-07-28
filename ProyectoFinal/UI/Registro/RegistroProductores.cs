using ProyectoFinal.BLL;
using ProyectoFinal.DAL;
using ProyectoFinal.Entidades;
using ProyectoFinal.UI.Consulta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.UI.Registro
{
    public partial class RegistroProductores : Form, IRetorno<Productores>
    {
        public RegistroProductores()
        {
            InitializeComponent();
            Limpiar();
        }
        private void Limpiar()
        {
            errorProvider.Clear();
            ProductorIDTextBox.Text = 0.ToString();
            NombreTextBox.Text = string.Empty;
            TelefonomaskedTextBox.Text = string.Empty;
            CedulaMasketTextBox.Text = string.Empty;
            FechaNacimientodateTimePicker.Value = DateTime.Now;
        }
        private Productores LlenaClase()
        {
            Productores productores = new Productores
            {
                ProductorID = Convert.ToInt32(ProductorIDTextBox.Text),
                Nombre = NombreTextBox.Text,
                Telefono = TelefonomaskedTextBox.Text,
                Cedula = CedulaMasketTextBox.Text,
                FechaNacimiento = FechaNacimientodateTimePicker.Value,
                FechaRegistro = DateTime.Now
            };
            return productores;
        }
        private void LlenaCampo(Productores productores)
        {
            ProductorIDTextBox.Text = productores.ProductorID.ToString();
            NombreTextBox.Text = productores.Nombre;
            TelefonomaskedTextBox.Text = productores.Telefono;
            CedulaMasketTextBox.Text = productores.Cedula;
            FechaNacimientodateTimePicker.Value = productores.FechaNacimiento;
        }
        private bool Validar()
        {
            bool paso = true;
            errorProvider.Clear();
            //Regex nombre = new Regex(@"[a-zA-ZñÑ\s]{2,50}");  
            if (String.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                errorProvider.SetError(NombreTextBox, "Este Campo No puede Estar Vacio , Ni Debe Contener caracteres!!");
                paso = false;
            }
            if (String.IsNullOrWhiteSpace(TelefonomaskedTextBox.Text.Replace("-", "")) || TelefonomaskedTextBox.TextLength != 12)
            {
                errorProvider.SetError(TelefonomaskedTextBox, "Este Campo No puede Estar Vacio!!");
                paso = false;
            }
            if (String.IsNullOrWhiteSpace(CedulaMasketTextBox.Text.Replace("-", "")) || CedulaMasketTextBox.TextLength != 13)
            {
                errorProvider.SetError(CedulaMasketTextBox, "Este Campo No puede Estar Vacio!!");
                paso = false;
            }
            if (Constantes.ValidarEspaciosEnBlancos(TelefonomaskedTextBox.Text) == false)
            {
                errorProvider.SetError(TelefonomaskedTextBox, "Este Campo No puede Tener Espacios En Blancos!!");
                paso = false;
            }
            if (Constantes.ValidarEspaciosEnBlancos(CedulaMasketTextBox.Text) == false)
            {
                errorProvider.SetError(CedulaMasketTextBox, "Este Campo No puede Tener Espacios En Blancos!!");
                paso = false;
            }
            return paso;
        }
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;
            Productores productores = LlenaClase();
            bool paso = false;
            if (Convert.ToInt32(ProductorIDTextBox.Text) == 0)
                paso = ProductoresBLL.Guardar(productores);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No puede Modificar un productor Inexistente!", "AgroSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                paso = ProductoresBLL.Modificar(productores);
                if (paso)
                {
                    MessageBox.Show("Productor Modificado Exitosamente!!", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    return;
                }
            }
            if (paso)
            {
                MessageBox.Show("Productor Guardado Exitosamente!!", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
                MessageBox.Show("No Se Pudo Guardar!!", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void EliminarButton_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            int.TryParse(ProductorIDTextBox.Text, out int id);
            if (!ExisteEnLaBaseDeDatos())
            {
                MessageBox.Show("Debes buscar un Productor Antes de eliminar", "AgroSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (ProductoresBLL.Eliminar(id))
            {
                Limpiar();
                MessageBox.Show("Productor Eliminado Exitosamente!!", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            int.TryParse(ProductorIDTextBox.Text, out int ID);
            Productores productor = ProductoresBLL.Buscar(ID);
            return (productor != null);
        }
        private void NombreTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Constantes.ValidarNombreTextBox(sender, e);
        }
        private void Buscar()
        {
            errorProvider.Clear();
            int.TryParse(ProductorIDTextBox.Text, out int ID);
            Productores productores = ProductoresBLL.Buscar(ID);
            if (productores != null)
            {
                errorProvider.Clear();
                LlenaCampo(productores);
            }
            else
                MessageBox.Show("Productor no Encontrado!!", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void ProductorIDTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Constantes.ValidarSoloNumeros(sender, e);
            if ((int)e.KeyChar == (int)Keys.Enter)
                Buscar();
        }

        public void Ejecutar(Productores template)
        {
            if (template.ProductorID == 0)
                return;
            LlenaCampo(ProductoresBLL.Buscar(template.ProductorID));
        }

        private void BuscaProductores_Click(object sender, EventArgs e)
        {
            var cmd = new CallerMemberName();
            cmd.UsingCallerMemberName();
            ConsultaProductores.Llamado = cmd.Nombre;
            ConsultaProductores cProductores = new ConsultaProductores();
            cProductores.PContrato = this;
            cProductores.ShowDialog();
            cProductores.Dispose();
        }
        
    }
}
