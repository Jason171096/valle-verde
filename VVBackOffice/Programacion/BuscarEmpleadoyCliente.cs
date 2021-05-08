using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerde.Programacion
{
    class BuscarEmpleadoyCliente
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        private int esActivo;

        public BuscarEmpleadoyCliente()
        {
        }

        public BuscarEmpleadoyCliente(bool esActivo)
        {
            this.esActivo = esActivo ? 1 : 0;
        }

        public DataTable BuscarEmpleado()
        {
            ob.AbrirConexionBD();
            cmd = new SqlCommand("BuscarEmpleado", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);
            ob.CerrarConexionBD();
            return dt;
        }

        public DataTable BuscarCliente()
        {
            dt2.Rows.Clear();
            ob.AbrirConexionBD();
            cmd = new SqlCommand("BuscarCliente", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@esActivo", esActivo);
            da.SelectCommand = cmd;
            da.Fill(dt2);
            ob.CerrarConexionBD();
            return dt2;
        }

        public void CambiarFiltroCliente(bool esActivo)
        {
            this.esActivo = esActivo ? 1 : 0;
            BuscarCliente();
        }
    }
}
