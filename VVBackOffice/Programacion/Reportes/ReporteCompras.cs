using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerde.Programacion.Reportes
{
    class ReporteCompras
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();
        public List<String[]> Obtenerlineas()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerLineas", ob.ObtenerConexion());

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

        public List<String[]> Obtenerfabricantes()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerFabricantes", ob.ObtenerConexion());

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

        public List<String[]> Obtenerproveedores()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerListaProveedores", ob.ObtenerConexion());

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
        public List<String[]> Obtenermarcas()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerMarcas", ob.ObtenerConexion());

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

        public List<Tuple<float, DateTime>> ComprasMes(int mes, int anocompra,  string idlinea, int idmarca, int idfabricante, int idproveedor)
        {
            ob.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("ReporteComprasMesYear", ob.ObtenerConexion());

            if (idlinea == "-1" && idmarca == -1 && idfabricante == -1 && idproveedor == -1)
            {
                cmd.Parameters.AddWithValue("@idlinea", SqlDbType.NVarChar).Value = "-1";
                cmd.Parameters.AddWithValue("@idmarca", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@idfabricante", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@idproveedor", SqlDbType.BigInt).Value = -1;
            }
            else if (idlinea != "-1" && idmarca == -1 && idfabricante == -1 && idproveedor == -1)
            {
                cmd.Parameters.AddWithValue("@idlinea", SqlDbType.NVarChar).Value = idlinea;
                cmd.Parameters.AddWithValue("@idmarca", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@idfabricante", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@idproveedor", SqlDbType.BigInt).Value = -1;
            }
            else if (idlinea == "-1" && idmarca != -1 && idfabricante == -1 && idproveedor == -1)
            {
                cmd.Parameters.AddWithValue("@idlinea", SqlDbType.NVarChar).Value = -1;
                cmd.Parameters.AddWithValue("@idmarca", SqlDbType.BigInt).Value = idmarca;
                cmd.Parameters.AddWithValue("@idfabricante", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@idproveedor", SqlDbType.BigInt).Value = -1;
            }
            else if (idlinea == "-1" && idmarca == -1 && idfabricante != -1 && idproveedor == -1)
            {
                cmd.Parameters.AddWithValue("@idlinea", SqlDbType.NVarChar).Value = -1;
                cmd.Parameters.AddWithValue("@idmarca", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@idfabricante", SqlDbType.BigInt).Value = idfabricante;
                cmd.Parameters.AddWithValue("@idproveedor", SqlDbType.BigInt).Value = -1;
            }
            else if (idlinea == "-1" && idmarca == -1 && idfabricante == -1 && idproveedor != -1)
            {
                cmd.Parameters.AddWithValue("@idlinea", SqlDbType.NVarChar).Value = -1;
                cmd.Parameters.AddWithValue("@idmarca", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@idfabricante", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@idproveedor", SqlDbType.BigInt).Value = idproveedor;
            }
            cmd.Parameters.AddWithValue("@mes", SqlDbType.BigInt).Value = mes;
            cmd.Parameters.AddWithValue("@anocompra", SqlDbType.BigInt).Value = anocompra;
            cmd.Parameters.AddWithValue("@year", SqlDbType.BigInt).Value = -1;
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
        public List<Tuple<float, DateTime>> ComprasYear(int year, string idlinea, int idmarca, int idfabricante, int idproveedor)
        {
            ob.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("ReporteComprasMesYear", ob.ObtenerConexion());

            if (idlinea == "-1" && idmarca == -1 && idfabricante == -1 && idproveedor == -1)
            {
                cmd.Parameters.AddWithValue("@idlinea", SqlDbType.NVarChar).Value = "-1";
                cmd.Parameters.AddWithValue("@idmarca", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@idfabricante", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@idproveedor", SqlDbType.BigInt).Value = -1;
               
            }
            else if (idlinea != "-1" && idmarca == -1 && idfabricante == -1 && idproveedor == -1)
            {
                cmd.Parameters.AddWithValue("@idlinea", SqlDbType.NVarChar).Value = idlinea;
                cmd.Parameters.AddWithValue("@idmarca", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@idfabricante", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@idproveedor", SqlDbType.BigInt).Value = -1;
            }
            else if (idlinea == "-1" && idmarca != -1 && idfabricante == -1 && idproveedor == -1)
            {
                cmd.Parameters.AddWithValue("@idlinea", SqlDbType.NVarChar).Value = -1;
                cmd.Parameters.AddWithValue("@idmarca", SqlDbType.BigInt).Value = idmarca;
                cmd.Parameters.AddWithValue("@idfabricante", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@idproveedor", SqlDbType.BigInt).Value = -1;
            }
            else if (idlinea == "-1" && idmarca == -1 && idfabricante != -1 && idproveedor == -1)
            {
                cmd.Parameters.AddWithValue("@idlinea", SqlDbType.NVarChar).Value = -1;
                cmd.Parameters.AddWithValue("@idmarca", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@idfabricante", SqlDbType.BigInt).Value = idfabricante;
                cmd.Parameters.AddWithValue("@idproveedor", SqlDbType.BigInt).Value = -1;
            }
            else if (idlinea == "-1" && idmarca == -1 && idfabricante == -1 && idproveedor != -1)
            {
                cmd.Parameters.AddWithValue("@idlinea", SqlDbType.NVarChar).Value = -1;
                cmd.Parameters.AddWithValue("@idmarca", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@idfabricante", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@idproveedor", SqlDbType.BigInt).Value = idproveedor;
            }
            cmd.Parameters.AddWithValue("@mes", SqlDbType.BigInt).Value = -1;
            cmd.Parameters.AddWithValue("@anocompra", SqlDbType.BigInt).Value = -1;
            cmd.Parameters.AddWithValue("@year", SqlDbType.BigInt).Value = year;
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

        public List<Tuple<float, DateTime>> FechasCompras(string idlinea, int idmarca, int idfabricante, int idproveedor, DateTime dateInicial, DateTime dateFinal)
        {
            ob.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("ReporteComprasFechas", ob.ObtenerConexion());

            if (idlinea == "-1" && idmarca == -1 && idfabricante == -1 && idproveedor == -1)
            {
                cmd.Parameters.AddWithValue("@idlinea", SqlDbType.NVarChar).Value = "-1";
                cmd.Parameters.AddWithValue("@idmarca", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@idfabricante", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@idproveedor", SqlDbType.BigInt).Value = -1;
            }
            else if (idlinea != "-1" && idmarca == -1 && idfabricante == -1 && idproveedor == -1)
            {
                cmd.Parameters.AddWithValue("@idlinea", SqlDbType.NVarChar).Value = idlinea;
                cmd.Parameters.AddWithValue("@idmarca", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@idfabricante", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@idproveedor", SqlDbType.BigInt).Value = -1;
            }
            else if (idlinea == "-1" && idmarca != -1 && idfabricante == -1 && idproveedor == -1)
            {
                cmd.Parameters.AddWithValue("@idlinea", SqlDbType.NVarChar).Value = -1;
                cmd.Parameters.AddWithValue("@idmarca", SqlDbType.BigInt).Value = idmarca;
                cmd.Parameters.AddWithValue("@idfabricante", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@idproveedor", SqlDbType.BigInt).Value = -1;
            }
            else if (idlinea == "-1" && idmarca == -1 && idfabricante != -1 && idproveedor == -1)
            {
                cmd.Parameters.AddWithValue("@idlinea", SqlDbType.NVarChar).Value = -1;
                cmd.Parameters.AddWithValue("@idmarca", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@idfabricante", SqlDbType.BigInt).Value = idfabricante;
                cmd.Parameters.AddWithValue("@idproveedor", SqlDbType.BigInt).Value = -1;
            }
            else if (idlinea == "-1" && idmarca == -1 && idfabricante == -1 && idproveedor != -1)
            {
                cmd.Parameters.AddWithValue("@idlinea", SqlDbType.NVarChar).Value = -1;
                cmd.Parameters.AddWithValue("@idmarca", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@idfabricante", SqlDbType.BigInt).Value = -1;
                cmd.Parameters.AddWithValue("@idproveedor", SqlDbType.BigInt).Value = idproveedor;
            }
            cmd.Parameters.AddWithValue("@FechaInicial", SqlDbType.Date).Value = dateInicial;
            cmd.Parameters.AddWithValue("@FechaFinal", SqlDbType.Date).Value = dateFinal;
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
    }
}
