using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerde.Programacion.Reportes
{
    class IrregularidadEmpleado
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();

        public void AgregarIrregularidad(string id, string nombres, string irregularidad)
        {
            ob.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("AgregarIrregularidad", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", SqlDbType.BigInt).Value = id;
            cmd.Parameters.AddWithValue("@nombres", SqlDbType.NVarChar).Value = nombres;
            cmd.Parameters.AddWithValue("@irregularidad", SqlDbType.NVarChar).Value = irregularidad;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Irregularidad añadida", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ob.CerrarConexionBD();
        }

        public void EliminarIrregularidad(string id, string nombres, string irregularidad)
        {
            ob.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("EliminarIrregularidad", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", SqlDbType.BigInt).Value = id;
            cmd.Parameters.AddWithValue("@nombres", SqlDbType.NVarChar).Value = nombres;
            cmd.Parameters.AddWithValue("@irregularidad", SqlDbType.NVarChar).Value = irregularidad;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Irregularidad eliminada", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ob.CerrarConexionBD();
        }

    }
}
