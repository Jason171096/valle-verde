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
    public partial class BuscarProductoModificar : Form
    {
        bool mantenerAbierta;
        public void setCodigo(string t)
        {
            textBox4.Text = t;
        }
        public BuscarProductoModificar(bool mantenerAbierta)
        {
            InitializeComponent();
            this.mantenerAbierta = mantenerAbierta;
            textBox4.KeyDown += new KeyEventHandler(tb_KeyDown);
            this.KeyDown += new KeyEventHandler(Eventos_Teclas);
        }

        public void Eventos_Teclas(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.F8:
                    btnBuscar.PerformClick();
                    break;

            }


        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim() != "")
            {
                //Verificar si existe
                ValleVerdeComun.Programacion.Producto ob = new ValleVerdeComun.Programacion.Producto();

                if (ob.ExisteProductoConCodigo(textBox4, true, false, false, "-1"))
                {
                    AltaProducto obj = new AltaProducto(false, textBox4.Text, mantenerAbierta);
                    obj.Text = "Modificar Producto";
                    obj.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No existe el producto");
                    textBox4.SelectAll();
                }
            }
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new ValleVerdeComun.BuscarProducto(textBox4,btnModificar,false).ShowDialog(this);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnModificar.PerformClick();
            }
            else
            {
                if (e.KeyCode == Keys.F8 || e.KeyCode == Keys.Down)
                    btnBuscar.PerformClick();
            }
        }

        public void pulsarModificar()
        {
            btnModificar.PerformClick();
        }

        private void BuscarProductoModificar_Load(object sender, EventArgs e)
        {

        }
    }
}
