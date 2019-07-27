using ProyectoFinal.BLL;
using ProyectoFinal.DAL;
using ProyectoFinal.Entidades;
using ProyectoFinal.UI.Consulta;
using ProyectoFinal.UI.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ProyectoFinal.UI.Registro
{
    public partial class RegistroDePesadas : Form,IRetorno<Productores>, IRetorno<Factoria>
    {
        public int FilaSeleccionada { get; set; }
        Pesadas PesadasOriginal = new Pesadas();
        List<PesadasDetalle> pesadasDetalles = new List<PesadasDetalle>();
        Pesadas pesadaImprimir;
        Thread t;
        Productores ProductoresGlobales { get; set; }
        Factoria FactoriaGlobales { get; set; }
        public RegistroDePesadas()
        {
            InitializeComponent();
            UsuarioTextBox.Text = PesadasBLL.GetUsuario().Nombre;
            LlenaComboBox();
            Limpiar();
        }
        private void LlenaComboBox()
        {     
            TipoArrozIdComboBox.DataSource = null;
            TipoArrozIdComboBox.DataSource = TipoArrozBLL.GetList(x => true);
            TipoArrozIdComboBox.ValueMember = "TipoArrozID";
            TipoArrozIdComboBox.DisplayMember = "Descripcion";
        }
        private void Limpiar()
        {
            LimpiarProvider();
            PesadaIDTextBox.Text = Convert.ToString(0);
            ProductorTextBox.Text = string.Empty;
            TipoArrozIdComboBox.Text = string.Empty;
            FactoriaTextBox.Text = string.Empty;
            CantidadSacosTextBox.Text = 0.ToString();
            KilosPesadosTextBox.Text = 0.ToString();
            SubTotalKGTextBox.Text = string.Empty;
            TotalSacosTextBox.Text = string.Empty;
            PrecioFanegaTextBox.Text = 0.ToString();
            FanegaTextBox.Text = 0.ToString();   
            TotalAPagarTextBox.Text = string.Empty;
            TotalKGTextBox.Text = string.Empty;
            NegaTextBox.Text = string.Empty;
            FechaRegistrodateTimePicker.Value = DateTime.Now;
            EliminarDetalleButton.Enabled = false;
            PesadasOriginal.PesadasDetalles = new List<PesadasDetalle>();
            pesadasDetalles = new List<PesadasDetalle>();
            DetalledataGridView.DataSource = null;
            LlenaComboBox();
            ImprimirButton.Visible = false;
            IDDetalle.Visible = false;
            ProductoresGlobales = new Productores();
            FactoriaGlobales = new Factoria();
            CargarGrid();
        }
        private Pesadas LlenaClase()
        {
            Pesadas pesad = new Pesadas
            {
                PesadaID = Convert.ToInt32(PesadaIDTextBox.Text),
                UsuarioID = PesadasBLL.GetUsuario().UsuarioID,
                FactoriaID = Convert.ToInt32(FactoriaGlobales.FactoriaID),
                ProductorID = Convert.ToInt32(ProductoresGlobales.ProductorID),
                TipoArrozID = Convert.ToInt32(TipoArrozIdComboBox.SelectedValue),
                Fanega = Convert.ToDecimal(FanegaTextBox.Text),
                PrecioFanega = Convert.ToDecimal(PrecioFanegaTextBox.Text),
                TotalKiloGramos = Convert.ToDecimal(TotalKGTextBox.Text),
                TotalSacos = Convert.ToDecimal(TotalSacosTextBox.Text),
                TotalPagar = Convert.ToDecimal(TotalAPagarTextBox.Text),
                FechaRegistro = FechaRegistrodateTimePicker.Value,
                PesadasDetalles = PesadasOriginal.PesadasDetalles
            };
            return pesad;
        }
        private PesadasDetalle LlenaClaseDetalle()
        {
            PesadasDetalle pDetalle = new PesadasDetalle
            {
                PesadasID = Convert.ToInt32(PesadaIDTextBox.Text),
                PesadaDetalleID = (int)IDDetalle.Value,
                Kilos = Convert.ToDecimal(KilosPesadosTextBox.Text),
                CantidadDeSacos = Convert.ToDecimal(CantidadSacosTextBox.Text),
                TipoArrozID = (int)TipoArrozIdComboBox.SelectedValue
            };
            return pDetalle;
        }
        private void LlenaCampo(Pesadas pesad)
        {
            LimpiarProvider();
            pesadaImprimir = new Pesadas();
            Pesadas pesadaAux = pesad;
            UsuarioTextBox.Text = PesadasBLL.GetUsuario().Nombre;
            FactoriaGlobales = FactoriaBLL.Buscar(pesadaAux.FactoriaID);
            FactoriaTextBox.Text = FactoriaGlobales.Nombre;
            ProductoresGlobales = ProductoresBLL.Buscar(pesadaAux.ProductorID);
            ProductorTextBox.Text = ProductoresGlobales.Nombre;
            FanegaTextBox.Text = pesadaAux.Fanega.ToString();
            PrecioFanegaTextBox.Text = pesadaAux.PrecioFanega.ToString();
            TotalSacosTextBox.Text = Convert.ToString(pesadaAux.TotalSacos);
            SubTotalKGTextBox.Text = Convert.ToString(pesadaAux.TotalKiloGramos);
            TotalKGTextBox.Text = Convert.ToString(pesadaAux.TotalPagar);
            FechaRegistrodateTimePicker.Value = pesadaAux.FechaRegistro;
            EliminarButton.Enabled = true;
            DetalledataGridView.DataSource = pesadaAux.PesadasDetalles;
            ImprimirButton.Visible = true;
            pesadasDetalles = new List<PesadasDetalle>();
            pesadaImprimir = pesadaAux;
            PesadasOriginal = pesadaAux;
            IDDetalle.Visible = true;
        }
        public void LimpiarProvider()
        {
            errorProvider.Clear();
        }
        public bool Validar()
        {
            LimpiarProvider();
            bool paso = true;
            if (ProductoresGlobales.ProductorID==0)
            {
                errorProvider.SetError(ProductorTextBox, "Debe Seleccionar o Crear un productor");
                paso = false;

            }
            if (TipoArrozIdComboBox.SelectedIndex<0)
            {
                errorProvider.SetError(TipoArrozIdComboBox, "Debe Seleccionar o Crear un TipoUsuario de Arroz");
                TipoArrozIdComboBox.Focus();
                paso = false;
            }
            if (FactoriaGlobales.FactoriaID==0 || FactoriaTextBox.Text.Equals(string.Empty))
            {
                errorProvider.SetError(FactoriaTextBox, "Debe Seleccionar o Crear una Factoria");
                paso = false;
            }
            return paso;
        }
        public bool ValidarDetalle()
        {
            LimpiarProvider();
            bool paso = true;
            if (Convert.ToDecimal(CantidadSacosTextBox.Text) <= 0)
            {
                errorProvider.SetError(CantidadSacosTextBox, "La Cantidad De Sacos Debe ser Mayor a 0");
                CantidadSacosTextBox.Focus();
                paso = false;
            }
            if (Convert.ToDecimal(KilosPesadosTextBox.Text)<= 0)
            {
                errorProvider.SetError(KilosPesadosTextBox, "La Cantidad De Kilos Debe ser Mayor a 0");
                KilosPesadosTextBox.Focus();
                paso = false;
            }
            if (Convert.ToDecimal(FanegaTextBox.Text) <= 0)
            {
                errorProvider.SetError(FanegaTextBox, "La Fanega Debe ser Mayor a 0");
                FanegaTextBox.Focus();
                paso = false;
            }
            if (Convert.ToDecimal(PrecioFanegaTextBox.Text) <= 0)
            {
                errorProvider.SetError(PrecioFanegaTextBox, "El Precio de la Fanega Debe ser Mayor a 0");
                PrecioFanegaTextBox.Focus();
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
            if (PesadaIDTextBox.Text.Equals("0"))
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
                var resultado = MessageBox.Show("Va a modificar algo, ¿Seguro que desea Hacerlo?", "AgroSoft",
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
        private void DetalledataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FilaSeleccionada = e.RowIndex;
            EliminarDetalleButton.Enabled = true;
        }
        private void AgregarButton_Click(object sender, EventArgs e)
        {
            if (!ValidarDetalle())
                return;
            PesadasDetalle pDetalle = new PesadasDetalle();
            pDetalle = LlenaClaseDetalle();
            IDDetalle.Visible = true;
            if (IDDetalle.Value == 0)
                PesadasOriginal.PesadasDetalles.Add(pDetalle);
            else
            {
                int pesadaId = Convert.ToInt32(PesadaIDTextBox.Text);
                if (PesadasOriginal.PesadasDetalles.Count == 0)
                {
                    PesadasOriginal.PesadasDetalles = PesadaDetalleBLL.GetList(x => x.PesadasID == pesadaId);
                }
                int index = PesadasOriginal.PesadasDetalles.FindIndex(x=>x.PesadaDetalleID==(int)IDDetalle.Value);
                PesadasDetalle Details = PesadaDetalleBLL.BuscarElemento(PesadasOriginal.PesadasDetalles,pDetalle, (int)IDDetalle.Value);
                PesadasOriginal.PesadasDetalles.RemoveAt(index);
                CargarGrid();
                PesadasOriginal.PesadasDetalles.Add(Details);               
            }
            Calculos();
            DetalledataGridView.DataSource = null;
            DetalledataGridView.DataSource = PesadasOriginal.PesadasDetalles;
            EliminarDetalleButton.Enabled = true;
            KilosPesadosTextBox.Text = 0.ToString();
            CantidadSacosTextBox.Text = Convert.ToString("0");
        }
        private void EliminarDetalleButton_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿Desea Eliminar El Detalle que ha seleccionado?",
                "AgroSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                if (FilaSeleccionada >= 0)
                {
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
        private void EliminarButton_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿Desea Eliminar?", "AgroSoft",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado.Equals(DialogResult.Yes))
            {
                PesadasBLL.ArreglarDetalle(PesadasBLL.Buscar(Convert.ToInt32(PesadaIDTextBox.Text)));
                if (PesadasBLL.Eliminar(Convert.ToInt32(PesadaIDTextBox.Text)))
                {
                    MessageBox.Show("Pesada Eliminada!!", "AgroSoft",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DetalledataGridView.DataSource = null;
                    LlenaComboBox();
                    Limpiar();
                }
                else
                    MessageBox.Show("Pesada No pudo Ser Eliminada!!", "AgroSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            decimal PrecionFanega = Convert.ToDecimal(PrecioFanegaTextBox.Text);
            decimal Fanega = Convert.ToDecimal(FanegaTextBox.Text);
            if (Fanega == 0)
                return;
            decimal Nega = ((TotalKG - totalsacos) / Fanega);
            decimal Truncado = Constantes.Truncate(Nega, 2);
            decimal totalApagar = Truncado * PrecionFanega;
            SubTotalKGTextBox.Text = TotalKG.ToString();
            TotalSacosTextBox.Text = totalsacos.ToString();
            TotalKGTextBox.Text = (TotalKG - totalsacos).ToString();
            NegaTextBox.Text = Truncado.ToString();
            TotalAPagarTextBox.Text = Constantes.Truncate(totalApagar, 2).ToString();
        }
        private void CargarGrid()
        {
            DetalledataGridView.DataSource = null;
            DetalledataGridView.DataSource = pesadasDetalles;
            
            DetalledataGridView.Columns[0].Name= "ID";
            DetalledataGridView.Columns[1].Visible = false;
        }
        private void Cargar()
        {
            ReportePesadaDetalles reporte = new ReportePesadaDetalles(pesadaImprimir, pesadaImprimir.PesadasDetalles, PesadasBLL.GetUsuario().Nombre);
            reporte.ShowDialog();
        }
        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            t = new Thread(Cargar);
            try
            {             
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
            }
            catch(Exception)
            { throw; }
            finally
            { 
               
            }
        }
        public void ActualizarInformacionComboBox(object sender,FormClosedEventArgs e)
        {
            LlenaComboBox();
        }
        private void BuscarPesadas_Click(object sender, EventArgs e)
        {
            LimpiarProvider();
            int.TryParse(PesadaIDTextBox.Text, out int ID);
            Pesadas pesadas = PesadasBLL.Buscar(ID);
            if (pesadas != null)
            {
                              LimpiarProvider();
                LlenaCampo(pesadas);
            }
            else
                MessageBox.Show("Pesada no Encontrada!!", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Calculos();
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
            LimpiarProvider();
            if (IDDetalle.Value == 0)
            {
                AgregarButton.Enabled = true;
                return;
            }
            CantidadSacosTextBox.Text = Convert.ToString("0");
            KilosPesadosTextBox.Text = 0.ToString();
            List<PesadasDetalle> lista = PesadasOriginal.PesadasDetalles;
            if (lista.Exists(x => x.PesadaDetalleID == (int)IDDetalle.Value))
            {
                foreach (var item in lista)
                {
                    if (item.PesadaDetalleID == (int)IDDetalle.Value)
                    {
                        CantidadSacosTextBox.Text = Convert.ToInt32(item.CantidadDeSacos).ToString();
                        KilosPesadosTextBox.Text = Convert.ToInt32(item.Kilos).ToString();
                        AgregarButton.Enabled = true;
                        TipoArrozIdComboBox.SelectedIndex = item.TipoArrozID-1;
                        return;
                    }
                }
            }
            else
            {
                AgregarButton.Enabled = false;
                errorProvider.SetError(IDDetalle, "El ID que ingreso no existe, introduzca un valor correto");
            }
        }
        private void BuscarProductor_Click(object sender, EventArgs e)
        {
            var cmd = new CallerMemberName();
            cmd.UsingCallerMemberName();
            ConsultaProductores.Llamado = cmd.Nombre;
            ConsultaProductores CProductores = new ConsultaProductores
            {
                PContrato = this
            };
            CProductores.ShowDialog();
        }
        private void BuscarFactoria_Click(object sender, EventArgs e)
        {
            var cmd = new CallerMemberName();
            cmd.UsingCallerMemberName();
            ConsultaDeFactorias.Llamado = cmd.Nombre;
            ConsultaDeFactorias CFactorias = new ConsultaDeFactorias
            {
                FFactoria = this
            };
            CFactorias.ShowDialog();
        }
        public void Ejecutar(Productores template)
        {
            if(template.ProductorID==0)
                return;
            ProductoresGlobales = GetProductores(template.ProductorID);
            ProductorTextBox.Text = ProductoresGlobales.Nombre;
        }
        public Productores GetProductores(int ID)
        {
            Productores productores = ProductoresBLL.Buscar(ID);
            return productores;
        }
        public Factoria GetFactorias(int ID)
        {
            Factoria factoria = FactoriaBLL.Buscar(ID);
            return factoria;
        }
        public void Ejecutar(Factoria template)
        {
            if (template.FactoriaID == 0)
                return;
            FactoriaGlobales = GetFactorias(template.FactoriaID);
            FactoriaTextBox.Text = FactoriaGlobales.Nombre;
        }
        private void DetalledataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.RowIndex > -1))
                return;
            int index = e.RowIndex;
            DataGridViewRow row = DetalledataGridView.Rows[index];
            PesadasDetalle p = new PesadasDetalle
            {
                PesadaDetalleID = Convert.ToInt32(row.Cells[0].Value),
                PesadasID = Convert.ToInt32(row.Cells[1].Value),
                TipoArrozID = Convert.ToInt32(row.Cells[2].Value),
                Kilos = Convert.ToDecimal(row.Cells[3].Value),
                CantidadDeSacos = Convert.ToDecimal(row.Cells[4].Value)
            };
            LlenaCampoDetalle(p);
        }
        private void LlenaCampoDetalle(PesadasDetalle pesadasDetalle)
        {
            CantidadSacosTextBox.Text = pesadasDetalle.CantidadDeSacos.ToString();
            KilosPesadosTextBox.Text = pesadasDetalle.Kilos.ToString();
            IDDetalle.Value = (int)pesadasDetalle.PesadaDetalleID;
            TipoArroz tipo = TipoArrozBLL.Buscar(pesadasDetalle.TipoArrozID);
            int index = 0;
            for(int i=0;i<TipoArrozIdComboBox.Items.Count;i++)
            {
                if (tipo.Descripcion.Equals(TipoArrozIdComboBox.Text))
                {
                    index = TipoArrozIdComboBox.SelectedIndex;
                    break;
                }     
            }
            TipoArrozIdComboBox.SelectedIndex = index;
        }
        private void PesadaIDTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Constantes.ValidarSoloNumeros(sender, e);
            if ((int)e.KeyChar == (int)Keys.Enter)
                BuscarPesadas_Click(sender,e);
            
        }
        private void CantidadSacosTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Constantes.ValidarNumerosDecimales(sender, e, CantidadSacosTextBox.Text);
        }
        private void FanegaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Constantes.ValidarNumerosDecimales(sender, e, FanegaTextBox.Text);
        }
        private void KilosPesadosTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Constantes.ValidarNumerosDecimales(sender, e, KilosPesadosTextBox.Text);
        }
        private void PrecioFanegaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Constantes.ValidarNumerosDecimales(sender, e, PrecioFanegaTextBox.Text);
        }
        private void PesadaIDTextBox_TextChanged(object sender, EventArgs e)
        {
            if (PesadaIDTextBox.Text.Equals(string.Empty)) 
                     return;
            if (Convert.ToInt32(PesadaIDTextBox.Text) == 0)
                ImprimirButton.Visible = false;
        }
        private void ProductorTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ProductorTextBox.Text != string.Empty)
                LimpiarProvider();
        }
        private void FactoriaTextBox_TextChanged(object sender, EventArgs e)
        {
            if (FactoriaTextBox.Text != string.Empty)
                LimpiarProvider();
        }
    }
}
