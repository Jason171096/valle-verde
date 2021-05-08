using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ValleVerde.Programacion.Gastos
{
    class PresupuestoAgregar
    {
        ValleVerdeComun.ConexionBD obj = new ValleVerdeComun.ConexionBD();

        public void AgregarPresupuesto(String Descripcion, String Presupuesto, bool Recurrente, string nomSucursal, bool esSucursal)
        {
            obj.AbrirConexionBD();
            try
            {
                if (double.Parse(Presupuesto) > 0)
                {
                    SqlCommand cmd = new SqlCommand("AgregarPresupuestoSuc", obj.ObtenerConexion());

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Descripcion", Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Presupuesto", Presupuesto));
                    cmd.Parameters.Add(new SqlParameter("@recurrente", Recurrente));
                    cmd.Parameters.Add(new SqlParameter("@nomSucursal", nomSucursal));
                    cmd.Parameters.Add(new SqlParameter("@esSucursal", esSucursal));

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Console.WriteLine(rdr[0]);
                    }

                    obj.CerrarConexionBD();
                    //MessageBox.Show("Presupuesto Agregado", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (double.Parse(Presupuesto) == 0)
                {
                    MessageBox.Show("No se puede Agregar un Presupuesto de '0' ", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al agregar Presupuesto ", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }
    }
}
