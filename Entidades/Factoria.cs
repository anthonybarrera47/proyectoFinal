﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Factoria
    {
        [Key]
        public int FactoriaID { get; set; }
        public String Nombre { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public DateTime FechaRegistro { get; set; }

        public Factoria()
        {
            FactoriaID = 0;
            Nombre = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            FechaRegistro = DateTime.Now;
        }
        public Factoria(int FactoriaID,String Nombre,String Direccion,String Telefono,DateTime Fecha)
        {
            this.FactoriaID = FactoriaID;
            this.Nombre = Nombre;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
            this.FechaRegistro = Fecha;
        }
    }
}
