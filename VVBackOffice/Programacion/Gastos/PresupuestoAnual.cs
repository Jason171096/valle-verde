using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerde.Programacion.Gastos
{
    class PresupuestoAnual
    {
        ValleVerdeComun.ConexionBD obj = new ValleVerdeComun.ConexionBD();
        SqlCommand cmd;
        DataTable dt;

        public void CargarPresupuestoAnual(DataGridView dgv, DateTimePicker year, int band, string nomSucursal, bool esSucursal)
        {
            string fecha2 = ("" + year.Text + "/" + DateTime.Now.Month + "/" + "01");
            DateTime fecha = DateTime.Parse(fecha2);

            try
            {
                obj.AbrirConexionBD();
                dt = new DataTable();
                cmd = new SqlCommand("[BuscarPresupuestoAnualSuc]", obj.ObtenerConexion());

                cmd.Parameters.AddWithValue("@todo", SqlDbType.NVarChar).Value = band;
                cmd.Parameters.AddWithValue("@fecha", SqlDbType.BigInt).Value = fecha;
                cmd.Parameters.AddWithValue("@nomSucursal", SqlDbType.NVarChar).Value = nomSucursal;
                cmd.Parameters.AddWithValue("@esSucursal", SqlDbType.NVarChar).Value = esSucursal;

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
                dgv.DataSource = dt;

                obj.CerrarConexionBD();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puden cargar los Presupuestos: " + ex.ToString());
            }
        }
    }
}
