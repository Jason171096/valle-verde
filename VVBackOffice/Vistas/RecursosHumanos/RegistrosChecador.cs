using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion.Reportes;
using ValleVerde.Vistas.Reportes;

namespace ValleVerde.Vistas.RecursosHumanos
{
    public partial class RegistrosChecador : Form
    {
        VerEmpleado obj = new VerEmpleado();
        public RegistrosChecador()
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvRegistro, true, false);
            
        }

        public void llenarTabla(string IDUsuario, string fechaInicio, string fechaFin)
        {
            dgvRegistro.ClearSelection();
            List<string[]> res = obj.Registros(IDUsuario, fechaInicio, fechaFin);//Registro checador
            foreach (string[] contenido in res)
            {
                string fechaFormato = DateTime.Parse(contenido[0]).ToString("dddd, dd/MM/yyyy", new CultureInfo("es-ES"));
                dgvRegistro.Rows.Add(new object[] { fechaFormato, DateTime.Parse(contenido[0]).TimeOfDay, contenido[1] });
                dgvRegistro.ClearSelection();
            }
        }

            private void regresar_Click(object sender, EventArgs e)
        {
            ReporteChecador obj = new ReporteChecador();
            obj.Visible = true;
            this.Close();
        }
    }
}
