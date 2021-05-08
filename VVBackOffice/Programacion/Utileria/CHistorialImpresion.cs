using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ValleVerde.Programacion.Utileria
{
    class CHistorialImpresion
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();
        
        public void AgregarHistorialEtiquetasImpresas(string idusuario, string idproducto, int cantidad, bool conprecio, bool porcambioprecio)
        {
            ob.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("AgregarHistorialEtiquetasImpresas", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idusuario", idusuario));
            cmd.Parameters.Add(new SqlParameter("@idproducto", idproducto));
            cmd.Parameters.Add(new SqlParameter("@cantidad", cantidad));
            cmd.Parameters.Add(new SqlParameter("@conprecio", conprecio));
            cmd.Parameters.Add(new SqlParameter("@porcambioprecio", porcambioprecio));
            cmd.ExecuteNonQuery();
            ob.CerrarConexionBD();
        }
        public List<object[]> ObtenerHistorialImpresion(string idusuario, DateTime fechainicio, DateTime fechafin, int filtrarfecha, int pegado, int finalizado, int conprecio, int porcambioprecio)
        {
            ob.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("ObtenerHistorialEtiquetasImpresas", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idusuario));
            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechainicio));
            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechafin));
            cmd.Parameters.Add(new SqlParameter("@filtrarPorFecha", filtrarfecha));
            cmd.Parameters.Add(new SqlParameter("@pegado", pegado));
            cmd.Parameters.Add(new SqlParameter("@finalizado", finalizado));
            cmd.Parameters.Add(new SqlParameter("@conPrecio", conprecio));
            cmd.Parameters.Add(new SqlParameter("@porCambioPrecio", porcambioprecio));
            SqlDataReader rdr = cmd.ExecuteReader();
            List<object[]> res = new List<object[]>();
            while(rdr.Read())
            {          
                res.Add(new object[] { rdr[0], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12] });
            }
            ob.CerrarConexionBD();
            return res;
        }

        public void ActualizarHistorialImpresion(string idetiqueta, string idusuario)
        {
            ob.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("ActualizarHistorialEtiquetasImpresas", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idetiqueta", idetiqueta));
            cmd.Parameters.Add(new SqlParameter("@idusuario", idusuario));
            cmd.ExecuteNonQuery();
            ob.CerrarConexionBD();
        }
    } 
}
