using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ValleVerdeComun.Programacion
{
    class Lineas
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();

        public List<String[]> ObtenerLineas()
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
                resultado.Add(new String[] {rdr[0]+"", rdr[1]+"", rdr[2]+""});
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public string ObtenerLineaProducto(string idProd)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerLineaProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            string res = "";
            while (rdr.Read())
            {
                res = rdr[0] + "";
            }

            ob.CerrarConexionBD();

            return res;
        }

        public void AltaNuevaLinea(String Nombre, String Descripcion)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AltaLinea", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Nom", Nombre));
            cmd.Parameters.Add(new SqlParameter("@des", Descripcion));


            // execute the command
            cmd.ExecuteReader();
            

            ob.CerrarConexionBD();
        }

        public int NoProductosLinea(String IDLinea)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("NoProductosLinea", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Id", IDLinea));


            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            // iterate through results, printing each to console
            int nop = 0;

            while (rdr.Read())
            {
                nop = int.Parse(rdr[0]+"");
            }

            
            ob.CerrarConexionBD();

            return nop;
        }

       public int EliminarLinea(String IDLinea)
       {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("EliminarLinea", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Id", IDLinea));


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
