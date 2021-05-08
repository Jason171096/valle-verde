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
    public partial class ClaveSAT : Form
    {
        bool respuestaLista = false;
        string []res=new string[2];

        public bool RespuestaLista()
        {
            return respuestaLista;
        }

        public string[] ObtenerRespuesta()
        {
            return res;
        }


        public ClaveSAT()
        {
            InitializeComponent();
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            //Darla de alta, si todo sale bien regresar 1

            respuestaLista = true;
            
            this.Dispose();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            respuestaLista = true;
            res[0] = "";
            res[1] = "";
            this.Dispose();
        }

        private void ClaveSAT_Load(object sender, EventArgs e)
        {
            CargarClavesSAT();

            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
        }

        public void CargarClavesSAT()
        {
            // Configurar tabla
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dvgClaves, true, false, 15, 15);

            //Obtener claves
            List<string[]> clavesSAT = new ValleVerdeComun.Programacion.ClavesSAT().ObtenerClavesSAT();

            //Llenar tabla
            DataTable dt = new DataTable();
            dt.Columns.Add("Clave");
            dt.Columns.Add("Descripcion");


            foreach (String[] claveSAT in clavesSAT)
            {
                dt.Rows.Add(claveSAT[0], claveSAT[1]);
            }
            dvgClaves.DataSource = dt;

            //id
            dvgClaves.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dvgClaves.Columns[0].Width = 100;

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var dt = (DataTable)dvgClaves.DataSource;
                dt.DefaultView.RowFilter = "Clave LIKE '%" + txtBuscar.Text + "%' or Descripcion LIKE '%" + txtBuscar.Text + "%'";
                dvgClaves.Refresh();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
        }

        private void btnNuevaClaveSAT_Click(object sender, EventArgs e)
        {
            if (txtClave.Text != "" && txtDescripcion.Text != "")
            {
                ValleVerdeComun.Programacion.ClavesSAT obj = new ValleVerdeComun.Programacion.ClavesSAT();

                int r = obj.AltaNuevaClaveSAT(txtClave.Text, txtDescripcion.Text);

                if (r == 1)
                {
                    res[0] = txtClave.Text;
                    res[1] = txtDescripcion.Text;
                }
                else
                {
                    res[0] = "";
                    res[1] = "";
                }
                respuestaLista = true;

                this.Dispose();
            }
        }

        private void dataGridView1_ContentChanged(object sender, EventArgs e)
        {
            if (dvgClaves.SelectedRows.Count > 0)
            {
                res[0] = dvgClaves.SelectedRows[0].Cells[0].Value + "";
                res[1] = dvgClaves.SelectedRows[0].Cells[1].Value + "";
            }
        }

        private void dvgClaves_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void claveSATBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
