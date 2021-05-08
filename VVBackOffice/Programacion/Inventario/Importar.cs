using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerde.Programacion.Inventario
{
    class Importar
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();

        public string ActualizarInformacionProducto(string idProd,bool bNombre,string nombre,bool bCosto,float costo,bool bExistencia, float existencia, int almacen, int idUsuario, bool precios, float utilidad, int cant2, float util2, int cant3, float util3, int cant4, float util4, int cant5, float util5,int iva, int ieps, bool actualizarInsertar)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ActualizarInformacionProducto", ob.ObtenerConexion());

            cmd.CommandTimeout = 300;
            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));
            cmd.Parameters.Add(new SqlParameter("@bNombre", bNombre));
            cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
            cmd.Parameters.Add(new SqlParameter("@bCosto", bCosto));
            cmd.Parameters.Add(new SqlParameter("@costo", costo));
            cmd.Parameters.Add(new SqlParameter("@bExistencia", bExistencia));
            cmd.Parameters.Add(new SqlParameter("@existencia", existencia));
            cmd.Parameters.Add(new SqlParameter("@almacen", almacen));
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
            cmd.Parameters.Add(new SqlParameter("@precios", precios));
            cmd.Parameters.Add(new SqlParameter("@utilidad", utilidad)); 
            cmd.Parameters.Add(new SqlParameter("@cant2", cant2));
            cmd.Parameters.Add(new SqlParameter("@util2", util2));
            cmd.Parameters.Add(new SqlParameter("@cant3", cant3));
            cmd.Parameters.Add(new SqlParameter("@util3", util3));
            cmd.Parameters.Add(new SqlParameter("@cant4", cant4));
            cmd.Parameters.Add(new SqlParameter("@util4", util4));
            cmd.Parameters.Add(new SqlParameter("@cant5", cant5));
            cmd.Parameters.Add(new SqlParameter("@util5", util5));
            cmd.Parameters.Add(new SqlParameter("@iva", iva));
            cmd.Parameters.Add(new SqlParameter("@ieps", ieps));
            cmd.Parameters.Add(new SqlParameter("@actualizarInsertar", actualizarInsertar));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            string res = "-1";

            while (rdr.Read())
            {
                res = rdr[0] + "";
            }

            ob.CerrarConexionBD();

            return res;
        }
    }
}
