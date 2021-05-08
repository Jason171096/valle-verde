using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerdeComun
{
    public partial class BuscarProducto : Form
    {

        ImagenProductoFlotante imagen;
        public TextBox txtCodigo;
        Button btnPulsarOK;
         bool img = false;
        DataTable table;
        int numeroProductosPorPagina = 50;
        int numeroPagina = 0;
        bool cargandoProductos = false;
        bool stop = false;
        bool soloClavesAdicionales;


        public BuscarProducto(TextBox txtC,Button btnOk,bool soloClavesAdicionales)
        {
            InitializeComponent();
            txtCodigo = txtC;
            if(txtC!=null)
                txtBuscar.Text = txtC.Text;
            btnPulsarOK = btnOk;
            this.soloClavesAdicionales = soloClavesAdicionales;
            txtBuscar.KeyDown += new KeyEventHandler(tb_KeyDown);
            dvgProductos.KeyDown += new KeyEventHandler(tb_KeyDown2);
            Shown += Form1_Shown;
        }

        private void BuscarProducto_Load(object sender, EventArgs e)
        {

            if (soloClavesAdicionales)
                lblTitulo.Text = "Buscando por Clave Adicional";
            else
                lblTitulo.Text = "Buscando por Producto";

            imagen = new ImagenProductoFlotante(this.DesktopLocation.X - 150, this.DesktopLocation.Y, this.Width, this.Height);
            imagen.Owner = this;

            //Cargar listas desplegables
            CargarListaFabricantes();
            CargarListaMarcas();
            CargarListaLineas();
            CargarListaProveedores();

            CargarProductos(true, "");
            cbMarca.DropDownWidth = 500;
            cbLinea.DropDownWidth = 500;
            cbFabricante.DropDownWidth = 500;
            cbProveedor.DropDownWidth = 500;

            chkMarca.CheckedChanged += new EventHandler(chkChecado);
            chkLinea.CheckedChanged += new EventHandler(chkChecado);
            chkFabricante.CheckedChanged += new EventHandler(chkChecado);
            chkProveedor.CheckedChanged += new EventHandler(chkChecado);




            this.Location = new Point(this.Location.X - 150, this.Location.Y); ;

            txtBuscar.Focus();
            txtBuscar.Select();

            dvgProductos.Scroll += new ScrollEventHandler(ScrollEvent_CargarMasProductos);
        }


        private void Form1_Shown(object sender, EventArgs e)
        {
            if (txtCodigo != null)
            {
                txtCodigo.Text = "";
                txtCodigo.SelectAll();
            }
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                btnAceptar.PerformClick();
            } else
            if (e.KeyCode == Keys.Up)
            {
                if (dvgProductos.SelectedRows.Count > 0)
                {
                    int index = dvgProductos.SelectedRows[0].Index;
                    if (index > 0)
                        dvgProductos.Rows[index - 1].Selected = true;
                    dvgProductos.CurrentCell = dvgProductos.SelectedRows[0].Cells[0];
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else
            {
                if (e.KeyCode == Keys.Down)
                {
                    if (dvgProductos.SelectedRows.Count > 0)
                    {
                        int index = dvgProductos.SelectedRows[0].Index;
                        if (index < dvgProductos.Rows.Count - 1)
                            dvgProductos.Rows[index + 1].Selected = true;
                        dvgProductos.CurrentCell = dvgProductos.SelectedRows[0].Cells[0];
                    }
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
                   
            
        }

        private void tb_KeyDown2(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cargandoProductos == false)
            {

                btnAceptar.PerformClick();
            }

        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            this.Close();

            

           
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            if (!cargandoProductos && dvgProductos.SelectedRows.Count > 0)
            {
                if (txtCodigo != null)
                    txtCodigo.Text = dvgProductos.SelectedRows[0].Cells[0].Value + "";
                if (btnPulsarOK != null)
                    btnPulsarOK.PerformClick();
                imagen.Dispose();
                this.Dispose();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dvgProductos.SelectedRows.Count > 0)
            {
                if (img == false)
                {
                    imagen.Show();
                    img = true;
                }

                /*if (imagen != null)
                {
                    imagen.BringToFront();
                    this.BringToFront();
                    this.ActiveControl = txtBuscar;

                }*/

                //cambiar la imagen si el producto tiene
                // MessageBox.Show("Mostrando la imagen para " + dvgProductos.SelectedRows[0].Cells[0].Value);

                Programacion.Producto obj = new Programacion.Producto();
                List<Image> r = obj.ObtenerImagenesProducto(dvgProductos.SelectedRows[0].Cells[0].Value + "");

                if (r.Count > 0)
                {
                    //string ruta = r[0];

                    try
                    {
                        //Image img = Image.FromFile(ruta);
                        imagen.setImage(r[0]);
                    }
                    catch {
                        imagen.setImage(null);
                    }


                }
                else
                    imagen.setImage(null);
            }
        }

       
        private void chkChecado(object sender, EventArgs e)
        {
            chkTodo.Checked = false;

            CargarProductos(true, txtBuscar.Text);
        }

        private void ScrollEvent_CargarMasProductos(object sender,ScrollEventArgs scrollEventArgs)
        {
            if (dvgProductos.DisplayedRowCount(false) + dvgProductos.FirstDisplayedScrollingRowIndex >= dvgProductos.RowCount && stop == false)
            {
                // at bottom
                numeroPagina++;
                CargarProductos(false,txtBuscar.Text);
                stop = true;
            }
            else
            {
                // not at bottom
                stop = false;
            }
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


        private void CargarProductos(bool limpiar,string buscar)
        {
            cargandoProductos = true;
            if (dvgProductos.Columns.Count > 0 && limpiar)
                dvgProductos.Columns.Clear();
            if (dvgProductos.Rows.Count > 0 && limpiar)
                dvgProductos.Rows.Clear();

            Programacion.Producto ob = new Programacion.Producto();

            int marca = -1, linea = -1, fabricante = -1, proveedor = -1, almacen = -1;

            if (chkMarca.Checked)
                marca = int.Parse(cbMarca.SelectedValue + "");

            if (chkLinea.Checked)
                linea = int.Parse(cbLinea.SelectedValue + "");

            if (chkFabricante.Checked)
                fabricante = int.Parse(cbFabricante.SelectedValue + "");

            if (chkProveedor.Checked)
                proveedor = int.Parse(cbProveedor.SelectedValue + "");

           

            
            if (limpiar)
            {
                numeroPagina = 0;
                table = new DataTable();
                table.Columns.Add("Codigo");
                table.Columns.Add("Nombre");
                table.Columns.Add("Precio");
                table.Columns.Add("Piezas");
                table.Columns.Add("Existencia Total");
            }

            List<String[]> res = ob.ObtenerProductos(marca, linea, fabricante, proveedor, almacen, false, numeroProductosPorPagina, numeroPagina, buscar, soloClavesAdicionales);

            foreach (String[] producto in res)
            {
                decimal precio = decimal.Parse(producto[2]);//decimal.Parse(new Programacion.Precios().ObtenerPrecioProducto(producto[0], 1,-1,-1)+"");
                decimal existencia = decimal.Parse(producto[3]);

                string c = "";
                if (existencia % 1 == 0)
                    c = decimal.ToInt32(existencia) + "";
                else
                    c = existencia.ToString("0.##");


                if (precio == -2)
                    table.Rows.Add(new string[] { producto[0] + "", producto[1] + "", "Sin Precio", producto[4] + "", c});//ob.ObtenerExistenciaTotalProducto(producto[0] + "") + "" });
                else
                    table.Rows.Add(new string[] { producto[0] + "", producto[1] + "", string.Format("{0:C}", precio), producto[4] + "", c}); //ob.ObtenerExistenciaTotalProducto(producto[0] + "") + "" });


                
                        
                
            }

            if (limpiar)
            {
                dvgProductos.DataSource = table;
                //Configurar columnas

                //generales de la tabla
                new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dvgProductos, true, false, 15, 15);

                //codigo
                dvgProductos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dvgProductos.Columns[0].Width = 170;
                dvgProductos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dvgProductos.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                //Precio
                dvgProductos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dvgProductos.Columns[2].Width = 120;
                dvgProductos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //Piezas
                dvgProductos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dvgProductos.Columns[3].Width = 70;
                dvgProductos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //Existencia
                dvgProductos.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dvgProductos.Columns[4].Width = 100;
                dvgProductos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                if (!soloClavesAdicionales)
                    dvgProductos.Columns[3].Visible = false;

                //Checar si se parecen entre ellos
                int i = 0;
               
                Color c1 = Color.Orange;
                Color c2 = Color.FromArgb(245, 227, 66);
                bool colorUsado = true;
                Color c;

                foreach (DataGridViewRow producto in dvgProductos.Rows)
                {
                    if (i > 0 && i%2!=0)
                    {
                        if (PorcientoDeCoincidencia(producto.Cells[1].Value+"", dvgProductos.Rows[i - 1].Cells[1].Value+"") >= 50.0m)
                        {
                            if (colorUsado)
                                c = c1;
                            else
                                c = c2;


                            colorUsado = !colorUsado;

                            //Coinciden en mas el 90%, marcar ambos de naranja
                            producto.DefaultCellStyle.BackColor = c;
                            //producto.DefaultCellStyle.SelectionForeColor = SystemColors.Highlight;
                            //producto.DefaultCellStyle.SelectionBackColor = c;
                            //producto.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
                            dvgProductos.Rows[i-1].DefaultCellStyle.BackColor = c;
                            //dvgProductos.Rows[i-1].DefaultCellStyle.SelectionForeColor = SystemColors.Highlight;
                            //dvgProductos.Rows[i-1].DefaultCellStyle.SelectionBackColor = c;
                            //dvgProductos.Rows[i - 1].DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
                        }

                    }
                    i++;
                }
            }

            //String s = txtBuscar.Text;
            //txtBuscar.Text = "";
            //txtBuscar.Text = s;
            cargandoProductos = false;
        }

        private decimal PorcientoDeCoincidencia(string a, string b)
        {
            var aWords = a.Split(' ');
            var bWords = b.Split(' ');
            b.Replace('#', ' ');
            decimal matches = (decimal)aWords.Count(x => bWords.Contains(x));
            matches = matches * 100 / (decimal)aWords.Count();
            return matches;
        }

        private void BuscarProducto_FormClosing(object sender, EventArgs e)
        {
            if(imagen!=null)
                imagen.Dispose();
        }

        private void BuscarProducto_LocationChanged(object sender, EventArgs e)
        {
            if (imagen != null)
            {
                imagen.ActualizarUbicacion(this.DesktopLocation.X, this.DesktopLocation.Y, this.Width, this.Height);

            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodo.Checked)
            {
                chkMarca.CheckedChanged -= new EventHandler(chkChecado);
                chkLinea.CheckedChanged -= new EventHandler(chkChecado);
                chkFabricante.CheckedChanged -= new EventHandler(chkChecado);
                chkProveedor.CheckedChanged -= new EventHandler(chkChecado);

                chkMarca.Checked = false;
                chkLinea.Checked = false;
                chkFabricante.Checked = false;
                chkProveedor.Checked = false;

                chkMarca.CheckedChanged += new EventHandler(chkChecado);
                chkLinea.CheckedChanged += new EventHandler(chkChecado);
                chkFabricante.CheckedChanged += new EventHandler(chkChecado);
                chkProveedor.CheckedChanged += new EventHandler(chkChecado);
            }
            CargarProductos(true, txtBuscar.Text);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMarca.Checked)
            {
                chkTodo.Checked = false;
                chkLinea.Checked = false;
                chkFabricante.Checked = false;
                chkProveedor.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLinea.Checked)
            {
                chkMarca.Checked = false;
                chkTodo.Checked = false;
                chkFabricante.Checked = false;
                chkProveedor.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFabricante.Checked)
            {
                chkMarca.Checked = false;
                chkLinea.Checked = false;
                chkTodo.Checked = false;
                chkProveedor.Checked = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (chkProveedor.Checked)
            {
                chkMarca.Checked = false;
                chkLinea.Checked = false;
                chkFabricante.Checked = false;
                chkTodo.Checked = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    var dt = (DataTable)dvgProductos.DataSource;
            //    string patron = "Nombre LIKE '%" + txtBuscar.Text.Replace(" ", "%' AND Nombre LIKE '%") + "%' or codigo LIKE '%" + txtBuscar.Text + "%'";
            //    dt.DefaultView.RowFilter = patron;
            //    dvgProductos.Refresh();
            //    Console.WriteLine(patron);
            //}
            //catch (Exception error)
            //{
            //    MessageBox.Show("Error: " + error.Message);
            //}
            // this inner method checks if user is still typing
            async Task<bool> UserKeepsTyping()
            {
                cargandoProductos = true;
                string txt = txtBuscar.Text;   // remember text
                await Task.Delay(850);        // wait some
                return txt != txtBuscar.Text;  // return that text chaged or not
            }
            if (await UserKeepsTyping()) return;
            // user is done typing, do your stuff    
            CargarProductos(true, txtBuscar.Text);
        }


        public TextBox ObtenerTxtCodigo()
        {
            return txtCodigo;
        }

        public Button ObtenerBtnAceptar()
        {
            return null;
        }

        private void cbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkMarca.Checked)
                CargarProductos(true,txtBuscar.Text);
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

    }
}
