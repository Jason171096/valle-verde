using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion.Utileria;

namespace ValleVerde.Vistas.Utileria
{
    public partial class HistorialImpresionesEtiquetas : Form
    {
        CHistorialImpresion cHistorial = new CHistorialImpresion();
        DataTable dt;
        public HistorialImpresionesEtiquetas()
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvHistorial, true, false);
            dt = cHistorial.TableHistorial(DateTime.Now.ToString("dd/MM/yyyy"));
            dgvHistorial.DataSource = dt;
        }

        private void dtpFechaHistorial_ValueChanged(object sender, EventArgs e)
        {
            dgvHistorial.DataSource = null;
            dt = cHistorial.TableHistorial(dtpFechaHistorial.Value.ToString("dd/MM/yyyy"));
            dgvHistorial.DataSource = dt;
        }
    }
}
