using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerdeComun.Programacion
{
    public class PermisosUsuario
    {
		#region BackOffice

		public bool IniciarSesionBackOffice;

		//Compras
		public bool CotizacionCompras;
		public bool RecibirCotizacion;
		public bool GenerarPedidoCompras;
		public bool RecibirPedidoCompras;
		public bool HistorialCompras;
		public bool AdministrarProveedores;
		public bool EliminarProveedor;
		public bool VerDevolucionesCompras;
		public bool HacerDevolucionesCompras;
		public bool VerComprasCredito;

		//Ventas
		public bool VerFacturas;
		public bool GenerarFacturas;
		public bool VerCreditosVentas;
		public bool Promociones;

		//Inventario
		public bool AltaProducto;
		public bool PrecapturarProducto;
		public bool ModificarProducto;
		public bool EliminarProducto;
		public bool ActualizarUbicacion;
		public bool AjustarPrecio;
		public bool ReporteExistencias;
		public bool TraspasarMercancia;
		public bool AdministrarEntradasSalidas;
		public bool RegistrarEntrada;
		public bool RegistrarSalida;
		public bool AdministrarFabricantes;
		public bool AdministrarMarcas;
		public bool AdministrarLineas;
		public bool AdministrarAlmacenes;
		public bool AdministrarUnidades;
		public bool AdministrarInmobiliario;

		//Recursos Humanos
		public bool AltaEmpleado;
		public bool ModificarEmpleado;
		public bool BajaEmpleado;
		public bool VerExEmpleados;
		public bool AdministrarHorarios;
		public bool AdministrarBonosPenalizaciones;
		public bool AdministrarPermisosRoles;
		public bool AltaCliente;
		public bool ModificarCliente;
		public bool BajaCliente;

		//Reportes
		public bool ReporteVentas;
		public bool ReporteCompras;
		public bool ReporteEmpleados;
		public bool ReporteFinanzas;
		public bool ReporteChecador;

		//Utileria
		public bool Checador;
		public bool ImportarProductosExcel;
		public bool Presupuestos;
		public bool VerificarInventario;
		public bool Gastos;
		public bool Gafete;

		//Configuracion
		public bool ConfiguracionBackOffice;

		#endregion

		public bool IniciarSesionPuntoVenta;

		public bool PedidoClienteAcceder  ;
		public bool DevolucionesVentasAcceder  ;
		public bool EtiquetasPendientesPegarAcceder  ;
		public bool PreescanearEtiquetas  ;
		
		public bool KardexAcceder  ;
		public bool DevolucionesComprasAcceder  ;
		public bool ProductosPendientesComprasAcceder  ;
		
		public bool ClavesAdicionalesAcceder;
		
		
		public bool DesbloquearCaja  ;
		public bool HacerCorte  ;
		public bool HacerDevolucion  ;
		
		public bool HacerCotizacionVenta  ;

		public bool VerVentas;
		

		public PermisosUsuario(
			bool IniciarSesionBackOffice,
			bool CotizacionCompras,
			bool RecibirCotizacion,
			bool GenerarPedidoCompras,
			bool RecibirPedidoCompras,
			bool HistorialCompras,
			bool AdministrarProveedores,
			bool EliminarProveedor,
			bool VerDevolucionesCompras,
			bool HacerDevolucionesCompras,
			bool VerComprasCredito,

			bool VerFacturas,
			bool GenerarFacturas,
			bool VerCreditosVentas,
			bool Promociones,

			bool AltaProducto,
			bool PrecapturarProducto,
			bool ModificarProducto,
			bool EliminarProducto,
			bool ActualizarUbicacion,
			bool AjustarPrecio,
			bool ReporteExistencias,
			bool TraspasarMercancia,
			bool AdministrarEntradasSalidas,
			bool RegistrarEntrada,
			bool RegistrarSalida,
			bool AdministrarFabricantes,
			bool AdministrarMarcas,
			bool AdministrarLineas,
			bool AdministrarAlmacenes,
			bool AdministrarUnidades,
			bool AdministrarInmobiliario,

			bool AltaEmpleado,
			bool ModificarEmpleado,
			bool BajaEmpleado,
			bool VerExEmpleados,
			bool AdministrarHorarios,
			bool AdministrarBonosPenalizaciones,
			bool AdministrarPermisosRoles,
			bool AltaCliente,
			bool ModificarCliente,
			bool BajaCliente,

			bool ReporteVentas,
			bool ReporteCompras,
			bool ReporteEmpleados,
			bool ReporteFinanzas,
			bool ReporteChecador,

			bool ImportarProductosExcel,
			bool Presupuestos,
			bool VerificarInventario,
			bool Gastos,
			bool Gafete,

			bool ConfiguracionBackOffice,

			bool IniciarSesionPuntoVenta,

			bool EtiquetasPendientesPegarAcceder,
			bool PreescanearEtiquetas,
			bool KardexAcceder,
		  
			bool DevolucionesComprasAcceder,
			bool ProductosPendientesComprasAcceder,
		 
			bool ClavesAdicionalesAcceder,
		  
			bool DesbloquearCaja,
			bool HacerCorte,
			bool HacerDevolucion,
		  
			bool HacerCotizacionVenta,

			bool PedidoClienteAcceder,
			bool DevolucionesVentasAcceder,
			bool VerVentas


		  )
        {
			this.IniciarSesionBackOffice = IniciarSesionBackOffice;
			this.CotizacionCompras = CotizacionCompras;
			this.RecibirCotizacion = RecibirCotizacion;
			this.GenerarPedidoCompras = GenerarPedidoCompras;
			this.RecibirPedidoCompras = RecibirPedidoCompras;
			this.HistorialCompras = HistorialCompras;
			this.AdministrarProveedores = AdministrarProveedores;
			this.EliminarProveedor = EliminarProveedor;
			this.VerDevolucionesCompras = VerDevolucionesCompras;
			this.HacerDevolucionesCompras = HacerDevolucionesCompras;
			this.VerComprasCredito = VerComprasCredito;

			this.VerFacturas = VerFacturas;
			this.GenerarFacturas = GenerarFacturas;
			this.VerCreditosVentas = VerCreditosVentas;
			this.Promociones = Promociones;

			this.AltaProducto = AltaProducto;
			this.PrecapturarProducto = PrecapturarProducto;
			this.ModificarProducto = ModificarProducto;
			this.EliminarProducto = EliminarProducto;
			this.ActualizarUbicacion = ActualizarUbicacion;
			this.AjustarPrecio = AjustarPrecio;
			this.ReporteExistencias = ReporteExistencias;
			this.TraspasarMercancia = TraspasarMercancia;
			this.AdministrarEntradasSalidas = AdministrarEntradasSalidas;
			this.RegistrarEntrada = RegistrarEntrada;
			this.RegistrarSalida = RegistrarSalida;
			this.AdministrarFabricantes = AdministrarFabricantes;
			this.AdministrarMarcas = AdministrarMarcas;
			this.AdministrarLineas = AdministrarLineas;
			this.AdministrarAlmacenes = AdministrarAlmacenes;
			this.AdministrarUnidades = AdministrarUnidades;
			this.AdministrarInmobiliario = AdministrarInmobiliario;

			this.AltaEmpleado = AltaEmpleado;
			this.ModificarEmpleado = ModificarEmpleado;
			this.BajaEmpleado = BajaEmpleado;
			this.VerExEmpleados = VerExEmpleados;
			this.AdministrarHorarios = AdministrarHorarios;
			this.AdministrarBonosPenalizaciones = AdministrarBonosPenalizaciones;
			this.AdministrarPermisosRoles = AdministrarPermisosRoles;
			this.AltaCliente = AltaCliente;
			this.ModificarCliente = ModificarCliente;
			this.BajaCliente = BajaCliente;

			this.ReporteVentas = ReporteVentas;
			this.ReporteCompras = ReporteCompras;
			this.ReporteEmpleados = ReporteEmpleados;
			this.ReporteFinanzas = ReporteFinanzas;
			this.ReporteChecador = ReporteChecador;

			this.ImportarProductosExcel = ImportarProductosExcel;
			this.Presupuestos = Presupuestos;
			this.VerificarInventario = VerificarInventario;
			this.Gastos = Gastos;
			this.Gafete = Gafete;

			this.ConfiguracionBackOffice = ConfiguracionBackOffice;
			

			this.IniciarSesionPuntoVenta = IniciarSesionPuntoVenta;

			this.PedidoClienteAcceder = PedidoClienteAcceder;
			  this.DevolucionesVentasAcceder = DevolucionesVentasAcceder;
			  this.EtiquetasPendientesPegarAcceder = EtiquetasPendientesPegarAcceder;
			  this.PreescanearEtiquetas = PreescanearEtiquetas;
			 
			  this.KardexAcceder = KardexAcceder;
			  this.DevolucionesComprasAcceder = DevolucionesComprasAcceder;
			  this.ProductosPendientesComprasAcceder = ProductosPendientesComprasAcceder;
			 
			  this.ClavesAdicionalesAcceder = ClavesAdicionalesAcceder;
			  
			 
			  this.DesbloquearCaja = DesbloquearCaja;
			  this.HacerCorte = HacerCorte;
			  this.HacerDevolucion = HacerDevolucion;
			  
			  this.HacerCotizacionVenta = HacerCotizacionVenta;


			this.VerVentas = VerVentas;
		}

    }
}
