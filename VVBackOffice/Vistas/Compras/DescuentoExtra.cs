using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ValleVerde.Vistas.Compras
{
    public partial class DescuentoExtra : Form
    {
        Programacion.Compra.Compras objCom = new Programacion.Compra.Compras();
        ushort venAlt = 116, tabAlt = 0, botDisBorSup = 13, tbIdProdAnc = 200, tbDescrProdAnc = 425, tbDesAnc = 50, lMotAnc = 60, tbMotAnc = 475, bEliAnc = 75;
        long idFac;
        string idProd, descrProd;
        bool CargarDescuentoDefault, eliminandoDescuento = false, ChangeWindow;
        List<object[]> descuentosExtras;

        public DescuentoExtra(long idFac, string idProd, string descrProd, bool ChangeWindow)
        {
            this.ChangeWindow = ChangeWindow;
            InitializeComponent();
            this.idFac = idFac;
            this.idProd = idProd;
            this.descrProd = descrProd;
            descuentosExtras = objCom.ObtenerDescuentosExtra(idFac);
            if (ChangeWindow)
            {
                
            }
            else
            {
                agr.Visible = false;
                ActualizarDescuentosExtra();
            }
        }

        private void DescuentoExtra_Load(object sender, EventArgs e)
        {
            if (ChangeWindow)
            {
                FormClosing += new FormClosingEventHandler(DescuentoExtra_FormClosing);
                tlp.Height = 0;
                tlp.RowCount = 0;
                if (idProd.Equals(""))
                    CargarDescuentoDefault = true;
                else
                    CargarDescuentoDefault = false;
                ActualizarDescuentosExtra();
                CargarDescuentoDefault = false;
            }
        }

        private void DescuentoExtra_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (ChangeWindow)
            {
                for (int ind = 0; ind < tlp.RowCount; ind++)
                    if (tlp.GetControlFromPosition(2, ind).Text.Equals(""))
                        objCom.EliminarDescuentoExtra((long)tlp.GetControlFromPosition(2, ind).Tag);
            }
        }

        private void GenerarFila(object idProd, object descrProd, object idDesExt, object can, object mot)
        {
            TextBox tbIdProd = new TextBox();
            TextBox tbDescrProd = new TextBox();
            TextBox tbDesExt = new TextBox();
            Label lMot = new Label();
            TextBox tbMot = new TextBox();
            Button bEli = new Button();

            tbDesExt.KeyDown += new KeyEventHandler(des_KeyDown);
            tbMot.KeyDown += new KeyEventHandler(des_KeyDown);
            bEli.Click += new EventHandler(eli_Click);
            tbIdProd.Enabled = false;
            tbDescrProd.Enabled = false;
            if (ChangeWindow)
            {
                tbIdProd.Tag = idProd;
                tbDesExt.Tag = idDesExt;
                tbMot.Tag = idDesExt;
                bEli.Tag = idDesExt;
            }

            tbDesExt.Name = "tbDesExt";
            tbMot.Name = "tbMot";

            if (tlp.RowCount == 0)
            {
                tbDesExt.TabIndex = 0;
                tbMot.TabIndex = 1;
            }
            else
            {
                tbDesExt.TabIndex = tlp.GetControlFromPosition(3, tlp.RowCount - 1).TabIndex + 1;
                tbMot.TabIndex = tbDesExt.TabIndex + 1;
            }

            bEli.TabStop = false;

            if (!can.ToString().Equals("-1"))
                tbDesExt.Text = can.ToString();

            if (idProd != null)
            {
                tbIdProd.Text = idProd.ToString();
                tbDescrProd.Text = descrProd.ToString();
            }

            lMot.Text = "Motivo:";
            tbMot.Text = mot.ToString();
            bEli.Text = "Eliminar";

            tbIdProd.Width = tbIdProdAnc;
            tbDescrProd.Width = tbDescrProdAnc;
            tbDesExt.Width = tbDesAnc;
            lMot.Width = lMotAnc;
            tbMot.Width = tbMotAnc;
            bEli.Width = bEliAnc;
            bEli.Height = 26;

            tlp.RowCount = tlp.RowCount + 1;
            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
            tlp.Controls.Add(tbIdProd, 0, tlp.RowCount - 1);
            tlp.Controls.Add(tbDescrProd, 1, tlp.RowCount - 1);
            tlp.Controls.Add(tbDesExt, 2, tlp.RowCount - 1);
            tlp.Controls.Add(lMot, 3, tlp.RowCount - 1);
            tlp.Controls.Add(tbMot, 4, tlp.RowCount - 1);
            tlp.Controls.Add(bEli, 5, tlp.RowCount - 1);

            if(!ChangeWindow)
            {
                tbDesExt.Enabled = false;
                lMot.Enabled = false;
                tbMot.Enabled = false;
                bEli.Visible = false;
            }
            //byte sep = 10;

            //tbDesX = 0;
            //lSigPorX = (ushort)(tbDesX + tbDesAnc + sep);
            //lMotX = (ushort)(lSigPorX + lSigPorAnc + sep);
            //tbMotX = (ushort)(lMotX + lMotAnc + sep);
            //bEliX = (ushort)(tbMotX + tbMotAnc + sep);

            //TextBox tbDes = new TextBox();
            //Label lSigPor = new Label();
            //Label lMot = new Label();
            //TextBox tbMot = new TextBox();
            //Button bEli = new Button();
            ////y = (ushort)(panAlt - 32);
            //y = 0;

            //tbDes.KeyDown += new KeyEventHandler(des_KeyDown);
            //tbMot.KeyDown += new KeyEventHandler(des_KeyDown);
            //bEli.Click += new EventHandler(eli_Click);
            //tbDes.Tag = idDes;
            //tbMot.Tag = idDes;
            //bEli.Tag = idDes;

            //tbDes.Text = des.ToString();
            //lSigPor.Text = "%";
            //lMot.Text = "Motivo:";
            //tbMot.Text = mot.ToString();
            //bEli.Text = "Eliminar";

            //tbDes.Width = tbDesAnc;
            //lSigPor.Width = lSigPorAnc;
            //lMot.Width = lMotAnc;
            //tbMot.Width = tbMotAnc;
            //bEli.Width = bEliAnc;
            //bEli.Height = 26;

            //tbDes.Location = new Point(tbDesX, y);
            //lSigPor.Location = new Point(lSigPorX, y);
            //lMot.Location = new Point(lMotX, y);
            //tbMot.Location = new Point(tbMotX, y);
            //bEli.Location = new Point(bEliX, y);

            //tbDes.Font = new Font(tbDes.Font.FontFamily, 12);
            //lSigPor.Font = new Font(lSigPor.Font.FontFamily, 12);
            //lMot.Font = new Font(lMot.Font.FontFamily, 12);
            //tbMot.Font = new Font(tbMot.Font.FontFamily, 12);
            //bEli.Font = new Font(bEli.Font.FontFamily, 12);

            //panInt.Controls.Add(tbDes);
            //panInt.Controls.Add(lSigPor);
            //panInt.Controls.Add(lMot);
            //panInt.Controls.Add(tbMot);
            //panInt.Controls.Add(bEli);
        }

        private void eli_Click(object sender, EventArgs e)
        {
            eliminandoDescuento = true;
            objCom.EliminarDescuentoExtra((long)(sender as Button).Tag);
            ActualizarDescuentosExtra();
            eliminandoDescuento = false;
        }

        private void des_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if ((sender as TextBox).Name.Equals("tbDesExt"))
                {
                    if (!(sender as TextBox).Text.Equals(""))
                        objCom.ActualizarCantidadDescuentoExtra((long)(sender as TextBox).Tag, decimal.Parse((sender as TextBox).Text));
                }
                else
                    objCom.ActualizarMotivoDescuentoExtra((long)(sender as TextBox).Tag, (sender as TextBox).Text);
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void agr_Click(object sender, EventArgs e)
        {
            GenerarFila(null, null, objCom.AgregarDescuentoExtraFacturaPendiente(idFac, ""), -1, "");
            RedimensionarVentana();
        }

        private void ActualizarDescuentosExtra()
        {
            tlp.Controls.Clear();
            tlp.RowStyles.Clear();
            tlp.RowCount = 0;
            int ind;
            bool prodRep = false;

            List<object[]> descuentos = objCom.ObtenerDescuentosExtra(idFac);

            if (descuentos.Count > 0)
            {
                for (ind = 0; ind < descuentos.Count; ind++)
                    GenerarFila(descuentos[ind][0], descuentos[ind][1], descuentos[ind][2], descuentos[ind][3], descuentos[ind][4]);
                if (ChangeWindow)
                {
                    if (!idProd.Equals("") && !eliminandoDescuento)
                    {
                        for (ind = 0; ind < tlp.RowCount; ind++)
                            if (tlp.GetControlFromPosition(0, ind).Text.Equals(idProd))
                            {
                                prodRep = true;
                                (tlp.GetControlFromPosition(0, ind) as TextBox).SelectAll();
                                break;
                            }
                        if (!prodRep)
                            GenerarFila(idProd, descrProd, objCom.AgregarDescuentoExtraFacturaPendiente(idFac, idProd), -1, "");
                    }
                }
            }
            else
                //if (CargarDescuentoDefault)
                    GenerarFila(idProd, descrProd, objCom.AgregarDescuentoExtraFacturaPendiente(idFac, idProd), -1, "");

            RedimensionarVentana();
        }

        private void RedimensionarVentana()
        {
            tlp.Height = tlp.RowCount * 32;
            agr.Top = tlp.Height + 13;
            Height = 13 + tlp.Height + agr.Height + 57;
            
            CenterToScreen();
        }
    }
}
