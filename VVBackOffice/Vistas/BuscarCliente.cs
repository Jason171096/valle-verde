using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion;
using ValleVerde.Programacion.RecursosHumanos;

namespace ValleVerde.Vistas
{
    public partial class BuscarCliente : Form
    {
        Validaciones v = new Validaciones();
        ObtenerCliente OC = new ObtenerCliente();
        BuscarEmpleadoyCliente BEC;
        DataTable dt;
        DatosClientes datosCliente;
        public BuscarCliente()
        {
            BEC = new BuscarEmpleadoyCliente(true);
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvBuscarCliente, true, false, 14, 14);
           
        }   

        private void BuscarCliente_Load(object sender, EventArgs e)
        {
            //DataTable dt recibe un metodo de la clase BEC BuscarCliente que es un DataTable
            dt = BEC.BuscarCliente();
            //dt le pasa la tabla al DataGridViewBuscarCliente
            dgvBuscarCliente.DataSource = dt;
            DarFormatoTabla();
        }

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            //Declaramos DataView para ver la tabla de DataTable dt
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("Convert(IDCliente,'System.String') LIKE '%{0}%' OR Nombres LIKE '%{0}%'", txtBuscarCliente.Text);
            dgvBuscarCliente.DataSource = dv;
        }

        public void SeleccionarCliente()
        {
            string idcliente = dgvBuscarCliente.CurrentRow.Cells[0].Value.ToString();
            datosCliente = OC.Obtenercliente(idcliente);
            Close();
        }

        private void dtgBuscarCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarCliente();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            SeleccionarCliente();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        public DatosClientes ObtenerCliente()
        {
            return datosCliente;
        }

        private void txtBuscarCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumerosyLetras(sender, e);
        }

        private void radioClientesActivos_CheckedChanged(object sender, EventArgs e)
        {
            BEC.CambiarFiltroCliente(radioClientesActivos.Checked);
        }
        private void DarFormatoTabla()
        {
            dgvBuscarCliente.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBuscarCliente.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBuscarCliente.Columns[0].Width = 100;
            dgvBuscarCliente.Columns[1].Width = 300;
            dgvBuscarCliente.Columns[2].Width = 300;
            dgvBuscarCliente.Columns[3].Width = 250;
            dgvBuscarCliente.Columns[4].Width = 300;

        }
    }
}
