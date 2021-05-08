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
    public partial class Lineas : Form
    {
        public Lineas()
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dvgLineas,true,false);
            dvgLineas.Columns[0].Width = 50;
            dvgLineas.Columns[3].Width = 100;
            dvgLineas.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }


        private void Lineas_Load(object sender, EventArgs e)
        {
            ActualizarLineas();
        }

        private void ActualizarLineas()
        {
            //Obtener lista de lineas
            Programacion.Lineas ob = new Programacion.Lineas();

            List<String[]> res = ob.ObtenerLineas();

            dvgLineas.Rows.Clear();

            foreach (String[] linea in res)
            {
                //Obtener el numero de productos para cierto fabricante
                int noProd = ob.NoProductosLinea(linea[0]);

                dvgLineas.Rows.Add(linea[0], linea[1], linea[2], string.Format("{0:N}", noProd));
            }
        }

        private void roundedButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                Programacion.Lineas ob = new Programacion.Lineas();
                ob.AltaNuevaLinea(txtNombre.Text, txtDescripcion.Text);

                //Limpiar vista
                txtNombre.Text = "";
                txtDescripcion.Text = "";

                ActualizarLineas();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dvgLineas.SelectedRows.Count != 0)
            {
                //Mandarlo Eliminar
                Programacion.Lineas ob = new Programacion.Lineas();
                int res = ob.EliminarLinea(dvgLineas.SelectedCells[0].Value + "");

                if (res == -1)
                    MessageBox.Show("No puedes eliminar una linea que tenga productos.");

                ActualizarLineas();
            }
            else
            {
                MessageBox.Show("Primero debes seleccionar una linea de la lista.");
            }
        }
    }
}
