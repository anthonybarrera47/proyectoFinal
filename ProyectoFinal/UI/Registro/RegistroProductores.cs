using ProyectoFinal.BLL;
using ProyectoFinal.DAL;
using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.UI.Registro
{
    public partial class RegistroProductores : Form
    {
        public RegistroProductores()
        {
            InitializeComponent();
            LlenaComboBox();
        }
        private void LlenaComboBox()
        {
            ProductorIdcomboBox.Items.Clear();
            foreach (var item in ProductoresBLL.GetList(x => true))
            {
                ProductorIdcomboBox.Items.Add(item.ProductorId);
            }
        }
        private void Limpiar()
        {
            errorProvider.Clear();
            ProductorIdcomboBox.Text = string.Empty;
            NombreTextBox.Text = string.Empty;
            TelefonomaskedTextBox.Text = string.Empty;
            CedulaMasketTextBox.Text = string.Empty;
            FechaNacimientodateTimePicker.Value = DateTime.Now;
            LlenaComboBox();
        }
        private Productores LlenaClase()
        {
            Productores productores = new Productores();
            if (ProductorIdcomboBox.Text.Equals(string.Empty))
                productores.ProductorId = 0;
            else
                productores.ProductorId = Convert.ToInt32(ProductorIdcomboBox.Text);
            productores.Nombre = NombreTextBox.Text;
            productores.Telefono = TelefonomaskedTextBox.Text;
            productores.Cedula = CedulaMasketTextBox.Text;
            productores.FechaNacimiento = FechaNacimientodateTimePicker.Value;
            return productores;
        }
        private void LlenaCampo(Productores productores)
        {
            ProductorIdcomboBox.Text = Convert.ToString(productores.ProductorId);
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
            if(NombreTextBox.Text[0].Equals(" "))
            {
                errorProvider.SetError(NombreTextBox, "El Primer Caracter es un espacio en Blanco");
                paso = false;
            }
            if (String.IsNullOrWhiteSpace(NombreTextBox.Text) )
            {
                errorProvider.SetError(NombreTextBox, "Este Campo No puede Estar Vacio , Ni Debe Contener caracteres!!");
                paso = false;
            }
            if (String.IsNullOrWhiteSpace(TelefonomaskedTextBox.Text.Replace("-", "")) || TelefonomaskedTextBox.TextLength != 12)
            {
                errorProvider.SetError(TelefonomaskedTextBox, "Este Campo No puede Estar Vacio!!");
                paso = false;
            }
            if (String.IsNullOrWhiteSpace(CedulaMasketTextBox.Text.Replace("-", "")) || CedulaMasketTextBox.TextLength !=13)
            {
                errorProvider.SetError(CedulaMasketTextBox, "Este Campo No puede Estar Vacio!!");
                paso = false;
            }
            if(Constantes.ValidarEspaciosEnBlancos(TelefonomaskedTextBox.Text)==false)
            {
                errorProvider.SetError(TelefonomaskedTextBox, "Este Campo No puede Tener Espacios En Blancos!!");
                paso = false;
            }
            if(Constantes.ValidarEspaciosEnBlancos(CedulaMasketTextBox.Text)==false)
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
            Productores productores;
            bool paso = false;
            if (!Validar())
                return;

            productores = LlenaClase();
            if (ProductorIdcomboBox.Text.Equals(string.Empty))
                paso = ProductoresBLL.Guardar(productores);
            else
            {
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
            int.TryParse(ProductorIdcomboBox.Text, out int id);
            if(ProductorIdcomboBox.Text.Equals(string.Empty))
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
        private void NombreTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Constantes.ValidarNombreTextBox(sender, e);
        }

        private void ProductorIdcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
            int.TryParse(ProductorIdcomboBox.Text, out int id);
            Productores productores = new Productores();

            productores = ProductoresBLL.Buscar(id);
            if (productores != null)
            {
                errorProvider.Clear();
                LlenaCampo(productores);
                MessageBox.Show("Productor Encontrado!!", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Productor no Encontrado!!", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }
    }
}
