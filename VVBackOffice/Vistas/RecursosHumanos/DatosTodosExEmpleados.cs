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
    public partial class DatosTodosExEmpleados : Form
    {
        public DatosTodosExEmpleados()
        {
            InitializeComponent();
        }

        private void DatosTodosExEmpleados_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'valleverdeDataSetEmpleados.ObtenerTodoExEmpleados' Puede moverla o quitarla según sea necesario.
            this.obtenerTodoExEmpleadosTableAdapter.Fill(this.valleverdeDataSetEmpleados.ObtenerTodoExEmpleados);

            this.reportViewer1.RefreshReport();
        }
    }
}
