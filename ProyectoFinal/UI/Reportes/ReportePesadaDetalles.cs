using ProyectoFinal.BLL;
using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.UI.Reportes
{
    public partial class ReportePesadaDetalles : Form
    {
        List<PesadasDetalle> data = new List<PesadasDetalle>();
        Pesadas pesadas;
        public ReportePesadaDetalles(Pesadas pesada,List<PesadasDetalle>Lista)
        {
            InitializeComponent();
            data = Lista;
            pesadas = pesada;
        }

        private void PesadaDetallecrystalReportViewer1_Load(object sender, EventArgs e)
        {
            Productores productores = ProductoresBLL.Buscar(pesadas.ProductorId);
            TipoArroz tipoArroz = TipoArrozBLL.Buscar(pesadas.TipoArrozId);
            Factoria factoria = FactoriaBLL.Buscar(pesadas.FactoriaId);
            ReportePesadaDetalle reporte = new ReportePesadaDetalle();
            reporte.SetDataSource(data);
            reporte.SetParameterValue("?Productor", productores.Nombre);
            reporte.SetParameterValue("?TipoArroz", tipoArroz.Descripcion);
            reporte.SetParameterValue("?Factoria", factoria.Nombre);
            reporte.SetParameterValue("?PesadaId", pesadas.PesadasId);
            reporte.SetParameterValue("?TotalKilos", pesadas.TotalKiloGramos);
            reporte.SetParameterValue("?TotalSacos", pesadas.TotalSacos);
            reporte.SetParameterValue("?Fanega", pesadas.Fanega);
            reporte.SetParameterValue("?PrecioFanega", pesadas.PrecioFanega);
            reporte.SetParameterValue("?TotalAPagar", pesadas.TotalPagar);
            PesadaDetallecrystalReportViewer1.ReportSource = reporte;
            PesadaDetallecrystalReportViewer1.Refresh();
        }
    }
}
