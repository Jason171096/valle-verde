using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ValleVerde.Vistas.Compras
{
    public partial class ComprasSugeridas : Form
    {
        Programacion.Compra.Compras objCom = new Programacion.Compra.Compras();
        double sub = 0.0, imp = 0.0, tot = 0.0;
        bool habilitadoSelectionChanged = true, habilitadoCellValueChanged = true;

        public ComprasSugeridas()
        {
            InitializeComponent();
        }

        private void ComprasSugeridas_Load(object sender, EventArgs e)
        {
            datGriVieProv.SelectionChanged += new EventHandler(datGriVieProv_SelectionChanged);
            datGriVieProd.CellValueChanged += new DataGridViewCellEventHandler(datGriVieProd_CellValueChanged);
            ActualizarProveedoresMejoresPrecios();
        }

        private void datGriVieProd_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(habilitadoCellValueChanged)
                ActualizarProductoMejorPrecio(datGriVieProv.SelectedRows[0].Cells[1].Value + "", double.Parse(datGriVieProd.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + ""), e.RowIndex);
        }

        private void ActualizarProductoMejorPrecio(string idProd, double nueCan, int indRen)
        {
            tot = 0.0;

            if(nueCan == 0.0)
            {
                datGriVieProd.Rows[indRen].Selected = true;
                datGriVieProd.ClearSelection();
                objCom.EliminarProductoMejorPrecio(idProd);
            }
            else
                objCom.ActualizarProductoMejorPrecio(idProd, nueCan);

            foreach (string[] prod in datGriVieProd.Rows)
            {
                tot += double.Parse(prod[0]) * double.Parse(prod[3]);
            }

            labTot.Text = string.Format("{0:c}", Convert.ToDecimal(tot));
        }

        private void ActualizarProveedoresMejoresPrecios()
        {
            habilitadoSelectionChanged = false;

            datGriVieProv.Rows.Clear();

            List<string[]> proveedores = objCom.ObtenerProveedoresMejoresPrecios();

            foreach (string[] proveedor in proveedores)
                datGriVieProv.Rows.Add(new string[] { proveedor[0], proveedor[1], proveedor[2] });

            datGriVieProv.ClearSelection();
            habilitadoSelectionChanged = true;

            if (datGriVieProv.Rows.Count != 0)
                datGriVieProv.Rows[0].Selected = true;
        }

        private void datGriVieProv_SelectionChanged(object sender, EventArgs e)
        {
            if(habilitadoSelectionChanged)
            {
                ActualizarProductosMejoresPrecios();
            }
        }

        private void ActualizarProductosMejoresPrecios()
        {
            habilitadoCellValueChanged = false;

            long idCot = long.Parse(datGriVieProv.SelectedRows[0].Cells[0].Value + "");

            List<String[]> productos = objCom.ObtenerProductosMejoresPrecios(idCot);

            datGriVieProd.Rows.Clear();
            sub = 0.0;
            imp = 0.0;
            tot = 0.0;

            foreach (string[] producto in productos)
            {
                if (producto[1].Equals(""))
                    producto[3] = producto[6] + "s de " + producto[3];
                else
                {
                    producto[3] = producto[2] + " cajas de " + producto[7] + " " + producto[6].ToLower() + "s de " + producto[3];
                    producto[2] = (decimal.Parse(producto[2]) * decimal.Parse(producto[7])).ToString();
                    producto[4] = (decimal.Parse(producto[4]) / decimal.Parse(producto[7])).ToString();
                }
                    datGriVieProd.Rows.Add(new string[] { producto[0], producto[1], producto[2], producto[3], producto[4], producto[5] });
                    tot += double.Parse(producto[2]) * double.Parse(producto[4]);
            }

            habilitadoCellValueChanged = true;

            sub = tot / 1.16;
            imp = (sub / 100) * 16;

            labSub.Text = string.Format("{0:c}", Convert.ToDecimal(sub));
            labImp.Text = string.Format("{0:c}", Convert.ToDecimal(imp));
            labTot.Text = string.Format("{0:c}", Convert.ToDecimal(tot));
        }

        private void butDes_Click(object sender, EventArgs e)
        {
            LimpiarVentana();
            objCom.EliminarCotizacion(long.Parse(datGriVieProv.SelectedRows[0].Cells[0].Value + ""));
            ActualizarProveedoresMejoresPrecios();
        }

        private void LimpiarVentana()
        {
            habilitadoSelectionChanged = false;
            datGriVieProv.Rows.Clear();
            datGriVieProd.Rows.Clear();
            habilitadoSelectionChanged = true;
        }

        private void butConGenPed_Click(object sender, EventArgs e)
        {
            objCom.GenerarPedido(long.Parse(datGriVieProv.SelectedRows[0].Cells[0].Value + ""), -1, sub, imp, tot);

            ActualizarProveedoresMejoresPrecios();
            //new Vistas.Compras.Ordenes().Show();
            //Close();
        }
    }
}
