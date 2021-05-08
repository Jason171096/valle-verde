using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ValleVerde.Programacion
{
    class ClavesSAT
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();

        public List<String[]> ObtenerClavesSAT()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerClavesSAT", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<String[]> resultado = new List<String[]>();

            while (rdr.Read())
            {
                resultado.Add(new String[] {rdr[0]+"", rdr[1]+""});
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public int AltaNuevaClaveSAT(String clave, String Descripcion)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AltaClaveSAT", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Clave", clave));
            cmd.Parameters.Add(new SqlParameter("@Des", Descripcion));


            // execute the command]
            SqlDataReader rdr = cmd.ExecuteReader();

            // iterate through results, printing each to console
            int res = -1;

            while (rdr.Read())
            {
                res = int.Parse(rdr[0] + "");
            }


           
            ob.CerrarConexionBD();
            return res;
        }

        public string[] ObtenerClaveSATProducto(string idProd)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerClaveSATProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            string[] res = null;
            while (rdr.Read())
            {
                res = new string[] { rdr[0] + "", rdr[1] + "" };
            }

            ob.CerrarConexionBD();

            return res;
        }

        public int VincularProductoConClaveSAT(String IDProd, String IDClaveSAT)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("VincularProductoConClaveSAT", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@IDProd", IDProd));
            cmd.Parameters.Add(new SqlParameter("@IDClaveSAT", IDClaveSAT));


            // execute the command]
            SqlDataReader rdr = cmd.ExecuteReader();

            // iterate through results, printing each to console
            int res = -1;

            while (rdr.Read())
            {
                res = int.Parse(rdr[0] + "");
            }



            ob.CerrarConexionBD();
            return res;
        }

        public int EliminarClaveSAT(String IDUnidad)
       {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("EliminarClaveSAT", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Id", IDUnidad));


            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            // iterate through results, printing each to console
            int res = 0;

            while (rdr.Read())
            {
                res = int.Parse(rdr[0] + "");
            }


            ob.CerrarConexionBD();
            return res;
       }
    }
}
