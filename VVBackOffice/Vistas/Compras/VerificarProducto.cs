using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ValleVerde.Vistas.Compras
{
    public partial class VerificarProducto : Form
    {
        Programacion.Compra.Compras objCom = new Programacion.Compra.Compras();
        Costo objCos;
        public List<object[]> producto;
        bool prodFuePed, cosIncImp, infDes, codBarEsClaAdi, recPed, altCom, verRap, habilitadoTextChanged = true;
        public long idFac, idPed, idProdPed, idProdPen;
        decimal totRea, can, uniPorCaj;
        sbyte desEsPor;
        string lisImp;

        DataGridView dgvP;
        TextBox tb, texBox = null;

        private void labCan_Click(object sender, EventArgs e)
        {

        }

        Color rojo;

        public VerificarProducto(bool verRap, DataGridView dgvP, TextBox tb, bool prodFuePed, Color rojo, sbyte desEsPor, bool cosIncImp, bool infDes, long idFac, long idPed, string codBar, string lisImp, decimal can, decimal uniPorCaj, bool codBarEsClaAdi, bool recPed, bool altCom, long idProdPen)
        {
            InitializeComponent();
            this.dgvP = dgvP;
            this.tb = tb;
            this.prodFuePed = prodFuePed;
            this.idFac = idFac;
            this.idPed = idPed;
            this.rojo = rojo;
            this.desEsPor = desEsPor;
            this.cosIncImp = cosIncImp;
            this.infDes = infDes;
            this.lisImp = lisImp;
            this.can = can;
            this.uniPorCaj = uniPorCaj;
            this.codBarEsClaAdi = codBarEsClaAdi;
            this.recPed = recPed;
            this.altCom = altCom;
            this.verRap = verRap;
            this.idProdPen = idProdPen;
            producto = objCom.ObtenerDatosProductoPedido(idPed, codBar, prodFuePed);
        }

        private void VerificarProducto_Load(object sender, EventArgs e)
        {
            //Si el costo actual es mayor a 0, significa que este producto es vendido por un proveedor que casi no cambia el costo de sus productos, por lo que el importe debe de cambiar conforme se modifique la cantidad, en un intento de que el importe calculado coincida con el de la factura.
            //if ((decimal)producto[0][10] > 0)
            labDes.Text = "";
            tbCan.Text = can + "";

            tbCan.TextChanged += new EventHandler(validarCampos);
            tbUniPorCaj.TextChanged += new EventHandler(validarCampos);

            tbCan.KeyDown += new KeyEventHandler(tb_KeyDown);
            tbUniPorCaj.KeyDown += new KeyEventHandler(tb_KeyDown);

            if (verRap)
            {
                lImpo.Visible = false;
                tbImpo.Visible = false;
                tb.TabStop = false;
                labDes.Location = new Point(labDes.Location.X, labDes.Location.Y - tbImpo.Height);
                butCon.Location = new Point(butCon.Location.X, butCon.Location.Y - tbImpo.Height);
                Height -= tbImpo.Height;
                //butCon.TabIndex = 2;
            }
            else
            {
                tbImpo.TextChanged += new EventHandler(validarCampos);
                tbImpo.KeyDown += new KeyEventHandler(tb_KeyDown);

                if(cosIncImp)
                    lImpo.Text = "Importe";
            }

            if ((producto[0][2] + "").Equals(""))
                tbUniPorCaj.Text = uniPorCaj + "";
            else
                tbUniPorCaj.Text = producto[0][2] + "";

            //if (producto[0][1].Equals(""))
            //    producto[0][6] = producto[0][5] + "s de " + producto[0][6];
            //else
            //    producto[0][6] = "Cajas con " + producto[0][3] + " " + producto[0][5] + "s de " + producto[0][6];
            //labDes.Text = producto[0][6] + "";

            //if (codBarEsClaAdi)
            //{
            //    //if (desEsPor != -1)
            //    //{
            //    //    Label lab = new Label();
            //    //    texBox = new TextBox();
            //    //    sbyte y = 99;

            //    //    texBox.TabIndex = 10;

            //    //    if (infDes)
            //    //    {
            //    //        lab.Text = "IVA:";
            //    //    }
            //    //    else
            //    //    {
            //    //        lab.Text = "Descuento:";
            //    //    }

            //    //    lab.Font = new Font(lab.Font.FontFamily, 12);
            //    //    texBox.Font = new Font(texBox.Font.FontFamily, 12);
            //    //    texBox.Width = tbCan.Width;

            //    //    lab.Location = new Point(tbCan.Location.X - 97, y + 3);
            //    //    texBox.Location = new Point(tbCan.Location.X, y);

            //    //    Controls.Add(lab);
            //    //    Controls.Add(texBox);

            //    //    if (desEsPor == 1)
            //    //    {
            //    //        Label sigPor = new Label();
            //    //        sigPor.Text = "%";
            //    //        sigPor.Font = new Font(sigPor.Font.FontFamily, 12);
            //    //        sigPor.Location = new Point(Width - 65, y + 3);
            //    //        sigPor.Width = 91;
            //    //        Controls.Add(sigPor);
            //    //    }

            //    //    labDes.Location = new Point(labDes.Location.X, labDes.Location.Y + 38);
            //    //    butCon.Location = new Point(butCon.Location.X, butCon.Location.Y + 38);
            //    //    Height += 38;
            //    //    //texBox.KeyDown += new KeyEventHandler(tb_KeyDown);
            //    //}
            //    tbImpo.KeyDown += new KeyEventHandler(tb_KeyDown);

            //    if (producto[0][1].Equals(""))
            //        producto[0][6] = producto[0][5] + "s de " + producto[0][6];
            //    else
            //        producto[0][6] = "Cajas con " + producto[0][3] + " " + producto[0][5] + "s de " + producto[0][6];
            //    labDes.Text = producto[0][6] + "";
            //    if(!verRap)
            //        if (prodFuePed)
            //        {
            //            ////tbCan.Text = producto[0][3] + "";
            //            if (!cosIncImp)
            //                tbImpo.Text = RestarImpuestosCosto(decimal.Parse(tbImpo.Text), producto[0][9] + "").ToString();
            //            //    tbImpo.Text = impo + "";
            //            //else
            //        }
            //        else
            //        {
            //            ////tbCan.Text = producto[0][4] + "";
            //            //tbImpo.Text = impo + "";
            //        }
            //}
            //else
            //{
            //    labCan.Text = "Cantidad:";
            //    ////tbCan.Text = can + "";
            //    //tbCan.KeyDown += new KeyEventHandler(tb_KeyDown);

            //    ////lUniPorCaj.Visible = false;
            //    ////tbUniPorCaj.Visible = false;
            //    //tbUniPorCaj.KeyDown += new KeyEventHandler(tb_KeyDown);
            //    //tbUniPorCaj.Text = "1";

            //    tbImpo.TabIndex = 2;
            //    tbImpo.KeyDown += new KeyEventHandler(tb_KeyDown);

            //    butCon.TabIndex = 2;
                
            //    if (cosIncImp)
            //        lImpo.Text = "Importe";
            //    else
            //        lImpo.Text = "Importe (sin impuestos)";
                
            //    if (desEsPor != -1)
            //    {
            //        Label lab = new Label();
            //        texBox = new TextBox();
            //        sbyte y = 99;

            //        texBox.TabIndex = 10;

            //        if (infDes)
            //        {
            //            lab.Text = "IVA:";
            //        }
            //        else
            //        {
            //            lab.Text = "Descuento:";
            //        }

            //        lab.Font = new Font(lab.Font.FontFamily, 12);
            //        texBox.Font = new Font(texBox.Font.FontFamily, 12);
            //        texBox.Width = tbCan.Width;

            //        lab.Location = new Point(tbCan.Location.X - 97, y + 3);
            //        texBox.Location = new Point(tbCan.Location.X, y);

            //        Controls.Add(lab);
            //        Controls.Add(texBox);

            //        if (desEsPor == 1)
            //        {
            //            Label sigPor = new Label();
            //            sigPor.Text = "%";
            //            sigPor.Font = new Font(sigPor.Font.FontFamily, 12);
            //            sigPor.Location = new Point(Width - 65, y + 3);
            //            sigPor.Width = 91;
            //            Controls.Add(sigPor);
            //        }

            //        labDes.Location = new Point(labDes.Location.X, labDes.Location.Y + 38);
            //        butCon.Location = new Point(butCon.Location.X, butCon.Location.Y + 38);
            //        Height += 38;
            //        //texBox.KeyDown += new KeyEventHandler(tb_KeyDown);
            //    }
                
            //    labDes.Text = producto[0][5] + "s de " + producto[0][6];
            //    if (prodFuePed)
            //    {
            //        ////tbCan.Text = producto[0][3] + "";
            //        if (!cosIncImp)
            //        //    tbImpo.Text = impo + "";
            //        //else
            //            tbImpo.Text = RestarImpuestosCosto(decimal.Parse(tbImpo.Text), producto[0][9] + "").ToString();
            //    }
            //    else
            //    {
            //        ////tbCan.Text = producto[0][4] + "";
            //        //tbImpo.Text = impo + "";
            //    }
            //}
        }

        private void validarCampos(object sender, EventArgs e)
        {
            if (habilitadoTextChanged)
            {
                habilitadoTextChanged = false;

                TextBox tb = (sender as TextBox);
                decimal caj, uniPorCaj;
                String tex = tb.Text.Trim();

                if (tex.Length > 0)
                {
                    try
                    {
                        decimal.Parse(tex);
                    }
                    catch (Exception ex)
                    {
                        tb.Text = tex.Substring(0, tex.Length - 1);
                    }
                    //else
                    //    if ((sender as TextBox).Name.Equals("tbUniPorCaj"))
                    //{
                    //    try
                    //    {
                    //        uniPorCaj = decimal.Parse(tbUniPorCaj.Text);
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        tbUniPorCaj.Text = tex;
                    //    }
                    //}
                    //else
                    //        if ((sender as TextBox).Name.Equals("tbImpo"))
                    //{
                    //    try
                    //    {
                    //        impo = decimal.Parse(tbImpo.Text);
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        tbImpo.Text = tex;
                    //    }
                    //}
                    if(idProdPen != -1)
                    {
                        //Como es un producto que nos debía el proveedor, entonces no se permite que entregue menos de lo que se debía
                        if (tb.Name.Equals(tbCan.Name) && decimal.Parse(tbCan.Text) < this.can)
                            tbCan.Text = this.can + "";
                        else
                            if (tb.Name.Equals(tbUniPorCaj.Name) && decimal.Parse(tbUniPorCaj.Text) < this.uniPorCaj)
                                tbUniPorCaj.Text = this.uniPorCaj + "";
                    }
                    
                    if (!tb.Name.Equals("tbImpo"))
                        if (tbCan.Text.Equals("") || tbUniPorCaj.Text.Equals("") || tbCan.Text.Equals("0") || tbUniPorCaj.Text.Equals("0"))
                        {
                            tbImpo.Text = "0";
                            labDes.Text = "";
                            butCon.Enabled = false;
                        }
                        else
                        {
                            tbImpo.Text = (decimal.Parse(tbCan.Text) * decimal.Parse(tbUniPorCaj.Text) * (decimal)producto[0][10]) + "";
                            //Mostrar el total de unidades que se agregaran
                            caj = decimal.Parse(tbCan.Text);
                            uniPorCaj = decimal.Parse(tbUniPorCaj.Text);
                            labDes.Text = caj * uniPorCaj + " ";
                            if (caj * uniPorCaj == 1)
                                labDes.Text += producto[0][5] + " de " + producto[0][6];
                            else
                                labDes.Text += producto[0][5] + "s de " + producto[0][6];
                            butCon.Enabled = true;
                        }
                }
                else
                {
                    if (!tb.Name.Equals("tbImpo"))
                    {
                        tbImpo.Text = "0";
                        labDes.Text = "";
                        butCon.Enabled = false;
                    }
                }
                habilitadoTextChanged = true;
            }

            //Mostrar cantidad de cajas y de unidades por caja
            //labDes.Text = "";
            //if (tbCan.Text.Equals("1"))
            //    labDes.Text += tbCan.Text + " caja con ";
            //else
            //    labDes.Text += tbCan.Text + " cajas con ";
            //if(tbUniPorCaj.Text.Equals("1"))
            //    labDes.Text += tbUniPorCaj.Text + " " + producto[0][5] + " de " + producto[0][6];
            //else
            //    labDes.Text += tbUniPorCaj.Text + " " + producto[0][5] + "s de " + producto[0][6];
        }

        public decimal ObtenerTotal()
        {
            return totRea;
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                if(verRap)
                {
                    if (tbUniPorCaj.Focused)
                        butCon.PerformClick();
                    else
                        SelectNextControl((Control)sender, true, true, true, true);
                }
                else
                {
                    if(tbImpo.Focused)
                        butCon.PerformClick();
                    else
                        SelectNextControl((Control)sender, true, true, true, true);
                }
            else
                if (e.KeyCode == Keys.Escape)
                    Close();
        }

        private void butCon_Click(object sender, EventArgs e)
        {
            objCos = new Costo(cosIncImp);
            decimal can, uniPorCaj, impo = 0;
            can = decimal.Parse(tbCan.Text);
            uniPorCaj = decimal.Parse(tbUniPorCaj.Text);

            if (cosIncImp)
                impo = decimal.Parse(tbImpo.Text);
            else
                impo = objCos.SumarImpuestosCosto(decimal.Parse(tbImpo.Text), producto[0][9] + "");

            //impo /= uniPorCaj;

            producto[0][4] = tbCan.Text;
            //if (cosIncImp)
            //    producto[0][8] = tbCos.Text;
            //else
            //    producto[0][8] = (decimal.Parse(tbCos.Text) * (decimal)1.16).ToString();
            //dgvP.Rows.Add(producto);

            //if (desEsPor != -1)
            //{
            //    if (texBox.Text.Equals(""))
            //        texBox.Text = "-1";
            //    if (infDes)
            //        idProdPed = objCom.AgregarProductoFacturaPendiente(idFac, idPed, producto[0][0] + "", producto[0][1] + "", can, impo, decimal.Parse(texBox.Text), prodFuePed);
            //    else
            //        idProdPed = objCom.AgregarProductoFacturaPendiente(idFac, idPed, producto[0][0] + "", producto[0][1] + "", can, impo, decimal.Parse(texBox.Text), prodFuePed);
            //}
            //else
            if (verRap)
                idProdPed = objCom.AgregarProductoAPedido(idPed, producto[0][0] + "", producto[0][1] + "", can, uniPorCaj, altCom, idProdPen);
            else
            {
                can *= uniPorCaj;
                idProdPed = objCom.AgregarProductoFacturaPendiente(idFac, idPed, producto[0][0] + "", producto[0][1] + "", can, impo, 0, prodFuePed, idProdPen);
            }
            tb.Text = "";
            tb.Focus();
            Close();
        }

        private decimal RestarImpuestosCosto(decimal cos, string lisImp)
        {
            byte ind;
            // idImp:1,descrProd:IVA,val:16;idImp:4,descrProd:IEPS,val:26.5
            if (lisImp.Contains("IVA"))
            {
                ind = (byte)(lisImp.IndexOf("IVA") + 8);
                cos = cos / ((decimal.Parse(lisImp.Substring(ind, lisImp.IndexOf(';') - ind)) / 100) + 1);
                //MessageBox.Show(lisImp.Substring(ind, lisImp.IndexOf(';') - ind));
                lisImp = lisImp.Substring(lisImp.IndexOf(';') + 1);
            }

            if (lisImp.Contains("IEPS"))
            {
                ind = (byte)(lisImp.IndexOf("IEPS") + 9);
                while (lisImp.Length > 0)
                {
                    cos = cos / ((decimal.Parse(lisImp.Substring(ind, lisImp.IndexOf(';') - ind)) / 100) + 1);
                    //MessageBox.Show(lisImp.Substring(ind, lisImp.IndexOf(';') - ind));
                    lisImp = lisImp.Substring(lisImp.IndexOf(';') + 1);
                }
            }

            return cos;
        }
    }
}
