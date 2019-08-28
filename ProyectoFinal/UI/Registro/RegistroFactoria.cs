using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ProyectoFinal.UI.Consulta;
using Entidades;
using DAL;
using BLL;

namespace ProyectoFinal.UI.Registro
{
    public partial class RegistroFactoria : Form, IRetorno<Factoria>
    {
        public RegistroFactoria()
        {
            InitializeComponent();
            Limpiar();
        }
        private void Limpiar()
        {
            ErrorProvider.Clear();
            FactoriaIDTextBox.Text = 0.ToString();
            NombreTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            FechadateTimePicker.Value = DateTime.Now;
        }
        private Factoria LlenaClase()
        {
            Factoria factoria = new Factoria();
            factoria.FactoriaID = 0;
            factoria.Nombre = NombreTextBox.Text;
            factoria.Direccion = DireccionTextBox.Text;
            factoria.Telefono = TelefonoTextBox.Text;
            factoria.FechaRegistro = FechadateTimePicker.Value;
            return factoria;
        }
        private void LlenaCampo(Factoria factoria)
        {
            FactoriaIDTextBox.Text = factoria.FactoriaID.ToString();
            NombreTextBox.Text = factoria.Nombre;
            DireccionTextBox.Text = factoria.Direccion;
            TelefonoTextBox.Text = factoria.Telefono;
        }
        private bool Validar()
        {
            ErrorProvider.Clear();
            bool paso = true;
            if (String.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                ErrorProvider.SetError(NombreTextBox, "Este Campo No puede Estar Vacio!!");
                paso = false;
            }
            if (String.IsNullOrWhiteSpace(DireccionTextBox.Text))
            {
                ErrorProvider.SetError(DireccionTextBox, "Este Campo No puede Estar Vacio!!");
                paso = false;
            }
            if (String.IsNullOrWhiteSpace(TelefonoTextBox.Text.Replace("-", "")) || TelefonoTextBox.Text.Length != 12)
            {
                ErrorProvider.SetError(TelefonoTextBox, "Este Campo No puede Estar Vacio!!");
                paso = false;
            }
            if (!Constantes.ValidarEspaciosEnBlancos(TelefonoTextBox.Text))
            {
                ErrorProvider.SetError(TelefonoTextBox, "Este Campo No puede contener Espacios en blancos!!");
                paso = false;
            }
            if (String.IsNullOrEmpty(FactoriaIDTextBox.Text))
            {
                FactoriaIDTextBox.Text = "0";
            }
            return paso;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Factoria> repositorio = new RepositorioBase<Factoria>();
            Factoria factoria = repositorio.Buscar(Convert.ToInt32(FactoriaIDTextBox.Text));
            return (factoria != null);
        }
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;
            Factoria factoria;
            RepositorioBase<Factoria> repositorio = new RepositorioBase<Factoria>();
            bool paso;
            factoria = LlenaClase();

            factoria.FactoriaID = 0;
            if (Convert.ToInt32(FactoriaIDTextBox.Text) == 0)
                paso = repositorio.Guardar(factoria);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No Puedes Modificar una Factoria Inexistente, Verifique Los Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = FactoriaBLL.Modificar(factoria);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Factoria Modificada Exitosamente!!", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (paso)
            {
                MessageBox.Show("Factoria Guardada Exitosamente!!", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
                MessageBox.Show("No Se Pudo Guardar!!", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Factoria> repositorio = new RepositorioBase<Factoria>();
            ErrorProvider.Clear();
            int.TryParse(FactoriaIDTextBox.Text, out int ID);

            if (!ExisteEnLaBaseDeDatos())
            {
                ErrorProvider.SetError(FactoriaIDTextBox, "No Puede Borrar Una Factoria Inexistente");
                return;
            }
            if (repositorio.Eliminar(ID))
            {
                Limpiar();
                MessageBox.Show("Factoria Eliminada Exitosamente!!", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            var cmd = new CallerMemberName();
            cmd.UsingCallerMemberName();
            ConsultaDeFactorias.Llamado = cmd.Nombre;
            ConsultaDeFactorias cConsultaFactorias = new ConsultaDeFactorias
            {
                FFactoria = this
            };
            cConsultaFactorias.ShowDialog();
            cConsultaFactorias.Dispose();
        }
        private void Buscar()
        {
            RepositorioBase<Factoria> repositorio = new RepositorioBase<Factoria>();
            ErrorProvider.Clear();
            int.TryParse(FactoriaIDTextBox.Text, out int ID);
            Factoria factoria = repositorio.Buscar(ID);
            if (factoria != null)
            {
                ErrorProvider.Clear();
                LlenaCampo(factoria);
            }
            else
                MessageBox.Show("Factoria no Encontrada!!", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void NombreTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Constantes.ValidarNombreTextBox(sender, e);
        }
        public void Ejecutar(Factoria template)
        {
            if (template.FactoriaID == 0)
                return;
            LlenaCampo(FactoriaBLL.Buscar(template.FactoriaID));
        }
        private void FactoriaIDTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
                Buscar();
            Constantes.ValidarSoloNumeros(sender, e);
        }
    }
}
