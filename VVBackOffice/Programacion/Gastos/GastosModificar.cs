using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ValleVerde.Programacion.Gastos
{
    class GastosModificar
    {
        ValleVerdeComun.ConexionBD obj = new ValleVerdeComun.ConexionBD();

        public void ModificarGasto(int IDGasto, DateTime Fecha, int IDPresupuesto, decimal Importe, string Observacion, string Folio, string nomSucursal, bool esSucursal)
        {
            obj.AbrirConexionBD();
            try
            {
                if(Importe >0)
                { 
                    SqlCommand cmd = new SqlCommand("ActualizarGastoSuc", obj.ObtenerConexion());

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDGasto", IDGasto));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
                    cmd.Parameters.Add(new SqlParameter("@idPresupuesto", IDPresupuesto));
                    cmd.Parameters.Add(new SqlParameter("@Importe", Importe));
                    cmd.Parameters.Add(new SqlParameter("@Observacion", Observacion));
                    cmd.Parameters.Add(new SqlParameter("@Folio", Folio));

                    cmd.Parameters.Add(new SqlParameter("@nomSucursal", nomSucursal));
                    cmd.Parameters.Add(new SqlParameter("@esSucursal", esSucursal));

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                      Console.WriteLine(rdr[0]);
                    }

                    obj.CerrarConexionBD();
                    MessageBox.Show("Gasto Modificado", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (Importe == 0)
                {
                    MessageBox.Show("No se puede Cambiar un Gasto a '0' ", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo Actualizar: " + ex.ToString());
            }        
        }
    }
}
