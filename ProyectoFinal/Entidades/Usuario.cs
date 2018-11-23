using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{

    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string UserName { get; set; }
        public String Nombre { get; set; }
        public String Password { get; set; }
        public String Tipo { get; set; }
        public DateTime FechaRegistro { get; set; }

        public Usuario()
        {
            UsuarioId = 0;
            UserName = string.Empty;
            Nombre = string.Empty;
            Password = string.Empty;
            Tipo = string.Empty;
            FechaRegistro = DateTime.Now;
        }

        public Usuario(int usuarioId, string userName, string nombre, string password, string tipo, DateTime fechaRegistro)
        {
            UsuarioId = usuarioId;
            UserName = userName;
            Nombre = nombre;
            Password = password;
            Tipo = tipo;
            FechaRegistro = fechaRegistro;
        }
    }
}
