using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerde.Programacion.Reportes
{
    class ObtenerUsuariosyIrregularidades
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        public DataTable TodosDatosUsuarios()
        {
            ob.AbrirConexionBD();
            cmd = new SqlCommand("ObtenerTodosUsuarios", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);
            ob.CerrarConexionBD();
            return dt;
        }

        public DataTable UsuariosIrregularidades()
        {
            ob.AbrirConexionBD();
            cmd = new SqlCommand("ObtenerUsuarioIrregularidades", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt2);
            ob.CerrarConexionBD();
            return dt2;
        }
    }
}
