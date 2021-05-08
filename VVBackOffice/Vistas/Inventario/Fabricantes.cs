using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ValleVerde
{
    public partial class Fabricantes : Form
    {
        public Fabricantes()
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dvgFabricantes, true, false);
            dvgFabricantes.Columns[0].Width = 50;
            dvgFabricantes.Columns[3].Width = 100;
            dvgFabricantes.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Fabricantes_Load(object sender, EventArgs e)
        {
            ActualizarFabricantes();


        }

        private void ActualizarFabricantes()
        {
            //Obtener lista de fabricantes
            Programacion.Fabricantes ob = new Programacion.Fabricantes();

            List<String[]> res = ob.ObtenerFabricantes();

            dvgFabricantes.Rows.Clear();

            foreach (String[] fabricante in res)
            {
                //Obtener el numero de productos para cierto fabricante
                int noProd = ob.NoProductosFabricante(fabricante[0]);

                dvgFabricantes.Rows.Add(fabricante[0], fabricante[1], fabricante[2], string.Format("{0:N}", noProd));
            }
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text!="")
            {
                Programacion.Fabricantes ob = new Programacion.Fabricantes();
                ob.AltaNuevo(txtNombre.Text,txtDescripcion.Text);

                //Limpiar vista
                txtNombre.Text = "";
                txtDescripcion.Text = "";

                ActualizarFabricantes();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dvgFabricantes.SelectedRows.Count != 0)
            {
                //Mandarlo Eliminar
                Programacion.Fabricantes ob = new Programacion.Fabricantes();
                int res = ob.EliminarFabricante(dvgFabricantes.SelectedCells[0].Value+"");

                if(res==-1)
                    MessageBox.Show("No puedes eliminar un fabricante que tenga productos.");

                ActualizarFabricantes();
            }
            else
            {
                MessageBox.Show("Primero debes seleccionar un fabricante de la lista.");
            }
        }
    }
}
