using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerde.Programacion.Configuracion
{
    class Metas
    {
        ValleVerdeComun.ConexionBD obj = new ValleVerdeComun.ConexionBD();

        public List<String[]> CargarMetas(decimal ano)
        {
            obj.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("ObtenerMetas", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ano", ano));
            SqlDataReader rdr = cmd.ExecuteReader();
            List<String[]> res = new List<string[]>();
            while (rdr.Read())
            {
                res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + "", rdr[6] + "", rdr[7] + "", rdr[8] + "", rdr[9] + "", rdr[10] + "", rdr[11] + "", rdr[12] + "", rdr[13] + "" });
                Console.WriteLine(rdr[0]);
            }
            obj.CerrarConexionBD();
            return res;
        }

        public void GuardarMetas(decimal ano, decimal ene, decimal feb, decimal mar, decimal abr, decimal may, decimal jun, decimal jul, decimal ago, decimal sep, decimal oct, decimal nov, decimal dic, double metAno)
        {
            obj.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("GuardarMetas", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ano", ano));
            cmd.Parameters.Add(new SqlParameter("@ene", ene));
            cmd.Parameters.Add(new SqlParameter("@feb", feb));
            cmd.Parameters.Add(new SqlParameter("@mar", mar));
            cmd.Parameters.Add(new SqlParameter("@abr", abr));
            cmd.Parameters.Add(new SqlParameter("@may", may));
            cmd.Parameters.Add(new SqlParameter("@jun", jun));
            cmd.Parameters.Add(new SqlParameter("@jul", jul));
            cmd.Parameters.Add(new SqlParameter("@ago", ago));
            cmd.Parameters.Add(new SqlParameter("@sep", sep));
            cmd.Parameters.Add(new SqlParameter("@oct", oct));
            cmd.Parameters.Add(new SqlParameter("@nov", nov));
            cmd.Parameters.Add(new SqlParameter("@dic", dic));
            cmd.Parameters.Add(new SqlParameter("@metAno", metAno));
            SqlDataReader rdr = cmd.ExecuteReader();
            List<String[]> res = new List<string[]>();
            while (rdr.Read())
            {
                res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + "", rdr[6] + "", rdr[7] + "", rdr[8] + "", rdr[9] + "", rdr[10] + "", rdr[11] + "", rdr[12] + "", rdr[13] + "" });
            }
            obj.CerrarConexionBD();
        }

        public string CargarMetasMes(decimal ano, string mes)
        {
            obj.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("SELECT " + mes + " FROM Metas WHERE Ano = " + ano, obj.ObtenerConexion());
            SqlDataReader rdr = cmd.ExecuteReader();
            string res = "0";
            while (rdr.Read())
            {
                res = rdr[0] + "";
                Console.WriteLine(rdr[0]);
            }
            obj.CerrarConexionBD();
            return res;
        }

        public string TotalVentas(DateTime fechaInicio, DateTime fechaFinal)
        {
            obj.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerTotalVentas", obj.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
            cmd.Parameters.Add(new SqlParameter("@fechaFinal", fechaFinal));
            cmd.Parameters.Add(new SqlParameter("@idTurno", "-1"));
            cmd.Parameters.Add(new SqlParameter("@obtenerTotalNeto", "0"));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            string resultado = "0";

            while (rdr.Read())
            {
                resultado = rdr[0] + "";
            }

            obj.CerrarConexionBD();

            return resultado;
        }

        public string Fecha()
        {
            obj.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("SELECT GETDATE()", obj.ObtenerConexion());
            SqlDataReader rdr = cmd.ExecuteReader();
            string res = "";
            while (rdr.Read())
            {
                res = rdr[0] + "";
                Console.WriteLine(rdr[0]);
            }
            obj.CerrarConexionBD();
            return res;
        }
    }
}
