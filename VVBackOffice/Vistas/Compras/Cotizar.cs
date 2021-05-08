using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using ValleVerdeComun;
using System.IO;
using System.Linq;
using System.Drawing;

namespace ValleVerde.Vistas.Compras
{
    public partial class Cotizar : Form
    {
        ValleVerdeComun.Programacion.Producto objPro = new ValleVerdeComun.Programacion.Producto();
        Programacion.Compra.Compras objCom = new Programacion.Compra.Compras();
        DataGridView datGriVie = new DataGridView();
        List<string[]> prod = new List<string[]>();
        List<string[]> provProd = new List<string[]>();
        bool limPesSol = false, usaLisExc = false, carPriLisProvSol = true, habilitadoCellValueChanged = true, sepPorProv = false, habilitadoSelectionChanged = true, habilitadaDescripcionProducto = true;
        byte indCanCaj = 3, indUniPorCaj = 4, indCanUni = 5, indCotPor = 6, indDescrUni = 7, indDiaCub = 8, indEnBasA = 9, tipCot = 0;
        decimal valAnt;
        private long idUsu = 1;

        public Cotizar()
        {
            InitializeComponent();
        }

        private void Cotizar_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(Cotizar_FormClosing);

            //new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(datGriVieAgrProPro,true,false);
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(agrProd,true,false);
            agrProd.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            
            


            sug.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            ultDosMes.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            minInv.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            
            datGriVie = mar;

            tabCon.SelectedIndexChanged += new EventHandler(tabCon_SelectedIndexChanged);

            //Cargar pestaña 'Agregar productos'
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(mar, false, true, 15, 15);
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(lin, false, true, 15, 15);
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(fab, false, true, 15, 15);
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(prov, false, true, 15, 15);

            CargarMarcas();
            CargarLineas();
            CargarFabricantes();
            CargarProveedores();
            mar.SelectionChanged += new EventHandler(datGriVie_SelectionChanged);
            lin.SelectionChanged += new EventHandler(datGriVie_SelectionChanged);
            fab.SelectionChanged += new EventHandler(datGriVie_SelectionChanged);
            prov.SelectionChanged += new EventHandler(datGriVie_SelectionChanged);
            datGriVie.SelectionChanged += new EventHandler(datGriVie_SelectionChanged);
            agrProd.SelectionChanged += new EventHandler(datGriVieAgrProPro_SelectionChanged);
            ActualizarProductosEnEsperaCotizacion();
            agrProd.CellBeginEdit += new DataGridViewCellCancelEventHandler(datGriVieAgrProPro_CellBeginEdit);
            agrProd.CellValueChanged += new DataGridViewCellEventHandler(datGriVieAgrProPro_CellValueChanged);
            agrProd.CurrentCellDirtyStateChanged += new EventHandler(datGriVieAgrProPro_CurrentCellDirtyStateChanged);
            tbDiaCub.KeyUp += new KeyEventHandler(tbDiaCub_KeyUp);
            
            texBoxIdPro.KeyDown += new KeyEventHandler(tb_KeyDown);
            texBoxSolIdProd.KeyDown += new KeyEventHandler(tb_KeyDown);
            agrProd.KeyDown += new KeyEventHandler(tb_KeyDown);

            //Cargar pestaña 'GenerarCotizaciones'
            datGriVieGenCotProv.SelectionChanged += new EventHandler(datGriVieGenCotProv_SelectionChanged);
            genCot.CellValueChanged += new DataGridViewCellEventHandler(datGriVieGenCotProd_CellValueChanged);
            ActualizarProveedoresCotizaciones();

            //Cargar pestaña 'Recibir'
            //datGriVieRecProv.SelectionChanged += new EventHandler(datGriVieRecProv_SelectionChanged);
        }

        private void tbDiaCub_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                butAgr.Focus();
            else
            {
                if (tbDiaCub.Text.Trim().Equals(""))
                    butAgr.Enabled = false;
                else
                    try
                    {
                        butAgr.Enabled = true;
                        short.Parse(tbDiaCub.Text.Trim());
                    }
                    catch (Exception ex)
                    {
                        if (ex is FormatException || ex is OverflowException)
                        {
                            tbDiaCub.Text = tbDiaCub.Text.Substring(0, tbDiaCub.Text.Length - 1).Trim();
                            tbDiaCub.SelectionStart = tbDiaCub.Text.Length;
                            tbDiaCub.SelectionLength = 0;
                        }
                    }
            }
        }

        private void prueba(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            MessageBox.Show("Escribiste una letra");
        }

        private void datGriVieAgrProPro_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex != 6)
                if (((sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "").Equals("-"))
                    valAnt = 0;
                else
                    valAnt = decimal.Parse((sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "");
            //MessageBox.Show("Valor anterior:" + valAnt);
        }

        private void datGriVieAgrProPro_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (agrProd.IsCurrentCellDirty && !agrProd.SelectedRows[0].Cells[3].IsInEditMode && !agrProd.SelectedRows[0].Cells[5].IsInEditMode && !agrProd.SelectedRows[0].Cells[8].IsInEditMode)
            {
                // This fires the cell value changed handler below
                agrProd.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void tabCon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabCon.SelectedTab == tabPagMar)
                datGriVie = mar;
            else
                if (tabCon.SelectedTab == tabPagLin)
                datGriVie = lin;
            else
                    if (tabCon.SelectedTab == tabPagFab)
                datGriVie = fab;
            else
                        if (tabCon.SelectedTab == tabPagPro)
                datGriVie = prov;
        }

        private void datGriVieAgrProPro_SelectionChanged(object sender, EventArgs e)
        {
            if (habilitadoSelectionChanged)
            {
                if (agrProd.Rows.Count == 0 || agrProd.SelectedRows.Count == 0)
                    butEli.Enabled = false;
                else
                {
                    butEli.Enabled = true;

                    if(!sepPorProv && habilitadaDescripcionProducto)
                        ActualizarDescripcionCantidad1();
                }
            }
        }

        private void datGriVie_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (sender as DataGridView);
            if (dgv.SelectedRows.Count > 0)
                if (dgv.SelectedRows[0].ReadOnly)
                    butAgr.Enabled = false;
                else
                    butAgr.Enabled = true;
            else
                butAgr.Enabled = false;
        }

        private void CargarMarcas()
        {
            List<object[]> marcas = new List<object[]>();

            marcas = objCom.ObtenerMarcas();

            foreach (object[] marca in marcas)
                mar.Rows.Add(marca);
        }

        private void CargarLineas()
        {
            List<object[]> lineas = new List<object[]>();

            lineas = objCom.ObtenerLineas();

            foreach (object[] linea in lineas)
                lin.Rows.Add(linea);
        }

        private void CargarFabricantes()
        {
            List<object[]> fabricantes = new List<object[]>();

            fabricantes = objCom.ObtenerFabricantes();

            foreach (object[] fabrica in fabricantes)
                fab.Rows.Add(fabrica);
        }

        private void CargarProveedores()
        {
            List<object[]> proveedores = new List<object[]>();

            proveedores = objCom.ObtenerProveedores();

            foreach (object[] proveedor in proveedores)
                prov.Rows.Add(proveedor);
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            if (sug.Checked)
            {
                lDiaCub.Visible = true;
                tbDiaCub.Visible = true;
                tipCot = 0;
            }
            else
                if (ultDosMes.Checked)
                {
                    lDiaCub.Visible = false;
                    tbDiaCub.Visible = false;
                    tipCot = 1;
                }
                else
                {
                    lDiaCub.Visible = false;
                    tbDiaCub.Visible = false;
                    tipCot = 2;
                }
        }

        private void CargarProductosSugeridos(long idCat, Int16 diaCub)
        {
            String cat = "";
            int numProIni;
            bool seOmiPro = false, vieCaj = true;

            List<String[]> productos = new List<String[]>();

            switch (tabCon.SelectedIndex)
            {
                case 0:
                    productos = objCom.ObtenerProductosSugeridos(0, idCat, diaCub);
                    cat = "esta marca";
                    break;
                case 1:
                    productos = objCom.ObtenerProductosSugeridos(1, idCat, diaCub);
                    cat = "esta línea";
                    break;
                case 2:
                    productos = objCom.ObtenerProductosSugeridos(2, idCat, diaCub);
                    cat = "este fabricante";
                    break;
                case 3:
                    productos = objCom.ObtenerProductosSugeridos(3, idCat, diaCub);
                    cat = "este proveedor";
                    break;
            }

            if (productos.Count == 0)
                if (diaCub == 1)
                    MessageBox.Show("Tienes suficiente inventario para cubrir el día de mañana.");
                else
                    MessageBox.Show("Tienes suficiente inventario para cubrir los próximos " + diaCub + " días.");
            else
            {
                numProIni = agrProd.Rows.Count;

                foreach (String[] producto in productos)
                {
                    if (!bool.Parse(ExisteProductoEnEsperaCotizacion(agrProd, producto[0])[0].ToString()))
                    {
                        vieCaj = ActualizarDescripcionCantidad1();

                        //objCom.AgregarProductoEsperaCotizacion(producto[0], producto[1], producto[3], decimal.Parse(producto[4]), bool.Parse(producto[5]), producto[7], producto[9], idUsu);

                    }
                    else
                        seOmiPro = true;
                }

                if (numProIni == agrProd.Rows.Count)
                    MessageBox.Show("Todos los productos a cubrir de " + cat + " ya estaban en la tabla. No se agregó ninguno.");
                else
                {
                    if(seOmiPro)
                        MessageBox.Show("Algunos productos no se agregaron porque ya estaban en la tabla.");
                    
                    datGriVie.SelectedRows[0].DefaultCellStyle.BackColor = Color.LightGray;

                    ActualizarProductosEnEsperaCotizacion();
                }
            }
        }

        private bool ActualizarDescripcionCantidad1()
        {
            if(agrProd.SelectedRows.Count > 0)
            {
                String canCaj = agrProd.SelectedRows[0].Cells[indCanCaj].Value.ToString();
                float uniPorCaj;
                float canPie = float.Parse(agrProd.SelectedRows[0].Cells[indCanUni].Value.ToString());
                String descrUni = agrProd.SelectedRows[0].Cells[indDescrUni].Value.ToString().ToLower();

                bool vieCaj = true;
                labCan.Text = "";

                if (canPie != 1)
                    descrUni += "s";

                if (!(agrProd.SelectedRows[0].Cells[1].Value + "").Equals(""))
                {
                    uniPorCaj = float.Parse(agrProd.SelectedRows[0].Cells[indUniPorCaj].Value.ToString());
                    if (float.Parse(canCaj) == 1)
                        labCan.Text = float.Parse(canCaj) + " caja con " + uniPorCaj + " " + descrUni;
                    else
                        labCan.Text = float.Parse(canCaj) + " cajas con " + uniPorCaj + " " + descrUni;
                }  
                else
                    vieCaj = false;

                if (!labCan.Text.Equals(""))
                    labCan.Text += " o ";
                //if (!piePorCaj.Equals(""))
                labCan.Text += canPie + " " + descrUni;

                return vieCaj;
            }
            

            return false;
        }

        private void ActualizarDescripcionCantidad2()
        {
            if(genCot.RowCount > 0)
            {
                String canCaj = genCot.SelectedRows[0].Cells[3].Value.ToString();
                String piePorCaj = genCot.SelectedRows[0].Cells[4].Value.ToString();
                float canPie = float.Parse(genCot.SelectedRows[0].Cells[5].Value.ToString());
                String uni = genCot.SelectedRows[0].Cells[7].Value.ToString().ToLower();

                bool vieCaj = true;
                labCan.Text = "";

                if (canPie != 1)
                    uni += "s";

                if (!canCaj.Equals(""))
                    if (float.Parse(canCaj) == 1)
                        labCan.Text = float.Parse(canCaj) + " caja con " + piePorCaj + " " + uni;
                    else
                        labCan.Text = float.Parse(canCaj) + " cajas con " + piePorCaj + " " + uni;
                else
                    vieCaj = false;

                if (!labCan.Text.Equals(""))
                    labCan.Text += " o ";

                labCan.Text += canPie + " " + uni;

                //return vieCaj;
            }
        }

        private string CantidadDescrita(String[] datos, bool soloCajas)
        {
            String canDes = "";
            String canCaj = datos[0];
            String piePorCaj = datos[1];
            float canPie = float.Parse(datos[2]);
            String uni = datos[3].ToLower();

            if (canPie != 1)
                uni += "s";

            if(soloCajas)
            {
                if (!canCaj.Equals(""))
                    if (float.Parse(canCaj) == 1)
                        canDes = float.Parse(canCaj) + " caja con " + piePorCaj + " " + uni;
                    else
                        canDes = float.Parse(canCaj) + " cajas con " + piePorCaj + " " + uni;
            }
            else
            {
                canDes = canPie + " " + uni;
            }

            return canDes;
        }

        private void Cotizar_FormClosing(Object sender, FormClosingEventArgs e)
        {
            //objCom.ProductosEliminarSinEspera();
        }

        //
        //Código de pestana 'Agregar productos'
        //

        private void datGriVieAgrProPro_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (habilitadoCellValueChanged && (e.ColumnIndex == indCanCaj || e.ColumnIndex == indCanUni || e.ColumnIndex == indCotPor || e.ColumnIndex == indDiaCub))
            {
                bool vieCaj = true;
                sbyte res = 0;
                String idProd = agrProd.Rows[e.RowIndex].Cells[0].Value.ToString(),
                    idClaAdi = "";
                short diaCub = 0;
                //decimal canUni = 0;
                //try { canUni = decimal.Parse(agrProd.Rows[e.RowIndex].Cells[indCanUni].Value.ToString()); } catch (FormatException ex) { canUni = 0; }
                //string cotPorStr = (agrProd.Rows[e.RowIndex].Cells[indCotPor] as DataGridViewComboBoxCell).Value.ToString();
                //bool cotPor = false;
                //if (cotPorStr.Contains("Caja"))
                //    cotPor = true;
                //short diaCub = 0;
                //if (!agrProd.Rows[e.RowIndex].Cells[indDiaCub].Value.ToString().Equals("-"))
                //    diaCub = short.Parse(agrProd.Rows[e.RowIndex].Cells[indDiaCub].Value.ToString());

                byte valCam = 0;
                if (e.ColumnIndex == indCanCaj)
                {//Esta modificando la cantidad de cajas
                    if (agrProd.Rows[e.RowIndex].Cells[4].Value.ToString().Equals(""))
                    {
                        agrProd.Rows[e.RowIndex].Cells[indCanCaj].Value = "";
                        res = 1;
                    }
                    else
                    {
                        valCam = 0;
                        short canCaj = 0;
                        try 
                        { 
                            canCaj = short.Parse(agrProd.Rows[e.RowIndex].Cells[indCanCaj].Value.ToString());
                            if (canCaj < 0)
                                canCaj = (short)valAnt;
                        } 
                        catch (Exception ex) 
                        {
                            if (ex is FormatException)
                                canCaj = (short)valAnt;
                            else
                                if (ex is OverflowException)
                                    if ((agrProd.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "").Contains("-"))
                                        canCaj = (short)valAnt;
                                    else
                                        canCaj = (short.MaxValue);
                        }
                        res = objCom.ModificarProductoEnEsperaCotizacion(idProd, idClaAdi, 255, valCam, canCaj, 0, false, 0, idUsu);
                    }
                }
                else
                    if (e.ColumnIndex == indCanUni)
                    {//Esta modificando la cantidad de unidades
                        decimal canUni = new decimal(0, 0, 0, false, 3);
                        try 
                        { 
                            canUni = decimal.Parse(agrProd.Rows[e.RowIndex].Cells[indCanUni].Value.ToString());
                            if (canUni < 0)
                                canUni = valAnt;
                            else
                                if (canUni >= 100000)
                                    canUni = (decimal)99999.999;
                        } 
                        catch (Exception ex) 
                        {
                            if (ex is FormatException)
                                canUni = valAnt;
                            else
                                if (ex is OverflowException)
                                    if ((agrProd.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "").Contains("-"))
                                        canUni = (short)valAnt;
                                    else
                                        canUni = (decimal)99999.999;
                        }
                        valCam = 1;
                        res = objCom.ModificarProductoEnEsperaCotizacion(idProd, idClaAdi, 255, valCam, 0, canUni, false, 0, idUsu);
                    }
                    else
                        if (e.ColumnIndex == indCotPor)
                        {//Esta modificando la forma de cotizar, ya sea por caja o por unidad
                            valCam = 2;
                            string cotPorStr = (agrProd.Rows[e.RowIndex].Cells[indCotPor] as DataGridViewComboBoxCell).Value.ToString();
                            bool cotPor = false;
                            if (cotPorStr.Contains("Caja"))
                                cotPor = true;
                    
                            res = objCom.ModificarProductoEnEsperaCotizacion(idProd, idClaAdi, 255, valCam, 0, 0, cotPor, 0, idUsu);
                        }
                        else
                            if (e.ColumnIndex == indDiaCub)
                            {//Esta modificando los dias a cubrir
                                valCam = 3;
                                try
                                {
                                    if (!agrProd.Rows[e.RowIndex].Cells[indDiaCub].Value.ToString().Equals("-"))
                                        diaCub = short.Parse(agrProd.Rows[e.RowIndex].Cells[indDiaCub].Value.ToString());
                                    if (diaCub < 0)
                                        diaCub = 0;
                                }
                                catch(Exception ex)
                                {
                                    if (ex is FormatException)
                                        diaCub = (short)valAnt;
                                    else
                                        if (ex is OverflowException)
                                            if ((agrProd.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "").Contains("-"))
                                                diaCub = (short)valAnt;
                                            else
                                                diaCub = (short.MaxValue);
                                }
                                
                                //List<string[]> producto = objCom.ObtenerProductosACotizar();
                                //idClaAdi = producto[0][1];
                                //if(!producto[0][3].Equals(""))
                                //    canCaj = short.Parse(producto[0][3].ToString());
                                //canUni = decimal.Parse(producto[0][5].ToString());
                                res = objCom.ModificarProductoEnEsperaCotizacion(idProd, idClaAdi, tipCot, valCam, short.Parse(agrProd.Rows[e.RowIndex].Cells[indCanCaj].Value + ""), decimal.Parse(agrProd.Rows[e.RowIndex].Cells[indCanUni].Value + ""), false, diaCub, idUsu);
                            }
                
                if (res != 1)
                {
                    if (diaCub == 1)
                        MessageBox.Show("Tienes suficiente inventario para cubrir el día de mañana.");
                    else
                        MessageBox.Show("Tienes suficiente inventario para cubrir los próximos " + diaCub + " días.");
                    //inhabilitarCellValueChanged = true;
                    //datGriVieAgrProPro.Rows[e.RowIndex].Cells[1].Value = "";
                    //datGriVieAgrProPro.Rows[e.RowIndex].Cells[3].Value = "";
                    //datGriVieAgrProPro.Rows[e.RowIndex].Cells[4].Value = "";
                    //datGriVieAgrProPro.Rows[e.RowIndex].Cells[5].Value = "0";
                    //datGriVieAgrProPro.Rows[e.RowIndex].Cells[8].Value = "";
                    //inhabilitarCellValueChanged = false;
                }

                if (e.ColumnIndex == indCanCaj || e.ColumnIndex == indCanUni || e.ColumnIndex == indDiaCub)
                {
                    ActualizarProductosEnEsperaCotizacion();
                    ActualizarDescripcionCantidad1();
                }
                    //datGriVieAgrProPro.Rows[datGriVieAgrProPro.SelectedRows[0].Index - 1].Selected = true;
            }
        }

        private void ReiniciarElementosComboBox(DataGridViewComboBoxCell dataGridViewComboBoxCell)
        {
            while(dataGridViewComboBoxCell.Items.Count > 0)
                dataGridViewComboBoxCell.Items.RemoveAt(0);

            dataGridViewComboBoxCell.Items.Add("Caja");
            dataGridViewComboBoxCell.Items.Add("Pieza");
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (tabConCot.SelectedTab == tabPagAgrPro)
                    butAgrPro.PerformClick();
                else
                    butSolAgrPro.PerformClick();
            else
                if (e.KeyCode == Keys.Delete)
                {
                    //Linea de codigo comentada provisionalmente, para evitar un error raro que borra todos los productos de la tabla de la derecha, aparentemente sin usar codigo de esta clase. Se pierden los renglones al correr de la linea 562 a la 144.
                    //butEli.PerformClick();
                    
                    ////objCom.EliminarProductoEnEsperaCotizacion(agrProd.SelectedRows[0].Cells[0].Value.ToString());
                    ////ActualizarProductosEnEsperaCotizacion();
                }
        }

        private void ActualizarProductosEnEsperaCotizacion()
        {
            habilitadoSelectionChanged = false;
            habilitadoCellValueChanged = false;

            agrProd.Rows.Clear();
            agrProd.Columns[3].ReadOnly = false;
            CargarProductosEnEsperaCotizacion(false);
            agrProd.ClearSelection();

            habilitadoCellValueChanged = true;
            habilitadoSelectionChanged = true;

            if (agrProd.Rows.Count > 0)
            {
                agrProd.Rows[agrProd.Rows.Count - 1].Selected = true;
                butEli.Enabled = true;
            }
            else
            {
                labCan.Text = "";
                butEli.Enabled = false;
            }
        }

        private void butAgrPro_Click(object sender, EventArgs e)
        {
            String codBar = texBoxIdPro.Text.Trim();
            int resultado;

            if (!String.IsNullOrEmpty(codBar))
            {
                string[] array = objCom.ExisteProductoConClaveAdicional(codBar);
                resultado = int.Parse(array[0]);
                bool exi = false;
                if (resultado == 1 || resultado == -2 || resultado == -3)
                    exi = true;
                if (exi)
                {
                    if (!objCom.ExisteProductoMejorPrecio(codBar))
                    {
                        object[] res = ExisteProductoEnEsperaCotizacion(agrProd, codBar);

                        if (!(bool)res[0])
                        {
                            if (codBar == array[1])
                            {
                                objCom.AgregarProductoEsperaCotizacion(codBar, "", idUsu);
                            }
                            else
                            {
                                objCom.AgregarProductoEsperaCotizacion("", codBar, idUsu);
                            }
                            ActualizarProductosEnEsperaCotizacion();
                        }
                        else
                        {
                            MessageBox.Show("El producto ya está en la tabla.");
                            agrProd.Rows[int.Parse(res[1].ToString())].Selected = true;
                        }
                    }
                    else
                        MessageBox.Show("Ya se tiene el mejor precio del producto con código de barras: " + codBar + ". No se agregó a la lista.");
                }
                else
                    MessageBox.Show("No existe producto con código de barras: " + codBar + ".");

                texBoxIdPro.Text = "";
            }
        }

        private object[] ExisteProductoEnEsperaCotizacion(DataGridView dgv, string idProd)
        {
            bool prodRep = false;
            int ren = 0;

            foreach (DataGridViewRow renglon in dgv.Rows)
            {
                if (idProd.Equals(renglon.Cells[0].Value.ToString()))
                {
                    prodRep = true;
                    ren = renglon.Index;
                    break;
                }
            }

            return new object[] { prodRep, ren };
        }

        private object[] ExisteProductoEnTabla3(string idProv)
        {
            bool exiProTab = false;
            int ren = 0;

            foreach (DataGridViewRow renglon in datGriVieGenCotProv.Rows)
            {
                if (idProv.Equals(renglon.Cells[0].Value.ToString()))
                {
                    exiProTab = true;
                    ren = renglon.Index;
                    break;
                }
            }

            return new object[] { exiProTab, ren };
        }

        private void CargarProductosEnEsperaCotizacion(bool preBotAgr)
        {
            List<object[]> productos = objCom.ObtenerProductosACotizar(true);
            DataGridViewComboBoxCell cotizarPor = null;
            short canCaj;
            bool tieClaAdi = false;

            foreach (object[] producto in productos)
            {
                if (producto[indDiaCub + 1].ToString().Equals("0") || producto[indDiaCub + 1].ToString().Equals(""))
                    producto[indDiaCub + 1] = "-";
                if (producto[2].ToString().Equals(""))
                {
                    tieClaAdi = false;
                    agrProd.Rows.Add(new object[] { producto[1], producto[2], producto[3], producto[4], producto[5], producto[6], producto[7], producto[8], producto[9], producto[10] });
                }
                else
                {
                    tieClaAdi = true;
                    agrProd.Rows.Add(new object[] { producto[1], producto[2], producto[3], short.Parse(producto[4] + ""), producto[5], producto[6], producto[7], producto[8], producto[9], producto[10] });
                }

                cotizarPor = (agrProd.Rows[agrProd.RowCount - 1].Cells[6] as DataGridViewComboBoxCell);
                
                if (!tieClaAdi)
                {
                    cotizarPor.Items.RemoveAt(0);
                    agrProd.Rows[agrProd.Rows.Count - 1].Cells[6].Value = cotizarPor.Items[0];
                    agrProd.Rows[agrProd.Rows.Count - 1].Cells[3].ReadOnly = true;
                }
                else
                    if((bool)producto[7])
                        agrProd.Rows[agrProd.Rows.Count - 1].Cells[6].Value = cotizarPor.Items[0];
                    else
                        agrProd.Rows[agrProd.Rows.Count - 1].Cells[6].Value = cotizarPor.Items[1];
            }
        }

        private void butSelProd_Click(object sender, EventArgs e)
        {
            new BuscarProducto(texBoxIdPro, butAgrPro, false).ShowDialog(this);
        }

        private void butSepPro_Click(object sender, EventArgs e)
        {
            List<string[]> prod = new List<string[]>();
            bool prodRep = false;
            int i, j, m;
            for(i = 0; i < agrProd.Rows.Count; i++)
            {
                for (j = 0; j < datGriVieGenCotProv.Rows.Count; j++)
                {
                    prod = objCom.ObtenerProductosCotizacionSeparados(long.Parse(datGriVieGenCotProv.Rows[j].Cells[0].Value + ""));
                    for (m = 0; m < prod.Count; m++)
                    {
                        if ((prod[m][0] + "").Equals(agrProd.Rows[i].Cells[0].Value + ""))
                        //if ((agrProd.Rows[j].Cells[0].Value).Equals(datGriVieGenCotProv.Rows[i].Cells[0].Value))
                        {
                            prodRep = true;
                            break;
                        }
                    }
                    if (prodRep)
                        break;
                    prod.Clear();
                }
            }

            if(prodRep)
            {
                PreguntaReemplazarSumar prs = new PreguntaReemplazarSumar();
                if (prs.ShowDialog() == DialogResult.Yes)
                    objCom.SepararPorProveedor(true);
                else
                    objCom.SepararPorProveedor(false);
                prs.Dispose();
            }
            else
                objCom.SepararPorProveedor(true);
            ActualizarProductosEnEsperaCotizacion();
            ActualizarProveedoresCotizaciones();
            tabConCot.SelectedIndex = 1;
        }

        private void ActualizarProveedoresCotizaciones()
        {
            ushort indSel;
            if (datGriVieGenCotProv.SelectedRows.Count == 0)
                indSel = 0;
            else
                indSel = (ushort)datGriVieGenCotProv.SelectedRows[0].Index;
            habilitadoSelectionChanged = false;

            datGriVieGenCotProv.Rows.Clear();

            List<String[]> proveedores = objCom.ObtenerProveedoresCotizaciones();

            foreach (string[] proveedor in proveedores)
                datGriVieGenCotProv.Rows.Add(new string[] { proveedor[0], proveedor[1], proveedor[2] });

            datGriVieGenCotProv.ClearSelection();
            habilitadoSelectionChanged = true;

            if (datGriVieGenCotProv.Rows.Count != 0)
            {
                datGriVieGenCotProv.Rows[indSel].Selected = true;
                butSolGenLisSelExc.Enabled = true;
                butGenCotReg.Enabled = true;
            }
            else
            {
                genCot.Rows.Clear();
                butSolGenLisSelExc.Enabled = false;
                butGenCotReg.Enabled = false;
            }
        }

        private void ActualizarProductosCotizacion(long idCot)
        {
            //inhabilitarSelectionChanged = true;

            genCot.Rows.Clear();
            CargarProductosCotizacionSeparados(idCot);

            //inhabilitarSelectionChanged = false;
        }

        private void CargarProductosCotizacionSeparados(long idCot)
        {
            List<String[]> productos = objCom.ObtenerProductosCotizacionSeparados(idCot);
            DataGridViewComboBoxCell cotizarPor = null;

            foreach (string[] producto in productos)
            {
                if (producto[3].Equals("0"))
                    producto[3] = "";

                genCot.Rows.Add(new object[] { producto[0], producto[1], producto[2], producto[3], producto[4], producto[5], "", producto[7] });

                cotizarPor = (genCot.Rows[genCot.RowCount - 1].Cells[6] as DataGridViewComboBoxCell);

                if (producto[3].Equals("") || producto[3].Equals("0"))
                {
                    cotizarPor.Items.RemoveAt(0);
                    genCot.Rows[genCot.Rows.Count - 1].Cells[6].Value = cotizarPor.Items[0];
                }
                else
                    if (bool.Parse(producto[6]))
                        genCot.Rows[genCot.Rows.Count - 1].Cells[6].Value = cotizarPor.Items[0];
                    else
                        genCot.Rows[genCot.Rows.Count - 1].Cells[6].Value = cotizarPor.Items[1];
            }

            if (genCot.Rows.Count != 0)
                genCot.Rows[genCot.Rows.Count - 1].Selected = true;
        }

        private void SepararPorProveedor()
        {


            ////usaLisExc = false;
            //List<string[]> proveedores = new List<string[]>();
            //String can = "";

            //for(int i = 0; i < datGriVieAgrProPro.Rows.Count; i++)
            //{
            //    proveedores = objCom.ObtenerProveedoresPorProducto(datGriVieAgrProPro.Rows[i].Cells[0].Value.ToString());
            //    datGriVieAgrProPro.Rows[i].Selected = true;

            //    foreach(string[] proveedor in proveedores)
            //    {
            //        if (datGriVieAgrProPro.Rows[i].Cells[5].Value.ToString().Equals("Caja"))
            //        {
            //            //provProd.Add(new string[] { proveedor[0], proveedor[1], datGriVieAgrProPro.Rows[i].Cells[0].Value.ToString(), datGriVieAgrProPro.Rows[i].Cells[1].Value.ToString(), datGriVieAgrProPro.Rows[i].Cells[2].Value.ToString(), labCan.Text.Substring(0, labCan.Text.IndexOf(" o ")) });
            //            provProd.Add(new string[] { proveedor[0], proveedor[1], datGriVieAgrProPro.Rows[i].Cells[0].Value.ToString(), datGriVieAgrProPro.Rows[i].Cells[1].Value.ToString(), datGriVieAgrProPro.Rows[i].Cells[2].Value.ToString(), labCan.Text });
            //        }
            //        else
            //        {
            //            if (labCan.Text.Contains("caja"))
            //                can = labCan.Text.Substring(labCan.Text.IndexOf(" o ") + 1);
            //            else
            //                can = labCan.Text;
            //            Todos los derechos reservados. No se otorga permiso para usar, copiar, modificar o distribuir este software con fines educativos, de investigación, con o sin lucro, sin un permiso escrito y firmado por Daniel Alejandro Gutiérrez Ruiz y Jorge Gabriel Gutiérrez Ruiz, estudiantes de Ingeniería en Sistemas Computacionales en el Instituto Tecnológico de Jiquilpan, con número de control 15420492 y 15420493, respectivamente, pertenecientes a la ciudad de Cotija de la Paz, Michoacán, México.Para solicitar permiso, comuníquese con Daniel Alejandro Gutiérrez Ruiz al correo electrónico: daniel_alejandro.12@icloud.com, o con Jorge Gabriel Gutiérrez Ruiz al correo electrónico: jorgea380 @icloud.com.
            //            provProd.Add(new string[] { proveedor[0], proveedor[1], datGriVieAgrProPro.Rows[i].Cells[0].Value.ToString(), "", datGriVieAgrProPro.Rows[i].Cells[2].Value.ToString(), can });
            //        }

            //        if(!bool.Parse(ExisteProductoEnTabla3(proveedor[0])[0].ToString()))
            //        {
            //            sepPorProv = true;
            //            datGriVieGenCotProv.Rows.Add(new object[] { proveedor[0], proveedor[1] });
            //            sepPorProv = false;
            //        }
            //    }
            //}

            //sepPorProv = true;
            //datGriVieAgrProPro.Rows.Clear();
            //sepPorProv = false;
            //datGriVieGenCotProv.Rows[0].Selected = true;
            //datGriVieGenCotProv.Columns[1].HeaderText = "Proveedor";
            //butGenCotReg.Enabled = true;
            //tabConCot.SelectedTab = tabPagGenCot;
            //LimpiarPestañaGenerarCotizacion();
            //CargarProveedoresCotizacion();
        }

        private void LimpiarPestañaGenerarCotizacion()
        {
            limPesSol = true;
            habilitadoSelectionChanged = false;
            datGriVieGenCotProv.Rows.Clear();
            genCot.Rows.Clear();
            habilitadoSelectionChanged = true;
            limPesSol = false;
        }

        //
        //Código de pestana 'Solicitar'
        //
        private void datGriVieGenCotProv_SelectionChanged(object sender, EventArgs e)
        {   
            if(!sepPorProv && habilitadoSelectionChanged)
            {
                ActualizarProductosCotizacion(long.Parse(datGriVieGenCotProv.SelectedRows[0].Cells[0].Value.ToString()));
                //ActualizarDescripcionCantidad2();
            }
            //if (!limPesSol)
            //{
            //    if (usaLisExc)
            //    {
            //        datGriVieGenCotProd.Rows.Clear();
            //        CargarProductosListaExcelSolicitud(long.Parse(datGriVieGenCotProv.SelectedRows[0].Cells[0].Value + ""));
            //    }
            //    else
            //    {
            //        datGriVieGenCotProd.Rows.Clear();
            //        CargarProductosSeparadosProveedor();
            //    }
            //}
        }

        private void CargarProductosListaExcelSolicitud(long idLib)
        {
            List<String[]> productos = objCom.ObtenerProductosListaExcelSolicitud(idLib);

            genCot.Rows.Clear();

            foreach (string[] producto in productos)
            {
                genCot.Rows.Add(producto);
            }
        }

        private void datGriVieGenCotProd_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (!limPesSol)
            //{
            //    if(usaLisExc)
            //    {
            //        string idProd = datGriVieGenCotProd.Rows[e.RowIndex].Cells[0].Value + "";
            //        int nueCan = int.Parse(datGriVieGenCotProd.Rows[e.RowIndex].Cells[2].Value + "");

            //        if (nueCan == 0)
            //            objCom.EliminarProductoCotizacionSolicitud(idProd);
            //        else
            //            objCom.ActualizarCantidadCotizacionSolicitud(idProd, nueCan);

            //        ActualizarNombresExcelSolicitud();
            //    }
            //    else
            //    {
            //        short nueCan = short.Parse(datGriVieGenCotProd.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "");
             //      objCom.ModificarProductoCotizacionSolicitud(datGriVieGenCotProd.Rows[e.RowIndex].Cells[0].Value + "", nueCan, false);
            //        limPesSol = true;
            //        datGriVieGenCotProd.Rows[e.RowIndex].Cells[2].Value = nueCan;
            //        limPesSol = false;
            //    }
            //}
        }

        private void CargarProductosSeparadosProveedor()
        {
            List<String[]> proSepPro = objCom.ProductosEsperaSeparadosProveedor(long.Parse(datGriVieGenCotProv.SelectedRows[0].Cells[0].Value + ""));

            genCot.Rows.Clear();

            foreach (string[] pro in proSepPro)
            {
                genCot.Rows.Add(pro);
            }
        }

        private string DarFormatoFechaHora(DateTime fec)
        {
            String fecFor = "";

            if (fec.Day < 10)
                fecFor += "0" + fec.Day + "-";
            else
                fecFor += fec.Day + "-";

            if (fec.Month < 10)
                fecFor += "0" + fec.Month + "-";
            else
                fecFor += fec.Month + "-";

            fecFor += fec.Year + "-";

            if (fec.Hour < 10)
                fecFor += "0" + fec.Hour + "-";
            else
                fecFor += fec.Hour + "-";

            if (fec.Minute < 10)
                fecFor += "0" + fec.Minute + "-";
            else
                fecFor += fec.Minute + "-";

            if (fec.Second < 10)
                fecFor += "0" + fec.Second;
            else
                fecFor += fec.Second;

            return fecFor;
        }

        private void butSolRegTodPro_Click(object sender, EventArgs e)
        {
            objCom.ProductosRegresarEspera();
            LimpiarPestañaGenerarCotizacion();
            agrProd.Rows.Clear();
            tabConCot.SelectedTab = tabPagAgrPro;
            CargarProductosEnEsperaCotizacion(true); //
        }

        private void butGenLisSelExc_Click(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();
            long idProv = long.Parse(datGriVieGenCotProv.SelectedRows[0].Cells[1].Value + "");
            string nomProv = datGriVieGenCotProv.SelectedRows[0].Cells[2].Value + "",
            nombreDeArchivo = idProv + " Proveedor " + nomProv + ", solicitud de cotizacion.xls";
            ofd.FileName = nombreDeArchivo;
            //usaLisExc = false;

            //if (usaLisExc)
            //{
            //    nombreDeArchivo = datGriVieGenCotProv.SelectedRows[0].Cells[2].Value + "";
            //    idProv = long.Parse(nombreDeArchivo.Substring(0, nombreDeArchivo.IndexOf(" ")));
            //}
            //else
            //{
            //    
            //}

            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
                //string ruta = Path.GetDirectoryName(ofd.FileName);

                GenerarListaEnExcel(idProv, "C:\\Users\\" + ofd.FileName);

                ActualizarProveedoresCotizaciones();
            //}
        }

        private void GenerarListaEnExcel(long idProv, string rutaYNombre)
        {
            string cotPor = "";
            bool exiLib;

            exiLib = ExisteLibroEnDirectorio(idProv);
            DateTime ahora = DateTime.Now;

            string ahoraString = DarFormatoFechaHora(ahora);

            System.IO.Directory.CreateDirectory(Path.GetDirectoryName(rutaYNombre));

            Excel.Application xlApp = new Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("¡Excel no está instalado correctamente!");
                return;
            }

            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            xlWorkSheet.Cells[1, 2] = "Código de barras de producto";
            xlWorkSheet.Cells[1, 1] = "Clave adicional";
            xlWorkSheet.Cells[1, 3] = "Cantidad";
            xlWorkSheet.Cells[1, 4] = "Descripción";
            xlWorkSheet.Cells[1, 5] = "Precio";
            xlWorkSheet.Cells[1, 6] = "¿Es precio por unidad? (Si escribió el precio por caja, la respuesta es 'No')";
            xlWorkSheet.Cells[1, 100] = datGriVieGenCotProv.SelectedRows[0].Cells[0].Value; //IDCotizacion
            xlWorkSheet.Cells[1, 101] = datGriVieGenCotProv.SelectedRows[0].Cells[1].Value; //IDProveedor

            //Rellenar tabla
            for (int ind = 0; ind < genCot.Rows.Count; ind++)
            {
                xlWorkSheet.Cells[ind + 2, 2] = genCot.Rows[ind].Cells[0].Value;   //Codigo de barras
                cotPor = (genCot.Rows[ind].Cells[6] as DataGridViewComboBoxCell).Value.ToString();
                if (cotPor.Contains("Caja"))
                {
                    xlWorkSheet.Cells[ind + 2, 1] = genCot.Rows[ind].Cells[1].Value;   //Clave adicional
                    xlWorkSheet.Cells[ind + 2, 3] = CantidadDescrita(new string[] { genCot.Rows[ind].Cells[3].Value.ToString(), genCot.Rows[ind].Cells[4].Value.ToString(), genCot.Rows[ind].Cells[5].Value.ToString(), genCot.Rows[ind].Cells[7].Value.ToString() }, true);//Cantidad cajas
                    xlWorkSheet.Cells[ind + 2, 100] = genCot.Rows[ind].Cells[3].Value; //Cantidad cajas para que la lea el sistema
                    xlWorkSheet.Cells[ind + 2, 101] = genCot.Rows[ind].Cells[4].Value; //Cantidad piezas por cajas para que la lea el sistema
                }
                else
                {
                    objCom.EliminarClaveAdicionalProductoCotizacion(long.Parse(datGriVieGenCotProv.SelectedRows[0].Cells[0].Value.ToString()), genCot.Rows[ind].Cells[0].Value.ToString());
                    xlWorkSheet.Cells[ind + 2, 3] = CantidadDescrita(new string[] { genCot.Rows[ind].Cells[3].Value.ToString(), genCot.Rows[ind].Cells[4].Value.ToString(), genCot.Rows[ind].Cells[5].Value.ToString(), genCot.Rows[ind].Cells[7].Value.ToString() }, false);//Cantidad piezas
                    xlWorkSheet.Cells[ind + 2, 102] = genCot.Rows[ind].Cells[5].Value; //Cantidad piezas para que lo lea el sistema
                }
                xlWorkSheet.Cells[ind + 2, 4] = genCot.Rows[ind].Cells[2].Value;   //Descripcion producto
                xlWorkSheet.Cells[ind + 2, 6] = "Si";
            }

            try
            {
                //xlWorkBook.OnSave = "C:\\Users\\danie\\Desktop\\11 Proveedor YAKULT, solicitud de cotizacion.xls";
                //xlWorkBook.Save();
                xlWorkBook.SaveAs(rutaYNombre, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                objCom.MarcarExcelGenerado(long.Parse(datGriVieGenCotProv.SelectedRows[0].Cells[0].Value.ToString()));
            }
            catch (COMException ex) { }

            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

            if (!exiLib)
                MessageBox.Show("Archivo de Excel creado. Puedes encontrar el archivo en: " + rutaYNombre);
        }

        private void butSolCarLisExc_Click(object sender, EventArgs e)
        {
            //Abrir cuadro de dialogo
            string[] rutasArchivos;
            List<long> idLib = new List<long>();

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\ValleVerde\\Cotizaciones";
                openFileDialog.Filter = "Archivos de excel (*.xls)|*.xls";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //datGriVieGenCotProd.Rows.Clear();

                    //Get the paths of specified files
                    rutasArchivos = openFileDialog.FileNames;

                    usaLisExc = true;

                    
                    int ind = 0;

                    Excel.Application xlApp = new Excel.Application();
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    Excel.Range range;

                    string celAct;
                    int conRen;
                    int conCol;
                    int numRen = 0;
                    int numCol = 0;

                    foreach(string rutaArchivo in rutasArchivos)
                    {
                        //idLib.Add(objCom.AgregarLibroExcelSolicitud(long.Parse(rutaArchivo.Substring(27, rutaArchivo.IndexOf(" ") - 27)), rutaArchivo.Substring(27)));

                        //Cargar archivo de excel
                        xlWorkBook = xlApp.Workbooks.Open(rutaArchivo, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                        range = xlWorkSheet.UsedRange;
                        numRen = range.Rows.Count;
                        numCol = range.Columns.Count;
                        List<String> ren = new List<String>();

                        for (conRen = 2; conRen <= numRen; conRen++)
                        {
                            for (conCol = 1; conCol <= numCol; conCol++)
                            {
                                celAct = (range.Cells[conRen, conCol] as Excel.Range).Value2 + "";
                                ren.Add(celAct);
                            }

                            //objCom.AgregarProductosListaExcelSolicitud(idLib[ind], ren);

                            genCot.Rows.Add(new object[] { ren[1], ren[0], ren[2], ren[3], ren[4], ren[5]});

                            ren.Clear();
                        }

                        xlWorkBook.Close(true, null, null);
                        Marshal.ReleaseComObject(xlWorkSheet);
                        Marshal.ReleaseComObject(xlWorkBook);

                        ind++;
                    }
                    xlApp.Quit();

                    Marshal.ReleaseComObject(xlApp);

                    openFileDialog.Dispose();

                    //ActualizarNombresExcelSolicitud();
                }
            }
        }

        private void ActualizarNombresExcelSolicitud()
        {
            List<String[]> listas = objCom.ObtenerListasExcelSolicitud();

            LimpiarPestañaGenerarCotizacion();

            foreach (string[] lis in listas)
            {
                datGriVieGenCotProv.Rows.Add(lis);
            }
        }

        private void butSolBusPro_Click(object sender, EventArgs e)
        {
            new BuscarProducto(texBoxSolIdProd, butSolAgrPro, false).Show();
        }

        private void butSolAgrPro_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(texBoxSolIdProd.Text.Trim()))
            {
                //El campo no esta vacio
                sbyte res = objCom.CodigoEsCajaOProducto(texBoxSolIdProd.Text.Trim());
                if (res != -1)
                {
                    //El codigo de barras es de un producto o de una caja

                    object[] res2 = ExisteProductoEnEsperaCotizacion(genCot, texBoxSolIdProd.Text.Trim());

                    //Sino se encuentra ya en la tabla
                    if(!bool.Parse(res2[0] + ""))
                    {
                        if (objCom.ProveedorVendeProductoOCaja(long.Parse(datGriVieGenCotProv.SelectedRows[0].Cells[1].Value.ToString()), texBoxSolIdProd.Text.Trim()))
                        {
                            //El producto es vendido por el proveedor
                            if (res == 1)
                                AgregarProductoCotizacion(long.Parse(datGriVieGenCotProv.SelectedRows[0].Cells[0].Value.ToString()), "",texBoxSolIdProd.Text);
                            else
                                AgregarProductoCotizacion(long.Parse(datGriVieGenCotProv.SelectedRows[0].Cells[0].Value.ToString()), texBoxSolIdProd.Text, "");
                        }
                        else
                        {
                            //El producto no es vendido por el proveedor, se le avisa al usuario
                            AvisoProveedorNoVendeProducto avi = new AvisoProveedorNoVendeProducto(1);
                            if (avi.ShowDialog() == DialogResult.Yes)
                                if (res == 1)
                                    AgregarProductoCotizacion(long.Parse(datGriVieGenCotProv.SelectedRows[0].Cells[0].Value.ToString()), "", texBoxSolIdProd.Text);
                                else
                                    AgregarProductoCotizacion(long.Parse(datGriVieGenCotProv.SelectedRows[0].Cells[0].Value.ToString()), texBoxSolIdProd.Text, "");
                                avi.Dispose();
                        }
                    }
                    else
                    {
                        genCot.Rows[(int)res2[1]].Selected = true;
                        texBoxSolIdProd.Text = "";
                    }
                    
                }
            }
        }

        private void AgregarProductoCotizacion(long idCot, string idProd, string idClaAdi)
        {
            objCom.AgregarProductoCotizacion(idCot, idProd, idClaAdi);
            ActualizarProveedoresCotizaciones();
            //ActualizarNombresExcelSolicitud();
            texBoxSolIdProd.Text = "";
        }

        private void butRecCarLisExc_Click(object sender, EventArgs e)
        {
            //Abrir cuadro de dialogo
            string[] rutasArchivos;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\ValleVerde\\Cotizaciones";
                openFileDialog.Filter = "Archivos de excel (*.xls)|*.xls";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the paths of specified files
                    rutasArchivos = openFileDialog.FileNames;

                    //butRecBusMejPre.Enabled = true;

                    Excel.Application xlApp = new Excel.Application();
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    Excel.Range range;

                    string celAct;
                    int conRen;
                    int conCol;
                    int numRen = 0;
                    int numCol = 0;
                    string idProv = "";
                    string nomArc = "";
                    List<string> ren;

                    foreach (string rutaArchivo in rutasArchivos)
                    {
                        idProv = rutaArchivo.Substring(27, rutaArchivo.IndexOf(" ") - 27);
                        nomArc = rutaArchivo.Substring(27);

                        ren = new List<string>();

                        //Cargar archivo de excel
                        xlWorkBook = xlApp.Workbooks.Open(rutaArchivo, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                        range = xlWorkSheet.UsedRange;
                        numRen = range.Rows.Count;
                        numCol = range.Columns.Count;

                        for (conRen = 2; conRen <= numRen; conRen++)
                        {
                            for (conCol = 1; conCol <= numCol; conCol++)
                            {
                                celAct = (range.Cells[conRen, conCol] as Excel.Range).Value2 + "";
                                ren.Add(celAct);
                            }

                            prod.Add(new string[] { idProv, nomArc, ren[0], ren[1], ren[2], ren[3], ren[4] });
                            ren.Clear();
                        }

                        xlWorkBook.Close(true, null, null);
                        Marshal.ReleaseComObject(xlWorkSheet);
                        Marshal.ReleaseComObject(xlWorkBook);

                    }
                    xlApp.Quit();

                    Marshal.ReleaseComObject(xlApp);

                    openFileDialog.ShowDialog();

                    //ActualizarNombresExcelRecibir();
                }
            }
        }

        private void prodAgrEmp_Click(object sender, EventArgs e)
        {
            new ProductosAgregadosPorEmpleados().ShowDialog();
            ActualizarProductosEnEsperaCotizacion();
        }

        private void ActualizarNombresExcelRecibir()
        {
            LimpiarPestañaRecibir();

            List<string> idProv = new List<string>();

            foreach (string[] ren in prod)
            {
                if (!idProv.Contains(ren[0]))
                {
                    //datGriVieRecProv.Rows.Add(new object[] { ren[0], ren[1] });
                    idProv.Add(ren[0]);
                }
            }
        }

        private void LimpiarPestañaRecibir()
        {
            /*
            limPesRec = true;
            datGriVieRecProv.Rows.Clear();
            datGriVieRecProd.Rows.Clear();
            limPesRec = false;
            */
        }

        private void SepararMejoresPrecios()
        {
            List<string[]> prodMejPre = new List<string[]>();
            List<string> idProdRev = new List<string>();
            List<string[]> mejPre = new List<string[]>();

            //Intento 3
            foreach (string[] ren in prod)
            {
                if (!idProdRev.Contains(ren[2]))
                {
                    var matchingValues = prod.Where(stringToCheck => stringToCheck[2].Contains(ren[2]));

                    foreach (string[] renMat in matchingValues)
                    {
                        if (mejPre.Count == 0)
                            mejPre.Add(renMat);
                        else
                        {
                            if (double.Parse(renMat[5]) < double.Parse(mejPre[0][5]))
                            {
                                mejPre.Clear();

                                mejPre.Add(renMat);
                            }
                        }
                    }

                    if (objCom.AgregarProductoMejorPrecio(mejPre) == -1)
                        MessageBox.Show("Ya se tiene el mejor precio del producto: " + mejPre[0][3] + ". No se agregará a la lista de mejores precios.");
                    mejPre.Clear();
                    idProdRev.Add(ren[2]);
                }
            }

            prod.Clear();
        }

        private void CargarProductosListaExcelRecibir()
        {
            /*
            double sub = 0.0;

            foreach (string[] ren in prod)
            {
                if(ren[0] == datGriVieRecProv.SelectedRows[0].Cells[0].Value + "")
                {
                    datGriVieRecProd.Rows.Add(new object[] { ren[2], ren[3], ren[4], ren[5], ren[6] });
                    sub += double.Parse(ren[4]) * double.Parse(ren[5]);
                }
            }
            */
        }

        private void butAgr_Click(object sender, EventArgs e)
        {
            byte numCat = 255;
            long idCat = -1;
            short diaCub = 0;

            switch (tabCon.SelectedIndex)
            {
                case 0:
                    idCat = long.Parse(mar.SelectedRows[0].Cells[0].Value.ToString());
                    numCat = 0;
                    break;
                case 1:
                    idCat = long.Parse(lin.SelectedRows[0].Cells[0].Value.ToString());
                    numCat = 1;
                    break;
                case 2:
                    idCat = long.Parse(fab.SelectedRows[0].Cells[0].Value.ToString());
                    numCat = 2;
                    break;
                case 3:
                    idCat = long.Parse(prov.SelectedRows[0].Cells[0].Value.ToString());
                    numCat = 3;
                    break;
                case 4:
                    idCat = -1;
                    numCat = 5;
                    break;
            }

            if (!tbDiaCub.Text.Equals(""))
                diaCub = short.Parse(tbDiaCub.Text);

            objCom.AgregarProductosCotizacion("", tipCot, idCat, numCat, diaCub, sob.Checked, idUsu);
            ActualizarProductosEnEsperaCotizacion();
        }

        private void AgregarProductosACotizar(byte tipCot, long idCat, byte numCat, short diaCub)
        {
            //String canStr, descUni, cat = "", mesTieSufInv = "";
            //int numProIni;
            //bool seOmiPro = false, vieCaj = true, cotPorCaj;
            //short? canCaj;
            //decimal canUni;

            //List<object[]> productos = new List<object[]>();

            //switch (tipCot)
            //{
            //    case 0:
            //        mesTieSufInv = "Tienes suficiente inventario en base a sugerencias, últimos dos meses y mínimo de inventario, no es necesario encargar productos.";
            //        break;
            //    case 1:
            //        mesTieSufInv = "Tienes suficiente inventario en base a últimos dos meses y mínimo de inventario, no es necesario encargar productos.";
            //        break;
            //    case 2:
            //        mesTieSufInv = "Tienes suficiente inventario en base al mínimo de inventario, no es necesario encargar productos.";
            //        break;
            //}

            ////switch (numCat)
            ////{
            ////    case 0:
            ////        cat = "esta marca";
            ////        break;
            ////    case 1:
            ////        cat = "esta línea";
            ////        break;
            ////    case 2:
            ////        cat = "este fabricante";
            ////        break;
            ////    case 3:
            ////        cat = "este proveedor";
            ////        break;
            ////}

            objCom.AgregarProductosCotizacion("", tipCot, idCat, numCat, diaCub, sob.Checked, idUsu);
            
            //if (productos.Count == 0)
            //    MessageBox.Show(mesTieSufInv);
            //else
            //{
            //    numProIni = agrProd.Rows.Count;
            //    habilitadoSelectionChanged = false;
            //    habilitadoCellValueChanged = false;
            //    habilitadaDescripcionProducto = false;

            //    agrProd.Rows.Clear();

            //    foreach (object[] producto in productos)
            //    {
            //        /*if (!bool.Parse(ExisteProductoEnEsperaCotizacion(producto[0])[0].ToString()))
            //        {   
            //            idProd, idClaAdi, nom,
            //            canCaj, canPie, uni, cotPor
            //            */
            //            canStr = "";
            //            descUni = producto[8].ToString().ToLower();
            //            vieCaj = true;

            //            if ((decimal)producto[6] != (decimal)1)
            //                descUni += "s";

            //            if (!producto[4].ToString().Equals("") && !producto[4].ToString().Equals("0"))
            //            {
            //                canCaj = (short)producto[4];
            //                if (canCaj == 1)
            //                    canStr = canCaj + " caja con " + (decimal)producto[5] + " " + descUni;
            //                else
            //                    canStr = canCaj + " cajas con " + (decimal)producto[5] + " " + descUni;
            //            }  
            //            else
            //            {
            //                vieCaj = false;
            //                canCaj = null;
            //            }

            //            if (!canStr.Equals(""))
            //                canStr += " o ";
            //            if (!producto[6].ToString().Equals(""))
            //                canStr += producto[6] + " " + descUni;

            //            if (producto[9].ToString().Equals("") || producto[9].ToString().Equals("0"))
            //                producto[9] = "-";

            //        if (canCaj == null)
            //            agrProd.Rows.Add(new object[] { producto[1], producto[2], producto[3], "", producto[5], producto[6], producto[7], producto[8], producto[9], producto[10] });
            //        else
            //            agrProd.Rows.Add(new object[] { producto[1], producto[2], producto[3], canCaj, producto[5], producto[6], producto[7], producto[8], producto[9], producto[10] });
            //            //try { this.canEsp = decimal.Parse(canEsp); } catch { this.canEsp = -1; };

            //            //objCom.AgregarProductoEsperaCotizacion(producto[1], producto[2], producto[4], decimal.Parse(producto[6]), bool.Parse(producto[7]), producto[9], producto[10]);
            //            // short canCaj, decimal canUni, bool cotPorCaj, short diaCub
            //                                                // tipCot, idCat, numCat, diaCub
            //                                                // 0, idProd, valCam, canCaj, canUni, cotPor, diaCub
            //            if (!vieCaj)
            //                (agrProd.Rows[agrProd.RowCount - 1].Cells[indCotPor] as DataGridViewComboBoxCell).Items.RemoveAt(0);
            //            agrProd.Rows[agrProd.RowCount - 1].Cells[indCotPor].Value = (agrProd.Rows[agrProd.RowCount - 1].Cells[indCotPor] as DataGridViewComboBoxCell).Items[0];
            //        //}
            //        //else
            //        //    seOmiPro = true;
            //    }

                ////if (numProIni == agrProd.Rows.Count)
                ////    MessageBox.Show("Todos los productos a cubrir de " + cat + " ya estaban en la tabla. No se agregó ninguno.");
                ////else
                ////    if (seOmiPro)
                ////    MessageBox.Show("Algunos productos no se agregaron porque ya estaban en la tabla.");

                //habilitadoSelectionChanged = true;
                //habilitadoCellValueChanged = true;
                //habilitadaDescripcionProducto = true;

                //agrProd.Rows[agrProd.Rows.Count - 1].Selected = true;
                //datGriVie.SelectedRows[0].DefaultCellStyle.BackColor = Color.LightGray;
                //datGriVie.ClearSelection();
            //}
        }

        private void tabPagAgrPro_Click(object sender, EventArgs e)
        {

        }

        private void tabConCot_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CargarProductosUltimosMeses(long idCat)
        {
            String can, uni, cat = "";
            int numProIni;
            bool seOmiPro = false, vieCaj = true;

            List<String[]> productos = new List<String[]>();

            switch (tabCon.SelectedIndex)
            {
                case 0:
                    productos = objCom.ObtenerProductosUltimosMeses(0, idCat);
                    cat = "esta marca";
                    break;
                case 1:
                    productos = objCom.ObtenerProductosUltimosMeses(1, idCat);
                    cat = "esta línea";
                    break;
                case 2:
                    productos = objCom.ObtenerProductosUltimosMeses(2, idCat);
                    cat = "este fabricante";
                    break;
                case 3:
                    productos = objCom.ObtenerProductosUltimosMeses(3, idCat);
                    cat = "este proveedor";
                    break;
            }

            if (productos.Count == 0)
                    MessageBox.Show("Tienes suficiente inventario en base a los últimos dos meses.");
            else
            {
                numProIni = agrProd.Rows.Count;

                foreach (String[] producto in productos)
                {
                    if (!bool.Parse(ExisteProductoEnEsperaCotizacion(agrProd, producto[0])[0].ToString()))
                    {
                        can = "";
                        uni = producto[5].ToLower();
                        vieCaj = true;

                        if (float.Parse(producto[4]) != 1)
                            uni += "s";

                        if (!producto[3].Equals(""))
                            if (Math.Ceiling(float.Parse(producto[3])) == 1)
                                can = Math.Ceiling(float.Parse(producto[3])) + " caja con " + (float.Parse(producto[4]) / float.Parse(producto[3])).ToString() + " " + uni;
                            else
                                can = Math.Ceiling(float.Parse(producto[3])) + " cajas con " + (float.Parse(producto[4]) / float.Parse(producto[3])).ToString() + " " + uni;
                        else
                            vieCaj = false;

                        if (!can.Equals(""))
                            can += " o ";
                        if (!producto[4].Equals(""))
                            can += producto[4] + " " + uni;
                        agrProd.Rows.Add(new object[] { producto[0], producto[1], producto[2], producto[3], producto[4], "", producto[5], "" });

                        if (!vieCaj)
                            (agrProd.Rows[agrProd.RowCount - 1].Cells[5] as DataGridViewComboBoxCell).Items.RemoveAt(0);
                        agrProd.Rows[agrProd.RowCount - 1].Cells[5].Value = (agrProd.Rows[agrProd.RowCount - 1].Cells[5] as DataGridViewComboBoxCell).Items[0];
                    }
                    else
                        seOmiPro = true;
                }

                if (numProIni == agrProd.Rows.Count)
                    MessageBox.Show("Todos los productos a cubrir de " + cat + " ya estaban en la tabla. No se agregó ninguno.");
                else
                    if (seOmiPro)
                    MessageBox.Show("Algunos productos no se agregaron porque ya estaban en la tabla.");

                agrProd.Rows[agrProd.Rows.Count - 1].Selected = true;
                datGriVie.SelectedRows[0].DefaultCellStyle.BackColor = Color.LightGray;
                datGriVie.ClearSelection();
            }
        }

        private void CargarProductosBajosInventario(long idCat)
        {
            String can, uni, cat = "";
            int numProIni;
            bool seOmiPro = false;

            List<String[]> productos = new List<String[]>();

            switch (tabCon.SelectedIndex)
            {
                case 0:
                    productos = objCom.ObtenerProductosBajosInventario(0, idCat);
                    cat = "esta marca";
                    break;
                case 1:
                    productos = objCom.ObtenerProductosBajosInventario(1, idCat);
                    cat = "esta línea";
                    break;
                case 2:
                    productos = objCom.ObtenerProductosBajosInventario(2, idCat);
                    cat = "este fabricante";
                    break;
                case 3:
                    productos = objCom.ObtenerProductosBajosInventario(3, idCat);
                    cat = "este proveedor";
                    break;
            }

            if (productos.Count == 0)
                MessageBox.Show("Ya tienes el inventario mínimo.");
            else
            {
                numProIni = agrProd.Rows.Count;

                foreach (String[] producto in productos)
                {
                    if (!bool.Parse(ExisteProductoEnEsperaCotizacion(agrProd, producto[0])[0].ToString()))
                    {
                        can = "";
                        uni = producto[5].ToLower();

                        if (float.Parse(producto[4]) != 1)
                            uni += "s";

                        if (!producto[3].Equals(""))
                            if (Math.Ceiling(float.Parse(producto[3])) == 1)
                                can = Math.Ceiling(float.Parse(producto[3])) + " caja con " + (float.Parse(producto[4]) / float.Parse(producto[3])).ToString() + " " + uni;
                            else
                                can = Math.Ceiling(float.Parse(producto[3])) + " cajas con " + (float.Parse(producto[4]) / float.Parse(producto[3])).ToString() + " " + uni;
                        if (!can.Equals(""))
                            can += " o ";
                        if (!producto[4].Equals(""))
                            can += producto[4] + " " + uni;
                        agrProd.Rows.Add(new string[] { producto[0], producto[1], producto[2], producto[3], producto[4], "", producto[5], "" });

                    }
                    else
                        seOmiPro = true;
                }

                if (numProIni == agrProd.Rows.Count)
                    MessageBox.Show("Todos los productos a cubrir de " + cat + " ya estaban en la tabla. No se agregó ninguno.");
                else
                    if (seOmiPro)
                    MessageBox.Show("Algunos productos no se agregaron porque ya estaban en la tabla.");

                agrProd.Rows[agrProd.Rows.Count - 1].Selected = true;
                datGriVie.SelectedRows[0].DefaultCellStyle.BackColor = Color.LightGray;
                datGriVie.ClearSelection();
            }
        }

        private void butEli_Click(object sender, EventArgs e)
        {
            objCom.EliminarProductoEnEsperaCotizacion(agrProd.SelectedRows[0].Cells[0].Value.ToString());
            ActualizarProductosEnEsperaCotizacion();
        }

        private void tabCon_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private bool ExisteLibroEnDirectorio(long idProv)
        {
            string[] rutaArchivos = Directory.GetFiles(@"c:\ValleVerde\Cotizaciones\", "*.xls");
            foreach (string ruta in rutaArchivos)
            {
                if(ruta.Contains(idProv + ""))
                {
                    return true;
                }
            }
            return false;
        }

        //
        //Código de pestana 'Enviar'
        //

    }
}
