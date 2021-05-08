using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerdeComun.Programacion
{
    class Corte
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();
        
        public string[] ObtenerDatosCorte(string idTurno)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerDatosTurno", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTurno", idTurno));

            string[] res = new string[8];
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res[0] = rdr[0] + "";
                    res[1] = rdr[1] + "";
                    res[2] = rdr[2] + "";
                    res[3] = rdr[3] + "";
                    res[4] = rdr[4] + "";
                    res[5] = rdr[5] + "";
                    res[6] = rdr[6] + "";
                    res[7] = rdr[7] + "";
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public decimal[] ObtenerTotalesVentas(string idTurno)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerTotalesVentas", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTurno", idTurno));

            decimal[] res = new decimal[14];
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res[0] = decimal.Parse(rdr[0] + "");
                    res[1] = decimal.Parse(rdr[1] + "");
                    res[2] = decimal.Parse(rdr[2] + "");
                    res[3] = decimal.Parse(rdr[3] + "");
                    res[4] = decimal.Parse(rdr[4] + "");
                    res[5] = decimal.Parse(rdr[5] + "");
                    res[6] = decimal.Parse(rdr[6] + "");
                    res[7] = decimal.Parse(rdr[7] + "");
                    res[8] = decimal.Parse(rdr[8] + "");
                    res[9] = decimal.Parse(rdr[9] + "");
                    res[10] = decimal.Parse(rdr[10] + "");
                    res[11] = decimal.Parse(rdr[11] + "");
                    res[12] = decimal.Parse(rdr[12] + "");
                    res[13] = decimal.Parse(rdr[13] + "");
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public decimal[] ObtenerTotalesVentasDesglosado(string idTurno)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerTotalesVentasDesglosado", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTurno", idTurno));

            decimal[] res = new decimal[6];
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res[0] = decimal.Parse(rdr[0] + "");
                    res[1] = decimal.Parse(rdr[1] + "");
                    res[2] = decimal.Parse(rdr[2] + "");
                    res[3] = decimal.Parse(rdr[3] + "");
                    res[4] = decimal.Parse(rdr[4] + "");
                    res[5] = decimal.Parse(rdr[5] + "");
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public List<string[]> ObtenerTotalesTarjeta(string idTurno)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerTotalesTarjeta", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTurno", idTurno));

            List<string[]> res = new List<string[]>();
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res.Add(new string[] { rdr[0] + "", rdr[1] + "" });
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public List<string[]> ObtenerTotalesVale(string idTurno)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerTotalesVale", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTurno", idTurno));

            List<string[]> res = new List<string[]>();
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "" });
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public List<string[]> ObtenerTotalesCredito(string idTurno)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerTotalesCredito", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTurno", idTurno));

            List<string[]> res = new List<string[]>();
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res.Add(new string[] { rdr[0] + "", rdr[1] + ""});
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public List<string[]> ObtenerTotalesCheque(string idTurno)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerTotalesCheque", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTurno", idTurno));

            List<string[]> res = new List<string[]>();
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "" });
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public List<string[]> ObtenerTotalesTransferencia(string idTurno)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerTotalesTransferencia", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTurno", idTurno));

            List<string[]> res = new List<string[]>();
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "" });
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public List<string[]> ObtenerTotalesDevolucionesDesglosado(string idTurno)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerTotalesDevolucionesDesglosado", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTurno", idTurno));

            List<string[]> res = new List<string[]>();
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res.Add(new string[] { rdr[0] + "", rdr[1] + ""});
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public List<string[]> ObtenerTotalesSalidasDesglosado(string idTurno)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerTotalesSalidasDesglosado", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTurno", idTurno));

            List<string[]> res = new List<string[]>();
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res.Add(new string[] { rdr[0] + "", rdr[1] + "" });
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public List<string[]> ObtenerTotalesEntradasDesglosado(string idTurno)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerTotalesEntradasDesglosado", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTurno", idTurno));

            List<string[]> res = new List<string[]>();
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res.Add(new string[] { rdr[0] + "", rdr[1] + "" });
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public List<string[]> ObtenerTotalesGastosTiendaDesglosado(string idTurno)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerTotalesGastosTiendaDesglosado", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTurno", idTurno));

            List<string[]> res = new List<string[]>();
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res.Add(new string[] { rdr[0] + "", rdr[1] + "" });
                }
            }

            ob.CerrarConexionBD();
            return res;
        }
    }
}
