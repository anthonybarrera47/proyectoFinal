using ProyectoFinal.BLL;
using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            ProductoresIdnumericUpDown.Value = 0;
            NombreTextBox.Text = string.Empty;
            TelefonomaskedTextBox.Text = string.Empty;
            BalancenumericUpDown.Value = 0;
            CedulaMasketTextBox.Text = string.Empty;
            FechaNacimientodateTimePicker.Value = DateTime.Now;
        }
        private Productores LlenaClase()
        {
            Productores productores = new Productores()
            {
                ProductorId = Convert.ToInt32(ProductoresIdnumericUpDown.Value),
                Nombre = NombreTextBox.Text,
                Telefono = TelefonomaskedTextBox.Text,
                Balance = BalancenumericUpDown.Value,
                Cedula = CedulaMasketTextBox.Text,
                FechaNacimiento = FechaNacimientodateTimePicker.Value
            };
            return productores;
        }
        private void LlenaCampo(Productores productores)
        {
            ProductoresIdnumericUpDown.Value = productores.ProductorId;
            NombreTextBox.Text =  productores.Nombre;
            TelefonomaskedTextBox.Text = productores.Telefono;
            BalancenumericUpDown.Value = productores.Balance;
            CedulaMasketTextBox.Text = productores.Cedula;
            FechaNacimientodateTimePicker.Value = productores.FechaNacimiento;
        }
        private bool Validar()
        {
            bool paso = true;
            if (String.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                errorProvider.SetError(NombreTextBox, "Este Campo No puede Estar Vacio!!");
                paso = false;
            }
            if (String.IsNullOrWhiteSpace(TelefonomaskedTextBox.Text))
            {
                errorProvider.SetError(TelefonomaskedTextBox, "Este Campo No puede Estar Vacio!!");
                paso = false;
            }
            if (String.IsNullOrWhiteSpace(CedulaMasketTextBox.Text))
            {
                errorProvider.SetError(CedulaMasketTextBox, "Este Campo No puede Estar Vacio!!");
                paso = false;
            }
            return paso;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Productores productores = ProductoresBLL.Buscar((int)ProductoresIdnumericUpDown.Value);
            return (productores != null);
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
            if (ProductoresIdnumericUpDown.Value == 0)
                paso = ProductoresBLL.Guardar(productores);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No Puedes Modificar un Productor Inexistente, Verifique Los Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            int id;
            int.TryParse(ProductoresIdnumericUpDown.Text, out id);

            if(!ExisteEnLaBaseDeDatos())
            {
                errorProvider.SetError(ProductoresIdnumericUpDown, "No Puede Borrar Un Productor Inexistente");
                return;
            }
            if(ProductoresBLL.Eliminar(id))
            {
                Limpiar();
                MessageBox.Show("Productor Eliminado Exitosamente!!", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            int id;
            int.TryParse(ProductoresIdnumericUpDown.Text, out id);
            Productores productores = new Productores();

            productores = ProductoresBLL.Buscar(id);
            if(productores!=null)
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
