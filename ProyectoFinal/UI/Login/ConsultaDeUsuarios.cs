﻿using ProyectoFinal.BLL;
using ProyectoFinal.DAL;
using ProyectoFinal.Entidades;
using ProyectoFinal.UI.Reportes.ReporteDeUsuarios;
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

namespace ProyectoFinal.UI.Login
{
    public partial class ConsultaDeUsuarios : Form
    {
        public ConsultaDeUsuarios()
        {
            InitializeComponent();
            FiltrocomboBox.SelectedIndex = 0;
            DesdedateTimePicker.Enabled = false;
            HastadateTimePicker.Enabled = false;
        }
        List<Usuario> ListaUsuarios;
        Expression<Func<Usuario, bool>> filtro = x => true;
        private void Seleccion()
        {
            errorProvider.Clear();
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            ListaUsuarios = new List<Usuario>();
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
                        filtro = x => x.UsuarioId == id;
                        break;
                    case 2:
                        if (!Validar())
                            return;
                        //lista = ProductoresBLL.GetList(p => p.Nombre.Contains(CriteriotextBox.Text));
                        filtro = x => x.Nombre.Contains(CriteriotextBox.Text);
                        break;
                    case 3:
                        if (!Validar())
                            return;
                        
                        filtro = x => x.UserName.Contains(CriteriotextBox.Text);
                        break;

                }
                //filtro =(c => c.FechaRegistro.Date >= DesdedateTimePicker.Value.Date && c.FechaRegistro.Date <= HastadateTimePicker.Value.Date);
            }
            if (FiltracheckBox.Checked == true)
            {
                ListaUsuarios = repositorio.GetList(filtro).Where(x => x.FechaRegistro.Date >= DesdedateTimePicker.Value.Date && x.FechaRegistro.Date <= HastadateTimePicker.Value.Date).ToList();
                UsuariosdataGridView.DataSource = null;
                UsuariosdataGridView.DataSource = ListaUsuarios;
            }
            else
            {
                ListaUsuarios = repositorio.GetList(filtro);
                UsuariosdataGridView.DataSource = null;
                UsuariosdataGridView.DataSource = ListaUsuarios;
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

        private void BuscarButton_Click_1(object sender, EventArgs e)
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
                Constantes.ValidarSoloNumeros(sender, e);
                CriteriotextBox.MaxLength = 9;
                return;
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

        private void ImprimirButton_Click_1(object sender, EventArgs e)
        {
            ReporteDeUsuario reporte = new ReporteDeUsuario(ListaUsuarios);
            reporte.Show();
        }
        private void FiltrocomboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CriteriotextBox.Text = string.Empty;
        }

        private void FiltrocomboBox_SelectedIndexChanged(object sender, EventArgs e)
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

        private void DesdedateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            ValidarFecha();
        }

        private void HastadateTimePicker_ValueChanged_1(object sender, EventArgs e)
        {
            ValidarFecha();
        }
        private void ValidarFecha()
        {
            if (DesdedateTimePicker.Value.Date > HastadateTimePicker.Value.Date)
                errorProvider.SetError(HastadateTimePicker, "La Fecha del campo Desde no puede ser mayor que la del Campo Hasta");
            else
                errorProvider.Clear();
            if (HastadateTimePicker.Value.Date < DesdedateTimePicker.Value.Date)
                errorProvider.SetError(DesdedateTimePicker, "La Fecha del campo Desde no puede ser mayor que la del Campo Hasta");
            else
                errorProvider.Clear();
        }
    }
}
