using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerde.Programacion.Configuracion
{
    class Dolar
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();

        public string FechaHoy()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("SELECT GETDATE()", ob.ObtenerConexion());

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            string resultado = "";

            while (rdr.Read())
            {
                resultado = rdr[0] + "";
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public decimal DolarBase()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("select precioDolar from ConfiguracionGlobal", ob.ObtenerConexion());

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            decimal resultado = 0;

            while (rdr.Read())
            {
                resultado = decimal.Parse(rdr[0] + "");
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public string ActualizarDolar(string valor)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("UPDATE ConfiguracionGlobal SET precioDolar = "+valor, ob.ObtenerConexion());

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

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
