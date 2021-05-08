using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;

namespace ValleVerde.Programacion.Compra
{
    class Proveedor
    {

        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();


        public List<String[]> ObtenerTodosProveedores(String estado, String ciudad, String buscar, int activo)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerTodosProveedores", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@estado", estado));
            cmd.Parameters.Add(new SqlParameter("@ciudad", ciudad));
            cmd.Parameters.Add(new SqlParameter("@buscar", buscar));
            cmd.Parameters.Add(new SqlParameter("@activo", activo));
            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<String[]> resultado =new  List<String[]>();

            while (rdr.Read())
            {
                resultado.Add(new string[] { rdr[0]+"",rdr[1] +"", rdr[2] + "",rdr[3] +"", rdr[4] + "", rdr[5] + "", rdr[6] + "", rdr[7] + "", rdr[8] + "", rdr[9] + "", rdr[10] + "", rdr[11] + "", rdr[12] + "", rdr[13] + "", rdr[14] + "", rdr[15] + "", rdr[16] + "",rdr[17] + ""});
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public List<String[]> ObtenerEstados()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerEstados", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<String[]> resultado = new List<String[]>();

            while (rdr.Read())
            {
                resultado.Add(new String[] { rdr[0] + ""});
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public List<String[]> ObtenerCiudades()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerCiudades", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;


            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<String[]> resultado = new List<String[]>();

            while (rdr.Read())
            {
                resultado.Add(new String[] { rdr[0] + ""});
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public void ActualizarProveedorPorCampos(long idprov, string nombre, string valor)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand($"update Proveedor set {nombre} = '{valor}' where IDProveedor = {idprov}", ob.ObtenerConexion());
            //SqlCommand cmd = new SqlCommand("ActualizarProveedorPorCampos", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            //cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.Add(new SqlParameter("@IDProveedor", idprov));
            //cmd.Parameters.Add(new SqlParameter("@NombreColumna", nombre));
            //cmd.Parameters.Add(new SqlParameter("@Valor", valor));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            //List<String[]> resultado = new List<String[]>();

            //while (rdr.Read())
            //{
            //    resultado.Add(new String[] { rdr[0] + "" });
            //}

            ob.CerrarConexionBD();

           // return resultado;
        }

    }
}
