using ProyectoFinal.BLL;
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
        public ConsultaProductores()
        {
            InitializeComponent();
            FiltrocomboBox.SelectedIndex = 0;
        }

        private void Seleccion()
        {
            errorProvider.Clear();
            //var lista = new List<Productores>();
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
                        //lista = ProductoresBLL.GetList(p => p.ProductorId == id);
                        filtro = x => x.ProductorId == id;
                        break;
                    case 2:
                        if (!Validar())
                            return;
                        //lista = ProductoresBLL.GetList(p => p.Nombre.Contains(CriteriotextBox.Text));
                        filtro = x => x.Nombre.Contains(CriteriotextBox.Text);
                        break;
                }
                //filtro = (c => c.FechaNacimiento.Date >= DesdedateTimePicker.Value.Date && c.FechaNacimiento.Date <= HastadateTimePicker.Value.Date);
            }
            ProductoresdataGridView.DataSource = null;
            ProductoresdataGridView.DataSource = ProductoresBLL.GetList(filtro);
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
                //Para obligar a que sólo se introduzcan números
                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                  if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan
                    e.Handled = true;
                }
                return;
            }
            if (FiltrocomboBox.SelectedIndex == 2)
            {
                //En caso que fuesemos a buscar por Nombres entonces si podremos Digitar Letras
                if (Char.IsLetter(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }

        }
        //Avisamosa al usuario de algun error en la consulta por fechas
        private void HastadateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (DesdedateTimePicker.Value.Date > HastadateTimePicker.Value.Date)
                errorProvider.SetError(HastadateTimePicker, "La Fecha del campo Desde no puede ser mayor que la del Campo Hasta");
            else
                errorProvider.Clear();
        }

        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            ReporteDeProductor reporte = new ReporteDeProductor(ProductoresBLL.GetList(filtro));
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
    }
}
