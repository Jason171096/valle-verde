using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerdeComun.Programacion;

namespace ValleVerdeComun.Vistas
{
    public partial class BuscarCliente : Form
    {
        ValleVerdeComun.Programacion.Cliente cliente;
        List<ValleVerdeComun.Programacion.Cliente> clientes;
        bool debeTenerCredito;

        public BuscarCliente(bool debeTenerCredito)
        {
            InitializeComponent();
            this.debeTenerCredito = debeTenerCredito;
            txtBuscar.KeyDown += new KeyEventHandler(tb_KeyDown);
            dgvClientes.KeyDown += new KeyEventHandler(tb_KeyDown2);
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                btnAsignar.PerformClick();
            }
            else
            if (e.KeyCode == Keys.Up)
            {

                int index = dgvClientes.SelectedRows[0].Index;
                if (index > 0)
                    dgvClientes.Rows[index - 1].Selected = true;
            }
            else
            {
                if (e.KeyCode == Keys.Down)
                {
                    int index = dgvClientes.SelectedRows[0].Index;
                    if (index < dgvClientes.Rows.Count - 1)
                        dgvClientes.Rows[index + 1].Selected = true;
                }
            }


        }

        private void tb_KeyDown2(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                btnAsignar.PerformClick();
            }

        }

        private void BuscarCliente_Load(object sender, EventArgs e)
        {
            CargarClientes();
            this.ActiveControl = txtBuscar;
            txtBuscar.SelectAll();
        }

        public void CargarClientes()
        {
            // Configurar tabla
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvClientes, true, false, 15, 15);
            
            //Obtener clientes
            clientes = new ValleVerdeComun.Programacion.Clientes().ObtenerClientes(debeTenerCredito);

            //Llenar tabla
            DataTable dt = new DataTable();
            dt.Columns.Add("No.Cliente");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Apellidos");
            dt.Columns.Add("Direccion");
            dt.Columns.Add("Telefono");
            dt.Columns.Add("Correo");
            dt.Columns.Add("R.F.C.");


            foreach (ValleVerdeComun.Programacion.Cliente cliente in clientes)
            {
                dt.Rows.Add(cliente.idCliente,cliente.nombre, cliente.apellidos, cliente.direccion, cliente.telefono, cliente.correos.Count > 0 ? cliente.correos[0] : "", cliente.rfc);
            }
            dgvClientes.DataSource = dt;

            //id
            dgvClientes.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvClientes.Columns[0].Width = 50;
            dgvClientes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvClientes.DefaultCellStyle.WrapMode = DataGridViewTriState.True;


        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public ValleVerdeComun.Programacion.Cliente ObtenerCliente()
        {
            return cliente;
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if(dgvClientes.Rows.Count > 0)
            {
                if(dgvClientes.SelectedRows.Count > 0)
                {
                    //Buscar el cliente en clientes por si id
                    foreach(Cliente cliente in clientes)
                    {
                        if (cliente.idCliente == dgvClientes.SelectedRows[0].Cells[0].Value + "")
                        {
                            this.cliente = cliente;
                            break;
                        }
                    }
                    
                }
            }
            this.Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var dt = (DataTable)dgvClientes.DataSource;
                dt.DefaultView.RowFilter = "No.Cliente LIKE '%" + txtBuscar.Text + "%' or Nombre LIKE '%" + txtBuscar.Text + "%' or Apellidos LIKE '%" + txtBuscar.Text + "%' or Direccion LIKE '%" + txtBuscar.Text + "%' or Telefono LIKE '%" + txtBuscar.Text + "%' or Correo LIKE '%" + txtBuscar.Text + "%'";
                dgvClientes.Refresh();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
        }
    }
}
