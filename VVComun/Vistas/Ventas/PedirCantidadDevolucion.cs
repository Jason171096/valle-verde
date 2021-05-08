using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerdeComun.Vistas
{
    public partial class PedirCantidadDevolucion : Form
    {
        public decimal cantidadDevolver = 0;
        public PedirCantidadDevolucion()
        {
            InitializeComponent();
           
        }

        private void PedirCantidadDevolucion_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtCantidad;
            txtCantidad.SelectAll();
        }

        public void setDatos(decimal cantDisponible)
        {
            if (cantDisponible % 1 == 0)
                txtDisponible.Text = decimal.ToInt32(cantDisponible)+"";
            else
                txtDisponible.Text =  cantDisponible +"";

            txtCantidad.Text = txtDisponible.Text;
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (decimal.Parse(txtCantidad.Text) <= decimal.Parse(txtDisponible.Text))
                {
                    cantidadDevolver = decimal.Parse(txtCantidad.Text);
                    this.Close();
                }
                else
                {
                    txtCantidad.SelectAll();
                }
            }
            catch { }

           
        }
    }
}
