using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ValleVerde.Programacion.Gastos
{
    class PresupuestoModificar
    {
        public void ModificarPresupuesto(int IDPresupuesto, string Descripcion, decimal presupuesto, bool Recurrente, string nomSucursal, bool esSucursal)
        {
            ValleVerdeComun.ConexionBD obj = new ValleVerdeComun.ConexionBD();
            obj.AbrirConexionBD();
            
            try
            {
                if (presupuesto > 0)
                {
                    SqlCommand cmd = new SqlCommand("ActualizarPresupuestoSuc", obj.ObtenerConexion());
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDPresupuesto", IDPresupuesto));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@presupuesto", presupuesto));
                    cmd.Parameters.Add(new SqlParameter("@recurrente", Recurrente));
                    cmd.Parameters.Add(new SqlParameter("@nomSucursal", nomSucursal));
                    cmd.Parameters.Add(new SqlParameter("@esSucursal", esSucursal));

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Console.WriteLine(rdr[0]);
                    }

                    obj.CerrarConexionBD();
                    MessageBox.Show("Presupuesto Modificado", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (presupuesto == 0)
                {
                    MessageBox.Show("No se puede Cambiar un Presupuesto a '0' ", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo Actualizar: " + ex.ToString());
            }
        }
    }
}
