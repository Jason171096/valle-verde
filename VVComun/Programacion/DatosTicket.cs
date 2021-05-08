using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerdeComun.Programacion
{
    public class DatosTicket
    {
        public int idTicket;
        public string nombreTicket;
        public string mensajeCabecera;
        public string mensajePie1, mensajePie2, mensajePie3;
        public bool incluirLogo;
        public bool incluirAhorro;
        public bool incluirCliente;
        public bool incluirSucursal;
        public bool incluirCorreoElectronico;
        public bool incluirDireccion;
        public int digitosBascula;
        public bool incluirMensajeCabecera;
        public bool incluirMensajePie1, incluirMensajePie2, incluirMensajePie3;
        public bool incluirTelefono;
        public bool incluirRFC;
        public bool incluirCaja;
        public bool incluirEmpleado;
        public bool incluirSlogan;
        public bool incluirSaldoActual;

        public DatosTicket(int idTicket,
        string nombreTicket,
        string mensajeCabecera,
        string mensajePie1,string mensajePie2,string mensajePie3,
        bool incluirLogo,
        bool incluirAhorro,
        bool incluirCliente,
        bool incluirSucursal,
        bool incluirCorreoElectronico,
        bool incluirDireccion,
        int digitosBascula,
        bool incluirMensajeCabecera,
        bool incluirMensajePie1,bool incluirMensajePie2,bool incluirMensajePie3,
        bool incluirTelefono,
        bool incluirRFC,
        bool incluirCaja,
        bool incluirEmpleado, 
        bool incluirSlogan,
        bool incluirSaldoActual)
        {
            this.idTicket = idTicket;
            this.nombreTicket = nombreTicket;
            this.mensajeCabecera = mensajeCabecera;
            this.mensajePie1 = mensajePie1;
            this.mensajePie2 = mensajePie2;
            this.mensajePie3 = mensajePie3;
            this.incluirLogo = incluirLogo;
            this.incluirAhorro = incluirAhorro;
            this.incluirCliente = incluirCliente;
            this.incluirSucursal = incluirSucursal;
            this.incluirCorreoElectronico = incluirCorreoElectronico;
            this.incluirDireccion = incluirDireccion;
            this.digitosBascula = digitosBascula;
            this.incluirMensajeCabecera = incluirMensajeCabecera;
            this.incluirMensajePie1 = incluirMensajePie1;
            this.incluirMensajePie2 = incluirMensajePie2;
            this.incluirMensajePie3 = incluirMensajePie3;
            this.incluirTelefono = incluirTelefono;
            this.incluirRFC = incluirRFC;
            this.incluirCaja = incluirCaja;
            this.incluirEmpleado = incluirEmpleado;
            this.incluirSlogan = incluirSlogan;
            this.incluirSaldoActual = incluirSaldoActual;
        }
    }
}
