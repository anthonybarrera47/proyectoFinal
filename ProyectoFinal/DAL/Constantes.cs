
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProyectoFinal.DAL
{
    public class Constantes
    {
        public const string admi = "A";
        public const string user = "U";

        //Metodo Para Utilizar Expresiones Regulares
        public static bool ComprobarRegex(string expressionRegular,string cadena)
        {
            Regex regex = new Regex(expressionRegular);
            bool result = regex.IsMatch(cadena);
            return result;
        }
        //Este Metodo valida que Solo haya Letras dentro del TextBox Muy Efectivo para validar nombres
        public static void ValidarNombreTextBox(object sender, KeyPressEventArgs e)
        {
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
        //Este metodo Valida El TextBox para que este solo acepte numeros enteros efectivo a la hora de consultas por ID.
        public static void ValidarSoloNumeros(object sender,KeyPressEventArgs e)
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
    }
}
