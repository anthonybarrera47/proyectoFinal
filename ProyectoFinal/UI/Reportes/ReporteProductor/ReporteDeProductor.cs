using ProyectoFinal.Entidades;
using ProyectoFinal.UI.Reportes.ReporteProductor;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProyectoFinal.UI.Reportes
{
    public partial class ReporteDeProductor : Form
    {
        List<Productores> data = new List<Productores>();
        public ReporteDeProductor(List<Productores> lista)
        {
            InitializeComponent();
            data = lista;
        }

        private void ProductorescrystalReportViewer1_Load(object sender, EventArgs e)
        {
            ReporteDeProductores reporteDeProductores = new ReporteDeProductores();
            reporteDeProductores.SetDataSource(data);
            ProductorescrystalReportViewer1.ReportSource = reporteDeProductores;
            ProductorescrystalReportViewer1.Refresh();
        }

        private void ReporteDeProductor_Load(object sender, EventArgs e)
        {
            ProductorescrystalReportViewer1_Load(sender, e);
        }
    }
}
