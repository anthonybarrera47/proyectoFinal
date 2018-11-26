using ProyectoFinal.Entidades;
using ProyectoFinal.UI.Reportes.ReporteDeTipoArroz;
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
    public partial class ReportesDeTipoArroz : Form
    {
        List<TipoArroz> data = new List<TipoArroz>(); 
        public ReportesDeTipoArroz(List<TipoArroz> lista)
        {
            InitializeComponent();
            data = lista;
        }

        private void TipoArrozcrystalReportViewer_Load(object sender, EventArgs e)
        {
            ReporteDeTiposArroz reporteDeTiposArroz = new ReporteDeTiposArroz();
            reporteDeTiposArroz.SetDataSource(data);
            TipoArrozcrystalReportViewer.ReportSource = reporteDeTiposArroz;
            TipoArrozcrystalReportViewer.Refresh();
        }
    }
}
