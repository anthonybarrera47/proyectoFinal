using BLL;
using DAL;
using Entidades;
using ProyectoFinal.UI.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace ProyectoFinal.UI.Consulta
{
    public partial class ConsultaTipoArroz : Form
    {
        public static string Llamado;
        Expression<Func<TipoArroz, bool>> filtro = x => true;
        List<TipoArroz> ListaArroz;
        public IRetorno<TipoArroz> TContrato { get; set; }
        public ConsultaTipoArroz()
        {
            InitializeComponent();
            ComprobarLlamado();
            FiltrocomboBox.SelectedIndex = 0;
            DesdedateTimePicker.Enabled = false;
            HastadateTimePicker.Enabled = false;
            Seleccion();
        }  
        private void ComprobarLlamado()
        {
            if (Llamado == null)
                return;
            if (Llamado.Equals("BuscarButton_Click"))
            {
                ImprimirButton.Visible = false;
                TipodataGridView.CellDoubleClick += TipodataGridView_CellContentDoubleClick;
            }          
            if (Llamado.Equals("ConsultaTipoArrozToolStripMenuItem_Click"))
                ImprimirButton.Visible = true;
        }
        private void Seleccion()
        {
            errorProvider.Clear();
            ListaArroz = new List<TipoArroz>();
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
                        int id = Convert.ToInt32(CriteriotextBox.Text);
                        filtro = x => x.TipoArrozID == id;
                        break;
                    case 2:
                        if (!Validar())
                            return;
                        filtro = x => x.Descripcion.Contains(CriteriotextBox.Text);
                        break;
                    case 3:
                        if (!Validar())
                            return;
                        decimal kilos = Convert.ToDecimal(CriteriotextBox.Text);
                        filtro = x => x.Kilos==kilos;
                        break;
                }  
            }
            if (FiltracheckBox.Checked == true)
                ListaArroz = TipoArrozBLL.GetList(filtro).Where(x => x.FechaRegistro.Date >= DesdedateTimePicker.Value.Date && x.FechaRegistro.Date <= HastadateTimePicker.Value.Date).ToList();
            else
                ListaArroz = TipoArrozBLL.GetList(filtro);
            CargarGrid(ListaArroz);
        }
        private void CargarGrid(List<TipoArroz> lista)
        {
            TipodataGridView.DataSource = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("TipoArrozID", typeof(int));
            dt.Columns.Add("Descripcion", typeof(string));
            dt.Columns.Add("Kilos", typeof(decimal));
            dt.Columns.Add("Fecha de registro", typeof(DateTime));
            foreach(var item in lista)
            {
                dt.Rows.Add(item.TipoArrozID, item.Descripcion, item.Kilos, item.FechaRegistro);
            }
            TipodataGridView.DataSource = dt;
            TotalTextBox.Text = lista.Count.ToString();
            decimal suma = 0;
            foreach(var item in lista)
            {
                suma += item.Kilos;
            }
            TotalKGTextBox.Text = suma.ToString();
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
            if (FiltrocomboBox.SelectedIndex == 1)
            {
                Constantes.ValidarSoloNumeros(sender, e);
                CriteriotextBox.MaxLength = 9;
            }
            
        }
        //Avisamosa al usuario de algun error en la consulta por fechas
        private void HastadateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (DesdedateTimePicker.Value.Date > HastadateTimePicker.Value.Date)
                errorProvider.SetError(HastadateTimePicker, "La FechaRegistro del campo Desde no puede ser mayor que la del Campo Hasta");
            else
                errorProvider.Clear();
        }
        private void ImprimirButton_Click_1(object sender, EventArgs e)
        {
            ReportesDeTipoArroz reporte = new ReportesDeTipoArroz(ListaArroz);     
            reporte.Show();
        }
        private void FiltrocomboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CriteriotextBox.Text = string.Empty;
        }
        private void FiltracheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(FiltracheckBox.Checked==true)
            {
                DesdedateTimePicker.Enabled = true;
                HastadateTimePicker.Enabled = true;
            }
            else
            {
                DesdedateTimePicker.Enabled = false;
                HastadateTimePicker.Enabled = false;
            }
        }
        private void TipodataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.RowIndex > -1))
                return;
            int index = e.RowIndex;
            DataGridViewRow row = TipodataGridView.Rows[index];
            TipoArroz tipoArroz = new TipoArroz
            {
                TipoArrozID = (row.Cells[0].Value).ToInt(),
            };
            TContrato.Ejecutar(tipoArroz);
            this.Close();
        }

        private void ConsultaTipoArroz_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
