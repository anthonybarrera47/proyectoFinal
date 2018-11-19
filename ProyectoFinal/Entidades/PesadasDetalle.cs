using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class PesadasDetalle
    {
        [Key]
        public int Id { get; set; }
        public int PesadaId { get; set; }
        public decimal Kilos { get; set; }
        public decimal CantidadDeSacos { get; set; }

        public PesadasDetalle()
        {
            Id = 0;
            PesadaId = 0;
            Kilos = 0;
            CantidadDeSacos = 0;
        }

        public PesadasDetalle(int id, int pesadaId, decimal kilos, decimal cantidadDeSacos)
        {
            Id = id;
            PesadaId = pesadaId;
            Kilos = kilos;
            CantidadDeSacos = cantidadDeSacos;
        }
    }
}
