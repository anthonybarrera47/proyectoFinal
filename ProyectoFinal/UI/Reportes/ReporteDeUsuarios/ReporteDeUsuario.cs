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

namespace ProyectoFinal.UI.Reportes.ReporteDeUsuarios
{
    public partial class ReporteDeUsuario : Form
    {
        List<Usuario> data = new List<Usuario>();
        public ReporteDeUsuario(List<Usuario> Lista)
        {
            InitializeComponent();
            data = Lista;
        }

        private void UsuariocrystalReportViewer_Load(object sender, EventArgs e)
        {
            ReporteUsuario reporteUsuario = new ReporteUsuario();
            reporteUsuario.SetDataSource(data);
            UsuariocrystalReportViewer.ReportSource = reporteUsuario;
            UsuariocrystalReportViewer.Refresh();
        }
    }
}
