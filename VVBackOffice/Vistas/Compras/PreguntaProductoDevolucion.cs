using System;
using System.Collections.Generic;
using System.Windows.Automation.Provider;
using System.Windows.Forms;
using ValleVerdeComun;

namespace ValleVerde.Vistas.Compras
{
    public partial class PreguntaProductoDevolucion : Form
    {
        Programacion.Compra.Compras objCom = new Programacion.Compra.Compras();
        List<object[]> productoSaliente, productoEntrante;
        long idDevComSal, idPed, idProv;
        bool devolucionDentroCompra;

        public PreguntaProductoDevolucion(bool devolucionDentroCompra, long idDevComSal, long idPed, long idProv, string codBar, decimal can, string descrProd, string descrUni, decimal cos)
        {
            InitializeComponent();
            this.devolucionDentroCompra = devolucionDentroCompra;
            this.idDevComSal = idDevComSal;
            this.idPed = idPed;
            this.idProv = idProv;

            if (can == 1)
                lDescrProd.Text = can + " " + descrUni.ToLower() + " de " + descrProd + " " + cos * can;
            else
                lDescrProd.Text = can + " " + descrUni.ToLower() + "s de " + descrProd + " " + cos * can;

            //if (devolucionDentroCompra)
            //{
                productoSaliente = objCom.ObtenerDevolucionCompraSalientes(-1, idDevComSal, -1, false, true);
                
                //Mostramos el producto que se devolverá
                //if (decimal.Parse(productoSaliente[0][6] + "") == 1)
                //    lDescrProd.Text = productoSaliente[0][6] + " " + (productoSaliente[0][11] + "").ToLower() + " de " + productoSaliente[0][3] + " " + string.Format("{0:c}", decimal.Parse(productoSaliente[0][6] + "") * decimal.Parse(productoSaliente[0][7] + ""));
                //else
                //    lDescrProd.Text = productoSaliente[0][6] + " " + (productoSaliente[0][11] + "").ToLower() + "s de " + productoSaliente[0][3] + " " + string.Format("{0:c}", decimal.Parse(productoSaliente[0][6] + "") * decimal.Parse(productoSaliente[0][7] + ""));
           // }
        }

        private void PreguntaProductoDevolucion_Load(object sender, EventArgs e)
        {
            List<object[]> tipDev = objCom.ObtenerTipoDevolucionCompra();

            foreach(object[] tip in tipDev)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Value = tip[0];
                item.Text = tip[1] + "";
                cb.Items.Add(item);
            }

            //Mostramos la compensacion que se obtendra a cambio del producto, en caso de que haya
            productoEntrante = objCom.ObtenerDevolucionCompraEntrantes(idDevComSal);
            if ((productoEntrante[0][4] + "").Contains("Producto diferente"))
            {
                tbCodBar.Text = productoEntrante[0][0] + "";
                lDes.Text = productoEntrante[0][2] + "";
                tbCan.Text = productoEntrante[0][5] + "";
                tbCos.Text = productoEntrante[0][6] + "";

                if (tbCan.Text.Equals(""))
                    tbCan.Text = "1";
                if (tbCos.Text.Equals(""))
                    tbCos.Text = "0";
                lImpo2.Text = string.Format("{0:c}", decimal.Parse(tbCan.Text) * decimal.Parse(tbCos.Text));
            }

            cb.SelectedIndexChanged += new EventHandler(cb_SelectedIndexChanged);
            cb.KeyDown += new KeyEventHandler(cb_KeyDown);
            tbCodBar.KeyDown += new KeyEventHandler(tbCodBar_KeyDown);
            tbCan.TextChanged += new EventHandler(tb_TextChanged);
            tbCos.TextChanged += new EventHandler(tb_TextChanged);

            //Mostramos que se obtendrá a cambio del producto
            //if (devolucionDentroCompra)
            //{
                if (!(productoSaliente[0][4] + "").Equals(""))
                {
                    for (int i = 0; i < cb.Items.Count; i++)
                    {
                        if (((cb.Items[i] as ComboBoxItem).Value + "").Equals(productoSaliente[0][4] + ""))
                        {
                            cb.SelectedIndex = i;
                            break;
                        }
                    }
                }
            //}
            //else
            //{
            //    for (int i = 0; i < cb.Items.Count; i++)
            //    {
            //        if (((cb.Items[i] as ComboBoxItem).Value + "").Contains("Pendiente"))
            //        {
            //            cb.SelectedIndex = i;
            //            break;
            //        }
            //    }
            //}
        }

        private void cb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
            else
                if (cb.SelectedIndex != -1)
                {
                    if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                    {
                        if ((cb.SelectedItem as ComboBoxItem).Text.Contains("Producto diferente"))
                        {
                            bMos.PerformClick();
                            if (tbCodBar.Text.Equals(""))
                                tbCodBar.Focus();
                            else
                                bAce.PerformClick();
                        }
                        else
                            bAce.PerformClick();
                    }
                }
        }

        private void tbCodBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                bMos.PerformClick();
            else
                if(e.KeyCode == Keys.Escape)
                    Close();
        }

        private void tb_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            try
            {
                lImpo2.Text = string.Format("{0:c}", decimal.Parse(tbCan.Text) * decimal.Parse(tbCos.Text));
                bAce.Enabled = true;
            }
            catch(Exception ex)
            {
                if (tb.Text.Equals(""))
                {
                    lImpo2.Text = "";
                    bAce.Enabled = false;
                }
                else
                {
                    tb.Text = tb.Text.Substring(0, tb.Text.Length - 1);
                    bAce.Enabled = true;
                }
            }
        }

        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxItem item = cb.SelectedItem as ComboBoxItem;

            lCodBar.Enabled = true;
            tbCodBar.Enabled = true;
            bSelProd.Enabled = true;
            bMos.Enabled = true;
            lDes.Enabled = true;
            lCan.Enabled = true;
            tbCan.Enabled = true;
            lCos.Enabled = true;
            tbCos.Enabled = true;
            bAce.Enabled = true;

            switch (int.Parse(item.Value + ""))
            {
                case 1: //Efectivo
                    lCodBar.Enabled = false;
                    tbCodBar.Enabled = false;
                    bSelProd.Enabled = false;
                    bMos.Enabled = false;
                    lDes.Enabled = false;
                    lCan.Enabled = false;
                    tbCan.Enabled = false;
                    break;
                case 2: //Mismo producto
                    lCodBar.Enabled = false;
                    tbCodBar.Enabled = false;
                    bSelProd.Enabled = false;
                    bMos.Enabled = false;
                    lDes.Enabled = false;
                    lCan.Enabled = false;
                    tbCan.Enabled = false;
                    lCos.Enabled = false;
                    tbCos.Enabled = false;
                    break;
                case 3: //Diferente producto
                    lCos.Enabled = false;
                    tbCos.Enabled = false;
                    bAce.Enabled = false;
                    break;
                case 4: //Credito para otra compra
                    lCodBar.Enabled = false;
                    tbCodBar.Enabled = false;
                    bSelProd.Enabled = false;
                    bMos.Enabled = false;
                    lDes.Enabled = false;
                    lCan.Enabled = false;
                    tbCan.Enabled = false;
                    lCos.Enabled = false;
                    tbCos.Enabled = false;
                    tbCan.Text = "1";
                    tbCos.Text = "0";
                    break;
                case 6: //Pendiente
                    lCodBar.Enabled = false;
                    tbCodBar.Enabled = false;
                    bSelProd.Enabled = false;
                    bMos.Enabled = false;
                    lDes.Enabled = false;
                    lCan.Enabled = false;
                    tbCan.Enabled = false;
                    lCos.Enabled = false;
                    tbCos.Enabled = false;
                    break;
            }
        }


        private void bSelProd_Click(object sender, EventArgs e)
        {
            new BuscarProducto(tbCodBar, bMos, false).Show();
        }

        private void bMos_Click(object sender, EventArgs e)
        {
            string codBar = tbCodBar.Text.Trim();
            if(!codBar.Equals(""))
            {
                string[] res = objCom.ExisteProductoConClaveAdicional(codBar);
                //Si no existe producto con ese codigo de barras, mostramos mensaje, sino continuamos
                if(res[0].Equals("-1"))
                {
                    MessageBox.Show("No existe producto con código de barras: " + codBar);
                    tbCodBar.Text = "";
                }
                else
                {
                    string idProd, idClaAdi;
                    if(res[1].Equals(codBar))
                    {
                        idProd = codBar;
                        idClaAdi = "";
                    }
                    else
                    {
                        idProd = res[1];
                        idClaAdi = codBar;
                    }

                    if (objCom.ProveedorVendeProductoOCaja(idProv, idProd))
                    {
                        lDes.Text = objCom.ObtenerDescripcionProducto(idProd);
                        tbCos.Text = objCom.ObtenerCostoProducto(idProd) + "";
                        bAce.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("No se puede recibir este producto, porque no esta en la lista de productos que vende el proveedor.");
                        tbCodBar.Text = "";
                    }
                }
            }
        }

        private void bAce_Click(object sender, EventArgs e)
        {
            decimal can, cos;
            if (tbCan.Text.Equals(""))
                can = 0;
            else
                can = decimal.Parse(tbCan.Text);
            if (tbCos.Text.Equals(""))
                cos = 0;
            else
                cos = decimal.Parse(tbCos.Text);
            
            // objCom.MarcarProductoPendiente(idProdPen, false);
            long idTipDev = -1;
            if (cb.SelectedItem != null)
                idTipDev = (long)(cb.SelectedItem as ComboBoxItem).Value;
            //objCom.AgregarProductoDevolucionCompra((long)producto[0], byte.Parse((ppd.cb.SelectedItem as ComboBoxItem).Value + ""), "", "", -1, "", -1, true, -1)[1];
            objCom.AgregarEntradaDevolucionCompra(idDevComSal, idTipDev, idPed, tbCodBar.Text, can, cos);
        }
    }
}
