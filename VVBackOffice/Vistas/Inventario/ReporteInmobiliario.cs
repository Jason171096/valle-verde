using System;
using System.Data;
using System.Windows.Forms;
using System.Globalization;
using ValleVerde.Programacion.Inventario;
using System.Drawing;

namespace ValleVerde.Vistas.Inventario
{
    public partial class ReporteInmobiliario : Form
    {
        DataTable dtInmo = new DataTable();
        Inmobiliario inmobiliario = new Inmobiliario();
        Validaciones v = new Validaciones();
        private bool activado;
        public ReporteInmobiliario()
        {
            InitializeComponent();
            ActualizarTablas();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvInmobiliario, true, false);
            activado = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtInmo);
            dv.RowFilter = string.Format("Convert(IDInmobiliario,'System.String') LIKE '%{0}%' OR Descripcion LIKE '%{0}%'", txtBuscar.Text);
            dgvInmobiliario.DataSource = dv;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(txtDescri.Text) && String.IsNullOrWhiteSpace(txtExistencia.Text) && String.IsNullOrWhiteSpace(txtPrecio.Text))
                MessageBox.Show("No pueden estar la Descripcion o Existencia o Precio vacios", "¡ADVERTENCIA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                //Aqui va mas codigo
                inmobiliario.AltaInmobiliario(txtDescri.Text, txtModelo.Text, txtExistencia.Text, txtPrecio.Text);
                //Esto va a hasta el ultimo
                ActualizarTablas();
            }
        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if(dgvInmobiliario.CurrentRow.Selected == false)
                MessageBox.Show("Seleccione la casilla para poder eliminarlo", "¡ADVERTENCIA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                DialogResult result = MessageBox.Show("¿Desea eliminar el producto?", "¡ADVERTENCIA!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    //Aqui va mas codigo
                    inmobiliario.BajaInmobiliario(dgvInmobiliario.CurrentRow.Cells[0].Value.ToString());
                    //Esto va a hasta el ultimo
                    ActualizarTablas();
                }
            }
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            if (dgvInmobiliario.CurrentRow.Selected == false)
                MessageBox.Show("Seleccione la casilla para poder modificarlo", "¡ADVERTENCIA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (activado == false)
            {
                txtID.Text = dgvInmobiliario.CurrentRow.Cells[0].Value.ToString();
                txtDescri.Text = dgvInmobiliario.CurrentRow.Cells[1].Value.ToString();
                txtModelo.Text = dgvInmobiliario.CurrentRow.Cells[2].Value.ToString();
                txtExistencia.Text = dgvInmobiliario.CurrentRow.Cells[3].Value.ToString();
                txtPrecio.Text = dgvInmobiliario.CurrentRow.Cells[4].Value.ToString();
                btnAgregar.Enabled = false;
                btnBorrar.Enabled = false;
                btnImprimir.Enabled = false;
                btnExportarExcel.Enabled = false;
                btnExportarPDF.Enabled = false;
                txtBuscar.Enabled = false;
                btnModificar.Text = "OK";
                activado = true;
            }
            else
            {
                activado = false;
                btnModificar.Text = "Modificar";
                btnAgregar.Enabled = true;
                btnBorrar.Enabled = true;
                btnImprimir.Enabled = true;
                btnExportarExcel.Enabled = true;
                btnExportarPDF.Enabled = true;
                txtBuscar.Enabled = true;
                inmobiliario.ModificarInmobiliario(txtID.Text, txtDescri.Text, txtModelo.Text,
                   txtExistencia.Text, txtPrecio.Text);
                BorrarDatos();
                ActualizarTablas();
            }
        }

        #region Validaciones

        private void txtExistencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloDecimales(sender, e);
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloDecimales(sender, e);
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumerosyLetras(sender, e);
        }
        #endregion
        #region Actualizar datos
        private void ActualizarTablas()
        {
            dgvInmobiliario.DataSource = null;
            dtInmo.Clear();
            dtInmo = inmobiliario.DataTableInmobiliario();
            dgvInmobiliario.DataSource = dtInmo;
            decimal sumaTotal = 0, sumaCantidad = 0;
            foreach (DataGridViewRow item in dgvInmobiliario.Rows)
            {
                sumaCantidad += decimal.Parse(item.Cells[3].Value.ToString());
                sumaTotal += decimal.Parse(item.Cells[5].Value.ToString(), NumberStyles.Currency);
            }
            lblCantidad.Text = sumaCantidad.ToString();
            lblCosto.Text = String.Format("{0:C2}", sumaTotal);
            lblCantidad.ForeColor = Color.Green;
            lblCosto.ForeColor = Color.Green;
        }
        #endregion
        #region BorrarDatos
        private void BorrarDatos()
        {
            txtID.Clear();
            txtDescri.Clear();
            txtModelo.Clear();
            txtExistencia.Clear();
            txtPrecio.Clear();
        }
        #endregion

    }
}
