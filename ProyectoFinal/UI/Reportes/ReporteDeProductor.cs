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
    }
}
