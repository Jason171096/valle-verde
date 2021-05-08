using System;
using System.Windows.Forms;
using ValleVerde.Programacion;

namespace ValleVerde.Vistas
{
    public partial class ImprimirEtiquetasProducto : Form
    {
        ValleVerdeComun.Programacion.ConfiguracionBO configuracion;
        ImpresoraEtiquetas impresora = new ImpresoraEtiquetas();
        Validaciones v = new Validaciones();
        ValleVerdeComun.BuscarProducto buscar;
        private bool TipoEtiqueta;//Booleano para saber el tipo de etiqueta que se va imprimir
        private bool SiseImprimio;
        public ImprimirEtiquetasProducto(bool imprimirConPrecio, ValleVerdeComun.Programacion.ConfiguracionBO configuracion)
        {
            InitializeComponent();
            txtCodigo.TabIndex = 0;
            this.configuracion = configuracion;
            this.TipoEtiqueta = imprimirConPrecio;
            if (imprimirConPrecio)//Si el bool es True se sabe que se debe imprimir etiqueta con precio
            {
                Text = "Imprimir Etiquetas con Precio";
                checkFecha.Visible = false;
            }
            else
                Text = "Imprimir Etiquetas sin Precio";
        }

        private void btnEtiqueta_Click(object sender, EventArgs e)
        {
            //Previene si los textbox estan vacios
            string cantidad = txtCantidad.Text;
            if (String.IsNullOrWhiteSpace(txtCantidad.Text) || String.IsNullOrWhiteSpace(txtCodigo.Text))
                MessageBox.Show("Los campos no pueden estar vacios", "¡ADVERTENCIA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (Convert.ToInt32(cantidad) > 100)
                cantidad = "1";
            else
            {
                int intcantidad = Convert.ToInt32(cantidad);
                //Cantidad de veces que va a llamar el metodo SendZplOverUsb

                //IMPORTANTE El nombre de la impresora tiene que cambiar para cada dispositivo que desea instalar el BackOffice
                SiseImprimio = impresora.SendZplOverUsb(configuracion.ImpresoraEtiquetas, txtCodigo.Text, TipoEtiqueta, intcantidad, false, false, checkFecha.Checked);
            }
            txtCantidad.Text = "1";
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validacion y cuando se presiona una tecla este activa el evento del boton
            v.SoloNumeros(e);
            if (e.KeyChar == (char)13)
            {
                btnEtiqueta.PerformClick();
                txtCodigo.SelectAll();
                txtCantidad.Text = "1";
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            //Pasa el foco al txtCodigo
            if (e.KeyCode == Keys.Enter)
            {
                btnEtiqueta.PerformClick();
                txtCodigo.SelectAll();
            }
            else if (e.KeyCode == Keys.F8 || e.KeyCode == Keys.Down)
            {
                buscar = new ValleVerdeComun.BuscarProducto(txtCodigo, btnEtiqueta, false);
                buscar.ShowDialog();
                if(SiseImprimio)
                {
                    txtCodigo.Focus();
                    txtCodigo.SelectAll();
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar = new ValleVerdeComun.BuscarProducto(txtCodigo, btnEtiqueta, false);
            buscar.ShowDialog();
            if(SiseImprimio)
            {
                txtCodigo.Focus();
                txtCodigo.SelectAll();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
