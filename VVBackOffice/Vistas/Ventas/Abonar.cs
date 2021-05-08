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
    public partial class Abonar : Form
    {
        Abona obj = new Abona();

        string cliente;
        int idCliente;

        string usuario;
        string idUsuario;        

        int idVenta;
        string total;

        int formaPago=0;
        int banderaVenta;

        Validaciones valida = new Validaciones();
        public Abonar(string cliente, int idCliente, int idVenta, string total, int venta, string saldo, string idUsuario, string usuario)
        {
            InitializeComponent();

            this.cliente = cliente;
            this.idCliente = idCliente;

            this.idVenta = idVenta;
            this.total = total;

            this.idUsuario = idUsuario;
            this.usuario = usuario;

            this.banderaVenta = venta;
            labelUsuario.Text = usuario;
            if (venta == 0)
            {
                label4.Visible = false;                
                labelIDVenta.Visible = false;

                label9.Location = new Point(100, 227);
                label9.Text = "Saldo a pagar:";
                
                labelTotal.Location = new Point(215, 227);
                labelTotal.Text = saldo;
            }
            else if(venta == 1)
            {
                if (total == "$" || total == "$0.00") 
                {                    
                    this.Dispose();
                }
                labelIDVenta.Text = idVenta.ToString();
                labelTotal.Text = total;
                textBox1.Text = total.Substring(1,total.Length-1);
                
            }
            else
            {
                if (total == "$" || total == "$0.00")
                {
                    this.Dispose();
                }
                labelIDVenta.Text = idVenta.ToString();
                labelTotal.Text = total;
            }
        }

        private void Abonar_Load(object sender, EventArgs e)
        {
            labelCliente.Text = cliente;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.SoloDecimales(sender, e);
        }

        private void efectivo_Click(object sender, EventArgs e)
        {
            this.formaPago = 1;
            efectivo.BackColor = Color.DodgerBlue;
            tarjeta.BackColor = Color.Transparent;
        }

        private void tarjeta_Click(object sender, EventArgs e)
        {
            this.formaPago = 2;
            tarjeta.BackColor = Color.DodgerBlue;
            efectivo.BackColor = Color.Transparent;
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            string res = "";
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && formaPago > 0)
            {
                if (banderaVenta == 0)
                {
                    res = obj.AgregarAbonosCredito(idCliente, decimal.Parse(textBox1.Text), formaPago,-1, int.Parse(idUsuario));
                }
                else if (banderaVenta == 1)
                {
                    res = obj.AgregarAbonosCredito(idCliente, decimal.Parse(textBox1.Text), formaPago,idVenta, int.Parse(idUsuario));
                }
                else if(banderaVenta == 2)
                {
                    res = obj.AgregarAbonosCredito(idCliente, decimal.Parse(textBox1.Text), formaPago,idVenta,int.Parse(idUsuario));
                }
                

                if (res == "1")
                {
                    MessageBox.Show("Abono Agregado con extito");
                }

                //CreditosVer o = new CreditosVer(idCliente.ToString(),cliente, idUsuario, usuario);
                //o.Show();
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Seleccione un metodo de pago o llene los campos");
            }
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            //CreditosVer o = new CreditosVer(idCliente.ToString(), cliente, idUsuario, usuario);
            //o.Show();
            this.Close();
        }
    }
}
