using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerdeComun.Programacion
{
    public class DatosEmpresa
    {
        public string nombre;
        public string domicilio;
        public string telefono1, telefono2;
        public Image logotipo;
        public string colonia;
        public string ciudad;
        public string estado;
        public string CP;
        public string slogan;
        public string rfc;
        public string correo;
        public string nombreCorto;

        public DatosEmpresa(string nombre,
         string domicilio,
         string telefono1,
         string telefono2,
         Image logotipo,
         string colonia,
         string ciudad,
         string estado,
         string CP,
         string slogan,
         string rfc,
         string correo,
         string nombreCorto)
        {
            this.nombre = nombre;
            this.domicilio = domicilio;
            this.telefono1 = telefono1;
            this.telefono2 = telefono2;
            this.logotipo = logotipo;
            this.colonia = colonia;
            this.ciudad = ciudad;
            this.estado = estado;
            this.CP = CP;
            this.slogan = slogan;
            this.rfc = rfc;
            this.correo = correo;
            this.nombreCorto = nombreCorto;
        }
    }
}