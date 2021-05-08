using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ValleVerde.Programacion.Utileria
{
    public class ClaseCodigosPreescaneados
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();
        

        public List<String[]> CodigosPreescaneados()
        {
            ob.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("ObtenerEtiquetasPreescaneadas", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idusuario", SqlDbType.BigInt).Value = -1;
            // execute the command
            SqlDataReader reader = cmd.ExecuteReader();

            List<String[]> codigos = new List<String[]>();
            while (reader.Read())
            {
                codigos.Add(new string[] { reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString() });
            }

            ob.CerrarConexionBD();

            return codigos;
        }
        public void GuardarEtiquetas(string codigoproducto, string idusuario)
        {
            ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();

            ob.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("GuardarEtiquetaPreescaneada", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idusuario", SqlDbType.BigInt).Value = idusuario;
            cmd.Parameters.AddWithValue("@codbarras", SqlDbType.NVarChar).Value = codigoproducto;

            cmd.ExecuteNonQuery();

            ob.CerrarConexionBD();
        }

        public void BorrarEtiquetas(string idproducto)
        {
            ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();

            ob.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("BorrarEtiquetaPreescaneada", ob.ObtenerConexion());

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idetiqueta", idproducto));
            cmd.ExecuteNonQuery();

            ob.CerrarConexionBD();
        }
    }
}
