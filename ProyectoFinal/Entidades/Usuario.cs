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

        public Usuario()
        {
            UsuarioId = 0;
            UserName = string.Empty;
            Nombre = string.Empty;
            Password = string.Empty;
        }

        public Usuario(int usuarioId, string userName, string nombre, string password)
        {
            UsuarioId = usuarioId;
            UserName = userName;
            Nombre = nombre;
            Password = password;
        }
    }
}
