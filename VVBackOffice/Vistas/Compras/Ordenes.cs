using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ValleVerde.Vistas.Inventario;
using ValleVerdeComun;
using ValleVerdeComun.Programacion.Huellas;

namespace ValleVerde.Vistas.Compras
{
    public partial class Ordenes : Form
    {
        ValleVerdeComun.Programacion.Producto objPro = new ValleVerdeComun.Programacion.Producto();
        Programacion.Compra.Compras objCom = new Programacion.Compra.Compras();
        Vistas.Compras.QuitarCadenas objQuiCad = new Vistas.Compras.QuitarCadenas();
        Costo objCos;
        long idPed, idFac, idProv, idProdPen;
        decimal subEsp = 0, impEsp = 0, totEsp = 0, subFac = 0, impFac = 0, totFac = 0, subGlo = 0, impGlo = 0, totGlo = 0, totAPagGlo = 0, porDesGen, canDesGenGlo, canDesPorRenGlo, canDesExtGlo, canDevGlo, totAPagFac = 0, canDesGenFac, canDesPorRenFac, canDesExtFac, canDevFac, creFav = 0;
        bool enterDentroCelda, recPed = true, camImp, habilitadoSelectionChanged = true, mostrarSeleccion = false, habilitadoSelectionIndex = true, habilitadoCellValueChanged = true, habilitadoCheckedChanged = true, habilitadoValueChanged = true, habilitadoRevisarProducto = true, todProdPenRec = true;
        byte indInd, indCodBar, indIdProd, indIdClaAdi, indUniPorCaj, indCanEsp, indCanRec, indDescrUni, indDescrProd, indCosActEspSinImpu, indCosActEsp, indCosRecSinImpu, indCosRec, indIdProdPed, indDescuPorRen, indLisImp, indNueCos, indIvaPesos, indIepsPesos, indCanDev, indMotDev, indDescuExt, indProdRep, indImpoSinImpu, indImpo, indProdPed, indUti, indAltCom, indIdProdPen,
            indIdProd2, indIdClaAdi2;
        object[,] datFac;
        short indAnt, renSel = -1;
        decimal valAnt;

        Color verde = Color.FromName("LightGreen");
        Color azul = Color.FromName("LightBlue");
        Color amarillo = Color.FromName("Yellow");
        Color rojo = Color.FromName("Salmon");
        Color gris = Color.FromName("LightGray");
        DataGridView dgvP = new DataGridView();
        ComboBox prov;
        RoundedButton agrProv;

        public Ordenes()
        {
            InitializeComponent();
            tbCodBar.KeyDown += new KeyEventHandler(tb_KeyDown);
            tbCodBar2.KeyDown += new KeyEventHandler(tb_KeyDown);
            //fol.KeyDown += new KeyEventHandler(tb_KeyDown);
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(datGriVieProv, false, false,15,15);
            datGriVieProv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(datGriVieProd, false, false, 10,10);
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvProdPen, false, false, 10, 10);
            //if (!recPed)
            //{
            //    p3.Controls.Add(prov);
            //    p3.Controls.Add(agrProv);
            //}
        }

        private void Ordenes_Load(object sender, EventArgs e)
        {
            tc.SelectedIndexChanged += new EventHandler(tc_SelectedIndexChanged);
            cbAgrProv.KeyDown += new KeyEventHandler(cbAgrProv_KeyDown);

            dgvProdPen.SelectionChanged += new EventHandler(dgvProdPen_SelectionChanged);
            datGriVieProv.SelectionChanged += new EventHandler(datGriVieProv_SelectionChanged);
            //datGriVieProv.MouseDown += new MouseEventHandler(datGriVieProd_MouseDown);

            dgvProdPen.KeyDown += new KeyEventHandler(dgvProdPen_KeyDown);
            datGriVieProv.KeyDown += new KeyEventHandler(datGriVieProv_KeyDown);
            datGriVieProd.KeyDown += new KeyEventHandler(datGriVieProd_KeyDown);
            datGriVieProd.KeyUp += new KeyEventHandler(datGriVieProd_KeyUp);
            tabConFac.SelectedIndexChanged += new EventHandler(cambioFactura);
            esFac.CheckedChanged += new EventHandler(cambioIndicacion);

            desAntImp.CheckedChanged += new EventHandler(cambioDescuentosAntesImpuestos);
            esPor.CheckedChanged += new EventHandler(cambioEsPorcentaje);
            cosIncImp.CheckedChanged += new EventHandler(cambioCostosIncluyenImpuestos);
            infDes.CheckedChanged += new EventHandler(cambioInferirDescuentos);
            cbMosTodCol.CheckedChanged += new EventHandler(mostrarColumnas);
            des.TextChanged += new EventHandler(cambioDescuentoGeneral);

            colVer.BackColor = verde;
            colAzu.BackColor = azul;
            colAma.BackColor = amarillo;
            colRoj.BackColor = rojo;
            colGri.BackColor = gris;

            CargarAlmacenes();
            CargarProveedores();
            ActualizarProveedoresPedidos();

            nin.CheckedChanged += new EventHandler(cambioDescuento);
            porRen.CheckedChanged += new EventHandler(cambioDescuento);
            gen.CheckedChanged += new EventHandler(cambioDescuento);

            if (porRen.Checked || gen.Checked)
                nin.Checked = false;

            fol.KeyUp += new KeyEventHandler(fol_KeyUp);

            tc.Location = new Point(tc.Location.X, tc.Location.Y - 30);

            //datGriVieProd.KeyDown += Copy_Click;
            //tbCodBar.Text += new DragEventHandler(datGriVieProd_DragEnter);
            //tbCodBar.Text += new DragEventHandler();
            //FormClosing += new FormClosingEventHandler(Ordenes_FormClosing);
        }

        private void cambioDescuentoGeneral(object sender, EventArgs e)
        {
            if (habilitadoValueChanged)
            {
                decimal des;
                try
                {
                    des = decimal.Parse(this.des.Text);
                    if (des < 0 || des > 100)
                    {
                        this.des.Text = "";
                        throw new FormatException();
                    }
                }
                catch (FormatException ex)
                {
                    this.des.Text = "";
                    des = -1;
                }
                if (des <= 0)
                    objCom.ActualizarDescuentoGeneralFactura(idFac, null);
                else
                    objCom.ActualizarDescuentoGeneralFactura(idFac, des);

                (tabConFac.SelectedTab.Tag as object[])[4] = des;
                porDesGen = des;
                ActualizarProductosFacturaPendiente(idFac);
                //.Focus();
            }
        }

        private void dgvProdPen_KeyDown(object sender, KeyEventArgs e)
        {
            bRecPen.PerformClick();
        }

        private void dgvProdPen_SelectionChanged(object sender, EventArgs e)
        {
            if(habilitadoSelectionChanged)
                if(dgvProdPen.SelectedRows.Count > 0)
                {
                    decimal can = decimal.Parse(dgvProdPen.SelectedRows[0].Cells[2].Value + "");
                    if (can == 1)
                        lDescrProdPen.Text = can + " " + (dgvProdPen.SelectedRows[0].Cells[5].Value + "").ToLower() + " de " + dgvProdPen.SelectedRows[0].Cells[3].Value + " " + string.Format("{0:c}", can * decimal.Parse(dgvProdPen.SelectedRows[0].Cells[4].Tag + ""));
                    else
                        lDescrProdPen.Text = can + " " + (dgvProdPen.SelectedRows[0].Cells[5].Value + "").ToLower() + "s de " + dgvProdPen.SelectedRows[0].Cells[3].Value + " " + string.Format("{0:c}", can * decimal.Parse(dgvProdPen.SelectedRows[0].Cells[4].Tag + ""));
                }
        }

        private void datGriVieProd_MouseDown(object sender, MouseEventArgs e)
        {
            datGriVieProv.DoDragDrop(datGriVieProd.SelectedRows[0].Cells[0].Value + "", DragDropEffects.Copy |
               DragDropEffects.Move);
        }

        private void datGriVieProd_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
                tbCodBar.Text = e.Data.GetData(DataFormats.Text).ToString();
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void datGriVieProd_DragDrop(object sender, DragEventArgs e)
        {
            tbCodBar.Text = e.Data.GetData(DataFormats.Text).ToString();
        }

        private void AsignarIndices()
        {
            if (recPed)
            {
                indInd = 0;
                indCodBar = 1;
                indIdProd = 2;
                indIdClaAdi = 3;
                indUniPorCaj = 4;
                indCanEsp = 5;
                indCanRec = 6;
                indDescrUni = 7;
                indDescrProd = 8;
                indCosActEspSinImpu = 9;
                indCosActEsp = 10;
                indCosRecSinImpu = 11;
                indCosRec = 12;
                indProdPed = 13;
                indDescuPorRen = 14;
                indLisImp = 15;
                indNueCos = 16;
                indIvaPesos = 17;
                indIepsPesos = 18;
                indCanDev = 19;
                indMotDev = 20;
                indDescuExt = 21;
                indProdRep = 22;
                indImpoSinImpu = 23;
                indImpo = 24;
                indIdProdPed = 25;
                indUti = 26;
                indAltCom = 27;
                indIdProdPen = 28;
            }
            else
            {
                indInd = 0;
                indCodBar = 1;
                indIdProd = 2;
                indIdClaAdi = 3;
                indUniPorCaj = 4;
                indCanRec = 5;
                indDescrUni = 6;
                indDescrProd = 7;
                indCosActEspSinImpu = 8;
                indCosActEsp = 9;
                indCosRecSinImpu = 10;
                indCosRec = 11;
                indDescuPorRen = 12;
                indLisImp = 13;
                indNueCos = 14;
                indIvaPesos = 15;
                indIepsPesos = 16;
                indDescuExt = 17;
                indProdRep = 18;
                indImpoSinImpu = 19;
                indImpo = 20;
                indIdProdPed = 21;
                indUti = 22;
                indAltCom = 23;
                indIdProdPen = 24;

                //indDescrUni = 5;
                //indDescrProd = 6;
                //indCosEspAct = 7;
                //indCosRec = 8;
                //indDescuPorRen = 9;
                //indLisImp = 10;
                //indNueCos = 11;
                //indCanImp = 12;
                //indDescuExt = 13;
                //indImpo = 15;
                //indIdProdPed = 16;

                //datGriVieProv.Columns.Add("IDProveedor", "ID de proveedor");
                //datGriVieProv.Columns[3].Visible = false;
                //agrProv = new RoundedButton();
                //agrProv.Text = "Agregar proveedor";
                //agrProv.Click += new EventHandler(agrProv_Click);

                //devProd.Visible = false;

                //datGriVieProv.Columns[0].Visible = false;
                //datGriVieProv.Columns[2].Visible = false;
                //groBoxEsp.Visible = false;
                //Label lProv = new Label();
                //lProv.Text = "Proveedor:";
                //lProv.Location = new Point(10, 6);
                //lProv.Width = 85;
                //lProv.Font = new Font(p3.Font.FontFamily, 12);

                //prov = new ComboBox();
                //List<object[]> proveedores = objCom.ObtenerProveedores();

                //foreach (object[] proveedor in proveedores)
                //{
                //    ComboBoxItem cbIte = new ComboBoxItem();
                //    cbIte.Value = proveedor[0];
                //    cbIte.Text = proveedor[1] + "";
                //    prov.Items.Add(cbIte);
                //}

                //prov.Location = new Point(lProv.Location.X + lProv.Width + 10, lProv.Location.Y);
                //prov.Font = new Font(p3.Font.FontFamily, 12);
                //prov.Width = 200;
                //agrProv.Location = new Point(lProv.Location.X, prov.Location.Y + prov.Height + 10);
                //agrProv.Size = new Size(148, 46);
                //p3.Controls.Add(lProv);
                p3.Controls.Add(prov);
                p3.Controls.Add(agrProv);
                //tabConFac.Location = new Point(10, tabConFac.Location.Y);
                //tabConFac.Width = p3.Width - 10;
            }
            indIdProd2 = 0;
            indIdClaAdi2 = 0;
        }

        private void rbRec_Click(object sender, EventArgs e)
        {
            if (datGriVieProv.SelectedRows.Count > 0)
                tc.SelectedIndex = 1;
        }

        private void bSal_Click(object sender, EventArgs e)
        {
            tc.SelectedIndex = 0;
        }

        private void datGriVieProd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Control)
            {
                Clipboard.SetDataObject(datGriVieProd.SelectedRows[0].Cells[0].Value + "");
            }
        }


        private void cbAgrProv_KeyDown(object sender, KeyEventArgs e)
        {
            if(cbAgrProv.SelectedIndex != -1)
                if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                    bNuePed.PerformClick();
        }

        private void tc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tc.SelectedIndex == 1)
            {
                //Indicamos si estamos recibiendo un pedido o productos no pedidos
                if ((bool)datGriVieProv.SelectedRows[0].Cells[4].Value)
                {
                    recPed = true;
                    tbCodBar.Focus();
                }
                else
                {
                    recPed = false;
                    tbCodBar2.Focus();
                }

                //Asignamos los indices de cada columna
                AsignarIndices();

                //Actualizamos los productos esperados, e implicitamente los productos separados por facturas
                idPed = long.Parse(datGriVieProv.SelectedRows[0].Cells[0].Value + "");
                idProv = long.Parse(datGriVieProv.SelectedRows[0].Cells[3].Value + "");
                ActualizarProductosPendientes();
                ActualizarProductosPedido(idPed);

                lNomProv.Text = datGriVieProv.SelectedRows[0].Cells[1].Value + "";
                objCom.RelacionarDevolucionesCompraPedido(idPed);
            }
            else
            {
                cbMosTodCol.Checked = false;
                datGriVieProv.Focus();
            }
        }

        private void datGriVieProv_KeyDown(object sender, KeyEventArgs e)
        {
            if (datGriVieProv.SelectedRows.Count > 0)
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                {
                    e.SuppressKeyPress = true;
                    tc.SelectedIndex = 1;
                }
        }

        private void datGriVieProd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (datGriVieProd.SelectedRows.Count > 0)
                {
                    if (!(datGriVieProd.SelectedRows[0].Cells[8].Value + "").Equals(""))
                        objCom.MarcarProductoPendiente((long)datGriVieProd.SelectedRows[0].Cells[8].Value, true);
                    objCom.EliminarProductoEscaneadoPedido(long.Parse(datGriVieProd.SelectedRows[0].Cells[6].Value + ""));
                    ActualizarProductosPedido(long.Parse(datGriVieProv.SelectedRows[0].Cells[0].Value + ""));
                    datGriVieProd.Focus();
                }
            }
            //else
            //    if (e.KeyCode == Keys.C && e.Control)
            //    {
            //        MessageBox.Show("Control + C!");
            //        // copy logic
            //        //datGriVieProd.CurrentCell = datGriVieProd.SelectedRows[0].Cells[0];
                
            //        //Clipboard.SetDataObject(datGriVieProd.CurrentCell.Value.ToString(), false);
                
            //       // Clipboard.SetDataObject(datGriVieProd.SelectedRows[0].Cells[0].Value + "", true);
            //        DataGridView dgv = sender as DataGridView;
            //        dgv.Select();
            //    DataObject o = new DataObject(DataFormats.UnicodeText, "Holaa");//dgv.GetClipboardContent();
            //    //o.SetData(DataFormats.UnicodeText, "Holaa");
            //        Clipboard.SetDataObject(o);
            //    }
        }

        private void bRecPen_Click(object sender, EventArgs e)
        {
            if(dgvProdPen.SelectedRows.Count > 0)
            {
                PreguntaProductoDevolucion ppd = new PreguntaProductoDevolucion(true, (long)dgvProdPen.SelectedRows[0].Cells[0].Value, idPed, idProv, dgvProdPen.SelectedRows[0].Cells[1].Value + "", decimal.Parse(dgvProdPen.SelectedRows[0].Cells[2].Value + ""), dgvProdPen.SelectedRows[0].Cells[3].Value + "", dgvProdPen.SelectedRows[0].Cells[5].Value + "", decimal.Parse(dgvProdPen.SelectedRows[0].Cells[4].Tag + ""));
                
                if(ppd.ShowDialog() == DialogResult.OK)
                {
                    ActualizarProductosPendientes();
                }

                ppd.Dispose();

                ActualizarProductosPendientes();
            }
        }

        private void p3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bDev_Click(object sender, EventArgs e)
        {
            DevolucionesHacer dh = new DevolucionesHacer(-1, idPed, idProv);

            dh.ShowDialog();

            dh.Dispose();

            ActualizarProductosPendientes();
            ActualizarCantidades();
        }

        private void mostrarColumnas(object sender, EventArgs e)
        {
            if (cbMosTodCol.Checked)
            {
                dgvP.Columns[indCosActEspSinImpu].Visible = true;
                dgvP.Columns[indCosActEsp].Visible = true;
                dgvP.Columns[indCosRecSinImpu].Visible = true;
                dgvP.Columns[indCosRec].Visible = true;
                dgvP.Columns[indIvaPesos].Visible = true;
                dgvP.Columns[indIepsPesos].Visible = true;
                dgvP.Columns[indImpoSinImpu].Visible = true;
                dgvP.Columns[indImpo].Visible = true;
            }
            else
            {
                dgvP.Columns[indIvaPesos].Visible = false;
                dgvP.Columns[indIepsPesos].Visible = false;

                FireEvent(cosIncImp, "CheckedChanged", new EventArgs());
            }
        }

        public static void FireEvent(Object targetObject, string eventName, EventArgs e)
        {
            String methodName = "On" + eventName;

            MethodInfo mi = targetObject.GetType().GetMethod(
                  methodName,
                  BindingFlags.Instance | BindingFlags.NonPublic);

            if (mi == null)
                throw new ArgumentException("No se pudo encontrar el evento llamado " + methodName);

            mi.Invoke(targetObject, new object[] { e });
        }

        private void fol_KeyUp(object sender, KeyEventArgs e)
        {
            ActualizarFolio(idFac, fol.Text);
            (tabConFac.SelectedTab.Tag as object[])[1] = fol.Text;
        }

        private void ActualizarFolio(long idFac, string fol)
        {
            objCom.ActualizarFolioFactura(idFac, fol);
        }

        private void bAgrProd2_Click(object sender, EventArgs e)
        {
            new BuscarProducto(tbCodBar2, bCodBar2, false).Show();
        }

        private void bNuePed_Click(object sender, EventArgs e)
        {
            objCom.GenerarPedido(-1, (long)(cbAgrProv.SelectedItem as ComboBoxItem).Value, 0, 0, 0);
            ActualizarProveedoresPedidos();
            tc.SelectedIndex = 1;
        }

        private void cbAgrProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            bNuePed.Enabled = true;
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbCodBar.Focused)
            {
                if (e.KeyCode == Keys.Enter || e.KeyData == Keys.Return)
                    butAgrPro.PerformClick();
                else
                    if (e.KeyCode == Keys.F8)
                        butSelProd.PerformClick();
            }
            else
                if(tbCodBar2.Focused)
                {
                    if (e.KeyCode == Keys.Enter || e.KeyData == Keys.Return)
                        bCodBar2.PerformClick();
                    else
                        if (e.KeyCode == Keys.F8)
                            bAgrProd2.PerformClick();
                }

            //else 
            //if(fol.Focused)
            //{
            //    if(e.KeyCode == Keys.Enter)
            //    //objCom.ActualizarFolioFactura(idFac, fol.Text);
            //    //(tabConFac.SelectedTab.Tag as object[])[1] = fol.Text;
            //}
        }

        private void CargarProveedores()
        {
            List<object[]> proveedores = objCom.ObtenerProveedores();

            foreach(object[] proveedor in proveedores)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Value = proveedor[0];
                item.Text = proveedor[1] + "";
                cbAgrProv.Items.Add(item);
            }
        }

        private void Ordenes_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (datGriVieProv.SelectedRows.Count > 0)
            {
                objCom.EliminarFacturasPendientesVacias(idPed);
                if (!recPed)
                    objCom.EliminarPedidosVacios();
            }
        }

        private void cambioDescuentosAntesImpuestos(object sender, EventArgs e)
        {
            objCom.ActualizarDescuentosAntesImpuestos(idPed, desAntImp.Checked);
        }

        private void agrProv_Click(object sender, EventArgs e)
        {
            if (prov.SelectedIndex != -1)
            {
                ComboBoxItem provSel = new ComboBoxItem();
                provSel = (prov.SelectedItem as ComboBoxItem);
                idPed = objCom.GenerarPedido(-1, long.Parse(provSel.Value.ToString()), 0, 0, 0);
                datGriVieProv.Rows.Add(new object[] { idPed, provSel.Text, "", provSel.Value });
                datGriVieProv.Rows[datGriVieProv.RowCount - 1].Selected = true;
                prov.SelectedIndex = -1;
            }
        }

        private void cambioInferirDescuentos(object sender, EventArgs e)
        {
            if (infDes.Checked)
            {
                porRen.Checked = true;
                esPor.Checked = false;
                //dgvP.Columns[indCanImp].Visible = true;
            }
            //else
            //    dgvP.Columns[indCanImp].Visible = false;

            //decimal descu;
            //decimal iva;

            //habilitadoCellValueChanged = false;

            //foreach(DataGridViewRow renglon in dgvP.Rows)
            //{
            //    iva = decimal.Parse(renglon.Cells[8].Tag.ToString()) - (decimal.Parse(renglon.Cells[8].Tag.ToString()) / (decimal)1.16);
            //    descu = (((iva) * 100) / 16) / decimal.Parse(renglon.Cells[4].Value.ToString());
            //}

            //habilitadoCellValueChanged = true;
        }

        private void cambioCostosIncluyenImpuestos(object sender, EventArgs e)
        {
            habilitadoCellValueChanged = false;
            foreach (DataGridViewRow renglon in dgvP.Rows)
            {
                //habilitadoCellValueChanged = false;
                //renglon.Cells[indCosAct].Value = string.Format("{0:c}", Costo((decimal)renglon.Cells[indCosAct].Tag, renglon.Cells[indLisImp].Value.ToString()));
                //renglon.Cells[indCosEsp].Value = string.Format("{0:c}", Costo((decimal)renglon.Cells[indCosEsp].Tag, renglon.Cells[indLisImp].Value.ToString()));
                //renglon.Cells[indCosRec].Value = string.Format("{0:c}", Costo((decimal)renglon.Cells[indCosRec].Tag, renglon.Cells[indLisImp].Value.ToString()));
                //renglon.Cells[indImpo].Value = string.Format("{0:c}", Costo((decimal)renglon.Cells[indImpo].Tag, renglon.Cells[indLisImp].Value.ToString()));
                //AplicarDescuentos(renglon.Index);
            }
            habilitadoCellValueChanged = true;

            if(!cbMosTodCol.Checked)
                if(cosIncImp.Checked)
                {
                    dgvP.Columns[indCosActEsp].Visible = true;
                    dgvP.Columns[indCosActEspSinImpu].Visible = false;

                    dgvP.Columns[indCosRec].Visible = true;
                    dgvP.Columns[indCosRecSinImpu].Visible = false;
                    
                    dgvP.Columns[indImpo].Visible = true;
                    dgvP.Columns[indImpoSinImpu].Visible = false;
                }
                else
                {
                    dgvP.Columns[indCosActEsp].Visible = false;
                    dgvP.Columns[indCosActEspSinImpu].Visible = true;

                    dgvP.Columns[indCosRec].Visible = false;
                    dgvP.Columns[indCosRecSinImpu].Visible = true;

                    dgvP.Columns[indImpo].Visible = false;
                    dgvP.Columns[indImpoSinImpu].Visible = true;
                }

            objCom.ActualizarCostosIncluyenImpuestosFacturaCompra(long.Parse(datGriVieProv.SelectedRows[0].Cells[0].Value.ToString()), cosIncImp.Checked);
        }

        private void eliFac_Click(object sender, EventArgs e)
        {
            if (recPed)
            {
                foreach (DataGridViewRow renglon in dgvP.Rows)
                    objCom.EliminarProductoFacturaPendiente(idFac, renglon.Cells[indIdProd].Value.ToString(), renglon.Cells[indIdClaAdi].Value + "", bool.Parse(renglon.Cells[indProdPed].Value.ToString()), short.Parse(renglon.Cells[indInd].Value.ToString()), true);
            }
            else
            {
                foreach (DataGridViewRow renglon in dgvP.Rows)
                    objCom.EliminarProductoFacturaPendiente(idFac, renglon.Cells[indIdProd].Value.ToString(), renglon.Cells[indIdClaAdi].Value + "", false, short.Parse(renglon.Cells[indInd].Value.ToString()), true);
            }

            objCom.EliminarFacturaPendiente(idFac);
            ActualizarProductosPedido(idPed);
            //ActualizarFacturas(idPed);
            //ActualizarCantidadesReales();
        }

        

        private void cambioEsPorcentaje(object sender, EventArgs e)
        {
            if (habilitadoCheckedChanged)
            {
                objCom.ActualizarEsPorcentajePedido(idPed, esPor.Checked);
                (tabConFac.SelectedTab.Tag as object[])[3] = esPor.Checked;

                habilitadoCellValueChanged = false;
                if (esPor.Checked)
                    foreach (DataGridViewRow renglon in dgvP.Rows)
                    {
                        if (!(renglon.Cells[indDescuPorRen].Tag + "").Equals("-1") && !(renglon.Cells[indDescuPorRen].Tag + "").Equals(""))
                        {
                            renglon.Cells[indDescuPorRen].Value = renglon.Cells[indDescuPorRen].Tag.ToString().Substring(0, renglon.Cells[indDescuPorRen].Tag.ToString().IndexOf('.') + 3) + " %";
                            AplicarDescuentos(renglon.Index);
                        }
                    }
                else
                    foreach (DataGridViewRow renglon in dgvP.Rows)
                    {
                        if (!(renglon.Cells[indDescuPorRen].Tag + "").Equals("-1") && !(renglon.Cells[indDescuPorRen].Tag + "").Equals(""))
                        {
                            renglon.Cells[indDescuPorRen].Value = string.Format("{0:c}", decimal.Parse(renglon.Cells[indDescuPorRen].Tag.ToString()));
                            AplicarDescuentos(renglon.Index);
                        }
                    }
                habilitadoCellValueChanged = true;

                ActualizarCantidades();
            }
        }

        private void cambioDescuento(object sender, EventArgs e)
        {
            des.Visible = false;
            sigPor.Visible = false;
            esPor.Visible = false;
            desAntImp.Visible = false;
            dgvP.Columns[indDescuPorRen].Visible = false;

            if (nin.Checked)
            {
                objCom.ActualizarDescuentosAntesImpuestos(idPed, null);
                objCom.ActualizarEsPorcentajePedido(idPed, null);
            }

            if (porRen.Checked)
            {
                esPor.Visible = true;
                desAntImp.Visible = true;
                dgvP.Columns[indDescuPorRen].Visible = true;
                
                objCom.ActualizarEsPorcentajePedido(idPed, esPor.Checked);
            }

            if (gen.Checked)
            {
                des.Visible = true;
                desAntImp.Visible = true;
                sigPor.Visible = true;
            }

            if (habilitadoCheckedChanged)
            {
                habilitadoCheckedChanged = false;

                switch ((sender as CheckBox).Name)
                {
                    case "nin":
                        if (nin.Checked)
                        {
                            porRen.Checked = false;
                            gen.Checked = false;
                        }
                        break;
                    case "porRen":
                        nin.Checked = false;
                        break;
                    case "gen":
                        nin.Checked = false;
                        break;
                }

                if (!porRen.Checked && !gen.Checked)
                    nin.Checked = true;

                habilitadoCheckedChanged = true;
            }
        }

        private void cambioIndicacion(object sender, EventArgs e)
        {
            objCom.ActualizarEsFactura(idFac, esFac);
            if (esFac.Checked)
                tabConFac.SelectedTab.Text = tabConFac.SelectedTab.Text.Substring(0, tabConFac.SelectedTab.Text.IndexOf('.')) + ".- Factura ";
            else
                tabConFac.SelectedTab.Text = tabConFac.SelectedTab.Text.Substring(0, tabConFac.SelectedTab.Text.IndexOf('.')) + ".- Hoja ";
        }

        private void CargarAlmacenes()
        {
            List<string[]> almacenes = objCom.ObtenerAlmacenes();

            foreach (string[] almacen in almacenes)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Value = almacen[0];
                item.Text = almacen[1];

                alm.Items.Add(item);

                alm.SelectedIndex = 0;
            }
        }

        private void datGriVieFac_SelectionChanged(object sender, EventArgs e)
        {
            if (habilitadoSelectionChanged)
            {
                habilitadoSelectionChanged = false;

                if (dgvP.SelectedRows.Count > 0)
                {
                    RevisarProducto((short)dgvP.SelectedRows[0].Index, -1);
                }

                //if (!mostrarSeleccion)
                //    dgvP.ClearSelection();

                habilitadoSelectionChanged = true;
            }
        }

        private void datGriVieFac_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (habilitadoCellValueChanged)
            {
                habilitadoCellValueChanged = false;
                decimal nuevoValor;

                try
                {
                    nuevoValor = decimal.Parse(objQuiCad.ObtenerCadenaLimpia(dgvP.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "", new string[] { "$", ",", "%" }));

                    if (e.ColumnIndex == indInd)
                    {   //El usuario quiere modificar el indice
                        objCom.CambiarIndicesProductoFacturas(long.Parse(dgvP.Rows[e.RowIndex].Cells[indIdProdPed].Value + ""), short.Parse(dgvP.Rows[e.RowIndex].Cells[indInd].Value + ""));
                        //dgvP.EditingControl.Text = dgvP.CurrentCell.Value.ToString();
                        //MessageBox.Show("Este es el indice anterior: " + .EditingControl.Text);
                        ActualizarProductosFacturaPendiente(idFac);
                    }
                    else
                        if (e.ColumnIndex == indCanRec)
                        {
                            //El usuario quiere modificar la cantidad
                            objCom.ActualizarCantidadProductoFacturaPendiente((long)dgvP.Rows[e.RowIndex].Cells[indIdProdPed].Value, nuevoValor);
                            //MessageBox.Show(dgvP.Rows[e.RowIndex].Cells[indCanRec].Value + "");
                            ActualizarImporte(e);
                            ActualizarImporteSinImpuesto(e);
                            ActualizarIVA(e);
                            ActualizarIEPS(e);
                        }
                        else
                            if (e.ColumnIndex == indCosRecSinImpu)
                            {
                                //El usuario quiere modificar el costo recibido sin impuestos
                                dgvP.Rows[e.RowIndex].Cells[indCosRecSinImpu].Tag = nuevoValor;
                                dgvP.Rows[e.RowIndex].Cells[indCosRecSinImpu].Value = string.Format("{0:c}", nuevoValor);

                                dgvP.Rows[e.RowIndex].Cells[indImpoSinImpu].Tag = decimal.Parse(dgvP.Rows[e.RowIndex].Cells[indCanRec].Value + "") * decimal.Parse(dgvP.Rows[e.RowIndex].Cells[indCosRecSinImpu].Tag + "");
                                dgvP.Rows[e.RowIndex].Cells[indImpoSinImpu].Value = string.Format("{0:c}", dgvP.Rows[e.RowIndex].Cells[indImpoSinImpu].Tag);
                                
                                dgvP.Rows[e.RowIndex].Cells[indImpo].Tag = Math.Round(SumarImpuestosCosto(decimal.Parse(dgvP.Rows[e.RowIndex].Cells[indImpoSinImpu].Tag + ""), dgvP.Rows[e.RowIndex].Cells[indLisImp].Value + ""), 2);
                                dgvP.Rows[e.RowIndex].Cells[indImpo].Value = string.Format("{0:c}", dgvP.Rows[e.RowIndex].Cells[indImpo].Tag);
                                objCom.ActualizarImporteProductoFacturaCompra((long)dgvP.Rows[e.RowIndex].Cells[indIdProdPed].Value, (decimal)dgvP.Rows[e.RowIndex].Cells[indImpo].Tag);

                                ActualizarCostoRecibido(e);

                                ActualizarIVA(e);
                                ActualizarIEPS(e);
                            }
                            else
                                if (e.ColumnIndex == indCosRec)
                                {
                                    //El usuario quiere modificar el costo recibido
                                    dgvP.Rows[e.RowIndex].Cells[indCosRec].Tag = nuevoValor;
                                    dgvP.Rows[e.RowIndex].Cells[indCosRec].Value = string.Format("{0:c}", nuevoValor);

                                    objCom.ActualizarCostoProductoFacturaPendiente((long)dgvP.Rows[e.RowIndex].Cells[indIdProdPed].Value, nuevoValor);

                                    ActualizarImporte(e);
                                    ActualizarImporteSinImpuesto(e);
                                    ActualizarCostoRecibidoSinImpuestos(e);
                                    ActualizarIVA(e);
                                    ActualizarIEPS(e);
                                }
                                else
                                    if (e.ColumnIndex == indDescuPorRen)
                                    {
                                        //El usuario cambio el descuento por renglon
                                        habilitadoCellValueChanged = false;

                                        if (esPor.Checked)
                                            if (nuevoValor < 0 || nuevoValor > 100)
                                                throw new FormatException();

                                        if (nuevoValor <= 0)
                                        {
                                            dgvP.Rows[e.RowIndex].Cells[indDescuPorRen].Tag = -1;
                                            dgvP.Rows[e.RowIndex].Cells[indDescuPorRen].Value = "";
                                            objCom.ActualizarDescuentoProductoFacturaPendiente((long)dgvP.Rows[e.RowIndex].Cells[indIdProdPed].Value, decimal.Parse(dgvP.Rows[e.RowIndex].Cells[indDescuPorRen].Tag + ""));
                                        }
                                        else
                                        {
                                            objCom.ActualizarDescuentoProductoFacturaPendiente((long)dgvP.Rows[e.RowIndex].Cells[indIdProdPed].Value, decimal.Parse(dgvP.Rows[e.RowIndex].Cells[indDescuPorRen].Tag + ""));
                                            dgvP.Rows[e.RowIndex].Cells[indDescuPorRen].Tag = nuevoValor;
                                            if (esPor.Checked)
                                                dgvP.Rows[e.RowIndex].Cells[indDescuPorRen].Value = string.Format("{0:P2}", nuevoValor / 100);
                                            else
                                                dgvP.Rows[e.RowIndex].Cells[indDescuPorRen].Value = string.Format("{0:c}", nuevoValor);
                                        }

                                        AplicarDescuentos(e.RowIndex);
                                        habilitadoCellValueChanged = true;
                                        //AplicarDescuentos(e.RowIndex);
                                    }
                                    else
                                    if (e.ColumnIndex == indCanDev)
                                    {
                                        objCom.ActualizarCantidadDevueltaFacturaCompra((long)dgvP.Rows[e.RowIndex].Cells[indIdProdPed].Value, nuevoValor);
                                        dgvP.Rows[e.RowIndex].Cells[indCanDev].Tag = decimal.Parse(dgvP.Rows[e.RowIndex].Cells[indCanDev].Value.ToString());
                                    }
                                    else
                                        if (e.ColumnIndex == indImpoSinImpu)
                                        {   //El usuario quiere modificar el importe
                                            //string impoSinImpu = nuevoValor + "";
                                            //if (impoSinImpu.Contains("."))
                                            //    impoSinImpu = impoSinImpu.Substring(0, impoSinImpu.IndexOf('.') + 3);
                                            dgvP.Rows[e.RowIndex].Cells[indImpoSinImpu].Tag = nuevoValor;
                                            dgvP.Rows[e.RowIndex].Cells[indImpoSinImpu].Value = string.Format("{0:c}", nuevoValor);

                                            dgvP.Rows[e.RowIndex].Cells[indImpo].Tag = Math.Round(SumarImpuestosCosto(decimal.Parse(dgvP.Rows[e.RowIndex].Cells[indImpoSinImpu].Tag + ""), dgvP.Rows[e.RowIndex].Cells[indLisImp].Value + ""), 2);
                                            dgvP.Rows[e.RowIndex].Cells[indImpo].Value = string.Format("{0:c}", dgvP.Rows[e.RowIndex].Cells[indImpo].Tag);
                                            objCom.ActualizarImporteProductoFacturaCompra((long)dgvP.Rows[e.RowIndex].Cells[indIdProdPed].Value, (decimal)dgvP.Rows[e.RowIndex].Cells[indImpo].Tag);
                                            ActualizarCostoRecibido(e);
                                            ActualizarCostoRecibidoSinImpuestos(e);
                                            ActualizarIVA(e);
                                            ActualizarIEPS(e);
                                        }
                                        else
                                        if (e.ColumnIndex == indImpo)
                                        {   //El usuario quiere modificar el importe
                                            //string impo = nuevoValor + "";
                                            //if (impo.Contains("."))
                                            //    impo = impo.Substring(0, impo.IndexOf('.') + 3);

                                            dgvP.Rows[e.RowIndex].Cells[indImpo].Tag = Math.Round(nuevoValor, 2);
                                            dgvP.Rows[e.RowIndex].Cells[indImpo].Value = string.Format("{0:c}", dgvP.Rows[e.RowIndex].Cells[indImpo].Tag);
                                            objCom.ActualizarImporteProductoFacturaCompra((long)dgvP.Rows[e.RowIndex].Cells[indIdProdPed].Value, (decimal)dgvP.Rows[e.RowIndex].Cells[indImpo].Tag);
                                            ActualizarImporteSinImpuesto(e);
                                            ActualizarCostoRecibido(e);
                                            ActualizarCostoRecibidoSinImpuestos(e);
                                            ActualizarIVA(e);
                                            ActualizarIEPS(e);
                                        }

                    RevisarProducto((short)e.RowIndex, (sbyte)e.ColumnIndex);

                    dgvP.Rows[e.RowIndex].Selected = true;

                    ActualizarCantidades();
                }
                catch (Exception ex)
                {
                    if (ex is FormatException)
                    {
                        if (e.ColumnIndex == indCanDev)
                        {
                            objCom.ActualizarMotivoDevolucionFacturaCompra((long)dgvP.Rows[e.RowIndex].Cells[indIdProdPed].Value, dgvP.Rows[e.RowIndex].Cells[indMotDev].Value + "");

                            //RevisarProducto((short)e.RowIndex, (sbyte)e.ColumnIndex);

                            //dgvP.Rows[e.RowIndex].Selected = true;

                            //ActualizarCantidadesReales();
                        }
                        else
                        {
                            //dgvP.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag = "";
                            //dgvP.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                            //dgvP.CancelEdit();
                            if(e.ColumnIndex == indInd || e.ColumnIndex == indCanRec)
                                dgvP.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = valAnt;
                            else
                                if(e.ColumnIndex == indDescuPorRen)
                                {
                                    dgvP.Rows[e.RowIndex].Cells[indDescuPorRen].Tag = valAnt;
                                    if (esPor.Checked)
                                        dgvP.Rows[e.RowIndex].Cells[indDescuPorRen].Value = string.Format("{0:P2}", valAnt / 100);
                                    else
                                        dgvP.Rows[e.RowIndex].Cells[indDescuPorRen].Value = string.Format("{0:c}", valAnt);
                                }
                                else
                                    dgvP.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Format("{0:c}", valAnt);
                        }
                    }
                    else
                        if (ex is NullReferenceException)
                    {
                        if (e.ColumnIndex == indInd)
                        {
                            dgvP.Rows[e.RowIndex].Cells[indInd].Value = indAnt;
                        }
                        else
                            if (e.ColumnIndex == indDescuPorRen)
                        {
                            dgvP.Rows[e.RowIndex].Cells[indDescuPorRen].Tag = -1;
                            dgvP.Rows[e.RowIndex].Cells[indDescuPorRen].Value = "";
                            objCom.ActualizarDescuentoProductoFacturaPendiente((long)dgvP.Rows[e.RowIndex].Cells[indIdProdPed].Value, decimal.Parse(dgvP.Rows[e.RowIndex].Cells[indDescuPorRen].Tag + ""));
                        }
                        else
                        {
                            dgvP.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag = "";
                            dgvP.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                            objCom.ActualizarMotivoDevolucionFacturaCompra((long)dgvP.Rows[e.RowIndex].Cells[indIdProdPed].Value, dgvP.Rows[e.RowIndex].Cells[indMotDev].Value + "");
                        }

                    }
                    AplicarDescuentos(e.RowIndex);

                    RevisarProducto((short)e.RowIndex, (sbyte)e.ColumnIndex);

                    dgvP.Rows[e.RowIndex].Selected = true;

                    ActualizarCantidades();
                }

                habilitadoCellValueChanged = true;
            }
        }

        private void ActualizarImporte(DataGridViewCellEventArgs e)
        {
            //decimal canRec = decimal.Parse(dgvP.Rows[e.RowIndex].Cells[indCanRec].Value + "");
            //string cosRec = objQuiCad.ObtenerCadenaLimpia(dgvP.Rows[e.RowIndex].Cells[indCosRec].Value + "", new string[] { "$", "," });
            dgvP.Rows[e.RowIndex].Cells[indImpo].Tag = Math.Round(decimal.Parse(dgvP.Rows[e.RowIndex].Cells[indCanRec].Value + "") * decimal.Parse(objQuiCad.ObtenerCadenaLimpia(dgvP.Rows[e.RowIndex].Cells[indCosRec].Value + "", new string[] { "$", "," })), 2);
            dgvP.Rows[e.RowIndex].Cells[indImpo].Value = string.Format("{0:c}", dgvP.Rows[e.RowIndex].Cells[indImpo].Tag);
            objCom.ActualizarImporteProductoFacturaCompra(long.Parse(dgvP.Rows[e.RowIndex].Cells[indIdProdPed].Value + ""), decimal.Parse(dgvP.Rows[e.RowIndex].Cells[indImpo].Tag + ""));
        }

        private void ActualizarImporteSinImpuesto(DataGridViewCellEventArgs e)
        {
            dgvP.Rows[e.RowIndex].Cells[indImpoSinImpu].Tag = RestarImpuestosCosto(decimal.Parse(dgvP.Rows[e.RowIndex].Cells[indImpo].Tag + ""), dgvP.Rows[e.RowIndex].Cells[indLisImp].Value + "");
            dgvP.Rows[e.RowIndex].Cells[indImpoSinImpu].Value = string.Format("{0:c}", dgvP.Rows[e.RowIndex].Cells[indImpoSinImpu].Tag);
        }
        private void ActualizarCostoRecibido(DataGridViewCellEventArgs e)
        {
            dgvP.Rows[e.RowIndex].Cells[indCosRec].Value = string.Format("{0:c}", decimal.Parse(dgvP.Rows[e.RowIndex].Cells[indImpo].Tag + "") / decimal.Parse(dgvP.Rows[e.RowIndex].Cells[indCanRec].Value + ""));
            //dgvP.Rows[e.RowIndex].Cells[indCosRec].Tag = ;
            objCom.ActualizarCostoProductoFacturaPendiente((long)dgvP.Rows[e.RowIndex].Cells[indIdProdPed].Value, decimal.Parse(objQuiCad.ObtenerCadenaLimpia(dgvP.Rows[e.RowIndex].Cells[indCosRec].Value + "", new string[] { "$", "," })));
        }
        private void ActualizarCostoRecibidoSinImpuestos(DataGridViewCellEventArgs e)
        {
            dgvP.Rows[e.RowIndex].Cells[indCosRecSinImpu].Tag = decimal.Parse(dgvP.Rows[e.RowIndex].Cells[indImpoSinImpu].Tag + "") / decimal.Parse(dgvP.Rows[e.RowIndex].Cells[indCanRec].Value + "");
            dgvP.Rows[e.RowIndex].Cells[indCosRecSinImpu].Value = string.Format("{0:c}", dgvP.Rows[e.RowIndex].Cells[indCosRecSinImpu].Tag);
        }
        
        private void devProd_Click(object sender, EventArgs e)
        {
            DevolverArticulo devArt = new DevolverArticulo(dgvP);
            devArt.ShowDialog();

            if (devArt.usuarioContinuo)
            {
                ActualizarCantidades();
                dgvP.Columns[indCanDev].Visible = true;
            }
        }

        private void ActualizarIVA(DataGridViewCellEventArgs e)
        {
            if((dgvP.Rows[e.RowIndex].Cells[indLisImp].Value + "").Contains("IVA"))
                dgvP.Rows[e.RowIndex].Cells[indIvaPesos].Value = string.Format("{0:c}", ObtenerIva((decimal)dgvP.Rows[e.RowIndex].Cells[indImpo].Tag, dgvP.Rows[e.RowIndex].Cells[indLisImp].Value + ""));
        }

        private void ActualizarIEPS(DataGridViewCellEventArgs e)
        {
            if ((dgvP.Rows[e.RowIndex].Cells[indLisImp].Value + "").Contains("IEPS"))
                dgvP.Rows[e.RowIndex].Cells[indIepsPesos].Value = string.Format("{0:c}", ObtenerIeps((decimal)dgvP.Rows[e.RowIndex].Cells[indImpo].Tag, dgvP.Rows[e.RowIndex].Cells[indLisImp].Value + ""));
        }

        private void datGriVieProv_SelectionChanged(object sender, EventArgs e)
        {
            if (habilitadoSelectionChanged)
            {
                subGlo = 0;
                impGlo = 0;
                totGlo = 0;
                idPed = long.Parse(datGriVieProv.SelectedRows[0].Cells[0].Value + "");
                if ((bool)datGriVieProv.SelectedRows[0].Cells[4].Value)
                {
                    lNomTab.Text = "Productos esperados";
                    bAgrProd2.Enabled = false;
                    bCodBar2.Enabled = false;
                    groBoxEsp.Visible = true;
                    tbCodBar2.Enabled = false;
                    bAgrProd2.Enabled = false;
                    bCodBar2.Enabled = false;
                }
                else
                {
                    lNomTab.Text = "Productos escaneados";
                    bAgrProd2.Enabled = true;
                    bCodBar2.Enabled = true;
                    groBoxEsp.Visible = false;
                    tbCodBar2.Enabled = true;
                    bAgrProd2.Enabled = true;
                    bCodBar2.Enabled = true;
                }
                rRec.Enabled = true;
                datGriVieProv.Focus();
            }
        }

        private void AgregarFactura(TabPage tab, long idPed, long idFac, bool esFac, bool desPorRenEsPor, string fol, decimal desGen, sbyte numFac)
        {
            //Si este pedido, aun no tiene facturas pendientes, creamos una para empezar a escanear productos
            if (idFac == -1)
            {
                idFac = objCom.CrearFacturaPendiente(idPed);
            }

            if (idPed == -1)
            {
                idPed = objCom.GenerarPedido(-1, long.Parse(datGriVieProv.SelectedRows[0].Cells[3].Value.ToString()), 0, 0, 0);
            }

            object datosFactura = new object();
            datosFactura = new object[] { idFac, fol, esFac, desPorRenEsPor, desGen, null };
            tab.Tag = datosFactura;
            tab.BackColor = Color.White;
            if (esFac)
                tab.Text = (numFac + 1) + ".- Factura ";
            else
                tab.Text = (numFac + 1) + ".- Hoja";
            tab.SetBounds(0, 0, 815, 512);
            this.porDesGen = desGen;
            tab.Width = tabConFac.Width;

            DataGridView dgvP = new DataGridView();

            dgvP.Size = new Size(tab.Size.Width, tab.Size.Height);
            dgvP.ReadOnly = false;
            dgvP.Dock = DockStyle.Fill;
            dgvP.ScrollBars = ScrollBars.Both;
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvP, false, true, 12, 12);
            dgvP.RowHeadersVisible = false;

            if (recPed)
            {
                dgvP.ColumnCount = 29;
                //23
                dgvP.Columns[indCanEsp].Name = "canEsp";
                dgvP.Columns[indCanEsp].HeaderText = "Cantidad esperada";
                dgvP.Columns[indCanEsp].ToolTipText = "Cantidad esperada";
                dgvP.Columns[indCanEsp].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvP.Columns[indCanEsp].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvP.Columns[indCanEsp].ReadOnly = true;
                dgvP.Columns[indCanEsp].Visible = true;
                dgvP.Columns[indCanEsp].MinimumWidth = 25;
                //24
                dgvP.Columns[indCosActEspSinImpu].Name = "cosEspSinImpu";
                dgvP.Columns[indCosActEspSinImpu].HeaderText = "Costo esperado (sin impuestos)";
                dgvP.Columns[indCosActEspSinImpu].ToolTipText = "Costo esperado (sin impuestos)";
                dgvP.Columns[indCosActEspSinImpu].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvP.Columns[indCosActEspSinImpu].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvP.Columns[indCosActEspSinImpu].ReadOnly = true;
                dgvP.Columns[indCosActEspSinImpu].Visible = false;
                dgvP.Columns[indCosActEspSinImpu].MinimumWidth = 25;
                //25
                dgvP.Columns[indCosActEsp].Name = "cosEsp";
                dgvP.Columns[indCosActEsp].HeaderText = "Costo esperado";
                dgvP.Columns[indCosActEsp].ToolTipText = "Costo esperado (sin impuestos)";
                dgvP.Columns[indCosActEsp].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvP.Columns[indCosActEsp].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvP.Columns[indCosActEsp].ReadOnly = true;
                dgvP.Columns[indCosActEsp].Visible = true;
                dgvP.Columns[indCosActEsp].MinimumWidth = 25;
                //26
                dgvP.Columns[indProdPed].Name = "prodPed";
                dgvP.Columns[indProdPed].HeaderText = "Producto pedido";
                dgvP.Columns[indProdPed].ToolTipText = "Producto pedido";
                dgvP.Columns[indProdPed].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvP.Columns[indProdPed].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvP.Columns[indProdPed].ReadOnly = true;
                dgvP.Columns[indProdPed].Visible = false;
                dgvP.Columns[indProdPed].MinimumWidth = 25;

                //27
                dgvP.Columns[indCanDev].Name = "canDev";
                dgvP.Columns[indCanDev].HeaderText = "Cantidad devuelta";
                dgvP.Columns[indCanDev].ToolTipText = "Cantidad devuelta";
                dgvP.Columns[indCanDev].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvP.Columns[indCanDev].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvP.Columns[indCanDev].ReadOnly = true;
                dgvP.Columns[indCanDev].Visible = false;
                dgvP.Columns[indCanDev].MinimumWidth = 25;

                //28
                dgvP.Columns[indMotDev].Name = "motDev";
                dgvP.Columns[indMotDev].HeaderText = "Motivo devolución";
                dgvP.Columns[indMotDev].ToolTipText = "Motivo devolución";
                dgvP.Columns[indMotDev].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvP.Columns[indMotDev].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvP.Columns[indMotDev].ReadOnly = true;
                dgvP.Columns[indMotDev].Visible = false;
                dgvP.Columns[indMotDev].MinimumWidth = 25;
            }
            else
            {
                dgvP.ColumnCount = 25;
                //23
                dgvP.Columns[indCosActEspSinImpu].Name = "cosActSinImpu";
                dgvP.Columns[indCosActEspSinImpu].HeaderText = "Costo actual (sin impuestos)";
                dgvP.Columns[indCosActEspSinImpu].ToolTipText = "Costo actual (sin impuestos)";
                dgvP.Columns[indCosActEspSinImpu].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvP.Columns[indCosActEspSinImpu].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvP.Columns[indCosActEspSinImpu].ReadOnly = true;
                dgvP.Columns[indCosActEspSinImpu].Visible = false;
                dgvP.Columns[indCosActEspSinImpu].MinimumWidth = 25;
                //24
                dgvP.Columns[indCosActEsp].Name = "cosAct";
                dgvP.Columns[indCosActEsp].HeaderText = "Costo actual";
                dgvP.Columns[indCosActEsp].ToolTipText = "Costo actual";
                dgvP.Columns[indCosActEsp].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvP.Columns[indCosActEsp].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvP.Columns[indCosActEsp].ReadOnly = true;
                dgvP.Columns[indCosActEsp].Visible = true;
                dgvP.Columns[indCosActEsp].MinimumWidth = 25;
            }
            //1
            dgvP.Columns[indInd].Name = "indInd";
            dgvP.Columns[indInd].HeaderText = "";
            dgvP.Columns[indInd].ToolTipText = "Indice";
            dgvP.Columns[indInd].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvP.Columns[indInd].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvP.Columns[indInd].ReadOnly = false;
            dgvP.Columns[indInd].Visible = true;
            //dgvP.Columns[indInd].Width = 50;
            dgvP.Columns[indInd].MinimumWidth = 25;
            //2
            dgvP.Columns[indCodBar].Name = "codBar";
            dgvP.Columns[indCodBar].HeaderText = "Código de barras";
            dgvP.Columns[indCodBar].ToolTipText = "Código de barras";
            dgvP.Columns[indCodBar].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvP.Columns[indCodBar].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvP.Columns[indCodBar].ReadOnly = true;
            dgvP.Columns[indCodBar].Visible = true;
            //dgvP.Columns[indCodBar].Width = 25;
            dgvP.Columns[indCodBar].MinimumWidth = 25;
            //3
            dgvP.Columns[indIdProd].Name = "idProd";
            dgvP.Columns[indIdProd].HeaderText = "ID de producto";
            dgvP.Columns[indIdProd].ReadOnly = true;
            dgvP.Columns[indIdProd].Visible = false;
            dgvP.Columns[indIdProd].MinimumWidth = 100;
            //4
            dgvP.Columns[indIdClaAdi].Name = "idClaAdi";
            dgvP.Columns[indIdClaAdi].Name = "Clave adicional";
            dgvP.Columns[indIdClaAdi].ReadOnly = true;
            dgvP.Columns[indIdClaAdi].Visible = false;
            dgvP.Columns[indIdClaAdi].MinimumWidth = 100;
            //5
            dgvP.Columns[indUniPorCaj].Name = "uniPorCaj";
            dgvP.Columns[indUniPorCaj].HeaderText = "Unidades por caja";
            dgvP.Columns[indUniPorCaj].ReadOnly = true;
            dgvP.Columns[indUniPorCaj].Visible = false;
            dgvP.Columns[indUniPorCaj].MinimumWidth = 50;
            //6
            dgvP.Columns[indCanRec].Name = "canRec";
            dgvP.Columns[indCanRec].HeaderText = "Cantidad recibida";
            dgvP.Columns[indCanRec].ToolTipText = "Cantidad recibida";
            dgvP.Columns[indCanRec].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvP.Columns[indCanRec].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvP.Columns[indCanRec].ReadOnly = false;
            dgvP.Columns[indCanRec].Visible = true;
            dgvP.Columns[indCanRec].Width = 70;
            dgvP.Columns[indCanRec].MinimumWidth = 70;
            //7
            dgvP.Columns[indDescrUni].Name = "descrUni";
            dgvP.Columns[indDescrUni].HeaderText = "Descripción de unidad";
            dgvP.Columns[indDescrUni].ReadOnly = true;
            dgvP.Columns[indDescrUni].Visible = false;
            dgvP.Columns[indDescrUni].MinimumWidth = 50;
            //8
            dgvP.Columns[indDescrProd].Name = "indDescrProd";
            dgvP.Columns[indDescrProd].HeaderText = "Descripción";
            dgvP.Columns[indDescrProd].ToolTipText = "Descripción";
            dgvP.Columns[indDescrProd].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvP.Columns[indDescrProd].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvP.Columns[indDescrProd].ReadOnly = true;
            dgvP.Columns[indDescrProd].Visible = true;
            dgvP.Columns[indDescrProd].MinimumWidth = 325;
            //9
            dgvP.Columns[indCosRecSinImpu].Name = "cosRecSinImpu";
            dgvP.Columns[indCosRecSinImpu].HeaderText = "Costo recibido (sin impuestos)";
            dgvP.Columns[indCosRecSinImpu].ToolTipText = "Costo recibido (sin impuestos)";
            dgvP.Columns[indCosRecSinImpu].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvP.Columns[indCosRecSinImpu].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvP.Columns[indCosRecSinImpu].ReadOnly = false;
            dgvP.Columns[indCosRecSinImpu].Visible = false;
            dgvP.Columns[indCosRecSinImpu].MinimumWidth = 25;
            //10
            dgvP.Columns[indCosRec].Name = "cosRec";
            dgvP.Columns[indCosRec].HeaderText = "Costo recibido";
            dgvP.Columns[indCosRec].ToolTipText = "Costo recibido";
            dgvP.Columns[indCosRec].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvP.Columns[indCosRec].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvP.Columns[indCosRec].ReadOnly = false;
            dgvP.Columns[indCosRec].Visible = true;
            dgvP.Columns[indCosRec].MinimumWidth = 25;
            //11
            dgvP.Columns[indDescuPorRen].Name = "descuPorRen";
            dgvP.Columns[indDescuPorRen].HeaderText = "Descuento por renglon";
            dgvP.Columns[indDescuPorRen].ToolTipText = "Descuento por renglon";
            dgvP.Columns[indDescuPorRen].ReadOnly = false;
            if (porRen.Checked)
                dgvP.Columns[indDescuPorRen].Visible = true;
            else
                dgvP.Columns[indDescuPorRen].Visible = false;
            dgvP.Columns[indDescuPorRen].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvP.Columns[indDescuPorRen].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvP.Columns[indDescuPorRen].MinimumWidth = 25;
            //12
            dgvP.Columns[indLisImp].Name = "lisImp";
            dgvP.Columns[indLisImp].HeaderText = "Lista de impuestos";
            dgvP.Columns[indLisImp].ReadOnly = true;
            dgvP.Columns[indLisImp].Visible = false;
            dgvP.Columns[indLisImp].MinimumWidth = 50;
            //13
            dgvP.Columns[indNueCos].Name = "nueCos";
            dgvP.Columns[indNueCos].HeaderText = "Nuevo costo";
            dgvP.Columns[indNueCos].ReadOnly = true;
            dgvP.Columns[indNueCos].Visible = false;
            dgvP.Columns[indNueCos].MinimumWidth = 100;
            //14
            dgvP.Columns[indIvaPesos].Name = "ivaPes";
            dgvP.Columns[indIvaPesos].HeaderText = "IVA";
            dgvP.Columns[indIvaPesos].ToolTipText = "IVA";
            dgvP.Columns[indIvaPesos].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvP.Columns[indIvaPesos].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvP.Columns[indIvaPesos].ReadOnly = true;
            dgvP.Columns[indIvaPesos].Visible = false;
            dgvP.Columns[indIvaPesos].MinimumWidth = 25;
            //15
            dgvP.Columns[indIepsPesos].Name = "iepsPes";
            dgvP.Columns[indIepsPesos].HeaderText = "IEPS";
            dgvP.Columns[indIepsPesos].ToolTipText = "IEPS";
            dgvP.Columns[indIepsPesos].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvP.Columns[indIepsPesos].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvP.Columns[indIepsPesos].ReadOnly = true;
            dgvP.Columns[indIepsPesos].Visible = false;
            dgvP.Columns[indIepsPesos].MinimumWidth = 25;
            //16
            dgvP.Columns[indDescuExt].Name = "descuExt";
            dgvP.Columns[indDescuExt].HeaderText = "Descuento extra";
            dgvP.Columns[indDescuExt].ToolTipText = "Descuento extra";
            dgvP.Columns[indDescuExt].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvP.Columns[indDescuExt].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvP.Columns[indDescuExt].ReadOnly = false;
            dgvP.Columns[indDescuExt].Visible = false;
            dgvP.Columns[indDescuExt].MinimumWidth = 25;
            //17
            dgvP.Columns[indProdRep].Name = "prodRep";
            dgvP.Columns[indProdRep].HeaderText = "Producto repetido";
            dgvP.Columns[indProdRep].ReadOnly = true;
            dgvP.Columns[indProdRep].Visible = false;
            dgvP.Columns[indProdRep].MinimumWidth = 25;
            //18
            dgvP.Columns[indImpoSinImpu].Name = "impoSinImpu";
            dgvP.Columns[indImpoSinImpu].HeaderText = "Importe (sin impuestos)";
            dgvP.Columns[indImpoSinImpu].ToolTipText = "Importe (sin impuestos)";
            dgvP.Columns[indImpoSinImpu].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvP.Columns[indImpoSinImpu].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvP.Columns[indImpoSinImpu].ReadOnly = false;
            dgvP.Columns[indImpoSinImpu].Visible = false;
            dgvP.Columns[indImpoSinImpu].MinimumWidth = 25;
            //19
            dgvP.Columns[indImpo].Name = "impo";
            dgvP.Columns[indImpo].HeaderText = "Importe";
            dgvP.Columns[indImpo].ToolTipText = "Importe";
            dgvP.Columns[indImpo].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvP.Columns[indImpo].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvP.Columns[indImpo].ReadOnly = false;
            dgvP.Columns[indImpo].Visible = true;
            dgvP.Columns[indImpo].MinimumWidth = 25;
            //20
            dgvP.Columns[indIdProdPed].Name = "idProdPed";
            dgvP.Columns[indIdProdPed].HeaderText = "ID del producto pedido";
            dgvP.Columns[indIdProdPed].ReadOnly = true;
            dgvP.Columns[indIdProdPed].Visible = false;
            dgvP.Columns[indIdProdPed].MinimumWidth = 25;
            //21
            dgvP.Columns[indUti].Name = "uti";
            dgvP.Columns[indUti].HeaderText = "Utilidad";
            dgvP.Columns[indUti].ReadOnly = true;
            dgvP.Columns[indUti].Visible = false;
            dgvP.Columns[indUti].MinimumWidth = 25;
            //22
            dgvP.Columns[indAltCom].Name = "altCom";
            dgvP.Columns[indAltCom].HeaderText = "Alta completa";
            dgvP.Columns[indAltCom].ReadOnly = true;
            dgvP.Columns[indAltCom].Visible = false;
            dgvP.Columns[indAltCom].MinimumWidth = 25;
            //23
            dgvP.Columns[indIdProdPen].Name = "idProdPen";
            dgvP.Columns[indIdProdPen].HeaderText = "ID de producto pendiente";
            dgvP.Columns[indIdProdPen].ReadOnly = true;
            dgvP.Columns[indIdProdPen].Visible = false;
            dgvP.Columns[indIdProdPen].MinimumWidth = 25;

            dgvP.SelectionChanged += new EventHandler(datGriVieFac_SelectionChanged);
           // dgvP.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dgvP_DataGridViewEditingControlShowingEventHandler);
            dgvP.CellBeginEdit += new DataGridViewCellCancelEventHandler(dgvP_CellBeginEdit);
            dgvP.CellEndEdit += new DataGridViewCellEventHandler(datGriVieFac_CellEndEdit);
            dgvP.CellValueChanged += new DataGridViewCellEventHandler(datGriVieFac_CellValueChanged);
            //dgvP.CellClick += new DataGridViewCellEventHandler(datGriVieFac_CellClick);
            dgvP.AllowUserToAddRows = false;
            dgvP.MultiSelect = false;
            dgvP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            dgvP.KeyDown += new KeyEventHandler(presionoTecla);

            tab.Controls.Add(dgvP);

            //Indicar cual es su id en la bd
            dgvP.Tag = idFac;

            this.dgvP = dgvP;
            //Cargar productos de la factura si recibi un idFac


            //Cargando los productos de la factura
            ActualizarProductosFacturaPendiente(idFac);

            tabConFac.TabPages.Add(tab);

            if (desGen > 0)
                gen.Checked = true;
        }

        private void dgvP_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == indInd || e.ColumnIndex == indCanRec)
                valAnt = decimal.Parse(dgvP.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "");
            else
                if (e.ColumnIndex == indCosRec)
                    valAnt = decimal.Parse(objQuiCad.ObtenerCadenaLimpia(dgvP.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag + "", new string[] { "$", "," }));
                else
                    valAnt = decimal.Parse(dgvP.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag + "");
        }

        private void dgvP_DataGridViewEditingControlShowingEventHandler(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //(DataGridViewTextBoxEditingControl)e.Control.KeyDown += new KeyEventHandler(dgvP_KeyPress);
        }

        private void datGriVieFac_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("datGriVieFac_CellEndEdit!");
            //decimal nueVal;
            //try
            //{
            //    nueVal = decimal.Parse(dgvP.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "");
            //}
            //catch (Exception ex) 
            //{
            //    dgvP.CancelEdit();
            //}
            if (e.RowIndex < dgvP.Rows.Count - 1)
            {
                try
                {
                    //DataGridViewCell cell = dgvP.Rows[e.RowIndex + 1].Cells[e.ColumnIndex];
                    //dgvP.CurrentCell = cell;
                    //MessageBox.Show(dgvP.BeginEdit(true) + "");


                    DataGridViewCell cell = dgvP.Rows[e.RowIndex + 1].Cells[e.ColumnIndex];
                    dgvP.CurrentCell = cell;
                    //MessageBox.Show(dgvP.CurrentCell.Value + "");
                    //MessageBox.Show("Se inicio a editar la siguiente celda: " + dgvP.BeginEdit(true));
                    dgvP.BeginEdit(true);
                }
                catch (InvalidOperationException ex) { dgvP.Rows[e.RowIndex].Selected = true; }
                
            }

            //MessageBox.Show("Termino CellEndEdit!");
        }

        private void datGriVieFac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (dgvP.Columns[e.ColumnIndex].ReadOnly)
                {
                    habilitadoSelectionChanged = false;

                    if (e.RowIndex == renSel && dgvP.Rows[e.RowIndex].Selected)
                    {
                        mostrarSeleccion = false;
                        devProd.Enabled = false;
                        dgvP.Rows[e.RowIndex].Selected = false;
                    }
                    else
                    {
                        mostrarSeleccion = true;
                        devProd.Enabled = true;
                        dgvP.Rows[e.RowIndex].Selected = true;
                    }

                    habilitadoSelectionChanged = true;
                }

                renSel = (short)e.RowIndex;
            }
        }

        private void ActualizarProductosFacturaPendiente(long idFac)
        {
            habilitadoSelectionChanged = false;

            List<object[]> productos = objCom.ObtenerProductosFacturaPendiente(idFac);
            ushort ren;
            decimal canDes, canImp;
            object[] obj;
            object temp;

            dgvP.Rows.Clear();

            habilitadoSelectionChanged = true;

            objCos = new Costo(recPed);

            foreach (object[] producto in productos)
            {
                //dgvP.Rows.Add(new object[] { producto[18], producto[0], producto[1], producto[2], producto[4], producto[5], producto[6], obj[1], obj[0], producto[10], producto[11], producto[12], producto[14], producto[17] });
                habilitadoCellValueChanged = false;
                habilitadoSelectionChanged = false;

                dgvP.Rows.Add();

                ren = (ushort)(dgvP.Rows.Count - 1);

                if (recPed)
                {
                    dgvP.Rows[ren].Cells[indCanEsp].Value = producto[3];

                    dgvP.Rows[ren].Cells[indCosActEspSinImpu].Tag = objCos.RestarImpuestosCosto((decimal)producto[7], producto[11] + "");
                    dgvP.Rows[ren].Cells[indCosActEsp].Tag = producto[7];
                    dgvP.Rows[ren].Cells[indCosActEspSinImpu].Value = string.Format("{0:c}", dgvP.Rows[ren].Cells[indCosActEspSinImpu].Tag);
                    dgvP.Rows[ren].Cells[indCosActEsp].Value = string.Format("{0:c}", producto[7]);

                    dgvP.Rows[ren].Cells[indProdPed].Value = producto[10];
                }
                else
                {
                    dgvP.Rows[ren].Cells[indCosActEspSinImpu].Tag = objCos.RestarImpuestosCosto((decimal)producto[13], producto[11] + "");
                    dgvP.Rows[ren].Cells[indCosActEsp].Tag = producto[13];
                    dgvP.Rows[ren].Cells[indCosActEspSinImpu].Value = string.Format("{0:c}", dgvP.Rows[ren].Cells[indCosActEspSinImpu].Tag);
                    dgvP.Rows[ren].Cells[indCosActEsp].Value = string.Format("{0:c}", producto[13]);
                }

                dgvP.Rows[ren].Cells[indCosRecSinImpu].Tag = objCos.RestarImpuestosCosto((decimal)producto[8], producto[11] + "");
                dgvP.Rows[ren].Cells[indCosRec].Tag = producto[8];
                dgvP.Rows[ren].Cells[indDescuPorRen].Tag = producto[9];
                dgvP.Rows[ren].Cells[indDescuExt].Tag = producto[17];

                if ((producto[1] + "").Equals(""))
                    dgvP.Rows[ren].Cells[indCodBar].Value = producto[0];
                else
                    dgvP.Rows[ren].Cells[indCodBar].Value = producto[1];
                dgvP.Rows[ren].Cells[indInd].Value = producto[18];
                dgvP.Rows[ren].Cells[indIdProd].Value = producto[0];
                dgvP.Rows[ren].Cells[indIdClaAdi].Value = producto[1];
                dgvP.Rows[ren].Cells[indUniPorCaj].Value = producto[2];
                dgvP.Rows[ren].Cells[indCanRec].Value = producto[4];
                dgvP.Rows[ren].Cells[indDescrUni].Value = producto[5];
                dgvP.Rows[ren].Cells[indDescrProd].Value = producto[6];
                dgvP.Rows[ren].Cells[indCosRecSinImpu].Value = string.Format("{0:c}", dgvP.Rows[ren].Cells[indCosRecSinImpu].Tag);
                dgvP.Rows[ren].Cells[indCosRec].Value = string.Format("{0:c}", producto[8]);
                if (!(dgvP.Rows[ren].Cells[indDescuPorRen].Tag + "").Equals(""))
                    if (porRen.Checked)
                        if (esPor.Checked)
                            dgvP.Rows[ren].Cells[indDescuPorRen].Value = string.Format("{0:P2}", (decimal)dgvP.Rows[ren].Cells[indDescuPorRen].Tag / 100);
                        else
                            dgvP.Rows[ren].Cells[indDescuPorRen].Value = string.Format("{0:c}", dgvP.Rows[ren].Cells[indDescuPorRen].Tag);
                dgvP.Rows[ren].Cells[indLisImp].Value = producto[11];
                dgvP.Rows[ren].Cells[indNueCos].Value = producto[12];
                dgvP.Rows[ren].Cells[indDescuExt].Value = string.Format("{0:c}", producto[17]);
                //dgvP.Rows[ren].Cells[indProdRep].Value
                dgvP.Rows[ren].Cells[indIdProdPed].Value = producto[20];

                if ((producto[19] + "").Equals(""))
                    producto[19] = CalcularImporteConImpuestos(ren, desAntImp.Checked);
                dgvP.Rows[ren].Cells[indImpo].Tag = producto[19];
                dgvP.Rows[ren].Cells[indImpoSinImpu].Tag = objCos.RestarImpuestosCosto((decimal)producto[19], producto[11] + "");

                dgvP.Rows[ren].Cells[indImpoSinImpu].Value = string.Format("{0:c}", dgvP.Rows[ren].Cells[indImpoSinImpu].Tag);
                dgvP.Rows[ren].Cells[indImpo].Value = string.Format("{0:c}", producto[19]);
                    
                dgvP.Rows[ren].Cells[indIvaPesos].Tag = ObtenerIva((decimal)producto[19], producto[11] + "");
                dgvP.Rows[ren].Cells[indIepsPesos].Tag = ObtenerIeps((decimal)producto[19], producto[11] + "");
                if ((decimal)dgvP.Rows[ren].Cells[indIvaPesos].Tag > 0)
                    dgvP.Rows[ren].Cells[indIvaPesos].Value = string.Format("{0:c}", dgvP.Rows[ren].Cells[indIvaPesos].Tag);
                if ((decimal)dgvP.Rows[ren].Cells[indIepsPesos].Tag > 0)
                    dgvP.Rows[ren].Cells[indIepsPesos].Value = string.Format("{0:c}", dgvP.Rows[ren].Cells[indIepsPesos].Tag);
                dgvP.Rows[ren].Cells[indUti].Value = producto[21];
                dgvP.Rows[ren].Cells[indAltCom].Value = producto[22];
                dgvP.Rows[ren].Cells[indIdProdPen].Value = producto[23];
                habilitadoCellValueChanged = true;
                habilitadoSelectionChanged = true;
                    
                //0 "indInd";
                //1 "idProd";
                //2 "idClaAdi";
                //3 "uniPorCaj";
                //4 "canRec";
                //5 "descrUni";
                //6 "indDescrProd";
                //7 "cosActSinImpu";
                //8 "cosAct";
                //9 "cosRecSinImpu";
                //10 "cosRec";
                //11 "descuPorRen";
                //12 "lisImp";
                //13 "nueCos";
                //14 "ivaPes";
                //15 "iepsPes";
                //16 "descuExt";
                //17 "prodRep";
                //18 "impoSinImpu";
                //19 "impo";
                //20 "idProdPed";

                AplicarDescuentos(ren);
                    
                //idFac = (long)(tabConFac.SelectedTab.Tag as object[])[0];

                RevisarProducto((short)ren, -1);
                //if (dgvP.Rows.Count > 0)
                //{
                //    dgvP.Rows[ren].Selected = true;
                //    dgvP.CurrentCell = dgvP.Rows[ren].Cells[indCodBar];
                //}

                foreach(DataGridViewRow renglon in dgvP.Rows)
                {
                    foreach(DataGridViewCell celda in renglon.Cells)
                    {
                        //if (celda.Visible == true && !celda.Style.BackColor.Equals(Color.White))
                        //    MessageBox.Show("Esta celda esta en blanco. El nombre de la columna es: " + dgvP.Columns[celda.ColumnIndex].Name);
                    }
                }
            }

            if(dgvP.Rows.Count > 0)
            {
                dgvP.CurrentCell = dgvP.Rows[dgvP.Rows.Count - 1].Cells[indCodBar];
            }

            ActualizarCantidades();
        }

        private decimal CalcularImporteConImpuestos(ushort ren, bool descuAntImpu)
        {
            decimal impo;

            if(descuAntImpu)
                impo = (decimal)dgvP.Rows[ren].Cells[indCanRec].Value * (decimal)dgvP.Rows[ren].Cells[indCosRecSinImpu].Tag;
            else
                impo = (decimal)dgvP.Rows[ren].Cells[indCanRec].Value * (decimal)dgvP.Rows[ren].Cells[indCosRec].Tag;
            
            if (!(dgvP.Rows[ren].Cells[indDescuExt].Value + "").Equals(""))
                impo -= (decimal)dgvP.Rows[ren].Cells[indDescuExt].Value;
            if (porRen.Checked)
                if (!(dgvP.Rows[ren].Cells[indDescuPorRen].Value + "").Equals(""))
                    if (esPor.Checked)
                        impo -= impo * ((decimal)dgvP.Rows[ren].Cells[indDescuPorRen].Tag / 100);
                    else
                        impo -= (decimal)dgvP.Rows[ren].Cells[indDescuPorRen].Value;

            if (descuAntImpu)
                impo = objCos.SumarImpuestosCosto(impo, dgvP.Rows[ren].Cells[indLisImp].Value + "");
            //Falta aplicar descuentos extra que se le hacen a la factura.
            return impo;
        }

        private decimal ObtenerIva(decimal cos, string lisImp)
        {
            byte ind;
            // idImp:1,descrProd:IVA,val:16;idImp:4,descrProd:IEPS,val:26.5
            if (lisImp.Contains("IVA"))
            {
                ind = (byte)(lisImp.IndexOf("IVA") + 8);
                cos = cos - (cos / ((decimal.Parse(lisImp.Substring(ind, lisImp.IndexOf(';') - ind)) / 100) + 1));
            }
            else
                cos = 0;

            return cos;
        }

        private decimal ObtenerIeps(decimal cos, string lisImp)
        {
            byte ind;
            // idImp:1,descrProd:IVA,val:16;idImp:4,descrProd:IEPS,val:26.5

            if (lisImp.Contains("IEPS"))
            {
                ind = (byte)(lisImp.IndexOf("IEPS") + 9);
                cos = cos - (cos / ((decimal.Parse(lisImp.Substring(ind, lisImp.LastIndexOf(';') - ind)) / 100) + 1));
            }
            else
                cos = 0;

            return cos;
        }

        private void AplicarDescuentos(int ren)
        {
            if(cbMosCosDes.Checked)
            {
                //if (porDesGen == -1)
                //    dgvP.Rows[ren].Cells[indCosRec].Value = string.Format("{0:c}", Costo((decimal)dgvP.Rows[ren].Cells[indCosRec].Tag, dgvP.Rows[ren].Cells[indLisImp].Value.ToString()));
                //else
                //{
                decimal can, cos;

                //if(!cosIncImp.Checked)
                //    cos = RestarImpuestosCosto((decimal)dgvP.Rows[ren].Cells[indCosRec].Tag, dgvP.Rows[ren].Cells[indImp].Value.ToString());

                //if (desAntImp.Checked)
                //{
                //    cos = RestarImpuestosCosto((decimal)dgvP.Rows[ren].Cells[indCosRec].Tag, dgvP.Rows[ren].Cells[indImp].Value.ToString());

                //    //Aplica descuento general
                //    cos = cos - ((cos / 100) * porDesGen);

                //    //Aplica descuento por renglon
                //    if (!dgvP.Rows[ren].Cells[indDescu].Tag.ToString().Equals("-1"))
                //    {
                //        if (esPor.Checked)
                //            cos = cos - ((cos / 100) * decimal.Parse(dgvP.Rows[ren].Cells[indDescu].Tag.ToString()));
                //        else
                //            cos -= decimal.Parse(dgvP.Rows[ren].Cells[indDescu].Tag.ToString());
                //    }

                //    //Aplica descuento extra
                //    if (!dgvP.Rows[ren].Cells[indDescuExt].Tag.ToString().Equals("-1"))
                //    {
                //        cos -= (decimal)dgvP.Rows[ren].Cells[indDescuExt].Tag;
                //    }

                //    cos = SumarImpuestosCosto(cos, dgvP.Rows[ren].Cells[indImp].Value.ToString());
                //}
                //else
                //{
                cos = Costo((decimal)dgvP.Rows[ren].Cells[indCosRec].Tag, dgvP.Rows[ren].Cells[indLisImp].Value.ToString());

                //Aplica descuento general
                cos = cos - ((cos / 100) * porDesGen);

                //Aplica descuento por renglon
                if (!dgvP.Rows[ren].Cells[indDescuPorRen].Tag.ToString().Equals("-1") && !dgvP.Rows[ren].Cells[indDescuPorRen].Tag.ToString().Equals(""))
                {
                    if (esPor.Checked)
                        cos = cos - ((cos / 100) * decimal.Parse(dgvP.Rows[ren].Cells[indDescuPorRen].Tag.ToString()));
                    else
                    {
                        can = decimal.Parse(dgvP.Rows[ren].Cells[indCanRec].Value.ToString());
                        //cos = Costo(decimal.Parse(dgvP.Rows[ren].Cells[indCosRec].Tag.ToString()), dgvP.Rows[ren].Cells[indLisImp].Value.ToString());

                        cos = ((can * cos) - decimal.Parse(dgvP.Rows[ren].Cells[indDescuPorRen].Tag.ToString())) / can;
                    }
                }

                //Aplica descuento extra
                if (!dgvP.Rows[ren].Cells[indDescuExt].Tag.ToString().Equals("-1") && !dgvP.Rows[ren].Cells[indDescuExt].Tag.ToString().Equals(""))
                {
                    if (recPed)
                    {
                        //Si este producto tiene una cantidad devuelta, necesitamos solo la cantidad que recibiremos del producto
                        if (dgvP.Rows[ren].Cells[indCanDev].Tag.ToString().Equals("") || dgvP.Rows[ren].Cells[indCanDev].Tag.ToString().Equals("-1"))
                        {
                            //No tiene cantidad devuelta
                            can = decimal.Parse(dgvP.Rows[ren].Cells[indCanRec].Value.ToString());
                            cos = ((can * cos) - (decimal)dgvP.Rows[ren].Cells[indDescuExt].Tag) / can;
                        }
                        else
                        {
                            //Tiene cantidad devuelta
                            can = decimal.Parse(dgvP.Rows[ren].Cells[indCanRec].Value.ToString());
                            cos = ((can * cos) - (decimal)dgvP.Rows[ren].Cells[indDescuExt].Tag) / can;
                            //can = decimal.Parse(dgvP.Rows[ren].Cells[indCanRec].Value.ToString()) - decimal.Parse(dgvP.Rows[ren].Cells[15].Value.ToString());
                            //cos = ((can * cos) - decimal.Parse(dgvP.Rows[ren].Cells[15].Tag.ToString())) / can;
                        }
                    }
                    else
                        can = decimal.Parse(dgvP.Rows[ren].Cells[indCanRec].Value.ToString());

                }
                //}
                //Costo((decimal)dgvP.Rows[ren].Cells[indCosRec].Tag, dgvP.Rows[ren].Cells[indImp].Value.ToString());

                dgvP.Rows[ren].Cells[indCosRec].Value = string.Format("{0:c}", cos);
                //}
            }
        }

        private decimal SumarImpuestosCosto(decimal cos, string lisImp)
        {
            byte ind;
            // idImp:1,descrProd:IVA,val:16;idImp:4,descrProd:IEPS,val:26.5
            if (lisImp.Contains("IVA"))
            {
                ind = (byte)(lisImp.IndexOf("IVA") + 8);
                cos = cos * ((decimal.Parse(lisImp.Substring(ind, lisImp.IndexOf(';') - ind)) / 100) + 1);
                //MessageBox.Show(lisImp.Substring(ind, lisImp.IndexOf(';') - ind));
            }

            if (lisImp.Contains("IEPS"))
            {
                ind = (byte)(lisImp.IndexOf("IEPS") + 9);
                cos = cos * ((decimal.Parse(lisImp.Substring(ind, lisImp.LastIndexOf(';') - ind)) / 100) + 1);
                //MessageBox.Show(lisImp.Substring(ind, lisImp.LastIndexOf(';') - ind));
            }
                
            return cos;
        }

        public decimal RestarImpuestosCosto(decimal cos, string lisImp)
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
                while(lisImp.Length > 0)
                {
                    cos = cos / ((decimal.Parse(lisImp.Substring(ind, lisImp.IndexOf(';') - ind)) / 100) + 1);
                    //MessageBox.Show(lisImp.Substring(ind, lisImp.IndexOf(';') - ind));
                    lisImp = lisImp.Substring(lisImp.IndexOf(';') + 1);
                }
            }

            return cos;
        }

        public decimal Costo(decimal cos, string lisImp)
        {
            if (cosIncImp.Checked)
                return cos;
            else
                return RestarImpuestosCosto(cos, lisImp);
        }

        private void presionoTecla(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                if (dgvP.SelectedRows.Count == 1)
                {
                    if (!(dgvP.SelectedRows[0].Cells[indIdProdPen].Value + "").Equals(""))
                        objCom.MarcarProductoPendiente((long)dgvP.SelectedRows[0].Cells[indIdProdPen].Value, true);
                    if (recPed)
                        EliminarProductoFacturaPendiente(dgvP.SelectedRows[0].Cells[indIdProd].Value.ToString(), dgvP.SelectedRows[0].Cells[indIdClaAdi].Value.ToString(), bool.Parse(dgvP.SelectedRows[0].Cells[indProdPed].Value.ToString()), short.Parse(dgvP.SelectedRows[0].Cells[indInd].Value.ToString()));
                    else
                        EliminarProductoFacturaPendiente(dgvP.SelectedRows[0].Cells[indIdProd].Value.ToString(), dgvP.SelectedRows[0].Cells[indIdClaAdi].Value.ToString(), false, short.Parse(dgvP.SelectedRows[0].Cells[indInd].Value.ToString()));
                }
            }
            else
                if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                {
                    AltaProducto ap;
                    if (!(bool)dgvP.SelectedRows[0].Cells[indAltCom].Value)
                    {
                        ap = new AltaProducto(false, dgvP.SelectedRows[0].Cells[indIdProd].Value + "", false);
                        if (ap.ShowDialog() == DialogResult.OK)
                        {
                            objCom.MarcarAltaCompleta((long)dgvP.SelectedRows[0].Cells[indIdProdPed].Value, true);
                            ActualizarProductosFacturaPendiente(idFac);
                        }
                        ap.Dispose();
                    }
                }
                else
            //    if (e.KeyCode == Keys.Up)
            //{
            //    if (dgvP.SelectedRows.Count > 0 && dgvP.SelectedRows[0].Index > 0)
            //    {
            //        mostrarSeleccion = true;
            //        //habilitadoSelectionChanged = false;
            //        dgvP.Rows[dgvP.SelectedRows[0].Index - 1].Selected = true;
            //        //habilitadoSelectionChanged = true;
            //        mostrarSeleccion = false;
            //    }
            //}
            //else
            //       if (e.KeyCode == Keys.Down)
            //{
            //    if (dgvP.SelectedRows.Count > 0 && dgvP.SelectedRows[0].Index < dgvP.Rows.Count - 1)
            //    {
            //        mostrarSeleccion = true;
            //        dgvP.Rows[dgvP.SelectedRows[0].Index + 1].Selected = true;
            //        mostrarSeleccion = false;
            //    }
            //}

            if (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Add)
                    {
                        DataGridView dgv = (DataGridView)tabConFac.SelectedTab.Controls[0];
                        AgregarProductoFacturaPendiente(dgv, dgv.SelectedRows[0].Cells[indIdProd].Value + "", 1, true);
                        ActualizarCantidades();
                        ActualizarImagenPorTabSeleccionado();
                    }
                    else
                        if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract)
                        {
                            DataGridView dgv = (DataGridView)tabConFac.SelectedTab.Controls[0];
                            AgregarProductoFacturaPendiente(dgv, dgv.SelectedRows[0].Cells[indInd].Value + "", -1, true);
                            ActualizarCantidades();
                            ActualizarImagenPorTabSeleccionado();
                        }
        }

        private void EliminarProductoFacturaPendiente(string idProd, string idClaAdi, bool prodPed, short ind)
        {
            if (objCom.EliminarProductoFacturaPendiente(idFac, idProd, idClaAdi, prodPed, ind, false) == -1)
                ActualizarProductosPedido(idPed);
            else
                ActualizarProductosPedido(idPed);
                //ActualizarProductosFacturaPendiente(idFac);
        }

        private void AgregarProductoFacturaPendiente(DataGridView dgv, string codBar, int can, bool fueUsu)
        {
            
        }

        private void ActualizarImagenPorTabSeleccionado()
        {
            //DataGridView dgv = (DataGridView)tabControl1.SelectedTab.Controls[0];
            //ValleVerdeComun.Programacion.Producto ob = new ValleVerdeComun.Programacion.Producto();

            //if (dgv.SelectedRows.Count > 0)
            //{
            //    int cant = ob.ObtenerCantidadImagenesProducto(dgv.SelectedRows[0].Cells[0].Value + "");
            //    if (cant > 0)
            //    {
            //        Image img = null;

            //        try
            //        {
            //            img = Image.FromFile(ob.ObtenerImagenesProducto(dgv.SelectedRows[0].Cells[0].Value + "")[0]);
            //        }
            //        catch (Exception e1)
            //        {

            //        }

            //        pictureBoxImagen.Image = img;
            //        if (ventanaSecundaria != null)
            //            ventanaSecundaria.SetImagen(img);
            //    }
            //}
            //else
            //{
            //    pictureBoxImagen.Image = null;
            //    if (ventanaSecundaria != null)
            //        ventanaSecundaria.SetImagen(null);
            //}
        }

        private void ActualizarDatosPedido(long idPed)
        {
            List<String> datos = objCom.ObtenerDatosPedido(idPed);

            if (datos.Count > 0)
            {
                //habilitadoCheckedChanged = false;
                subEsp = decimal.Parse(datos[0]);
                impEsp = decimal.Parse(datos[1]);
                totEsp = decimal.Parse(datos[2]);
                if (!datos[3].Equals(""))
                    desAntImp.Checked = bool.Parse(datos[3]);
                if (!datos[4].Equals(""))
                    cosIncImp.Checked = bool.Parse(datos[4]);
                if (!datos[5].Equals(""))
                {
                    esPor.Checked = bool.Parse(datos[5]);
                    porRen.Checked = true;
                }

                labSubEsp.Text = string.Format("{0:c}", Convert.ToDecimal(subEsp));
                labImpEsp.Text = string.Format("{0:c}", Convert.ToDecimal(impEsp));
                labTotEsp.Text = string.Format("{0:c}", Convert.ToDecimal(totEsp));

                //habilitadoCheckedChanged = true;

                ActualizarCantidades();
            }
        }

        //Agregar producto a factura
        private void butAgrPro_Click(object sender, EventArgs e)
        {
            string codBar = tbCodBar.Text.Trim();
            decimal canProd;
            bool exiCodBar = false;
            //totEsp = 0.0;

            //Si el usuario escribio algo
            if (!String.IsNullOrEmpty(codBar))
            {
                //Checamos si existe
                String[] res = objCom.ExisteProductoConClaveAdicional(codBar);

                if (!res[0].Equals("-1"))
                //Si existe
                {
                    bool prodFuePed = false, codBarEsClaAdi;
                    short ren3 = 0, ren2 = 0;
                    string idProd, idClaAdi;
                    decimal can = 1, uniPorCaj;

                    if (res[1].Equals(codBar))
                    {
                        idProd = codBar;
                        idClaAdi = "";
                        uniPorCaj = 1;
                    }
                    else
                    {
                        idProd = res[1];
                        idClaAdi = codBar;
                        uniPorCaj = objCom.ObtenerUnidadesPorCaja(idClaAdi);
                    }

                    if (idClaAdi.Equals(""))
                        codBarEsClaAdi = false;
                    else
                        codBarEsClaAdi = true;

                    bool prodFuePedOEsc = false, prodRepTab2 = false, seDebProd = false;
                    idProdPen = -1;
                    // Checa que el producto venga en el pedido o haya sido escaneado rapidamente
                    foreach (DataGridViewRow producto in datGriVieProd.Rows)
                    {
                        if ((producto.Cells[0].Value + "").Equals(codBar))
                        {
                            prodFuePedOEsc = true;
                            prodRepTab2 = true;
                            can = (decimal)datGriVieProd.Rows[ren2].Cells[4].Value;
                            uniPorCaj = 1;
                                if (!(datGriVieProd.Rows[ren2].Cells[5].Value + "").Equals(""))
                                    uniPorCaj = (decimal)datGriVieProd.Rows[ren2].Cells[5].Value;
                            //datGriVieProd.Rows.RemoveAt(ind);
                            break;
                        }
                        ren2++;
                    }

                    // Checa si el producto ya se encuentra en alguna de las facturas pendientes
                    bool prodRep = false;
                    ren3 = 0;
                    foreach (TabPage factura in tabConFac.TabPages)
                    {
                        foreach (DataGridViewRow producto in (factura.Controls[0] as DataGridView).Rows)
                        {
                            if ((producto.Cells[indCodBar].Value + "").Equals(codBar))
                            {
                                if (recPed)
                                    prodFuePedOEsc = bool.Parse(producto.Cells[indProdPed].Value.ToString());
                                prodRep = true;
                                break;
                            }
                            ren3++;
                        }
                    }

                    //if (prodRep)
                    //{
                    //    MessageBox.Show("Ya escaneaste este producto.");

                    //    habilitadaSeleccion = true;
                    //    dgvP.Rows[ind].Selected = true;
                    //    habilitadaSeleccion = false;
                    //}
                    //else
                    {
                        //Si el proveedor no lo vende
                        bool usuDesCon = true;

                        if (!objCom.ProveedorVendeProductoOCaja(long.Parse(datGriVieProv.SelectedRows[0].Cells[3].Value.ToString()), codBar))
                        {
                            AvisoProveedorNoVendeProducto a = new AvisoProveedorNoVendeProducto(0);
                            a.ShowDialog();

                            usuDesCon = a.usuDesCon;
                        }

                        //El usuario desea continuar y añadir este producto
                        if (usuDesCon)
                        {
                            VerificarProducto vp;
                            if (porRen.Checked)
                                if (esPor.Checked)
                                    vp = new VerificarProducto(false, dgvP, tbCodBar, prodFuePedOEsc, rojo, 1, cosIncImp.Checked, infDes.Checked, idFac, idPed, codBar, "", can, uniPorCaj, codBarEsClaAdi, recPed, true, idProdPen);
                                else
                                    vp = new VerificarProducto(false, dgvP, tbCodBar, prodFuePedOEsc, rojo, 0, cosIncImp.Checked, infDes.Checked, idFac, idPed, codBar, "", can, uniPorCaj, codBarEsClaAdi, recPed, true, idProdPen);
                            else
                                vp = new VerificarProducto(false, dgvP, tbCodBar, prodFuePedOEsc, rojo, -1, cosIncImp.Checked, infDes.Checked, idFac, idPed, codBar, "", can, uniPorCaj, codBarEsClaAdi, recPed, true, idProdPen);

                            if (vp.ShowDialog() == DialogResult.OK)
                            {
                                if(idProdPen != -1)
                                    objCom.MarcarProductoPendiente(idProdPen, false);

                                if (prodRepTab2 || seDebProd)
                                    ActualizarProductosPedido(idPed);
                                ActualizarProductosFacturaPendiente(idFac);
                                rec.Enabled = true;
                                //else
                                //    objCom.AgregarProductoFacturaPendiente(idFac, long.Parse(datGriVieProv.SelectedRows[0].Cells[0].Value.ToString()), idProd, idClaAdi, 1, 1, 0, 0, prodFuePed);
                            }
                        }
                    }
                }
                else
                {
                    PreguntaCodigoNoExiste pcne = new PreguntaCodigoNoExiste(codBar);
                    if(pcne.ShowDialog() == DialogResult.Yes)
                    {
                        AltaRapida ar = new AltaRapida(codBar);
                        if(ar.ShowDialog() == DialogResult.OK)
                        {
                            ValleVerdeComun.Programacion.Producto producto = new ValleVerdeComun.Programacion.Producto();
                            producto.DarAltaProducto(ar.tbCodBar.Text, ar.tbNom.Text, "", 0, 1, 1, 1, 1, 1, "", false, false, false, 0, 0,0,0);
                            string idProd, idClaAdi;
                            idProd = ar.tbCodBar.Text;
                            idClaAdi = "";//p.ObtenerUltimoIdClaveAdicionalAgregada();
                            
                            string listaImpuestos = objCom.ObtenerListaImpuestos(idProd);
                            VerificarProducto vp;
                            if (idClaAdi.Equals(""))
                                vp = new VerificarProducto(false, dgvP, tbCodBar, false, rojo, -1, cosIncImp.Checked, infDes.Checked, idFac, idPed, idProd, listaImpuestos, 1, 1, false, recPed, false, -1);
                            else
                                vp = new VerificarProducto(false, dgvP, tbCodBar, false, rojo, -1, cosIncImp.Checked, infDes.Checked, idFac, idPed, idClaAdi, listaImpuestos, 1, 1, true, recPed, false, -1);
                            
                            if (vp.ShowDialog() == DialogResult.OK)
                            {
                                objCom.MarcarAltaCompleta(vp.idProdPed, false);
                                //ActualizarProductosPedido(idPed);
                                ActualizarProductosFacturaPendiente(idFac);
                            }
                            vp.Dispose();
                        }
                        ar.Dispose();
                    }
                    pcne.Dispose();
                }

                tbCodBar.Text = "";
                tbCodBar.Focus();
            }
        }
        //Agregar producto a escaneados
        private void bCodBar2_Click(object sender, EventArgs e)
        {
            string codBar = tbCodBar2.Text;

            //Si el usuario escribio algo
            if (!String.IsNullOrEmpty(codBar))
            {
                //Checamos si existe
                String[] res = objCom.ExisteProductoConClaveAdicional(codBar);

                if (!res[0].Equals("-1"))
                //Si existe
                {
                    bool prodFuePed = false;
                    short ind = 0;
                    string idProd, idClaAdi;

                    if (res[1].Equals(codBar))
                    {
                        idProd = codBar;
                        idClaAdi = "";
                    }
                    else
                    {
                        idProd = res[1];
                        idClaAdi = codBar;
                    }

                    // Checa si el producto ya se encuentra en la tabla de la izquierda
                    ind = 0;
                    bool prodRep = false;
                    idProdPen = -1;
                    foreach (DataGridViewRow producto in datGriVieProd.Rows)
                    {
                        if ((producto.Cells[indIdProd2].Value + "").Equals(idProd) || (producto.Cells[indIdClaAdi2].Value + "").Equals(idClaAdi))
                        {
                            prodRep = true;
                            break;
                        }
                        ind++;
                    }

                    if (prodRep)
                    {
                        mostrarSeleccion = true;
                        datGriVieProd.Rows[ind].Selected = true;
                        mostrarSeleccion = false;
                    }
                    else
                    {
                        if(todProdPenRec || idProdPen != -1)
                        {
                            //El usuario desea añadir este producto
                            bool codBarEsClaAdi;
                            if (idClaAdi.Equals(""))
                                codBarEsClaAdi = false;
                            else
                                codBarEsClaAdi = true;

                            VerificarProducto vp = new VerificarProducto(true, datGriVieProd, tbCodBar2, false, rojo, 1, false, false, idFac, idPed, tbCodBar2.Text, "", 1, 1, false, false, true, idProdPen);
                            //VerificarProductoRapido vp = new VerificarProductoRapido(tbCodBar2, idPed, idProd, idClaAdi, false);
                            if (vp.ShowDialog() == DialogResult.OK)
                            {
                                if (idProdPen != -1)
                                {  
                                    objCom.MarcarProductoPendiente(idProdPen, false);
                                    //objCom.AgregarProductoAPedido(idPed, idProd, idClaAdi, decimal.Parse(vp.tbCan.Text), decimal.Parse(vp.tbUniPorCaj.Text), true, idProdPen);
                                }
                                ActualizarProductosPedido(idPed);
                                //datGriVieProd.Rows[datGriVieProd.Rows.Count - 1].Selected = true;
                            }
                            vp.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Aún hay productos que nos debe el proveedor, estos se deben de recibir primero.");
                        }
                    }
                }
                else
                {
                    PreguntaCodigoNoExiste pcne = new PreguntaCodigoNoExiste(codBar);
                    if (pcne.ShowDialog() == DialogResult.Yes)
                    {
                        AltaRapida ar = new AltaRapida(codBar);
                        if (ar.ShowDialog() == DialogResult.OK)
                        {
                            ValleVerdeComun.Programacion.Producto producto = new ValleVerdeComun.Programacion.Producto();
                            producto.DarAltaProducto(ar.tbCodBar.Text, ar.tbNom.Text, "", 0, 1, 1, 1, 1, 1, "", false, false, false, 0, 0,0,0);
                            string idProd, idClaAdi;
                            idProd = ar.tbCodBar.Text;
                            idClaAdi = "";//ar.ObtenerUltimoIdClaveAdicionalAgregada();

                            string listaImpuestos = objCom.ObtenerListaImpuestos(idProd);
                            VerificarProducto vp;
                            //VerificarProductoRapido vpr;
                            if (idClaAdi.Equals(""))
                                vp = new VerificarProducto(true, datGriVieProd, tbCodBar2, false, rojo, 1, false, false, idFac, idPed, tbCodBar2.Text, "", 1, 1, false, false, false, -1);
                            else
                                vp = new VerificarProducto(true, datGriVieProd, tbCodBar2, false, rojo, 1, false, false, idFac, idPed, tbCodBar2.Text, "", 1, 1, false, false, false, -1);
                            
                            if (vp.ShowDialog() == DialogResult.OK)
                            {
                                ActualizarProductosPedido(idPed);
                                //datGriVieProd.Rows[datGriVieProd.Rows.Count - 1].Selected = true;
                                //ActualizarProductosFacturaPendiente(idFac);
                            }
                            vp.Dispose();
                        }
                        ar.Dispose();
                    }
                    pcne.Dispose();
                }

                tbCodBar2.Text = "";
                tbCodBar2.Focus();
            }
        }

        private void RevisarProducto(short renglon, sbyte columna)
        {
            //Si esta producto esta dado de alta completamente, revisa el renglon, sino, lo colorea de gris
            if((bool)dgvP.Rows[renglon].Cells[indAltCom].Value)
            {
                bool prodPed;
                if (recPed)
                    prodPed = (bool)dgvP.Rows[renglon].Cells[indProdPed].Value;
                else
                    prodPed = true;

                if (prodPed)
                {
                    decimal canEsp = 0, canRec = 0, cosActEsp = 0, cosRec = 0;

                    try
                    {
                        var cosActEspStr = dgvP.Rows[renglon].Cells[indCosActEsp].Value + "";
                        var cosRecStr = dgvP.Rows[renglon].Cells[indCosRec].Value + "";
                        var charsToRemove = new string[] { "$", "," };
                        foreach (var c in charsToRemove)
                        {
                            cosActEspStr = cosActEspStr.Replace(c, string.Empty);
                            cosRecStr = cosRecStr.Replace(c, string.Empty);
                        }
                        canRec = decimal.Parse(dgvP.Rows[renglon].Cells[indCanRec].Value.ToString());
                        if (recPed)
                            canEsp = decimal.Parse(dgvP.Rows[renglon].Cells[indCanEsp].Value.ToString());
                        else
                            canEsp = canRec;
                        cosActEsp = decimal.Parse(cosActEspStr);
                        cosRec = decimal.Parse(cosRecStr);

                        if (canEsp == canRec && cosActEsp >= cosRec)
                        {
                            dgvP.Rows[renglon].Cells[indInd].Style.BackColor = verde;
                            dgvP.Rows[renglon].Cells[indCodBar].Style.BackColor = verde;
                            dgvP.Rows[renglon].Cells[indCanEsp].Style.BackColor = verde;
                            dgvP.Rows[renglon].Cells[indCanRec].Style.BackColor = verde;
                            dgvP.Rows[renglon].Cells[indDescrProd].Style.BackColor = verde;
                            dgvP.Rows[renglon].Cells[indCosActEspSinImpu].Style.BackColor = verde;
                            dgvP.Rows[renglon].Cells[indCosActEsp].Style.BackColor = verde;
                            dgvP.Rows[renglon].Cells[indCosRecSinImpu].Style.BackColor = verde;
                            dgvP.Rows[renglon].Cells[indCosRec].Style.BackColor = verde;
                            dgvP.Rows[renglon].Cells[indDescuPorRen].Style.BackColor = verde;
                            dgvP.Rows[renglon].Cells[indIvaPesos].Style.BackColor = verde;
                            dgvP.Rows[renglon].Cells[indIepsPesos].Style.BackColor = verde;
                            dgvP.Rows[renglon].Cells[indCanDev].Style.BackColor = verde;
                            dgvP.Rows[renglon].Cells[indMotDev].Style.BackColor = verde;
                            dgvP.Rows[renglon].Cells[indDescuExt].Style.BackColor = verde;
                            dgvP.Rows[renglon].Cells[indImpoSinImpu].Style.BackColor = verde;
                            dgvP.Rows[renglon].Cells[indImpo].Style.BackColor = verde;
                        }
                        else
                        {
                            dgvP.Rows[renglon].Cells[indInd].Style.BackColor = Color.White;
                            dgvP.Rows[renglon].Cells[indCodBar].Style.BackColor = Color.White;
                            dgvP.Rows[renglon].Cells[indCanEsp].Style.BackColor = Color.White;
                            dgvP.Rows[renglon].Cells[indCanRec].Style.BackColor = Color.White;
                            dgvP.Rows[renglon].Cells[indDescrProd].Style.BackColor = Color.White;
                            dgvP.Rows[renglon].Cells[indCosActEspSinImpu].Style.BackColor = Color.White;
                            dgvP.Rows[renglon].Cells[indCosActEsp].Style.BackColor = Color.White;
                            dgvP.Rows[renglon].Cells[indCosRecSinImpu].Style.BackColor = Color.White;
                            dgvP.Rows[renglon].Cells[indCosRec].Style.BackColor = Color.White;
                            dgvP.Rows[renglon].Cells[indDescuPorRen].Style.BackColor = Color.White;
                            dgvP.Rows[renglon].Cells[indIvaPesos].Style.BackColor = Color.White;
                            dgvP.Rows[renglon].Cells[indIepsPesos].Style.BackColor = Color.White;
                            dgvP.Rows[renglon].Cells[indCanDev].Style.BackColor = Color.White;
                            dgvP.Rows[renglon].Cells[indMotDev].Style.BackColor = Color.White;
                            dgvP.Rows[renglon].Cells[indDescuExt].Style.BackColor = Color.White;
                            dgvP.Rows[renglon].Cells[indImpoSinImpu].Style.BackColor = Color.White;
                            dgvP.Rows[renglon].Cells[indImpo].Style.BackColor = Color.White;

                            //if (columna == indCanRec || columna == -1)
                            //{
                            //Revisa la cantidad esperada contra la recibida
                            if (canEsp != canRec)
                            {
                                dgvP.Rows[renglon].Cells[indCanEsp].Style.BackColor = azul;
                                dgvP.Rows[renglon].Cells[indCanRec].Style.BackColor = azul;
                            }
                            //else
                            //{
                            //    dgvP.Rows[renglon].Cells[indCanEsp].Style.BackColor = Color.White;
                            //    dgvP.Rows[renglon].Cells[indCanRec].Style.BackColor = Color.White;
                            //}

                            //if (dgvP.Rows[renglon].Cells[indCosActEsp].Style.BackColor == verde)
                            //{
                            //    dgvP.Rows[renglon].Cells[indCosActEsp].Style.BackColor = Color.White;
                            //    dgvP.Rows[renglon].Cells[indCosRec].Style.BackColor = Color.White;
                            //}
                            //}

                            //if (columna == indCosActEsp || columna == indCosRec /*Falta confirmar si este indice esta bien*/ || columna == -1)
                            //{
                            //Revisando el costo esperado contra el costo recibido
                            if (cosActEsp < cosRec)
                            {
                                dgvP.Rows[renglon].Cells[indCosActEsp].Style.BackColor = amarillo;
                                dgvP.Rows[renglon].Cells[indCosRec].Style.BackColor = amarillo;
                            }
                            //else
                            //{
                            //    dgvP.Rows[renglon].Cells[indCosRec].Style.BackColor = Color.White;
                            //    dgvP.Rows[renglon].Cells[indCosRec].Style.BackColor = Color.White;
                            //}

                            //if (dgvP.Rows[renglon].Cells[indCanEsp].Style.BackColor == verde)
                            //{
                            //    dgvP.Rows[renglon].Cells[indCanEsp].Style.BackColor = Color.White;
                            //    dgvP.Rows[renglon].Cells[indCanEsp].Style.BackColor = Color.White;
                            //}
                            //}
                        }
                        //ActualizarCantidadesReales();
                    }
                    catch (NullReferenceException ex)
                    {
                        dgvP.Rows[renglon].Cells[indInd].Style.BackColor = Color.White;
                        dgvP.Rows[renglon].Cells[indCodBar].Style.BackColor = Color.White;
                        dgvP.Rows[renglon].Cells[indCanEsp].Style.BackColor = Color.White;
                        dgvP.Rows[renglon].Cells[indCanRec].Style.BackColor = Color.White;
                        dgvP.Rows[renglon].Cells[indDescrProd].Style.BackColor = Color.White;
                        dgvP.Rows[renglon].Cells[indCosActEspSinImpu].Style.BackColor = Color.White;
                        dgvP.Rows[renglon].Cells[indCosActEsp].Style.BackColor = Color.White;
                        dgvP.Rows[renglon].Cells[indCosRecSinImpu].Style.BackColor = Color.White;
                        dgvP.Rows[renglon].Cells[indCosRec].Style.BackColor = Color.White;
                        dgvP.Rows[renglon].Cells[indDescuPorRen].Style.BackColor = Color.White;
                        dgvP.Rows[renglon].Cells[indIvaPesos].Style.BackColor = Color.White;
                        dgvP.Rows[renglon].Cells[indIepsPesos].Style.BackColor = Color.White;
                        dgvP.Rows[renglon].Cells[indCanDev].Style.BackColor = Color.White;
                        dgvP.Rows[renglon].Cells[indMotDev].Style.BackColor = Color.White;
                        dgvP.Rows[renglon].Cells[indDescuExt].Style.BackColor = Color.White;
                        dgvP.Rows[renglon].Cells[indImpoSinImpu].Style.BackColor = Color.White;
                        dgvP.Rows[renglon].Cells[indImpo].Style.BackColor = Color.White;
                    }
                }
                else
                {
                    dgvP.Rows[renglon].DefaultCellStyle.BackColor = rojo;
                }
                //else
                //{
                //    decimal canRec = 0, cosActEsp = 0, cosRec = 0;

                //    try
                //    {
                //        canRec = decimal.Parse(dgvP.Rows[renglon].Cells[indCanRec].Value.ToString());
                //        cosActEsp = (decimal)dgvP.Rows[renglon].Cells[indCosActEsp].Tag;
                //        cosRec = decimal.Parse((dgvP.Rows[renglon].Cells[indCosRec].Value + "").Substring(1));

                //        if (cosActEsp >= cosRec)
                //        {
                //            dgvP.Rows[renglon].Cells[indInd].Style.BackColor = verde;
                //            dgvP.Rows[renglon].Cells[indCodBar].Style.BackColor = verde;
                //            dgvP.Rows[renglon].Cells[indCanEsp].Style.BackColor = verde;
                //            dgvP.Rows[renglon].Cells[indCanRec].Style.BackColor = verde;
                //            dgvP.Rows[renglon].Cells[indDescrProd].Style.BackColor = verde;
                //            dgvP.Rows[renglon].Cells[indCosActEspSinImpu].Style.BackColor = verde;
                //            dgvP.Rows[renglon].Cells[indCosActEsp].Style.BackColor = verde;
                //            dgvP.Rows[renglon].Cells[indCosRecSinImpu].Style.BackColor = verde;
                //            dgvP.Rows[renglon].Cells[indCosRec].Style.BackColor = verde;
                //            dgvP.Rows[renglon].Cells[indDescuPorRen].Style.BackColor = verde;
                //            dgvP.Rows[renglon].Cells[indIvaPesos].Style.BackColor = verde;
                //            dgvP.Rows[renglon].Cells[indIepsPesos].Style.BackColor = verde;
                //            dgvP.Rows[renglon].Cells[indDescuExt].Style.BackColor = verde;
                //            dgvP.Rows[renglon].Cells[indImpoSinImpu].Style.BackColor = verde;
                //            dgvP.Rows[renglon].Cells[indImpo].Style.BackColor = verde;
                //        }
                //        else
                //        {
                //            dgvP.Rows[renglon].Cells[indInd].Style.BackColor = Color.White;
                //            dgvP.Rows[renglon].Cells[indCodBar].Style.BackColor = Color.White;
                //            dgvP.Rows[renglon].Cells[9].Style.BackColor = Color.White;

                //            if (columna == indCanRec || columna == -1) //Falta confirmar el indice
                //            {
                //                if (dgvP.Rows[renglon].Cells[7].Style.BackColor == verde)
                //                {
                //                    dgvP.Rows[renglon].Cells[indCanRec].Style.BackColor = Color.White;
                //                    dgvP.Rows[renglon].Cells[7].Style.BackColor = Color.White;
                //                }
                //            }
                //            if (columna == indCosActEsp || columna == -1)
                //            {
                //                //Revisa el costo actual contra el costo recibido
                //                if (cosActEsp < cosRec)
                //                {
                //                    dgvP.Rows[renglon].Cells[indCosActEsp].Style.BackColor = amarillo;
                //                    dgvP.Rows[renglon].Cells[indCosRec].Style.BackColor = amarillo;
                //                }
                //                else
                //                {
                //                    dgvP.Rows[renglon].Cells[indCosActEsp].Style.BackColor = Color.White;
                //                    dgvP.Rows[renglon].Cells[indCosRec].Style.BackColor = Color.White;
                //                }

                //                if (dgvP.Rows[renglon].Cells[6].Style.BackColor == verde)
                //                {
                //                    dgvP.Rows[renglon].Cells[6].Style.BackColor = Color.White;
                //                    dgvP.Rows[renglon].Cells[indProdPed].Style.BackColor = Color.White;
                //                }
                //            }
                //        }
                //        //ActualizarCantidadesReales();
                //    }
                //    catch (NullReferenceException ex)
                //    {
                //        dgvP.Rows[renglon].Cells[indInd].Style.BackColor = Color.White;
                //        dgvP.Rows[renglon].Cells[indCodBar].Style.BackColor = Color.White;
                //        dgvP.Rows[renglon].Cells[9].Style.BackColor = Color.White;
                //    }
                //}  
            }
            else
            {
                dgvP.Rows[renglon].Cells[indInd].Style.BackColor = gris;
                dgvP.Rows[renglon].Cells[indCodBar].Style.BackColor = gris;
                dgvP.Rows[renglon].Cells[indCanEsp].Style.BackColor = gris;
                dgvP.Rows[renglon].Cells[indCanRec].Style.BackColor = gris;
                dgvP.Rows[renglon].Cells[indDescrProd].Style.BackColor = gris;
                dgvP.Rows[renglon].Cells[indCosActEspSinImpu].Style.BackColor = gris;
                dgvP.Rows[renglon].Cells[indCosActEsp].Style.BackColor = gris;
                dgvP.Rows[renglon].Cells[indCosRecSinImpu].Style.BackColor = gris;
                dgvP.Rows[renglon].Cells[indCosRec].Style.BackColor = gris;
                dgvP.Rows[renglon].Cells[indDescuPorRen].Style.BackColor = gris;
                dgvP.Rows[renglon].Cells[indIvaPesos].Style.BackColor = gris;
                dgvP.Rows[renglon].Cells[indIepsPesos].Style.BackColor = gris;
                dgvP.Rows[renglon].Cells[indCanDev].Style.BackColor = gris;
                dgvP.Rows[renglon].Cells[indMotDev].Style.BackColor = gris;
                dgvP.Rows[renglon].Cells[indDescuExt].Style.BackColor = gris;
                dgvP.Rows[renglon].Cells[indImpoSinImpu].Style.BackColor = gris;
                dgvP.Rows[renglon].Cells[indImpo].Style.BackColor = gris;
            }       
        }

        private void butSelProd_Click(object sender, EventArgs e)
        {
            new BuscarProducto(tbCodBar, butAgrPro, false).Show();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            string idProd = "", descrProd = "";

            if (dgvP.SelectedRows.Count != 0)
            {
                idProd = dgvP.SelectedRows[0].Cells[indIdProd].Value.ToString();
                descrProd = dgvP.SelectedRows[0].Cells[indDescrProd].Value.ToString();
            }

            new DescuentoExtra(idFac, idProd, descrProd, true).ShowDialog();

            ActualizarProductosFacturaPendiente(idFac);
        }

        private void rec_Click(object sender, EventArgs e)
        {
            if(RevisarAltasCompletas())
            {
                bool cambieCasillaImpuestos = false;
            
                if (!cosIncImp.Checked)
                {
                    cosIncImp.Checked = true;
                    cambieCasillaImpuestos = true;
                }

                AjustarCostos ajuCos = new AjustarCostos(idPed, long.Parse((alm.SelectedItem as ComboBoxItem).Value.ToString()), tabConFac, dgvP, recPed, new object[] { null, null, datGriVieProv.SelectedRows[0].Cells[1].Value, "Daniel Gutiérrez", subEsp, impEsp, totEsp, subGlo, impGlo, totGlo, canDesGenGlo + canDesExtGlo + canDesPorRenGlo, canDevGlo, totAPagGlo, null, null, null, null, null, null }, datFac, indInd, indIdProd, indIdClaAdi, indUniPorCaj, indCanEsp, indCanRec, indDescrUni, indDescrProd, indCosActEspSinImpu, indCosActEsp, indCosRecSinImpu, indCosRec, indIdProdPed, indDescuPorRen, indLisImp, indNueCos, indIvaPesos, indIepsPesos, indCanDev, indMotDev, indDescuExt, indProdRep, indImpoSinImpu, indImpo, indProdPed, indUti);
                ajuCos.ShowDialog();

                if (cambieCasillaImpuestos)
                    cosIncImp.Checked = !cosIncImp.Checked;

                if (ajuCos.usuarioContinuo)
                {
                    ActualizarProveedoresPedidos();
                    tc.SelectedIndex = 0;
                }
                else
                    ActualizarFacturas(idPed);

                ajuCos.Dispose();
            }
            else
                MessageBox.Show("Todos los productos deben estar dados de alta completamente.");
        }

        private bool RevisarAltasCompletas()
        {
            bool altCom = true;
            foreach (TabPage factura in tabConFac.TabPages)
                if (altCom)
                    foreach (DataGridViewRow renglon in (factura.Controls[0] as DataGridView).Rows)
                    {
                        if (!(bool)renglon.Cells[indAltCom].Value)
                        {
                            altCom = false;
                            break;
                        }
                    }
                else
                    break;
            return altCom;
        }

        private void tabConFac_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void agrFac_Click(object sender, EventArgs e)
        {
            AgregarFactura(new TabPage(), idPed, -1, true, true,"", -1, sbyte.Parse(tabConFac.TabCount.ToString()));
            tabConFac.SelectedIndex = tabConFac.TabPages.Count - 1;

            eliFac.Enabled = true;
        }

        private void ActualizarProductosPendientes()
        {
            List<object[]> productosPendientes = objCom.ObtenerProductosPendientes((long)datGriVieProv.SelectedRows[0].Cells[3].Value, idPed);
            bool prodPenVis = false;
            dgvProdPen.Rows.Clear();

            lCreFav.Visible = false;
            lCreFav2.Visible = false;
            creFav = 0;

            if (productosPendientes.Count > 0)
            {
                todProdPenRec = false;
                habilitadoSelectionChanged = false;

                foreach (object[] prodPen in productosPendientes)
                {
                    if ((prodPen[5] + "").Contains("Pendiente"))
                    {
                        dgvProdPen.Rows.Add(new object[] { prodPen[0], prodPen[2], prodPen[6], prodPen[3], string.Format("{0:c}", prodPen[7]), prodPen[11] });
                        dgvProdPen.Rows[dgvProdPen.Rows.Count - 1].Cells[4].Tag = prodPen[7];
                        prodPenVis = true;
                        //dgvProdPen.Rows[dgvProdPen.Rows.Count - 1].Cells[4].Value = string.Format("{0:c}", dgvProdPen.Rows[dgvProdPen.Rows.Count - 1].Cells[4].Tag);
                    }
                    else
                    {
                        lCreFav.Visible = true;
                        lCreFav2.Visible = true;

                        creFav += decimal.Parse(prodPen[6] + "") * decimal.Parse(prodPen[7] + "");
                    }
                }
                lCreFav2.Text = string.Format("{0:c}", creFav);
                dgvProdPen.ClearSelection();
                habilitadoSelectionChanged = true;
                if (dgvProdPen.Rows.Count > 0)
                    dgvProdPen.Rows[0].Selected = true;
            }

            if(prodPenVis)
            {
                panelProductosPendientes.Visible = true;
                panelProductosEsperados.Location = new Point(3, 371);
                panelProductosEsperados.Height = 267;
            }
            else
            {
                panelProductosPendientes.Visible = false;
                panelProductosEsperados.Location = new Point(1, 63);
                panelProductosEsperados.Height = 569;
            }
        }

        private void ActualizarProductosPedido(long idPed)
        {
            List<object[]> productos = objCom.ObtenerProductosPedido(idPed);

            datGriVieProd.Rows.Clear();

            foreach (object[] producto in productos)
            {
                datGriVieProd.Rows.Add(new object[] { null, producto[0], producto[1], producto[6], producto[4], producto[11], producto[10], null, producto[13] });
                if ((producto[1] + "").Equals(""))
                {
                    datGriVieProd.Rows[datGriVieProd.Rows.Count - 1].Cells[0].Value = producto[0];
                    datGriVieProd.Rows[datGriVieProd.Rows.Count - 1].Cells[3].Value = producto[6];
                }
                else
                {
                    datGriVieProd.Rows[datGriVieProd.Rows.Count - 1].Cells[0].Value = producto[1];
                    datGriVieProd.Rows[datGriVieProd.Rows.Count - 1].Cells[3].Value = "Caja con " + producto[6];
                }
            }

            if(datGriVieProd.Rows.Count > 0)
                datGriVieProd.Rows[0].Selected = true;

            ActualizarFacturas(idPed);
        }

        private void ActualizarProveedoresPedidos()
        {
            habilitadoSelectionChanged = false;
            habilitadoSelectionIndex = false;

            List<object[]> proveedores = objCom.ObtenerProveedoresPedidos();

            datGriVieProv.Rows.Clear();
            tabConFac.TabPages.Clear();

            habilitadoSelectionIndex = true;

            foreach (object[] proveedor in proveedores)
                datGriVieProv.Rows.Add(proveedor);

            datGriVieProv.ClearSelection();

            habilitadoSelectionChanged = true;

            if (datGriVieProv.Rows.Count > 0)
            {
                //if (recPed)
                    datGriVieProv.Rows[0].Selected = true;
            }
            else
                if (recPed)
                    LimpiarVentana();
                //else
                //    AgregarFactura(new TabPage(), -1, -1, true, true, "-1", -1, 0);
            //datGriVieProv_SelectionChanged(this, new EventArgs());
        }

        private void LimpiarVentana()
        {
            subEsp = 0;
            impEsp = 0;
            totEsp = 0;

            labSubEsp.Text = string.Format("{0:c}", Convert.ToDecimal(subEsp));
            labImpEsp.Text = string.Format("{0:c}", Convert.ToDecimal(impEsp));
            labTotEsp.Text = string.Format("{0:c}", Convert.ToDecimal(totEsp));

            habilitadoSelectionIndex = false;

            datGriVieProd.Rows.Clear();
            tabConFac.TabPages.Clear();

            habilitadoSelectionIndex = true;

            ActualizarCantidades();
        }

        private void ActualizarFacturas(long idPed)
        {
            habilitadoSelectionIndex = false;
            byte indFac = (byte)tabConFac.SelectedIndex;
            tabConFac.TabPages.Clear();
            habilitadoSelectionIndex = true;
            //Checar si hay facturas pendientes y cargarlas, si no cargar una nueva
            List<string[]> facturas = objCom.ObtenerFacturasPendientes(idPed);
            if (facturas.Count > 0)
            {
                rec.Enabled = true;
                sbyte numFac = 0;
                foreach (string[] factura in facturas)
                {
                    TabPage tab = new TabPage();

                    //if (factura[3].Equals(""))
                    //    factura[3] = "True";
                    if (factura[3].Equals(""))
                        factura[3] = "0";

                    AgregarFactura(tab, idPed, long.Parse(factura[0]), bool.Parse(factura[2]), esPor.Checked, factura[1], decimal.Parse(factura[3]), numFac);

                    numFac++;
                }

                fol.Text = (tabConFac.SelectedTab.Tag as object[])[1].ToString();
                des.Text = (tabConFac.SelectedTab.Tag as object[])[4].ToString();
                eliFac.Enabled = true;
            }
            else
            {
                AgregarFactura(new TabPage(), idPed, -1, true, true, "", -1, 0);
                eliFac.Enabled = false;
                rec.Enabled = false;
            }

            dgvP = tabConFac.SelectedTab.Controls[0] as DataGridView;
            tabConFac.SelectedIndex = indFac;
            idFac = (long)(tabConFac.SelectedTab.Tag as object[])[0];
            ActualizarDatosPedido(idPed);
        }

        private void cambioFactura(object sender, EventArgs e)
        {
            if(habilitadoSelectionIndex)
            {
                habilitadoCheckedChanged = false;
                habilitadoValueChanged = false;
                dgvP = (DataGridView)tabConFac.SelectedTab.Controls[0];
                idFac = (long)(tabConFac.SelectedTab.Tag as object[])[0];
                fol.Text = (tabConFac.SelectedTab.Tag as object[])[1].ToString();
                esFac.Checked = (bool)(tabConFac.SelectedTab.Tag as object[])[2];
                if ((tabConFac.SelectedTab.Tag as object[])[4].ToString().Equals("-1"))
                    des.Text = "";
                else
                    des.Text = (tabConFac.SelectedTab.Tag as object[])[4].ToString();
                esPor.Checked = (bool)(tabConFac.SelectedTab.Tag as object[])[3];
                
                habilitadoCheckedChanged = true;
                habilitadoValueChanged = true;

                ActualizarCantidades();

                tbCodBar.Focus();
            }
        }

        private void ActualizarCantidades()
        {
            decimal can, cos, impo;
            byte indFac = 0;
            string lisImpCan = "";
            long idFac;

            subGlo = 0;
            impGlo = 0;
            totGlo = 0;

            canDesGenGlo = creFav;
            canDesPorRenGlo = 0;
            canDesExtGlo = 0;
            canDevGlo = 0;

            totAPagGlo = 0;
            datFac = new object[tabConFac.TabPages.Count, 17];
            foreach (TabPage factura in tabConFac.TabPages)
            {
                subFac = 0;
                impFac = 0;
                totFac = 0;
                canDesGenFac = 0;
                canDesExtFac = 0;
                canDesPorRenFac = 0;
                canDevFac = 0;
                totAPagFac = 0;

                idFac = (long)(factura.Tag as object[])[0];

                canDesExtFac = objCom.ObtenerTotalDescuentosExtra(idFac);
                canDesExtGlo += canDesExtFac;
                foreach (DataGridViewRow prod in (factura.Controls[0] as DataGridView).Rows)
                    //Si el producto tiene cantidad y costo recibidos, lo toma en cuenta para el calculo
                    if (prod.Cells[indCanRec].Value != null && prod.Cells[indCosRec].Value != null)
                    {
                        if((prod.Cells[indImpo].Value + "").Equals(""))
                        {
                            can = decimal.Parse(prod.Cells[indCanRec].Value.ToString());
                            cos = (decimal)prod.Cells[indCosRec].Tag;
                            impo = can * cos;
                        }
                        else
                        {
                            can = decimal.Parse(prod.Cells[indCanRec].Value + "");
                            impo = decimal.Parse(prod.Cells[indImpo].Tag + "");
                            if (can == 0)
                                can = 1;
                            cos = impo / can;
                        }
                        
                        if (recPed)
                        {
                            //Si el producto tiene una cantidad devuelta
                            if (!(prod.Cells[indCanDev].Tag + "").Equals(""))
                            {
                                canDevFac += (decimal)prod.Cells[indCanDev].Tag * cos;
                                (factura.Controls[0] as DataGridView).Columns[indCanDev].Visible = true;
                                (factura.Controls[0] as DataGridView).Columns[indMotDev].Visible = true;

                                //Si el producto tiene impuestos
                                if(!(prod.Cells[indLisImp].Value + "").Equals(""))
                                {
                                    can -= (decimal)prod.Cells[indCanDev].Tag;
                                    //prod.Cells[indCanImp].Tag = (can * cos) - (can * RestarImpuestosCosto(cos, prod.Cells[indLisImp].Value.ToString()));
                                    impFac += (can * cos) - (can * RestarImpuestosCosto(cos, prod.Cells[indLisImp].Value.ToString()));
                                }
                            }
                            else
                            {
                                //Si el producto tiene impuestos
                                if (!(prod.Cells[indLisImp].Value + "").Equals(""))
                                {
                                    //prod.Cells[indCanImp].Tag = (can * cos) - (can * RestarImpuestosCosto(cos, prod.Cells[indLisImp].Value.ToString()));
                                    impFac += (can * cos) - (can * RestarImpuestosCosto(cos, prod.Cells[indLisImp].Value.ToString()));
                                }
                            }

                            //Si el producto tiene un descuento por renglon
                            if (!(prod.Cells[indDescuPorRen].Tag + "").Equals("-1") && !(prod.Cells[indDescuPorRen].Tag + "").Equals(""))
                                if (esPor.Checked)
                                    if ((prod.Cells[indCanDev].Tag + "").Equals("-1") || (prod.Cells[indCanDev].Tag + "").Equals(""))
                                    {
                                        canDesPorRenFac += ((decimal)prod.Cells[indDescuPorRen].Tag / 100) * impo;
                                    }
                                    else
                                    {
                                        canDesPorRenFac += ((decimal)prod.Cells[indDescuPorRen].Tag / 100) * ((can - (decimal)prod.Cells[indCanDev].Tag) * cos);
                                    }
                                else
                                {
                                    canDesPorRenFac += (decimal)prod.Cells[indDescuPorRen].Tag;
                                }
                        }
                        else
                        {
                            // Si el producto tiene descuento por renglon
                            if (!(prod.Cells[indDescuPorRen].Tag + "").Equals("-1") && !(prod.Cells[indDescuPorRen].Tag + "").Equals(""))
                                if (esPor.Checked)
                                {
                                    canDesPorRenFac += ((decimal)prod.Cells[indDescuPorRen].Tag / 100) * impo;
                                }
                                else
                                {
                                    canDesPorRenFac += (decimal)prod.Cells[indDescuPorRen].Tag;
                                }
                            
                            //Si el producto tiene impuestos
                            if (!(prod.Cells[indLisImp].Value + "").Equals(""))
                            {
                                //prod.Cells[indCanImp].Tag = (can * cos) - (can * RestarImpuestosCosto(cos, prod.Cells[indLisImp].Value.ToString()));
                                impFac += (can * cos) - (can * RestarImpuestosCosto(cos, prod.Cells[indLisImp].Value.ToString()));
                            }
                        }

                        //prod.Cells[indImpo].Tag = impo;
                        //prod.Cells[indImpo].Value = string.Format("{0:c}", impo);
                        totFac += impo;
                    }

                canDevGlo += canDevFac;
                canDesPorRenGlo += canDesPorRenFac;

                if (porDesGen > 0)
                {
                    canDesGenFac = (totFac / 100) * porDesGen;
                    canDesGenGlo += canDesGenFac;
                }
                subFac = totFac - impFac;

                subGlo += subFac;
                impGlo += impFac;
                totGlo += totFac;

                //Calcula cantidades de la factura actual
                totAPagFac = totFac - canDesGenFac - canDesExtFac - canDesPorRenFac - canDevFac;

                objCom.ActualizarTotalesFactura(idFac, subFac, impFac, totFac, canDesGenFac + canDesExtFac + canDesPorRenFac, canDevFac, totAPagFac);

                (factura.Tag as object[])[5] = new object[] { subFac, impFac, totFac, canDesGenFac + canDesPorRenFac + canDesExtFac, canDevFac, totAPagFac };

                if (indFac == tabConFac.SelectedIndex)
                {
                    lSubFac.Text = string.Format("{0:c}", subFac);
                    lImpFac.Text = string.Format("{0:c}", impFac);
                    lTotFac.Text = string.Format("{0:c}", totFac);
                    lDesFac.Text = string.Format("{0:c}", canDesGenFac + canDesExtFac + canDesPorRenFac);
                    lDevFac.Text = string.Format("{0:c}", canDevFac);
                    lTotAPagFac.Text = string.Format("{0:c}", totAPagFac);
                }

                datFac[indFac, 0] = idFac;
                datFac[indFac, 1] = (factura.Tag as object[])[1];
                datFac[indFac, 5] = subFac;
                datFac[indFac, 6] = impFac;
                datFac[indFac, 7] = totFac;
                datFac[indFac, 8] = canDesGenFac + canDesExtFac + canDesPorRenFac;
                datFac[indFac, 9] = canDevFac;
                datFac[indFac, 10] = totAPagFac;

                indFac++;
            }


            //Aplicamos descuento general, si aplica
            //if (des.Text.Equals(""))
            //{
            //    totConDes1.Visible = false;
            //    labTotAPag.Visible = false;
            //}
            //else
            //{
            //    totConDes1.Visible = true;
            //    labTotAPag.Visible = true;
            
            //}

            //Calcula cantidades globales
            totAPagGlo = totGlo - canDesGenGlo - canDesExtGlo - canDesPorRenGlo - canDevGlo;
            labSubGlo.Text = string.Format("{0:c}", subGlo);
            labImpGlo.Text = string.Format("{0:c}", impGlo);
            labTotGlo.Text = string.Format("{0:c}", totGlo);
            labDesGlo.Text = string.Format("{0:c}", canDesGenGlo + canDesExtGlo + canDesPorRenGlo);
            labDevGlo.Text = string.Format("{0:c}", canDevGlo);
            labTotAPag.Text = string.Format("{0:c}", totAPagGlo);

            //Actualizamos las cantidades del pedido si tenemos alguno seleccionado
            if (tabConFac.TabPages.Count > 0)
                objCom.ActualizarTotalesPedido(idPed, subGlo, impGlo, totGlo, canDesGenGlo + canDesExtGlo + canDesPorRenGlo, canDevGlo, totAPagGlo);

            if (labTotEsp.Text.Equals(labTotGlo.Text))
            {
                labSubGlo.ForeColor = Color.Green;
                labImpGlo.ForeColor = Color.Green;
                labTotGlo.ForeColor = Color.Green;
                labDesGlo.ForeColor = Color.Green;
                labDevGlo.ForeColor = Color.Green;
                labTotAPag.ForeColor = Color.Green;
            }
            else
            {
                labSubGlo.ForeColor = Color.DarkRed;
                labImpGlo.ForeColor = Color.DarkRed;
                labTotGlo.ForeColor = Color.DarkRed;
                labDesGlo.ForeColor = Color.DarkRed;
                labDevGlo.ForeColor = Color.DarkRed;
                labTotAPag.ForeColor = Color.DarkRed;
            }
            //if(totEsp > totRea)
            //{
            //    labSubRea.ForeColor = Color.Blue;
            //    labImpRea.ForeColor = Color.Blue;
            //    labTotRea.ForeColor = Color.Blue;
            //    labTotAPag.ForeColor = Color.Blue;
            //}
            //else
            //{
            //    labSubRea.ForeColor = Color.FromName("DarkGoldenrod");
            //    labImpRea.ForeColor = Color.FromName("DarkGoldenrod");
            //    labTotRea.ForeColor = Color.FromName("DarkGoldenrod");
            //    labTotAPag.ForeColor = Color.FromName("DarkGoldenrod");
            //}
        }
    }
    //public class ComboBoxItem
    //{
    //    public string Text { get; set; }
    //    public object Value { get; set; }

    //    public override string ToString()
    //    {
    //        return Text;
    //    }
    //}
}
