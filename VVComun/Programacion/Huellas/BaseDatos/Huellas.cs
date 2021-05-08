using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ValleVerdeComun.Programacion.Huellas.BaseDatos
{
    public class Huellas
    {
        ConexionBD ob = new ConexionBD();

        

        public int AltaNuevaHuella(string idUsuario,byte[] template, uint templateLen)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AltaHuella", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
            cmd.Parameters.Add(new SqlParameter("@template", template));
            cmd.Parameters.Add(new SqlParameter("@templateLen", Convert.ToInt32(templateLen)));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            int res = 0;
            while (rdr.Read())
            {
                res = int.Parse(rdr[0] + "");
            }

            ob.CerrarConexionBD();

            return res;
        }

        public List<ResultadoHuella> ObtenerHuellas(bool debeSerAdministrador,string idUsuarioNecesario)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd;

            cmd = new SqlCommand("ObtenerHuellas", ob.ObtenerConexion());
            

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@debeSerAdministrador", debeSerAdministrador));
            cmd.Parameters.Add(new SqlParameter("@idUsuarioNecesario", idUsuarioNecesario));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            List<ResultadoHuella> res = new List<ResultadoHuella>();
            while (rdr.Read())
            {
                ResultadoHuella ob = new ResultadoHuella();
                ob.IDUsuario = rdr[0] + "";
                ob.Nombres = rdr[1] + "";
                ob.Apellidos = rdr[2] + "";
                ob.templateBD = rdr.GetSqlBytes(3).Value;
                String tml = rdr[4] + "";
                int ent = int.Parse(tml);
                ob.templateLengthBD = Convert.ToUInt32(ent);
                ob.nombre = rdr[5] + "";
                ob.esAdministrador = Convert.ToBoolean( rdr[6] + "");

                res.Add(ob);
            }

            ob.CerrarConexionBD();

            return res;
        }

        
    }
}
