using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerde.Programacion.Ventas
{
    class CreditosClientes
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();
        public List<string[]> ObtenerVentasCredito(string IDCliente, DateTime fechaInicio, DateTime fechaFin, int todas, bool pendiente, bool fecha)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerVentasCredito", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@IDCliente", IDCliente));
            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
            cmd.Parameters.Add(new SqlParameter("@todas", todas));
            cmd.Parameters.Add(new SqlParameter("@pendientes", pendiente));
            cmd.Parameters.Add(new SqlParameter("@fecha",fecha));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<string[]> resultado = new List<string[]>();

            while (rdr.Read())
            {
                //V.IDVenta, V.Fecha, Cajero, V.Pagado, CV.abono, V.Total
                resultado.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + ""});
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public string[] ObtenerLimiteCredito(string IDCliente)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerCreditoCliente", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@IDCliente", IDCliente));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            string[] resultado = new string[] { };

            while (rdr.Read())
            {
                resultado = new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + ""};
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public List<string[]> ObtenerProductosVenta(int idVenta)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerProductosVenta", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idVenta", idVenta));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<string[]> resultado = new List<string[]>();

            while (rdr.Read())
            {
                resultado.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + "", rdr[6] + "", rdr[7] + "", rdr[8] + "" });
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public List<string[]> ObtenerAbonosCliente(int IDCliente, string fechaInicio, string fechaFin, bool todas)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerAbonosCliente", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@IDCliente", IDCliente));
            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
            cmd.Parameters.Add(new SqlParameter("@todas", todas));


            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<string[]> resultado = new List<string[]>();

            while (rdr.Read())
            {
                resultado.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "" , rdr[4] + "", rdr[5] + "" });
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public List<string[]> ObtenerTicketCredito(int IDCliente, int IDVenta)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerTicketCredito", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@IDCliente", IDCliente));
            cmd.Parameters.Add(new SqlParameter("@IDVenta", IDVenta));
            

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<string[]> resultado = new List<string[]>();

            while (rdr.Read())
            {
                //V.IDVenta, V.Fecha, Cajero, V.Pagado, CV.abono, V.Total
                resultado.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + "" });
            }

            ob.CerrarConexionBD();

            return resultado;
        }
        public List<string[]> ObtenerAbonosTicket(int IDCliente, int IDVenta)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerAbonosTicket", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@IDCliente", IDCliente));
            cmd.Parameters.Add(new SqlParameter("@IDVenta", IDVenta));


            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<string[]> resultado = new List<string[]>();

            while (rdr.Read())
            {
                resultado.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + "" });
            }

            ob.CerrarConexionBD();

            return resultado;
        }

    }
}
