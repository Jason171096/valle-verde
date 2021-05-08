using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerdeComun.Programacion.InicioSesion
{
    class InicioSesion
    {
        ConexionBD obj = new ConexionBD();

        internal Huellas.ResultadoHuella VerificarUsuarioContrasena(string usuario, string contrasena,bool debeSerAdministrador,string idUsuarioNecesario)
        {
            obj.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("VerificarUsuarioContrasena", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@usu", usuario));
            cmd.Parameters.Add(new SqlParameter("@con", contrasena));
            cmd.Parameters.Add(new SqlParameter("@debeSerAdministrador", debeSerAdministrador));
            cmd.Parameters.Add(new SqlParameter("@idUsuarioNecesario", idUsuarioNecesario));
            SqlDataReader rdr = cmd.ExecuteReader();

            Huellas.ResultadoHuella res = null;

            while (rdr.Read())
            {
                if (rdr[0] + "" != "0")
                {
                   
                    res = new Huellas.ResultadoHuella();
                    res.IDUsuario = rdr[0] + "";
                    res.Nombres = rdr[1] + "";
                    res.Apellidos = rdr[2] + "";
                    res.templateBD = null;
                    res.templateLengthBD = 0;
                    res.nombre = "";
                    res.esAdministrador = Convert.ToBoolean(rdr[3] + "");
                }

            }

            obj.CerrarConexionBD();

            return res;
        }
    }
}
