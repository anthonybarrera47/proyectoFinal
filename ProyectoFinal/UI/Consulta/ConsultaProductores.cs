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
    public partial class ConsultaProductores : Form
    {
        Expression<Func<Productores, bool>> filtro = x => true;
        List<Productores> ListaProductores = new List<Productores>();
        public IRetorno<Productores> PContrato { get; set; }
        public static string Llamado;
        public ConsultaProductores()
        {
            InitializeComponent();
            FiltrocomboBox.SelectedIndex = 0;
            DesdedateTimePicker.Enabled = false;
            HastadateTimePicker.Enabled = false;
            ComprobarLlamado();
            CargarGrid(ProductoresBLL.GetList(x=>true));
            
        }
        public void ComprobarLlamado()
        {
            if (Llamado == null)
                return; 
            if (Llamado.Equals("BuscarProductor_Click") || Llamado.Equals("BuscaProductores_Click"))
            {
                ProductoresdataGridView.CellDoubleClick += DataGridView_CellDoubleClick;
                ImprimirButton.Visible = false;
            }
            if (Llamado.Equals("BuscarProductor_Click"))
                ImprimirButton.Visible = true;
                
        }
        private void Seleccion()
        {
            errorProvider.Clear();
            //var lista = new List<Productores>();
            ListaProductores = new List<Productores>();
            CriteriotextBox.Focus();
            if (CriteriotextBox.Text.Trim().Length >= 0)
            {
                switch (FiltrocomboBox.SelectedIndex)
                {
                    case 0: //Todo
                        filtro = x => true;
                        break;
                    case 1: // PesadaDetalleID
                        if (!Validar())
                            return;
                        int id = Convert.ToInt32(CriteriotextBox.Text);
                        filtro = x => x.ProductorID == id;
                        break;
                    case 2: // Nombre
                        if (!Validar())
                            return;
                        filtro = x => x.Nombre.Contains(CriteriotextBox.Text);
                        break;
                    case 3: // Telefono
                        if (!Validar())
                            return;
                        filtro = x => x.Telefono.Contains(CriteriotextBox.Text);
                        break;
                    case 4: // Cedula
                        if (!Validar())
                            return;
                        filtro = x => x.Cedula.Contains(CriteriotextBox.Text);
                        break;
                } 
            }
            if (FiltracheckBox.Checked == true)
                ListaProductores = ProductoresBLL.GetList(filtro).Where(x => x.FechaNacimiento.Date >= DesdedateTimePicker.Value.Date && x.FechaNacimiento.Date <= HastadateTimePicker.Value.Date).ToList();
            else
                ListaProductores = ProductoresBLL.GetList(filtro);

            CargarGrid(ListaProductores);
        }
        private void CargarGrid(List<Productores> lista)
        {
            ProductoresdataGridView.DataSource = null; 
            ProductoresdataGridView.DataSource = lista;
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

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Seleccion();
        }

        private void CriteriotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
                Seleccion();

            if (FiltrocomboBox.SelectedIndex == 1)
            {
                Constantes.ValidarSoloNumeros(sender, e);
            }
            if (FiltrocomboBox.SelectedIndex == 2)
            {
                //En caso que fuesemos a buscar por Nombres entonces si podremos Digitar Letras
                Constantes.ValidarNombreTextBox(sender, e);
            }
            if(FiltrocomboBox.SelectedIndex == 3)
            {
                CriteriotextBox.MaxLength = 12;
            }
            if(FiltrocomboBox.SelectedIndex == 4)
            {
                CriteriotextBox.MaxLength = 13;
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

        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            ReporteDeProductor reporte = new ReporteDeProductor(ListaProductores);
            reporte.Show();
        }

        private void FiltrocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CriteriotextBox.Text = string.Empty;
        }

        private void FiltrocomboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            CriteriotextBox.Text = string.Empty;
        }

        private void FiltracheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (FiltracheckBox.Checked == true)
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
        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.RowIndex > -1))
                return;
            int index = e.RowIndex;
            DataGridViewRow row = ProductoresdataGridView.Rows[index];
            Productores p = new Productores
            {
                ProductorID = Convert.ToInt32(row.Cells[0].Value), 
            };
            PContrato.Ejecutar(p);
            this.Close();
        }
    }
}
