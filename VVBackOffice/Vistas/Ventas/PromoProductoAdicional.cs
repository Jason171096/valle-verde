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
    public partial class PromoProductoAdicional : Form
    {
        Button boton = new Button();
        Promocion obpromo = new Promocion();
        List<string[]> list = new List<string[]>();
        public PromoProductoAdicional(List<string []> list)
        {
            InitializeComponent();
            
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvAdicional, true, false, 15, 15);
            boton.Click += new System.EventHandler(this.boton_Click);
            this.list = list;
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            new ValleVerdeComun.BuscarProducto(textAdicional, boton, false).ShowDialog(this);
        }

        private void boton_Click(object sender, EventArgs e)
        {
            textNombre.Text = obpromo.ObtenerNombreProducto(textAdicional.Text) + "";
        }
        

        private void anadir_Click(object sender, EventArgs e)
        {
            int i = 0;
            bool ban = false;
            if (dgvAdicional.Rows.Count <= 0)
            {
                dgvAdicional.Rows.Add(textAdicional.Text, textNombre.Text, textCantidad.Text, textDescuento.Text);
            }
            else
            {
                while (i < dgvAdicional.Rows.Count)
                {
                    if (dgvAdicional.Rows[i].Cells[0].Value.ToString() == textAdicional.Text)
                    {
                        MessageBox.Show("No se puede agregar el mismo producto");
                        ban = false;
                        break;
                    }
                    else
                    {
                        ban = true;
                    }
                    i++;
                }
                if (ban)
                {
                    dgvAdicional.Rows.Add(textAdicional.Text, textNombre.Text, textCantidad.Text, textDescuento.Text);
                }
            }
            textAdicional.Text = "";
            textNombre.Text = "";
            textCantidad.Text = "1";
            textDescuento.Text = "100";
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvAdicional.Rows.Count; i++)
            {                
                list.Add(new String[] { dgvAdicional.Rows[i].Cells[0].Value.ToString(), dgvAdicional.Rows[i].Cells[1].Value.ToString(), dgvAdicional.Rows[i].Cells[2].Value.ToString(), dgvAdicional.Rows[i].Cells[3].Value.ToString() });                
            }
            this.Dispose();
        }
    }
}
