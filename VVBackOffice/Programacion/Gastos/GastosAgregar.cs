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
    class GastosAgregar
    {
        ValleVerdeComun.ConexionBD obj = new ValleVerdeComun.ConexionBD();
        
        public void AgregarGasto(DateTime Fecha, int idPresupuesto, decimal Importe, string Observacion, string Folio, string nomSucursal, bool esSucursal)
        {
            obj.AbrirConexionBD();
            try
            {
                if (Importe >0)
                {
                    SqlCommand cmd = new SqlCommand("AgregarGastoSuc", obj.ObtenerConexion());
                   
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
                    cmd.Parameters.Add(new SqlParameter("@idPresupuesto", idPresupuesto));
                    cmd.Parameters.Add(new SqlParameter("@Importe", Importe));
                    cmd.Parameters.Add(new SqlParameter("@observacion", Observacion));
                    cmd.Parameters.Add(new SqlParameter("@folio", Folio));
                    cmd.Parameters.Add(new SqlParameter("@nomSucursal", nomSucursal));
                    cmd.Parameters.Add(new SqlParameter("@esSucursal", esSucursal));

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Console.WriteLine(rdr[0]);
                    }

                    obj.CerrarConexionBD();
                    //MessageBox.Show("Gasto Agregado", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (Importe == 0)
                {
                    MessageBox.Show("No se puede Agregar un Gasto de '0' ", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar Gasto " +ex, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
