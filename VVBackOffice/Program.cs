using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion.Configuracion;
using ValleVerde.Vistas.Utileria.Gastos;
using ValleVerde.Vistas.RecursosHumanos;
using ValleVerde.Vistas.Utileria;

namespace ValleVerde
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //ValleVerdeComun.Programacion.ConfiguracionBO bO = ValleVerdeComun.Programacion.ConfiguracionBO.Load();
            //Application.Run(new OpcionImpresion(bO, false));

            //Application.Run(new Gastos(false));


            Application.Run(new Inicio());


        }
    }
}
