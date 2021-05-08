using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;
using System.Drawing.Imaging;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Globalization;
using ValleVerdeComun;
using System.Windows.Forms.DataVisualization.Charting;
using ValleVerde.Vistas;

namespace ValleVerde
{
    public partial class AltaProducto : Form
    {
        ValleVerdeComun.Vistas.Inventario.Precios objPrecios = new ValleVerdeComun.Vistas.Inventario.Precios();
        Array[] precios;
        bool esPrecaptura = false;
        // Create class-level accesible variables
        VideoCapture capture;
        Mat frame;
        Bitmap image;
        private Thread camera;
        bool isCameraRunning = false;
        string rutaServidor = "C:/TempVV/";
        List<String> proveedoresRespIDs;
        List<String> proveedoresRespIDsSinModificar;
        string codigoRecibido = "";
        bool impuestosModificados = false;
        //bool preciosModificados = false;
        bool claveSATModificada = false;
        bool imagenesModificadas = false;
        bool claveAdicionalModificadas = false;
        bool productoExtraModificado = false;
        int imgPanelSeleccionado = 1;
        bool esAlta = false;

        string costoOriginal = "";
        List<decimal[]> preciosSinModificarProducto = null;

        PonerToolTip obt;


        //Daniel
        bool agrClaAdi = false;

        public AltaProducto(bool esPrecaptura,string codigoProd, bool mantenerAbierta)
        {
            InitializeComponent();

            obt = new PonerToolTip(toolTip1);

            this.esPrecaptura = esPrecaptura;

            if (this.esPrecaptura)
            {
                panelPrecios.Visible = false;
                txtCodigo.Text = codigoProd;
                codigoRecibido = "";

            }
            else
            {
                //Si recibe un producto entonces va a modificar, precargar la ventana con la informacion
                codigoRecibido = codigoProd;
            }

            chkMantenerAbierta.Checked = mantenerAbierta;

            this.cbImpuestos.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbImpuestos_SelectedIndexChanged);

            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AltaProducto_KeyDown);
            this.txtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AltaProducto_KeyDown);
            this.txtMinimo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AltaProducto_KeyDown);
            this.txtExistencia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AltaProducto_KeyDown);
            this.cbFabricante.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AltaProducto_KeyDown);
            this.cbMarca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AltaProducto_KeyDown);
            this.cbLinea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AltaProducto_KeyDown);
            this.cbUnidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AltaProducto_KeyDown);
            this.cbAlmacen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AltaProducto_KeyDown);
            this.txtLocalizacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AltaProducto_KeyDown);
            this.chkPidePeso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AltaProducto_KeyDown);
            this.btnAgregarProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AltaProducto_KeyDown);
            this.cbImpuestos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AltaProducto_KeyDown);
            this.txtCosto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AltaProducto_KeyDown);

            new ValleVerdeComun.Vistas.BuscadorComboBox(this, cbFabricante);
            new ValleVerdeComun.Vistas.BuscadorComboBox(this, cbMarca);
            new ValleVerdeComun.Vistas.BuscadorComboBox(this, cbLinea);
        }

        private void AltaProducto_Load(object sender, EventArgs e)
        {

            //Cargar listas desplegables
            CargarListaFabricantes();
            CargarListaMarcas();
            CargarListaLineas();
            CargarListaAlmacenes();
            CargarListaUnidades();
            CargarImpuestos();

            objPrecios.ConfigurarPanelPrecios(ref tablePrecios, ref txtCosto, ref precios, false);

            txtCodigo.Select();

            //Si recibe un producto entonces va a modificar, precargar la ventana con la informacion
            if (codigoRecibido == "") {
                //Es una alta
                //lbExistencia.Enabled = false;
                //lbExistencia.Visible = false;
                //txtExistencia.Enabled = false;
                //txtExistencia.Visible = false;
                
                panelLocalizacion.Visible = false;
                esAlta = true;
            }
            else
            {
                //Es una modificacion
                //btnBuscar.Visible = false;

                ValleVerdeComun.Programacion.Producto ob = new ValleVerdeComun.Programacion.Producto();
                this.Text = "Modificar producto";
                //txtCodigo.ReadOnly = true;

                txtExistencia.Enabled = false;
                panelAlmacenes.Visible = false;

                lbExistencia.Text = "Existencia total:";
                lbExistencia.Location.Offset(0,-500);
                txtExistencia.Location = new System.Drawing.Point(lbExistencia.Location.X + lbExistencia.Width + 5, txtExistencia.Location.Y);
                txtCodigo.Text = codigoRecibido;
                panelError.Visible = false;
                txtNombre.Text = ob.ObtenerNombreProducto(codigoRecibido);
                //txtDescripcion.Text = ob.ObtenerDescripcionProducto(codigoRecibido);
                txtExistencia.Text = ob.ObtenerExistenciaTotalProducto(codigoRecibido) + "";
                txtMinimo.Text = ob.ObtenerMinimoInventario(codigoRecibido) + "";
                txtMerma.Text = ob.ObtenerMerma(codigoRecibido) + "";
                txtUtilidadSucursales.Text = ob.ObtenerUtilidadSucursal(codigoRecibido) +"";
                chkNoUsaInventario.Checked = ob.NoUsaInventario(codigoRecibido);
                chkPidePeso.Checked = ob.PidePeso(codigoRecibido);
                chkBloqueado.Checked = ob.EstaBloqueado(codigoRecibido);

                CargarListaProveedores();
                ValleVerdeComun.Programacion.Precios obp = new ValleVerdeComun.Programacion.Precios();
                costoOriginal = obp.ObtenerCostoProducto(codigoRecibido) + "";
                preciosSinModificarProducto = obp.ObtenerPreciosCostoProducto(codigoRecibido);
                objPrecios.CargarPreciosCosto(codigoRecibido, ref precios);
                CargarClaveSAT();
                CargarImagenes();
                CargarLocalizacion();
                CargarClavesAdicionales();
                CargarProductoExtra();
            }
        }

        public void CargarLocalizacion()
        {
            ValleVerdeComun.Programacion.Producto ob = new ValleVerdeComun.Programacion.Producto();

            List<String[]> res = ob.ObtenerLocalizacion(codigoRecibido);

            foreach (String[] loc in res)
            {
                dvgLocalizacion.Rows.Add(loc[0], loc[1], loc[2]);
            }
        }

        public void CargarClavesAdicionales()
        {
            ValleVerdeComun.Programacion.Producto ob = new ValleVerdeComun.Programacion.Producto();

            List<String[]> res = ob.ObtenerClavesAdicionales(codigoRecibido);

            foreach (String[] loc in res)
            {
                dvgClavesAdicionales.Rows.Add(loc[0], loc[1], loc[2]);
            }
        }

        public void CargarProductoExtra()
        {
            ValleVerdeComun.Programacion.Producto ob = new ValleVerdeComun.Programacion.Producto();

            List<String[]> res = ob.ObtenerProductoExtra(codigoRecibido);

            foreach (String[] loc in res)
            {
                dvgProductoExtra.Rows.Add(loc[0], loc[1], loc[2]);
            }
        }

        private void CargarListaFabricantes()
        {
            Programacion.Fabricantes ob = new Programacion.Fabricantes();

            List<String[]> res = ob.ObtenerFabricantes();

            cbFabricante.DisplayMember = "Text";
            cbFabricante.ValueMember = "Value";

            List<Object> items = new List<Object>();

            //Si recibio un producto seleccionar su fabricante
            string fabricanteProd = ob.ObtenerFabricanteProducto(codigoRecibido)[0];
            int fabricanteProdI = -1, fabricantePorDefecto = 0, i = 0;

            foreach (String[] fabricante in res)
            {
                items.Add(new { Text = fabricante[1], Value = fabricante[0] });
                if(fabricante[0] == fabricanteProd)
                {
                    fabricanteProdI = i;
                }

                if (fabricante[0] == "1")
                {
                    fabricantePorDefecto = i;
                }
                i++;
            }

            cbFabricante.DataSource = items;


            if (fabricanteProdI != -1)
            {
                cbFabricante.SelectedIndex = fabricanteProdI;
                obt.SetToolTip(cbFabricante, cbFabricante.GetItemText(cbFabricante.SelectedItem)+"");
            }
            else
            {
                cbFabricante.SelectedIndex = fabricantePorDefecto;
            }
        }

        private void CargarListaMarcas()
        {
            Programacion.Marcas ob = new Programacion.Marcas();

            List<String[]> res = ob.ObtenerMarcas();

            cbMarca.DisplayMember = "Text";
            cbMarca.ValueMember = "Value";

            List<Object> items = new List<Object>();

            //Si recibio un producto seleccionar su fabricante
            string marcaProd = ob.ObtenerMarcaProducto(codigoRecibido)[0];
            int marcaProdI = -1, marcaPorDefecto = 0, i = 0;


            foreach (String[] marca in res)
            {
                items.Add(new { Text = marca[1], Value = marca[0] });
                if (marca[0] == marcaProd)
                {
                    marcaProdI = i;
                }

                if (marca[0] == "1")
                {
                    marcaPorDefecto = i;
                }

                i++;
            }

            cbMarca.DataSource = items;

            if (marcaProdI != -1)
            {
                cbMarca.SelectedIndex = marcaProdI;
                obt.SetToolTip(cbMarca, cbMarca.GetItemText(cbMarca.SelectedItem) + "");
            }
            else
            {
                cbMarca.SelectedIndex = marcaPorDefecto;
            }
        }

        private void CargarListaLineas()
        {
            Programacion.Lineas ob = new Programacion.Lineas();

            List<String[]> res = ob.ObtenerLineas();

            cbLinea.DisplayMember = "Text";
            cbLinea.ValueMember = "Value";

            List<Object> items = new List<Object>();

            //Si recibio un producto seleccionar su fabricante
            string lineaProd = ob.ObtenerLineaProducto(codigoRecibido)[0];
            int lineaProdI = -1, lineaPorDefecto = 0, i = 0;


            foreach (String[] linea in res)
            {
                items.Add(new { Text = linea[1], Value = linea[0] });
                if (linea[0] == lineaProd)
                {
                    lineaProdI = i;
                }

                if (linea[0] == "1")
                {
                    lineaPorDefecto = i;
                }

                i++;
            }

            cbLinea.DataSource = items;

            if (lineaProdI != -1)
            {
                cbLinea.SelectedIndex = lineaProdI;
                obt.SetToolTip(cbLinea, cbLinea.GetItemText(cbLinea.SelectedItem) + "");
            }
            else
            {
                cbLinea.SelectedIndex = lineaPorDefecto;
            }
        }

        private void CargarListaAlmacenes()
        {
            Programacion.Almacenes ob = new Programacion.Almacenes();

            List<String[]> res = ob.ObtenerAlmacenes();

            cbAlmacen.DisplayMember = "Text";
            cbAlmacen.ValueMember = "Value";

            List<Object> items = new List<Object>();

            foreach (String[] almacen in res)
            {
                items.Add(new { Text = almacen[1], Value = almacen[0] });
            }

            cbAlmacen.DataSource = items;
        }

        private void CargarListaUnidades()
        {
            Programacion.Unidades ob = new Programacion.Unidades();

            List<String[]> res = ob.ObtenerUnidades();

            cbUnidad.DisplayMember = "Text";
            cbUnidad.ValueMember = "Value";

            List<Object> items = new List<Object>();
            //Si recibio un producto seleccionar su fabricante
            string unidadProd = ob.ObtenerUnidadProducto(codigoRecibido);
            int unidadProdI = 0, i = 0;

            foreach (String[] unidad in res)
            {
                items.Add(new { Text = unidad[1], Value = unidad[0] });
                if (unidad[0] == unidadProd)
                {
                    unidadProdI = i;
                }
                i++;
            }

            cbUnidad.DataSource = items;
            cbUnidad.SelectedIndex = unidadProdI;
        }

        private void CargarListaProveedores()
        {
            Programacion.Proveedor ob = new Programacion.Proveedor();

            //Recibiremos la lista que incluye el id y el nombre del proveedor
            //El id va en proveedoresRespIDs y el nombre en el list box
            

            List<String[]> res = ob.ObtenerProveedoresProducto(codigoRecibido);
            if (proveedoresRespIDs == null)
                proveedoresRespIDs = new List<string>();
            else
                proveedoresRespIDs.Clear();

            if (proveedoresRespIDsSinModificar == null)
                proveedoresRespIDsSinModificar = new List<string>();
            else
                proveedoresRespIDsSinModificar.Clear();

            listBoxP.Items.Clear();

            foreach (String[] Proveedor in res)
            {
                listBoxP.Items.Add(Proveedor[1]);
                proveedoresRespIDs.Add(Proveedor[0]);
                proveedoresRespIDsSinModificar.Add(Proveedor[0]);
            }
        }


        private void CargarClaveSAT()
        {
            ValleVerdeComun.Programacion.ClavesSAT ob = new ValleVerdeComun.Programacion.ClavesSAT();

            String[] claveDescripcionSAT = ob.ObtenerClaveSATProducto(codigoRecibido);

            if (claveDescripcionSAT != null)
            {
                txtCodigoSAT.Text = claveDescripcionSAT[0];
                txtDescripcionSAT.Text = claveDescripcionSAT[1];
            }

        }

        private void CargarImagenes()
        {
            ValleVerdeComun.Programacion.Producto ob = new ValleVerdeComun.Programacion.Producto();

            int cant = ob.ObtenerCantidadImagenesProducto(codigoRecibido);
            // MessageBox.Show("El producto tiene " + cant + " imagenes");
            if (cant > 0)
            {
                //Cargar imagenes
                List<Image> imagenes = ob.ObtenerImagenesProducto(codigoRecibido);
                List<PictureBox> imagenesProducto = new List<PictureBox> {pictureBox1,pictureBox2,pictureBox3,pictureBox4 };

                int ind = 0;
                foreach(Image imagen in imagenes)
                {
                    Image img = null;
                    try 
                    {
                        //img = Image.FromFile(rutaImagen); 
                        img = imagen;
                    } catch { 
                        img = ValleVerde.Properties.Resources.producto_placeholder200;
                    }
                    
                    if (ind == 0)
                    {
                       
                        pictureBoxP.Image = img.GetThumbnailImage(img.Width, img.Height, null, new IntPtr());
                        
                    }

                    imagenesProducto[ind].Image = img.GetThumbnailImage(img.Width, img.Height, null, new IntPtr()); ;

                    img.Dispose();

                    //El tag "" significa que no se cargo imagen
                    //El tag "1" significa que se cargo una nueva imagen
                    //El tag "2" significa que se cargo una imagen de base de datos
                    imagenesProducto[ind].Tag = "2";

                    ind++;
                }
               
            }
        }

        private void CargarImpuestos()
        {
            if (cbImpuestos != null)
                cbImpuestos.DataSource = null;

            ValleVerdeComun.Programacion.Impuestos ob = new ValleVerdeComun.Programacion.Impuestos();

            List<String[]> res = ob.ObtenerImpuestos();
           
           

            List<Object> items = new List<Object>();

            foreach (String[] almacen in res)
            {
                items.Add(new { Text = almacen[1] + " - " + almacen[2], Value = almacen[0] });
               
            }

            cbImpuestos.DataSource = items;
            cbImpuestos.DisplayMember = "Text";
            cbImpuestos.ValueMember = "Value";

            //Si recibio un producto seleccionar su fabricante
            if (codigoRecibido != "")
            {
                List<string[]> impuestosProd = ob.ObtenerImpuestosProducto(codigoRecibido);
                List<int> indexImpuestos = null;

                foreach (string[] impuesto in impuestosProd)
                {
                    int x = 0;
                    foreach (Object imp in cbImpuestos.Items)
                    {
                        PropertyDescriptorCollection i = TypeDescriptor.GetProperties(imp);

                        String idImpuesto = i.Find("Value", true).GetValue(imp) + "";
                       
                        if (idImpuesto == impuesto[0])
                        {
                            //Para evitar errores se guarda la lista de index que hay que marcar
                            if (indexImpuestos == null)
                                indexImpuestos = new List<int>();
                            indexImpuestos.Add(x);

                        }
                        x++;
                    }

                }

                if (indexImpuestos != null)
                {
                    impuestosModificados = true;
                    foreach (int indice in indexImpuestos)
                    {
                        cbImpuestos.SetItemChecked(indice, true);
                    }
                }
            }
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            if (chkMantenerAbierta.Checked && !esAlta)
            {
                new BuscarProductoModificar(true).Show();
            }

            this.Close();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            if (esAlta)
            {
                DarDeAltaProducto();
            }
            else
            {
                ModificarProducto();
            }

        }

        private void DarDeAltaProducto()
        {
            decimal merma = -1, minimo = -1;
            float utilidadSucursal = -1;

            int mermaUtilidadMinimo = 1;

            try
            {
                if (txtMerma.Text.Trim() == "")
                    merma = 0;
                else
                    merma = decimal.Parse(txtMerma.Text);

            }
            catch
            {
                mermaUtilidadMinimo = -1;
            }

            try
            {
                if (txtUtilidadSucursales.Text.Trim() == "")
                    utilidadSucursal = 0;
                else
                    utilidadSucursal = float.Parse(txtUtilidadSucursales.Text);
            }
            catch
            {
                mermaUtilidadMinimo = -2;
            }

            try
            {
                if (txtMinimo.Text.Trim() == "")
                    minimo = 0;
                else
                    minimo = decimal.Parse(txtMinimo.Text);
            }
            catch
            {
                mermaUtilidadMinimo = -3;
            }

            //Verificar que campos obligatorios no esten vacios
            int verificarPrecios = objPrecios.VerificarPrecios();
            if (txtCodigo.Text != "" && txtNombre.Text != "" && panelError.Visible == false && cbFabricante.SelectedValue != null && cbMarca.SelectedValue != null && cbLinea.SelectedValue != null && verificarPrecios == 1 && mermaUtilidadMinimo == 1)
            {
                //Dar de alta el producto
                ValleVerdeComun.Programacion.Producto ob = new ValleVerdeComun.Programacion.Producto();
                int idFabricante = Convert.ToInt16(cbFabricante.SelectedValue);
                int idMarca = Convert.ToInt16(cbMarca.SelectedValue);
                int idLinea = Convert.ToInt16(cbLinea.SelectedValue);
                int idUnidad = Convert.ToInt16(cbUnidad.SelectedValue);
                int idAlmacen = Convert.ToInt16(cbAlmacen.SelectedValue);
                float costo = 0;
                if (txtCosto.Text != "")
                {
                    costo = float.Parse(txtCosto.Text);
                }
                int resultado = ob.DarAltaProducto(txtCodigo.Text, txtNombre.Text, "", decimal.Parse(txtExistencia.Text), idFabricante, idMarca, idLinea, idUnidad, idAlmacen, txtLocalizacion.Text, chkNoUsaInventario.Checked, chkBloqueado.Checked, chkPidePeso.Checked, costo, minimo, merma, utilidadSucursal);

                if (resultado == 1)
                {
                    //Conectar con proveedores
                    RegistrarProveedores(ob);

                    //Conectar con impuestos
                    RegistrarImpuestos(ob);

                    //Registrar precios
                    objPrecios.RegistrarPrecios(ob, txtCodigo.Text,"-1");

                    //Si saben la clave del sat conectarlo
                    RegistrarClaveSAT(ob);

                    //Registrar las imagenes y guardarla en el servidor
                    RegistrarImagenes(ob);

                    //Guardar claves adicionales
                    RegistrarClavesAdicionales(ob);

                    //Guardar producto extra
                    RegistrarProductoExtra(ob);

                    if (chkMantenerAbierta.Checked)
                    {
                        //Limpiar los campos
                        LimpiarVentana();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    switch (resultado)
                    {
                        case -1:
                            MessageBox.Show("El producto ya fue dado de alta");
                            break;
                        case -2:
                            MessageBox.Show("Selecciona un fabricante");
                            break;
                        case -3:
                            MessageBox.Show("Selecciona la marca");
                            break;
                        case -4:
                            MessageBox.Show("Selecciona la linea");
                            break;
                        case -5:
                            MessageBox.Show("Selecciona la unidad");
                            break;
                        case -6:
                            MessageBox.Show("Selecciona un almacen");
                            break;
                        case -7:
                            MessageBox.Show("Revisa el nombre, descripcion o codigo");
                            break;

                    }

                }
                //NOTA: tomar en cuenta impuestos para calculo de precio
            }
            else
            {
                if (verificarPrecios != 1)
                {
                    switch (verificarPrecios)
                    {
                        case -1:
                            MessageBox.Show("Verifica el costo");
                            txtCosto.SelectAll();
                            break;
                        case -2:
                            MessageBox.Show("Las utilidades deben de ser positivas y consecutivas de mayor a menor.", "Verifica las utilidades");
                            break;
                        case -3:
                            MessageBox.Show("Las cantidades deben de ser positivas y consecutivas de menor a mayor.", "Verifica las cantidades");
                            break;
                        default:
                            MessageBox.Show("Llena los campos obligatorios y verifica los otros datos.");
                            break;
                    }
                }
                else
                {
                    switch (mermaUtilidadMinimo)
                    {
                        case -1:
                            MessageBox.Show("Verifica la merma");
                            txtMerma.Focus();
                            txtMerma.SelectAll();
                            break;
                        case -2:
                            MessageBox.Show("Verifica la utilidad para las sucursales");
                            txtUtilidadSucursales.Focus();
                            txtUtilidadSucursales.SelectAll();
                            break;
                        case -3:
                            MessageBox.Show("Verifica el inventario minimo.");
                            txtMinimo.Focus();
                            txtMinimo.SelectAll();
                            break;
                        default:
                            MessageBox.Show("Llena los campos obligatorios y verifica los otros datos.");
                            break;
                    }
                }
               
               
            }
        }

        private void ModificarProducto()
        {
            //Verificar que campos obligatorios no esten vacios
            decimal merma = -1, minimo = -1;
            float utilidadSucursal = -1;

            int mermaUtilidadMinimo = 1;

            try
            {
                if (txtMerma.Text.Trim() == "")
                    merma = 0;
                else
                    merma = decimal.Parse(txtMerma.Text);

            }
            catch
            {
                mermaUtilidadMinimo = -1;
            }

            try
            {
                if (txtUtilidadSucursales.Text.Trim() == "")
                    utilidadSucursal = 0;
                else
                    utilidadSucursal = float.Parse(txtUtilidadSucursales.Text);
            }
            catch
            {
                mermaUtilidadMinimo = -2;
            }

            try
            {
                if (txtUtilidadSucursales.Text.Trim() == "")
                    minimo = 0;
                else
                    minimo = decimal.Parse(txtMinimo.Text);
            }
            catch
            {
                mermaUtilidadMinimo = -3;
            }

            

            int verificarPrecios = objPrecios.VerificarPrecios();
            if (txtCodigo.Text != "" && txtNombre.Text != "" && panelError.Visible == false && cbFabricante.SelectedValue != null && cbMarca.SelectedValue != null && cbLinea.SelectedValue != null && verificarPrecios == 1 && mermaUtilidadMinimo == 1)
            {

                //Dar de alta el producto
                ValleVerdeComun.Programacion.Producto ob = new ValleVerdeComun.Programacion.Producto();
                int idFabricante = Convert.ToInt16(cbFabricante.SelectedValue);
                int idMarca = Convert.ToInt16(cbMarca.SelectedValue);
                int idLinea = Convert.ToInt16(cbLinea.SelectedValue);
                int idUnidad = Convert.ToInt16(cbUnidad.SelectedValue);
                decimal costo = 0;
                if (txtCosto.Text != "")
                {
                    costo = decimal.Parse(txtCosto.Text);
                }

                int resultado = ob.ModificarProducto(codigoRecibido,txtCodigo.Text, txtNombre.Text, "", idFabricante, idMarca, idLinea, idUnidad, chkNoUsaInventario.Checked, chkBloqueado.Checked, chkPidePeso.Checked, costo, minimo, merma, utilidadSucursal);

                if (resultado == 1)
                {
                    if (!Enumerable.SequenceEqual(proveedoresRespIDs, proveedoresRespIDsSinModificar))
                    {
                        //Las listas no coinciden, los proveedores fueron modificados
                        ob.EliminarRelacionesConProveedores(txtCodigo.Text);

                        //Crear las nuevas relaciones con proveedores
                        RegistrarProveedores(ob);
                    }

                    //Conectar con impuestos
                    if (impuestosModificados)
                    {
                        //Eliminar los anteriores
                        ob.EliminarRelacionesConImpuestos(codigoRecibido);

                        //Crear las nuevas relaciones con impuestos
                        RegistrarImpuestos(ob);
                    }


                    //Actualizar precios
                    //varificar si fueron modificados, si es asi entonces eliminarlos y volverlos a registrar
                    bool preciosModificados = false;

                    //Checar que no haya cambiado el costo
                    if(costoOriginal != txtCosto.Text)
                        preciosModificados = true;

                    //checar que no haya cambiado las utilidades o cantidades
                    if(preciosSinModificarProducto.Count != precios.Length)
                        preciosModificados = true;
                    else
                    {
                        for(int x=0;x<precios.Length;x++)
                        {
                            if (x != 0)
                            {
                                //Para no comparar en el primero las cantidades
                                if ((precios.ElementAt(x) as TextBox[])[2].Text != (preciosSinModificarProducto.ElementAt(x)[1] + ""))
                                {
                                    preciosModificados = true;
                                    break;
                                }
                            }

                            if ((precios.ElementAt(x) as TextBox[])[1].Text != (preciosSinModificarProducto.ElementAt(x)[0] + ""))
                            {
                                preciosModificados = true;
                                break;
                            }
                            
                        }
                    }

                    if (preciosModificados)
                    {
                        //Mandar las utilidades a historialcosto, para eso ocupo saber las anteriores
                        

                        //EliminarAnteriores
                        string idHistorialCosto = ob.EliminarPrecios(codigoRecibido);//Estos van a registrar un historial de cambio con 0
                        
                        //Relacionar los nuevos precios
                        objPrecios.RegistrarPrecios(ob,txtCodigo.Text, idHistorialCosto);//Estos van a registrar un historial de cambio con 1
                    }

                    //Actualizar clave sat
                    if (claveSATModificada)
                    {
                        ob.EliminarRelacionConClaveSAT(codigoRecibido);

                        RegistrarClaveSAT(ob);
                    }

                    //Registrar las imagenes y guardarla en el servidor
                    if (imagenesModificadas)
                    {
                        //Eliminar del servidor las imagenes
                        ob.ObtenerCantidadImagenesProducto(codigoRecibido);
                        
                        //int cant = ob.ObtenerCantidadImagenesProducto(codigoRecibido);

                        //if (cant > 0)
                        //{
                        //    List<Image> imagenes = ob.ObtenerImagenesProducto(codigoRecibido);

                        //    foreach (Image imagen in imagenes)
                        //    {
                        //        try
                        //        {
                        //           // File.Delete(imagen);
                        //           //mandar eliminar de bd

                        //        }
                        //        catch (IOException e)
                        //        {
                        //            MessageBox.Show("Error al eliminar imagenes en servidor." + e);
                        //        }
                               
                        //    }
                        //}

                        //Eliminar de la base de datos
                        ob.EliminarRelacionesConImagenes(codigoRecibido);


                        RegistrarImagenes(ob);
                    }

                    if (claveAdicionalModificadas)
                    {
                        //Eliminar anteriores
                        ob.EliminarClavesAdicionalesAnteriores(codigoRecibido);

                        //Guardar claves adicionales
                        RegistrarClavesAdicionales(ob);
                    }

                    if (productoExtraModificado)
                    {
                        //Eliminar anteriores
                        ob.EliminarProductoExtraAnterior(codigoRecibido);

                        //Guardar Producto extra
                        RegistrarProductoExtra(ob);
                    }

                    if (chkMantenerAbierta.Checked)
                    {
                        new BuscarProductoModificar(true).Show();
                    }
                    
                     this.Close();
                    
                }
                else
                {
                    switch (resultado)
                    {
                        case -1:
                            MessageBox.Show("El producto ya fue dado de alta");
                            break;
                        case -2:
                            MessageBox.Show("Selecciona un fabricante");
                            break;
                        case -3:
                            MessageBox.Show("Selecciona la marca");
                            break;
                        case -4:
                            MessageBox.Show("Selecciona la linea");
                            break;
                        case -5:
                            MessageBox.Show("Selecciona la unidad");
                            break;
                        case -6:
                            MessageBox.Show("Selecciona un almacen");
                            break;
                        case -7:
                            MessageBox.Show("Revisa el nombre, descripcion o codigo");
                            break;

                    }

                }
                //NOTA: tomar en cuenta impuestos para calculo de precio
            }
            else
            {
                

                if (verificarPrecios != 1)
                {
                    switch (verificarPrecios)
                    {
                        case -1:
                            MessageBox.Show("Verifica el costo");
                            txtCosto.Focus();
                            txtCosto.SelectAll();
                            break;
                        case -2:
                            MessageBox.Show("Las utilidades deben de ser positivas y consecutivas de mayor a menor.", "Verifica las utilidades");
                            break;
                        case -3:
                            MessageBox.Show("Las cantidades deben de ser positivas y consecutivas de menor a mayor.", "Verifica las cantidades");
                            break;
                        default:
                            MessageBox.Show("Revisa los datos.");
                            txtCodigo.Focus();
                            txtCodigo.SelectAll();
                            break;
                    }
                }
                else
                {
                    switch (mermaUtilidadMinimo)
                    {
                        case -1:
                            MessageBox.Show("Verifica la merma");
                            txtMerma.Focus();
                            txtMerma.SelectAll();
                            break;
                        case -2:
                            MessageBox.Show("Verifica la utilidad para las sucursales");
                            txtUtilidadSucursales.Focus();
                            txtUtilidadSucursales.SelectAll();
                            break;
                        case -3:
                            MessageBox.Show("Verifica el inventario minimo.");
                            txtMinimo.Focus();
                            txtMinimo.SelectAll();
                            break;
                        default:
                            MessageBox.Show("Llena los campos obligatorios y verifica los otros datos.");
                            break;
                    }
                }


            }
        }

        private void RegistrarProveedores(ValleVerdeComun.Programacion.Producto ob)
        {
            if (proveedoresRespIDs != null)
                foreach (string proveedor in proveedoresRespIDs)
                {
                    int res = ob.AgregarProveedorProducto(txtCodigo.Text, proveedor);
                    if (res != 1)
                    {
                        MessageBox.Show("Ocurrio un error en proveedores: " + res);
                    }
                }
        }

        private void RegistrarImpuestos(ValleVerdeComun.Programacion.Producto ob)
        {
            if (cbImpuestos.CheckedItems.Count > 0)
                foreach (Object impuesto in cbImpuestos.CheckedItems)
                {
                    PropertyDescriptorCollection i = TypeDescriptor.GetProperties(impuesto);

                    String idImpuesto = i.Find("Value", true).GetValue(impuesto) + "";

                    //MessageBox.Show("Voy a relacionar con impuesto "+nombre +" con valor de " +valor);

                    int res = ob.AgregarImpuestoProducto(txtCodigo.Text, idImpuesto);
                    if (res != 1)
                    {
                        MessageBox.Show("Ocurrio un error en impuestos: " + res);
                    }
                }
        }

        private void RegistrarClaveSAT(ValleVerdeComun.Programacion.Producto ob)
        {
            if (txtCodigoSAT.Text != "")
            {
                ValleVerdeComun.Programacion.ClavesSAT obj = new ValleVerdeComun.Programacion.ClavesSAT();
                int r = obj.VincularProductoConClaveSAT(txtCodigo.Text, txtCodigoSAT.Text);

                if (r != 1)
                {
                    MessageBox.Show("Ocurrio un error en la clavesat: " + r);
                }
            }
        }
        
        private void RegistrarImagenes(ValleVerdeComun.Programacion.Producto ob)
        {
            string ruta = "";

            System.IO.Directory.CreateDirectory(rutaServidor);

            if ((pictureBox1.Tag + "") != "-1")
            {
                //ruta = rutaServidor + "img-" + txtCodigo.Text + "-1.png";


                var i2 = new Bitmap(pictureBox1.Image);

                //i2.Save(ruta, ImageFormat.Png);

                //pictureBox1.Image.Save(ruta, ImageFormat.Png);
                ob.AgregarImagenProducto(txtCodigo.Text, i2);
               
                
            }

            if ((pictureBox2.Tag + "") != "-1")
            {
                //ruta = rutaServidor + "img-" + txtCodigo.Text + "-2.png";
                //pictureBox2.Image.Save(ruta, ImageFormat.Png);
                ob.AgregarImagenProducto(txtCodigo.Text, pictureBox2.Image);
            }

            if ((pictureBox3.Tag + "") != "-1")
            {
                //ruta = rutaServidor + "img-" + txtCodigo.Text + "-3.png";
                //pictureBox3.Image.Save(ruta, ImageFormat.Png);
                ob.AgregarImagenProducto(txtCodigo.Text, pictureBox3.Image);
            }

            if ((pictureBox4.Tag + "") != "-1")
            {
                //ruta = rutaServidor + "img-" + txtCodigo.Text + "-4.png";
                //pictureBox4.Image.Save(ruta, ImageFormat.Png);
                ob.AgregarImagenProducto(txtCodigo.Text, pictureBox4.Image);
            }

        }

        private void RegistrarClavesAdicionales(ValleVerdeComun.Programacion.Producto ob)
        {
            if (dvgClavesAdicionales.Rows.Count > 0)
            {
                for (int x = 0; x < dvgClavesAdicionales.Rows.Count; x++)
                {
                    ob.AgregarClaveAdicional(txtCodigo.Text, dvgClavesAdicionales.Rows[x].Cells[0].Value + "", dvgClavesAdicionales.Rows[x].Cells[1].Value + "", dvgClavesAdicionales.Rows[x].Cells[2].Value + "");
                }
            }
        }

        private void RegistrarProductoExtra(ValleVerdeComun.Programacion.Producto ob)
        {
            if (dvgProductoExtra.Rows.Count > 0)
            {
                for (int x = 0; x < dvgProductoExtra.Rows.Count; x++)
                {
                    int e = ob.AgregarProductoExtra(txtCodigo.Text, dvgProductoExtra.Rows[x].Cells[0].Value + "", dvgProductoExtra.Rows[x].Cells[1].Value + "", dvgProductoExtra.Rows[x].Cells[2].Value + "");
                    switch (e)
                    {
                        case -1:
                            MessageBox.Show("No existe el producto: " + txtCodigo.Text);
                            break;
                        case -2:
                            MessageBox.Show("No existe el producto extra: " + dvgProductoExtra.Rows[x].Cells[0].Value);
                            break;
                        case -3:
                            MessageBox.Show("Ya esta registrado el producto extra: " + dvgProductoExtra.Rows[x].Cells[0].Value);
                            break;
                    }
                }
            }
        }

        private void LimpiarVentana()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            //txtDescripcion.Text = "";
            txtExistencia.Text = "";
            cbFabricante.SelectedIndex = 0;
            cbMarca.SelectedIndex = 0;
            cbLinea.SelectedIndex = 0;
            cbUnidad.SelectedIndex = 0;
            cbAlmacen.SelectedIndex = 0;
            txtLocalizacion.Text = "";
            chkNoUsaInventario.Checked = false;
            chkPidePeso.Checked = false;
            chkBloqueado.Checked = false;
            proveedoresRespIDs = null;
            proveedoresRespIDsSinModificar = null;
            listBoxP.Items.Clear();
            for (int i = 0; i < cbImpuestos.Items.Count; i++)
                cbImpuestos.SetItemCheckState(i, CheckState.Unchecked);

            txtCosto.Text = "";

            tablePrecios.Controls.Clear();
            objPrecios.ConfigurarPanelPrecios(ref tablePrecios,ref txtCosto,ref precios, false);

            txtCodigoSAT.Text = "";
            txtDescripcionSAT.Text = "";

            pictureBoxP.Image = ValleVerde.Properties.Resources.anadir;
            pictureBox1.Image = ValleVerde.Properties.Resources.anadir;
            pictureBox2.Image = ValleVerde.Properties.Resources.anadir;
            pictureBox3.Image = ValleVerde.Properties.Resources.anadir;
            pictureBox4.Image = ValleVerde.Properties.Resources.anadir;
            pictureBox1.Tag = "-1";
            pictureBox2.Tag = "-1";
            pictureBox3.Tag = "-1";
            pictureBox4.Tag = "-1";

            impuestosModificados = false;
            claveSATModificada = false;
            imagenesModificadas = false;

            tabControl1.SelectedIndex = 0;
            txtCodigo.Focus();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SeleccionarProveedor obj = new SeleccionarProveedor();
            obj.ShowDialog();

            List<String> respNom = obj.ObtenerRespuestaNombres();

            if (proveedoresRespIDs == null)
                proveedoresRespIDs = new List<string>();

            List<string> resp = obj.ObtenerRespuestaIDs();
            if (resp != null)
            {
                foreach (string prov in resp)
                {
                    proveedoresRespIDs.Add(prov);
                }
            }


            if (respNom != null)
            {
                foreach (String respuesta in respNom)
                {
                    if (!listBoxP.Items.Contains(respuesta))
                        listBoxP.Items.Add(respuesta);
                }
            }
        }

        //private void RespuestaSeleccionaProveedor(SeleccionarProveedor obj)
        //{
        //    bool respuestaLista;

        //    do
        //    {
        //        respuestaLista = obj.RespuestaLista();
        //    } while (!respuestaLista);

           

        //}

        private void button5_Click(object sender, EventArgs e)
        {
            objPrecios.AgregarRenglonPrecios(ref precios, false,false);
        }

        private void txtCosto_TextChanged(object sender, EventArgs e)
        {

            try
            {
                (precios[0] as TextBox[])[0].Enabled = true;
                (precios[0] as TextBox[])[1].Enabled = true;
                foreach (TextBox[]precio in precios){
                    string t = precio[1].Text;
                    precio[1].Text = "";
                    precio[1].Text = t;
                }
            }
            catch { }
        }

        private async void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            //Solo checar cuando es alta, no modificacion
           
            
                ValleVerdeComun.Programacion.Producto ob = new ValleVerdeComun.Programacion.Producto();

                async Task<bool> UserKeepsTyping()
                {
                    string txt = txtCodigo.Text;   // remember text
                    await Task.Delay(500);        // wait some
                    return txt != txtCodigo.Text;  // return that text chaged or not
                }
                if (await UserKeepsTyping()) return;
                // user is done typing, do your stuff    

                if (ob.ExisteProductoConCodigo(txtCodigo, true, false,true, "-1") == true)
                {
                    if (codigoRecibido == "")
                        panelError.Visible = true;
                    else
                        if(codigoRecibido != txtCodigo.Text)
                             panelError.Visible = true;

            }
                else
                {
                    panelError.Visible = false;
                }
            
            
        }

        private void AltaProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //switch (((Control)sender).Name)
                //{
                //    case "txtCodigo":
                //        txtNombre.SelectAll();
                //        txtNombre.Focus();
                //        break;
                //    case "txtNombre":
                //        txtMinimo.SelectAll();
                //        txtMinimo.Focus();
                //        break;
                //    case "txtMinimo":
                //        txtExistencia.SelectAll();
                //        txtExistencia.Focus();
                //        break;
                //    case "txtExistencia":
                //        cbFabricante.SelectAll();
                //        cbFabricante.Focus();
                //        break;
                //    case "cbFabricante":
                //        cbMarca.SelectAll();
                //        cbMarca.Focus();
                //        break;
                //    case "cbMarca":
                //        cbLinea.SelectAll();
                //        cbLinea.Focus();
                //        break;
                //    case "cbLinea":
                //        cbUnidad.SelectAll();
                //        cbUnidad.Focus();
                //        break;
                //    case "cbUnidad":
                //        cbAlmacen.SelectAll();
                //        cbAlmacen.Focus();
                //        break;
                //    case "cbAlmacen":
                //        txtLocalizacion.SelectAll();
                //        txtLocalizacion.Focus();
                //        break;
                //    case "txtLocalizacion":
                //        chkPidePeso.Select();
                //        chkPidePeso.Focus();
                //        break;
                //    case "chkPidePeso":
                //        btnAgregarProveedor.Select();
                //        btnAgregarProveedor.Focus();
                //        break;
                //    case "btnAgregarProveedor":
                //        cbImpuestos.Select();
                //        cbImpuestos.Focus();
                //        break;
                //    case "cbImpuestos":
                //        txtCosto.SelectAll();
                //        txtCosto.Focus();
                //        break;
                //}
                //SelectNextControl((Control)sender, true, true, true, true);
                SendKeys.Send("{TAB}");
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
           
        }

        private void clbImpuestos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(Evento));
            
        }

        private void Evento()
        {
            //De los impuestos con el mismo nombre solo puede estar seleccionado uno a la vez
            impuestosModificados = true;
            List<String> seleccionadosNombre = new List<string>();
            List<int> seleccionadosPosicion = new List<int>();

            foreach (Object impuesto in cbImpuestos.CheckedItems)
            {
                PropertyDescriptorCollection imp = TypeDescriptor.GetProperties(impuesto);

                String nombre = imp.Find("Text", true).GetValue(impuesto) + "";

                nombre = nombre.Substring(0, nombre.IndexOf('-'));

                if (seleccionadosNombre.Contains(nombre))
                {
                    //Si ya esta significa que ya habia seleccionado otro con el mismo nombre, debemos de desmarcar uno de los dos
                    this.cbImpuestos.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.clbImpuestos_SelectedIndexChanged);

                    //Des-seleccionando el anterior
                    if (seleccionadosPosicion[seleccionadosNombre.IndexOf(nombre)] != cbImpuestos.SelectedIndex)
                    {
                        cbImpuestos.SetItemChecked(seleccionadosPosicion[seleccionadosNombre.IndexOf(nombre)], false);
                    }
                    else
                    {
                        cbImpuestos.SetItemChecked(cbImpuestos.Items.IndexOf(impuesto), false);
                    }
                    this.cbImpuestos.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbImpuestos_SelectedIndexChanged);

                    break;
                }
                else
                {
                    //Si no esta agregarlo
                    seleccionadosNombre.Add(nombre);
                    seleccionadosPosicion.Add(cbImpuestos.Items.IndexOf(impuesto));
                }


            }
        }

        private void roundedButton5_Click(object sender, EventArgs e)
        {
            PictureBox pb = new PictureBox();
            switch (imgPanelSeleccionado)
            {
                case 1:
                    pb = pictureBox1;
                    break;
                case 2:
                    pb = pictureBox2;
                    break;
                case 3:
                    pb = pictureBox3;
                    break;
                case 4:
                    pb = pictureBox4;
                    break;
                default:
                    break;
            }
            BuscarGoogle(1,pb);


        }

        private void roundedButton6_Click(object sender, EventArgs e)
        {
            PictureBox pb = new PictureBox();
            switch (imgPanelSeleccionado)
            {
                case 1:
                    pb = pictureBox1;
                    break;
                case 2:
                    pb = pictureBox2;
                    break;
                case 3:
                    pb = pictureBox3;
                    break;
                case 4:
                    pb = pictureBox4;
                    break;
                default:
                    break;
            }
            BuscarGoogle(0,pb);
        }

        //Este metodo se usa para buscar con google
        private void BuscarGoogle(int porNombre,PictureBox pb)
        {
            int intento = 1;
            List<string> urls;

            do
            {
                string html = GetHtmlCode(porNombre);
                urls = GetUrls(html);
                if (urls.Count > 0)
                    intento=5;
                else
                    intento++;
            } while (intento < 5);

           


            if (urls.Count > 0)
            {
               

                var rnd = new Random();

                byte[] image;

                intento = 0;
                do
                {
                    int randomUrl = rnd.Next(0, urls.Count - 1);

                    string luckyUrl = urls[randomUrl];

                    image = GetImage(luckyUrl);

                    if (image != null)
                        intento = 5;
                    else
                        intento++;
                } while (intento < 5);

                if (image != null)
                {
                    using (var ms = new MemoryStream(image))
                    {
                        try
                        {
                            pb.Image = Image.FromStream(ms);
                            pictureBoxP.Image = pb.Image;
                            pb.Tag = "1";
                            imagenesModificadas = true;
                        }
                        catch
                        {

                        }
                       
                    }
                }
            }
            else
            {
                MessageBox.Show("No se encontro niguna imagen");
            }

        }

        private string GetHtmlCode(int porNombre)
        {
            string buscar;
            if (porNombre == 0)
            {
                buscar = txtNombre.Text.Replace(" ","+");
            }
            else
            {
                buscar = txtCodigo.Text;
            }
            //string url = "https://www.google.com/search?q=" + buscar + "&tbm=isch";
            string url = " http://images.google.com/search?tbm=isch&q=" + buscar;
            string data = "";

            Console.WriteLine(url);

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";

            var response = (HttpWebResponse)request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                if (dataStream == null)
                    return "";
                using (var sr = new StreamReader(dataStream))
                {
                    data = sr.ReadToEnd();
                }
            }
            return data;
        }

        //Este metodo se usa para buscar con google
        private List<string> GetUrls(string html)
        {
            var urls = new List<string>();

            int pos2 = html.IndexOf(".jpg"), pos1, longitudMaxUrl=100;
           
            int i = 0;

            while (pos2 >= 0 && i<30)
            {
                //Posicion del https
                pos1 = html.LastIndexOf("http", pos2);

                //Posicion de la extension .jpg
                pos2 = html.IndexOf(".jpg", pos1);
                string url = html.Substring(pos1, (pos2 + 4 ) - pos1);

                if (!url.Contains("doodles") && !url.Contains("["))
                    urls.Add(url);

                int posAnt = pos2;

                //pos2 = html.IndexOf(".jpg", pos1+ longitudMaxUrl);
                
                //if(pos2 == posAnt)
                    pos2 = html.IndexOf(".jpg", pos2+4);

                i++;
            }
            return urls;
        }

        //Este metodo se usa para buscar con google
        private byte[] GetImage(string url)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                var response = (HttpWebResponse)request.GetResponse();

                using (Stream dataStream = response.GetResponseStream())
                {
                    if (dataStream == null)
                        return null;
                    using (var sr = new BinaryReader(dataStream))
                    {
                        byte[] bytes = sr.ReadBytes(100000000);

                        return bytes;
                    }
                }
            }
            catch
            {
                //MessageBox.Show("No se encontro niguna imagen (-1)");
                return null;
            }



        }

        private void button10_Click(object sender, EventArgs e)
        {
            pictureBoxP.Image = ValleVerde.Properties.Resources.anadir;
            pictureBox1.Image = ValleVerde.Properties.Resources.anadir;
            pictureBox2.Image = ValleVerde.Properties.Resources.anadir;
            pictureBox3.Image = ValleVerde.Properties.Resources.anadir;
            pictureBox4.Image = ValleVerde.Properties.Resources.anadir;
            pictureBox1.Tag = "-1";
            pictureBox2.Tag = "-1";
            pictureBox3.Tag = "-1";
            pictureBox4.Tag = "-1";
            imagenesModificadas = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ValleVerde.Properties.Resources.anadir;
            pictureBox1.Tag = "-1";
            imagenesModificadas = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = ValleVerde.Properties.Resources.anadir;
            pictureBox2.Tag = "-1";
            imagenesModificadas = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = ValleVerde.Properties.Resources.anadir;
            pictureBox3.Tag = "-1";
            imagenesModificadas = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            pictureBox4.Image = ValleVerde.Properties.Resources.anadir;
            pictureBox4.Tag = "-1";
            imagenesModificadas = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Blue;
            panel2.BackColor = Color.Transparent;
            panel3.BackColor = Color.Transparent;
            panel4.BackColor = Color.Transparent;
            imgPanelSeleccionado = 1;
            pictureBoxP.Image = pictureBox1.Image;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Transparent;
            panel2.BackColor = Color.Blue;
            panel3.BackColor = Color.Transparent;
            panel4.BackColor = Color.Transparent;
            imgPanelSeleccionado = 2;
            pictureBoxP.Image = pictureBox2.Image;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Transparent;
            panel2.BackColor = Color.Transparent;
            panel3.BackColor = Color.Blue;
            panel4.BackColor = Color.Transparent;
            imgPanelSeleccionado = 3;
            pictureBoxP.Image = pictureBox3.Image;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Transparent;
            panel2.BackColor = Color.Transparent;
            panel3.BackColor = Color.Transparent;
            panel4.BackColor = Color.Blue;
            imgPanelSeleccionado = 4;
            pictureBoxP.Image = pictureBox4.Image;
        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            PictureBox pb = new PictureBox();
            switch (imgPanelSeleccionado)
            {
                case 1:
                    pb = pictureBox1;
                    break;
                case 2:
                    pb = pictureBox2;
                    break;
                case 3:
                    pb = pictureBox3;
                    break;
                case 4:
                    pb = pictureBox4;
                    break;
                default:
                    break;
            }

            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBoxP.Image = new Bitmap(open.FileName);
                pb.Image = pictureBoxP.Image;
                pb.Tag = "1";
                imagenesModificadas = true;
                // image file path  
                // textBox1.Text = open.FileName;
            }
        }

        
        private void roundedButton4_Click(object sender, EventArgs e)
        {
            btnTF.Visible = true;
            CaptureCamera();
            isCameraRunning = true;

        }

        // Declare required methods
        private void CaptureCamera()
        {
            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            camera.Start();
        }

        private void CaptureCameraCallback()
        {

            frame = new Mat();
            capture = new VideoCapture(0);
            capture.Open(0);

            PictureBox pb = new PictureBox();
            switch (imgPanelSeleccionado)
            {
                case 1:
                    pb = pictureBox1;
                    break;
                case 2:
                    pb = pictureBox2;
                    break;
                case 3:
                    pb = pictureBox3;
                    break;
                case 4:
                    pb = pictureBox4;
                    break;
                default:
                    break;
            }

            if (capture.IsOpened())
            {
                while (isCameraRunning)
                {
                    try
                    {
                        capture.Read(frame);
                        image = BitmapConverter.ToBitmap(frame);
                        if (pictureBoxP.Image != null)
                        {
                            pictureBoxP.Image.Dispose();
                            pb.Image.Dispose();
                        }
                        pictureBoxP.Image = image;
                        pb.Image = pictureBoxP.Image;
                        pb.Tag = "1";
                        imagenesModificadas = true;
                    }
                    catch
                    {

                    }
                   
                }
            }
        }

        private void btnTF_Click(object sender, EventArgs e)
        {
            if (isCameraRunning)
            {
                
                // Take snapshot of the current image generate by OpenCV in the Picture Box
                //Bitmap snapshot = new Bitmap(pictureBoxC.Image);

                // Save in some directory
                // in this example, we'll generate a random filename e.g 47059681-95ed-4e95-9b50-320092a3d652.png
                // snapshot.Save(@"C:\Users\sdkca\Desktop\mysnapshot.png", ImageFormat.Png);
                //snapshot.Save("C:/TempVV/1.jpeg", ImageFormat.Jpeg);
                //snapshot.Save(string.Format(@"C:\\TempVV\\1.png", Guid.NewGuid()), ImageFormat.Png);
                capture.Release();
                isCameraRunning = false;
                btnTF.Visible = false;

            }
            else
            {
                Console.WriteLine("Cannot take picture if the camera isn't capturing image!");
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            TextInfo myTI = new CultureInfo("es-MX", false).TextInfo;
            int pos = txtNombre.SelectionStart;
            txtNombre.Text = myTI.ToTitleCase(txtNombre.Text);
            txtNombre.Select(pos,0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBoxP.SelectedItems.Count < 1)
            {
                MessageBox.Show("Debes seleccionar un proveedor primero");
            } else
            {
                proveedoresRespIDs.RemoveAt(listBoxP.SelectedIndex);
                listBoxP.Items.RemoveAt(listBoxP.SelectedIndex);
                

               
            }
        }

        private void cbClaveSAT_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnNuevaClaveSAT_Click(object sender, EventArgs e)
        {
            ClaveSAT obj = new ClaveSAT();
            obj.ShowDialog();
           

            string[] resp = obj.ObtenerRespuesta();

            obj.Dispose();

            txtCodigoSAT.Text = resp[0];
            txtDescripcionSAT.Text = resp[1];

            claveSATModificada = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            claveAdicionalModificadas = true;
            Vistas.Inventario.ClavesAdicionales obj = new Vistas.Inventario.ClavesAdicionales();
            obj.ShowDialog();

            Thread esperaRespuesta = new Thread(() => RespuestaClaveAdicional(obj));

            esperaRespuesta.Start();
            esperaRespuesta.Join();

            String[] res = obj.ObtenerRespuesta();

            if (res != null)
            {
                dvgClavesAdicionales.Rows.Add(res[0], res[1], res[2]);
                agrClaAdi = true;
            }
        }

        private void RespuestaClaveAdicional(Vistas.Inventario.ClavesAdicionales obj)
        {
            bool respuestaLista;

            do
            {
                respuestaLista = obj.RespuestaLista();
            } while (!respuestaLista);



        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtCodigoSAT.Text = "";
            txtDescripcionSAT.Text = "";
            claveSATModificada = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            claveAdicionalModificadas = true;

            if (dvgClavesAdicionales.SelectedRows.Count < 1)
            {
                MessageBox.Show("Debes seleccionar una clave adicional primero");
            }
            else
            {
                dvgClavesAdicionales.Rows.Remove(dvgClavesAdicionales.SelectedRows[0]);



            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            productoExtraModificado = true;
            Vistas.Inventario.ProductoExtra obj = new Vistas.Inventario.ProductoExtra();
            obj.ShowDialog();

            Thread esperaRespuesta = new Thread(() => RespuestaProductoExtra(obj));

            esperaRespuesta.Start();
            esperaRespuesta.Join();

            String[] res = obj.ObtenerRespuesta();

            if (res != null)
                dvgProductoExtra.Rows.Add(res[0], res[1], res[2]);
        }

        private void RespuestaProductoExtra(Vistas.Inventario.ProductoExtra obj)
        {
            bool respuestaLista;

            do
            {
                respuestaLista = obj.RespuestaLista();
            } while (!respuestaLista);



        }

        private void button6_Click(object sender, EventArgs e)
        {
            productoExtraModificado = true;

            if (dvgProductoExtra.SelectedRows.Count < 1)
            {
                MessageBox.Show("Debes seleccionar un producto extra primero");
            }
            else
            {
                dvgProductoExtra.Rows.Remove(dvgProductoExtra.SelectedRows[0]);



            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Button btnLlenar = new Button();
            new BuscarProducto(txtCodigo, btnLlenar, false).ShowDialog(this);
            codigoRecibido = txtCodigo.Text;
            txtCodigo.Text = "";

            txtNombre.Text = new ValleVerdeComun.Programacion.Producto().ObtenerNombreProducto(codigoRecibido);
            obt.SetToolTip(txtNombre, txtNombre.Text);

            txtNombre.Focus();
            txtNombre.SelectAll();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnLlenar_Click(object sender, EventArgs e)
        {
            codigoRecibido = txtCodigo.Text;
            txtCodigo.Text = "";
            
            txtNombre.Text = new ValleVerdeComun.Programacion.Producto().ObtenerNombreProducto(codigoRecibido);
            obt.SetToolTip(txtNombre,  txtNombre.Text);
            CargarListaFabricantes();
            CargarListaMarcas();
            CargarListaLineas();
            CargarListaUnidades();
            CargarImpuestos();
            CargarListaProveedores();

            txtCodigo.Select();
        }

        public string ObtenerIdProductoAgregado()
        {
            return txtCodigo.Text;
        }

        public string ObtenerUltimoIdClaveAdicionalAgregada()
        {
            if(agrClaAdi)
                return dvgClavesAdicionales.Rows[dvgClavesAdicionales.Rows.Count - 1].Cells[0].Value + "";
            else
                return "";
        }

        private void chkPidePeso_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPidePeso.Checked)
            {
                lblMerma.Visible = true;
                txtMerma.Visible = true;
                txtMerma.Text = new ValleVerdeComun.Programacion.Producto().ObtenerMerma(txtCodigo.Text)+"";
            }
            else
            {
                lblMerma.Visible = false;
                txtMerma.Visible = false;
                txtMerma.Text = "0";
            }
        }

        private void roundedButton2_Click_1(object sender, EventArgs e)
        {
            Button btnLlenar = new Button();
            btnLlenar.Click += new EventHandler(btnLlenar_Click);
            new BuscarProducto(txtCodigo, btnLlenar, false).ShowDialog(this);
            txtCodigo.Focus();
            txtCodigo.SelectAll();
        }

        private void roundedButton7_Click(object sender, EventArgs e)
        {
            Button btnLlenar = new Button();
            btnLlenar.Click += new EventHandler(btnLlenar_Precios);
            new BuscarProducto(txtCodigo, btnLlenar, false).ShowDialog(this);
            txtCodigo.Focus();
            txtCodigo.SelectAll();
        }

        private void btnLlenar_Precios(object sender, EventArgs e)
        {
            codigoRecibido = txtCodigo.Text;
            txtCodigo.Text = "";

            //txtNombre.Text = new ValleVerdeComun.Programacion.Producto().ObtenerNombreProducto(codigoRecibido);
            //obt.SetToolTip(txtNombre, txtNombre.Text);

            objPrecios.CargarPreciosCosto(codigoRecibido, ref precios);

            txtCosto.Focus();
            txtCosto.Select();
        }
    }
}
