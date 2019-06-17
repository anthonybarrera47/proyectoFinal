using ProyectoFinal.BLL;
using ProyectoFinal.DAL;
using ProyectoFinal.Entidades;
using ProyectoFinal.UI.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ProyectoFinal.UI.Registro
{

    public partial class RegistroDePesadas : Form
    {
        bool Confirmar = false;
        public int FilaSeleccionada { get; set; }

        Pesadas PesadasOriginal = new Pesadas();
        List<PesadasDetalle> pesadasDetalles = new List<PesadasDetalle>();
        Pesadas pesadaImprimir;
        public RegistroDePesadas()
        {
            InitializeComponent();
            UsuarioTextBox.Text = PesadasBLL.GetUsuario().Nombre;
            LlenaComboBox();
            Limpiar();   
        }
        private void LlenaComboBox()
        {
            ProductorIdcomboBox.DataSource = null;
            TipoArrozIdComboBox.DataSource = null;
            FactoriaIdComboBox.DataSource = null;

            ProductorIdcomboBox.DataSource = ProductoresBLL.GetList(x => true);
            ProductorIdcomboBox.ValueMember = "ProductorID";
            ProductorIdcomboBox.DisplayMember = "Nombre";

            TipoArrozIdComboBox.DataSource = TipoArrozBLL.GetList(x => true);
            TipoArrozIdComboBox.ValueMember = "TipoArrozID";
            TipoArrozIdComboBox.DisplayMember = "Descripcion";

            FactoriaIdComboBox.DataSource = FactoriaBLL.GetList(x => true);
            FactoriaIdComboBox.ValueMember = "FactoriaID";
            FactoriaIdComboBox.DisplayMember = "Nombre";
        }
        private void Limpiar()
        {
            errorProvider.Clear();
            PesadaIDnumericUpDown.Value = 0;
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
            PesadasOriginal.PesadasDetalles = new List<PesadasDetalle>();
            DetalledataGridView.DataSource = null;
            LlenaComboBox();
            ImprimirButton.Visible = false;
            IDDetalle.Visible = false;
            CargarGrid();
        }
        private Pesadas LlenaClase()
        {
            Pesadas pesad = new Pesadas();
            pesad.PesadaID = Convert.ToInt32(PesadaIDnumericUpDown.Value);
            pesad.UsuarioID = PesadasBLL.GetUsuario().UsuarioID;
            pesad.FactoriaID = Convert.ToInt32(FactoriaIdComboBox.SelectedValue);
            pesad.ProductorID = Convert.ToInt32(ProductorIdcomboBox.SelectedValue);
            pesad.TipoArrozID = Convert.ToInt32(TipoArrozIdComboBox.SelectedValue);
            pesad.Fanega = Convert.ToDecimal(FaneganumericUpDown.Value);
            pesad.PrecioFanega = Convert.ToDecimal(PrecioFaneganumericUpDown.Value);
            pesad.TotalKiloGramos = Convert.ToDecimal(TotalKGTextBox.Text);
            pesad.TotalSacos = Convert.ToDecimal(TotalSacosTextBox.Text);
            pesad.TotalPagar = Convert.ToDecimal(TotalAPagarTextBox.Text);
            pesad.FechaRegistro = FechaRegistrodateTimePicker.Value;
            pesad.PesadasDetalles = PesadasOriginal.PesadasDetalles;
            return pesad;
        }
        private void LlenaCampo(Pesadas pesad)
        {
            errorProvider.Clear();
            pesadaImprimir = new Pesadas();
            Pesadas pesadaAux = pesad;
            //pesadasDetalleImprimir = new List<PesadasDetalle>();
            UsuarioTextBox.Text = PesadasBLL.GetUsuario().Nombre;
            FactoriaIdComboBox.Text = Convert.ToString(pesadaAux.FactoriaID);
            ProductorIdcomboBox.Text = Convert.ToString(pesadaAux.ProductorID);
            TipoArrozIdComboBox.Text = Convert.ToString(pesadaAux.TipoArrozID);
            FaneganumericUpDown.Value = pesadaAux.Fanega;
            PrecioFaneganumericUpDown.Value = pesadaAux.PrecioFanega;
            TotalSacosTextBox.Text = Convert.ToString(pesadaAux.TotalSacos);
            TotalKGTextBox.Text = Convert.ToString(pesadaAux.TotalKiloGramos);
            TotalAPagarTextBox.Text = Convert.ToString(pesadaAux.TotalPagar);
            FechaRegistrodateTimePicker.Value = pesadaAux.FechaRegistro;
            EliminarButton.Enabled = true;
            DetalledataGridView.DataSource = pesadaAux.PesadasDetalles;
            ImprimirButton.Visible = true;
            pesadasDetalles = new List<PesadasDetalle>();
            pesadaImprimir = pesadaAux;
            PesadasOriginal = pesadaAux;
            IDDetalle.Visible = true;
        }
        public bool Validar()
        {
            errorProvider.Clear();
            bool paso = true;
            if (ProductorIdcomboBox.SelectedIndex < 0)
            {
                errorProvider.SetError(ProductorIdcomboBox, "Debe Seleccionar o Crear un productor");
                ProductorIdcomboBox.Focus();
                paso = false;
            }
            if (TipoArrozIdComboBox.SelectedIndex<0)
            {
                errorProvider.SetError(TipoArrozIdComboBox, "Debe Seleccionar o Crear un TipoUsuario de Arroz");
                TipoArrozIdComboBox.Focus();
                paso = false;
            }
            if (FactoriaIdComboBox.Text == string.Empty)
            {
                errorProvider.SetError(FactoriaIdComboBox, "Debe Seleccionar o Crear una Factoria");
                FactoriaIdComboBox.Focus();
                paso = false;
            }
            return paso;
        }
        public bool ValidarDetalle()
        {
            errorProvider.Clear();
            bool paso = true;
            if (CantidadSaconumericUpDown.Value <= 0)
            {
                errorProvider.SetError(CantidadSaconumericUpDown, "La Cantidad De Sacos Debe ser Mayor a 0");
                CantidadSaconumericUpDown.Focus();
                paso = false;
            }
            if (KilosPesadosnumericUpDown.Value <= 0)
            {
                errorProvider.SetError(KilosPesadosnumericUpDown, "La Cantidad De Kilos Debe ser Mayor a 0");
                KilosPesadosnumericUpDown.Focus();
                paso = false;
            }
            if (FaneganumericUpDown.Value <= 0)
            {
                errorProvider.SetError(FaneganumericUpDown, "La Fanega Debe ser Mayor a 0");
                FaneganumericUpDown.Focus();
                paso = false;
            }
            if (PrecioFaneganumericUpDown.Value <= 0)
            {
                errorProvider.SetError(PrecioFaneganumericUpDown, "El Precio de la Fanega Debe ser Mayor a 0");
                PrecioFaneganumericUpDown.Focus();
                paso = false;
            }
            if (TipoArrozIdComboBox.Text.Equals(string.Empty))
            {
                errorProvider.SetError(TipoArrozIdComboBox, "Debe Elegir un tipo de arroz");
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
            Pesadas pesad = LlenaClase();
            if (PesadaIDnumericUpDown.Value ==0)
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
                        ReportePesadaDetalles reporte = new ReportePesadaDetalles(pesad,pesad.PesadasDetalles, PesadasBLL.GetUsuario().Nombre);
                        reporte.Show();
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
                                PesadaDetalleBLL.Eliminar(item.PesadaDetalleID);
                            }
                        }
                        if (Confirmar)
                        {
                            PesadasBLL.DescontarKilaje(pesadasDetalles);
                            Confirmar = false;
                        }
                        var resultad = MessageBox.Show("Desea Imprimir un recibo?", "AgroSoft",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultad == DialogResult.Yes)
                        {
                            ReportePesadaDetalles reporte = new ReportePesadaDetalles(pesad, pesad.PesadasDetalles,PesadasBLL.GetUsuario().Nombre);
                            reporte.Show();

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
            IDDetalle.Visible = true;
            if (IDDetalle.Value == 0)
                PesadasOriginal.PesadasDetalles.Add(new PesadasDetalle(0, PesadasOriginal.PesadaID, Convert.ToInt32(TipoArrozIdComboBox.SelectedValue),
                    Convert.ToDecimal(KilosPesadosnumericUpDown.Value), Convert.ToDecimal(CantidadSaconumericUpDown.Value)));
            else
            {
                int pesadaId = Convert.ToInt32(PesadaIDnumericUpDown.Value);
                if (PesadasOriginal.PesadasDetalles.Count == 0)
                {
                    PesadasOriginal.PesadasDetalles = PesadaDetalleBLL.GetList(x => x.PesadasID == pesadaId);
                }
                PesadasOriginal.PesadasDetalles.Add(new PesadasDetalle(0, Convert.ToInt32(PesadaIDnumericUpDown.Value), Convert.ToInt32(TipoArrozIdComboBox.Text),
                    Convert.ToDecimal(KilosPesadosnumericUpDown.Value), Convert.ToDecimal(CantidadSaconumericUpDown.Value)));
                PesadasOriginal.PesadasDetalles = PesadasBLL.Editar(PesadasOriginal.PesadasDetalles, new PesadasDetalle(Convert.ToInt32(IDDetalle.Value), Convert.ToInt32(ProductorIdcomboBox.Text),
                                              Convert.ToInt32(TipoArrozIdComboBox.Text), Convert.ToDecimal(KilosPesadosnumericUpDown.Value), Convert.ToDecimal(CantidadSaconumericUpDown.Value)));
            }
            Calculos();
            DetalledataGridView.DataSource = null;
            DetalledataGridView.DataSource = PesadasOriginal.PesadasDetalles;   
            EliminarDetalleButton.Enabled = true;
            KilosPesadosnumericUpDown.Value = 0;
            CantidadSaconumericUpDown.Value = 0;
        }
        private void DetalledataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FilaSeleccionada = e.RowIndex;
            EliminarDetalleButton.Enabled = true;
        }

        private void EliminarDetalleButton_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿Desea Eliminar El Detalle que ha seleccionado?",
                "AgroSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                if (FilaSeleccionada >= 0)
                {
                    Confirmar = true;
                    PesadasDetalle Detalle = PesadasOriginal.PesadasDetalles.ElementAt(FilaSeleccionada);
                    pesadasDetalles.Add(new PesadasDetalle(Detalle.PesadaDetalleID, Detalle.PesadasID, Detalle.TipoArrozID, Detalle.Kilos, Detalle.CantidadDeSacos));
                    PesadasOriginal.PesadasDetalles.RemoveAt(FilaSeleccionada);
                    DetalledataGridView.DataSource = null;
                    DetalledataGridView.DataSource = PesadasOriginal.PesadasDetalles;
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
        private void Calculos()
        {
            Decimal TotalKG = 0, totalsacos = 0;
            List<PesadasDetalle> Detalle = PesadasOriginal.PesadasDetalles;
            foreach (var item in Detalle)
            {
                TotalKG += item.Kilos;
                totalsacos += item.CantidadDeSacos;
            }
            decimal PrecionFanega = PrecioFaneganumericUpDown.Value;
            decimal Fanega = FaneganumericUpDown.Value;
            TotalKGTextBox.Text = TotalKG.ToString();
            TotalSacosTextBox.Text = totalsacos.ToString();
            decimal totalApagar = Math.Round((TotalKG - totalsacos) / Fanega, 2) * PrecionFanega;
            TotalAPagarTextBox.Text = totalApagar.ToString();
        }
        private void CargarGrid()
        {
            DetalledataGridView.DataSource = null;
            DetalledataGridView.DataSource = pesadasDetalles;
        }
        private void EliminarButton_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿Desea Eliminar?", "AgroSoft",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);  
            if (resultado.Equals(DialogResult.Yes))
            {
                PesadasBLL.ArreglarDetalle(PesadasBLL.Buscar(Convert.ToInt32(PesadaIDnumericUpDown.Value)));
                if (PesadasBLL.Eliminar(Convert.ToInt32(PesadaIDnumericUpDown.Value)))
                {
                    MessageBox.Show("Pesada Eliminada!!", "AgroSoft",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DetalledataGridView.DataSource = null;
                    LlenaComboBox();
                    Limpiar();
                }
                else
                    MessageBox.Show("Pesada No pudo Ser Eliminada!!", "AgroSoft",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Cargar()
        {
            ReportePesadaDetalles reporte = new ReportePesadaDetalles(pesadaImprimir, pesadaImprimir.PesadasDetalles, PesadasBLL.GetUsuario().Nombre);
            Application.Run(reporte);
        }
        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            try
            {
                Thread t = new Thread(Cargar);
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
            }
            catch(Exception)
            { throw; }
        }
        public void ActualizarInformacionComboBox(object sender,FormClosedEventArgs e)
        {
            LlenaComboBox();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            int.TryParse(PesadaIDnumericUpDown.Text, out int ID);
            Pesadas pesadas= PesadasBLL.Buscar(ID);
            if (pesadas != null)
            {
                errorProvider.Clear();
                LlenaCampo(pesadas);
            }
            else
                MessageBox.Show("Pesada no Encontrada!!", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void AgregarProductor_Click(object sender, EventArgs e)
        {
            RegistroProductores rProductores = new RegistroProductores();
            rProductores.FormClosed += new FormClosedEventHandler(ActualizarInformacionComboBox);
            rProductores.ShowDialog();
        }
        private void AgregarFactoria_Click(object sender, EventArgs e)
        {
            RegistroFactoria rFactoria = new RegistroFactoria();
            rFactoria.FormClosed += new FormClosedEventHandler(ActualizarInformacionComboBox);
            rFactoria.ShowDialog();
        }
        private void AgregarTipoArro_Click(object sender, EventArgs e)
        {
            RegistroTiposArroz rTipoArroz = new RegistroTiposArroz();
            rTipoArroz.FormClosed += new FormClosedEventHandler(ActualizarInformacionComboBox);
            rTipoArroz.Show();
        }

        private void IDDetalle_ValueChanged(object sender, EventArgs e)
        {
            if (IDDetalle.Value == 0)
                return;
            List<PesadasDetalle> lista = PesadasOriginal.PesadasDetalles;
            foreach(var item in lista)
            {
                if(lista.Exists(x=>x.PesadaDetalleID==(int)IDDetalle.Value))
                {
                    CantidadSaconumericUpDown.Value = item.CantidadDeSacos;
                    KilosPesadosnumericUpDown.Value = item.Kilos;
                }
                else
                {
                    MessageBox.Show("El ID del detalle introducido no existe, agregue el correcto o ponga valor 0", "AgroSoft",
                                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void DetalledataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
