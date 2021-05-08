using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerdeComun.Programacion.Huellas
{
    public class ResultadoHuella
    {
        public string IDUsuario;
        public string Nombres;
        public string Apellidos;
        public byte[] templateBD;
        public uint templateLengthBD;
        public string nombre;
        public bool esAdministrador;

        public ResultadoHuella()
        {

        }

        public ResultadoHuella(string IDUsuario,
         string Nombres,
         string Apellidos,
         string nombre,
         bool esAdministrador)
        {
            this.IDUsuario = IDUsuario;
            this.Nombres = Nombres;
            this.Apellidos = Apellidos;
            this.nombre = nombre;
            this.esAdministrador = esAdministrador;
        }
    }
}
