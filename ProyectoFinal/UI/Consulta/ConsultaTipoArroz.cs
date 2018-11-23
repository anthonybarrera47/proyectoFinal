using ProyectoFinal.BLL;
using ProyectoFinal.DAL;
using ProyectoFinal.Entidades;
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
    public partial class ConsultaTipoArroz : Form
    {
        public ConsultaTipoArroz()
        {
            InitializeComponent();
            FiltrocomboBox.SelectedIndex = 0;
        }
        Expression<Func<TipoArroz, bool>> filtro = x => true;
        private void Seleccion()
        {
            errorProvider.Clear();

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
                        filtro = x => x.TipoArrozId == id;
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
                //filtro = (c => c.FechaNacimiento.Date >= DesdedateTimePicker.Value.Date && c.FechaNacimiento.Date <= HastadateTimePicker.Value.Date);
            }
            ProductoresdataGridView.DataSource = null;
            ProductoresdataGridView.DataSource = TipoArrozBLL.GetList(filtro);
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
            if (FiltrocomboBox.SelectedIndex == 2)
            {
                //En caso que fuesemos a buscar por Nombres entonces si podremos Digitar Letras
                Constantes.ValidarNombreTextBox(sender, e);
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
            /* ReporteDeProductor reporte = new ReporteDeProductor(ProductoresBLL.GetList(filtro));
             reporte.Show();*/
        }
        private void FiltrocomboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CriteriotextBox.Text = string.Empty;
        }
    }
}
