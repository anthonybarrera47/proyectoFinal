using System;
using ProyectoFinal.Entidades;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoFinal.BLL;
using System.Text.RegularExpressions;

namespace ProyectoFinal.UI.Registro
{
    public partial class RegistroFactoria : Form
    {
        internal RepositorioBase<Factoria> repositorio;
        public RegistroFactoria()
        {
            
            InitializeComponent();
        }
        private void Limpiar()
        {
            ErrorProvider.Clear();
            FactoriaIDNumericUpDown.Value = 0;
            NombreTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
        }
        private Factoria LlenaClase()
        {
            Factoria factoria = new Factoria()
            {
                FactoriaID = Convert.ToInt32(FactoriaIDNumericUpDown.Value),
                Nombre = NombreTextBox.Text,
                Direccion = DireccionTextBox.Text,
                Telefono = TelefonoTextBox.Text
            };

            return factoria;
        }
        private void LlenaCampo(Factoria factoria)
        {
            FactoriaIDNumericUpDown.Value = factoria.FactoriaID;
            NombreTextBox.Text = factoria.Nombre;
            DireccionTextBox.Text = factoria.Direccion;
            TelefonoTextBox.Text = factoria.Telefono;
        }
        private bool Validar()
        {
            bool paso = true;
            String nombre = NombreTextBox.Text;
            String telefono = Telefono.Text;      
            Regex regex = new Regex(@"[a-zA-ZñÑ\s]{2,50}");
            Regex regexTelefono = new Regex(@"^[+-]?\d+(\.\d+)?$");
            if(String.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                ErrorProvider.SetError(NombreTextBox, "Este Campo No puede Estar Vacio!!");
                paso = false;
            }
            if(String.IsNullOrWhiteSpace(DireccionTextBox.Text))
            {
                ErrorProvider.SetError(DireccionTextBox, "Este Campo No puede Estar Vacio!!");
                paso = false;
            }
            if (String.IsNullOrWhiteSpace(TelefonoTextBox.Text))
            {
                ErrorProvider.SetError(TelefonoTextBox, "Este Campo No puede Estar Vacio!!");
                paso = false;
            }
            if(regex.IsMatch(nombre)==false)
            {
                ErrorProvider.SetError(NombreTextBox, "Este Campo Solo Debe Contener Letras");
                paso = false;
            }
            if(regexTelefono.IsMatch(telefono))
            {
                ErrorProvider.SetError(TelefonoTextBox, "Este Campo Solo Debe Contener Numeros");
                paso = false;
            }
            return paso;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            repositorio = new RepositorioBase<Factoria>();
            //Factoria factoria = repositorio.Buscar((int)FactoriaIDNumericUpDown.Value);
            Factoria factoria = FactoriaBLL.Buscar((int)FactoriaIDNumericUpDown.Value);
            return (factoria != null);
        }  
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Factoria factoria;
            repositorio = new RepositorioBase<Factoria>();
            bool paso = false;
            if (!Validar())
                return;

            factoria = LlenaClase();
            if (FactoriaIDNumericUpDown.Value == 0)
                //paso = repositorio.Guardar(factoria);
                paso = FactoriaBLL.Guardar(factoria);
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
                    MessageBox.Show("Factoria Modificada Exitosamente!!", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    return;
                }
            }
            if(paso)
            {
                MessageBox.Show("Factoria Guardada Exitosamente!!", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
                MessageBox.Show("No Se Pudo Guardar!!","Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            repositorio = new RepositorioBase<Factoria>();
            ErrorProvider.Clear();
            int ID;
            int.TryParse(FactoriaIDNumericUpDown.Text, out ID);
            
            if(!ExisteEnLaBaseDeDatos())
            {
                ErrorProvider.SetError(FactoriaIDNumericUpDown, "No Puede Borrar Una Factoria Inexistente");
                return; 
            }
            //if(repositorio.Eliminar(ID))
            if(FactoriaBLL.Eliminar(ID))
            {
                Limpiar();
                MessageBox.Show("Factoria Eliminada Exitosamente!!", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            repositorio = new RepositorioBase<Factoria>();
            ErrorProvider.Clear();
            int ID;
            int.TryParse(FactoriaIDNumericUpDown.Text, out ID);
            Factoria factoria = new Factoria();

            //factoria = repositorio.Buscar(ID);
            factoria = FactoriaBLL.Buscar(ID);
            if(factoria != null)
            {
                ErrorProvider.Clear();
                LlenaCampo(factoria);
                MessageBox.Show("Factoria Encontrada!!", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Factoria no Encontrada!!", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
