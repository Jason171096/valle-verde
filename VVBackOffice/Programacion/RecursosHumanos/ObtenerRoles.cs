using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerde.Programacion.RecursosHumanos
{
    class ObtenerRoles
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();

        public DataTable BuscarRoles()
        {
            dt.Rows.Clear();
            ob.AbrirConexionBD();
            cmd = new SqlCommand("ObtenerRolUsuario", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idusuario", -1);
            da.SelectCommand = cmd;
            da.Fill(dt);
            ob.CerrarConexionBD();
            return dt;
        }

        public void CrearRol(string nomRol)
        {
            ob.AbrirConexionBD();
            cmd = new SqlCommand("AgregarRolUsuario", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nomRol", nomRol);
            cmd.ExecuteReader();
            ob.CerrarConexionBD();
        }

        public void CambiarRol(int idRol, string nomRol)
        {
            ob.AbrirConexionBD();
            cmd = new SqlCommand("ModificarRolUsuario", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idRol", idRol);
            cmd.Parameters.AddWithValue("@nomRol", nomRol);
            cmd.ExecuteReader();
            ob.CerrarConexionBD();
        }

        public int EliminarRol(int idRol)
        {
            ob.AbrirConexionBD();
            cmd = new SqlCommand("EliminarRolUsuario", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idRol", idRol);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            return Convert.ToInt32(reader[0].ToString());
        }

        public DataTable BuscarPermisos(int idRol)
        {
            dt2.Rows.Clear();
            ob.AbrirConexionBD();
            cmd = new SqlCommand("ObtenerPermisosRol", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idRol", idRol);
            da.SelectCommand = cmd;
            da.Fill(dt2);
            ob.CerrarConexionBD();
            return dt2;
        }

        public void CrearPermisos(int idRol)
        {
            ob.AbrirConexionBD();
            cmd = new SqlCommand("AgregarPermisosRol", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idRol", idRol);
            cmd.ExecuteReader();
            ob.CerrarConexionBD();
        }

        public void GuardarPermisos(int idRol, List<bool> p)
        {
            ob.AbrirConexionBD();
            cmd = new SqlCommand("ActualizarPermisosRol", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            // ID rol
            cmd.Parameters.AddWithValue("@idRol", idRol);
            // Permisos comunes
            cmd.Parameters.AddWithValue("@VerificadorAcceder", p[0] ? 1 : 0);
            cmd.Parameters.AddWithValue("@PedidoClienteAcceder", p[1] ? 1 : 0);
            cmd.Parameters.AddWithValue("@DevolucionesVentasAcceder", p[2] ? 1 : 0);
            // Permisos BackOffice
            cmd.Parameters.AddWithValue("@EtiquetasPendientesPegarAcceder", p[3] ? 1 : 0);
            cmd.Parameters.AddWithValue("@PreescanearEtiquetas", p[4] ? 1 : 0);
            cmd.Parameters.AddWithValue("@VerificarInventario", p[5] ? 1 : 0);
            cmd.Parameters.AddWithValue("@KardexAcceder", p[6] ? 1 : 0);
            cmd.Parameters.AddWithValue("@RecibirAcceder", p[7] ? 1 : 0);
            cmd.Parameters.AddWithValue("@DevolucionesComprasAcceder", p[8] ? 1 : 0);
            cmd.Parameters.AddWithValue("@ProductosPendientesComprasAcceder", p[9] ? 1 : 0);
            cmd.Parameters.AddWithValue("@AltaProducto", p[10] ? 1 : 0);
            cmd.Parameters.AddWithValue("@PrecapturarProducto", p[11] ? 1 : 0);
            cmd.Parameters.AddWithValue("@ModificarProducto", p[12] ? 1 : 0);
            cmd.Parameters.AddWithValue("@ClavesAdicionalesAcceder", p[13] ? 1 : 0);
            cmd.Parameters.AddWithValue("@EntradasSalidasProductoAcceder", p[14] ? 1 : 0);
            cmd.Parameters.AddWithValue("@CotizacionCompras", p[15] ? 1 : 0);
            cmd.Parameters.AddWithValue("@InicciarSesionBackOffice", p[16] ? 1 : 0);
            // Permisos Punto de Venta
            cmd.Parameters.AddWithValue("@DesbloquearCaja", p[17] ? 1 : 0);
            cmd.Parameters.AddWithValue("@HacerCorte", p[18] ? 1 : 0);
            cmd.Parameters.AddWithValue("@HacerDevolucion", p[19] ? 1 : 0);
            cmd.Parameters.AddWithValue("@EliminarProducto", p[20] ? 1 : 0);
            cmd.Parameters.AddWithValue("@HacerCotizacionVenta", p[21] ? 1 : 0);
            cmd.Parameters.AddWithValue("@IniciarSesionPuntoVenta", p[22] ? 1 : 0);


            cmd.ExecuteReader();
            ob.CerrarConexionBD();
        }
        public List<bool[]> ObtenerRolesPermisos(int idRol)
        {
            ob.AbrirConexionBD();
            cmd = new SqlCommand("ObtenerPermisosRol", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idRol", idRol);
            SqlDataReader rdr = cmd.ExecuteReader();
            List<bool[]> res = new List<bool[]>();
            while (rdr.Read())
            {
                res.Add(new bool[] {
                    bool.Parse(rdr[0].ToString()),
                    bool.Parse(rdr[1].ToString()),
                    bool.Parse(rdr[2].ToString()),
                    bool.Parse(rdr[3].ToString()),
                    bool.Parse(rdr[4].ToString()),
                    bool.Parse(rdr[5].ToString()),
                    bool.Parse(rdr[6].ToString()),
                    bool.Parse(rdr[7].ToString()),
                    bool.Parse(rdr[8].ToString()),
                    bool.Parse(rdr[9].ToString()),
                    bool.Parse(rdr[10].ToString()),
                    bool.Parse(rdr[11].ToString()),
                    bool.Parse(rdr[12].ToString()),
                    bool.Parse(rdr[13].ToString()),
                    bool.Parse(rdr[14].ToString()),
                    bool.Parse(rdr[15].ToString()),
                    bool.Parse(rdr[16].ToString()),
                    bool.Parse(rdr[17].ToString()),
                    bool.Parse(rdr[18].ToString()),
                    bool.Parse(rdr[19].ToString()),
                    bool.Parse(rdr[20].ToString()),
                    bool.Parse(rdr[21].ToString()),
                    bool.Parse(rdr[22].ToString())
                });
            }
            return res;
        }

        public List<String[]> ObtenerTodosRoles()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerRolUsuario", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idusuario", -1));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<String[]> resultado = new List<String[]>();

            while (rdr.Read())
            {
                resultado.Add(new String[] { rdr[0] + "", rdr[1] + "" });
            }

            ob.CerrarConexionBD();

            return resultado;
        }

    }
}
