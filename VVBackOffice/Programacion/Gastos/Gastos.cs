using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace ValleVerde.Programacion.Gastos
{
    class Gastos
    {
        ValleVerdeComun.ConexionBD obj = new ValleVerdeComun.ConexionBD();
        SqlCommand cmd;
        DataTable dt;

        public void CargarGastos(DataGridView dgv, DateTimePicker FechaInicio, DateTimePicker FechaFin, int band, string nomSucursal, bool esSucursal)
        {
            try
            { 
                obj.AbrirConexionBD();
                dt = new DataTable();
                cmd = new SqlCommand("BuscarGastosSuc", obj.ObtenerConexion());

                cmd.Parameters.AddWithValue("@todo", SqlDbType.NVarChar).Value = band;
                cmd.Parameters.AddWithValue("@nomSucursal", SqlDbType.NVarChar).Value = nomSucursal;
                cmd.Parameters.AddWithValue("@esSucursal", SqlDbType.NVarChar).Value = esSucursal;


                cmd.Parameters.AddWithValue("@fechaInicio", SqlDbType.BigInt).Value = FechaInicio.Value.Date.ToString("yyyy/MM/dd");
                cmd.Parameters.AddWithValue("@fechaFin", SqlDbType.BigInt).Value = FechaFin.Value.Date.ToString("yyyy/MM/dd");
                
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
                MessageBox.Show("¡No se puden cargar los gastos!", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
