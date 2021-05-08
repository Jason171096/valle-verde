using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ValleVerde.Programacion.Ventas;

namespace ValleVerde.Vistas.Compras
{
    public partial class HistorialCompras : Form
    {
        Programacion.Compra.Compras obj = new Programacion.Compra.Compras();
        Ordenes ordenes = new Ordenes();
        public long idProSel;
        List<String[]> datCom;
        List<String[]> auxiliar;
        List<object[]> facturas;
        private string idproveedor;
        private int count = 0;
        private bool stop = false;
        private bool _calendarDroppedDown = false;
        List<List<object[]>> ListaProductos = new List<List<object[]>>();
        string idFact, idProd, descrProd;
        private int VerCompra = 1, cont = 1;
        //Indices para acomodar las columnas del DataGridView dgvFullFactura
        private readonly byte indInd = 0;
        private readonly byte indCodBar = 1;
        private readonly byte indCan = 2;
        private readonly byte indNomProd = 3;
        private readonly byte indcostoRecibidoSin = 4;
        private readonly byte indCosto = 5;
        private readonly byte indDesc = 6;
        private readonly byte indListaImpuestos = 7;
        private readonly byte indIVA = 8;
        private readonly byte indIEPS = 9;
        private readonly byte indimporteSin = 10;
        private readonly byte indimporte = 11;
        //
        private readonly Dictionary<int, string> FormasPago = new Dictionary<int, string>();

        public HistorialCompras()
        {
            InitializeComponent();

            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvDatCom, true, false);
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvFullFactura, true, false);
            radButCom.CheckedChanged += new EventHandler(radioButtonsBuscarPor_CheckedChanged);
            radButPro.CheckedChanged += new EventHandler(radioButtonsBuscarPor_CheckedChanged);
            radButFec.CheckedChanged += new EventHandler(radioButtonsBuscarPor_CheckedChanged);
            rdbTodas.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            rdbCredito.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            rdbContado.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);

            dgvDatCom.SelectionChanged += new EventHandler(dgvDatCom_SelectionChanged);
            datTimPicFecIni.MinDate = DateTime.Parse("01/12/2018");
            datTimPicFecFin.MinDate = DateTime.Parse("01/12/2018");
            datTimPicFecIni.MaxDate = DateTime.Now.Date;
            datTimPicFecFin.MaxDate = DateTime.Now.Date;

            FormasPago.Add(1, "Efectivo");
            FormasPago.Add(2, "Tarjeta");
            FormasPago.Add(3, "Vale");
            FormasPago.Add(4, "Credito");
            FormasPago.Add(5, "Cheque");
            FormasPago.Add(6, "Transferencia");

            CargarCompras(1, 1, count, "-1", "-1", datTimPicFecIni.Value, datTimPicFecFin.Value);
        }
        #region Ver compras RadioButton
        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            //Cargar las compras conforme cambia al RadioButton
            RadioButton rdb = sender as RadioButton;
            if (rdb.Checked && rdb.TabIndex == 101)
            {//Muesta todas las compras ya sean de Credito o a Contado
                VerCompra = 1;
                LimpiarVentanaCompra();
                CargarCompras(1, 1, 0, "-1", "-1", datTimPicFecIni.Value, datTimPicFecFin.Value);
                radButNin.Checked = true;
            }
            else if (rdb.Checked && rdb.TabIndex == 102)
            {//Muestra las compras de Contado
                VerCompra = 2;
                LimpiarVentanaCompra();
                CargarCompras(2, 1, 0, "-1", "-1", datTimPicFecIni.Value, datTimPicFecFin.Value);
                radButNin.Checked = true;
            }
            else if (rdb.Checked && rdb.TabIndex == 103)
            {//Muestra las compras de Credito
                VerCompra = 3;
                LimpiarVentanaCompra();
                CargarCompras(3, 1, 0, "-1", "-1", datTimPicFecIni.Value, datTimPicFecFin.Value);
                radButNin.Checked = true;
            }
        }
        #endregion
        #region CargarCompras y CargarProductos
        private void CargarCompras(int vercompra, int opcion, int cont, string buscar, string idproveedor, DateTime dateI, DateTime dateF)
        {//Carga las compras 
            datCom = obj.ObtenerCompras(vercompra, opcion, cont, buscar, idproveedor, dateI, dateF);//Obtiene la lista de las compras
            dgvDatCom.ColumnCount = 3;//Se le asigna al dgvDatCom las columnas 
            dgvDatCom.Columns[0].Name = "ID";
            dgvDatCom.Columns[1].Name = "Nombre";
            dgvDatCom.Columns[2].Name = "Fecha";
            foreach (string[] datos in datCom)
            {//Se le añade las Filas
                string[] row = new string[] { datos[0], datos[4], DateTime.Parse(datos[5]).ToShortDateString() };
                dgvDatCom.Rows.Add(row);
            }
            dgvDatCom.Columns[0].Visible = false;//Se hace invisible el ID de Compra
        }
        private void CargarProductos(int indFac)
        {
            short ren;
            //El indice y la Lista de Productos no cumplen la condicion esta se da por determinada
            //Que existe la Compra pero que no tiene Productos en su Factura
            if (indFac >= 0 && ListaProductos.Count > 0)
            {
                dgvFullFactura.Rows.Clear();
                dgvFullFactura.ColumnCount = 12;
                dgvFullFactura.Columns[0].Name = "Indice";
                dgvFullFactura.Columns[1].Name = "Codigo Producto";
                dgvFullFactura.Columns[2].Name = "Cantidad";
                dgvFullFactura.Columns[3].Name = "Nombre Producto";
                dgvFullFactura.Columns[4].Name = "Costo recibido(sin impuestos)";
                dgvFullFactura.Columns[5].Name = "Costo";
                dgvFullFactura.Columns[6].Name = "Descuento";
                dgvFullFactura.Columns[7].Name = "Lista de Impuestos";
                dgvFullFactura.Columns[8].Name = "IVA";
                dgvFullFactura.Columns[9].Name = "IEPS";
                dgvFullFactura.Columns[10].Name = "Importe(sin impuestos)";
                dgvFullFactura.Columns[11].Name = "Importe";
                foreach (object[] items in ListaProductos[indFac])
                {//0.IDProducto 1.ClaveAdional 2.Cantidad 3.Costo 4.Descuento 5.CantidadDevuelta 6.MotivoDevolucion 7.Indice 8.NombrePrducto 9.ListaImpuestos
                    dgvFullFactura.Rows.Add();//Se crea un Fila nueva vacia que despues se va a llenar
                    ren = (short)(dgvFullFactura.Rows.Count - 1);

                    dgvFullFactura.Rows[ren].Cells[indInd].Value = items[7];
                    if (items[1].ToString().Equals(""))
                        dgvFullFactura.Rows[ren].Cells[indCodBar].Value = items[0];
                    else
                        dgvFullFactura.Rows[ren].Cells[indCodBar].Value = items[1];
                    dgvFullFactura.Rows[ren].Cells[indNomProd].Value = items[8];
                    dgvFullFactura.Rows[ren].Cells[indCan].Value = items[2];
                    //dgvFullFactura.Rows[ren].Cells[costoRecibidoSin].Value = String.Format("{0:C}", items[4]);
                    dgvFullFactura.Rows[ren].Cells[indCosto].Value = String.Format("{0:C}", items[3]);
                    dgvFullFactura.Rows[ren].Cells[indDesc].Value = items[5];
                    dgvFullFactura.Rows[ren].Cells[indListaImpuestos].Value = items[9];
                    //dgvFullFactura.Rows[ren].Cells[IVA].Value = items[10];
                    //dgvFullFactura.Rows[ren].Cells[IEPS].Value = items[11];
                    //dgvFullFactura.Rows[ren].Cells[importeSin].Value = items[12];
                    //dgvFullFactura.Rows[ren].Cells[importe].Value = items[13];

                }
                LlenarLabelsFactura(indFac);
                DarFormatoTabla();
            }
        }

        #endregion
        #region Button Buscar Por
        private void radioButtonsBuscarPor_CheckedChanged(object sender, EventArgs e)
        {
            //Busca de forma en que cambian los RadionButtons de Buscar
            RadioButton rdb = sender as RadioButton;
            if (rdb.Checked && rdb.TabIndex == 111)
            {//Busca Compras por Ningun Filtro
                labFecIni.Enabled = false;
                labFecFin.Enabled = false;
                datTimPicFecIni.Enabled = false;
                datTimPicFecFin.Enabled = false;
                butSelPro.Enabled = false;
                texBoxCom.Enabled = false;
                butBus.Enabled = false;
                LimpiarVentanaCompra();
                CargarCompras(VerCompra, 1, count, "-1", "-1", datTimPicFecIni.Value, datTimPicFecFin.Value);
            }
            else if (rdb.Checked && rdb.TabIndex == 112)
            {//Busca Compras por Fecha
                labFecIni.Enabled = true;
                labFecFin.Enabled = true;
                datTimPicFecIni.Enabled = true;
                datTimPicFecFin.Enabled = true;
                butSelPro.Enabled = false;
                texBoxCom.Enabled = false;
                butBus.Enabled = false;
                LimpiarVentanaCompra();
                CargarCompras(VerCompra, 4, count, "-1", "-1", datTimPicFecIni.Value, datTimPicFecFin.Value);
            }
            else if (rdb.Checked && rdb.TabIndex == 113)
            {//Busca Compras por Proveedor
                labFecIni.Enabled = false;
                labFecFin.Enabled = false;
                datTimPicFecIni.Enabled = false;
                datTimPicFecFin.Enabled = false;
                butSelPro.Enabled = true;
                texBoxCom.Enabled = false;
                butBus.Enabled = false;
                LimpiarVentanaCompra();
            }
            else if (rdb.Checked && rdb.TabIndex == 114)
            {//Busca Compras por ID de Compra
                labFecIni.Enabled = false;
                labFecFin.Enabled = false;
                datTimPicFecIni.Enabled = false;
                datTimPicFecFin.Enabled = false;
                butSelPro.Enabled = false;
                texBoxCom.Enabled = true;
                butBus.Enabled = true;
                LimpiarVentanaCompra();
            }
        }
        #endregion
        #region Button SelectProveedor and Buscar
        private void butSelPro_Click(object sender, EventArgs e)
        {//Boton que Busca la Compras por Proveedor
            LimpiarVentanaCompra();
            TextBox textBox = new TextBox();
            new BuscarProveedor2(textBox).ShowDialog();
            idproveedor = textBox.Text;
            count = 0;
            CargarCompras(VerCompra, 3, count, "-1", idproveedor, DateTime.Now, DateTime.Now);
        }

        private void butBus_Click(object sender, EventArgs e)
        {//Boton que Busca la Compra por su ID
            LimpiarVentanaCompra();
            count = 0;
            CargarCompras(VerCompra, 2, count, texBoxCom.Text, "-1", DateTime.Now, DateTime.Now);
        }
        #endregion
        #region dgvDatCom_SelectionChanged
        private void dgvDatCom_SelectionChanged(object sender, EventArgs e)
        {//Evento que se ejecuta cuando se selecciona una Fila

            //Se limpia la ventana donde van las Facturas
            LimpiarVentanaFactura();         
            ListaProductos.Clear();
            tabConFac.TabPages.Clear();
            if (tabConFac.SelectedIndex > 0)
                tabConFac.SelectedIndex = 0;

            //Se le asigna un nuevo IDCompra
            long idCom = long.Parse(dgvDatCom[0, dgvDatCom.CurrentRow.Index].Value.ToString());
            //Se obtienen las facturas de esa compra
            facturas = obj.ObtenerFacturas(idCom);
            cont = 1;
            for (int i = 0; i < facturas.Count; i++)
            {//Se crean las TapPages de las Facturas
                tabConFac.TabPages.Add($"Factura {cont}");
                cont++;
            }
            foreach (object[] fac in facturas)
            {//Se le agregan a la lista los productos de la Factura
                ListaProductos.Add(obj.ObtenerProductosFactura(fac[0].ToString()));
            }
            LlenarLabelsCompra(dgvDatCom.CurrentRow.Index);
            //Siempre se le asigna 0 para mostrar siempre la lista de productos de la posicion 0
            CargarProductos(0);
            checkCostosImp.Checked = false;
            checkTodosImp.Checked = false;
        }
        #endregion
        #region DataGridView DatosCompras
        private void dgvDatCom_Scroll(object sender, ScrollEventArgs e)
        {//Evento que se ejecuta cuando la Scroll llega al final del DataGridView de Compras 
            if (dgvDatCom.DisplayedRowCount(false) + dgvDatCom.FirstDisplayedScrollingRowIndex >= dgvDatCom.Rows.Count && stop == false)
            {//Si el numero de Filas mostradas al Usuario + la primera Fila mostrada al Usuario es >= que el Total de numero Filas en el DataGridView //Entra
                int x = dgvDatCom.VerticalScrollingOffset;//Obtiene el numero de Pixeles Verticalmente(Se puede borrar ya que no afecta al Scroll del DataGridView)
                count++;
                //Dependiendo de que RadioButton este activo, entra y carga las Compras 
                if (radButNin.Checked)
                {
                    GuardarLista();
                    CargarCompras(VerCompra, 1, count, "-1", "-1", DateTime.Now, DateTime.Now);
                    AsignarLista();
                }
                else if (radButCom.Checked)
                {
                    GuardarLista();
                    CargarCompras(VerCompra, 2, count, texBoxCom.Text, "-1", DateTime.Now, DateTime.Now);
                    AsignarLista();
                }
                else if (radButPro.Checked)
                {
                    GuardarLista();
                    CargarCompras(VerCompra, 3, count, "-1", idproveedor, DateTime.Now, DateTime.Now);
                    AsignarLista();
                }
                else if (radButFec.Checked)
                {
                    GuardarLista();
                    CargarCompras(VerCompra, 4, count, "-1", "-1", datTimPicFecIni.Value, datTimPicFecFin.Value);
                    AsignarLista();
                }
                stop = true;
                //Se le asigna a la posicion en donde se quedo el Pixel(Se puede borrar ya que no afecta al Scroll del DataGridView)
                dgvDatCom.AutoScrollOffset = new Point(x, 0);
            }
            else
                stop = false;
        }
        #endregion
        #region LlenarLabels
        private void LlenarLabelsFactura(int value)
        {//Busca entre la lista de las Facturas y obtene el Arreglo
            object[] datos = facturas[value];
            //Llenas los datos de esa Factura
            idFact = datos[0].ToString();
            txtFolio.Text = datos[3].ToString();
            lSubFac.Text = datos[4].ToString();
            lImpFac.Text = datos[5].ToString();
            lTotFac.Text = datos[6].ToString();
            lDesFac.Text = datos[7].ToString();
            lDevFac.Text = datos[8].ToString();
            lTotAPagFac.Text = datos[9].ToString();
            //Siempre va estar activo si es que no encuentra algun Descuento
            checkNinguno.Checked = true;
            if (datos[2].ToString() != "0")
            {//Si en caso de que encontrara algo se activan los Descuentos necesarios
                checkGeneral.Checked = true;
                lblPorcentaje.Visible = true;
                txtPorcentaje.Visible = true;
                txtPorcentaje.Text = datos[2].ToString();
                checkNinguno.Checked = false;
            }
        }
        private void LlenarLabelsCompra(int numRen)
        {
            try
            {//Obtiene el arreglo de los datos de la Compra almacenados en la lista datCom
                string[] datos = datCom[numRen];

                if(!datos[1].Equals(""))
                {
                    string NombrePago = "";
                    //Obtene del Directorio el nombre de pago por medio del Indice
                    FormasPago.TryGetValue(Convert.ToInt32(datos[1]), out NombrePago);
                    txtPago.Text = NombrePago;
                }                
                labFec.Text = String.Format("{0:dddd, MMMM d, yyyy}", datos[5]);
                labSubGlo.Text = datos[7];
                labImpGlo.Text = datos[8];
                labTotGlo.Text = datos[9];
                labDesGlo.Text = datos[10];
                labDevGlo.Text = datos[11];
                labTotAPag.Text = datos[12];
                txtAlmacen.Text = datos[16];
               
                if (datos[15].ToString().Equals("True"))
                {//Se activa si tiene descuento por Renglon 
                    checkRenglon.Checked = true;
                    checkPorcentaje.Visible = true;
                }
                if (datos[14].ToString().Equals("False") && datos[15].ToString().Equals("False"))
                    //Si no tiene ni descuento por Renglon o General
                    checkNinguno.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }
        #endregion
        #region Limpiar Ventanas
        private void LimpiarVentanaFactura()
        {
            dgvFullFactura.Rows.Clear();
            txtFolio.Text = "";
            txtPorcentaje.Text = "";
            lSubFac.Text = "";
            lImpFac.Text = "";
            lTotFac.Text = "";
            lDesFac.Text = "";
            lDevFac.Text = "";
            lTotAPagFac.Text = "";
            txtPorcentaje.Visible = false;
            lblPorcentaje.Visible = false;
            checkGeneral.Checked = false;
            checkRenglon.Checked = false;
            checkNinguno.Checked = false;
        }
        private void LimpiarVentanaCompra()
        {
            LimpiarVentanaFactura();
            dgvDatCom.Rows.Clear();
            labFec.Text = "-";
            labMetPag.Text = "-";
            txtAlmacen.Text = "";
            txtPago.Text = "";
            labSubGlo.Text = "";
            labImpGlo.Text = "";
            labTotGlo.Text = "";
            labDesGlo.Text = "";
            labDevGlo.Text = "";
            labTotAPag.Text = "";
            tabConFac.TabPages.Clear();
            count = 0;

        }
        #endregion
        #region Eventos de DatePicker

        private void HistorialCompras_Load(object sender, EventArgs e)
        {
            datTimPicFecIni.DropDown += new EventHandler(datTimPicFec_DropDown);
            datTimPicFecIni.CloseUp += new EventHandler(datTimPicFec_CloseUp);
            datTimPicFecFin.DropDown += new EventHandler(datTimPicFec_DropDown);
            datTimPicFecFin.CloseUp += new EventHandler(datTimPicFec_CloseUp);
        }

        //called when calendar drops down
        private void datTimPicFec_DropDown(object sender, EventArgs e)
        {
            _calendarDroppedDown = true;

        }
        //called when calendar closes
        private void datTimPicFec_CloseUp(object sender, EventArgs e)
        {
            _calendarDroppedDown = false;
            RefreshToolbox(null, null); //NOW we want to refresh display
        }

        //This method is called when ValueChanged is fired
        public void RefreshToolbox(object sender, EventArgs e)
        {
            count = 0;
            if (!_calendarDroppedDown) //only refresh the display once user has chosen a date from the calendar, not while they're paging through the days.
            {

                if (datTimPicFecIni.Value > datTimPicFecFin.Value)
                    datTimPicFecIni.Value = datTimPicFecFin.Value;
                LimpiarVentanaCompra();
                CargarCompras(VerCompra, 4, count, "-1", "-1", datTimPicFecIni.Value, datTimPicFecFin.Value);

            }
        }
        #endregion
        private void tabConFac_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Evento que se activa cada vez que se cambia de TabPage 
            //Muestra los productos de la Factura cada vez que se cambia
            LimpiarVentanaFactura();
            CargarProductos(tabConFac.SelectedIndex);
        }

        private void btnVerDesExt_Click(object sender, EventArgs e)
        {
            try
            {//Obtiene el IDProducto y llama a la ventana si es que tiene DescuentoExtra
                Promocion promocion = new Promocion();
                idProd = dgvFullFactura.CurrentRow.Cells[0].Value.ToString();
                descrProd = promocion.ObtenerNombreProducto(idProd);

                new DescuentoExtra(long.Parse(idFact), idProd, descrProd, false).ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo capturar", "¡ADVERTENCIA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GuardarLista()
        {//Se guarda la lista en una lista Auxiliar para despues recuperarla
            auxiliar = datCom;
        }
        private void AsignarLista()
        {//Despues se recuperan la lista de la lista Auxiliar
            foreach (string[] item in auxiliar)
            {
                datCom.Add(item);
            }
            auxiliar.Clear();
        }
        private void DarFormatoTabla()
        {
            //Asigna el estilo de los DataGridView
            foreach (DataGridViewColumn column in dgvFullFactura.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
            dgvDatCom.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDatCom.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);
            dgvDatCom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDatCom.DefaultCellStyle.Font = new Font("Arial", 12);
            dgvFullFactura.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFullFactura.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);
            dgvFullFactura.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFullFactura.Columns[indNomProd].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvFullFactura.DefaultCellStyle.Font = new Font("Arial", 12);
            dgvFullFactura.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvFullFactura.Columns[indInd].Width = 50;
            dgvFullFactura.Columns[indCodBar].Width = 200;
            dgvFullFactura.Columns[indNomProd].Width = 300;
            dgvFullFactura.Columns[indCan].Width = 125;
            dgvFullFactura.Columns[indCosto].Width = 125;
            dgvFullFactura.Columns[indcostoRecibidoSin].Width = 125;
            dgvFullFactura.Columns[indDesc].Width = 125;
            dgvFullFactura.Columns[indListaImpuestos].Width = 125;
            dgvFullFactura.Columns[indIVA].Width = 125;
            dgvFullFactura.Columns[indIEPS].Width = 125;
            dgvFullFactura.Columns[indimporteSin].Width = 125;
            dgvFullFactura.Columns[indimporte].Width = 125;
            dgvFullFactura.Columns[indCosto].Visible = false;
            dgvFullFactura.Columns[indListaImpuestos].Visible = false;
            dgvFullFactura.Columns[indIVA].Visible = false;
            dgvFullFactura.Columns[indIEPS].Visible = false;
            dgvFullFactura.Columns[indimporte].Visible = false;
        }

        #region CheckBox Impuestos
        private void checkCostosImp_CheckedChanged(object sender, EventArgs e)
        {
            //Si estan activos desaparece y muestra las columnas 
            if (checkCostosImp.Checked)
            {
                checkTodosImp.CheckedChanged -= checkTodosImp_CheckedChanged;
                checkTodosImp.Checked = false;
                checkTodosImp.CheckedChanged += checkTodosImp_CheckedChanged;
                dgvFullFactura.Columns[indCosto].Visible = true;
                dgvFullFactura.Columns[indimporte].Visible = true;
                dgvFullFactura.Columns[indcostoRecibidoSin].Visible = false;
                dgvFullFactura.Columns[indimporteSin].Visible = false;
                dgvFullFactura.Columns[indListaImpuestos].Visible = false;
                dgvFullFactura.Columns[indIVA].Visible = false;
                dgvFullFactura.Columns[indIEPS].Visible = false;
            }
            else
            {
                dgvFullFactura.Columns[indcostoRecibidoSin].Visible = true;
                dgvFullFactura.Columns[indimporteSin].Visible = true;
                dgvFullFactura.Columns[indCosto].Visible = false;
                dgvFullFactura.Columns[indimporte].Visible = false;
                dgvFullFactura.Columns[indListaImpuestos].Visible = false;
                dgvFullFactura.Columns[indIVA].Visible = false;
                dgvFullFactura.Columns[indIEPS].Visible = false;
            }

        }

        private void checkTodosImp_CheckedChanged(object sender, EventArgs e)
        {
            //Si estan activos desaparece y muestra las columnas 
            if (checkTodosImp.Checked)
            {
                checkCostosImp.CheckedChanged -= checkCostosImp_CheckedChanged;
                checkCostosImp.Checked = false;
                checkCostosImp.CheckedChanged += checkCostosImp_CheckedChanged;
                dgvFullFactura.Columns[indcostoRecibidoSin].Visible = true;
                dgvFullFactura.Columns[indimporteSin].Visible = true;
                dgvFullFactura.Columns[indCosto].Visible = true;
                dgvFullFactura.Columns[indListaImpuestos].Visible = true;
                dgvFullFactura.Columns[indIVA].Visible = true;
                dgvFullFactura.Columns[indIEPS].Visible = true;
                dgvFullFactura.Columns[indimporte].Visible = true;
            }
            else
            {
                dgvFullFactura.Columns[indcostoRecibidoSin].Visible = true;
                dgvFullFactura.Columns[indimporteSin].Visible = true;
                dgvFullFactura.Columns[indCosto].Visible = false;
                dgvFullFactura.Columns[indListaImpuestos].Visible = false;
                dgvFullFactura.Columns[indIVA].Visible = false;
                dgvFullFactura.Columns[indIEPS].Visible = false;
                dgvFullFactura.Columns[indimporte].Visible = false;
            }
        }

        #endregion

        //private void checkCostos_CheckedChanged(object sender, EventArgs e)
        //{
        //    habilitadoCellValueChanged = false;
        //    int i = 0;
        //    foreach (DataGridViewRow renglon in dgvFullFactura.Rows)
        //    {
        //        habilitadoCellValueChanged = false;
        //        renglon.Cells[i].Value = string.Format("{0:c}", ordenes.Costo((decimal)renglon.Cells[i].Tag, renglon.Cells[0].Value.ToString()));
        //        renglon.Cells[i].Value = string.Format("{0:c}", ordenes.Costo((decimal)renglon.Cells[i].Tag, renglon.Cells[0].Value.ToString()));
        //        //AplicarDescuentos(renglon.Index);
        //    }
        //    habilitadoCellValueChanged = true;
        //}
    }
}