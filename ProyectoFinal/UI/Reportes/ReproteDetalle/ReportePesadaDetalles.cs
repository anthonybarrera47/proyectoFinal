using ProyectoFinal.BLL;
using ProyectoFinal.Entidades;
using ProyectoFinal.UI.Reportes.ReproteDetalle;
using System;
using System.Collections.Generic;

using System.Windows.Forms;

namespace ProyectoFinal.UI.Reportes
{
    public partial class ReportePesadaDetalles : Form
    {
        List<PesadasDetalle> data = new List<PesadasDetalle>();
        Pesadas pesadas;
        String Nombre;
        public ReportePesadaDetalles(Pesadas pesada,List<PesadasDetalle>Lista,string nombre)
        {
            InitializeComponent();
            data = Lista;
            pesadas = pesada;
            Nombre = nombre;
        }

        private void PesadaDetallecrystalReportViewer1_Load(object sender, EventArgs e)
        {
            
            Productores productores = ProductoresBLL.Buscar(pesadas.ProductorID);
            TipoArroz tipoArroz = TipoArrozBLL.Buscar(pesadas.TipoArrozID);
            Factoria factoria = FactoriaBLL.Buscar(pesadas.FactoriaID);
            ReportePesadaDetalle reporte = new ReportePesadaDetalle();
            reporte.SetDataSource(data);
            reporte.SetParameterValue("Usuarios", Nombre);
            reporte.SetParameterValue("Productor", productores.Nombre);
            reporte.SetParameterValue("TipoUsuario Arroz", tipoArroz.Descripcion);
            reporte.SetParameterValue("Factoria", factoria.Nombre);
            reporte.SetParameterValue("PesadaId", pesadas.PesadaID);
            reporte.SetParameterValue("TotalKilos", pesadas.TotalKiloGramos);
            reporte.SetParameterValue("TotalSacos", pesadas.TotalSacos);
            reporte.SetParameterValue("Fanega", pesadas.Fanega);
            reporte.SetParameterValue("PrecioFanega", pesadas.PrecioFanega);
            reporte.SetParameterValue("TotalAPagar", pesadas.TotalPagar);
            reporte.SetParameterValue("FechaRegistro", pesadas.FechaRegistro);
            PesadaDetallecrystalReportViewer1.ReportSource = reporte;
            PesadaDetallecrystalReportViewer1.Refresh();
        }

        private void ReportePesadaDetalles_Load(object sender, EventArgs e)
        {
            PesadaDetallecrystalReportViewer1_Load(sender, e);
        }
    }
}
