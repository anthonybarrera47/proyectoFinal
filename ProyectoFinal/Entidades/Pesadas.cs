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
        public int PesadasID { get; set; }
        public int ProductorID { get; set; }
        public int TipoArrozID { get; set; }
        public int FactoriaID { get; set; }
        public int UsuarioID { get; set; }
        public decimal Fanega { get; set; }
        public decimal PrecioFanega { get; set; }
        public decimal TotalKiloGramos { get; set; }
        public decimal TotalSacos { get; set; }
        public decimal TotalPagar { get; set; }
        public DateTime FechaRegistro { get; set; }

        public virtual List<PesadasDetalle> PesadasDetalles { get; set; }

        public Pesadas(int PesadaID, int ProductorId, int TipoArrozId, int FactoriaId, int UsuarioId, decimal Fanega, decimal PrecioFanega
            ,decimal TotalKiloGramos,decimal TotalSacos,decimal TotalPagar,List<PesadasDetalle> pesadasDetalles)
        {
            this.PesadasID = PesadaID;
            this.ProductorID = ProductorId;
            this.TipoArrozID = TipoArrozId;
            this.FactoriaID = FactoriaId;
            this.UsuarioID = UsuarioId;
            this.Fanega = Fanega;
            this.PrecioFanega = PrecioFanega;
            this.TotalKiloGramos = TotalKiloGramos;
            this.TotalSacos = TotalSacos;
            this.TotalPagar = TotalPagar;
            this.PesadasDetalles = pesadasDetalles;
        }
        public Pesadas()
        {
            PesadasID = 0;
            ProductorID = 0;
            TipoArrozID = 0;
            FactoriaID = 0;
            UsuarioID = 0;
            Fanega = 0;
            PrecioFanega = 0;
            TotalKiloGramos = 0;
            TotalSacos = 0;
            TotalPagar = 0;
            PesadasDetalles = new List<PesadasDetalle>();
        }
    }
}
