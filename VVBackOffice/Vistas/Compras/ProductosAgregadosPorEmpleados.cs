using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ValleVerde.Vistas.Compras
{
    public partial class ProductosAgregadosPorEmpleados : Form
    {
        Programacion.Compra.Compras objCom = new Programacion.Compra.Compras();
        public ProductosAgregadosPorEmpleados()
        {
            InitializeComponent();

            //new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgv, false, false);
        }

        private void ProductosAgregadosPorEmpleados_Load(object sender, EventArgs e)
        {
            List<object[]> productos = objCom.ObtenerProductosACotizar(false);

            for(int i = 0; i < productos.Count; i++)
            {
                dgv.Rows.Add(new object[] { productos[i][0], productos[i][1], productos[i][3], productos[i][4], productos[i][5], productos[i][6], productos[i][8], "", productos[i][9], productos[i][10], productos[i][11], productos[i][12], productos[i][14], productos[i][13] });
            }

            dgv.CellValueChanged += new DataGridViewCellEventHandler(dgv_CellValueChanged);
        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                objCom.ActualizarProductoNoAutorizado(long.Parse(dgv.Rows[e.RowIndex].Cells[0].Value.ToString()), bool.Parse(dgv.Rows[e.RowIndex].Cells[13].Value.ToString()));
            }
        }

        private void aut_Click(object sender, EventArgs e)
        {
            objCom.AutorizarProductosCotizacion();
            Close();
        }
    }
}
