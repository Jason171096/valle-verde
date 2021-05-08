using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerde.Programacion.RecursosHumanos
{
    class Horario
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();

        public List<string[]> Horas()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("SELECT Nombre, HoraEntrada, HoraSalida, IDHorarioFijo FROM HorarioFijo", ob.ObtenerConexion());

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            List<string[]> resultado = new List<string[]>();

            while (rdr.Read())
            {
                resultado.Add(new string[] { rdr[0] + "", rdr[1] + "" , rdr[2] + "", rdr[3] + ""});
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public string[] Busqueda(string IDHorario)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("SELECT Nombre, HoraEntrada, HoraSalida FROM HorarioFijo WHERE IDHorarioFijo = "+IDHorario+"", ob.ObtenerConexion());

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            string[] resultado = new string[3];

            while (rdr.Read())
            {
                resultado = new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "" };
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public string Insertar(string nombre, string horaEntrada, string horaSalida)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("INSERT INTO HorarioFijo (Nombre, HoraEntrada, HoraSalida) VALUES ('"+nombre+"','"+horaEntrada+"','"+horaSalida+"')", ob.ObtenerConexion());

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

        public string Modificar(string nombre, string horaEntrada, string horaSalida, string IDHorario)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("UPDATE HorarioFijo SET Nombre = '"+nombre+"',HoraEntrada = '"+horaEntrada+"',HoraSalida = '"+horaSalida+"' WHERE IDHorarioFijo = "+IDHorario+"", ob.ObtenerConexion());

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

        public string Eliminar(String IDHorario)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("DELETE FROM HorarioFijo WHERE IDHorario = "+IDHorario+" ", ob.ObtenerConexion());

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
    }
}
