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
    public partial class AvisoProveedorNoVendeProducto : Form
    {
        public bool usuDesCon;

        public AvisoProveedorNoVendeProducto(byte sit)
        {
            InitializeComponent();
            switch (sit)
            {
                case 0:
                    //Estamos hablando de compras
                    label1.Text = "El producto no está en la lista de los productos que vende el proveedor. Si continúa y finaliza la compra, este producto se añadirá a la lista, ¿desea continuar?";
                    break;
                case 1:
                    //Estamos hablando de cotizacion, antes de generar el Excel
                    label1.Text = "El producto no está en la lista de los productos que vende el proveedor. Si continúa y genera la lista en Excel, este producto se añadirá a la lista, ¿desea continuar?";
                    break;
            }
        }

        private void si_Click(object sender, EventArgs e)
        {
            usuDesCon = true;
            Close();
        }

        private void no_Click(object sender, EventArgs e)
        {
            usuDesCon = false;
            Close();
        }
    }
}
