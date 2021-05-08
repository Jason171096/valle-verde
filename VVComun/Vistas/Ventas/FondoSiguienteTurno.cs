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
    public partial class FondoSiguienteTurno : Form
    {
        private decimal fondo = 0;
        string valorEscrito = "";
        decimal disponible = 0;
        bool primeraVez = true;
        public FondoSiguienteTurno(decimal disponible)
        {
            this.disponible = disponible;

            InitializeComponent();
            this.TransparencyKey = Color.Turquoise;
            this.BackColor = Color.Turquoise;

            FormBorderStyle = FormBorderStyle.None;

            txtFondo.KeyPress += new KeyPressEventHandler(tb_KeyDown);
        }

        private void FondoSiguienteTurno_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtFondo;
        }

        private void tb_KeyDown(object sender, KeyPressEventArgs e)
        {

            if (true == Char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Return || e.KeyChar == (char)Keys.OemPeriod || e.KeyChar == '.')
                if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Return)
                {
                    btnAceptar.PerformClick();

                }
                else
                {
                    string letra = e.KeyChar + "";
                    if (e.KeyChar == (char)Keys.Back)
                    {
                        if (valorEscrito != "")
                        {
                            valorEscrito = valorEscrito.Substring(0, valorEscrito.Length - 1);
                            if ( valorEscrito.Length == 0)
                            {
                                // 0 al estar vacio
                                valorEscrito = "0";
                            }
                        }
                    }
                    else
                    {
                        if (letra == "." && primeraVez)
                            letra = "0.";

                        if (primeraVez)
                        {
                            primeraVez = false;
                            valorEscrito = "";
                        }


                        if (letra == ".")
                        {
                            if (!valorEscrito.Contains("."))
                                valorEscrito += letra;
                        }
                        else
                            valorEscrito += letra;
                        
                    }


                    if (valorEscrito != "" )
                        {
                            ((TextBox)sender).Text = string.Format("{0:C}", decimal.Parse(valorEscrito));
                            fondo = decimal.Parse(valorEscrito);
                        }
                        
                    
                }


            e.Handled = true;
            
            //e.SuppressKeyPress = true;
        }

        public decimal ObtenerFondo()
        {
            return fondo;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (fondo<=disponible)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("No puedes dejar mas dinero del que hay actualmente en la caja.");
                valorEscrito = "0";
                txtFondo.Text = string.Format("{0:C}", decimal.Parse(valorEscrito));
                fondo = decimal.Parse(valorEscrito);

                txtFondo.SelectAll();
            }
        }
    }
}
