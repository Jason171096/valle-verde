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
    public partial class Marcas : Form
    {
        public Marcas()
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dvgMarcas, true, false);
            dvgMarcas.Columns[0].Width = 50;
            dvgMarcas.Columns[3].Width = 100;
            dvgMarcas.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                Programacion.Marcas ob = new Programacion.Marcas();
                ob.AltaNuevaMarca(txtNombre.Text, txtDescripcion.Text);

                //Limpiar vista
                txtNombre.Text = "";
                txtDescripcion.Text = "";

                ActualizarMarcas();
            }
        }

        private void ActualizarMarcas()
        {
            //Obtener lista de fabricantes
            Programacion.Marcas ob = new Programacion.Marcas();

            List<String[]> res = ob.ObtenerMarcas();

            dvgMarcas.Rows.Clear();

            foreach (String[] marca in res)
            {
                //Obtener el numero de productos para cierto fabricante
                int noProd = ob.NoProductosMarca(marca[0]);

                dvgMarcas.Rows.Add(marca[0], marca[1], marca[2], string.Format("{0:N}", noProd));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dvgMarcas.SelectedRows.Count != 0)
            {
                //Mandarlo Eliminar
                Programacion.Marcas ob = new Programacion.Marcas();
                int res = ob.EliminarMarca(dvgMarcas.SelectedCells[0].Value + "");

                if (res == -1)
                    MessageBox.Show("No puedes eliminar una marca que tenga productos.");

                ActualizarMarcas();
            }
            else
            {
                MessageBox.Show("Primero debes seleccionar una marca de la lista.");
            }
        }

        private void Marcas_Load(object sender, EventArgs e)
        {
            ActualizarMarcas();
        }
    }
}
