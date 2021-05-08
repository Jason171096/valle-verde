using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerdeComun.Programacion
{
    public class Cliente
    {
        public string idCliente;
        public string nombre;
        public string apellidos;
        public string direccion;
        public string numeroExterior;
        public string numeroInterior;
        public string cp;
        public string colonia;
        public string localidad;
        public string ciudad;
        public string estado;
        public string pais;
        public string telefono;
        public decimal utilidadSobreCosto;
        public decimal descuentoGeneral;
        public string rfc;
        public List<string> correos;
        public bool requiereFirma;
        public bool personafisica;
        public string IDFacturama;
        public string UsoCFDI;

        public Cliente( string idCliente,
         string nombre,
         string apellidos,
         string direccion,
        string numeroExterior,
        string numeroInterior,
        string cp,
        string colonia,
        string localidad,
        string ciudad,
        string estado,
        string pais,
        string telefono,
        decimal utilidadsobreCosto,
         decimal descuentoGeneral,
         string rfc,
         List<string> correos,
         bool requiereFirma,
         bool personafisica,
         string IDFacturama,
         string UsoCFDI)
        {
            this.idCliente = idCliente;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.direccion = direccion;
            this.numeroExterior = numeroExterior;
            this.numeroInterior = numeroInterior;
            this.cp = cp;
            this.colonia= colonia;
            this.localidad= localidad;
            this.ciudad= ciudad;
            this.estado= estado;
            this.pais= pais;
            this.telefono = telefono;
            this.utilidadSobreCosto = utilidadsobreCosto;
            this.descuentoGeneral = descuentoGeneral;
            this.rfc = rfc;
            this.correos = correos;
            this.requiereFirma = requiereFirma;
            this.personafisica = personafisica;
            if (IDFacturama.Trim() == "")
                IDFacturama = "-1";
            this.IDFacturama = IDFacturama;
            this.UsoCFDI = UsoCFDI;
        }
    }
}
