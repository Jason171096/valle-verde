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
    public partial class Almacenes : Form
    {
        public Almacenes()
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dvgAlmacenes, true, false);
            dvgAlmacenes.Columns[0].Width = 50;
            dvgAlmacenes.Columns[2].Width = 100;
            dvgAlmacenes.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void Almacenes_Load(object sender, EventArgs e)
        {
            ActualizarAlmacenes();
        }

        private void ActualizarAlmacenes()
        {
            //Obtener lista de fabricantes
            Programacion.Almacenes ob = new Programacion.Almacenes();

            List<String[]> res = ob.ObtenerAlmacenes();

            dvgAlmacenes.Rows.Clear();

            foreach (String[] almacen in res)
            {
                //Obtener el numero de productos para cierto fabricante
                decimal noProd = ob.NoProductosAlmacen(almacen[0]);

                dvgAlmacenes.Rows.Add(almacen[0], almacen[1], string.Format("{0:N}",noProd));
            }
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                Programacion.Almacenes ob = new Programacion.Almacenes();
                ob.AltaNuevoAlmacen(txtNombre.Text, "1");

                //Limpiar vista
                txtNombre.Text = "";

                ActualizarAlmacenes();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dvgAlmacenes.SelectedRows.Count != 0)
            {
                //Mandarlo Eliminar
                Programacion.Almacenes ob = new Programacion.Almacenes();
                int res = ob.EliminarAlmacen(dvgAlmacenes.SelectedCells[0].Value + "");

                if (res == -1)
                    MessageBox.Show("No puedes eliminar un almacen que tenga productos.");

                ActualizarAlmacenes();
            }
            else
            {
                MessageBox.Show("Primero debes seleccionar un almacen de la lista.");
            }
        }
    }
}
