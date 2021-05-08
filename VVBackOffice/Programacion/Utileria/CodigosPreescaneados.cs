using System;
using System.Windows.Forms;
using ValleVerde.Programacion.Utileria;
using ValleVerde.Programacion;

namespace ValleVerde.Vistas.Utileria
{
    public partial class CodigosPreescaneados : Form
    {
        ConfiguracionPrograma configuracion;
        ClaseCodigosPreescaneados codigosPreescaneados = new ClaseCodigosPreescaneados();
        HistorialCosto historial = new HistorialCosto();
        public CodigosPreescaneados(bool bandera, ConfiguracionPrograma configuracion)
        {
            InitializeComponent();
            this.configuracion = configuracion;
            if (bandera)
            {
                Text = "Etiqueta Cambio de Precio";
                dtpFechaHistorial.Visible = true;
                dtpFechaHistorial.MinDate = new DateTime(2018, 12, 01);
                dtpFechaHistorial.MaxDate = DateTime.Now.Date;
                listBox1.DataSource = historial.CodigosHistorialCosto(dtpFechaHistorial.Value);
            }
            else
            {
                Text = "Codigos Preescaneados";
                dtpFechaHistorial.Visible = false;
                listBox1.DataSource = codigosPreescaneados.CodigosPreescaneados();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ImpresoraEtiquetas impresora = new ImpresoraEtiquetas();
            impresora.SendZplOverUsb(configuracion.impresoraEtiquetas, listBox1.SelectedValue.ToString(), true,1);
        }

        private void dtpFechaHistorial_ValueChanged(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            listBox1.DataSource = historial.CodigosHistorialCosto(dtpFechaHistorial.Value);
        }

        private void btnCambiarFecha_Click(object sender, EventArgs e)
        {
           // monthCalendar1.SelectionRange.Start
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
           // codigosPreescaneados.EliminarRegistroEtiquetas(true, );
        }
    }
}
