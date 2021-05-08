using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerde.Programacion.Inventario
{
    class EntradasSalidas
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();

        public List<string[]> ObtenerKardexProducto(bool entrada, bool salida, bool compra, bool venta, bool devolucion, string idProducto, DateTime fechaInicio, DateTime fechaFin)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlConnection con = ob.ObtenerConexion();

            SqlCommand cmd = new SqlCommand("ObtenerKardexProducto", con);
            
            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.Add(new SqlParameter("@todo", todo));
            //cmd.Parameters.Add(new SqlParameter("@fechaBandera", fecha));
            cmd.Parameters.Add(new SqlParameter("@entrada", entrada));
            cmd.Parameters.Add(new SqlParameter("@salida", salida));
            //cmd.Parameters.Add(new SqlParameter("@producto", producto));
            cmd.Parameters.Add(new SqlParameter("@compra", compra));
            cmd.Parameters.Add(new SqlParameter("@venta", venta));
            cmd.Parameters.Add(new SqlParameter("@devolucion", devolucion));
            cmd.Parameters.Add(new SqlParameter("@idProd", idProducto));
            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            List<string[]> res = new List<string[]>();
            while (rdr.Read())
            {
                res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + "", rdr[6] + "", rdr[7] + "", rdr[8] + "", rdr[9] + "" });
            }

            ob.CerrarConexionBD();

            return res;
        }

        public string ObtenerNombreProducto(string idProducto)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerNombreProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Cod", idProducto));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            string resultado = "";

            while (rdr.Read())
            {
                resultado = rdr[0] + "";
            }

            ob.CerrarConexionBD();

            return resultado;
        }

    }
}
