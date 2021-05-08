using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion;
using ValleVerde.Programacion.Gastos;
using ValleVerde.Programacion.RecursosHumanos;
using ValleVerde.Programacion.Utileria;
using ValleVerde.Programacion.Ventas;
using ValleVerde.Vistas;
using ValleVerde.Vistas.Compras;
using ValleVerde.Vistas.Configuracion;
using ValleVerde.Vistas.Inventario;
using ValleVerde.Vistas.RecursosHumanos;
using ValleVerde.Vistas.Utileria;
using ValleVerde.Vistas.Ventas;
using ValleVerdeComun.Programacion;

namespace ValleVerde
{
    public partial class Formulario : ValleVerdeComun.Programacion.InterfazPrincipal
    {
        ValleVerdeComun.Programacion.Huellas.ResultadoHuella usuario;
        private bool showPic;

        int i = 0;
        public Formulario(ValleVerdeComun.Programacion.Huellas.ResultadoHuella usuario, ValleVerdeComun.Programacion.ConfiguracionBO configuracion)
        {
            ////Corregir cadena de conexion de los data set
            //ValleVerdeComun.ConexionBD obc = new ValleVerdeComun.ConexionBD();
            //obc.AbrirConexionBD();
            //string cs = obc.ObtenerCadenaConexion();

            //Properties.Settings.Default["valleverdeConnectionString"] = cs;
            //Properties.Settings.Default["valleverdeConnectionStringRemoto"] = cs;

            //Properties.Settings.Default.Save();
            //obc.CerrarConexionBD();
            InitializeComponent();
            //EtiquetasNoImpresas();

            this.MinimumSize = new Size(0, 0);
            tabControlPrincipal.MinimumSize = new Size(0, 0);

            //Local
            this.configuracionBO = configuracion;
            this.usuario = usuario;

            //Global
            configuracionGlobal = new ValleVerdeComun.Programacion.ConfiguracionGlobal().ObtenerConfiguracionGlobal();


            //Si Movivendor esta configurado cargar los productos de recargas y servicios
            //en nuevo hilo para no retrasar el inicio del programa
            if ((configuracionGlobal.movivendor_idcanal_recargas != "" && configuracionGlobal.movivendor_ident_recargas != "" && configuracionGlobal.movivendor_pwd_recargas != "")
                || configuracionGlobal.movivendor_idcanal_servicios != "" && configuracionGlobal.movivendor_ident_servicios != "" && configuracionGlobal.movivendor_pwd_servicios != "")
            {
                ObtenerResultadosCargarMovivendor = new ValleVerdeComun.Programacion.DelegateObtenerResultadosCargarObjetoMovivendor(this.ResultadoCargarMovivendor);
                Thread t = new Thread(new ThreadStart(CargarMovivendor));
                t.Start();

            }

            //Configurar impresoras
            impresoraTickets = new PrintDocument();
            impresoraTickets.PrintController = new StandardPrintController();

            impresoraTickets.PrinterSettings.PrinterName = configuracion.ImpresoraTickets;

            generarTicket = new ValleVerdeComun.Programacion.GenerarTicket(null,configuracionBO, configuracionGlobal, impresoraTickets);
        }

        private void CargarMovivendor()
        {
            new ValleVerdeComun.Programacion.Movivendor.MovivendorMetodos(this);
        }

        private void ResultadoCargarMovivendor(ValleVerdeComun.Programacion.Movivendor.MovivendorMetodos obMovivendor)
        {
            this.obMovivendor = obMovivendor;
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            tabControlPrincipal.SelectedTab = tabPage1;
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            tabControlPrincipal.SelectedTab = tabPage2;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            tabControlPrincipal.SelectedTab = tabPage3;
        }

        private void roundedButton4_Click(object sender, EventArgs e)
        {
            tabControlPrincipal.SelectedTab = tabPage6;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.horaLabel.Text = DateTime.Now.ToLocalTime().ToString();
            if (i == 60)
            {
                EtiquetasNoImpresas();
                i = 0;
                controlmetas1.Dia();
                controlmetas2.Mes();

            }
            i++;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            EditarFavoritos obj = new EditarFavoritos();
            obj.ShowDialog();
        }

        private void roundedButton6_Click(object sender, EventArgs e)
        {
            tabControlPrincipal.SelectedTab = tabPage4;
        }

        private void roundedButton5_Click(object sender, EventArgs e)
        {
            tabControlPrincipal.SelectedTab = tabPage5;
        }

        private void roundedButton7_Click(object sender, EventArgs e)
        {
            tabControlPrincipal.SelectedTab = tabPage8;
        }

        private void horaLabel_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControlPrincipal.Appearance = TabAppearance.FlatButtons;
            tabControlPrincipal.ItemSize = new Size(0, 1);
            tabControlPrincipal.SizeMode = TabSizeMode.Fixed;

            controlmetas1.Dia();
            controlmetas2.Mes();

            VerificarPermisos();

            //this.Size = new Size(1280,1024);
            //this.WindowState = FormWindowState.Normal;
        }

        private void VerificarPermisos()
        {
            PermisosUsuario permisos = new Usuarios().ObtenerPermisosUsuario(this.usuario.IDUsuario);

            //Desabilitar todos los botones a los que no tiene acceso el usuario que inicio sesion

            //Compras
            if (!permisos.CotizacionCompras)
                tableLayoutPanel7.Controls.Remove(button80);
            if (!permisos.RecibirCotizacion)
                tableLayoutPanel7.Controls.Remove(button66);
            if (!permisos.GenerarPedidoCompras)
                tableLayoutPanel7.Controls.Remove(button65);
            if (!permisos.RecibirPedidoCompras)
                tableLayoutPanel7.Controls.Remove(button67);
            if (!permisos.HistorialCompras)
                tableLayoutPanel7.Controls.Remove(button64);
            if (!permisos.AdministrarProveedores)
                tableLayoutPanel7.Controls.Remove(btnProveedores);
            if (!permisos.EliminarProveedor)
                tableLayoutPanel7.Controls.Remove(button70);
            if (!permisos.VerDevolucionesCompras)
                tableLayoutPanel7.Controls.Remove(button71);
            if (!permisos.HacerDevolucionesCompras)
                tableLayoutPanel7.Controls.Remove(button72);
            if (!permisos.VerComprasCredito)
                tableLayoutPanel7.Controls.Remove(button73);


            ReorganizarTableLayout(tableLayoutPanel7, roundedButton2);

            //Ventas
            if (!permisos.VerVentas)
                tableLayoutPanel2.Controls.Remove(button13);
            if (!permisos.VerFacturas)
                tableLayoutPanel2.Controls.Remove(button14);
            if (!permisos.GenerarFacturas)
                tableLayoutPanel2.Controls.Remove(button15);
            if (!permisos.VerCreditosVentas)
                tableLayoutPanel2.Controls.Remove(button16);
            if (!permisos.Promociones)
                tableLayoutPanel2.Controls.Remove(button87);

            ReorganizarTableLayout(tableLayoutPanel2, roundedButton3);

            //Inventario
            if (!permisos.AltaProducto)
                tableLayoutPanel3.Controls.Remove(button23);
            if (!permisos.PrecapturarProducto)
                tableLayoutPanel3.Controls.Remove(button26);
            if (!permisos.ModificarProducto)
            {
                tableLayoutPanel3.Controls.Remove(button24);
                tableLayoutPanel3.Controls.Remove(button45);
            }
            if (!permisos.EliminarProducto) 
                tableLayoutPanel3.Controls.Remove(button25);
            if (!permisos.ActualizarUbicacion)
                tableLayoutPanel3.Controls.Remove(button51);
            if (!permisos.AjustarPrecio)
                tableLayoutPanel3.Controls.Remove(button29);
            if (!permisos.ReporteExistencias)
                tableLayoutPanel3.Controls.Remove(button28);
            if (!permisos.TraspasarMercancia)
                tableLayoutPanel3.Controls.Remove(button30);
            if (!permisos.AdministrarEntradasSalidas)
                tableLayoutPanel3.Controls.Remove(button32);
            if (!permisos.RegistrarEntrada)
                tableLayoutPanel3.Controls.Remove(button33);
            if (!permisos.RegistrarSalida)
                tableLayoutPanel3.Controls.Remove(button34);
            if (!permisos.AdministrarFabricantes)
                tableLayoutPanel3.Controls.Remove(button39);
            if (!permisos.AdministrarMarcas)
                tableLayoutPanel3.Controls.Remove(button38);
            if (!permisos.AdministrarLineas)
                tableLayoutPanel3.Controls.Remove(button37);
            if (!permisos.AdministrarAlmacenes)
                tableLayoutPanel3.Controls.Remove(button35);
            if (!permisos.AdministrarUnidades)
                tableLayoutPanel3.Controls.Remove(button36);
            if (!permisos.AdministrarInmobiliario)
                tableLayoutPanel3.Controls.Remove(btnInmobiliario);


            ReorganizarTableLayout(tableLayoutPanel3, roundedButton6);

            //Recursos humanos
            if (!permisos.AltaEmpleado)
                tableLayoutPanel8.Controls.Remove(button74);
            if (!permisos.ModificarEmpleado)
            {
                tableLayoutPanel8.Controls.Remove(button75);
                tableLayoutPanel8.Controls.Remove(button81);
            }
            if (!permisos.BajaEmpleado)
                tableLayoutPanel8.Controls.Remove(button76);
            if (!permisos.VerExEmpleados)
                tableLayoutPanel8.Controls.Remove(button79);
            if (!permisos.AdministrarHorarios)
                tableLayoutPanel8.Controls.Remove(button83);
            if (!permisos.AdministrarBonosPenalizaciones)
                tableLayoutPanel8.Controls.Remove(btnBonosyPenalizacion);
            if (!permisos.AdministrarPermisosRoles)
                tableLayoutPanel8.Controls.Remove(btnPermisos);
            if (!permisos.AltaCliente)
                tableLayoutPanel8.Controls.Remove(btnAltaCliente);
            if (!permisos.ModificarCliente)
                tableLayoutPanel8.Controls.Remove(btnModificarCliente);
            if (!permisos.BajaCliente)
                tableLayoutPanel8.Controls.Remove(btnBajaCliente);

            ReorganizarTableLayout(tableLayoutPanel8, roundedButton5);

            //Reportes
            if (!permisos.ReporteVentas)
                tableLayoutPanel5.Controls.Remove(button43);
            if (!permisos.ReporteCompras)
                tableLayoutPanel5.Controls.Remove(button44);
            if (!permisos.ReporteEmpleados)
                tableLayoutPanel5.Controls.Remove(button77);
            if (!permisos.ReporteFinanzas)
                tableLayoutPanel5.Controls.Remove(button78);
            if (!permisos.ReporteChecador)
                tableLayoutPanel5.Controls.Remove(button82);

            ReorganizarTableLayout(tableLayoutPanel5, roundedButton4);

            //Utileria
            //if (!permisos.Checador)
            //{
            //    tableLayoutPanel6.Controls.Remove(button12);
            //    tableLayoutPanel6.Controls.Remove(button55);
            //}
            if (!permisos.ImportarProductosExcel)
                tableLayoutPanel6.Controls.Remove(button57);
            if (!permisos.Presupuestos)
                tableLayoutPanel6.Controls.Remove(button60);
            if (!permisos.VerificarInventario)
                tableLayoutPanel6.Controls.Remove(button84);
            if (!permisos.Gastos)
                tableLayoutPanel6.Controls.Remove(button56);
            if (!permisos.Gafete)
                tableLayoutPanel6.Controls.Remove(btnGafete);

            ReorganizarTableLayout(tableLayoutPanel6, roundedButton10);

            //Configuracion
            if (!permisos.ConfiguracionBackOffice)
                tlBotonesMenu.Controls.Remove(roundedButton7);


        }

        private void ReorganizarTableLayout(TableLayoutPanel tl, Button boton) 
        {
            //Reorganizar con los controles que quedaron
            int r = 0, c = 0;
            for (int ren = 0; ren < tl.RowCount; ren++)
            {
                for (int col = 0; col < tl.ColumnCount; col++)
                {
                    Control control = tl.GetControlFromPosition(col, ren);

                    if (control != null)
                        tl.SetCellPosition(control, new TableLayoutPanelCellPosition(c++, r));

                    if (c >= tl.ColumnCount)
                    {
                        r++;
                        c = 0;
                    }
                }
            }

            if (r == 0 && c == 0)
                boton.Visible = false;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            AltaProducto obj = new AltaProducto(false, "", true);
            obj.Show();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            new AdministrarEntradasSalidas().Show();
        }


        private void button31_Click_1(object sender, EventArgs e)
        {
            new ValleVerdeComun.BuscarProducto(null, null, false).ShowDialog(this);
        }

        private void roundedButton10_Click(object sender, EventArgs e)
        {
            tabControlPrincipal.SelectedTab = tabPage7;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            new BuscarProductoModificar(true).Show();

        }

        private void button25_Click(object sender, EventArgs e)
        {
            new EliminarProducto().ShowDialog();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            AltaProducto obj = new AltaProducto(true, "", true);
            obj.Text = "Precaptura de Producto";
            obj.Show();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            new AjustarPrecio().ShowDialog();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            new ReporteExistencias().Show();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            new TraspasoMercancia().Show();
        }

        private void button27_Click_1(object sender, EventArgs e)
        {
            new ValleVerdeComun.VerificadorDePrecios().Show();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            new RegistrarEntrada(0, usuario.IDUsuario).Show();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            new RegistrarEntrada(1, usuario.IDUsuario).Show();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            new Unidades().Show();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            new Almacenes().Show();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            new Marcas().Show();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            new Lineas().Show();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            new Fabricantes().Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Permisos obj = new Permisos();
            obj.Show();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            Tickets obj = new Tickets();
            obj.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ValleVerdeComun.Vistas.VerVentas obj = new ValleVerdeComun.Vistas.VerVentas(this,null,configuracionBO,obMovivendor);
            obj.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            FacturasVer obj = new FacturasVer();
            obj.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            FacturasGenerar obj = new FacturasGenerar();
            obj.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //Creditos
            ClientesBuscar obj = new ClientesBuscar();
            obj.datosUsuario(usuario.IDUsuario, usuario.Nombres);
            obj.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ClientesAgregar obj = new ClientesAgregar();
            obj.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            ClientesModificar obj = new ClientesModificar();
            obj.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            ClientesEliminar obj = new ClientesEliminar();
            obj.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            DevolucionesVer obj = new DevolucionesVer();
            obj.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            DevolucionesHacer obj = new DevolucionesHacer();
            obj.Show();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            ReportesVentas obj = new ReportesVentas();
            obj.Show();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            ReportesCompras obj = new ReportesCompras();
            obj.Show();
        }

        private void button43_Click(object sender, EventArgs e)
        {
            ReportesEmpleados obj = new ReportesEmpleados();
            obj.Show();
        }

        private void button44_Click(object sender, EventArgs e)
        {
            Finanzas obj = new Finanzas();
            obj.Show();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            Metas obj = new Metas();
            obj.Show();
        }

        private void button45_Click(object sender, EventArgs e)
        {

        }

        private void button52_Click(object sender, EventArgs e)
        {

        }

        private void button45_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button64_Click(object sender, EventArgs e)
        {
            Vistas.Compras.HistorialCompras obj = new Vistas.Compras.HistorialCompras();
            obj.Show();
        }

        private void button68_Click(object sender, EventArgs e)
        {
            Vistas.Compras.ProveedorAgregar obj = new Vistas.Compras.ProveedorAgregar();
            obj.Show();
        }

        private void button69_Click(object sender, EventArgs e)
        {
            Vistas.Compras.ProveedorModificar obj = new Vistas.Compras.ProveedorModificar();
            obj.Show();
        }

        private void button70_Click(object sender, EventArgs e)
        {
            Vistas.Compras.ProveedorEliminar obj = new Vistas.Compras.ProveedorEliminar();
            obj.Show();
        }

        private void button65_Click(object sender, EventArgs e)
        {
            Vistas.Compras.ComprasSugeridas obj = new Vistas.Compras.ComprasSugeridas();
            obj.Show();
        }

        private void button66_Click(object sender, EventArgs e)
        {
            Vistas.GenerarPedido obj = new Vistas.GenerarPedido();
            obj.Show();
        }

        private void button71_Click(object sender, EventArgs e)
        {
            Vistas.Compras.DevolucionesVer obj = new Vistas.Compras.DevolucionesVer();
            obj.Show();
        }

        private void button72_Click(object sender, EventArgs e)
        {
            Vistas.Compras.DevolucionesHacer obj = new Vistas.Compras.DevolucionesHacer(-1, -1, -1);
            obj.Show();
        }

        private void button67_Click(object sender, EventArgs e)
        {
            ///new Vistas.Compras.RecibirMercanciaPreguntar().Show();
            new Ordenes().Show();
        }

        private void button74_Click(object sender, EventArgs e)
        {
            RegistroEmpleados obj = new RegistroEmpleados(null, null, "");
            
            obj.Show();

        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            Permisos obj = new Permisos();
            obj.Show();
        }

        private void button40_Click_1(object sender, EventArgs e)
        {
            Tickets obj = new Tickets();
            obj.Show();
        }

        private void button50_Click_1(object sender, EventArgs e)
        {
            Metas obj = new Metas();
            obj.Show();
        }

        private void button43_Click_1(object sender, EventArgs e)
        {
            ReportesVentas obj = new ReportesVentas();
            obj.Show();
        }

        private void button44_Click_1(object sender, EventArgs e)
        {
            ReportesCompras obj = new ReportesCompras();
            obj.Show();
        }

        private void button77_Click(object sender, EventArgs e)
        {
            ReportesEmpleados obj = new ReportesEmpleados();
            obj.Show();
        }

        private void button78_Click(object sender, EventArgs e)
        {
            Finanzas obj = new Finanzas();
            obj.Show();
        }

        private void button42_Click_1(object sender, EventArgs e)
        {
            new Vistas.Reportes.Bajas().Show();
        }

        private void button45_Click_2(object sender, EventArgs e)
        {
            new Vistas.Inventario.VerProductosPrecapturados().Show();
        }

        private void button75_Click(object sender, EventArgs e)
        {

            //Mofificacion empleado
            BuscarEmpleado obj = new BuscarEmpleado();
            obj.ShowDialog();

            Usuario datosUsuario = obj.ObtenerUsuario();
            Usuario datosUsuarioFoto = obj.ObtenerUsuarioFoto();
            if(datosUsuario!=null)
                new RegistroEmpleados(datosUsuario, datosUsuarioFoto, "").Show();


        }

        private void button76_Click(object sender, EventArgs e)
        {
            //Baja empleado
            BuscarEmpleado obj = new BuscarEmpleado();
            obj.ShowDialog();
            Usuario datosUsuario = obj.ObtenerUsuario();
            Usuario datosUsuarioFoto = obj.ObtenerUsuarioFoto();
            if (datosUsuario != null)
                new MotivoBaja(datosUsuario, datosUsuarioFoto).Show();
        }

        private void button51_Click(object sender, EventArgs e)
        {
            new Vistas.Inventario.ActualizarUbicacion().Show();
        }

        private void button73_Click(object sender, EventArgs e)
        {
            new Vistas.Compras.ComprasCredito().ShowDialog();
        }

        private void button80_Click(object sender, EventArgs e)
        {
            new Vistas.Compras.Cotizar().Show();
        }

        private void button79_Click(object sender, EventArgs e)
        {
            new ExEmpleados().Show();
        }

        private void Formulario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button81_Click(object sender, EventArgs e)
        {
            //Registro de Huellas
            BuscarEmpleado obj = new BuscarEmpleado();
            obj.ShowDialog();
            Usuario datosUsuario = obj.ObtenerUsuario();
            Usuario datosUsuarioFoto = obj.ObtenerUsuarioFoto();
            if (datosUsuario != null)
            {
                RegistroEmpleados re = new RegistroEmpleados(datosUsuario, datosUsuarioFoto, "Huellas");
                re.Show();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            new Vistas.Utileria.Checador().Show();
        }

        private void button82_Click(object sender, EventArgs e)
        {
            new Vistas.Reportes.ReporteChecador().Show();
        }

        private void button83_Click(object sender, EventArgs e)
        {
            new Vistas.RecursosHumanos.Horarios().Show();
        }

        private void btnGafete_Click(object sender, EventArgs e)
        {
            //Gafete
            BuscarEmpleado be = new BuscarEmpleado();

            be.ShowDialog();

            Usuario datosUsuario = be.ObtenerUsuario();
            Usuario datosUsuarioFoto = be.ObtenerUsuarioFoto();
            if (datosUsuario != null)
            {
                Gafete gafete = new Gafete();
                gafete.ImprimirGafete(datosUsuario, datosUsuarioFoto);
            }
        }

        private void btnAltaCliente_Click(object sender, EventArgs e)
        {
            //Alta Cliente
            RegistroCliente obj = new RegistroCliente(null);
            obj.Show();
        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            //Modificar Cliente
            BuscarCliente bc = new BuscarCliente();
            bc.ShowDialog();

            DatosClientes datosClientes = bc.ObtenerCliente();
            if (datosClientes != null)
            {
                RegistroCliente obj = new RegistroCliente(datosClientes);
                obj.Show();
            }
        }
        private void button55_Click(object sender, EventArgs e)
        {
            SalidaAutorizada sa = new SalidaAutorizada();
            sa.Show();
        }
        private void btnBajaCliente_Click_2(object sender, EventArgs e)
        {
            BuscarCliente bc = new BuscarCliente();
            bc.ShowDialog();

            DatosClientes datosClientes = bc.ObtenerCliente();
            if (datosClientes != null)
                new BajaCliente(datosClientes).ShowDialog();
        }

        private void btnInmobiliario_Click(object sender, EventArgs e)
        {
            ReporteInmobiliario obj = new ReporteInmobiliario();
            obj.Show();
        }

        private void button63_Click(object sender, EventArgs e)
        {
            Dolar obd = new Dolar();
            obd.Show();
        }

        private void btnTickets_Click(object sender, EventArgs e)
        {
            //EtiquetasNoImpresas();
            new OpcionImpresion(configuracionBO, showPic).Show();
            
        }

        private void button85_Click(object sender, EventArgs e)
        {
            Tickets2 obt = new Tickets2();
            obt.Show();
        }

        private void button86_Click(object sender, EventArgs e)
        {
            Cotizacion obc = new Cotizacion();
            obc.Show();
        }

        private void button57_Click(object sender, EventArgs e)
        {
            ImportarExcelProductos iep = new ImportarExcelProductos();
            iep.Show();
        }

        private void button84_Click(object sender, EventArgs e)
        {
            new Vistas.Utileria.VerificarInventario().Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button87_Click(object sender, EventArgs e)
        {
            Promociones promo = new Promociones();
            promo.Show();
        }

        private void button48_Click(object sender, EventArgs e)
        {

        }

        private void button56_Click(object sender, EventArgs e)
        {
            new Vistas.Utileria.Gastos.Gastos(false).Show();
            
        }

        private void button58_Click(object sender, EventArgs e)
        {

        }

        private void button60_Click(object sender, EventArgs e)
        {
            new Vistas.Utileria.Gastos.Presupuestos(false).Show();
        }

        private void button88_Click(object sender, EventArgs e)
        {
            new Vistas.Configuracion.Sucursal().Show();
        }

        private void btnPermisos_Click(object sender, EventArgs e)
        {
            new PermisosRoles().Show();
        }
        private void EtiquetasNoImpresas()
        {
            HistorialCosto historial = new HistorialCosto();   
            List<object[]> dt = historial.CodigosHistorialCosto(DateTime.Now, DateTime.Now, DateTime.Now, false, 2);
            if (dt.Count == 0)
            {
                btnTickets.Image = Properties.Resources.imprimirEtiquetas64;
                showPic = false;
            }
            else
            {
                btnTickets.Image = Properties.Resources.imprimirEtiquetasCambio64;
                showPic = true;
            }
        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            new Vistas.Compras.Proveedores().Show();
        }

        private void button46_Click(object sender, EventArgs e)
        {

        }

        private void btnBonosyPenalizacion_Click(object sender, EventArgs e)
        {
            new BonosyPenalizacion().ShowDialog();
        }

        private void btnSalario_Click(object sender, EventArgs e)
        {
            new NominaUsuario().Show();
        }
    }
}
