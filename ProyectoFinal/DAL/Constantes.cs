
using System;
using System.Security.Cryptography;
using System.Text;
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
        //Este metodo Valida El TextBox para que este solo acepte numeros enteros efectivo a la hora de consultas por PesadaDetalleID.
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
        public static void ValidarNumerosDecimales(object sender,KeyPressEventArgs e,String cadena)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            bool IsDec = false;
            int nroDec = 0;

            for (int x = 0; x < cadena.Length; x++)
            {
                if (cadena[x] == '.')
                { IsDec = true; }
                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }
        public static bool ValidarEspaciosEnBlancos(String cadena)
        {
            bool paso = true;
            for(int i=0;i<cadena.Length;i++)
            {
                if (cadena[i]==' ')
                    paso = false;
            }
            return paso;
        }
        public static string SHA1(string password)
        {
            using (SHA1Managed SHa1 = new SHA1Managed())
            {
                var hash = SHa1.ComputeHash(Encoding.UTF8.GetBytes(password));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte item in hash)
                {
                    sb.Append(item.ToString("X2"));
                }
                return sb.ToString();
            }
        }
        public static decimal Truncate(decimal value, int decimalPlaces)
        {
            decimal integralValue = Math.Truncate(value);
            decimal fraction = value - integralValue;
            int factor = (int)Math.Pow(10, decimalPlaces);
            decimal truncatedFraction = Math.Truncate(fraction * factor) / factor;
            decimal result = integralValue + truncatedFraction;
            return result;
        }
    }
}
