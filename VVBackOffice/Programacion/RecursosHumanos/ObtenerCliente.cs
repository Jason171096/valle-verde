using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ValleVerde.Programacion.RecursosHumanos
{
    class ObtenerCliente
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();
        DatosClientes datosCliente;

        public DatosClientes Obtenercliente(string idcliente)
        {
            ob.AbrirConexionBD();
            SqlCommand cmd2 = new SqlCommand("ClienteCreditoVerificar", ob.ObtenerConexion());

            cmd2.CommandType = CommandType.StoredProcedure;

            cmd2.Parameters.AddWithValue("@idcliente", SqlDbType.BigInt).Value = idcliente;

            bool credito = bool.Parse(cmd2.ExecuteScalar().ToString());



            SqlCommand cmd = new SqlCommand("ObtenerCliente", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idcliente", idcliente));

            // execute the command

            SqlDataReader reader = cmd.ExecuteReader();

            try
            {
                if (credito)
                {
                    while (reader.Read())
                    {
                        datosCliente = new DatosClientes(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(),
                            reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(),
                            reader[6].ToString(), reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[10].ToString(),
                            reader[11].ToString(), reader[12].ToString(), reader[13].ToString(),
                            Decimal.Parse(reader[14].ToString()), Decimal.Parse(reader[15].ToString()), bool.Parse(reader[16].ToString()),
                            bool.Parse(reader[17].ToString()),
                            Convert.ToInt32(reader[20].ToString()), Decimal.Parse(reader[21].ToString()), bool.Parse(reader[22].ToString()));
                    }
                }
                else
                {
                    while (reader.Read())
                    {
                        datosCliente = new DatosClientes(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(),
                            reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(),
                            reader[6].ToString(), reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[10].ToString(),
                            reader[11].ToString(), reader[12].ToString(), reader[13].ToString(),
                            Decimal.Parse(reader[14].ToString()), Decimal.Parse(reader[15].ToString()), bool.Parse(reader[16].ToString()),
                            bool.Parse(reader[17].ToString()), -1, -1, bool.Parse(reader[20].ToString()));
                    }
                }
            } catch (Exception e)
            {
                MessageBox.Show( "Los datos del usuario pueden estar corruptos, favor de comunicar al programador\n\n" +
                    "Detalles del error:\n" + e.Message + "\n" + e.StackTrace, 
                    "Error al leer usuario",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ob.CerrarConexionBD();
            return datosCliente;
        }
        public List<String[]> ObtenerClienteCorreo(string idcliente)
        {
            ob.AbrirConexionBD();
            SqlCommand cmd2 = new SqlCommand("ObtenerCorreosCliente", ob.ObtenerConexion());
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add(new SqlParameter("@idcliente", idcliente));
            SqlDataReader rdr = cmd2.ExecuteReader();
            List<String[]> resultado = new List<String[]>();
            while (rdr.Read())
            {
                resultado.Add(new String[] { rdr[0].ToString(), rdr[1].ToString() });
            }
            ob.CerrarConexionBD();
            return resultado;
        }
    }
}

