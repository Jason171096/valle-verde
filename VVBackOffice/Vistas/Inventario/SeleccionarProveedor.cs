using Microsoft.ReportingServices.Diagnostics.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerde
{
    public partial class SeleccionarProveedor : Form
    {
        bool respuestaLista = false;
        List<String> respuestaNombres = null;
        List<String> respuestaIDs = null;

        public SeleccionarProveedor()
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvProveedores, true, false);
           
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            respuestaLista = true;
            this.Close();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count < 1)
            {
                MessageBox.Show("Debes seleccionar un proveedor primero.");
            } else
            {
               
                //Retornarlos para que sean agregados
                respuestaNombres = new List<string>();
                respuestaIDs = new List<string>();

                foreach (DataGridViewRow row in dgvProveedores.SelectedRows)
                {
                    respuestaNombres.Add(Convert.ToString(row.Cells[1].Value));
                    respuestaIDs.Add(Convert.ToString(row.Cells[0].Value));
                }

                respuestaLista = true;
                this.Close();
            }

        }

        public bool RespuestaLista()
        {
            return respuestaLista;
        }

        public List<String> ObtenerRespuestaNombres()
        {
            return respuestaNombres;
        }

        public List<String> ObtenerRespuestaIDs()
        {
            return respuestaIDs;
        }

        private void SeleccionarProveedor_Load(object sender, EventArgs e)
        {

            CargarProveedores();


            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.Focus();
            this.txtBuscar.Select();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var dt = (DataTable)dgvProveedores.DataSource;
                dt.DefaultView.RowFilter = "Nombre LIKE '%" + txtBuscar.Text + "%' or Telefono LIKE '%" + txtBuscar.Text + "%'";
                dgvProveedores.Refresh();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            respuestaLista = true;
            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0} = {1}", "CloseReason", e.CloseReason);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel);
            messageBoxCS.AppendLine();
           // MessageBox.Show(messageBoxCS.ToString(), "FormClosing Event");
        }

        private void CargarProveedores()
        {
            Programacion.Proveedor obp = new Programacion.Proveedor();
            
            List<String[]> res = obp.ObtenerProveedores();

            //dgvProveedores.Rows.Clear();
            dgvProveedores.DataSource = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("No.");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Ciudad");
            dt.Columns.Add("Estado");
            dt.Columns.Add("Telefono");

           
            foreach (String[] proveedor in res)
            {
                dt.Rows.Add(proveedor[0] + "", proveedor[1], proveedor[3], proveedor[4], proveedor[5]);
                //dgvProveedores.Rows.Add(proveedor[0]+"", proveedor[1], proveedor[3], proveedor[4], proveedor[5]);
            }

            dgvProveedores.DataSource = dt;
            dgvProveedores.Columns[0].Width = 50;
            dgvProveedores.Columns[2].Width = 100;
            dgvProveedores.Columns[3].Width = 100;
            dgvProveedores.Columns[4].Width = 100;
            dgvProveedores.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

    }
}
