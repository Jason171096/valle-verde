using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerde.Vistas.Reportes
{
    public partial class ReporteEmpleado : Form
    {
        public ReporteEmpleado()
        {
            InitializeComponent();
        }
        public long ID { get; set; }
        private void ReporteEmpleado_Load(object sender, EventArgs e)
        {
            this.obtenerEmpleadoTableAdapter.Fill(this.valleverdeDataSetEmpleados.ObtenerEmpleado, ID);
            this.reportViewer1.RefreshReport();
        }
    }
}
