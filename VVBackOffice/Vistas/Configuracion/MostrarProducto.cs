using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerde.Vistas.Configuracion
{
    public partial class MostrarProducto : Form
    {
        int id,op;
        List<string[]> mostrarProductos = new List<string[]>();
        public MostrarProducto(int id, List<string[]> mostrarProductos, int op)
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvProductos, true, false);
            dgvProductos.MultiSelect = true;
            this.id = id;
            this.mostrarProductos = mostrarProductos;
            this.op = op;
        }

        private void MostrarProducto_Load(object sender, EventArgs e)
        {
            LlenarTabla();
        }

        private void LlenarTabla()
        {
            List<string[]> resProd = new List<string[]>();
            ValleVerdeComun.Programacion.Producto ob = new ValleVerdeComun.Programacion.Producto();
            switch (op)
            {
                case 1:
                    resProd = ob.ObtenerProductos(id, -1, -1, -1, -1, false, -1, -1, "", false);
                    break;
                case 2:
                    resProd = ob.ObtenerProductos(-1, id, -1, -1, -1, false, -1, -1, "", false);
                    break;
                case 3:
                    resProd = ob.ObtenerProductos(-1, -1, -1, id, -1, false, -1, -1, "", false);
                    break;
                case 4:
                    resProd = ob.ObtenerProductos(-1, -1, id, -1, -1, false, -1, -1, "", false);
                    break;
            }

            dgvProductos.Rows.Clear();
            foreach (string[] producto in resProd)
            {
                dgvProductos.Rows.Add(producto[0], producto[1], false);
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.CurrentRow.Cells[2].Value.ToString() == "True")
            {
                dgvProductos.CurrentRow.Cells[2].Value = false;
            }
            else
            {
                dgvProductos.CurrentRow.Cells[2].Value = true;
            }
            
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.Rows.Count > 0) 
            {
                for (int i = 0; i < dgvProductos.Rows.Count; i++)
                {
                    if (dgvProductos.Rows[i].Cells[2].Value.ToString() == "True")
                    {
                        mostrarProductos.Add(new String[] { dgvProductos.Rows[i].Cells[0].Value.ToString(), dgvProductos.Rows[i].Cells[1].Value.ToString() });

                    }
                }
                Dispose();
            }
        }
    }
}
