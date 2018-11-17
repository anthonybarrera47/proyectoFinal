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
    public partial class RegistroTiposArroz : Form
    {
        public RegistroTiposArroz()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            errorProvider.Clear();
            TipoArrozIDNumericUpDown.Value = 0;
            DescripcionTextBox.Text = string.Empty;
        }
        private TiposArroz LlenaClase()
        {
            TiposArroz tiposArroz = new TiposArroz();
          
            tiposArroz.TipoArrozId = Convert.ToInt32(TipoArrozIDNumericUpDown.Value);
            tiposArroz.Descripcion = DescripcionTextBox.Text;
            return tiposArroz;
        }
        private void LlenaCampo(TiposArroz tiposArroz)
        {
            TipoArrozIDNumericUpDown.Value = tiposArroz.TipoArrozId;
            DescripcionTextBox.Text = tiposArroz.Descripcion;
        }
        private bool Validar()
        {
            bool paso = true;
            if(String.IsNullOrWhiteSpace(DescripcionTextBox.Text))
            {
                errorProvider.SetError(DescripcionTextBox, "Este Campo No puede Estar Vacio!!");
                paso = false;
            }
            return paso;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<TiposArroz> repositorio = new RepositorioBase<TiposArroz>();
            TiposArroz tiposArroz = repositorio.Buscar((int)TipoArrozIDNumericUpDown.Value);
            return (tiposArroz != null);
        }
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<TiposArroz> repositorio = new RepositorioBase<TiposArroz>();
            TiposArroz tiposArroz;
            bool paso = false;
            if (!Validar())
                return;
            tiposArroz = LlenaClase();
            if (TipoArrozIDNumericUpDown.Value == 0)
                 paso = TipoArrozBLL.Guardar(tiposArroz);
            else
            {
                    if (!ExisteEnLaBaseDeDatos())
                    {
                        MessageBox.Show("No Puedes Modificar un Tipo De Arroz Inexistente, Verifique Los Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    paso = repositorio.Modificar(tiposArroz);
                    if(paso)
                    {
                        MessageBox.Show("Tipos De Arroz Modificada Exitosamente!!", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        return;
                    }
            }
            if (paso)
            {
                MessageBox.Show("Tipo De Arroz Guardado Exitosamente!!", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
                MessageBox.Show("No Se Pudo Guardar!!", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            int Id;
            int.TryParse(TipoArrozIDNumericUpDown.Text, out Id);
            RepositorioBase<TiposArroz> repositorio = new RepositorioBase<TiposArroz>();
            if (!ExisteEnLaBaseDeDatos())
            {
                errorProvider.SetError(TipoArrozIDNumericUpDown, "No Puede Borrar Un TIpo De Arroz Inexistente");
                return;
            }
            if(repositorio.Eliminar(Id))
            {
                Limpiar();
                MessageBox.Show("Tipo De Arroz Eliminado Exitosamente!!", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            int Id;
            int.TryParse(TipoArrozIDNumericUpDown.Text, out Id);
            RepositorioBase<TiposArroz> repositorio = new RepositorioBase<TiposArroz>();
            TiposArroz tiposArroz = new TiposArroz();

            tiposArroz = repositorio.Buscar(Id);
            if(tiposArroz!=null)
            { 
                errorProvider.Clear();
                LlenaCampo(tiposArroz);
                MessageBox.Show("Tipo De Arroz Encontrado!!", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Tipo De Arroz Encontrado!!", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
