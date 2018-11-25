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
            Limpiar();
            LlenarComboBox();
        }
        private void LlenarComboBox()
        {
            RepositorioBase<TipoArroz> repositorio = new RepositorioBase<TipoArroz>();
            TipoArrozIdcomboBox.Items.Clear();
            foreach(var item in repositorio.GetList(x=>true))
            {
                TipoArrozIdcomboBox.Items.Add(item.TipoArrozId);
            }
        }
        private void Limpiar()
        {
            errorProvider.Clear();
            TipoArrozIdcomboBox.Items.Clear();
            DescripcionTextBox.Text = string.Empty;
            KilostextBox.Text = "0";
            LlenarComboBox();
        }
        private TipoArroz LlenaClase()
        {
            TipoArroz tiposArroz = new TipoArroz();
            if (TipoArrozIdcomboBox.Text.Equals(string.Empty))
                tiposArroz.TipoArrozId = 0;
            else
                tiposArroz.TipoArrozId = Convert.ToInt32(KilostextBox.Text);
            tiposArroz.Descripcion = DescripcionTextBox.Text;
            tiposArroz.Kilos = Convert.ToDecimal(KilostextBox.Text);
            return tiposArroz;
        }
        /*private void LlenaCampo(TiposArroz tiposArroz)
        {
            TipoArrozIDNumericUpDown.Value = tiposArroz.TipoArrozId;
            DescripcionTextBox.Text = tiposArroz.Descripcion;
        }*/
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
            RepositorioBase<TipoArroz> repositorio = new RepositorioBase<TipoArroz>();
            TipoArroz tiposArroz = repositorio.Buscar(Convert.ToInt32(TipoArrozIdcomboBox.Text));
            return (tiposArroz != null);
        }
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<TipoArroz> repositorio = new RepositorioBase<TipoArroz>();
            TipoArroz tiposArroz;
            bool paso = false;
            if (!Validar())
                return;
            tiposArroz = LlenaClase();
            if (TipoArrozIdcomboBox.Text.Equals(string.Empty))
                 paso = TipoArrozBLL.Guardar(tiposArroz);
            else
            {
                    /*if (!ExisteEnLaBaseDeDatos())
                    {
                        MessageBox.Show("No Puedes Modificar un Tipo De Arroz Inexistente, Verifique Los Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }*/
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
            RepositorioBase<TipoArroz> repositorio = new RepositorioBase<TipoArroz>();
            /*if (!ExisteEnLaBaseDeDatos())
            {
                errorProvider.SetError(TipoArrozIDNumericUpDown, "No Puede Borrar Un TIpo De Arroz Inexistente");
                return;
            }*/
            if(TipoArrozIdcomboBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("Para Eliminar Debe Buscar algun Tipo de Arroz", "AgroSoft",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var respuesta = MessageBox.Show("¿Va a Eliminar este Tipo de Arroz", "AgroSoft"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(respuesta==DialogResult.Yes)
            {
                if (repositorio.Eliminar(Convert.ToInt32(TipoArrozIdcomboBox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Tipo De Arroz Eliminado Exitosamente!!", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LlenarComboBox();

                }
            }
           
        }
        private void TipoArrozIdcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RepositorioBase<TipoArroz> repositorio = new RepositorioBase<TipoArroz>();
            errorProvider.Clear();
            TipoArroz tiposArroz = repositorio.Buscar(Convert.ToInt32(TipoArrozIdcomboBox.Text));
            DescripcionTextBox.Text = tiposArroz.Descripcion;
            KilostextBox.Text = Convert.ToString(tiposArroz.Kilos);      
        }


        /* private void BuscarButton_Click(object sender, EventArgs e)
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
         }*/
    }
}
