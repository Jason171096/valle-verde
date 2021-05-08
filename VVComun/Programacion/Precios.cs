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
    public class Precios
    {
        ConexionBD ob = new ConexionBD();

        

        public int ObtenerCantidadPreciosProducto(string idProd)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerCantidadPreciosProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            int res = 0;
            while (rdr.Read())
            {
                res = int.Parse(rdr[0] + "");
            }

            ob.CerrarConexionBD();

            return res;
        }

        public decimal ObtenerCostoProducto(string idProd)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerCostoProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            decimal res = 0;
            while (rdr.Read())
            {
                res = decimal.Parse(rdr[0] + "");
            }

            ob.CerrarConexionBD();

            return res;
        }

        public List<decimal[]> ObtenerPreciosCostoProducto(string idProd)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd;

            cmd = new SqlCommand("ObtenerPreciosCostoProducto", ob.ObtenerConexion());
            

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            List<decimal[]> res = new List<decimal[]>();
            while (rdr.Read())
            {
                //Utilidad - Cantidad
                res.Add( new decimal[] { decimal.Parse(rdr[0] + ""), decimal.Parse(rdr[1] + "") });
            }

            ob.CerrarConexionBD();

            return res;
        }

        public decimal ObtenerPrecioProducto(string idProd,decimal cantidad, decimal utilidadSobreCosto, decimal descuento,bool pagoConTarjeta)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd;

            cmd = new SqlCommand("ObtenerPrecioProducto", ob.ObtenerConexion());


            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));
            cmd.Parameters.Add(new SqlParameter("@Cant", cantidad));
            cmd.Parameters.Add(new SqlParameter("@utilidadSobreCosto", utilidadSobreCosto));
            cmd.Parameters.Add(new SqlParameter("@descuento", descuento));
            cmd.Parameters.Add(new SqlParameter("@pagoConTarjeta", pagoConTarjeta));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            decimal res = -1;
            while (rdr.Read())
            {
                //Utilidad - Cantidad
                res = decimal.Parse(rdr[0] + "");
            }

            ob.CerrarConexionBD();

            return res;
        }

        public decimal[] ObtenerPrecioYDescuentoProducto(string idProd, decimal cantidad, decimal utilidadSobreCosto, decimal descuento,bool pagoConTarjeta)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd;

            cmd = new SqlCommand("ObtenerPrecioProducto", ob.ObtenerConexion());


            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));
            cmd.Parameters.Add(new SqlParameter("@Cant", cantidad));
            cmd.Parameters.Add(new SqlParameter("@utilidadSobreCosto", utilidadSobreCosto));
            cmd.Parameters.Add(new SqlParameter("@descuento", descuento));
            cmd.Parameters.Add(new SqlParameter("@pagoConTarjeta", pagoConTarjeta));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            decimal[] res = new decimal[3];
            while (rdr.Read())
            {
                //Utilidad - Cantidad
                res[0] = decimal.Parse(rdr[0] + "");
                res[1] = decimal.Parse(rdr[1] + "");
                res[2] = decimal.Parse(rdr[2] + "");
            }

            ob.CerrarConexionBD();

            return res;
        }

        public decimal ObtenerPrecioDolar()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd;

            cmd = new SqlCommand("ObtenerPrecioDolar", ob.ObtenerConexion());


            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            decimal res = 0.0m;
            while (rdr.Read())
            {
                res = decimal.Parse(rdr[0] + "");
            }

            ob.CerrarConexionBD();

            return res;
        }

        public decimal RedondearTotal(decimal total)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd;

            cmd = new SqlCommand("RedondearTotal", ob.ObtenerConexion());


            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@total", total));

            // execute the command
            
            SqlDataReader rdr = cmd.ExecuteReader();

            decimal res = 0.0m;
            while (rdr.Read())
            {
                res = decimal.Parse(rdr[0] + "");
            }

            ob.CerrarConexionBD();

            return res;
        }

        public void AltaNuevaUnidad(String Nombre, String Descripcion, String ClaveSat)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AltaUnidad", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Nom", Nombre));
            cmd.Parameters.Add(new SqlParameter("@Des", Descripcion));
            cmd.Parameters.Add(new SqlParameter("@Clave", ClaveSat));


            // execute the command
            cmd.ExecuteReader();
            ob.CerrarConexionBD();
        }

       public int EliminarUnidad(String IDUnidad)
       {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("EliminarUnidad", ob.ObtenerConexion());

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
