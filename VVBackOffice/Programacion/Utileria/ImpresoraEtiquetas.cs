using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion.Utileria;
using Zebra.Sdk.Comm;

namespace ValleVerde
{
    public class ImpresoraEtiquetas
    {
        CHistorialImpresion cHistorial = new CHistorialImpresion();
        ClaseCodigosPreescaneados codigosPreescaneados = new ClaseCodigosPreescaneados();
        private string zplData = "";
        string fecha = DateTime.Now.ToString("dd/MM/yyyy");
        private bool EsClaveAdicional;
        private string IDUsuario;
        private string IDProducto;
        private string ponerFecha;
        
        public bool SendZplOverUsb(string printerName, string CodigoProducto, bool TipoEtiqueta, int cantidad, bool etiquetacambioprecio, bool etiquetapreescaneada, bool checkFecha)
        {
            // Instantiate connection for ZPL USB port for given printer name
            Connection thePrinterConn = new DriverPrinterConnection(printerName);
            try
            {
                // Open the connection - physical connection is established here.
                thePrinterConn.Open();

                // This example prints "This is a ZPL test." near the top of the label.
                if (TipoEtiqueta)
                {
                    zplData = EtiquetaConPrecio(CodigoProducto);
                    
                }
                else
                {
                    zplData = EtiquetaSinPrecio(CodigoProducto, checkFecha);
                }

                // Send the data to printer as a byte array.
                if (!String.IsNullOrEmpty(zplData))
                {
                    string original = zplData;
                    for (int i = 1; i < cantidad; i++)
                    {
                        zplData += original;
                    }
                    thePrinterConn.Write(Encoding.UTF8.GetBytes(zplData));

                    if(etiquetapreescaneada)
                    {
                        codigosPreescaneados.BorrarEtiquetas(IDProducto);
                    }

                    cHistorial.AgregarHistorialEtiquetasImpresas(IDUsuario, IDProducto, cantidad, TipoEtiqueta, etiquetacambioprecio);
                }

            }
            catch (ConnectionException ex)
            {
                // Handle communications error here.
                MessageBox.Show("Verifique que la impresora este conectada", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //IDUsuario = "1";
                //IDProducto = CodigoProducto;
                //cHistorial.AgregarHistorialEtiquetasImpresas(IDUsuario, IDProducto, cantidad, TipoEtiqueta, etiquetacambioprecio);
            }
            finally
            {
                // Close the connection to release resources.
                thePrinterConn.Close();
            }
            return true;
        }

        #region String Etiqueta Con o Sin Precio
        
        private string PrecioTarjetaVacio(decimal precio1, decimal precioTarjeta, decimal costoTarjeta, bool Varios)
        {
            if (Varios)
            {
                string[] log = TamanoPrecioPrincipal(precio1, costoTarjeta);
                if (costoTarjeta != 0)
                {

                    return $@"
^FT{log[1]},210 
^A0N,20,20^FH\
^FDTarjeta:{FormatPrecio(precioTarjeta)}^FS";
                }
                return "";
            }
            else
            {
                string[] log = TamanoPrecioPrincipal(precio1, precioTarjeta);
                if (costoTarjeta != 0)
                {

                    return $@"
^FT{log[1]},270 
^A0N,20,20^FH\
^FDTarjeta:{FormatPrecio(precioTarjeta)}^FS";
                }
                return "";
            }
        }
        private string FormatPrecio(decimal precio)
        {
            return String.Format("{0:C}", precio);
        }
        #region Tamaño del Nombre separacion y del Codigo de Barras
        private string TamanoCodigoBarras(int tamano)//Metodo para verificar el tamaño del codigo de barras
        {
            //Le mando el espaciado de donde va estar el codigo de barras
            if (tamano >= 0 && tamano <= 3)
                return "150";
            else if (tamano >= 4 && tamano <= 6)
                return "125";
            else if (tamano >= 7 && tamano <= 8)
                return "100";
            else
                return "40";
        }

        private string[] NombreProductoSeparado(string nombreproducto)
        {          
            string[] nombreseparado = new string[4];
            nombreseparado[3] =
$@"^FO0,25^GFA,01792,01792,00056,:Z64:
eJxjYBgFo2AUjAL8oP4/WeDPUNE30OE7CgYGAABXIN0V:75E7
^FT50,35^A0N,28,28^FB335,1,0,C^FH\^FDVALLE VERDE {fecha}^FS";
            if (nombreproducto.Length <= 27)
            {
                nombreseparado[0] = nombreproducto;
                return nombreseparado;
            }
            else if(nombreproducto.Length <= 54)
            {
                nombreseparado[0] = nombreproducto.Substring(0, 27);
                nombreseparado[1] = nombreproducto.Substring(27);
                return nombreseparado;
            }
            else
            {
                nombreseparado[2] =
$@"^FT0,45,2^A0N,28,28^FB450,1,0,C,0
^FH\^FD{ nombreproducto.Substring(0, 27)}^FS
^FT440,280^A0B,15,20^FB335,1,0,C^FH\^FD{fecha}^FS";
                nombreseparado[0] = nombreproducto.Substring(27, 27);
                if (nombreproducto.Length <= 81)
                    nombreseparado[1] = nombreproducto.Substring(54, nombreproducto.Length-54);
                else
                    nombreseparado[1] = nombreproducto.Substring(54, 27);
                nombreseparado[3] = "";
                return nombreseparado;
            }
        }
        #endregion
        #region Tamaños de los precios 1,2,3
        private string[] TamanoPrecioPrincipal(decimal precio, decimal costoTarj1)
        {
            string[] log = new string[2];
            if (costoTarj1 == 0)
            {
                log[0] = "100";
                return log;
            }
            int longitud = precio.ToString().Replace(".", "").Replace(",", "").Length;
            if (longitud >= 1 && longitud <= 2)
            {
                log[0] = "40";//Precio MEN
                log[1] = "270";//Precio Tarj1
                return log;
            }
            else if (longitud >= 3 && longitud <= 4)
            {
                log[0] = "30";//Precio MEN
                log[1] = "265";//Precio Tarj1
                return log;
            }
            else if(longitud == 5)
            {
                log[0] = "10";
                log[1] = "265";
            }
            else if (longitud >= 6 && longitud <= 7)
            {
                log[0] = "0";//Precio MEN
                log[1] = "290";//Precio Tarj1
                return log;
            }
            return log;
        }
        private string[] TamanoPrecioSecundario(decimal precio2)
        {
            string[] log2 = new string[8];
            int longitud = precio2.ToString().Replace(".", "").Replace(",", "").Length;
            if (longitud >= 1 && longitud <= 2)
            {
                log2[0] = "50";//Precio2
                log2[1] = "20";//Precio2 Tot:
                log2[2] = "30";//PrecioTarj2
                log2[3] = "30";//PrecioTarj2 Tot:

                log2[4] = "270";//Precio3
                log2[5] = "250";//Precio3 Tot:
                log2[6] = "260";//PrecioTarj3
                log2[7] = "260";//PrecioTarj3 Tot:
                return log2;
            }
            else if (longitud >= 3 && longitud <= 4)
            {
                log2[0] = "40";
                log2[1] = "10";
                log2[2] = "50";
                log2[3] = "50";

                log2[4] = "270";
                log2[5] = "250";
                log2[6] = "270";
                log2[7] = "270";
                return log2;
            }
            else if(longitud == 5)
            {
                log2[0] = "30";
                log2[1] = "5";
                log2[2] = "60";
                log2[3] = "60";

                log2[4] = "240";
                log2[5] = "230";
                log2[6] = "280";
                log2[7] = "280";
                return log2;
            }
            else if (longitud >= 5 && longitud <= 7)
            {
                log2[0] = "20";
                log2[1] = "0";
                log2[2] = "70";
                log2[3] = "70";

                log2[4] = "230";
                log2[5] = "230";
                log2[6] = "300";
                log2[7] = "300";
                return log2;
            }
            return log2;
        }

        #endregion
        #region Metodos para añadir precios 2 y 3
        //Metodo para añadir los precios
        private string AddCantidadesPrecios(decimal cantidad2, decimal cantidad3, decimal precio2, decimal precio3, decimal costoTarj2, decimal costoTarj3, decimal precioTarj2, decimal precioTarj3)
        {
            string[] log2 = TamanoPrecioSecundario(precio2);
            string strprecio2Cent = $@"
^FT22,270^A0N,24,24^FB177,1,0,C^FH\^FDPor {cantidad2} piezas^FS
^FT22,295^A0N,24,24^FB177,1,0,C^FH\^FD{FormatPrecio(precio2)}^FS
^FT22,320^A0N,24,24^FB177,1,0,C^FH\^FDTot: {FormatPrecio(precio2 * cantidad2)}^FS";
            string strprecio3Cent = $@"
^FT230,270^A0N,24,24^FB177,1,0,C^FH\^FDPor {cantidad3} piezas^FS
^FT230,295^A0N,24,24^FB177,1,0,C^FH\^FD{FormatPrecio(precio3)}^FS
^FT230,320^A0N,24,24^FB177,1,0,C^FH\^FDTot: {FormatPrecio(precio3 * cantidad3)}^FS";
            string strprecio2 = $@"
^FT0,268^A0N,24,24^FB160,1,0,L^FH\^FDPor {cantidad2} piezas^FS
^FT{log2[0]},295^A0N,20,20^FB160,1,0,L^FH\^FD{FormatPrecio(precio2)}^FS
^FT{log2[1]},320^A0N,20,20^FB160,1,0,L^FH\^FDTot:{FormatPrecio(precio2 * cantidad2)}^FS";
            string strprecio3 = $@"
^FT230,268^A0N,24,24
^FB160,1,0,L^FH\^FDPor {cantidad3} piezas^FS
^FT{log2[4]},295^A0N,20,20^FB160,1,0,L^FH\^FD{FormatPrecio(precio3)}^FS
^FT{log2[5]},320^A0N,20,20^FB160,1,0,L^FH\^FDTot:{FormatPrecio(precio3 * cantidad3)}^FS";
            string strpreciotarj2 = $@"
^FT100,270^A0N,15,15^FB150,1,0,C^FH\^FDTarjeta^FS
^FT{log2[2]},290^A0N,15,18^FB150,1,0,R^FH\^FD{FormatPrecio(precioTarj2)}^FS
^FT{log2[3]},310^A0N,15,18^FB150,1,0,R^FH\^FD{FormatPrecio(precioTarj2 * cantidad2)}^FS";
            string strpreciotarj3 = $@"
^FT320,270^A0N,15,15^FB150,1,0,C^FH\^FDTarjeta^FS
^FT{log2[6]},290^A0N,15,18^FB150,1,0,R^FH\^FD{FormatPrecio(precioTarj3)}^FS
^FT{log2[7]},310^A0N,15,18^FB150,1,0,R^FH\^FD{FormatPrecio(precioTarj3 * cantidad3)}^FS";
            string addprecio = "";
            //Si las cantidades son 0 entonces no se añade nada
            if (cantidad2 == 0 && cantidad3 == 0)
            {
                return addprecio;
            }
            else if (cantidad2 != 0 && cantidad3 == 0)
            {
                addprecio = strprecio2Cent;
                if (costoTarj2 != 0)
                {
                    addprecio = strprecio2 + strpreciotarj2;
                }
                return addprecio;
            }
            else if (cantidad2 == 0 && cantidad3 != 0)
            {
                addprecio = strprecio3Cent;

                if (costoTarj3 != 0)
                {
                    addprecio = strprecio3 + strpreciotarj3;
                }
                return addprecio;

            }
            else //Si los dos tiene cantidades entonces se les manda el formato
            {
                addprecio = strprecio2Cent + strprecio3Cent;
                if (costoTarj2 != 0 && costoTarj3 == 0)
                {
                    addprecio = strprecio2 + strpreciotarj2 + strprecio3Cent;
                    return addprecio;
                }
                if (costoTarj2 == 0 && costoTarj3 != 0)
                {
                    addprecio = strprecio2Cent + strprecio3 + strpreciotarj3;
                    return addprecio;
                }
                if (costoTarj2 != 0 && costoTarj3 != 0)
                {
                    addprecio = strprecio2 + strpreciotarj2 + strprecio3 + strpreciotarj3;
                    return addprecio;
                }
                return addprecio;
            }
        }

        #endregion
        private string EtiquetaUnPrecio(string[] nombreproducto, string tamanobarras, string codigoproducto, string[] log, string precioTarj1, decimal precio1)
        {
            return 
$@"^XA
^CI28
^MMT
^PW448
^LL0336
^LS0
{nombreproducto[3]}
{nombreproducto[2]}
^FT0,90,2^A0N,28,28^FB450,1,0,C,0
^FH\^FD{nombreproducto[0]}^FS
^FT0,120,2^A0N,28,28^FB450,1,0,C,0
^FH\^FD{nombreproducto[1]}^FS
^BY2,3,50^FO{tamanobarras},170,2^BCN,,Y,N
^FD{codigoproducto}^FS
^FT{log[0]},300^A0N,45,45^FH\^FDMEN: {FormatPrecio(precio1)}^FS
{precioTarj1}
^PQ1,0,1,Y^XZ";
        }

        private string EtiquetaVariosPrecios(string[] nombreproducto, string tamanobarras, string codigoproducto, string log, decimal precio1, string precioTarj1, string imprimirprecios)
        {
            return
$@"^XA
^CI28
^MMT
^PW448
^LL0336
^LS0
^FO0,215^GFA,01792,01792,00056,:Z64:
eJxjYBgFo2AUjIKRDer/kwX+DBV9Ax2+gxUAANpC3RU=:E98E
{nombreproducto[3]}
{nombreproducto[2]}
^FO219,240^GB0,100,3^FS
^FT0,72,2^A0N,28,28^FB450,1,0,C,0
^FH\^FD{nombreproducto[0]}^FS
^FT0,105,2^A0N,28,28^FB450,1,0,C,0
^FH\^FD{nombreproducto[1]}^FS
^BY2,3,30^FO{tamanobarras},130,2^BCN,,Y,N
^FD{codigoproducto}^FS
^FT{log},225^A0N,45,45^FH\^FDMEN: {FormatPrecio(precio1)}^FS
{precioTarj1}
{imprimirprecios}
^PQ1,0,1,Y^XZ";
        }
        private string EtiquetaConPrecio(string codigoproducto)
        {
            string zplData;
            //Instanciamos la clase que se llama obtener
            ObtenerProductoPrecioTop obtener = new ObtenerProductoPrecioTop();
            //La variable nombre obtene el metodo de Obtenernombre del producto
            ProductoPrecioTop nombre = obtener.Obtenernombreproducto(codigoproducto);
            if (nombre == null)
                MessageBox.Show("No existe producto", "¡ADVERTENCIA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                //ValleVerdeComun.Vistas.InicioSesion.InicioSesion obi = new ValleVerdeComun.Vistas.InicioSesion.InicioSesion(false);
                //obi.ShowDialog();

                //ValleVerdeComun.Programacion.Huellas.ResultadoHuella usuario = obi.usuario;

                //if (usuario != null)
                //{
                    IDUsuario = "1";//usuario.IDUsuario;
                     //obi.Close();
                     //String para que no exceda el nombre del tamaño
                    string[] tamanombreproducto = NombreProductoSeparado(nombre.nombreproducto);
                    //String para cambiar la posicion del codigo de barras
                    string tamanobarras = TamanoCodigoBarras(codigoproducto.Length);

                    EsClaveAdicional = obtener.ComprobarClaveAdicional(codigoproducto);
                    if (EsClaveAdicional)
                    {
                        IDProducto = "";

                        ProductoPrecioTop preciosClave = obtener.ObtenerprecioproductoClaveAdicional(codigoproducto);

                        string[] log = TamanoPrecioPrincipal(preciosClave.precioClaveAdicional, preciosClave.costoTarjClaveAdicional);

                        string precioTarjeta1 = PrecioTarjetaVacio(preciosClave.precioClaveAdicional, preciosClave.precioTarjClaveAdicional, preciosClave.costoTarjClaveAdicional, false);

                        zplData = EtiquetaUnPrecio(tamanombreproducto, tamanobarras, codigoproducto, log, precioTarjeta1, preciosClave.precioClaveAdicional);
                        return zplData;
                    }
                    else
                    {
                        IDProducto = codigoproducto;

                        //La variable de cantidad obtiene el metodo de Obtenercantidad para recibir las cantidades de ese producto
                        ProductoPrecioTop cantidad = obtener.Obtenercantidadproductopreciotop(codigoproducto);

                        //La variable de precios obtiene el metodo de Obtenerprecios para recibir los precios de las cantidades
                        ProductoPrecioTop precios = obtener.Obtenerprecioproductopreciotop(codigoproducto);
                        //La variable de precios obtiene el metodo de Obtenerpreciostarjeta para recibir los precios de tarjeta 
                        ProductoPrecioTop preciosTarj = obtener.Obtenerprecioproductotarjeta(codigoproducto);

                    if (precios != null)
                    {
                        string[] log = TamanoPrecioPrincipal(precios.precio1, preciosTarj.costoTarj1);

                        string precioTarjeta1 = PrecioTarjetaVacio(precios.precio1, preciosTarj.preciotarj1, preciosTarj.costoTarj1, true);

                        //String para imprimir si va a llevar dos precios o tres precios
                        string imprimirprecios = AddCantidadesPrecios(cantidad.cantidad2, cantidad.cantidad3, precios.precio2, precios.precio3, preciosTarj.costoTarj2, preciosTarj.costoTarj3, preciosTarj.preciotarj2, preciosTarj.preciotarj3);

                        if (cantidad.cantidad2 == 0 && cantidad.cantidad3 == 0)
                        {
                            zplData = EtiquetaUnPrecio(tamanombreproducto, tamanobarras, codigoproducto, log, precioTarjeta1, precios.precio1);
                            return zplData;
                        }
                        else
                        {
                            //Creamos un string que se le añaderan las varibles instanciadas para devolver nombre, cantidad, precio
                            zplData = EtiquetaVariosPrecios(tamanombreproducto, tamanobarras, codigoproducto, log[0], precios.precio1, precioTarjeta1, imprimirprecios);
                            return zplData;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Producto Existente pero no cuenta con precio", "¡ADVERTENCIA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    //}
                }
            }
            return "";
        }
        private string EtiquetaSinPrecio(string codigoproducto, bool checkFecha)
        {

            ObtenerProductoPrecioTop obtener = new ObtenerProductoPrecioTop();
            ProductoPrecioTop nombre = obtener.Obtenernombreproducto(codigoproducto);
            if (nombre == null)
                MessageBox.Show("No existe producto", "¡ADVERTENCIA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                //ValleVerdeComun.Vistas.InicioSesion.InicioSesion obi = new ValleVerdeComun.Vistas.InicioSesion.InicioSesion(false);
                //obi.ShowDialog();

                //ValleVerdeComun.Programacion.Huellas.ResultadoHuella usuario = obi.usuario;

                //if (usuario != null)
                //{
                    IDUsuario = "1";//usuario.IDUsuario;
                    //obi.Close();
                    string tamanobarras = TamanoCodigoBarras(codigoproducto.Length);

                    EsClaveAdicional = obtener.ComprobarClaveAdicional(codigoproducto);
                    if (EsClaveAdicional)
                    {
                        IDProducto = "";
                    }
                    else
                    {
                        IDProducto = codigoproducto;
                    }

                    if (checkFecha)
                        ponerFecha = fecha;
                    else
                        ponerFecha = "";

                    string[] tamanombreproducto = NombreProductoSeparado(nombre.nombreproducto);

                    string zplData =
$@"^XA
^CI28
^MMT
^PW448
^LL0336
^LS0
^FO0,32^GFA,01792,01792,00056,:Z64:
eJxjYBgFo2AUjAL8oP4/WeDPUNE30OE7CgYGAABXIN0V:75E7
^FT50,35^A0N,28,28^FB335,1,0,C^FH\^FDVALLE VERDE {ponerFecha}^FS
^FT0,90,2^A0N,28,30^FB450,1,0,C,0
^FH\^FD{tamanombreproducto[0]}^FS
^FT0,120,2^A0N,28,30^FB450,1,0,C,0
^FH\^FD{tamanombreproducto[1]}^FS
^FT0,150,2^A0N,28,30^FB450,1,0,C,0
^FH\^FD{tamanombreproducto[2]}^FS
^BY2,3,74^FO{tamanobarras},170,2^BCN,,Y,N
^FD{codigoproducto}^FS
^PQ1,0,1,Y^XZ";                   
                    return zplData;
                //}
            }
            return "";
        }
        #endregion
    }
}
