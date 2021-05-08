using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerde.Programacion.RecursosHumanos
{
    class CBonosyPenalizacion
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();


        public void AltaBono(string descripcion, string importe)
        {
            ExecuteBonosyPenalizaciones("1", "1", "0", "0", "", descripcion, importe, "", "", "0");
        }
        public void ModificarBono(string idbono, string descripcion, string importe)
        {
            ExecuteBonosyPenalizaciones("1", "0", "2", "0", idbono, descripcion, importe, "", "", "0");
        }
        public void EliminarBono(string idbono)
        {
            ExecuteBonosyPenalizaciones("1", "0", "0", "3", idbono, "", "0", "", "", "0");
        }
        public void AltaPenalizacion(string descripcion, string importe)
        {
            ExecuteBonosyPenalizaciones("0", "1", "0", "0", "", "", "0", "", descripcion, importe);
        }
        public void ModificarPenalizacion(string idpenalizacion, string descripcion, string importe)
        {
            ExecuteBonosyPenalizaciones("0", "0", "2", "0", "", "", "0", idpenalizacion, descripcion, importe);
        }
        public void EliminarPenalizacion(string idpenalizacion)
        {
            ExecuteBonosyPenalizaciones("0", "0", "0", "3", "", "", "0", idpenalizacion, "", "0");
        }
        private void ExecuteBonosyPenalizaciones(string BonoyPena, string insert, string update, string delete,
            string idbono, string desbono, string impbono, string idpena, string despena, string imppena)
        {
            ob.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("BonosyPenalizaciones", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@BonOPena", BonoyPena));
            cmd.Parameters.Add(new SqlParameter("@insert", insert));
            cmd.Parameters.Add(new SqlParameter("@update", update));
            cmd.Parameters.Add(new SqlParameter("@delete", delete));
            cmd.Parameters.Add(new SqlParameter("@idBono", idbono));
            cmd.Parameters.Add(new SqlParameter("@desBono", desbono)) ;
            cmd.Parameters.Add(new SqlParameter("@impBono", Decimal.Parse(impbono)));
            cmd.Parameters.Add(new SqlParameter("@idPena", idpena));
            cmd.Parameters.Add(new SqlParameter("@desPena", despena));
            cmd.Parameters.Add(new SqlParameter("@impPena", Decimal.Parse(imppena)));
            cmd.ExecuteNonQuery();
            ob.CerrarConexionBD();
        }

        public List<object[]> ObtenerBonos()
        {
            ob.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("ObtenerBonosyPenalizaciones", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@BonOPena", true));
            SqlDataReader rdr = cmd.ExecuteReader();
            List<object[]> res = new List<object[]>();
            while(rdr.Read())
            {
                res.Add(new object[] { rdr[0], rdr[1], rdr[2] });
            }
            ob.CerrarConexionBD();
            return res;
        }
        public List<object[]> ObtenerPenalizaciones()
        {
            ob.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("ObtenerBonosyPenalizaciones", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@BonOPena", false));
            SqlDataReader rdr = cmd.ExecuteReader();
            List<object[]> res = new List<object[]>();
            while (rdr.Read())
            {
                res.Add(new object[] { rdr[0], rdr[1], rdr[2] });
            }
            ob.CerrarConexionBD();
            return res;
        }
    }
}
