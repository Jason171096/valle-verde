using System.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows;

namespace ValleVerde.Programacion.Utileria
{
    class Utileria
    {
        ValleVerdeComun.ConexionBD obj = new ValleVerdeComun.ConexionBD();

        public object[] VerificarExistencia(String IDProducto)
        {
            obj.AbrirConexionBD();

            SqlCommand cmd=new SqlCommand("ObtenerVerificarExistencia", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@IDPRODUCTO", IDProducto));
            SqlDataReader rdr = cmd.ExecuteReader();

            object[] res = new object[3];

            while(rdr.Read())
            {
                try
                {
                    if (int.Parse(rdr[0].ToString())<0)
                    {
                        res[0] = rdr[0];
                    }
                    else
                    {
                        res[0] = rdr[0];
                        res[1] = rdr[1];
                        res[2] = rdr[2];
                    }
                    
                }
                catch
                {
                    res[0] = rdr[0];
                    res[1] = rdr[1];
                    res[2] = rdr[2];
                }

            }

            obj.CerrarConexionBD();


            return res;
        }
    }
}
