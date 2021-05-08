using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerde.Vistas.Compras
{
    public partial class ElegirProveedores : Form
    {
        Programacion.Compra.Compras objCom = new Programacion.Compra.Compras();

        public ElegirProveedores()
        {
            InitializeComponent();
        }

        private void ElegirProveedores_Load(object sender, EventArgs e)
        {
            List<string[]> productosRepetidos = objCom.ObtenerTodosProductosCotizacionesRecibidas();
            DataGridViewCheckBoxCell checkBox = null;

            foreach (string[] producto in productosRepetidos)
            {
                if (datGriVieProd.Rows.Count > 0)
                    if (producto[2].Equals(datGriVieProd.Rows[datGriVieProd.Rows.Count - 1].Cells[2].Value.ToString()))
                    {
                        AgregarProducto(producto);
                        checkBox = (DataGridViewCheckBoxCell)datGriVieProd.Rows[datGriVieProd.Rows.Count - 1].Cells[5];
                        checkBox.Value = false;
                    }
                    else
                    {
                        AgregarProducto(producto);
                        checkBox = (DataGridViewCheckBoxCell)datGriVieProd.Rows[datGriVieProd.Rows.Count - 1].Cells[5];
                        checkBox.Value = true;
                    }
                else
                {
                    AgregarProducto(producto);
                    checkBox = (DataGridViewCheckBoxCell)datGriVieProd.Rows[datGriVieProd.Rows.Count - 1].Cells[5];
                    checkBox.Value = true;
                }
            }
        }

        private void AgregarProducto(string[] producto)
        {
            if (producto[1].Equals(""))
                datGriVieProd.Rows.Add(new string[] { producto[0], producto[1], producto[2], producto[3], string.Format("{0:c}", Convert.ToDecimal(producto[4])) + " - " + producto[5] });
            else
            {
                producto[3] = "Caja con " + producto[6] + " " + producto[7].ToLower() + "s de " + producto[3];
                producto[4] = string.Format("{0:c}", decimal.Parse(producto[4]) / decimal.Parse(producto[6])) + " - " + producto[5];
                datGriVieProd.Rows.Add(new string[] { producto[0], producto[1], producto[2], producto[3], producto[4] });
            }
        }

        private void butCon_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow renglon in datGriVieProd.Rows)
            {
                if (!bool.Parse((renglon.Cells[5] as DataGridViewCheckBoxCell).Value.ToString()))
                    objCom.EliminarProductoCotizacionRecibida(long.Parse(renglon.Cells[0].Value.ToString()), renglon.Cells[1].Value.ToString(), renglon.Cells[2].Value.ToString());
            }

            foreach(DataGridViewRow renglon in datGriVieProd.Rows)
                objCom.MarcarMejorPrecio(long.Parse(renglon.Cells[0].Value.ToString()));

            new Compras.ComprasSugeridas().Show();
            this.Close();
        }
    }
}
