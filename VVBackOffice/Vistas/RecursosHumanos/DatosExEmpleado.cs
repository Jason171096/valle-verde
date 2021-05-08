using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerde.Vistas.RecursosHumanos
{
    public partial class DatosExEmpleado : Form
    {
        public DatosExEmpleado()
        {
            InitializeComponent();
        }
        public long ID { get; set; }
        private void DatosExEmpleado_Load(object sender, EventArgs e)
        {
            this.obtenerExEmpleadoTableAdapter.Fill(this.valleverdeDataSetEmpleados.ObtenerExEmpleado, ID);
            this.reportViewer1.RefreshReport();
        }
    }
}
