using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerde.Programacion.Inventario
{
    class EntradaRegistrar
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();

        public string[] ObtenerProducto(string buscar)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerProductos", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@marca", -1));
            cmd.Parameters.Add(new SqlParameter("@linea", -1));
            cmd.Parameters.Add(new SqlParameter("@fabricante", -1));
            cmd.Parameters.Add(new SqlParameter("@proveedor", -1));
            cmd.Parameters.Add(new SqlParameter("@almacen", -1)); 
            cmd.Parameters.Add(new SqlParameter("@precioDeCosto", false));
            cmd.Parameters.Add(new SqlParameter("@numeroProductosPorPagina", -1));
            cmd.Parameters.Add(new SqlParameter("@numeroPagina", -1));
            cmd.Parameters.Add(new SqlParameter("@buscar", buscar));
            cmd.Parameters.Add(new SqlParameter("@soloClavesAdicionales", false));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            string[] res = new string[4];
            while (rdr.Read())
            {
                res = new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "" };
            }

            ob.CerrarConexionBD();

            return res;
        }

        public List<string[]> ObtenerAlmacenProducto(string idProducto)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerAlmacenesProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Cod", idProducto));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            List<string[]> res = new List<string[]>();
            while (rdr.Read())
            {
                res.Add( new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "" });
            }

            ob.CerrarConexionBD();

            return res;
        }

        public List<Image> ObtenerImagenesProducto(string idProd)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerImagenesProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            List<Image> res = new List<Image>();
            while (rdr.Read())
            {
                byte[] b = (byte[])rdr.GetValue(0);

                Image img = Image.FromStream(new MemoryStream(b));

                res.Add(img);
            }

            ob.CerrarConexionBD();

            return res;
        }

        public int ObtenerCantidadImagenesProducto(string idProd)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerCantidadImagenesProducto", ob.ObtenerConexion());

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

        public string ActualizarExistenciaProducto(string idProd, int idAlmacen, float cantidad, string concepto, string obsevaciones, bool merma, int idAlmacenAntes, int idUsuario)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ActualizarExistenciaProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));
            cmd.Parameters.Add(new SqlParameter("@idAlmacen", idAlmacen));
            //cmd.Parameters.Add(new SqlParameter("@existencia", existencia));
            cmd.Parameters.Add(new SqlParameter("@cantidad", cantidad));
            cmd.Parameters.Add(new SqlParameter("@concepto", concepto));
            cmd.Parameters.Add(new SqlParameter("@observaciones", obsevaciones));
            cmd.Parameters.Add(new SqlParameter("@merma", merma));
            cmd.Parameters.Add(new SqlParameter("@idAlmacenAntes", idAlmacenAntes));
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            string res = "";
            while (rdr.Read())
            {
                res =  rdr[0] + "";
            }

            ob.CerrarConexionBD();

            return res;
        }

    }

}
