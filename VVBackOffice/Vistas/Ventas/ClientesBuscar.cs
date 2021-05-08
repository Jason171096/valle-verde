using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion;
using ValleVerde.Programacion.Ventas;
using ValleVerdeComun.Programacion.Huellas;

namespace ValleVerde
{
    public partial class ClientesBuscar : Form
    {
        public string idCliente;
        public string cliente;

        public string idUsuario;
        public string nombreU;
        
        BuscarClientes ob = new BuscarClientes();
        public ClientesBuscar()
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvClientes, true, false);
        }

        public void datosUsuario(string idUsuario, string nombre)
        {
            this.idUsuario = idUsuario;
            this.nombreU = nombre;
        }

        private void ClientesBuscar_Load(object sender, EventArgs e)
        {
            List<string[]> res = ob.Clientes(textBuscar.Text);
            LlenarTabla(res);
        }

        private void LlenarTabla(List<string[]> res)
        {
            dgvClientes.Rows.Clear();
            string act = "No";

            foreach (string[] fila in res)
            {
                if(fila[5]=="True")
                {
                    act = "Si";
                }
                dgvClientes.Rows.Add(fila[0],fila[1], fila[2], fila[3], fila[4], act);
            }
            dgvClientes.ClearSelection();
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string IDCliente = dgvClientes.CurrentRow.Cells[0].Value.ToString();
            string nombre = dgvClientes.CurrentRow.Cells[1].Value.ToString(); ;

            CreditosVer cv = new CreditosVer(IDCliente, nombre, idUsuario, nombreU);
            cv.Show();
            this.Close();
        }

        private void textBuscar_TextChanged(object sender, EventArgs e)
        {
            List<string[]> res = ob.Clientes(textBuscar.Text);
            LlenarTabla(res);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string IDCliente = dgvClientes.CurrentRow.Cells[0].Value.ToString();
            string nombre = dgvClientes.CurrentRow.Cells[1].Value.ToString(); ;

            CreditosVer cv = new CreditosVer(IDCliente, nombre, idUsuario, nombreU);
            cv.Show();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
