using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace ValleVerde.Programacion.Gastos
{
    class PresupuestoEliminar
    {
        public void EliminarPresupuesto(int IDPresupuesto, string nomSucursal, bool esSucursal)
        {
            ValleVerdeComun.ConexionBD obj = new ValleVerdeComun.ConexionBD();
            obj.AbrirConexionBD();
            try
            {
                SqlCommand cmd = new SqlCommand("EliminarPresupuestoSuc", obj.ObtenerConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IDPresupuesto", IDPresupuesto));
                cmd.Parameters.Add(new SqlParameter("@nomSucursal", nomSucursal));
                cmd.Parameters.Add(new SqlParameter("@esSucursal", esSucursal));


                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0]);
                }

                obj.CerrarConexionBD();
                //MessageBox.Show("Presupuesto Eliminado", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("No puedes Eliminar un Presupuesto que tenga Gastos Registrados.","¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
