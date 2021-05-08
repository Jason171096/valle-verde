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
    class GastosEliminar
    {
        ValleVerdeComun.ConexionBD obj = new ValleVerdeComun.ConexionBD();

        public void EliminarGasto(int IDGasto, string nomSucursal, bool esSucursal)
        {
            obj.AbrirConexionBD();
            
            try
            {
                SqlCommand cmd = new SqlCommand("EliminarGastoSuc", obj.ObtenerConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IDGasto", IDGasto));
                cmd.Parameters.Add(new SqlParameter("@nomSucursal", nomSucursal));
                cmd.Parameters.Add(new SqlParameter("@esSucursal", esSucursal));

                SqlDataReader rdr = cmd.ExecuteReader();
                
                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0]);
                }
                obj.CerrarConexionBD();

                //MessageBox.Show("Gasto Eliminado", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo Eliminar: " + ex.ToString());
            }
        }
    }
}
