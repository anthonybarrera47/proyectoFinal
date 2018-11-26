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
            
            Productores productores = ProductoresBLL.Buscar(pesadas.ProductorId);
            TipoArroz tipoArroz = TipoArrozBLL.Buscar(pesadas.TipoArrozId);
            Factoria factoria = FactoriaBLL.Buscar(pesadas.FactoriaId);
            ReportePesadaDetalle reporte = new ReportePesadaDetalle();
            reporte.SetDataSource(data);
            reporte.SetParameterValue("Usuario", Nombre);
            reporte.SetParameterValue("Productor", productores.Nombre);
            reporte.SetParameterValue("Tipo Arroz", tipoArroz.Descripcion);
            reporte.SetParameterValue("Factoria", factoria.Nombre);
            reporte.SetParameterValue("PesadaId", pesadas.PesadasId);
            reporte.SetParameterValue("TotalKilos", pesadas.TotalKiloGramos);
            reporte.SetParameterValue("TotalSacos", pesadas.TotalSacos);
            reporte.SetParameterValue("Fanega", pesadas.Fanega);
            reporte.SetParameterValue("PrecioFanega", pesadas.PrecioFanega);
            reporte.SetParameterValue("TotalAPagar", pesadas.TotalPagar);
            reporte.SetParameterValue("Fecha", pesadas.FechaRegistro);
            PesadaDetallecrystalReportViewer1.ReportSource = reporte;
            PesadaDetallecrystalReportViewer1.Refresh();
        }
    }
}
