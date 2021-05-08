using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerde.Programacion.Inventario
{
    class Existencias
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();

        public List<String[]> ObtenerInformacionCompletaProductos(int marca, int linea, int fabricante, int proveedor, int almacen, bool precioDeCosto, int numeroProductosPorPagina, int numeroPagina, string buscar)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerInformacionCompletaProductos", ob.ObtenerConexion());

            cmd.CommandTimeout = 300;
            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@marca", marca));
            cmd.Parameters.Add(new SqlParameter("@linea", linea));
            cmd.Parameters.Add(new SqlParameter("@fabricante", fabricante));
            cmd.Parameters.Add(new SqlParameter("@proveedor", proveedor));
            cmd.Parameters.Add(new SqlParameter("@almacen", almacen));
            cmd.Parameters.Add(new SqlParameter("@precioDeCosto", precioDeCosto));
            cmd.Parameters.Add(new SqlParameter("@numeroProductosPorPagina", numeroProductosPorPagina));
            cmd.Parameters.Add(new SqlParameter("@numeroPagina", numeroPagina));
            cmd.Parameters.Add(new SqlParameter("@buscar", buscar));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> res = new List<string[]>();
            while (rdr.Read())
            {
                res.Add(new String[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + "", rdr[6] + "", rdr[7] + "", rdr[8] + "", rdr[9] + "", rdr[10] + "", rdr[11] + "", rdr[12] + "", rdr[13] + "", rdr[14] + "", rdr[15] + "", rdr[16] + "", rdr[17] + "", rdr[18] + "", rdr[19] + "", rdr[20] + "", rdr[21] + "", rdr[22] + "", rdr[23] + "", rdr[24] + "", rdr[25] + "", rdr[26] + "" });
            }

            ob.CerrarConexionBD();

            return res;
        }

        public List<String[]> ObtenerClavesAdicionales(string Cod)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerClavesAdicionalesConPrecio", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Cod", Cod));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> res = new List<string[]>();
            while (rdr.Read())
            {
                res.Add(new String[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "" });
            }

            ob.CerrarConexionBD();

            return res;
        }
    }
}
