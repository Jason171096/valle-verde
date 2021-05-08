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
    class Almacenes
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();

        public List<String[]> ObtenerAlmacenes()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerAlmacenes", ob.ObtenerConexion());

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

        public List<String[]> ObtenerDepartamentos()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerDepartamentos", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<String[]> resultado = new List<String[]>();

            while (rdr.Read())
            {
                resultado.Add(new String[] { rdr[0] + "", rdr[1] + "" });
            }

            ob.CerrarConexionBD();

            return resultado;
        }


        public List<String[]> ObtenerAlmacenesProducto(string idProd)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerAlmacenesProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<String[]> resultado = new List<String[]>();

            while (rdr.Read())
            {
                resultado.Add(new String[] { rdr[0] + "", rdr[1] + "" , rdr[2] + "" });
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public int ActualizarAlmacenProducto(string idProd,string idAlmacen, string ubicacion)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ActualizarAlmacenProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));
            cmd.Parameters.Add(new SqlParameter("@idAlmacen", idAlmacen));
            cmd.Parameters.Add(new SqlParameter("@ubicacion", ubicacion));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            int resultado = -10;

            while (rdr.Read())
            {
                resultado = int.Parse( rdr[0] + "");
            }

            ob.CerrarConexionBD();

            return resultado;
        }
        public void AltaNuevoAlmacen(String Nombre, String Empresa)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AltaAlmacen", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Nom", Nombre));
            cmd.Parameters.Add(new SqlParameter("@IDEmpresa", Empresa));

            // execute the command
            cmd.ExecuteReader();

            ob.CerrarConexionBD();
        }

        public decimal NoProductosAlmacen(String IDAlmacen)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("NoProductosAlmacen", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Id", IDAlmacen));


            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            // iterate through results, printing each to console
            decimal nop = 0;

            while (rdr.Read())
            {
                nop = decimal.Parse(rdr[0]+"");
            }

            
            ob.CerrarConexionBD();

            return nop;
        }

       public int EliminarAlmacen(String IDAlmacen)
       {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("EliminarAlmacen", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Id", IDAlmacen));


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
