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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.UI.Consulta
{
    public partial class ConsultaDeFactorias : Form
    {
        List<Factoria> ListaFactorias;
        public static String Llamado = string.Empty;
        public IRetorno<Factoria> FFactoria { get; set; }
        Expression<Func<Factoria, bool>> filtro = x => true;
        public ConsultaDeFactorias()
        {    
            InitializeComponent();
            FiltrocomboBox.SelectedIndex = 0;
            DesdedateTimePicker.Enabled = false;
            HastadateTimePicker1.Enabled = false;
            ComprobarLlamado();
            CargarGrid(FactoriaBLL.GetList(x => true));
            CriteriotextBox.Focus();
        }
        public void ComprobarLlamado()
        {
            if (Llamado == null)
                return; 
            if (Llamado.Equals("BuscarFactoria_Click")|| Llamado.Equals("BuscarButton_Click"))
            {
                ImprimirButton.Visible = false;
                FactoriasdataGridView.CellDoubleClick += DataGridView_CellDoubleClick;       
            }
            if(Llamado.Equals("ConsultaFactoriasToolStripMenuItem_Click"))
                ImprimirButton.Visible = true;
        }
       
        private void Seleccion()
        {
            errorProvider.Clear();
            ListaFactorias = new List<Factoria>();
            if (CriteriotextBox.Text.Trim().Length >= 0)
            {
                switch (FiltrocomboBox.SelectedIndex)
                {
                    case 0: //Todo
                        filtro = x => true;
                        break;
                    case 1://ID
                        if (!Validar())
                            return;
                        int.TryParse(CriteriotextBox.Text, out int ID);
                        filtro = x => x.FactoriaID == ID;
                        break;
                    case 2://Nombre
                        if (!Validar())
                            return;
                        filtro = x => x.Nombre.Contains(CriteriotextBox.Text);
                        break;
                    case 3://Direccion
                        if (!Validar())
                            return;
                        filtro = x => x.Direccion.Contains(CriteriotextBox.Text);
                        break;
                    case 4://Telefono
                        if (!Validar())
                            return;
                        filtro = x => x.Telefono.Contains(CriteriotextBox.Text);
                        break;
                }
            }
            if (FiltracheckBox.Checked == true)
                 ListaFactorias = FactoriaBLL.GetList(filtro).Where(x => x.FechaRegistro.Date >= DesdedateTimePicker.Value.Date && x.FechaRegistro.Date <= HastadateTimePicker1.Value.Date).ToList();            
            else
                ListaFactorias = FactoriaBLL.GetList(filtro);
            CargarGrid(ListaFactorias);
        }
        private void CargarGrid(List<Factoria> lista)
        {
            FactoriasdataGridView.DataSource = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Direccion", typeof(string));
            dt.Columns.Add("Telefono", typeof(string));
            dt.Columns.Add("FechaRegistro", typeof(DateTime));
            foreach(var item in lista)
            {
                dt.Rows.Add(item.FactoriaID, item.Nombre, item.Direccion, item.Telefono, item.FechaRegistro);
            }
            FactoriasdataGridView.DataSource = dt;
            TotalTextBox.Text = lista.Count.ToString();
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
        private void BuscarButton_Click_1(object sender, EventArgs e)
        {
            Seleccion();
        }
        private void CriteriotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
                Seleccion();
            if (FiltrocomboBox.SelectedIndex == 1)
                Constantes.ValidarSoloNumeros(sender, e);

        }
        //Avisamosa al usuario de algun error en la consulta por fechas
        private void ValidarFecha()
        {
            if (DesdedateTimePicker.Value.Date > HastadateTimePicker1.Value.Date)
                errorProvider.SetError(HastadateTimePicker1, "La FechaRegistro del campo Desde no puede ser mayor que la del Campo Hasta");
            else 
                errorProvider.Clear();
            if (HastadateTimePicker1.Value.Date < DesdedateTimePicker.Value.Date)
                errorProvider.SetError(DesdedateTimePicker, "La FechaRegistro del campo Desde no puede ser mayor que la del Campo Hasta");
            else
                errorProvider.Clear();
        }
        private void ImprimirButton_Click_1(object sender, EventArgs e)
        {
            ReportesDeFactoria reporte = new ReportesDeFactoria(ListaFactorias);
            reporte.Show();
            reporte.Dispose();
        }
        private void FiltrocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FactoriasdataGridView.DataSource = null;
            CriteriotextBox.Text = string.Empty;
            if (FiltrocomboBox.SelectedIndex == 1)
            {
                CriteriotextBox.Focus();
                CriteriotextBox.MaxLength = 9;
            }
            if (FiltrocomboBox.SelectedIndex == 4)
            {
                CriteriotextBox.Focus();
                CriteriotextBox.MaxLength = 12;
            }
        }
        private void FiltracheckBox_CheckedChanged_1(object sender, EventArgs e)
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
        private void DesdedateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            ValidarFecha();
        }
        private void HastadateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ValidarFecha();
        }
        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.RowIndex > -1))
                return;
            int index = e.RowIndex;
            DataGridViewRow row = FactoriasdataGridView.Rows[index];
            if (row.Cells[0].Value== null)
                return;
            int ID = Convert.ToInt32(row.Cells[0].Value);
            Factoria p = new Factoria
            {
                FactoriaID = ID
            };
            
            FFactoria.Ejecutar(p);
            this.Close();
        }
        private void CriteriotextBox_TextChanged(object sender, EventArgs e)
        {
            Seleccion();
        }
    }
}
