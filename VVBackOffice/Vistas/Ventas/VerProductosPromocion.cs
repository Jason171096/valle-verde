using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion.Ventas;

namespace ValleVerde.Vistas.Ventas
{
    public partial class VerProductosPromocion : Form
    {
        Promocion promo = new Promocion();
        string idPromocion;
        int tipo;
        DataGridView dgvProductos = new DataGridView();
        
        public VerProductosPromocion(string idPromocion, int tipo)
        {
            InitializeComponent();
            dgvProductos.Size = new Size(panel1.Width,panel1.Height);
            panel1.Controls.Add(dgvProductos);
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvProductos,true,false, 15, 15);
            dgvProductos.RowHeadersVisible = false;
            this.idPromocion = idPromocion;
            this.tipo = tipo;

            LlenarTabla();
        }

        private void LlenarTabla()
        {
            if (tipo == 1) 
            { 
                List<string[]> resProd = promo.ObtenerProductoPromocion(idPromocion);

                dgvProductos.ColumnCount = 2;
                dgvProductos.Columns[0].HeaderText = "Codigo";
                dgvProductos.Columns[0].Visible = true;
                dgvProductos.Columns[0].Frozen = false;

                dgvProductos.Columns[1].HeaderText = "Nombre";
                dgvProductos.Columns[0].Visible = true;
                dgvProductos.Columns[0].Frozen = false;

                foreach (string[] res in resProd)
                {
                    string nombreProd = promo.ObtenerNombreProducto(res[2]);
                    dgvProductos.Rows.Add(res[2], nombreProd);
                }
                dgvProductos.ClearSelection();
            }
            else if (tipo == 2)
            {
                List<string[]> resAdicional = promo.ObtenerProductosAdicionalesPromocion(idPromocion);

                dgvProductos.ColumnCount = 4;
                dgvProductos.Columns[0].HeaderText = "Codigo";
                dgvProductos.Columns[0].Visible = true;
                dgvProductos.Columns[0].Frozen = false;

                dgvProductos.Columns[1].HeaderText = "Nombre";
                dgvProductos.Columns[1].Visible = true;
                dgvProductos.Columns[1].Frozen = false;

                dgvProductos.Columns[2].HeaderText = "Cantidad";
                dgvProductos.Columns[2].Visible = true;
                dgvProductos.Columns[2].Frozen = false;

                dgvProductos.Columns[3].HeaderText = "Descuento";
                dgvProductos.Columns[3].Visible = true;
                dgvProductos.Columns[3].Frozen = false;

                foreach (string[] res in resAdicional)
                {
                    string nombreProd = promo.ObtenerNombreProducto(res[2]);
                    dgvProductos.Rows.Add(res[2], nombreProd, res[4], res[3]);
                }
                dgvProductos.ClearSelection();
            }

        }
    }
}
