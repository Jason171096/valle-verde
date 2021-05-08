using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerde.Programacion.Configuracion
{
    class Cotizacion
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();
        public decimal ObtenerDuracion()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("SELECT DuracionCotizacionesEnHoras FROM ConfiguracionGlobal", ob.ObtenerConexion());

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            decimal resultado = 0;

            while (rdr.Read())
            {
                resultado = decimal.Parse(rdr[0] + "");
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public bool ObtenerRespetar()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("SELECT RespetarPreciosCotizacion FROM ConfiguracionGlobal", ob.ObtenerConexion());

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            bool resultado = false;

            while (rdr.Read())
            {
                resultado = bool.Parse(rdr[0] + "");
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public string ModicarConfigCot(string campo, string valor)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("UPDATE ConfiguracionGlobal SET " + campo + " = " + valor, ob.ObtenerConexion());

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            string resultado = "-1";

            while (rdr.Read())
            {
                resultado = rdr[0] + "";
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public string ModicarRespetarCot(string campo, int valor)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("UPDATE ConfiguracionGlobal SET " + campo + " = " + valor, ob.ObtenerConexion());

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            string resultado = "-1";

            while (rdr.Read())
            {
                resultado = rdr[0] + "";
            }

            ob.CerrarConexionBD();

            return resultado;
        }
    }
}
