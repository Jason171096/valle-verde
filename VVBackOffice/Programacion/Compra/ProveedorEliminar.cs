using System;
using System.Data;
using System.Data.SqlClient;

namespace ValleVerde.Programacion
{
    class ProveedorEliminar
    {
        ValleVerdeComun.ConexionBD obj = new ValleVerdeComun.ConexionBD();
        public void EliminarProveedor(long idProSel)
        {
            obj.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("EliminarProveedor", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idPro", idProSel));
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine(rdr[0]);
            }

            obj.CerrarConexionBD();
        }
    }
}
