using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class Pesadas
    {
        [Key]
        public int PesadasId { get; set; }
        public int ProductorId { get; set; }
        public int TipoArrozId { get; set; }
        public int FactoriaId { get; set; }
        public int UsuarioId { get; set; }
        public decimal TotalKiloGramos { get; set; }
        public decimal TotalSacos { get; set; }
        public decimal TotalPagar { get; set; }

        public virtual List<PesadasDetalle> PesadasDetalles { get; set; }

        public Pesadas(int PesadaId,int ProductorId,int TipoArrozId,int FactoriaId,decimal TotalKiloGramos,decimal TotalSacos,decimal TotalPagar,List<PesadasDetalle> pesadasDetalles)
        {
            this.PesadasId = PesadasId;
            this.ProductorId = ProductorId;
            this.TipoArrozId = TipoArrozId;
            this.TotalKiloGramos = TotalKiloGramos;
            this.TotalSacos = TotalSacos;
            this.TotalPagar = TotalPagar;
            this.PesadasDetalles = pesadasDetalles;
        }
        public Pesadas()
        {
            PesadasId = 0;
            ProductorId = 0;
            TipoArrozId = 0;
            TotalKiloGramos = 0;
            TotalSacos = 0;
            TotalPagar = 0;
            PesadasDetalles = new List<PesadasDetalle>();
        }
    }
}
