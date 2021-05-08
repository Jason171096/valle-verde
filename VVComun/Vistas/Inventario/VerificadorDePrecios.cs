using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerdeComun
{
    public partial class VerificadorDePrecios : Form
    {
        Array[] precios;
        Vistas.Inventario.Precios objPrecios = new Vistas.Inventario.Precios();
        Programacion.Precios obp = new Programacion.Precios();
        bool ventanaSecundaria = false;
        Form parentSecundaria;
        Vistas.Inventario.ImagenFlotante obi;
        AxOposScanner_CCO.AxOPOSScanner OPOSScanner;

        public VerificadorDePrecios()
        {
            InitializeComponent();
            txtCodigo.KeyDown += new KeyEventHandler(tb_KeyDown);
            this.FormClosing += Form_Closing;
            this.KeyDown += new KeyEventHandler(Eventos_Teclas);
        }

        private void VerificadorDePrecios_Load(object sender, EventArgs e)
        {
            TextBox t = new TextBox();
            objPrecios.ConfigurarPanelPrecios(ref tablePrecios, ref t, ref precios, true);
           
            if(ventanaSecundaria)
            {
                obi = new Vistas.Inventario.ImagenFlotante();
                obi.setImagenFlotante(ObtenerPanelPrecios());
                obi.Show(parentSecundaria);
            }
        }

        private void Form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (obi != null)
            {
                obi.Close();
                obi.Dispose();
            }
        }

        public void Eventos_Teclas(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.F8:
                    btnBuscar.PerformClick();
                    break;
                
            }


        }
        private void roundedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                //Checar si es un codigo con la estructura de la bascula, si es asi
                //y el producto existe sustituir txtCodigoEvento.Text y cantAgregar
                //para que se agrege, si no dejarlo asi para tratar de agregarlo normal


                if (txtCodigo.Text.Length > 1)
                    if (txtCodigo.Text.Substring(0, 2) == "28" && txtCodigo.Text.Length == 13)
                        if (new Vistas.Inventario.CheckDigit().Check(txtCodigo.Text, true) == txtCodigo.Text)
                        {
                            txtCodigo.Text = txtCodigo.Text.Substring(2, 5);
                        
                        }


                Programacion.Producto ob = new Programacion.Producto();
                if (ob.ExisteProductoConCodigo(txtCodigo,false,true,false,"-1"))
                {
                    txtCodigo.Focus();
                    string codigo = txtCodigo.Text;

                    int cant = ob.ObtenerCantidadImagenesProducto(codigo);
                    if (cant > 0)
                        try
                        {
                            //pictureBox1.Image = Image.FromFile(ob.ObtenerImagenesProducto(codigo)[0]);
                            pictureBox1.Image = ob.ObtenerImagenesProducto(codigo)[0];
                        }
                        catch { }
                    else
                        pictureBox1.Image = null;

                    txtNombre.Text = ob.ObtenerNombreProducto(codigo);

                    decimal existencia = ob.ObtenerExistenciaTotalProducto(codigo);

                    string c = "";
                    if (existencia % 1 == 0)
                        c = decimal.ToInt32(existencia) + "";
                    else
                        c = existencia.ToString("0.##");

                    txtExistencia.Text = c;

                    if(existencia < 0)
                    {
                        lblExistencia.Text = "Sin Existencia:";
                        txtExistencia.BackColor = Color.Tomato;
                    }
                    else
                    {
                        lblExistencia.Text = "Existencia:";
                        txtExistencia.BackColor = SystemColors.Highlight;
                    }

                    tablePrecios.Controls.Clear();
                    TextBox t = new TextBox();
                    objPrecios.ConfigurarPanelPrecios(ref tablePrecios, ref t, ref precios, true);

                    objPrecios.CargarPreciosPublico(txtCodigo.Text, ref precios);


                }
                else
                {
                    MessageBox.Show("El producto no existe.");
                    Limpiar();
                }
            }

            if (ventanaSecundaria)
            {
                obi.setImagenFlotante(ObtenerPanelPrecios());
            }

            if (OPOSScanner != null)
            {
                OPOSScanner.DeviceEnabled = true;
                OPOSScanner.DataEventEnabled = true;
            }
        }

        private void Limpiar()
        {
            txtNombre.Text = "";

            tablePrecios.Controls.Clear();

            pictureBox1.Image = null;

            txtExistencia.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
           
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar.PerformClick();
               
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (obi != null)
                obi.Close();
            this.Close();

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        public TextBox ObtenerTxtCodigo()
        {
            return txtCodigo;
        }

        public Button ObtenerBtnAceptar()
        {
            return btnAceptar;
        }

        public Panel ObtenerPanelPrecios()
        {
            return panelPreciosPrincipal;
        }

        public void setParentParaSecundaria(Form parent)
        {
            ventanaSecundaria = true;
            this.parentSecundaria = parent;
        }

        public void setEscaner(AxOposScanner_CCO.AxOPOSScanner OPOSScanner)
        {
            this.OPOSScanner = OPOSScanner;
            
        }

        private void roundedButton1_Click_1(object sender, EventArgs e)
        {
            new BuscarProducto(txtCodigo, btnAceptar, false).ShowDialog(this);
        }
    }
}
