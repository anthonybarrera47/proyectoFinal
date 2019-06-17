using ProyectoFinal.BLL;
using ProyectoFinal.DAL;
using ProyectoFinal.Entidades;
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
    public partial class RegistroProductores : Form
    {
        public RegistroProductores()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            errorProvider.Clear();
            ProductorIDnumericUpDown.Value = 0;
            NombreTextBox.Text = string.Empty;
            TelefonomaskedTextBox.Text = string.Empty;
            CedulaMasketTextBox.Text = string.Empty;
            FechaNacimientodateTimePicker.Value = DateTime.Now;
        }
        private Productores LlenaClase()
        {
            Productores productores = new Productores();
            productores.ProductorID = (int)ProductorIDnumericUpDown.Value;
            productores.Nombre = NombreTextBox.Text;
            productores.Telefono = TelefonomaskedTextBox.Text;
            productores.Cedula = CedulaMasketTextBox.Text;
            productores.FechaNacimiento = FechaNacimientodateTimePicker.Value;
            productores.FechaRegistro = DateTime.Now;
            return productores;
        }
        private void LlenaCampo(Productores productores)
        {
            ProductorIDnumericUpDown.Value = productores.ProductorID;
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
            if (!Validar())
                return;
            bool paso = false;
            Productores productores = LlenaClase();
            if (ProductorIDnumericUpDown.Value==0)
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
            int.TryParse(ProductorIDnumericUpDown.Text, out int id);
            if(!ExisteEnLaBaseDeDatos())
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
            Productores productor = ProductoresBLL.Buscar((int)ProductorIDnumericUpDown.Value);
            return (productor != null);
        }
        private void NombreTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Constantes.ValidarNombreTextBox(sender, e);
        }
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            int.TryParse(ProductorIDnumericUpDown.Text, out int ID);
            Productores productores = ProductoresBLL.Buscar(ID);
            if (productores != null)
            {
                errorProvider.Clear();
                LlenaCampo(productores); 
            }
            else
                MessageBox.Show("Productor no Encontrado!!", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
