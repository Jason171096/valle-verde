using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerde.Programacion.Utileria
{
    class RegistroChecador
    {

        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();

        public DateTime HoraServidor()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("SELECT GETDATE()", ob.ObtenerConexion());

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            DateTime resultado = new DateTime();
            // iterate through results, printing each to console
            while (rdr.Read())
            {
                resultado = DateTime.Parse(rdr[0]+"");
            }
            ob.CerrarConexionBD();

            return resultado;
        }

        public List<string[]> Horario(string IDUsuario)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("SELECT HoraEntrada, HoraSalida FROM HorarioFijo INNER JOIN Usuario_Horario ON HorarioFijo.IDHorarioFijo = Usuario_Horario.IDHorarioFijo WHERE IDUsuario = " + IDUsuario + " AND Usuario_Horario.Activo = 1 order by (HoraEntrada)", ob.ObtenerConexion());

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            List<string[]> resultado = new List<string[]>();
            // iterate through results, printing each to console
            while (rdr.Read())
            {
                resultado.Add(new string[] { rdr[0] + "", rdr[1] + "" });
            }
            ob.CerrarConexionBD();

            return resultado;
        }

        public string ValidacionChecador(string IDUsuario, string Fecha)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("SELECT count(IDUsuario) FROM Horario_Checador where IDUsuario = " +IDUsuario+ " and Fecha = '"+Fecha+"'", ob.ObtenerConexion());

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            string resultado = "0";
            // iterate through results, printing each to console
            while (rdr.Read())
            {
                resultado = rdr[0] + "";
            }
            ob.CerrarConexionBD();

            return resultado;
        }

        public string Registro(string IDUsuario, string Comentario, bool Autorizacion)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("RegitroChecador", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@IDUsuario", IDUsuario));
            cmd.Parameters.Add(new SqlParameter("@Comentario", Comentario));
            cmd.Parameters.Add(new SqlParameter("@Autorizacion", Autorizacion));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            String resultado = "-1";
            // iterate through results, printing each to console
            while (rdr.Read())
            {
                resultado = rdr[0] + "";
            }


            ob.CerrarConexionBD();

            return resultado;
        }

        public string RegistroTarde(string IDUsuario, DateTime Registro, string Comentario, bool Autorizacion)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("RegitroChecadorTarde", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@IDUsuario", IDUsuario));
            cmd.Parameters.Add(new SqlParameter("@Registro", Registro));
            cmd.Parameters.Add(new SqlParameter("@Comentario", Comentario));
            cmd.Parameters.Add(new SqlParameter("@Autorizacion", Autorizacion));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            String resultado = "-1";
            // iterate through results, printing each to console
            while (rdr.Read())
            {
                resultado = rdr[0] + "";
            }


            ob.CerrarConexionBD();

            return resultado;
        }

        public string InsertarHorarioChecar(string IDUsuario, string fecha, string entrada, string inicioDescanso, string finDescanso, string salida, string comentario, bool autorizacion, string horaEntrada)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            //SqlCommand cmd = new SqlCommand("INSERT INTO Horario_Checador (IDUsuario,Fecha,Entrada,InicioDescanso,FinDescanso,Salida,Comentario,Autorizacion) values (" + IDusuario + ",'" + Fecha + "','" + Entrada + "','','','','" + Comentario + "'," + Autorizacion + ")", ob.ObtenerConexion());
            SqlCommand cmd = new SqlCommand("RegitroHorarioChecador", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@IDUsuario", IDUsuario));
            cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
            cmd.Parameters.Add(new SqlParameter("@entrada", entrada));
            cmd.Parameters.Add(new SqlParameter("@inicioDescanso", inicioDescanso));
            cmd.Parameters.Add(new SqlParameter("@findescanso", finDescanso));
            cmd.Parameters.Add(new SqlParameter("@salida", salida));
            cmd.Parameters.Add(new SqlParameter("@comentario", comentario));
            cmd.Parameters.Add(new SqlParameter("@autorizacion", autorizacion));
            cmd.Parameters.Add(new SqlParameter("@horaEntrada", horaEntrada));
            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            String resultado = "-1";
            // iterate through results, printing each to console
            while (rdr.Read())
            {
                resultado = rdr[0] + "";
            }
            ob.CerrarConexionBD();

            return resultado;
        }

        public string UpdateCampo(string campo, string valor, string IDUsuario, string fecha)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("UPDATE Horario_Checador SET "+campo+" = "+valor+" WHERE IDUsuario = "+IDUsuario+" AND Fecha = '"+fecha+"'", ob.ObtenerConexion());

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            String resultado = "-1";
            // iterate through results, printing each to console
            while (rdr.Read())
            {
                resultado = rdr[0] + "";
            }
            ob.CerrarConexionBD();

            return resultado;
        }

        public string BusquedaDesacanso(string IDUsuario, string fecha)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("SELECT InicioDescanso FROM Horario_Checador WHERE IDUsuario = " + IDUsuario + " AND Fecha = '" + fecha + "'", ob.ObtenerConexion());

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            String resultado = "";
            // iterate through results, printing each to console
            while (rdr.Read())
            {
                resultado = rdr[0] + "";
            }
            ob.CerrarConexionBD();

            return resultado;
        }
    }
}
