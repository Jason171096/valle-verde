using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion.Inventario;

using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using Color = MigraDoc.DocumentObjectModel.Color;
using MigraDoc.DocumentObjectModel.Tables;
using Font = MigraDoc.DocumentObjectModel.Font;
using System.Diagnostics;
using Microsoft.Office.Core;
using System.Globalization;
using System.IO;

namespace ValleVerde
{
    public delegate void DelegateActualizarNumeroPiezasInventario(string piezas);
    public partial class ReporteExistencias : Form
    {
        ExportarTablaExcel exp = new ExportarTablaExcel();
        int numeroProductosPorPagina = 100;
        int numeroPagina = 0;
        bool stop = false;
        DataGridView dgvProductos = new DataGridView();
        Thread hiloCargarNumeroPiezas;
        public DelegateActualizarNumeroPiezasInventario DActualizarNumeroPiezasInventario;

        public ReporteExistencias()
        {
            InitializeComponent();
            dgvProductos.Size = new Size(panel1.Width - 5, panel1.Height - 5);
            panel1.Controls.Add(dgvProductos);

            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvProductos, true, false);
            

            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvProductos.Dock = DockStyle.None;
            dgvProductos.ScrollBars = ScrollBars.Both;
            dgvProductos.RowHeadersVisible = false;
            DActualizarNumeroPiezasInventario = new DelegateActualizarNumeroPiezasInventario(ActualizarNumeroPiezasInventario);
            this.FormClosing += Form_Closing;
        }

        private void ReporteExistencias_Load(object sender, EventArgs e)
        {
            tabControlExistencias.Appearance = TabAppearance.FlatButtons;
            tabControlExistencias.ItemSize = new Size(0, 1);
            tabControlExistencias.SizeMode = TabSizeMode.Fixed;


            //Cargar costo de inventario y productos en el inventario
            Programacion.Inventario.Inventario obi = new Programacion.Inventario.Inventario();

            CargarTotales();

            
            //Cargar listas desplegables
            CargarListaFabricantes();
            CargarListaMarcas();
            CargarListaLineas();
            CargarListaProveedores();
            CargarListaAlmacenes();

            CargarProductos(true, "");
            dgvProductos.Columns[0].Width = 160;

            chkMarca.CheckedChanged += new EventHandler(chkChecado);
            chkLinea.CheckedChanged += new EventHandler(chkChecado);
            chkFabricante.CheckedChanged += new EventHandler(chkChecado);
            chkProveedor.CheckedChanged += new EventHandler(chkChecado);
            chkAlmacen.CheckedChanged += new EventHandler(chkChecado);

            cbMarca.DropDownWidth = 500;
            cbLinea.DropDownWidth = 500;
            cbFabricante.DropDownWidth = 500;
            cbProveedor.DropDownWidth = 500;
            cbMarca.DropDownWidth = 200;


            txtBuscar.Select();

            dgvProductos.Scroll += new ScrollEventHandler(ScrollEvent_CargarMasProductos);
        }

        private void Form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (hiloCargarNumeroPiezas != null)
            {
                hiloCargarNumeroPiezas.Abort();
            }
        }

        private void ScrollEvent_CargarMasProductos(object sender, ScrollEventArgs scrollEventArgs)
        {
            if (dgvProductos.DisplayedRowCount(false) + dgvProductos.FirstDisplayedScrollingRowIndex >= dgvProductos.RowCount && stop == false)
            {
                // at bottom
                int x = dgvProductos.VerticalScrollingOffset;
                numeroPagina++;
                CargarProductos(false, txtBuscar.Text);
                stop = true;
                dgvProductos.AutoScrollOffset = new Point(x ,0);

            }
            else
            {
                // not at bottom
                stop = false;
            }
        }

        private void chkChecado(object sender, EventArgs e)
        {
            chkTodo.Checked = false;
            CargarProductos(true, txtBuscar.Text);
        }

        public void ActualizarNumeroPiezasInventario(string piezas)
        {
            lblPiezasInventario.Text = string.Format("{0:N}", Convert.ToDecimal(piezas ));
        }

        private void CargarListaFabricantes()
        {
            Programacion.Fabricantes ob = new Programacion.Fabricantes();

            List<String[]> res = ob.ObtenerFabricantes();

            cbFabricante.DisplayMember = "Text";
            cbFabricante.ValueMember = "Value";

            List<Object> items = new List<Object>();

            foreach (String[] fabricante in res)
            {
                items.Add(new { Text = fabricante[1], Value = fabricante[0] });
               
            }

            cbFabricante.DataSource = items;
        }

        private void CargarListaMarcas()
        {
            Programacion.Marcas ob = new Programacion.Marcas();

            List<String[]> res = ob.ObtenerMarcas();

            cbMarca.DisplayMember = "Text";
            cbMarca.ValueMember = "Value";

            List<Object> items = new List<Object>();

            foreach (String[] marca in res)
            {
                items.Add(new { Text = marca[1], Value = marca[0] });
            }

            cbMarca.DataSource = items;
        }

        private void CargarListaLineas()
        {
            Programacion.Lineas ob = new Programacion.Lineas();

            List<String[]> res = ob.ObtenerLineas();

            cbLinea.DisplayMember = "Text";
            cbLinea.ValueMember = "Value";

            List<Object> items = new List<Object>();


            foreach (String[] linea in res)
            {
                items.Add(new { Text = linea[1], Value = linea[0] });
            }

            cbLinea.DataSource = items;
        }

        private void CargarListaAlmacenes()
        {
            Programacion.Almacenes ob = new Programacion.Almacenes();

            List<String[]> res = ob.ObtenerAlmacenes();

            cbAlmacen.DisplayMember = "Text";
            cbAlmacen.ValueMember = "Value";

            List<Object> items = new List<Object>();

            foreach (String[] unidad in res)
            {
                items.Add(new { Text = unidad[1], Value = unidad[0] });
            }

            cbAlmacen.DataSource = items;
        }

        private void CargarListaProveedores()
        {
            Programacion.Proveedor ob = new Programacion.Proveedor();

            List<String[]> res = ob.ObtenerProveedores();

            cbProveedor.DisplayMember = "Text";
            cbProveedor.ValueMember = "Value";

            List<Object> items = new List<Object>();

            foreach (String[] unidad in res)
            {
                items.Add(new { Text = unidad[1], Value = unidad[0] });
            }

            cbProveedor.DataSource = items;
        }

        private void CargarProductos(bool limpiar, string buscar)
        {
            if (dgvProductos.Columns.Count > 0 && limpiar)
                dgvProductos.Columns.Clear();
            if(dgvProductos.Rows.Count> 0 && limpiar)
                dgvProductos.Rows.Clear();

            ValleVerdeComun.Programacion.Producto ob = new ValleVerdeComun.Programacion.Producto();
            Existencias abc = new Existencias();

            int marca=-1, linea=-1, fabricante=-1, proveedor=-1, almacen=-1;

            if (chkMarca.Checked)
                marca = int.Parse(cbMarca.SelectedValue + "");

            if (chkLinea.Checked)
                linea = int.Parse(cbLinea.SelectedValue + "");

            if (chkFabricante.Checked)
                fabricante = int.Parse(cbFabricante.SelectedValue + "");

            if (chkProveedor.Checked)
                proveedor = int.Parse(cbProveedor.SelectedValue + "");

            if (chkAlmacen.Checked)
                almacen = int.Parse(cbAlmacen.SelectedValue + "");

            if (limpiar) 
            {
                tabla();
            }

            //List<String[]> res = ob.ObtenerProductos(marca,linea,fabricante,proveedor,almacen,true,numeroProductosPorPagina,numeroPagina,buscar);
            List<String[]> res = abc.ObtenerInformacionCompletaProductos(marca, linea, fabricante, proveedor, almacen, true, numeroProductosPorPagina, numeroPagina, buscar);

            //Si no son todos entonces calcular costo de inventario y cantidad de productos
            decimal costo = 0, cantidadProductos = 0, cantidadPiezas = 0;

            
            foreach (String[] producto in res)
            {
                decimal precio1 = 0, precio2 = 0, precio3 = 0, precio4 = 0, precio5 = 0;
                string p1 = "", p2 = "", p3 = "", p4 = "", p5 = "";
                string pide = "", bloq = "", noInv="";
                decimal existProd = decimal.Parse(producto[17]);
                decimal precio = decimal.Parse(producto[2]);
                if (producto[4] != "")
                {
                    precio1 = decimal.Parse(producto[4]);
                    p1 = string.Format("{0:C}", precio1);
                }
                if (producto[7] != "")
                {
                    precio2 = decimal.Parse(producto[7]);
                    p2 = string.Format("{0:C}", precio2);
                }
                if (producto[10] != "")
                {
                    precio3 = decimal.Parse(producto[10]);
                    p3 = string.Format("{0:C}", precio3);
                }
                if (producto[13] != "")
                {
                    precio4 = decimal.Parse(producto[13]);
                    p4 = string.Format("{0:C}", precio4);
                }
                if (producto[16] != "")
                {
                    precio5 = decimal.Parse(producto[16]);
                    p5 = string.Format("{0:C}", precio5);
                }

                if (producto[24] == "False")
                {
                    pide = "0";
                }
                else
                {
                    pide = "1";
                }

                if (producto[25] == "False")
                {
                    bloq = "0";
                }
                else
                {
                    bloq = "1";
                }

                if (producto[26] == "False")
                {
                    noInv = "0";
                }
                else
                {
                    noInv = "1";
                }

                if (chkUtilidadPrecio.Checked)
                {
                    string claveAdicional="";
                    List<String[]> claveA = abc.ObtenerClavesAdicionales(producto[0]);
                    if (claveA.Count <= 0)
                    {
                        claveAdicional = "";
                    }
                    if (precio == -2)
                    {
                        dgvProductos.Rows.Add(new string[] { producto[0] + "", claveAdicional,"","","", producto[1] + "", string.Format("{0:C}", "Sin precio"), producto[3], p1, producto[5], producto[6], p2, producto[8], producto[9], p3, producto[11], producto[12], p4, producto[14], producto[15], p5, existProd + "", producto[18], producto[19], producto[20], producto[21], producto[22], producto[23], pide, bloq, noInv });
                        if (claveA.Count > 0)
                        {
                            for (int a = 0; a < claveA.Count; a++)
                            {
                                dgvProductos.Rows.Add(new string[] { "", claveA[a][0] , claveA[a][1], claveA[a][2], string.Format("{0:C}", (float.Parse(claveA[a][2]) * float.Parse(claveA[a][3]))) });
                            }
                        }
                    }
                    else
                    {
                        dgvProductos.Rows.Add(new string[] { producto[0] + "", claveAdicional,"","","", producto[1] + "", string.Format("{0:C}", precio), producto[3], p1, producto[5], producto[6], p2, producto[8], producto[9], p3, producto[11], producto[12], p4, producto[14], producto[15], p5, existProd + "", producto[18], producto[19], producto[20], producto[21], producto[22], producto[23], pide, bloq, noInv });
                        if (claveA.Count > 0)
                        {
                            for (int a = 0; a < claveA.Count; a++) 
                            {
                                dgvProductos.Rows.Add(new string[] {"", claveA[a][0], claveA[a][1], claveA[a][2], string.Format("{0:C}", (float.Parse(claveA[a][2]) * float.Parse(claveA[a][3])))});
                            }
                        }
                    }

                    if (!chkTodo.Checked || txtBuscar.Text != "")
                    {
                        costo += (decimal.Parse(producto[2]) * existProd);
                        cantidadProductos++;

                        cantidadPiezas += existProd;
                    }
                }
                else
                {
                    if (precio == -2)
                        dgvProductos.Rows.Add(new string[] { producto[0] + "", producto[1] + "", string.Format("{0:C}", "Sin precio"), existProd + "" });
                    else
                        dgvProductos.Rows.Add(new string[] { producto[0] + "", producto[1] + "", string.Format("{0:C}", precio), existProd + "" });
                    if (!chkTodo.Checked || txtBuscar.Text != "")
                    {
                        costo += (decimal.Parse(producto[2]) * existProd);
                        cantidadProductos++;

                        cantidadPiezas += existProd;
                    }
                }
                dgvProductos.ClearSelection();
            }

            if (limpiar)
            {
                tabla();
                if (!chkTodo.Checked || txtBuscar.Text != "")
                {
                    Programacion.Inventario.Inventario obi = new Programacion.Inventario.Inventario();

                    lblCostoInventario.Text = string.Format("{0:C}", Convert.ToDouble(costo));

                    lblProductosInventario.Text = string.Format("{0:N}", Convert.ToDecimal(cantidadProductos));
                    lblProductosInventario.Text = lblProductosInventario.Text.Substring(0, lblProductosInventario.Text.Length-3);
                    lblPiezasInventario.Text = string.Format("{0:N}", Convert.ToDecimal(cantidadPiezas));
                }
            }

            //String s = txtBuscar.Text;
            //txtBuscar.Text = "";
            //txtBuscar.Text = s;
            dgvProductos.ClearSelection();
        }

        private void tabla()
        {
            if (chkUtilidadPrecio.Checked)
            {
                numeroPagina = 0;
                dgvProductos.ColumnCount = 31;
                dgvProductos.Columns[0].Name = "codigo";
                dgvProductos.Columns[0].HeaderText = "Codigo";
                dgvProductos.Columns[0].Visible = true;
                dgvProductos.Columns[0].Frozen = false;
                dgvProductos.Columns[0].Width = 160;

                dgvProductos.Columns[1].Name = "claveAdicional";
                dgvProductos.Columns[1].HeaderText = "Clave Adicional";
                dgvProductos.Columns[1].Visible = true;
                dgvProductos.Columns[1].Frozen = false;
                dgvProductos.Columns[1].Width = 160;

                dgvProductos.Columns[2].Name = "nombreAdicional";
                dgvProductos.Columns[2].HeaderText = "Desc. Clv Adicional";
                dgvProductos.Columns[2].Visible = true;
                dgvProductos.Columns[2].Frozen = false;
                dgvProductos.Columns[2].Width = 160;

                dgvProductos.Columns[3].Name = "piezas";
                dgvProductos.Columns[3].HeaderText = "Piezas Adicional";
                dgvProductos.Columns[3].Visible = true;
                dgvProductos.Columns[3].Frozen = false;
                dgvProductos.Columns[3].Width = 160;

                dgvProductos.Columns[4].Name = "precioCaja";
                dgvProductos.Columns[4].HeaderText = "Precio Clv Adicional";
                dgvProductos.Columns[4].Visible = true;
                dgvProductos.Columns[4].Frozen = false;
                dgvProductos.Columns[4].Width = 140;

                dgvProductos.Columns[5].Name = "nombre";
                dgvProductos.Columns[5].HeaderText = "Nombre";
                dgvProductos.Columns[5].Visible = true;
                dgvProductos.Columns[5].Frozen = false;
                dgvProductos.Columns[5].Width = 450;

                dgvProductos.Columns[6].Name = "costo";
                dgvProductos.Columns[6].HeaderText = "Precio Costo";
                dgvProductos.Columns[6].Visible = true;
                dgvProductos.Columns[6].Frozen = false;
                dgvProductos.Columns[6].Width = 120;
                dgvProductos.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                
                dgvProductos.Columns[7].Name = "utilidad";
                dgvProductos.Columns[7].HeaderText = "Utilidad";
                dgvProductos.Columns[7].Visible = true;
                dgvProductos.Columns[7].Frozen = false;
                dgvProductos.Columns[7].Width = 80;
                dgvProductos.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvProductos.Columns[8].Name = "precio";
                dgvProductos.Columns[8].HeaderText = "Precio Publico";
                dgvProductos.Columns[8].Visible = true;
                dgvProductos.Columns[8].Frozen = false;
                dgvProductos.Columns[8].Width = 110;
                dgvProductos.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvProductos.Columns[9].Name = "cant2";
                dgvProductos.Columns[9].HeaderText = "Cant 2";
                dgvProductos.Columns[9].Visible = true;
                dgvProductos.Columns[9].Frozen = false;
                dgvProductos.Columns[9].Width = 95;
                dgvProductos.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvProductos.Columns[10].Name = "util2";
                dgvProductos.Columns[10].HeaderText = "Util 2";
                dgvProductos.Columns[10].Visible = true;
                dgvProductos.Columns[10].Frozen = false;
                dgvProductos.Columns[10].Width = 80;
                dgvProductos.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvProductos.Columns[11].Name = "precio2";
                dgvProductos.Columns[11].HeaderText = "Precio 2";
                dgvProductos.Columns[11].Visible = true;
                dgvProductos.Columns[11].Frozen = false;
                dgvProductos.Columns[11].Width = 110;
                dgvProductos.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
                dgvProductos.Columns[12].Name = "cant3";
                dgvProductos.Columns[12].HeaderText = "Cant 3";
                dgvProductos.Columns[12].Visible = true;
                dgvProductos.Columns[12].Frozen = false;
                dgvProductos.Columns[12].Width = 95;
                dgvProductos.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvProductos.Columns[13].Name = "util3";
                dgvProductos.Columns[13].HeaderText = "Util 3";
                dgvProductos.Columns[13].Visible = true;
                dgvProductos.Columns[13].Frozen = false;
                dgvProductos.Columns[13].Width = 80;
                dgvProductos.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
           
                dgvProductos.Columns[14].Name = "precio3";
                dgvProductos.Columns[14].HeaderText = "Precio 3";
                dgvProductos.Columns[14].Visible = true;
                dgvProductos.Columns[14].Frozen = false;
                dgvProductos.Columns[14].Width = 110;
                dgvProductos.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvProductos.Columns[15].Name = "cant4";
                dgvProductos.Columns[15].HeaderText = "Cant 4";
                dgvProductos.Columns[15].Visible = true;
                dgvProductos.Columns[15].Frozen = false;
                dgvProductos.Columns[15].Width = 95;
                dgvProductos.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvProductos.Columns[16].Name = "util4";
                dgvProductos.Columns[16].HeaderText = "Util 4";
                dgvProductos.Columns[16].Visible = true;
                dgvProductos.Columns[16].Frozen = false;
                dgvProductos.Columns[16].Width = 80;
                dgvProductos.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                
                dgvProductos.Columns[17].Name = "precio4";
                dgvProductos.Columns[17].HeaderText = "Precio 4";
                dgvProductos.Columns[17].Visible = true;
                dgvProductos.Columns[17].Frozen = false;
                dgvProductos.Columns[17].Width = 110;
                dgvProductos.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvProductos.Columns[18].Name = "cant5";
                dgvProductos.Columns[18].HeaderText = "Cant 5";
                dgvProductos.Columns[18].Visible = true;
                dgvProductos.Columns[18].Frozen = false;
                dgvProductos.Columns[18].Width = 95;
                dgvProductos.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvProductos.Columns[19].Name = "util5";
                dgvProductos.Columns[19].HeaderText = "Util 5";
                dgvProductos.Columns[19].Visible = true;
                dgvProductos.Columns[19].Frozen = false;
                dgvProductos.Columns[19].Width = 80;
                dgvProductos.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
                dgvProductos.Columns[20].Name = "precio5";
                dgvProductos.Columns[20].HeaderText = "Precio 5";
                dgvProductos.Columns[20].Visible = true;
                dgvProductos.Columns[20].Frozen = false;
                dgvProductos.Columns[20].Width = 110;
                dgvProductos.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvProductos.Columns[21].Name = "existencia";
                dgvProductos.Columns[21].HeaderText = "Existencia";
                dgvProductos.Columns[21].Visible = true;
                dgvProductos.Columns[21].Frozen = false;
                dgvProductos.Columns[21].Width = 120;
                dgvProductos.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvProductos.Columns[22].Name = "iva";
                dgvProductos.Columns[22].HeaderText = "IVA";
                dgvProductos.Columns[22].Visible = true;
                dgvProductos.Columns[22].Frozen = false;
                dgvProductos.Columns[22].Width = 80;
                dgvProductos.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvProductos.Columns[23].Name = "ieps";
                dgvProductos.Columns[23].HeaderText = "IEPS";
                dgvProductos.Columns[23].Visible = true;
                dgvProductos.Columns[23].Frozen = false;
                dgvProductos.Columns[23].Width = 80;
                dgvProductos.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
                dgvProductos.Columns[24].Name = "marca";
                dgvProductos.Columns[24].HeaderText = "Marca";
                dgvProductos.Columns[24].Visible = true;
                dgvProductos.Columns[24].Frozen = false;
                dgvProductos.Columns[24].Width = 320;

                dgvProductos.Columns[25].Name = "linea";
                dgvProductos.Columns[25].HeaderText = "Linea";
                dgvProductos.Columns[25].Visible = true;
                dgvProductos.Columns[25].Frozen = false;
                dgvProductos.Columns[25].Width = 320;

                dgvProductos.Columns[26].Name = "fabricante";
                dgvProductos.Columns[26].HeaderText = "Fabricante";
                dgvProductos.Columns[26].Visible = true;
                dgvProductos.Columns[26].Frozen = false;
                dgvProductos.Columns[26].Width = 320;
            
                dgvProductos.Columns[27].Name = "unidad";
                dgvProductos.Columns[27].HeaderText = "Unidad";
                dgvProductos.Columns[27].Visible = true;
                dgvProductos.Columns[27].Frozen = false;
                dgvProductos.Columns[27].Width = 80;

                dgvProductos.Columns[28].Name = "piedepeso";
                dgvProductos.Columns[28].HeaderText = "Pide Peso";
                dgvProductos.Columns[28].Visible = true;
                dgvProductos.Columns[28].Frozen = false;
                dgvProductos.Columns[28].Width = 80;
            
                dgvProductos.Columns[29].Name = "bloqueado";
                dgvProductos.Columns[29].HeaderText = "Bloq";
                dgvProductos.Columns[29].Visible = true;
                dgvProductos.Columns[29].Frozen = false;
                dgvProductos.Columns[29].Width = 80;
            
                dgvProductos.Columns[30].Name = "nousainventario";
                dgvProductos.Columns[30].HeaderText = "No Inv";
                dgvProductos.Columns[30].Visible = true;
                dgvProductos.Columns[30].Frozen = false;
                dgvProductos.Columns[30].Width = 80;

                //dgvProductos.Dock = DockStyle.None;
                dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            }
            else
            {
                numeroPagina = 0;
                dgvProductos.ColumnCount = 4;
                dgvProductos.Columns[0].Name = "Codigo";
                dgvProductos.Columns[0].HeaderText = "Codigo";
                dgvProductos.Columns[0].Visible = true;
                dgvProductos.Columns[0].Frozen = false;
                dgvProductos.Columns[0].Width = 170;

                dgvProductos.Columns[1].Name = "nombre";
                dgvProductos.Columns[1].HeaderText = "Nombre";
                dgvProductos.Columns[1].Visible = true;
                dgvProductos.Columns[1].Frozen = false;

                dgvProductos.Columns[2].Name = "costo";
                dgvProductos.Columns[2].HeaderText = "Precio Costo";
                dgvProductos.Columns[2].Visible = true;
                dgvProductos.Columns[2].Frozen = false;
                dgvProductos.Columns[2].Width = 120;
                dgvProductos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


                dgvProductos.Columns[3].Name = "existencia";
                dgvProductos.Columns[3].HeaderText = "Existencia";
                dgvProductos.Columns[3].Visible = true;
                dgvProductos.Columns[3].Frozen = false;
                dgvProductos.Columns[3].Width = 140;
                dgvProductos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvProductos.Dock = DockStyle.Fill;
                dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void chkTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodo.Checked)
            {
                chkMarca.CheckedChanged -= new EventHandler(chkChecado);
                chkLinea.CheckedChanged -= new EventHandler(chkChecado);
                chkFabricante.CheckedChanged -= new EventHandler(chkChecado);
                chkProveedor.CheckedChanged -= new EventHandler(chkChecado);
                chkAlmacen.CheckedChanged -= new EventHandler(chkChecado);

                chkMarca.Checked = false;
                chkLinea.Checked = false;
                chkFabricante.Checked = false;
                chkProveedor.Checked = false;
                chkAlmacen.Checked = false;

                chkMarca.CheckedChanged += new EventHandler(chkChecado);
                chkLinea.CheckedChanged += new EventHandler(chkChecado);
                chkFabricante.CheckedChanged += new EventHandler(chkChecado);
                chkProveedor.CheckedChanged += new EventHandler(chkChecado);
                chkAlmacen.CheckedChanged += new EventHandler(chkChecado);

                
                CargarTotales();



            }
            else
            {
                if(chkMarca.Checked==false && chkLinea.Checked==false && chkFabricante.Checked==false && chkProveedor.Checked == false && chkAlmacen.Checked == false)
                    chkAlmacen.Checked = true;
            }

            CargarProductos(true, txtBuscar.Text);


        }

        private void CargarTotales()
        {
            Programacion.Inventario.Inventario obi = new Programacion.Inventario.Inventario();

            lblCostoInventario.Text = string.Format("{0:C}", Convert.ToDouble(obi.ObtenerCostoInventario() + ""));
            lblProductosInventario.Text = string.Format("{0:N}", Convert.ToDecimal(obi.ObtenerNumeroProductosInventario() + ""));
            lblProductosInventario.Text = lblProductosInventario.Text.Substring(0, lblProductosInventario.Text.Length - 3);

            //Cargar asincrono

            hiloCargarNumeroPiezas = new Thread(() => CargarNumeroPiezas(this, obi));
            hiloCargarNumeroPiezas.Start();
        }

        private void CargarNumeroPiezas(ReporteExistencias r, Programacion.Inventario.Inventario obi)
        {
            if (!r.IsDisposed)
                r.Invoke(DActualizarNumeroPiezasInventario, new object[] { obi.ObtenerNumeroPiezasInventario() + "" });
        }
        
        private void cbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(chkMarca.Checked)
                CargarProductos(true, txtBuscar.Text);
        }

        private void cbLinea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkLinea.Checked)
                CargarProductos(true, txtBuscar.Text);
        }

        private void cbFabricante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkFabricante.Checked)
                CargarProductos(true, txtBuscar.Text);
        }

        private void cbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkProveedor.Checked)
                CargarProductos(true, txtBuscar.Text);
        }

        private void cbAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkAlmacen.Checked)
                CargarProductos(true, txtBuscar.Text);
        }

        private void chkFabricante_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                new AltaProducto(false, dgvProductos.SelectedRows[0].Cells[0].Value + "",false).Show();
            }
        }

        private async void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    var dt = (DataTable)dgvProductos.DataSource;
            //    dt.DefaultView.RowFilter = "Nombre LIKE '%" + txtBuscar.Text + "%'";
            //    dgvProductos.Refresh();
            //}
            //catch(Exception error)
            //{
            //    MessageBox.Show("Error: "+error.Message);
            //}
            async Task<bool> UserKeepsTyping()
            {
                string txt = txtBuscar.Text;   // remember text
                await Task.Delay(500);        // wait some
                return txt != txtBuscar.Text;  // return that text chaged or not
            }
            if (await UserKeepsTyping()) return;
            // user is done typing, do your stuff    
            CargarProductos(true, txtBuscar.Text);

        }

        private void chkMarca_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkLinea_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void exportarExcel_Click(object sender, EventArgs e)
        {
            numeroPagina = -1;
            numeroProductosPorPagina = -1;
            CargarProductos(true, txtBuscar.Text);
            exp.GenerarExcel(dgvProductos, 1, 2);
        }

        private void chkUtilidadPrecio_CheckedChanged(object sender, EventArgs e)
        {
            CargarProductos(true, txtBuscar.Text);
        }

        private void buttonPDF_Click(object sender, EventArgs e)
        {
            numeroPagina = -1;
            numeroProductosPorPagina = -1;
            CargarProductos(true, txtBuscar.Text);

            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "PDF (*.pdf)|*.pdf";
                fichero.FileName = "InformacionProductos_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    // Create a MigraDoc document
                    Document document = CreateDocument();
                    document.UseCmykColor = true;

                    // ===== Unicode encoding and font program embedding in MigraDoc is demonstrated here =====

                    const bool unicode = false;

                    // Create a renderer for the MigraDoc document.
                    PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(unicode);

                    // Associate the MigraDoc document with a renderer
                    pdfRenderer.Document = document;

                    // Layout and render document to PDF
                    pdfRenderer.RenderDocument();

                    // Save the document...            
                    pdfRenderer.PdfDocument.Save(fichero.FileName);

                    // ...and start a viewer.
                    Process.Start(fichero.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar la informacion debido a: " + ex.ToString());
            }
        }

        public Document CreateDocument()
        {
            Document document = new Document();

            string fecha = DateTime.Now.ToString("dddd, dd/MM/yyyy HH:mm:ss");
            fecha = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(fecha);

            // Crear fuentes
            Font fueTit = new Font("Verdana", 18);
            fueTit.Bold = true;
            Font fueDoc = new Font("Verdana", 10);
            fueDoc.Bold = true;
            Font fueTab = new Font("Arial", 10);

            // Add a section to the document
            Section secCom = document.AddSection();
            // MessageBox.Show(secCom.PageSetup.PageFormat.ToString()); // = PageFormat.A4;
            secCom.PageSetup.PageFormat = PageFormat.Letter;
            secCom.PageSetup.TopMargin = 10;
            secCom.PageSetup.LeftMargin = 12;
            secCom.PageSetup.RightMargin = 0;
            secCom.PageSetup.BottomMargin = 50;


            // Añadir elementos a la seccion
            //string img = System.IO.Directory.GetCurrentDirectory();
            //System.Drawing.Image img = global::ValleVerde.Properties.Resources.LOGO;
            //img.Save();

            //string img = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Resources\\LOGO.png");
            //global::ValleVerde.Properties.Resources.LOGO);
            //System.Drawing.Image im = global::ValleVerde.Properties.Resources.LOGO;
            //MigraDoc.DocumentObjectModel.Shapes.Image image = secCom.AddImage("../../../Resources/LOGO.png");
            byte[] image1 = LoadImage("global::ValleVerde.Properties.Resources.LOGO.png");
            string imageFilename = MigraDocFilenameFromByteArray(image1);

            MigraDoc.DocumentObjectModel.Shapes.Image image = secCom.AddImage(imageFilename);
            image.Width = "4 cm";
            image.LockAspectRatio = true;
            
            Table tabDat = secCom.AddTable();

            secCom.AddParagraph();
            Table tab = secCom.AddTable();

            secCom.AddParagraph();
            Table foo = new Table();
            foo.AddColumn();
            foo.AddColumn();
            foo.AddRow();
            foo.Columns[0].Format.Alignment = ParagraphAlignment.Left;
            foo.Columns[1].Format.Alignment = ParagraphAlignment.Right;

            foo.Columns[0].Width = 472;
            foo.Columns[1].Width = 100;
            foo.Rows[0].Cells[0].AddParagraph("\tFecha: " + fecha);
            foo.Rows[0].Cells[1].AddParagraph().AddPageField();
            secCom.Footers.Primary.Add(foo.Clone());
            
            tabDat.AddColumn();
            tabDat.AddColumn();
            tabDat.AddRow();
            tabDat.AddRow();
            tabDat.AddRow();
            tabDat.Format.Font = fueDoc;

            tabDat.Columns[0].Width = 286;
            tabDat.Columns[1].Width = 286;
 
            tabDat.Columns[0].Format.Alignment = ParagraphAlignment.Left;
            tabDat.Columns[1].Format.Alignment = ParagraphAlignment.Left;
            tabDat.Rows[0].Cells[0].AddParagraph("\tCosto del Inventario: \n\t" + string.Format("{0:C}", lblCostoInventario.Text));
            tabDat.Rows[0].Cells[1].AddParagraph("Fecha: " + fecha);
            tabDat.Rows[2].Cells[0].AddParagraph("\tProductos en inventario: \n\t" + lblProductosInventario.Text);
            tabDat.Rows[2].Cells[1].AddParagraph("Piezas en el inventario: \n" + lblPiezasInventario.Text);
            tabDat.Format.Alignment = ParagraphAlignment.Center;


            for (int a = 0; a < dgvProductos.ColumnCount; a++)
            {
                tab.AddColumn();
            }

            Row row = tab.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Shading.Color = Colors.PaleGreen;
            tab.Format.Font = fueTab;

            if (dgvProductos.ColumnCount == 4) 
            {
                tab.Columns[0].Width = 110;
                tab.Columns[1].Width = 360;
                tab.Columns[2].Width = 0;
                tab.Columns[3].Width = 110;
            }
            else
            {
                tab.Columns[0].Width = 80;
                tab.Columns[1].Width = 80;
                tab.Columns[2].Width = 60;
                tab.Columns[2].Format.Alignment = ParagraphAlignment.Center;
                tab.Columns[3].Width = 0;
                tab.Columns[4].Width = 60;
                tab.Columns[4].Format.Alignment = ParagraphAlignment.Right;
                tab.Columns[5].Width = 130;
                tab.Columns[5].Format.Alignment = ParagraphAlignment.Center;
                tab.Columns[6].Width = 60;
                tab.Columns[6].Format.Alignment = ParagraphAlignment.Right;
                tab.Columns[7].Width = 0;

                tab.Columns[8].Width = 60;
                tab.Columns[8].Format.Alignment = ParagraphAlignment.Right;

                tab.Columns[9].Width = 0;
                tab.Columns[10].Width = 0;
                tab.Columns[11].Width = 0;
                tab.Columns[12].Width = 0;
                tab.Columns[13].Width = 0;
                tab.Columns[14].Width = 0;
                tab.Columns[15].Width = 0;
                tab.Columns[16].Width = 0;
                tab.Columns[17].Width = 0;
                tab.Columns[18].Width = 0;
                tab.Columns[19].Width = 0;
                tab.Columns[20].Width = 0;

                tab.Columns[21].Width = 60;
                tab.Columns[21].Format.Alignment = ParagraphAlignment.Right;

                tab.Columns[22].Width = 0;
                tab.Columns[23].Width = 0;
                tab.Columns[24].Width = 0;
                tab.Columns[25].Width = 0;
                tab.Columns[26].Width = 0;
                tab.Columns[27].Width = 0;
                tab.Columns[28].Width = 0;
                tab.Columns[29].Width = 0;
                tab.Columns[30].Width = 0;
            }


            for (int b = 0; b < dgvProductos.ColumnCount; b++)
            {
                if(dgvProductos.ColumnCount == 4 && b != 2)
                    row.Cells[b].AddParagraph(dgvProductos.Columns[b].HeaderText);

                if (dgvProductos.ColumnCount == 31)
                {
                    if(b == 0 || b == 1 || b == 2|| b == 4 || b == 5 || b == 6 || b == 8 || b == 21)
                    {
                        row.Cells[b].AddParagraph(dgvProductos.Columns[b].HeaderText);
                    }                        
                }                    
            }

            tab.Borders.Color = Colors.Black;
            tab.Borders.Width = 0.25;
            tab.Rows.VerticalAlignment = VerticalAlignment.Center;

            for (int i = 0; i < dgvProductos.RowCount; i++)
            {
                tab.AddRow();
                for (int j = 0; j < dgvProductos.ColumnCount; j++) 
                {
                    if (dgvProductos.Rows[i].Cells[j].Value != null)
                    {
                        if (dgvProductos.ColumnCount == 4 && j != 2)
                            tab.Rows[i + 1].Cells[j].AddParagraph(dgvProductos.Rows[i].Cells[j].Value.ToString());

                        if (dgvProductos.ColumnCount == 31)
                        {
                            if (j == 0 || j == 1 || j == 2 || j == 4 || j == 5 || j == 6 || j == 8 || j == 21)
                            {
                                tab.Rows[i + 1].Cells[j].AddParagraph(dgvProductos.Rows[i].Cells[j].Value.ToString());
                            }
                        }

                    }
                }
            }

            return document;
        }

        static string MigraDocFilenameFromByteArray(byte[] image)
        {
            return "base64:" + Convert.ToBase64String(image);
        }

    static byte[] LoadImage(string name)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(name))
            {
            if (stream == null)
            throw new ArgumentException("No resource with name " + name);
            int count = (int)stream.Length;
            byte[] data = new byte[count];
            stream.Read(data, 0, count);
            return data;
            }
        }
    
    }
}
