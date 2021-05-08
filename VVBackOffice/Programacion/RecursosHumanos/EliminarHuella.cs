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
    class EliminarHuella
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();
        public void Eliminarhuella(string idhuella ,string idusuario, string nombrehuella)
        {
            ob.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("EliminarHuellasEmpleado", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idhuella", SqlDbType.BigInt).Value = idhuella;
            cmd.Parameters.AddWithValue("@idusuario", SqlDbType.BigInt).Value = idusuario;      
            cmd.Parameters.AddWithValue("@nombre", SqlDbType.NVarChar).Value = nombrehuella;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Huella Eliminada", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ob.CerrarConexionBD();
        }
    }
}
