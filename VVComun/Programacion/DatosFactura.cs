using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerdeComun.Programacion
{
    //Datos necesarios
    //Código de qr
        //UUID de la factura
        //rfc emisor
        //rfc receptor
        //total
        //ultimos 8 caracteres sello digital emisor

    //II.Número de serie del CSD del emisor y del SAT, 
    //III.La leyenda: “Este documento es una representación impresa de un CFDI”
    //IV.Fecha y hora de emisión y de certificación del CFDI 
    //V.Cadena original del complemento de certificación digital del SAT.

    
    public class DatosFactura
    {
        public string UUID, rfcEmisor, rfcReceptor, selloDigital, selloDigitalSAT, cadenaComplementoSat;
        public string fechaCertificacion, fechaEmision, nombreReceptor, usoCFDI, noCertificadoEmisor, noCertificadoSat;
        public decimal total;
        public Dictionary<string, decimal> impuestos;


        public DatosFactura(string UUID, string rfcEmisor, string rfcReceptor, string nombreReceptor, decimal total, string selloDigital, string selloDigitalSAT, string fechaCertificacion, string fechaEmision, string cadenaComplementoSat, string usoCFDI, string noCertificadoEmisor, string noCertificadoSat)
        {
            this.UUID = UUID;
            this.rfcEmisor = rfcEmisor;
            this.rfcReceptor = rfcReceptor;
            this.nombreReceptor = nombreReceptor;
            this.total = total;
            this.selloDigital = selloDigital;
            this.selloDigitalSAT = selloDigitalSAT;
            this.fechaEmision = fechaEmision;
            this.fechaCertificacion = fechaCertificacion;
            this.cadenaComplementoSat = cadenaComplementoSat;
            this.usoCFDI = usoCFDI;
            this.noCertificadoEmisor = noCertificadoEmisor;
            this.noCertificadoSat = noCertificadoSat;
        }
    }
}
