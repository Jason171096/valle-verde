using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValleVerdeComun.Programacion.Huellas;

namespace ValleVerde.Programacion.Reportes
{
    class VerEmpleado
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();

        //Usuarios combobox
        public List<string[]> Usuarios()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerNombreUsuario", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<string[]> resultado = new List<string[]>();

            while (rdr.Read())
            {
                resultado.Add(new string[]{ rdr[0] + "", rdr[1] + "" });
            }

            ob.CerrarConexionBD();

            return resultado;
        }
        //Regitro tabla checador
        public List<string[]> Registros(string IDUsuario, string fechaInicio, string fechaFin)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerRegistroChecador", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@IDUsuario", IDUsuario));

            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));

            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<string[]> Resultado = new List<string[]>();

            while (rdr.Read())
            {
                Resultado.Add(new string[] { rdr[0] + "", rdr[1]+"",rdr[2]+""});
            }

            ob.CerrarConexionBD();

            return Resultado;
        }

        //Regitro tabla checador
        public List<string> RegistroFecha(string IDUsuario, string fechaInicio, string fechaFin)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerRegistroFecha", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Nombres", IDUsuario));

            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));

            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<string> resultado = new List<string>();

            while (rdr.Read())
            {
                resultado.Add((rdr[0] + "").Substring(0, 10));
                //Resultado.Add(DateTime.Parse(rdr[0] + ""));
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        //Regitro tabla checador
        public List<string> FechaChecador(string IDUsuario, string fechaInicio, string fechaFin)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerFechaChecador", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@IDUsuario", IDUsuario));

            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));

            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<string> resultado = new List<string>();

            while (rdr.Read())
            {
                resultado.Add((rdr[0] + "").Substring(0, 10));
                //Resultado.Add(DateTime.Parse(rdr[0] + ""));
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        //Regitro tabla Horario_Checador
        public List<string[]> TablaChecador(string IDUsuario, string Fecha)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerHorariosChecador", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@IDUsuario", IDUsuario));

            cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<string[]> Resultado = new List<string[]>();

            while (rdr.Read())
            {
                Resultado.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + "", rdr[6] + "", rdr[7] + ""});
            }

            ob.CerrarConexionBD();

            return Resultado;
        }

        public string Pagar(string valor, string IDUsuario, string fecha)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("UPDATE Horario_Checador SET Pagado = " + valor + " WHERE IDUsuario = " + IDUsuario + " AND Fecha = '" + fecha + "'", ob.ObtenerConexion());

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            string resultado = "-1";
            // iterate through results, printing each to console
            while (rdr.Read())
            {
                resultado = rdr[0] + "";
            }
            ob.CerrarConexionBD();

            return resultado;
        }

        //Horarios de los empleados tabla HorarioFijo
        public List<DateTime> HorarioEntrada()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("SELECT HoraEntrada FROM HorarioFijo", ob.ObtenerConexion());

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            List<DateTime> resultado = new List<DateTime>();

            while (rdr.Read())
            {
                resultado.Add(DateTime.Parse(rdr[0] + ""));
                //Resultado.Add(rdr[0]+"");
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public List<string[]> HorasEmpleado(string IDUsuario)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("SELECT Nombre, HoraEntrada, HoraSalida, HorarioFijo.IDHorarioFijo FROM HorarioFijo INNER JOIN Usuario_Horario ON HorarioFijo.IDHorarioFijo = Usuario_Horario.IDHorarioFijo WHERE IDUsuario = " + IDUsuario + " AND Activo = 1", ob.ObtenerConexion());

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            List<string[]> resultado = new List<string[]>();

            while (rdr.Read())
            {
                resultado.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "" });
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        //Eliminacion logica
        public string Eliminar(string IDHorario, string IDUsuario)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("UPDATE Usuario_Horario SET FechaDesactivacion = GETDATE(), Activo = 0 WHERE IDHorario = " + IDHorario + "AND IDUsuario = " + IDUsuario, ob.ObtenerConexion());

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

        public string InsertarHoraEmp(string IDHorario, string IDUsuario)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("InsertarHorarioEmpleado", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@IDUsuario", IDUsuario));

            cmd.Parameters.Add(new SqlParameter("@IDHorario", IDHorario));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            string resultado = "-1";
            // iterate through results, printing each to console
            while (rdr.Read())
            {
                resultado = rdr[0] + "";
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public string NombreEmpleado(string IDUsuario)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("SELECT Nombres FROM Usuario WHERE IDUsuario = " + IDUsuario, ob.ObtenerConexion());

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            string resultado = "";

            while (rdr.Read())
            {
                resultado = rdr[0] +"";
            }

            ob.CerrarConexionBD();

            return resultado;
        }
    
        public string AgregarTiempoDescanso(string IDUsuario, string IDHorario, int tiempoDescanso, bool bandera)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AgregarTiempoDescanso", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@IDUsuario", IDUsuario));

            cmd.Parameters.Add(new SqlParameter("@IDHorario", IDHorario));

            cmd.Parameters.Add(new SqlParameter("@tiempoDescanso", tiempoDescanso));

            cmd.Parameters.Add(new SqlParameter("@bandera", bandera));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            string resultado = "-1";
            // iterate through results, printing each to console
            while (rdr.Read())
            {
                resultado = rdr[0] + "";
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public string TiempoDescanso(string IDUsuario, string horaEntrada)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("SELECT TiempoDescanso FROM Usuario_Horario INNER JOIN HorarioFijo ON Usuario_Horario.IDHorarioFijo = HorarioFijo.IDHorarioFijo WHERE IDUsuario = " + IDUsuario + " AND HoraEntrada = '" + horaEntrada + "'", ob.ObtenerConexion());

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            string resultado ="";

            while (rdr.Read())
            {
                resultado = rdr[0] + "";
            }

            ob.CerrarConexionBD();

            return resultado;
        }

    }
}
