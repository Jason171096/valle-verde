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
    public partial class VerificarProductoRapido : Form
    {
        Programacion.Compra.Compras objCom = new Programacion.Compra.Compras();
        List<object[]> producto;
        long idPed;
        string idProd, idClaAdi;
        bool prodFuePed;
        TextBox tb;

        public VerificarProductoRapido(TextBox tb, long idPed, string idProd, string idClaAdi, bool prodFuePed)
        {
            InitializeComponent();
            string codBar;
            this.idPed = idPed;
            this.idProd = idProd;
            this.idClaAdi = idClaAdi;
            this.prodFuePed = prodFuePed;
            this.tb = tb;

            if (idClaAdi.Equals(""))
                codBar = idProd;
            else
                codBar = idClaAdi;

            producto = objCom.ObtenerDatosProductoPedido(idPed, codBar, prodFuePed);
        }

        private void VerificarProductoRapido_Load(object sender, EventArgs e)
        {
            //producto = objCom.ObtenerDatosProductoPedido(idPed, codBar, prodFuePed);
            //labDes.Text = producto[0][6] + "";
            tbCan.Text = "1";
            tbCan.KeyDown += new KeyEventHandler(TextBox_KeyDown);

            if(idClaAdi.Equals(""))
            {
                labCan.Text = "Cantidad:";

                //lUniPorCaj.Visible = false;
                //tbUniPorCaj.Visible = false;
                tbUniPorCaj.Text = "1";
                butCon.TabIndex = 1;
            }
            else
            {
                tbUniPorCaj.KeyDown += new KeyEventHandler(TextBox_KeyDown);
                tbUniPorCaj.Text = producto[0][2] + "";
            }

            tbCan.SelectAll();
        }

        private void butCon_Click(object sender, EventArgs e)
        {
            decimal can, uniPorCaj;
            can = decimal.Parse(tbCan.Text);
            uniPorCaj = decimal.Parse(tbUniPorCaj.Text);

            if(idClaAdi.Equals(""))
                can *= uniPorCaj;
            //impo /= uniPorCaj;

            //producto[0][4] = tbCan.Text;
            //if (cosIncImp)
            //    producto[0][8] = tbCos.Text;
            //else
            //    producto[0][8] = (decimal.Parse(tbCos.Text) * (decimal)1.16).ToString();
            //dgvP.Rows.Add(producto);

            objCom.AgregarProductoAPedido(idPed, idProd, idClaAdi, can, uniPorCaj, true, -1);

            tb.Text = "";
            tb.Focus();
            Close();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                if (tbUniPorCaj.Focused)
                    butCon.PerformClick();
                else
                    SelectNextControl((Control)sender, true, true, true, true);
        }
    }
}
