using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ValleVerde.Programacion.Reportes
{
    public class ReporteVentas
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();
        public List<String[]> Obtenerempleados()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerNombreUsuario", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<String[]> resultado = new List<String[]>();

            while (rdr.Read())
            {
                resultado.Add(new string[] { rdr[0].ToString(), rdr[1].ToString() });
            }

            ob.CerrarConexionBD();

            return resultado;
        }
        public List<String> Obtenercajas()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerCajas", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<String> resultado = new List<String>();

            while (rdr.Read())
            {
                resultado.Add(rdr[0].ToString());
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public List<Tuple<float, DateTime>> VentasMes(int mes, int idempleado, string nombrecaja, int anoventa)
        {
            ob.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("ReporteVentasMesYear", ob.ObtenerConexion());

            if (idempleado == -1 && nombrecaja == "-1")
            {
                cmd.Parameters.AddWithValue("@idcaja", SqlDbType.NVarChar).Value = "-1";
                cmd.Parameters.AddWithValue("@idempleado", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@mes", SqlDbType.BigInt).Value = mes;
                cmd.Parameters.AddWithValue("@anoventa", SqlDbType.BigInt).Value = anoventa;
                cmd.Parameters.AddWithValue("@year", SqlDbType.BigInt).Value = -1;
            }
            else if (nombrecaja == "-1")
            {
                cmd.Parameters.AddWithValue("@idcaja", SqlDbType.NVarChar).Value = "-1";
                cmd.Parameters.AddWithValue("@idempleado", SqlDbType.BigInt).Value = idempleado;
                cmd.Parameters.AddWithValue("@mes", SqlDbType.BigInt).Value = mes;
                cmd.Parameters.AddWithValue("@anoventa", SqlDbType.BigInt).Value = anoventa;
                cmd.Parameters.AddWithValue("@year", SqlDbType.BigInt).Value = -1;
            }
            else if (idempleado == -1)
            {
                cmd.Parameters.AddWithValue("@idcaja", SqlDbType.NVarChar).Value = nombrecaja;
                cmd.Parameters.AddWithValue("@idempleado", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@mes", SqlDbType.BigInt).Value = mes;
                cmd.Parameters.AddWithValue("@anoventa", SqlDbType.BigInt).Value = anoventa;
                cmd.Parameters.AddWithValue("@year", SqlDbType.BigInt).Value = -1;
            }
            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<Tuple<float, DateTime>> resultado = new List<Tuple<float, DateTime>>();

            while (rdr.Read())
            {
                resultado.Add(new Tuple<float, DateTime>(float.Parse(rdr[0].ToString()), Convert.ToDateTime(rdr[1].ToString())));
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public List<Tuple<float, DateTime>> VentasYear(int year, int idempleado, string nombrecaja)
        {
            ob.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("ReporteVentasMesYear", ob.ObtenerConexion());

            if (idempleado == -1 && nombrecaja == "-1")
            {
                cmd.Parameters.AddWithValue("@idcaja", SqlDbType.NVarChar).Value = "-1";
                cmd.Parameters.AddWithValue("@idempleado", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@mes", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@anoventa", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@year", SqlDbType.BigInt).Value = year;

            }
            else if (nombrecaja == "-1")
            {
                cmd.Parameters.AddWithValue("@idcaja", SqlDbType.NVarChar).Value = "-1";
                cmd.Parameters.AddWithValue("@idempleado", SqlDbType.BigInt).Value = idempleado;
                cmd.Parameters.AddWithValue("@mes", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@anoventa", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@year", SqlDbType.BigInt).Value = year;

            }
            else if (idempleado == -1)
            {
                cmd.Parameters.AddWithValue("@idcaja", SqlDbType.NVarChar).Value = nombrecaja;
                cmd.Parameters.AddWithValue("@idempleado", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@mes", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@anoventa", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@year", SqlDbType.BigInt).Value = year;

            }
            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<Tuple<float, DateTime>> resultado = new List<Tuple<float, DateTime>>();

            while (rdr.Read())
            {
                resultado.Add(new Tuple<float, DateTime>(float.Parse(rdr[0].ToString()), Convert.ToDateTime(rdr[1])));
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public List<Tuple<float, DateTime>> FechaVentas(DateTime pFechaInicial, DateTime pFechaFinal, int idempleado, string nombrecaja)
        {
            ob.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("ReporteVentasFechas", ob.ObtenerConexion());

            if (idempleado == -1 && nombrecaja == "-1")
            {
                cmd.Parameters.AddWithValue("@idcaja", SqlDbType.NVarChar).Value = "-1";
                cmd.Parameters.AddWithValue("@idempleado", SqlDbType.BigInt).Value = -1;

                cmd.Parameters.AddWithValue("@FechaInicial", SqlDbType.Date).Value = pFechaInicial.Date;
                cmd.Parameters.AddWithValue("@FechaFinal", SqlDbType.Date).Value = pFechaFinal.Date;
            }
            else if(idempleado!=-1)
            {
                cmd.Parameters.AddWithValue("@idcaja", SqlDbType.NVarChar).Value = "-1";
                cmd.Parameters.AddWithValue("@idempleado", SqlDbType.BigInt).Value = idempleado;

                cmd.Parameters.AddWithValue("@FechaInicial", SqlDbType.Date).Value = pFechaInicial.Date;
                cmd.Parameters.AddWithValue("@FechaFinal", SqlDbType.Date).Value = pFechaFinal.Date;
            }
            else if(nombrecaja!="-1")
            {
                cmd.Parameters.AddWithValue("@idcaja", SqlDbType.NVarChar).Value = nombrecaja;
                cmd.Parameters.AddWithValue("@idempleado", SqlDbType.BigInt).Value = -1;

                cmd.Parameters.AddWithValue("@FechaInicial", SqlDbType.Date).Value = pFechaInicial.Date;
                cmd.Parameters.AddWithValue("@FechaFinal", SqlDbType.Date).Value = pFechaFinal.Date;
            }

            cmd.CommandType = CommandType.StoredProcedure;

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<Tuple<float, DateTime>> resultado = new List<Tuple<float, DateTime>>();

            while (rdr.Read())
            {
                resultado.Add(new Tuple<float, DateTime>(float.Parse(rdr[0].ToString()), Convert.ToDateTime(rdr[1].ToString())));
            }

            ob.CerrarConexionBD();

            return resultado;
        }
    }

}
