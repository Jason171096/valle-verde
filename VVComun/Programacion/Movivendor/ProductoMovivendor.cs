using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerdeComun.Programacion.Movivendor
{
    public class ProductoMovivendor : IComparable
    {
        public string grupo;
        public object montos;
        public string nombre;
        public string sku;

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            ProductoMovivendor otroProducto = obj as ProductoMovivendor;
            if (otroProducto != null)
                return this.nombre.CompareTo(otroProducto.nombre);
            else
                throw new ArgumentException("El objeto no es un producto");
        }

        public void MostrarMontos()
        {
            if (montos.GetType() == typeof(string))
                Console.WriteLine(montos.ToString());
            else
                foreach (var monto in (IEnumerable<object>)montos)
                {
                    Console.WriteLine(monto.ToString());
                }
        }

        public List<decimal> ObtenerMontos()
        {
            List<decimal> res = new List<decimal>();

            if (montos.GetType() == typeof(string))
                res.Add(decimal.Parse(montos.ToString()));
            else
                foreach (var monto in (IEnumerable<object>)montos)
                {
                    res.Add(decimal.Parse(monto.ToString()));
                }

            res.Sort();

            return res;
        }
    }
}