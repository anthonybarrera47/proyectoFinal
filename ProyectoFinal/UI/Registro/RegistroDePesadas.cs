using BLL;
using DAL;
using Entidades;
using ProyectoFinal.UI.Consulta;
using ProyectoFinal.UI.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;


namespace ProyectoFinal.UI.Registro
{
    public partial class RegistroDePesadas : Form, IRetorno<Productores>, IRetorno<Factoria>
    {
        public int FilaSeleccionada { get; set; }
        Pesadas PesadasOriginal = new Pesadas();
        List<PesadasDetalle> pesadasDetalles = new List<PesadasDetalle>();
        
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
            LlenaComboBox();
            ImprimirButton.Visible = false;
            IDDetalle.Visible = false;
            ProductoresGlobales = new Productores();
            FactoriaGlobales = new Factoria();
            CargarGrid(pesadasDetalles);
        }
        private Pesadas LlenaClase()
        {
            Pesadas pesad = new Pesadas
            {
                PesadaID = (PesadaIDTextBox.Text).ToInt(),
                UsuarioID = PesadasBLL.GetUsuario().UsuarioID,
                FactoriaID = (FactoriaGlobales.FactoriaID).ToInt(),
                ProductorID = (ProductoresGlobales.ProductorID).ToInt(), 
                Fanega = (FanegaTextBox.Text).ToDecimal(),
                PrecioFanega = (PrecioFanegaTextBox.Text).ToDecimal(),
                TotalKiloGramos = (TotalKGTextBox.Text).ToDecimal(),
                TotalSacos = (TotalSacosTextBox.Text).ToDecimal(),
                TotalPagar = (TotalAPagarTextBox.Text).ToDecimal(),
                FechaRegistro = FechaRegistrodateTimePicker.Value,
                PesadasDetalles = PesadasOriginal.PesadasDetalles
            };
            return pesad;
        }
        private PesadasDetalle LlenaClaseDetalle()
        {
            PesadasDetalle pDetalle = new PesadasDetalle
            {
                PesadasID = (PesadaIDTextBox.Text).ToInt(),
                PesadaDetalleID =IDDetalle.Value.ToInt(),
                Kilos = (KilosPesadosTextBox.Text).ToDecimal(),
                CantidadDeSacos = (CantidadSacosTextBox.Text).ToDecimal(),
                TipoArrozID = TipoArrozIdComboBox.SelectedValue.ToInt()
            };
            return pDetalle;
        }
        private void LlenaCampo(Pesadas pesad)
        {
            LimpiarProvider();
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
            CargarGrid(pesadaAux.PesadasDetalles);
            ImprimirButton.Visible = true;
            pesadasDetalles = new List<PesadasDetalle>();
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
            if (ProductoresGlobales.ProductorID == 0)
            {
                errorProvider.SetError(ProductorTextBox, "Debe Seleccionar o Crear un productor");
                paso = false;

            }
            if (TipoArrozIdComboBox.SelectedIndex < 0)
            {
                errorProvider.SetError(TipoArrozIdComboBox, "Debe Seleccionar o Crear un TipoUsuario de Arroz");
                TipoArrozIdComboBox.Focus();
                paso = false;
            }
            if (FactoriaGlobales.FactoriaID == 0 || FactoriaTextBox.Text.Equals(string.Empty))
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
            if ((CantidadSacosTextBox.Text).ToDecimal() <= 0)
            {
                errorProvider.SetError(CantidadSacosTextBox, "La Cantidad De Sacos Debe ser Mayor a 0");
                CantidadSacosTextBox.Focus();
                paso = false;
            }
            if ((KilosPesadosTextBox.Text).ToDecimal() <= 0)
            {
                errorProvider.SetError(KilosPesadosTextBox, "La Cantidad De Kilos Debe ser Mayor a 0");
                KilosPesadosTextBox.Focus();
                paso = false;
            }
            if ((FanegaTextBox.Text).ToDecimal() <= 0)
            {
                errorProvider.SetError(FanegaTextBox, "La Fanega Debe ser Mayor a 0");
                FanegaTextBox.Focus();
                paso = false;
            }
            if ((PrecioFanegaTextBox.Text).ToDecimal() <= 0)
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
                        ReportePesadaDetalles reporte = new ReportePesadaDetalles(pesad, pesad.PesadasDetalles, PesadasBLL.GetUsuario().Nombre);
                        reporte.Show();
                        reporte.Dispose();
                    }
                    Limpiar();
                }
                else
                    MessageBox.Show("No Se Guardo Su Pesada!!", "AgroSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("Pesada No Existente!!", "AgroSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
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
                            ReportePesadaDetalles reporte = new ReportePesadaDetalles(pesad, pesad.PesadasDetalles, PesadasBLL.GetUsuario().Nombre);
                            reporte.Show();
                            reporte.Dispose();
                        }
                        Limpiar();
                    }
                    else
                        MessageBox.Show("No Se pudo Modificar Su Pesada!!", "AgroSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            return (FactoriaBLL.Buscar(PesadaIDTextBox.Text.ToInt())!=null);
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
                int pesadaId = (PesadaIDTextBox.Text).ToInt();
                if (PesadasOriginal.PesadasDetalles.Count == 0)
                {
                    PesadasOriginal.PesadasDetalles = PesadaDetalleBLL.GetList(x => x.PesadasID == pesadaId);
                }
                int index = PesadasOriginal.PesadasDetalles.FindIndex(x => x.PesadaDetalleID == (int)IDDetalle.Value);
                PesadasDetalle Details = PesadaDetalleBLL.BuscarElemento(PesadasOriginal.PesadasDetalles, pDetalle, (int)IDDetalle.Value);
                PesadasOriginal.PesadasDetalles.RemoveAt(index);
                CargarGrid(pesadasDetalles);
                PesadasOriginal.PesadasDetalles.Add(Details);
            }
            Calculos();

            CargarGrid(PesadasOriginal.PesadasDetalles);
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
                    CargarGrid(PesadasOriginal.PesadasDetalles);
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
                PesadasBLL.ArreglarDetalle(PesadasBLL.Buscar((PesadaIDTextBox.Text).ToInt()));
                if (PesadasBLL.Eliminar((PesadaIDTextBox.Text).ToInt()))
                {
                    MessageBox.Show("Pesada Eliminada!!", "AgroSoft",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            decimal PrecionFanega = (PrecioFanegaTextBox.Text).ToDecimal();
            decimal Fanega = (FanegaTextBox.Text).ToDecimal();
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

        private void Cargar()
        {
            Pesadas pesadas = PesadasBLL.Buscar(PesadaIDTextBox.Text.ToInt());new Pesadas();
            ReportePesadaDetalles reporte = new ReportePesadaDetalles(pesadas, pesadas.PesadasDetalles, PesadasBLL.GetUsuario().Nombre);
            reporte.ShowDialog();
            reporte.Dispose();
        }
        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            t = new Thread(Cargar);
            try
            {
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
            }
            catch (Exception)
            { throw; }
            finally
            {}
        }
        public void ActualizarInformacionComboBox(object sender, FormClosedEventArgs e)
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
            rProductores.Dispose();
        }
        private void AgregarFactoria_Click(object sender, EventArgs e)
        {
            RegistroFactoria rFactoria = new RegistroFactoria();
            rFactoria.FormClosed += new FormClosedEventHandler(ActualizarInformacionComboBox);
            rFactoria.ShowDialog();
            rFactoria.Dispose();
        }
        private void AgregarTipoArro_Click(object sender, EventArgs e)
        {
            RegistroTiposArroz rTipoArroz = new RegistroTiposArroz();
            rTipoArroz.FormClosed += new FormClosedEventHandler(ActualizarInformacionComboBox);
            rTipoArroz.ShowDialog();
            rTipoArroz.Dispose();
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
            if (lista.Exists(x => x.PesadaDetalleID == IDDetalle.Value.ToInt()))
            {
                foreach (var item in lista)
                {
                    if (item.PesadaDetalleID == (int)IDDetalle.Value)
                    {
                        CantidadSacosTextBox.Text = (item.CantidadDeSacos).ToInt().ToString();
                        KilosPesadosTextBox.Text = (item.Kilos).ToInt().ToString();
                        AgregarButton.Enabled = true;
                        TipoArrozIdComboBox.SelectedValue = TipoArrozIdComboBox.Items.IndexOf(TipoArrozBLL.Buscar(item.TipoArrozID).Descripcion);
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
            CProductores.Dispose();
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
            CFactorias.Dispose();
        }
        public void Ejecutar(Productores template)
        {
            if (template.ProductorID == 0)
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
                PesadaDetalleID = (row.Cells["Id Detalle"].Value).ToInt(),
                PesadasID = (row.Cells["PesadasID"].Value).ToInt(),
                TipoArrozID = (row.Cells["TipoArrozID"].Value).ToInt(),
                Kilos = (row.Cells["Kilos"].Value).ToDecimal(),
                CantidadDeSacos = (row.Cells["Cantidad de sacos"].Value).ToDecimal()
            };
            LlenaCampoDetalle(p);
        }
        private void CargarGrid(List<PesadasDetalle> Details)
        {
            DetalledataGridView.DataSource = null;
            /*DetalledataGridView.DataSource = Details;
            this.DetalledataGridView.Columns["PesadasID"].Visible = false;
            this.DetalledataGridView.Columns["TipoArrozID"].Visible = false; */
            DataTable dt = new DataTable();
            dt.Columns.Add("PesadasID", typeof(int));
            dt.Columns.Add("Id Detalle", typeof(int));
            dt.Columns.Add("Cantidad de sacos", typeof(decimal));
            dt.Columns.Add("Kilos", typeof(decimal));
            dt.Columns.Add("TipoArrozID", typeof(int));
            dt.Columns.Add("Tipo de arroz", typeof(string));
            foreach (var item in Details)
            {
                dt.Rows.Add(item.PesadasID, item.PesadaDetalleID, item.CantidadDeSacos, item.Kilos, item.TipoArrozID, TipoArrozBLL.Buscar(item.TipoArrozID).Descripcion);
            }
            DetalledataGridView.DataSource = dt;
            this.DetalledataGridView.Columns["PesadasID"].Visible = false;
            this.DetalledataGridView.Columns["TipoArrozID"].Visible = false;
        }
        private void LlenaCampoDetalle(PesadasDetalle pesadasDetalle)
        {
            CantidadSacosTextBox.Text = pesadasDetalle.CantidadDeSacos.ToString();
            KilosPesadosTextBox.Text = pesadasDetalle.Kilos.ToString();
            IDDetalle.Value = pesadasDetalle.PesadaDetalleID.ToInt();
            TipoArroz tipo = TipoArrozBLL.Buscar(pesadasDetalle.TipoArrozID);
            TipoArrozIdComboBox.SelectedValue = tipo.TipoArrozID; 
        }
        private void PesadaIDTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Constantes.ValidarSoloNumeros(sender, e);
            if ((int)e.KeyChar == (int)Keys.Enter)
                BuscarPesadas_Click(sender, e);
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
            if ((PesadaIDTextBox.Text).ToInt() == 0)
                ImprimirButton.Visible = false;
            else if ((PesadasBLL.Buscar((PesadaIDTextBox.Text).ToInt()) == null))
                ImprimirButton.Visible = false;
            else
                ImprimirButton.Visible = true;
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