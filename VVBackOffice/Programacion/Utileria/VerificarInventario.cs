using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;

namespace ValleVerde.Programacion.Utileria
{
    class VerificarInventario
    {
        Utileria obj = new Utileria();

        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();

        public object[] VerificarExistencia(String IDProducto)
        {
            Object[] producto = obj.VerificarExistencia(IDProducto);
            return producto;
        }



        public List<string[]> ObtenerProductosAVerificar()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerProductosAVerificar", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.Add(new SqlParameter("@buscar", buscar));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<string[]> resultado = new List<string[]>();

            while (rdr.Read())
            {
                resultado.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "",rdr[3]+"" });
            }

            ob.CerrarConexionBD();

            return resultado;
        }


        public List<string[]> ObtenerUbicacionesAVerificar(String IDVerificar,String IDUsuario)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerUbicacionesAVerificar", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idVerif", IDVerificar));
            cmd.Parameters.Add(new SqlParameter("@idUser", IDUsuario));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<string[]> resultado = new List<string[]>();

            while (rdr.Read())
            {
                resultado.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[3] + "", rdr[4] + "" });
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public List<string[]> ObtenerUbicaciones()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerUbicaciones", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.Add(new SqlParameter("@buscar", buscar));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<string[]> resultado = new List<string[]>();

            while (rdr.Read())
            {
                resultado.Add(new string[] { rdr[0] + "", rdr[1] + "", });
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public List<string[]> ActualizarVerificarExistencia(String IDVerificar)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ActualizarVerificarExistencia", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idVerif", IDVerificar));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<string[]> resultado = new List<string[]>();

            while (rdr.Read())
            {
                resultado.Add(new string[] { rdr[0] + "" });
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public void ActualizarCantidadUbicacion(long idVerExi, decimal can)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ActualizarCantidadUbicacion", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idVerExi", idVerExi));
            cmd.Parameters.Add(new SqlParameter("@can", can));

            // execute the command
            //SqlDataReader rdr = 
                cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            //List<string[]> resultado = new List<string[]>();

            //while (rdr.Read())
            //{
            //    resultado.Add(new string[] { rdr[0] + "", rdr[1]+ ""});
            //}

            ob.CerrarConexionBD();

            //return resultado;
        }

        public List<string[]> ActualizarUbicacionAVerrificar(String idUnico, float cant)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ActualizarUbicacionAVerificar", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idUnico", idUnico));
            cmd.Parameters.Add(new SqlParameter("@cant", cant));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<string[]> resultado = new List<string[]>();

            while (rdr.Read())
            {
                resultado.Add(new string[] { rdr[0] + "" });
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public object AgregarProductosAVerificar(String codBarras)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AgregarProductosAVerificar", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@codBarras", codBarras));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            object resultado = new object();

            while (rdr.Read())
            {
                resultado = rdr[0];
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public object AgregarUbicacionAVerificar(long idVerif, long idUbic, long idUser)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AgregarUbicacionAVerificar", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idVerif", idVerif));
            cmd.Parameters.Add(new SqlParameter("@idUbic", idUbic));
            cmd.Parameters.Add(new SqlParameter("@idUser", idUser));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            object resultado = new object();

            while (rdr.Read())
            {
                resultado = rdr[0];
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public object ObtenerExistenciaTotalProducto(String codigo)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerExistenciaTotalProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Cod", codigo));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            object resultado = new object();

            while (rdr.Read())
            {
                resultado = rdr[0];
            }

            ob.CerrarConexionBD();

            return resultado;
        }
    }
}
