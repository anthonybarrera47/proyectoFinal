using BLL;
using DAL;
using Entidades;
using ProyectoFinal.UI.Consulta;
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
    public partial class RegistroTiposArroz : Form, IRetorno<TipoArroz>
    {
        public RegistroTiposArroz()
        {
            InitializeComponent();
            Limpiar();
        }
        private void Limpiar()
        {
            errorProvider.Clear();
            TipoIDTextBox.Text = 0.ToString();
            DescripcionTextBox.Text = string.Empty;
            KilostextBox.Text = 0.ToString();
            FechadateTimePicker.Value = DateTime.Now;
        }
        private TipoArroz LlenaClase()
        {
            TipoArroz tiposArroz = new TipoArroz
            {
                TipoArrozID = (TipoIDTextBox.Text).ToInt(),
                Descripcion = DescripcionTextBox.Text,
                Kilos = (KilostextBox.Text).ToDecimal(),
                FechaRegistro = FechadateTimePicker.Value
            };
            return tiposArroz;
        }
        private void LlenaCampo(TipoArroz tipoArroz)
        {
            TipoIDTextBox.Text = tipoArroz.TipoArrozID.ToString();
            DescripcionTextBox.Text = tipoArroz.Descripcion;
            KilostextBox.Text = Convert.ToString(tipoArroz.Kilos);
            FechadateTimePicker.Value = tipoArroz.FechaRegistro;
        }
        private bool Validar()
        {
            bool paso = true;
            if (String.IsNullOrWhiteSpace(DescripcionTextBox.Text))
            {
                errorProvider.SetError(DescripcionTextBox, "Este Campo No puede Estar Vacio!!");
                paso = false;
            }
            return paso;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<TipoArroz> repositorio = new RepositorioBase<TipoArroz>();
            TipoArroz tiposArroz;
            try
            {
                tiposArroz = repositorio.Buscar(TipoIDTextBox.Text.ToInt());
            }
            catch (Exception)
            { throw; }
            finally
            { repositorio.Dispose(); }
            return (tiposArroz != null);

        }
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<TipoArroz> repositorio = new RepositorioBase<TipoArroz>();
            try
            {

                TipoArroz tiposArroz;
                bool paso = false;
                if (!Validar())
                    return;
                tiposArroz = LlenaClase();
                if (Convert.ToInt32(TipoIDTextBox.Text) == 0)
                    paso = TipoArrozBLL.Guardar(tiposArroz);
                else
                {
                    if (!ExisteEnLaBaseDeDatos())
                    {
                        MessageBox.Show("No puedes modificar un tipo de arroz inexistente, verifique los datos", "AgroSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    paso = repositorio.Modificar(tiposArroz);
                    if (paso)
                    {
                        MessageBox.Show("Tipo de arroz modificada exitosamente!!", "AgroSoft!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        return;
                    }
                }
                if (paso)
                {
                    MessageBox.Show("Tipo de arroz guardado exitosamente!!", "AgroSoft!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                    MessageBox.Show("No se oudo guardar!!", "AgroSoft!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            { throw; }
            finally
            { repositorio.Dispose(); }

        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            RepositorioBase<TipoArroz> repositorio = new RepositorioBase<TipoArroz>();
            try
            {

                if (!ExisteEnLaBaseDeDatos())
                {
                    errorProvider.SetError(TipoIDTextBox, "No puede borrar Un Tipo de arroz inexistente");
                    return;
                }
                var respuesta = MessageBox.Show("¿Va a eliminar este tipo de arroz", "AgroSoft"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    if (KilostextBox.Text != Convert.ToString("0"))
                    {
                        MessageBox.Show("Este tipo de arroz no puede ser eliminado !!", "AgroSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (repositorio.Eliminar(Convert.ToInt32(TipoIDTextBox.Text)))
                    {
                        Limpiar();
                        MessageBox.Show("Tipo de arroz eliminado exitosamente!!", "AgroSoft!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception)
            { throw; }
            finally
            { repositorio.Dispose(); }


        }
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            var cmd = new CallerMemberName();
            cmd.UsingCallerMemberName();
            ConsultaTipoArroz.Llamado = cmd.Nombre;
            ConsultaTipoArroz cConsultaTipoArroz = new ConsultaTipoArroz
            {
                TContrato = this
            };
            cConsultaTipoArroz.ShowDialog();
            cConsultaTipoArroz.Dispose();
        }
        public void Ejecutar(TipoArroz template)
        {
            if (template.TipoArrozID == 0)
                return;
            LlenaCampo(TipoArrozBLL.Buscar(template.TipoArrozID));
        }
        private void Buscar()
        {
            errorProvider.Clear();
            RepositorioBase<TipoArroz> repositorio = new RepositorioBase<TipoArroz>();
            try
            {
                int.TryParse(TipoIDTextBox.Text, out int Id);
                TipoArroz tiposArroz = repositorio.Buscar(Id);
                if (tiposArroz != null)
                {
                    errorProvider.Clear();
                    LlenaCampo(tiposArroz);
                }
                else
                    MessageBox.Show("Tipo de arroz encontrado!!", "AgroSoft!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            { throw; }
            finally
            { repositorio.Dispose(); }

        }
        private void TipoIDTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
                Buscar();
            Constantes.ValidarSoloNumeros(sender, e);
        }
    }
}
