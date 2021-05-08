using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ValleVerde.Programacion.Compra
{
    class Devoluciones
    {
        ValleVerdeComun.ConexionBD obj = new ValleVerdeComun.ConexionBD();
        public List<object[]> ObtenerDevoluciones(bool LLevaCompra, int IDCompra)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerDevoluciones", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@llevacompra", LLevaCompra));
            cmd.Parameters.Add(new SqlParameter("@idcompra", IDCompra));
            SqlDataReader rdr = cmd.ExecuteReader();

            List<object[]> res = new List<object[]>();

            while (rdr.Read())
            {
                res.Add(new object[] { rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7] });
            }

            obj.CerrarConexionBD();

            return res;
        }
    }
}
