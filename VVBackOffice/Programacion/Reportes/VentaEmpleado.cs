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
    class VentaEmpleado
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        public DataTable VentasEmpleados(string idusuario, DateTime fechainicio, DateTime fechafin)
        {
            try
            {
                ob.AbrirConexionBD();
                SqlCommand cmd = new SqlCommand("ObtenerEmpleadoVentas", ob.ObtenerConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idusuario", SqlDbType.BigInt).Value = idusuario;
                cmd.Parameters.AddWithValue("@fechainicio", SqlDbType.Date).Value = fechainicio;
                cmd.Parameters.AddWithValue("@fechafin", SqlDbType.Date).Value = fechafin;
                da.SelectCommand = cmd;
                da.Fill(dt);
                ob.CerrarConexionBD();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.GetBaseException().ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }
    }
}
