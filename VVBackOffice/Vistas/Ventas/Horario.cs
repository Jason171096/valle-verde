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
using ValleVerde.Programacion.Ventas;

namespace ValleVerde.Vistas.Ventas
{
    public partial class Horario : Form
    {
        Promocion promo = new Promocion();
        Label idHora = new Label();
        public Horario(Label labelHorario)
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvHorario, true, false);
            dgvHorario.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            Llenartabla();
            dgvHorario.ClearSelection();
            this.idHora = labelHorario;
        }

        private void Llenartabla()
        {
            dgvHorario.Rows.Clear();
            List<string[]> res = promo.ObtenerTodosHorariosPromocion();

            foreach(string[] fila in res)
            {
                dgvHorario.Rows.Add(fila[0],fila[1], fila[2], fila[3], fila[4], fila[5], fila[6], fila[7], fila[8]);
                dgvHorario.ClearSelection();
            }
            dgvHorario.ClearSelection();
        }

        private void nuevoHorario_Click(object sender, EventArgs e)
        {
            groupHorario.Visible = true;
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            string lunes = "", martes = "", miercoles = "", jueves = "", viernes = "", sabado = "", domingo = "";

            //insertar
            if (chkLunes.Checked)
            {
                lunes = lHinicio.Value.ToString("hh:mm:ss tt") + " - " + lHFin.Value.ToString("hh:mm:ss tt");
            }
            if (chkMartes.Checked)
            {
                martes = mHInicio.Value.ToString("hh:mm:ss tt") + " - " + mHFin.Value.ToString("hh:mm:ss tt");
            }
            if (chkMiercoles.Checked)
            {
                miercoles = miHInicio.Value.ToString("hh:mm:ss tt") + " - " + miHFin.Value.ToString("hh:mm:ss tt");
            }
            if (chkJueves.Checked)
            {
                jueves = jHInicio.Value.ToString("hh:mm:ss tt") + " - " + jHFin.Value.ToString("hh:mm:ss tt");
            }
            if (chkViernes.Checked)
            {
                viernes = vHInicio.Value.ToString("hh:mm:ss tt") + " - " + vHFin.Value.ToString("hh:mm:ss tt");
            }
            if (chkSabado.Checked)
            {
                sabado = sHInicio.Value.ToString("hh:mm:ss tt") + " - " + sHFin.Value.ToString("hh:mm:ss tt");
            }
            if (chkDomingo.Checked)
            {
                domingo = dHInicio.Value.ToString("hh:mm:ss tt") + " - " + dHFin.Value.ToString("hh:mm:ss tt");
            }

            if (textNombre.Text == "")
            {
                MessageBox.Show("El campo nombre esta vacio", "Error");
            }
            else
            {
                promo.AgregarHorarioPromocion(textNombre.Text, lunes, martes, miercoles, jueves, viernes, sabado, domingo);
                groupHorario.Visible = false;
            }

            //refrescar data
            Llenartabla();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            groupHorario.Visible = true;

        }

        private void dgvHorario_DoubleClick(object sender, EventArgs e)
        {
            if(dgvHorario.SelectedRows.Count > 0)
            {
                idHora.Text = dgvHorario.CurrentRow.Cells[0].Value.ToString();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Seleccione un horario de la tabla", "Error");
            }
        }
    }
}
