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
    public partial class RegistroDePesadas : Form
    {
        decimal Total = 0;
        bool paso = true;
        public int FilaSeleccionada { get; set; }
        Pesadas pesadas = new Pesadas();
        List<PesadasDetalle> pesadasDetalles = new List<PesadasDetalle>();
        public RegistroDePesadas()
        {
            InitializeComponent();
            UsuarioTextBox.Text = PesadasBLL.GetUsuario().Nombre;
            LlenaComboBox();
        }
        private void LlenaComboBox()
        {
            PesadaIdcomboBox.Items.Clear();
            ProductorIdcomboBox.Items.Clear();
            TipoArrozIdComboBox.Items.Clear();
            FactoriaIdComboBox.Items.Clear();

            foreach (var item in PesadasBLL.GetList(x => true))
                PesadaIdcomboBox.Items.Add(item.PesadasId);
            foreach (var item in ProductoresBLL.GetList(x => true))
                ProductorIdcomboBox.Items.Add(item.ProductorId);
            foreach (var item in TipoArrozBLL.GetList(x => true))
                TipoArrozIdComboBox.Items.Add(item.TipoArrozId);
            foreach (var item in FactoriaBLL.GetList(x => true))
                FactoriaIdComboBox.Items.Add(item.FactoriaID);
            
        }
        private void Limpiar()
        {
            PesadaIdcomboBox.Text = string.Empty;
            ProductorIdcomboBox.Text = string.Empty;
            TipoArrozIdComboBox.Text = string.Empty;
            FactoriaIdComboBox.Text = string.Empty;
            CantidadSaconumericUpDown.Value = 0;
            KilosPesadosnumericUpDown.Value = 0;
            TotalKGTextBox.Text = string.Empty;
            TotalSacosTextBox.Text = string.Empty;
            FanegaTextBox.Text = string.Empty;
            PorcentajeTextBox.Text = string.Empty;
            TotalAPagarTextBox.Text = string.Empty;
            FechaRegistrodateTimePicker.Value = DateTime.Now;
            EliminarDetalleButton.Enabled = false;
        }
        
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private Pesadas LlenaClase()
        {
            Pesadas pesad = new Pesadas();
            if (PesadaIdcomboBox.Text == string.Empty)
                pesad.PesadasId = 0;
            else
                pesad.PesadasId = Convert.ToInt32(PesadaIdcomboBox.Text);
            pesad.UsuarioId = PesadasBLL.GetUsuario().UsuarioId;
            pesad.FactoriaId = Convert.ToInt32(FactoriaIdComboBox.Text);
            pesad.ProductorId = Convert.ToInt32(ProductorIdcomboBox.Text);
            pesad.TipoArrozId = Convert.ToInt32(TipoArrozIdComboBox.Text);
            pesad.TotalKiloGramos = Convert.ToDecimal(TotalKGTextBox.Text);
            pesad.TotalSacos = Convert.ToDecimal(TotalSacosTextBox.Text);
            pesad.TotalPagar = Convert.ToDecimal(TotalAPagarTextBox.Text);
            pesad.PesadasDetalles = pesadas.PesadasDetalles;
            

            return pesad;
        }
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Pesadas pesadas = LlenaClase();
            if(PesadaIdcomboBox.Text == string.Empty)
            {
                if (PesadasBLL.Guardar(pesadas))
                {
                    MessageBox.Show("Pesada Guardada Exitosamente!!", "AgroSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LlenaComboBox();
                    var resultado = MessageBox.Show("¿Quiere Imprimir un Recibo?", "AgroSoft",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        /*Hacer El Reporte*/
                    }
                    Limpiar();
                }
                else
                    MessageBox.Show("No Se Guardo Su Pesada!!", "AgroSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var resultado = MessageBox.Show("Va a modificar algo, ¿Seguro que desea Hacerlo", "AgroSoft",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(resultado==DialogResult.Yes)
                {
                    if(PesadasBLL.Modificar(LlenaClase()))
                    {
                        MessageBox.Show("Pesada Modificada Exitosamente!!", "AgroSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if(pesadasDetalles.Count != 0)
                        {
                            foreach(var item in pesadasDetalles)
                            {
                                PesadaDetalleBLL.Eliminar(item.Id);
                            }
                        }
                        var resultad = MessageBox.Show("Desea Imprimir un recibo?", "+Ventas",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultad == DialogResult.Yes)
                        {
                            //Hace Reporte

                        }
                        Limpiar();
                    }
                    else
                        MessageBox.Show("No Se pudo Modificar Su Pesada!!", "AgroSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        

        private void AgregarButton_Click(object sender, EventArgs e)
        {
            if (DetalleIdComboBox.Text == string.Empty)
                pesadas.PesadasDetalles.Add(new PesadasDetalle(0,Convert.ToInt32(ProductorIdcomboBox.Text),
                    Convert.ToDecimal(KilosPesadosnumericUpDown.Value),Convert.ToDecimal(CantidadSaconumericUpDown.Value)));
            else
            {
                int pesadaId = Convert.ToInt32(PesadaIdcomboBox.Text);
                if(pesadas.PesadasDetalles.Count==0)
                    pesadas.PesadasDetalles = PesadaDetalleBLL.GetList(x=> x.PesadaId == pesadaId);
                /*if(DetalleIdComboBox.Text == string.Empty)
                {
                    var detalleId
                }*/

            }
            DetalledataGridView.DataSource = null;
            DetalledataGridView.DataSource = pesadas.PesadasDetalles;
            LlenarComboBoxDetalle();
            EliminarDetalleButton.Enabled = true;
        }
        private void LlenarComboBoxDetalle()
        {
            DetalleIdComboBox.Items.Clear();
            foreach(var item in pesadas.PesadasDetalles)
            {
                DetalleIdComboBox.Items.Add(item.Id);
            }
        }

        private void DetalledataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FilaSeleccionada = e.RowIndex;
        }

        private void EliminarDetalleButton_Click(object sender, EventArgs e)
        {
            bool Eliminando = false;
            var resultado = MessageBox.Show("¿Desea Eliminar El Detalle que ha seleccionad?",
                "AgroSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                if(FilaSeleccionada >= 0)
                {
                    Eliminando = true;
                    PesadasDetalle Detalle = pesadas.PesadasDetalles.ElementAt(FilaSeleccionada);
                    pesadasDetalles.Add(new PesadasDetalle(Detalle.Id, Detalle.PesadaId, Detalle.Kilos, Detalle.CantidadDeSacos));
                    pesadas.PesadasDetalles.RemoveAt(FilaSeleccionada);
                    DetalledataGridView.DataSource = null;
                    DetalledataGridView.DataSource = pesadas.PesadasDetalles;
                    FilaSeleccionada = -1;
                    MessageBox.Show("Eliminado", "AgroSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if(DetalledataGridView.Rows.Count==0)
                        MessageBox.Show("No Hay Detalle Seleccionado", "AgroSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void CargarGrid()
        {
            DetalledataGridView.DataSource = null;
            DetalledataGridView.DataSource = pesadasDetalles;
        }

        private void PesadaIdcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
            int PesadaId = Convert.ToInt32(PesadaIdcomboBox.Text);
            pesadas = PesadasBLL.Buscar(PesadaId);
            FactoriaIdComboBox.Text = Convert.ToString(pesadas.FactoriaId);
            ProductorIdcomboBox.Text = Convert.ToString(pesadas.ProductorId);
            TipoArrozIdComboBox.Text = Convert.ToString(pesadas.TipoArrozId);
            TotalSacosTextBox.Text = Convert.ToString(pesadas.TotalSacos);
            TotalKGTextBox.Text = Convert.ToString(pesadas.TotalKiloGramos);
            TotalAPagarTextBox.Text = Convert.ToString(pesadas.TotalPagar);
            DetalleIdComboBox.Enabled = true;
            EliminarButton.Enabled = true;
            DetalledataGridView.DataSource = pesadas.PesadasDetalles;
            pesadasDetalles = new List<PesadasDetalle>();
        }
    }
}
