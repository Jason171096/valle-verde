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
using ValleVerde.valleverdeDataSetTableAdapters;

namespace ValleVerde.Vistas.Inventario
{
    public partial class VerProductosPrecapturados : Form
    {
        ValleVerdeComun.Programacion.Producto ob = new ValleVerdeComun.Programacion.Producto();

        public VerProductosPrecapturados()
        {
            InitializeComponent();
            dgvProductos.SelectionChanged += new EventHandler(SelectionChanged);

            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvProductos, true, false);
            dgvProductos.Columns[0].Width = 160;
        }

        private void VerProductosPrecapturados_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            List<string[]> res = ob.ObtenerProductosPrecapturados();

            dgvProductos.Rows.Clear();

            foreach(string[] producto in res){
                dgvProductos.Rows.Add(producto[0], producto[1], producto[2]);
            }

        }

        private void SelectionChanged(object sender, EventArgs e)
        {

            //cambiar la imagen si el producto tiene
            // MessageBox.Show("Mostrando la imagen para " + dvgProductos.SelectedRows[0].Cells[0].Value);

            if (dgvProductos.SelectedRows.Count != 0)
            {
                string codigo = dgvProductos.SelectedRows[0].Cells[0].Value + "";

                txtNombre.Text = dgvProductos.SelectedRows[0].Cells[1].Value + "";
                txtFabricante.Text = new ValleVerde.Programacion.Fabricantes().ObtenerFabricanteProducto(codigo)[1];
                txtMarca.Text = new ValleVerde.Programacion.Marcas().ObtenerMarcaProducto(codigo)[1];
                txtLinea.Text = new ValleVerde.Programacion.Lineas().ObtenerLineaProducto(codigo)[1];

                int cant = ob.ObtenerCantidadImagenesProducto(codigo);
                if (cant > 0)
                {


                    try
                    {
                       
                        pictureBoxP.Image = ob.ObtenerImagenesProducto(dgvProductos.SelectedRows[0].Cells[0].Value + "")[0];
                    }
                    catch
                    {
                        pictureBoxP.Image = Properties.Resources.unknown;
                    }

                }
                else
                {
                    pictureBoxP.Image = Properties.Resources.unknown;
                }

                
            }
            else
            {
                txtNombre.Text =  "";
                txtFabricante.Text = "";
                txtMarca.Text ="";
                txtLinea.Text = "";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(dgvProductos.SelectedRows.Count != 0)
            {
                new AltaProducto(false,dgvProductos.SelectedRows[0].Cells[0].Value+"",false).ShowDialog();

                //Guardar la posicionde scroll

                int i = 0;

                if(dgvProductos.SelectedRows.Count > 0)
                    i = dgvProductos.SelectedRows[0].Index;

                CargarProductos();

                if (dgvProductos.Rows.Count > 0)
                {
                    if (i >= dgvProductos.Rows.Count)
                        i = dgvProductos.Rows.Count - 1;
                    dgvProductos.CurrentCell = dgvProductos.Rows[i].Cells[0];
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}
