using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerde.Programacion.RecursosHumanos
{
    class EmpleadoInactivo
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();
        public void Empleadoinactivo(string id, string nombres, bool activo)
        {
            ob.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("UsuarioActivo", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", SqlDbType.BigInt).Value = id;
            cmd.Parameters.AddWithValue("@nombres", SqlDbType.NVarChar).Value = nombres;
            cmd.Parameters.AddWithValue("@activo", SqlDbType.NVarChar).Value = activo;
            cmd.ExecuteNonQuery();
            ob.CerrarConexionBD();
        }
    }
}
