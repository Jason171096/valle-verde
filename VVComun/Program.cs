using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerdeComun.Programacion.InicioSesion;
using ValleVerdeComun.Vistas;
using ValleVerdeComun.Vistas.InicioSesion;

namespace ValleVerdeComun
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
            //Application.Run(new Vistas.InicioSesion.InicioSesion(false));
            //Application.Run(new VerVentas(null,null,null,null));
            //Application.Run(new VerificadorDePrecios());
            Application.Run(new PedirFondo());
        }

       
    }
}
