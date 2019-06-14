using ProyectoFinal.BLL;
using ProyectoFinal.DAL;
using ProyectoFinal.Entidades;
using ProyectoFinal.UI.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;

using System.Windows.Forms;

namespace ProyectoFinal.UI.Consulta
{
    public partial class ConsultaDePesadas : Form
    {
        public ConsultaDePesadas()
        {
            InitializeComponent();
            FiltrocomboBox.SelectedIndex = 0;
            DesdedateTimePicker.Enabled = false;
            HastadateTimePicker1.Enabled = false;
        }
        List<Pesadas> ListaPesadas;
        Expression<Func<Pesadas, bool>> filtro = x => true;
        private void Seleccion()
        {
            errorProvider.Clear();
            ListaPesadas = new List<Pesadas>();
            int ID = Convert.ToInt32(CriteriotextBox.Text);
            decimal decimales = Convert.ToDecimal(CriteriotextBox.Text);
            if (CriteriotextBox.Text.Trim().Length >= 0)
            {
                switch (FiltrocomboBox.SelectedIndex)
                {
                    case 0: //Todo
                        //lista = ProductoresBLL.GetList(x => true);
                        filtro = x => true;
                        break;
                    case 1:
                        if (!Validar())
                            return;
                        filtro = x => x.PesadasID == ID;
                        break;
                    case 2:
                        if (!Validar())
                            return;
                        filtro = x => x.ProductorID == ID;
                        break;
                    case 3://Direccion
                        if (!Validar())
                            return;
                        filtro = x => x.TipoArrozID == ID;
                        break;
                    case 4://Telefono
                        if (!Validar())
                            return;    
                        filtro = x => x.FactoriaID == ID;
                        break;
                    case 5:
                        if (!Validar())
                            return;
                        filtro = x => x.UsuarioID == ID;
                        break;
                    case 6:
                        if (!Validar())
                            return;
                        filtro = x => x.Fanega == decimales;
                        break;
                    case 7:
                        if (!Validar())
                            return;
                        filtro = x => x.PrecioFanega == decimales;
                        break;
                    case 8:
                        if (!Validar())
                            return;
                        filtro = x => x.TotalKiloGramos == decimales;
                        break;
                    case 9:
                        if (!Validar())
                            return;
                        filtro = x => x.TotalSacos == decimales;
                        break;
                }
            }
            if (FiltracheckBox.Checked == true)
            {
                ListaPesadas = PesadasBLL.GetList(filtro).Where(x => x.FechaRegistro.Date >= DesdedateTimePicker.Value.Date && x.FechaRegistro.Date <= HastadateTimePicker1.Value.Date).ToList();
                FactoriasdataGridView.DataSource = null;
                FactoriasdataGridView.DataSource = ListaPesadas;
            }
            else
            {
                ListaPesadas = PesadasBLL.GetList(filtro);
                FactoriasdataGridView.DataSource = null;
                FactoriasdataGridView.DataSource = ListaPesadas;
            }
        }

        private bool Validar()
        {
            bool paso = true;
            if (CriteriotextBox.Text.FirstOrDefault() == '.')
                paso = false;
            if (String.IsNullOrWhiteSpace(CriteriotextBox.Text))
            {
                errorProvider.SetError(CriteriotextBox, "Debe poner Informacion en el campo");
                paso = false;
            }
            return paso;
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Seleccion();
        }

        private void CriteriotextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
                Seleccion();

            if (FiltrocomboBox.SelectedIndex == 1 || FiltrocomboBox.SelectedIndex == 2 || FiltrocomboBox.SelectedIndex == 3 || FiltrocomboBox.SelectedIndex == 4 || FiltrocomboBox.SelectedIndex == 5)
            {

                Constantes.ValidarSoloNumeros(sender, e);
                CriteriotextBox.MaxLength = 9;
            }
            if (FiltrocomboBox.SelectedIndex == 6 || FiltrocomboBox.SelectedIndex == 7 || FiltrocomboBox.SelectedIndex == 8 ||FiltrocomboBox.SelectedIndex == 9)
            {
                Constantes.ValidarNumerosDecimales(sender, e, CriteriotextBox.Text);
                CriteriotextBox.MaxLength = 20;
            }

        }
        //Avisamosa al usuario de algun error en la consulta por fechas
        private void ValidarFecha()
        {
            if (DesdedateTimePicker.Value.Date > HastadateTimePicker1.Value.Date)
                errorProvider.SetError(HastadateTimePicker1, "La Fecha del campo Desde no puede ser mayor que la del Campo Hasta");
            else
                errorProvider.Clear();
            if (HastadateTimePicker1.Value.Date < DesdedateTimePicker.Value.Date)
                errorProvider.SetError(DesdedateTimePicker, "La Fecha del campo Desde no puede ser mayor que la del Campo Hasta");
            else
                errorProvider.Clear();
        }


        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            ReporteDePesadas reporte = new ReporteDePesadas(ListaPesadas);
            reporte.Show();
        }

        private void FiltrocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CriteriotextBox.Text = string.Empty;
        }
        private void DesdedateTimePicker_ValueChanged_1(object sender, EventArgs e)
        {
            ValidarFecha();
        }

        private void HastadateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            ValidarFecha();
        }

        private void FiltracheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (FiltracheckBox.Checked == true)
            {
                DesdedateTimePicker.Enabled = true;
                HastadateTimePicker1.Enabled = true;
            }
            else
            {
                DesdedateTimePicker.Enabled = false;
                HastadateTimePicker1.Enabled = false;
            }
        }
    }
}
