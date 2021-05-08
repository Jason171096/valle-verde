using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerde.Vistas.Compras
{
    class QuitarCadenas
    {
        public QuitarCadenas()
        {

        }

        public string ObtenerCadenaLimpia(string cadOri, string[] cadQui)
        {
            foreach (string c in cadQui)
            {
                cadOri = cadOri.Replace(c, string.Empty);
            }
            return cadOri;
        }
    }
}
