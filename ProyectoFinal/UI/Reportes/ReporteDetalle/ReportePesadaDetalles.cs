using ProyectoFinal.BLL;
using ProyectoFinal.Entidades;
using ProyectoFinal.UI.Reportes.ReporteDetalle;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace ProyectoFinal.UI.Reportes
{
    public partial class ReportePesadaDetalles : Form
    {
        List<PesadasDetalle> data = new List<PesadasDetalle>();
        Pesadas pesadas;
        String Nombre;
        ReportePesadaDetalle reporte = new ReportePesadaDetalle();
        public ReportePesadaDetalles(Pesadas pesada,List<PesadasDetalle>Lista,string nombre)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
          
            data = Lista;
            pesadas = pesada;
            Nombre = nombre;
        }
        private void Cargar()
        {
            Productores productores = ProductoresBLL.Buscar(pesadas.ProductorID);
            TipoArroz tipoArroz = TipoArrozBLL.Buscar(pesadas.TipoArrozID);
            Factoria factoria = FactoriaBLL.Buscar(pesadas.FactoriaID);
            
            
            reporte.SetDataSource(data);
            reporte.SetParameterValue("Usuario", Nombre);
            reporte.SetParameterValue("Productor", productores.Nombre);
            reporte.SetParameterValue("Tipo Arroz", tipoArroz.Descripcion);
            reporte.SetParameterValue("Factoria", factoria.Nombre);
            reporte.SetParameterValue("PesadaID", pesadas.PesadaID);
            reporte.SetParameterValue("TotalKilos", pesadas.TotalKiloGramos);
            reporte.SetParameterValue("TotalSacos", pesadas.TotalSacos);
            reporte.SetParameterValue("Fanega", pesadas.Fanega);
            reporte.SetParameterValue("PrecioFanega", pesadas.PrecioFanega);
            reporte.SetParameterValue("TotalAPagar", pesadas.TotalPagar);
            reporte.SetParameterValue("Fecha", pesadas.FechaRegistro);

            PesadaDetallecrystalReportViewer1.ReportSource = reporte;
            PesadaDetallecrystalReportViewer1.Refresh();
           
        }
        private void PesadaDetallecrystalReportViewer1_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        private void ReportePesadaDetalles_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void ReportePesadaDetalles_FormClosed(object sender, FormClosedEventArgs e)
        {
            reporte.Dispose();
            this.Dispose();
        }
    }
}
