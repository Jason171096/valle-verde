using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerde.Programacion.Configuracion
{
    class SeleccionTicket
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();
        public List<string[]> ObtenerTickets()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("SELECT IDTicket, Nombre FROM Tickets", ob.ObtenerConexion());

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<string[]> resultado = new List<string[]>();

            while (rdr.Read())
            {
                resultado.Add(new string[] { rdr[0] + "", rdr[1] + "" });
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public string getTicketsVentas()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("SELECT Nombre FROM Tickets WHERE IDTicket = (SELECT IDTicketVentas FROM ConfiguracionGlobal)", ob.ObtenerConexion());

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            string resultado = "";

            while (rdr.Read())
            {
                resultado = rdr[0] + "";
            }

            ob.CerrarConexionBD();

            return resultado;
        }
        public string getTicketsDevolucion()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("SELECT Nombre FROM Tickets WHERE IDTicket = (SELECT IDTicketDevoluciones FROM ConfiguracionGlobal)", ob.ObtenerConexion());

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            string resultado = "";

            while (rdr.Read())
            {
                resultado = rdr[0] + "";
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public decimal getMaximoPendientes()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("SELECT numeroTicketsMaximo FROM ConfiguracionGlobal", ob.ObtenerConexion());

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

        public string ModicarConfig(string campo, string valor)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("UPDATE ConfiguracionGlobal SET "+ campo +" = " + valor, ob.ObtenerConexion());

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
