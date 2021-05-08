using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ValleVerde.Programacion.Gastos
{
    class Presupuestos
    {
        ValleVerdeComun.ConexionBD obj = new ValleVerdeComun.ConexionBD();
        SqlCommand cmd;
        DataTable dt;
        
        public void CargarPresupuesto(DataGridView dgv, ComboBox month, DateTimePicker year, int band, string nomSucursal, bool esSucursal)  
        {
            string fecha2 = ("" + year.Value.Year.ToString() + "/" + (month.SelectedIndex + 1) + "/" + "01");
            DateTime fecha = DateTime.Parse(fecha2);
            

            try
            {
                obj.AbrirConexionBD();
                dt = new DataTable();
                cmd = new SqlCommand("[BuscarPresupuestosSuc]", obj.ObtenerConexion());

                cmd.Parameters.AddWithValue("@todo", SqlDbType.NVarChar).Value = band;
                cmd.Parameters.AddWithValue("@fecha", SqlDbType.DateTime).Value = fecha;
                cmd.Parameters.AddWithValue("@esSucursal", SqlDbType.NVarChar).Value = esSucursal;
                cmd.Parameters.AddWithValue("@nomSucursal", SqlDbType.NVarChar).Value = nomSucursal;

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
                dgv.DataSource = dt;

                obj.CerrarConexionBD();
            }
            catch (Exception)
            {
                if (esSucursal)
                    MessageBox.Show("¡Eror al conectar con Sucursal!", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show("¡No se puden cargar los Presupuestos!", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public int PDisponible(int IdGasto, int idPresupuesto, decimal Importe, string Descripcion, bool accion, string nomServidor, bool esSucursal)
        {
            if (esSucursal)
            {
                // false, presupuesto al agregar Sucursal
                if (accion == false)
                {
                    obj.AbrirConexionBD();
                    var sqlCommand = new SqlCommand("SELECT * FROM OPENQUERY([" + nomServidor + "], 'SELECT Total FROM Presupuestos WHERE IDPresupuesto = " + idPresupuesto + "')", obj.ObtenerConexion());

                    decimal Total = (decimal)sqlCommand.ExecuteScalar();

                    obj.CerrarConexionBD();

                    if (Importe > Total)
                    {
                        MessageBox.Show("No hay presupuesto suficiente." + '\n' + "El Presupuesto Restante para '" + Descripcion + "' es de: $ " + Total + "", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return 0;
                    }
                }
                else // true, presupuesto al modificar sucursal
                {
                    decimal TotalAnt = 0;
                    decimal ImporteAnt = 0;
                    obj.AbrirConexionBD();

                    string query = "SELECT * FROM OPENQUERY([" +nomServidor + "], 'SELECT Gastos.Importe, Presupuestos.Total FROM Gastos INNER JOIN Presupuestos ON Presupuestos.IDPresupuesto = Gastos.IDPresupuesto WHERE Gastos.IDGasto = " + IdGasto + "')";
                    
                    SqlCommand cmd = new SqlCommand(query, obj.ObtenerConexion());
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        ImporteAnt = decimal.Parse(dr["Importe"].ToString());
                        TotalAnt = decimal.Parse(dr["Total"].ToString());
                    }
                    obj.CerrarConexionBD();

                    decimal Total = TotalAnt + ImporteAnt;

                    if (Importe > Total)
                    {
                        MessageBox.Show("No hay presupuesto suficiente." + '\n' + "El Presupuesto Restante para '" + Descripcion + "' es de: $ " + Total + "", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return 0;
                    }
                }
            }
            else
            {
                // false, presupuesto al agregar
                if (accion == false)
                {
                    obj.AbrirConexionBD();
                    var sqlCommand = new SqlCommand("SELECT Total FROM Presupuestos WHERE IDPresupuesto = " + idPresupuesto + "", obj.ObtenerConexion());
                    decimal Total = (decimal)sqlCommand.ExecuteScalar();

                    obj.CerrarConexionBD();

                    if (Importe > Total)
                    {
                        MessageBox.Show("No hay presupuesto suficiente." + '\n' + "El Presupuesto Restante para '" + Descripcion + "' es de: $ " + Total + "", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return 0;
                    }
                }
                else // true, presupuesto al modificar
                {
                    decimal TotalAnt = 0;
                    decimal ImporteAnt = 0;
                    obj.AbrirConexionBD();

                    string query = "SELECT Gastos.Importe, Presupuestos.Total FROM Gastos INNER JOIN Presupuestos ON Presupuestos.IDPresupuesto = Gastos.IDPresupuesto WHERE Gastos.IDGasto = " + IdGasto + "";
                    SqlCommand cmd = new SqlCommand(query, obj.ObtenerConexion());
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        ImporteAnt = decimal.Parse(dr["Importe"].ToString());
                        TotalAnt = decimal.Parse(dr["Total"].ToString());
                    }
                    obj.CerrarConexionBD();

                    decimal Total = TotalAnt + ImporteAnt;

                    if (Importe > Total)
                    {
                        MessageBox.Show("No hay presupuesto suficiente." + '\n' + "El Presupuesto Restante para '" + Descripcion + "' es de: $ " + Total + "", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return 0;
                    }
                }
            }
            return 1;
        }
    }
}
