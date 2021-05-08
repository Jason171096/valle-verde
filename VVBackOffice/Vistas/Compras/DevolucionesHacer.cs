using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ValleVerdeComun;

namespace ValleVerde.Vistas.Compras
{
    public partial class DevolucionesHacer : Form
    {
        Programacion.Compra.Compras objCom = new Programacion.Compra.Compras();
        private byte indIdDevComSal, indCodBar, indCan, indDescrProd, indCos, indSeCamPor, indMot, indImpo, indNumReg, indYaTieCom; //indices de la tabla de proveedores
        private bool habilitadoSelectionChanged = true, todProdTieCompe;
        private decimal impSal = 0, impEnt = 0, impDif = 0;
        private long idCom, idPed, idProv; //{ get; set; }
        private short ren, posDiv = 0;

        public DevolucionesHacer(long idCom, long idPed, long idProv)
        {
            InitializeComponent();
            this.idCom = idCom;
            this.idPed = idPed;
            this.idProv = idProv;

            indIdDevComSal = 0;
            indCodBar = 1;
            indCan = 2;
            indDescrProd = 3;
            indCos = 4;
            indSeCamPor = 5;
            indMot = 6;
            indImpo = 7;
        }

        private void DevolucionesHacer_Load(object sender, EventArgs e)
        {
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(prod, false, false, 12, 12);
            prod.ReadOnly = false;
            
            if (idPed == -1)
            {
                CargarProveedoresComboBox();
                ActualizarProveedores();
                prov.ClearSelection();
                cbProv.SelectedIndexChanged += new EventHandler(cbProv_SelectedIndexChanged);
                prov.SelectionChanged += new EventHandler(prov_SelectionChanged);
                prov.KeyDown += new KeyEventHandler(prov_KeyDown);
                new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(prov, false, false, 12, 12);
                if (prov.Rows.Count > 0)
                    prov.Rows[0].Selected = true;
                prod.Columns[indCan].ReadOnly = false;
                prod.Columns[indMot].ReadOnly = false;
            }
            else
            {
                cbProv.Visible = false;
                agrProv.Visible = false;
                prov.Visible = false;
                prov.Location = new Point(11, 11);
                //prov.Size = new Size(1328, 645);
                bCon.Visible = true;
                bCon.Location = new Point(1202, 671);
                prod.Width += prov.Width;
                prod.Left = prov.Left;
                bFin.Visible = false;

                tbCodBar.Enabled = true;
                butSelProd.Enabled = true;
                butAgrPro.Enabled = true;
                ActualizarProductos();
            }
           
            tbCodBar.KeyDown += new KeyEventHandler(tbCodBar_KeyDown);
            prod.SelectionChanged += new EventHandler(prod_SelectionChanged);
            prod.KeyDown += new KeyEventHandler(prod_KeyDown);
            prod.CellValueChanged += new DataGridViewCellEventHandler(prod_CellValueChanged);

        }

        private void prod_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == indCan || e.ColumnIndex == indMot)
            {
                objCom.ActualizarProductoDevolucionSalida((long)prod.Rows[e.RowIndex].Cells[0].Value, decimal.Parse(prod.Rows[e.RowIndex].Cells[indCan].Value + ""), prod.Rows[e.RowIndex].Cells[indMot].Value + "");
            }
        }

        private void prov_KeyDown(object sender, KeyEventArgs e)
        {
            if (prov.SelectedRows.Count > 0)
            {
                can.PerformClick();
            }
        }

        private void bCon_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void prod_KeyDown(object sender, KeyEventArgs e)
        {
            if(prod.SelectedRows.Count > 0)
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                {
                    PreguntaProductoDevolucion ppd = new PreguntaProductoDevolucion(false, (long)prod.SelectedRows[0].Cells[indIdDevComSal].Value, idPed, idProv, prod.SelectedRows[0].Cells[indCodBar].Value + "", decimal.Parse(prod.SelectedRows[0].Cells[indCan].Value + ""), prod.SelectedRows[0].Cells[indDescrProd].Value + "", "Unidad", decimal.Parse(prod.SelectedRows[0].Cells[indImpo].Tag + ""));
                    if (ppd.ShowDialog() == DialogResult.OK)
                    {
                        //Insertamos el producto de entrada
                        //long numReg = long.Parse(objCom.AgregarProductoDevolucionCompra((long)prov.SelectedRows[0].Cells[indIdProdDevCom].Value, byte.Parse((ppd.cb.SelectedItem as ComboBoxItem).Value + ""), "", "", -1, "", -1, true, -1)[1] + "");
                        //Insertamos el producto de entrada
                        //objCom.AgregarProductoDevolucionCompra(idCom, long.Parse(prov.SelectedRows[0].Cells[0].Value + ""), idProd, idClaAdi, decimal.Parse(ppd.tbCan.Text), long.Parse((ppd.cb.SelectedItem as ComboBoxItem).Value + ""), "", decimal.Parse(ppd.tbCos.Text), true, numReg);
                        ActualizarProveedores();
                        ActualizarProductos();
                    }
                    ppd.Dispose();
                }
                else
                    if(e.KeyCode == Keys.Delete)
                    {
                        objCom.EliminarProductoDevolucionCompra((long)prod.SelectedRows[0].Cells[indIdDevComSal].Value);
                        ActualizarProductos();
                    }
        }

        private void can_Click(object sender, EventArgs e)
        {
            if(prov.SelectedRows.Count > 0)
            {
                objCom.EliminarDevolucionCompra((long)prov.SelectedRows[0].Cells[0].Value);
                ActualizarProveedores();
                ActualizarProductos();
            }
        }

        private void bFin_Click(object sender, EventArgs e)
        {
            if (todProdTieCompe)
            {
                objCom.ConfirmarDevolucionCompra((long)prov.SelectedRows[0].Cells[0].Value);
                ActualizarProveedores();
                ActualizarProductos();
            }
            else
                MessageBox.Show("Aún hay productos que no se ha indicado como se compensarán.");
        }

        private void prod_SelectionChanged(object sender, EventArgs e)
        {
            if (habilitadoSelectionChanged)
            {
                if (prod.Rows.Count > 0)
                {
                    
                }
            }
        }

        private void tbCodBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                butAgrPro.PerformClick();
        }

        private void butAgrPro_Click(object sender, EventArgs e)
        {
            if (!tbCodBar.Text.Trim().Equals(""))
            {
                sbyte res = 0;
                string codBar = tbCodBar.Text.Trim(),
                    idProd;
                //objCom.AgregarProductoDevolucionCompraPendiente(long.Parse(prov.SelectedRows[0].Cells[0].Value + ""), "", "", true, short.Parse(sal.SelectedRows[0].Cells[indNumReg].Value + ""), can);
                
                bool prodRep = false;
                string[] codBarEsCaj = objCom.ExisteProductoConClaveAdicional(codBar);

                if (codBarEsCaj[0].Equals("-1"))
                    //El código de barras no existe
                    res = -1;
                else
                {
                    if (codBarEsCaj[1].Equals(codBar))
                    {
                        idProd = codBar;
                    }
                    else
                    {
                        idProd = codBarEsCaj[1];
                    }
                    //Revisamos que no se encuentre ya en la tabla, la caja o el producto con tal código de barras
                    for (int i = 0; i < prod.Rows.Count; i++)
                    {
                        if ((prod.Rows[i].Cells[indCodBar].Value + "").Equals(codBar) && i > posDiv)
                        {
                            prod.Rows[i].Selected = true;
                            prodRep = true;
                            break;
                        }
                    }

                    if (!prodRep)
                    {
                        if (objCom.ProveedorVendeProductoOCaja(idProv, codBar))
                        {
                            objCom.AgregarSalidaDevolucionCompra(idProv, idProd, idPed);
                            ActualizarProductos();
                        }
                        else
                        {
                            MessageBox.Show("No se puede devolver este artículo porque el proveedor no lo vende.");
                            tbCodBar.Text = "";
                        }
                    }
                }
                tbCodBar.Text = "";
                if (res == -1)
                    MessageBox.Show("No existe producto con código de barras: " + codBar);
                else
                    if (res == -2)
                    MessageBox.Show("El proveedor " + prov.SelectedRows[0].Cells[2].Value + " no vende ningún producto con código de barras: " + codBar);
            }
        }

        private void butSelProd_Click(object sender, EventArgs e)
        {
            new BuscarProducto(tbCodBar, butAgrPro, false).Show();
        }

        private void agrProv_Click(object sender, EventArgs e)
        {
            ActualizarProveedores();

            habilitadoSelectionChanged = false;
            prov.Rows.Add(new object[] { (cbProv.SelectedItem as ComboBoxItem).Value, (cbProv.SelectedItem as ComboBoxItem).Text });
            habilitadoSelectionChanged = true;

            tbCodBar.Enabled = true;
            butSelProd.Enabled = true;
            butAgrPro.Enabled = true;
        }

        private void cbProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            agrProv.Enabled = true;
            //Falta borrar el evento
        }

        private void CargarProveedoresComboBox()
        {
            List<object[]> proveedores = objCom.ObtenerProveedores();

            foreach(object[] proveedor in proveedores)
            {
                ComboBoxItem cbIte = new ComboBoxItem();
                cbIte.Value = proveedor[0];
                cbIte.Text = proveedor[1] + "";
                cbProv.Items.Add(cbIte);
            }
        }

        private void ActualizarProveedores()
        {
            habilitadoSelectionChanged = false;

            prov.Rows.Clear();
            
            List<object[]> proveedores = objCom.ObtenerProveedoresDevolucion();

            foreach (object[] proveedor in proveedores)
            {
                prov.Rows.Add(proveedor);
            }

            habilitadoSelectionChanged = true;
        }

        private void prov_SelectionChanged(object sender, EventArgs e)
        {
            if(habilitadoSelectionChanged)
            {
                if (prov.SelectedRows.Count > 0)
                {
                    ActualizarProductos();
                    can.Enabled = true;

                    //gbAgrA.Enabled = true;
                    tbCodBar.Enabled = true;
                    butSelProd.Enabled = true;
                    butAgrPro.Enabled = true;

                    idProv = (long)prov.SelectedRows[0].Cells[3].Value;
                }
                else
                {
                    can.Enabled = false;

                    //gbAgrA.Enabled = false;
                    tbCodBar.Enabled = false;
                    butSelProd.Enabled = false;
                    butAgrPro.Enabled = false;
                }
            }
        }

        private void ActualizarProductos()
        {
            habilitadoSelectionChanged = false;
            prod.Rows.Clear();
            bool sePuedeDividirRenglones = true;
            if(prov.SelectedRows.Count > 0 || idPed != -1)
            {
                List<object[]> productos;
                if (idPed == -1)
                    productos = objCom.ObtenerDevolucionCompraSalientes((long)prov.SelectedRows[0].Cells[0].Value, -1, -1, false, false);
                else
                    productos = objCom.ObtenerDevolucionCompraSalientes(idProv, -1, idPed, true, true);
                //productos = objCom.ObtenerProductosDevolucionPedido(idPed);

                todProdTieCompe = true;
                foreach (object[] producto in productos)
                {
                    prod.Rows.Add(new object[] { producto[0], producto[2], producto[6], producto[3], producto[7], null, producto[8] });
                    ren = (short)(prod.Rows.Count - 1);

                    if (idPed != -1 && (bool)producto[12])
                    {
                        if (sePuedeDividirRenglones)
                        {
                            if(ren > 0)
                            {
                                prod.Rows[ren - 1].DividerHeight = 10;
                                sePuedeDividirRenglones = false;
                                posDiv = (short)(ren - 1);
                            }
                        }

                        prod.Rows[ren].Cells[indCan].ReadOnly = false;
                        prod.Rows[ren].Cells[indMot].ReadOnly = false;
                    }
                    else
                    {
                        //if(idPed == -1 && )
                        prod.Rows[ren].Cells[indCan].ReadOnly = true;
                        prod.Rows[ren].Cells[indMot].ReadOnly = true;
                    }

                    prod.Rows[ren].Cells[indSeCamPor].Tag = producto[4];
                    prod.Rows[ren].Cells[indSeCamPor].Value = producto[5];

                    prod.Rows[ren].Cells[indImpo].Tag = decimal.Parse(producto[6] + "") * decimal.Parse(producto[7] + "");
                    prod.Rows[ren].Cells[indImpo].Value = string.Format("{0:c}", prod.Rows[ren].Cells[indImpo].Tag);
                    
                    RevisarProducto(ren);
                }
                // Todos los derechos reservados. No se otorga permiso para usar, copiar, modificar o distribuir este software con fines educativos, de investigación, con o sin lucro, sin un permiso escrito y firmado por Daniel Alejandro Gutiérrez Ruiz y Jorge Gabriel Gutiérrez Ruiz, estudiantes de Ingeniería en Sistemas Computacionales en el Instituto Tecnológico de Jiquilpan, con número de control 15420492 y 15420493, respectivamente, pertenecientes a la ciudad de Cotija de la Paz, Michoacán, México. Para solicitar permiso, comuníquese con Daniel Alejandro Gutiérrez Ruiz al correo electrónico: daniel_alejandro.12@icloud.com, o con Jorge Gabriel Gutiérrez Ruiz al correo electrónico: jorgea380@icloud.com.
            }
            habilitadoSelectionChanged = true;
        }

        private void RevisarProducto(short ren)
        {
            if((prod.Rows[ren].Cells[indSeCamPor].Value + "").Equals(""))
            {
                prod.Rows[ren].DefaultCellStyle.BackColor = Color.LightGray;
            }
            else
            {
                prod.Rows[ren].DefaultCellStyle.BackColor = Color.White;
            }
        }
    }
}
