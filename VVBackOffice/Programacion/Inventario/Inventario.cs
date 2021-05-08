using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace ValleVerde.Programacion.Inventario
{



    class Inventario
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();

        public float ObtenerCostoInventario()
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerCostoInventario", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                float res = 0;
                while (rdr.Read())
                {
                    res = float.Parse(rdr[0] + "");
                }
                ob.CerrarConexionBD();

                return res;
            }
        }

        public float ObtenerNumeroProductosInventario()
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerNumeroProductosInventario", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                float res = 0;
                while (rdr.Read())
                {
                    res = float.Parse(rdr[0] + "");
                }
                ob.CerrarConexionBD();

                return res;
            }
        }
        public double ObtenerNumeroPiezasInventario()
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerNumeroPiezasInventario", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();
            
            // iterate through results, printing each to console
            double res = 0;
            while (rdr.Read())
            {
                res = double.Parse(rdr[0] + "");
            }
            ob.CerrarConexionBD();

            return res;
            
        }
    }
    
}
