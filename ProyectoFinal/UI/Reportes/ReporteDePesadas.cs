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
    public partial class ReporteDePesadas : Form
    {
        List<Pesadas> data = new List<Pesadas>();
        public ReporteDePesadas(List<Pesadas> lista)
        {
            InitializeComponent();
            data = lista;
        }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            ReporteDePesada reporteDePesada = new ReporteDePesada();
            reporteDePesada.SetDataSource(data);
            PesadascrystalReportViewer.ReportSource = reporteDePesada;
            PesadascrystalReportViewer.Refresh();
        }
    }
}
