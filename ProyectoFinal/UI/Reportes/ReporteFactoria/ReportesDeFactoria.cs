using Entidades;
using ProyectoFinal.UI.Reportes.ReporteFactoria;
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
    public partial class ReportesDeFactoria : Form
    {
        readonly List<Factoria> data = new List<Factoria>();
        public ReportesDeFactoria(List<Factoria> lista)
        {
            InitializeComponent();
            data = lista;
        }

        private void FactoriacrystalReportViewer_Load(object sender, EventArgs e)
        {
            ReporteDeFactoria reporteDeFactoria = new ReporteDeFactoria();
            reporteDeFactoria.SetDataSource(data);
            FactoriacrystalReportViewer.ReportSource = reporteDeFactoria;
            FactoriacrystalReportViewer.Refresh();
        }

        private void ReportesDeFactoria_Load(object sender, EventArgs e)
        {
            FactoriacrystalReportViewer_Load(sender, e);
        }

        private void ReportesDeFactoria_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
