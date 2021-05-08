using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ValleVerde.Programacion.Compra
{
    class CreditoCompra
    {

        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();


        public List<String[]> ObtenerProveedoresComprasPendientes()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerProveedoresComprasPendientes", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<String[]> resultado = new List<String[]>();

            while (rdr.Read())
            {
                resultado.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + ""});
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        
        public List<object[]> ObtenerFacturasDeComprasPendientes(long idProv)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerFacturasDeComprasPendientes", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProv", idProv));
            //cmd.Parameters.Add(new SqlParameter("@numFecLim", numFecLim));
            ////cmd.Parameters.Add(new SqlParameter("@Con1", Con1));
            ////cmd.Parameters.Add(new SqlParameter("@Con2", Con2));
            //cmd.Parameters.Add(new SqlParameter("@idFac", idFac));
            //cmd.Parameters.Add(new SqlParameter("@fecLim", fecLim));
            //cmd.Parameters.Add(new SqlParameter("@motLim", motLim));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();
           

            //Pasar datos a vector para regresarlos
            List<object[]> resultado = new List<object[]>();

            while (rdr.Read())
            {
                resultado.Add(new object[] { rdr[0]  , rdr[1]  , rdr[2] , rdr[3] , rdr[4] , rdr[5], rdr[6], rdr[7], rdr[8],rdr[9]});
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public List<String[]> ObtenerFormaPago()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerFormaPago", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

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

        public DateTime ObtenerFechaServidor()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerFechaServidor", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            DateTime resultado = new DateTime();

            while (rdr.Read())
            {
                resultado = DateTime.Parse(rdr[0] + "");
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public List<String[]> ObtenerTodosProveedores(String estado, String ciudad, String buscar, int activo)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerTodosProveedores", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@estado", estado));
            cmd.Parameters.Add(new SqlParameter("@ciudad", ciudad));
            cmd.Parameters.Add(new SqlParameter("@buscar", buscar));
            cmd.Parameters.Add(new SqlParameter("@activo", activo));
            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<String[]> resultado = new List<String[]>();

            while (rdr.Read())
            {
                resultado.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "" });
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        internal List<object[]> ObtenerAbonosFacturaCreditoCompra(long IDFAC)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerAbonosFacturaCreditoCompra", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@IDFAC", IDFAC));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();


            //Pasar datos a vector para regresarlos
            List<object[]> resultado = new List<object[]>();

            while (rdr.Read())
            {
                resultado.Add(new object[] { rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6] });
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public List<object[]> AgregarAbonoCreditoCompra(long idFactura, decimal Importe , DateTime Fecha, long idForPago, long idUsuario, String Referencia, bool AplicarMasAntiguas)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AgregarAbonoCreditoCompra", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idFactura", idFactura));
            cmd.Parameters.Add(new SqlParameter("@Importe", Importe));
            cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
            cmd.Parameters.Add(new SqlParameter("@idForPago", idForPago));
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
            cmd.Parameters.Add(new SqlParameter("@Referencia", Referencia));
            cmd.Parameters.Add(new SqlParameter("@AplicarMasAntiguas", AplicarMasAntiguas));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();


            //Pasar datos a vector para regresarlos
            List<object[]> resultado = new List<object[]>();

            while (rdr.Read())
            {
                resultado.Add(new object[] { rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7] });
            }

            ob.CerrarConexionBD();

            return resultado;
        }
    }
}
