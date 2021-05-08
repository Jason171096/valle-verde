using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerde.Programacion.Inventario
{
    public class Inmobiliario
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();

        DatosInmobiliario datosInmobiliario;
        public void AltaInmobiliario(string descripcion, string modelo, string existencia, string precio)
        {
            ob.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("InmobiliaroDarAlta", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@descripcion", SqlDbType.NVarChar).Value = descripcion;
            cmd.Parameters.AddWithValue("@modelo", SqlDbType.NVarChar).Value = modelo;
            cmd.Parameters.AddWithValue("@existencia", SqlDbType.Float).Value = existencia;
            cmd.Parameters.AddWithValue("@precio", SqlDbType.Money).Value = precio;

            cmd.ExecuteNonQuery();
            MessageBox.Show("Inmobiliario añadido", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ob.CerrarConexionBD();
        }

        public void BajaInmobiliario(string id)
        {
            ob.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("InmobiliaroDarBaja", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idinmobiliario", SqlDbType.BigInt).Value = id;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Inmobiliario eliminado", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ob.CerrarConexionBD();
        }

        public void ModificarInmobiliario(string id, string descripcion, string modelo, string existencia, string precio)
        {
            ob.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("InmobiliaroModificar", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idinmobiliario", SqlDbType.BigInt).Value = id;
            cmd.Parameters.AddWithValue("@descripcion", SqlDbType.NVarChar).Value = descripcion;
            cmd.Parameters.AddWithValue("@modelo", SqlDbType.NVarChar).Value = modelo;
            cmd.Parameters.AddWithValue("@existencia", SqlDbType.Float).Value = existencia;
            cmd.Parameters.AddWithValue("@precio", SqlDbType.Float).Value = precio;

            cmd.ExecuteNonQuery();
            MessageBox.Show("Inmobiliario modificado", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ob.CerrarConexionBD();
        }

        public DataTable DataTableInmobiliario()
        {
            ob.AbrirConexionBD();
            cmd = new SqlCommand("ObtenerInmobiliario", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);
            ob.CerrarConexionBD();
            return dt;
        }

        public class DatosInmobiliario
        {
            public int idinmobiliario;
            public string descripcion;
            public string modelo;
            public float existencia;
            public string precio;

            public DatosInmobiliario(int pidinmobiliario, string pdescripcion, string pmodelo, 
                float pexistencia, string pprecio)
            {
                idinmobiliario = pidinmobiliario;
                descripcion = pdescripcion;
                modelo = pmodelo;
                existencia = pexistencia;
                precio = pprecio;
            }
        }

        public DatosInmobiliario ObtenerInmobiliario(string idinmobiliario)
        {
            ob.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("ObtenerInmobiliario", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idinmobiliario", idinmobiliario));

            // execute the command
            SqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                datosInmobiliario = new DatosInmobiliario(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(),
                    reader[2].ToString(), float.Parse(reader[3].ToString()), reader[4].ToString());
            }
            ob.CerrarConexionBD();
            return datosInmobiliario;
        }

    }
}
