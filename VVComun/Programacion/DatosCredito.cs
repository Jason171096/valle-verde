using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerdeComun.Programacion
{
    public class DatosCredito
    {
        public decimal limiteCredito;
        public int diasCredito;
        public decimal saldo;

        public DatosCredito(decimal limiteCredito, int diasCredito, decimal saldo)
        {
            this.limiteCredito = limiteCredito;
            this.diasCredito = diasCredito;
            this.saldo = saldo;
        }

    }
}
