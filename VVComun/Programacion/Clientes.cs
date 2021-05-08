using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerdeComun.Programacion
{
    public class Clientes
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();

        public List<Cliente> ObtenerClientes(bool debeTenerCredito)
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerClientes", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@debeTenerCredito", debeTenerCredito));

            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                List<Cliente> clientes = new List<Cliente>();
                while (rdr.Read())
                {
                    List<string> correos = ObtenerCorreosCliente(rdr["IDCliente"] + "");
                    Cliente cliente = new Cliente(rdr["IDCliente"] + "", rdr["Nombres"] + "", rdr["Apellidos"] + "", rdr["Direccion"] + "", 
                        rdr["NumeroExterior"] + "", rdr["NumeroInterior"] + "", rdr["cp"] + "", rdr["Colonia"] + "", rdr["Localidad"] + "", rdr["Ciudad"] + "", rdr["Estado"] + "", rdr["Pais"] + "", rdr["Telefono"] + "", decimal.Parse(rdr["UtilidadSobreCosto"] + ""), decimal.Parse(rdr["DescuentoGeneral"] + ""), rdr["RFC"] + "", correos, Convert.ToBoolean( rdr["RequiereFirma"] + ""), Convert.ToBoolean(rdr["EsPersonaFisica"] + ""), rdr["IDFacturama"] + "", rdr["UsoCFDI"] + "");


                    clientes.Add(cliente);
                }
                ob.CerrarConexionBD();

                return clientes;
            }




        }

        public List<string> ObtenerCorreosCliente(string idCliente)
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerCorreosCliente", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idCliente", idCliente));

            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                List<string> correos = new List<string>();
                while (rdr.Read())
                {
                    correos.Add(rdr[0] + "");

                }
                ob.CerrarConexionBD();

                return correos;
            }




        }

        public Cliente ObtenerClienteConID(string idCliente)
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerClienteConID", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idCliente", idCliente));

            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                Cliente cliente = null;
                while (rdr.Read())
                {
                    List<string> correos = ObtenerCorreosCliente(rdr["IDCliente"] + "");
                    cliente = new Cliente(rdr["IDCliente"] + "", rdr["Nombres"] + "", rdr["Apellidos"] + "", rdr["Direccion"] + "",
                        rdr["NumeroExterior"] + "", rdr["NumeroInterior"] + "", rdr["cp"] + "", rdr["Colonia"] + "", rdr["Localidad"] + "", rdr["Ciudad"] + "", rdr["Estado"] + "", rdr["Pais"] + "", rdr["Telefono"] + "", decimal.Parse(rdr["UtilidadSobreCosto"] + ""), decimal.Parse(rdr["DescuentoGeneral"] + ""), rdr["RFC"] + "", correos, Convert.ToBoolean(rdr["RequiereFirma"] + ""), Convert.ToBoolean(rdr["EsPersonaFisica"] + ""), rdr["IDFacturama"] + "", rdr["UsoCFDI"] + "");

                }
                ob.CerrarConexionBD();

                return cliente;
            }




        }

        public DatosCredito ObtenerCreditoCliente(string idCliente)
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerCreditoCliente", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idCliente", idCliente));

            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                DatosCredito credito = null;
                while (rdr.Read())
                {
                    if(rdr[0] + "" != "-1")
                        credito = new DatosCredito(decimal.Parse(rdr[0] + ""), int.Parse(rdr[1] + ""), decimal.Parse(rdr[2] + ""));

                }
                ob.CerrarConexionBD();

                return credito;
            }




        }

        public void AsignarClienteTicket(string idTicket, string idCliente)
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AsignarClienteTicket", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTicket", idTicket));
            cmd.Parameters.Add(new SqlParameter("@idCliente", idCliente));

            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
               
                while (rdr.Read())
                {
                    
                }
                ob.CerrarConexionBD();

               
            }




        }

        public void AsignarIDFacturama(string idCliente, string idFacturama)
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AsignarIDFacturamaCliente", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idCliente", idCliente));
            cmd.Parameters.Add(new SqlParameter("@idFacturama", idFacturama));

            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console

                while (rdr.Read())
                {

                }
                ob.CerrarConexionBD();


            }




        }

        public void EliminarClienteTicket(string idTicket, string idCliente)
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("EliminarClienteTicket", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTicket", idTicket));
            cmd.Parameters.Add(new SqlParameter("@idCliente", idCliente));

            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console

                while (rdr.Read())
                {

                }
                ob.CerrarConexionBD();


            }




        }
    }
}
