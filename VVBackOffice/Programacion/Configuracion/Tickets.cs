using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerde.Programacion.Configuracion
{
    class Tickets
    {
        ValleVerdeComun.ConexionBD obj = new ValleVerdeComun.ConexionBD();

        public void crearTicket(String nom, String menCab, String men1PiePag, String men2PiePag, String men3PiePag, Boolean logo, Boolean aho, Boolean cli, Boolean suc, Boolean corEle, Boolean dir, Int16 digBas, Boolean incMenCab, Boolean incMen1PiePag, Boolean incMen2PiePag, Boolean incMen3PiePag, Boolean tel, Boolean rfc, Boolean caj, Boolean emp)
        {
            obj.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("crearTicket", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nom", nom));
            cmd.Parameters.Add(new SqlParameter("@menCab", menCab));
            cmd.Parameters.Add(new SqlParameter("@men1PiePag", men1PiePag));
            cmd.Parameters.Add(new SqlParameter("@men2PiePag", men2PiePag));
            cmd.Parameters.Add(new SqlParameter("@men3PiePag", men3PiePag));
            cmd.Parameters.Add(new SqlParameter("@logo", logo));
            cmd.Parameters.Add(new SqlParameter("@aho", aho));
            cmd.Parameters.Add(new SqlParameter("@cli", cli));
            cmd.Parameters.Add(new SqlParameter("@suc", suc));
            cmd.Parameters.Add(new SqlParameter("@corEle", corEle));
            cmd.Parameters.Add(new SqlParameter("@dir", dir));
            cmd.Parameters.Add(new SqlParameter("@digBas", digBas));
            cmd.Parameters.Add(new SqlParameter("@incMenCab", incMenCab));
            cmd.Parameters.Add(new SqlParameter("@incMen1PiePag", incMen1PiePag));
            cmd.Parameters.Add(new SqlParameter("@incMen2PiePag", incMen2PiePag));
            cmd.Parameters.Add(new SqlParameter("@incMen3PiePag", incMen3PiePag));
            cmd.Parameters.Add(new SqlParameter("@tel", tel));
            cmd.Parameters.Add(new SqlParameter("@rfc", rfc));
            cmd.Parameters.Add(new SqlParameter("@caj", caj));
            cmd.Parameters.Add(new SqlParameter("@emp", emp));
            SqlDataReader rdr = cmd.ExecuteReader();
            obj.CerrarConexionBD();
        }

        public List<String[]> ObtenerTickets()
        {
            obj.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("select * from Tickets", obj.ObtenerConexion());
            cmd.CommandType = CommandType.Text;
            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> res = new List<string[]>();
            while (rdr.Read())
            {
                res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + "", rdr[6] + "", rdr[7] + "", rdr[8] + "", rdr[9] + "", rdr[10] + "", rdr[11] + "", rdr[12] + "", rdr[13] + "", rdr[14] + "", rdr[15] + "", rdr[16] + "", rdr[17] + "", rdr[18] + "", rdr[19] + "", rdr[20] + "" });
            }

            obj.CerrarConexionBD();

            return res;
        }

        public void ModificarTicket(Int64 idTic, string nom, string menCab, string men1PiePag, string men2PiePag, string men3PiePag, bool log, bool aho, bool cli, bool suc, bool corEle, bool dir, Int16 digBas, bool incMenCab, bool incMen1PiePag, bool incMen2PiePag, bool incMen3PiePag, bool tel, bool rfc, bool caj, bool emp)
        {
            obj.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("ModificarTicket", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idTic", idTic));
            cmd.Parameters.Add(new SqlParameter("@nom", nom));
            cmd.Parameters.Add(new SqlParameter("@menCab", menCab));
            cmd.Parameters.Add(new SqlParameter("@men1PiePag", men1PiePag));
            cmd.Parameters.Add(new SqlParameter("@men2PiePag", men2PiePag));
            cmd.Parameters.Add(new SqlParameter("@men3PiePag", men3PiePag));
            cmd.Parameters.Add(new SqlParameter("@logo", log));
            cmd.Parameters.Add(new SqlParameter("@aho", aho));
            cmd.Parameters.Add(new SqlParameter("@cli", cli));
            cmd.Parameters.Add(new SqlParameter("@suc", suc));
            cmd.Parameters.Add(new SqlParameter("@corEle", corEle));
            cmd.Parameters.Add(new SqlParameter("@dir", dir));
            cmd.Parameters.Add(new SqlParameter("@digBas", digBas));
            cmd.Parameters.Add(new SqlParameter("@incMenCab", incMenCab));
            cmd.Parameters.Add(new SqlParameter("@incMen1PiePag", incMen1PiePag));
            cmd.Parameters.Add(new SqlParameter("@incMen2PiePag", incMen2PiePag));
            cmd.Parameters.Add(new SqlParameter("@incMen3PiePag", incMen3PiePag));
            cmd.Parameters.Add(new SqlParameter("@tel", tel));
            cmd.Parameters.Add(new SqlParameter("@rfc", rfc));
            cmd.Parameters.Add(new SqlParameter("@caj", caj));
            cmd.Parameters.Add(new SqlParameter("@emp", emp));
            SqlDataReader rdr = cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        public void EliminarTicket(Int64 idTicSel)
        {
            obj.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("EliminarTicket", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idTic", idTicSel));
            SqlDataReader rdr = cmd.ExecuteReader();
            obj.CerrarConexionBD();
        }
    }
}
