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
        }
        private void Limpiar()
        {
            errorProvider.Clear();
            TipoIDNumericUpdown.Value = 0;
            DescripcionTextBox.Text = string.Empty;
            KilostextBox.Text = "0";
            FechadateTimePicker.Value = DateTime.Now;
        }
        private TipoArroz LlenaClase()
        {
            TipoArroz tiposArroz = new TipoArroz();
            tiposArroz.TipoArrozID = Convert.ToInt32(TipoIDNumericUpdown.Value);
            tiposArroz.Descripcion = DescripcionTextBox.Text;
            tiposArroz.Kilos = Convert.ToDecimal(KilostextBox.Text);
            tiposArroz.FechaRegistro = FechadateTimePicker.Value;
            return tiposArroz;
        }
        private void LlenaCampo(TipoArroz tipoArroz)
        {
            TipoIDNumericUpdown.Value = tipoArroz.TipoArrozID;
            DescripcionTextBox.Text = tipoArroz.Descripcion;
            KilostextBox.Text = Convert.ToString(tipoArroz.Kilos);
            FechadateTimePicker.Value = tipoArroz.FechaRegistro;
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
            RepositorioBase<TipoArroz> repositorio = new RepositorioBase<TipoArroz>();
            TipoArroz tiposArroz = repositorio.Buscar(Convert.ToInt32(TipoIDNumericUpdown.Value));
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
            if (TipoIDNumericUpdown.Value==0)
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
                        MessageBox.Show("Tipo De Arroz Modificada Exitosamente!!", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (!ExisteEnLaBaseDeDatos())
            {
                errorProvider.SetError(TipoIDNumericUpdown, "No Puede Borrar Un TIpo De Arroz Inexistente");
                return;
            }
            var respuesta = MessageBox.Show("¿Va a Eliminar este TipoUsuario de Arroz", "AgroSoft"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(respuesta==DialogResult.Yes)
            {
                if(KilostextBox.Text != Convert.ToString("0"))
                {
                    MessageBox.Show("Este TipoUsuario de Arroz no puede ser eliminado !!", "AgroSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (repositorio.Eliminar(Convert.ToInt32(TipoIDNumericUpdown.Value)))
                {
                    Limpiar();
                    MessageBox.Show("TipoUsuario De Arroz Eliminado Exitosamente!!", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
           
        }
         private void BuscarButton_Click(object sender, EventArgs e)
         {
             errorProvider.Clear();
             int.TryParse(TipoIDNumericUpdown.Text, out int Id);
             RepositorioBase<TipoArroz> repositorio = new RepositorioBase<TipoArroz>();
            TipoArroz tiposArroz = repositorio.Buscar(Id);
            if (tiposArroz!=null)
             { 
                 errorProvider.Clear();
                 LlenaCampo(tiposArroz);
             }
             else
                 MessageBox.Show("TipoUsuario De Arroz Encontrado!!", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
    }
}
