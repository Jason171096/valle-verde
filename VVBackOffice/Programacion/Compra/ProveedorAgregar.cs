using System;
using System.Data;
using System.Data.SqlClient;

namespace ValleVerde.Programacion
{
    class ProveedorAgregar
    {
        ValleVerdeComun.ConexionBD obj = new ValleVerdeComun.ConexionBD();

        public void AgregarProveedor(String nom, String dir, String ciu, String est, String tel, int diaCre, String corEle, int limCre, Boolean[] diaVis,String rfc, String cel, int idUsu, DateTime fecUsu)
        {
            obj.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("AgregarProveedor", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nom", nom));
            cmd.Parameters.Add(new SqlParameter("@dir", dir));
            cmd.Parameters.Add(new SqlParameter("@ciu", ciu));
            cmd.Parameters.Add(new SqlParameter("@est", est));
            cmd.Parameters.Add(new SqlParameter("@tel", tel));
            cmd.Parameters.Add(new SqlParameter("@diaCre", diaCre));
            cmd.Parameters.Add(new SqlParameter("@corEle", corEle));
            cmd.Parameters.Add(new SqlParameter("@limCre", limCre));
            cmd.Parameters.Add(new SqlParameter("@lun", diaVis[0]));
            cmd.Parameters.Add(new SqlParameter("@mar", diaVis[1]));
            cmd.Parameters.Add(new SqlParameter("@mie", diaVis[2]));
            cmd.Parameters.Add(new SqlParameter("@jue", diaVis[3]));
            cmd.Parameters.Add(new SqlParameter("@vie", diaVis[4]));
            cmd.Parameters.Add(new SqlParameter("@sab", diaVis[5]));
            cmd.Parameters.Add(new SqlParameter("@dom", diaVis[6]));
            cmd.Parameters.Add(new SqlParameter("@rfc", rfc));
            cmd.Parameters.Add(new SqlParameter("@cel", cel));
            cmd.Parameters.Add(new SqlParameter("@idUsu", idUsu));
            cmd.Parameters.Add(new SqlParameter("@fecUsu", fecUsu));
            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                Console.WriteLine(rdr[0]);
            }

            obj.CerrarConexionBD();
        }
    }
}
