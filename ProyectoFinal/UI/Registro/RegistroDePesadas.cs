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
        decimal TotalSacos = 0, TotalKilogramos;
        bool Confirmar = false;
        public int FilaSeleccionada { get; set; }
        Pesadas pesadas = new Pesadas();
        List<PesadasDetalle> pesadasDetalles = new List<PesadasDetalle>();
        public RegistroDePesadas()
        {
            InitializeComponent();
            UsuarioTextBox.Text = PesadasBLL.GetUsuario().Nombre;
            LlenaComboBox();
            Limpiar();
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
            errorProvider.Clear();
            PesadaIdcomboBox.Text = string.Empty;
            ProductorIdcomboBox.Text = string.Empty;
            TipoArrozIdComboBox.Text = string.Empty;
            FactoriaIdComboBox.Text = string.Empty;
            CantidadSaconumericUpDown.Value = 0;
            KilosPesadosnumericUpDown.Value = 0;
            TotalKGTextBox.Text = string.Empty;
            TotalSacosTextBox.Text = string.Empty;
            PrecioFaneganumericUpDown.Value = 0;
            FaneganumericUpDown.Value = 0;
            CantidadSaconumericUpDown.Value = 0;
            KilosPesadosnumericUpDown.Value = 0;
            TotalAPagarTextBox.Text = string.Empty;
            FechaRegistrodateTimePicker.Value = DateTime.Now;
            EliminarDetalleButton.Enabled = false;
            pesadas.PesadasDetalles = new List<PesadasDetalle>();
            DetalledataGridView.DataSource = null;
            CargarGrid();
        }
        public bool Validar()
        {
            errorProvider.Clear();
            bool paso = true;
            if(ProductorIdcomboBox.Text == string.Empty)
            {
                errorProvider.SetError(ProductorNombretextBox, "Debe Seleccionar o Crear un productor");
                ProductorIdcomboBox.Focus();
                paso = false;
            }
            if(TipoArrozIdComboBox.Text==string.Empty)
            {
                errorProvider.SetError(TipoArroztextBox, "Debe Seleccionar o Crear un Tipo de Arroz");
                TipoArrozIdComboBox.Focus();
                paso = false;
            }
            if(FactoriaIdComboBox.Text == string.Empty)
            {
                errorProvider.SetError(FactoriaIdComboBox, "Debe Seleccionar o Crear una Factoria");
                FactoriaIdComboBox.Focus();
                paso = false;
            }
            return paso;
        }
        public bool ValidarDetalle()
        {
            bool paso = true;
            if(CantidadSaconumericUpDown.Value <= 0)
            {
                errorProvider.SetError(CantidadSaconumericUpDown, "La Cantidad De Sacos Debe ser Mayor a 0");
                CantidadSaconumericUpDown.Focus();
                paso = false;
            }
            if(KilosPesadosnumericUpDown.Value<=0)
            {
                errorProvider.SetError(KilosPesadosnumericUpDown, "La Cantidad De Kilos Debe ser Mayor a 0");
                KilosPesadosnumericUpDown.Focus();
                paso = false;
            }
            if(FaneganumericUpDown.Value<=0)
            {
                errorProvider.SetError(FaneganumericUpDown, "La Fanega Debe ser Mayor a 0");
                FaneganumericUpDown.Focus();
                paso = false;
            }
            if(PrecioFaneganumericUpDown.Value<=0)
            {
                errorProvider.SetError(PrecioFaneganumericUpDown, "El Precio de la Fanega Debe ser Mayor a 0");
                PrecioFaneganumericUpDown.Focus();
                paso = false;
            }
            return paso;
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
            pesad.Fanega = Convert.ToDecimal(FaneganumericUpDown.Value);
            pesad.PrecioFanega = Convert.ToDecimal(PrecioFaneganumericUpDown.Value);
            pesad.TotalKiloGramos = Convert.ToDecimal(TotalKGTextBox.Text);
            pesad.TotalSacos = Convert.ToDecimal(TotalSacosTextBox.Text);
            pesad.TotalPagar = Convert.ToDecimal(TotalAPagarTextBox.Text);
            pesad.FechaRegistro = FechaRegistrodateTimePicker.Value;
            pesad.PesadasDetalles = pesadas.PesadasDetalles;
            return pesad;
        }
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;
            Pesadas pesad = LlenaClase();
            if (PesadaIdcomboBox.Text.Equals(string.Empty))
            {
                if (PesadasBLL.Guardar(pesad))
                {
                    MessageBox.Show("Pesada Guardada Exitosamente!!", "AgroSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LlenaComboBox();
                    PesadasBLL.EnviarKilaje(pesad.PesadasDetalles);
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
                if (resultado == DialogResult.Yes)
                {
                    if (PesadasBLL.Modificar(pesad))
                    {
                        MessageBox.Show("Pesada Modificada Exitosamente!!", "AgroSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (pesadasDetalles.Count != 0)
                        {
                            foreach (var item in pesadasDetalles)
                            {
                                PesadaDetalleBLL.Eliminar(item.Id);
                            }
                        }
                        if(Confirmar)
                        {
                            PesadasBLL.DescontarKilaje(pesadasDetalles);
                            Confirmar = false;
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
            if (!ValidarDetalle())
                return;
            if (DetalleIdComboBox.Text == string.Empty)
                pesadas.PesadasDetalles.Add(new PesadasDetalle(0, Convert.ToInt32(ProductorIdcomboBox.Text),Convert.ToInt32(TipoArrozIdComboBox.Text),
                    Convert.ToDecimal(KilosPesadosnumericUpDown.Value), Convert.ToDecimal(CantidadSaconumericUpDown.Value)));
            else
            {
                int pesadaId = Convert.ToInt32(PesadaIdcomboBox.Text);
                if (pesadas.PesadasDetalles.Count == 0)
                    pesadas.PesadasDetalles = PesadaDetalleBLL.GetList(x => x.PesadasId == pesadaId);
                /*if(DetalleIdComboBox.Text == string.Empty)
                {
                    var detalleId
                }*/
                if(DetalleIdComboBox.Text.Equals(string.Empty))
                {
                    var tipoarroz = Convert.ToInt32(TipoArrozIdComboBox.Text);
                    if(pesadas.PesadasDetalles.Exists(x=>x.TipoArrozId == tipoarroz))
                    {
                        foreach(var item in pesadas.PesadasDetalles)
                        {
                            if(item.TipoArrozId == tipoarroz)
                            {
                                item.Kilos += Convert.ToDecimal(KilosPesadosnumericUpDown.Value);
                            }
                        }
                    }
                    else
                        pesadas.PesadasDetalles.Add(new PesadasDetalle(0, Convert.ToInt32(ProductorIdcomboBox.Text), Convert.ToInt32(TipoArrozIdComboBox.Text),
                        Convert.ToDecimal(KilosPesadosnumericUpDown.Value), Convert.ToDecimal(CantidadSaconumericUpDown.Value)));
                }
                else
                {
                    pesadas.PesadasDetalles = PesadasBLL.Editar(pesadas.PesadasDetalles, new PesadasDetalle(Convert.ToInt32(DetalleIdComboBox.Text), Convert.ToInt32(ProductorIdcomboBox.Text), Convert.ToInt32(TipoArrozIdComboBox.Text),
                                                                Convert.ToDecimal(KilosPesadosnumericUpDown.Value), Convert.ToDecimal(CantidadSaconumericUpDown.Value)));
                }
            }
            TotalSacosTextBox.Text = string.Empty;
            TotalKGTextBox.Text = string.Empty;
            TotalKilogramos += KilosPesadosnumericUpDown.Value;
            TotalSacos += CantidadSaconumericUpDown.Value;

            Calculos();
            DetalledataGridView.DataSource = null;
            DetalledataGridView.DataSource = pesadas.PesadasDetalles;
            LlenarComboBoxDetalle();
            EliminarDetalleButton.Enabled = true;

        }
        private void LlenarComboBoxDetalle()
        {
            DetalleIdComboBox.Items.Clear();
            foreach (var item in pesadas.PesadasDetalles)
                DetalleIdComboBox.Items.Add(item.Id);

        }

        private void DetalledataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FilaSeleccionada = e.RowIndex;
            EliminarDetalleButton.Enabled = true;
        }

        private void EliminarDetalleButton_Click(object sender, EventArgs e)
        {
            //bool Eliminando = false;
            var resultado = MessageBox.Show("¿Desea Eliminar El Detalle que ha seleccionad?",
                "AgroSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                if (FilaSeleccionada >= 0)
                {
                    //Eliminando = true;
                    Confirmar = true;
                    PesadasDetalle Detalle = pesadas.PesadasDetalles.ElementAt(FilaSeleccionada);
                    TotalSacos -= Detalle.CantidadDeSacos;
                    TotalKilogramos -= Detalle.Kilos;
                    pesadasDetalles.Add(new PesadasDetalle(Detalle.Id, Detalle.PesadasId,Detalle.TipoArrozId, Detalle.Kilos, Detalle.CantidadDeSacos));
                    pesadas.PesadasDetalles.RemoveAt(FilaSeleccionada);
                    DetalledataGridView.DataSource = null;
                    DetalledataGridView.DataSource = pesadas.PesadasDetalles;

                    FilaSeleccionada = -1;
                    MessageBox.Show("Eliminado", "AgroSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (DetalledataGridView.Rows.Count == 0)
                        MessageBox.Show("No Hay Detalle Seleccionado", "AgroSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Calculos();
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
            UsuarioTextBox.Text = PesadasBLL.GetUsuario().Nombre;
            FactoriaIdComboBox.Text = Convert.ToString(pesadas.FactoriaId);
            ProductorIdcomboBox.Text = Convert.ToString(pesadas.ProductorId);
            TipoArrozIdComboBox.Text = Convert.ToString(pesadas.TipoArrozId);
            TotalSacos = pesadas.TotalSacos;
            TotalKilogramos = pesadas.TotalKiloGramos;
            FaneganumericUpDown.Value = pesadas.Fanega;
            PrecioFaneganumericUpDown.Value = pesadas.PrecioFanega;
            TotalSacosTextBox.Text = Convert.ToString(pesadas.TotalSacos);
            TotalKGTextBox.Text = Convert.ToString(pesadas.TotalKiloGramos);
            TotalAPagarTextBox.Text = Convert.ToString(pesadas.TotalPagar);
            FechaRegistrodateTimePicker.Value = pesadas.FechaRegistro;
            DetalleIdComboBox.Enabled = true;
            EliminarButton.Enabled = true;
            LlenarComboBoxDetalle();
            DetalledataGridView.DataSource = pesadas.PesadasDetalles;
            
            pesadasDetalles = new List<PesadasDetalle>();
        }

        private void Calculos()
        {
            decimal totalSacos = 0, totalKilogramos = 0, Fanega = 0, PrecioNega = 0, totalApagar = 0;
            TotalKGTextBox.Text = string.Empty;
            TotalKGTextBox.Text = string.Empty;
            TotalKGTextBox.Text = Convert.ToString(TotalKilogramos);
            TotalSacosTextBox.Text = Convert.ToString(TotalSacos);
            totalKilogramos = Convert.ToDecimal(TotalKGTextBox.Text);
            totalSacos = Convert.ToDecimal(TotalSacosTextBox.Text);
            Fanega = Convert.ToDecimal(FaneganumericUpDown.Value);
            PrecioNega = Convert.ToDecimal(PrecioFaneganumericUpDown.Value);
            totalApagar = Math.Round((TotalKilogramos - (totalSacos)) / Fanega, 2) * PrecioNega;
            TotalAPagarTextBox.Text = Convert.ToString(Math.Round(totalApagar, 2));
        }

        private void ProductorIdcomboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ProductorNombretextBox.Text = BalancetextBox.Text=string.Empty;
            Productores productor = ProductoresBLL.Buscar(Convert.ToInt32(ProductorIdcomboBox.Text));
            ProductorNombretextBox.Text = productor.Nombre;
        }

        private void TipoArrozIdComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            TipoArroztextBox.Text = string.Empty;
            TipoArroztextBox.Text = TipoArrozBLL.Buscar(Convert.ToInt32(TipoArrozIdComboBox.Text)).Descripcion;
        }

        private void DetalleIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID, pesadaid;
            pesadaid = Convert.ToInt32(PesadaIdcomboBox.Text);
            ID = Convert.ToInt32(DetalleIdComboBox.Text);
            if(pesadas.PesadasDetalles.Count() == 0)
                pesadas.PesadasDetalles = PesadaDetalleBLL.GetList(x => x.PesadasId == pesadaid);
            foreach(var item in pesadas.PesadasDetalles)
            {
                if(item.Id == ID)
                {
                    CantidadSaconumericUpDown.Value = item.CantidadDeSacos;
                    KilosPesadosnumericUpDown.Value = item.Kilos;
                    TipoArrozIdComboBox.Text = Convert.ToString(item.TipoArrozId);
                }
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿Desea Eliminar?", "AgroSoft",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(resultado.Equals(DialogResult.Yes))
            {
                PesadasBLL.ArreglarDEtalle(PesadasBLL.Buscar(Convert.ToInt32(PesadaIdcomboBox.Text)));
                if (PesadasBLL.Eliminar(Convert.ToInt32(PesadaIdcomboBox.Text))) 
                {
                    MessageBox.Show("Pesada Eliminada!!", "AgroSoft",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DetalledataGridView.DataSource = null;
                    LlenaComboBox();
                    Limpiar();
                }
                else
                    MessageBox.Show("Pesada No pudo Ser Eliminada!!", "AgroSoft",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FactoriaIdComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            FactoriatextBox.Text = string.Empty;
            FactoriatextBox.Text = FactoriaBLL.Buscar(Convert.ToInt32(FactoriaIdComboBox.Text)).Nombre;
        }
       
    }
}
