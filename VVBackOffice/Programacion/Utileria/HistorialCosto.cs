using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerde.Programacion.Utileria
{
    class HistorialCosto
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();
        public List<object[]> CodigosHistorialCosto(DateTime date, DateTime horainicial, DateTime horafinal, bool horaactiva, int impreso)
        {          
            List<object[]> codigos = new List<object[]>();

            ob.AbrirConexionBD();


            SqlCommand cmd = new SqlCommand("ObtenerHistorialCosto", ob.ObtenerConexion());

            cmd.Parameters.AddWithValue("@fecha", SqlDbType.DateTime).Value = date;
            cmd.Parameters.AddWithValue("@horainicial", SqlDbType.Time).Value = horainicial;
            cmd.Parameters.AddWithValue("@horafinal", SqlDbType.Time).Value = horafinal;
            cmd.Parameters.AddWithValue("@horaactiva", SqlDbType.Bit).Value = horaactiva;
            cmd.Parameters.AddWithValue("@impreso", SqlDbType.Int).Value = impreso;

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // execute the command
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                codigos.Add(new object[] { reader[0], reader[1], reader[2], reader[3]});
            }

            ob.CerrarConexionBD();

            return codigos;

        }
    }
}
