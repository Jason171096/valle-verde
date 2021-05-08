using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerdeComun.Programacion
{
    
    public class DatosConfiguracionGlobal
    {
        public decimal precioDolar;
        public int numeroTicketsMaximo;
        public int IDTicketVentas;
        public int IDTicketDevoluciones;
        public int DuracionCotizacionesEnHoras;
        public bool respetarPreciosCotizacion;
        public decimal ComisionPagoTarjeta;
        public decimal MinimoPorcentajeUtilidadPagoConTarjeta;
        public int PrecioCobrarComisionTarjeta;
        public string url_servicio = "";
        public string movivendor_idcanal_recargas = "";
        public string movivendor_ident_recargas = "";
        public string movivendor_pwd_recargas = "";
        public string movivendor_idcanal_servicios = "";
        public string movivendor_ident_servicios = "";
        public string movivendor_pwd_servicios = "";
        public string url_base_facturacion = "";
        public string usuarioFacturacion = "";
        public string contrasenaFacturacion = "";

        public DatosConfiguracionGlobal(decimal precioDolar
        , int numeroTicketsMaximo
        , int IDTicketVentas
        , int DuracionCotizacionesEnHoras
        , bool respetarPreciosCotizacion
        , int IDTicketDevoluciones
        , decimal ComisionPagoTarjeta
        , decimal MinimoPorcentajeUtilidadPagoConTarjeta
        , int PrecioCobrarComisionTarjeta
        , string url_servicio   
        , string movivendor_idcanal_recargas   
        , string movivendor_ident_recargas   
        , string movivendor_pwd_recargas   
        , string movivendor_idcanal_servicios   
        , string movivendor_ident_servicios   
        , string movivendor_pwd_servicios
        , string url_base_facturacion
        , string usuarioFacturacion
        , string contrasenaFacturacion)
        {
            this.precioDolar = precioDolar;
            this.numeroTicketsMaximo = numeroTicketsMaximo;
            this.IDTicketVentas = IDTicketVentas;
            this.DuracionCotizacionesEnHoras = DuracionCotizacionesEnHoras;
            this.respetarPreciosCotizacion = respetarPreciosCotizacion;
            this.IDTicketDevoluciones = IDTicketDevoluciones;
            this.ComisionPagoTarjeta = ComisionPagoTarjeta;
            this.MinimoPorcentajeUtilidadPagoConTarjeta = MinimoPorcentajeUtilidadPagoConTarjeta;
            this.PrecioCobrarComisionTarjeta = PrecioCobrarComisionTarjeta;
            this.url_servicio = url_servicio;
            this.movivendor_idcanal_recargas = movivendor_idcanal_recargas;
            this.movivendor_ident_recargas = movivendor_ident_recargas;
            this.movivendor_pwd_recargas = movivendor_pwd_recargas;
            this.movivendor_idcanal_servicios = movivendor_idcanal_servicios;
            this.movivendor_ident_servicios = movivendor_ident_servicios;
            this.movivendor_pwd_servicios = movivendor_pwd_servicios;
            this.url_base_facturacion = url_base_facturacion;
            this.usuarioFacturacion = usuarioFacturacion;
            this.contrasenaFacturacion = contrasenaFacturacion;
        }

    }
}
