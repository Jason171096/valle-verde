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
    public partial class Unidades : Form
    {
        List<String> dvgUnidadesCP;
        public Unidades()
        {
            dvgUnidadesCP = new List<String>();
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dvgUnidades, true, false);
            dvgUnidades.Columns[0].Width = 50;
            dvgUnidades.Columns[2].Width = 100;
        }

        private void Unidades_Load(object sender, EventArgs e)
        {
            ActualizarUnidades();
        }

        private void ActualizarUnidades()
        {
            //Obtener lista de fabricantes
            Programacion.Unidades ob = new Programacion.Unidades();

            List<String[]> res = ob.ObtenerUnidades();

            dvgUnidades.Rows.Clear();
            dvgUnidadesCP.Clear();

            foreach (String[] fabricante in res)
            {
                dvgUnidadesCP.Add(fabricante[0]);
                dvgUnidades.Rows.Add(fabricante[1], fabricante[2], fabricante[3]);
            }
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                Programacion.Unidades ob = new Programacion.Unidades();
                ob.AltaNuevaUnidad(txtNombre.Text, txtDescripcion.Text, txtClaveSat.Text);

                //Limpiar vista
                txtNombre.Text = "";
                txtDescripcion.Text = "";
                txtClaveSat.Text = "";

                ActualizarUnidades();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dvgUnidades.SelectedRows.Count != 0)
            {
                //Mandarlo Eliminar
                Programacion.Unidades ob = new Programacion.Unidades();
                int res = ob.EliminarUnidad(dvgUnidadesCP[dvgUnidades.SelectedCells[0].RowIndex] + "");

                if (res == -1)
                    MessageBox.Show("No puedes eliminar un fabricante que tenga productos.");

                ActualizarUnidades();
            }
            else
            {
                MessageBox.Show("Primero debes seleccionar un fabricante de la lista.");
            }
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            //Buscar CLave del Sat en Archivo de Ex
        }
    }
}
