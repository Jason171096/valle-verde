using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ValleVerde.Programacion.Configuracion
{
    class Sucursales
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();

        public string AltaSucursal(string nombre, string domicilio, string nExterior, string nInterior, string colonia, int CP, string ciudad, string estado, string pais, string telefono, string celular, string correo, bool estadoS, string slogan,string nombreCorto, Image logotipo, string nombreServidor, string conexion)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AltaSucursal", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
            cmd.Parameters.Add(new SqlParameter("@domicilio", domicilio));
            cmd.Parameters.Add(new SqlParameter("@nExterior", nExterior));
            cmd.Parameters.Add(new SqlParameter("@nInterior", nInterior));
            cmd.Parameters.Add(new SqlParameter("@colonia", colonia));
            cmd.Parameters.Add(new SqlParameter("@CP", CP));
            cmd.Parameters.Add(new SqlParameter("@ciudad", ciudad));
            cmd.Parameters.Add(new SqlParameter("@estado", estado));
            cmd.Parameters.Add(new SqlParameter("@pais", pais));
            cmd.Parameters.Add(new SqlParameter("@telefono", telefono));
            cmd.Parameters.Add(new SqlParameter("@celular", celular));
            cmd.Parameters.Add(new SqlParameter("@correo", correo));
            cmd.Parameters.Add(new SqlParameter("@estadoS", estadoS));
            cmd.Parameters.Add(new SqlParameter("@slogan", slogan));
            cmd.Parameters.Add(new SqlParameter("@nombreCorto", nombreCorto));
            cmd.Parameters.Add(new SqlParameter("@logotipo", ImageToByteArra(logotipo)));
            cmd.Parameters.Add(new SqlParameter("@nombreServidor", nombreServidor));
            cmd.Parameters.Add(new SqlParameter("@conexion", conexion));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            string resultado = "";

            while (rdr.Read())
            {
                resultado = rdr[0] + "";
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public string ActualizarSucursal(long idSucursal,string nombre, string domicilio, string nExterior, string nInterior, string colonia, int CP, string ciudad, string estado, string pais, string telefono, string celular, string correo, bool estadoS, string slogan, string nombreCorto, Image logotipo, string nombreServidor, string conexion)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ActualizarSucursal", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idSucursal", idSucursal));
            cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
            cmd.Parameters.Add(new SqlParameter("@domicilio", domicilio));
            cmd.Parameters.Add(new SqlParameter("@nExterior", nExterior));
            cmd.Parameters.Add(new SqlParameter("@nInterior", nInterior));
            cmd.Parameters.Add(new SqlParameter("@colonia", colonia));
            cmd.Parameters.Add(new SqlParameter("@CP", CP));
            cmd.Parameters.Add(new SqlParameter("@ciudad", ciudad));
            cmd.Parameters.Add(new SqlParameter("@estado", estado));
            cmd.Parameters.Add(new SqlParameter("@pais", pais));
            cmd.Parameters.Add(new SqlParameter("@telefono", telefono));
            cmd.Parameters.Add(new SqlParameter("@celular", celular));
            cmd.Parameters.Add(new SqlParameter("@correo", correo));
            cmd.Parameters.Add(new SqlParameter("@estadoS", estadoS));
            cmd.Parameters.Add(new SqlParameter("@slogan", slogan));
            cmd.Parameters.Add(new SqlParameter("@nombreCorto", nombreCorto));
            cmd.Parameters.Add(new SqlParameter("@logotipo", ImageToByteArra(logotipo)));
            //cmd.Parameters.Add(new SqlParameter("@logotipo", DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@nombreServidor", nombreServidor));
            cmd.Parameters.Add(new SqlParameter("@conexion", conexion));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            string resultado = "";

            while (rdr.Read())
            {
                resultado = rdr[0] + "";
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public void EliminarSucursal(int IDSucursal)
        {
            ob.AbrirConexionBD();

            
                SqlCommand cmd = new SqlCommand("EliminarSucursal", ob.ObtenerConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IDSucursal", IDSucursal));

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0]);
                }
                ob.CerrarConexionBD();

            
        }

        private byte[] ImageToByteArra(System.Drawing.Image imageIn)
        {
            using (MemoryStream msc = new MemoryStream())
            {
                imageIn.Save(msc, ImageFormat.Bmp);
                return msc.ToArray();
            }
        }

        public List<string[]> ObtenerSucursales()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerSucursales", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<string[]> res = new List<string[]>();

            while (rdr.Read())
            {
                res.Add(new String[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[17] + "", rdr[18] + "", rdr[22] + "", rdr[13] + ""});
            }

            ob.CerrarConexionBD();

            return res;
        }

        public string[] ObtenerSucursalConID(long idSucursal)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerSucursalConID", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idSucursal", idSucursal));
            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            string[] res = new string[23];

            while (rdr.Read())
            {
                res = (new String[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + "", rdr[6] + "", rdr[7] + "", rdr[8] + "", rdr[9] + "", rdr[10] + "", rdr[11] + "", rdr[12] + "", rdr[13] + "", rdr[14] + "", rdr[15] + "", rdr[16] + "", rdr[17] + "", rdr[18] + "", rdr[19] + "", rdr[20] + "", rdr[21] + "", rdr[22] + ""});
            }

            ob.CerrarConexionBD();

            return res;
        }

        public string ObtenerNombreProducto(string idProducto)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerNombreProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Cod", idProducto));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            string resultado = "";

            while (rdr.Read())
            {
                resultado = rdr[0] + "";
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public List<decimal[]> ObtenerPreciosCostoProducto(string idProd)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd;

            cmd = new SqlCommand("ObtenerPreciosCostoProducto", ob.ObtenerConexion());


            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            List<decimal[]> res = new List<decimal[]>();
            while (rdr.Read())
            {
                //Utilidad - Cantidad
                res.Add(new decimal[] { decimal.Parse(rdr[0] + ""), decimal.Parse(rdr[1] + "") });
            }

            ob.CerrarConexionBD();

            return res;
        }

        public decimal ObtenerPrecioProducto(string idProd, decimal cantidad, decimal utilidadSobreCosto, decimal descuento)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd;

            cmd = new SqlCommand("ObtenerPrecioProducto", ob.ObtenerConexion());


            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));
            cmd.Parameters.Add(new SqlParameter("@Cant", cantidad));
            cmd.Parameters.Add(new SqlParameter("@utilidadSobreCosto", utilidadSobreCosto));
            cmd.Parameters.Add(new SqlParameter("@descuento", descuento));
            cmd.Parameters.Add(new SqlParameter("@pagoConTarjeta", "0"));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            decimal res = -1;
            while (rdr.Read())
            {
                //Utilidad - Cantidad
                res = decimal.Parse(rdr[0] + "");
            }

            ob.CerrarConexionBD();

            return res;
        }

        public decimal ObtenerCostoProducto(string idProd)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerCostoProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            decimal res = 0;
            while (rdr.Read())
            {
                res = decimal.Parse(rdr[0] + "");
            }

            ob.CerrarConexionBD();

            return res;
        }

        public string AgregarUtilidadSucursal(string idProducto, long idSucursal, double utilidadSucursal)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AgregarUtilidadSucursal", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idProducto", idProducto));
            cmd.Parameters.Add(new SqlParameter("@idSucursal", idSucursal));
            cmd.Parameters.Add(new SqlParameter("@utilidadSucursal", utilidadSucursal));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            string resultado = "";

            while (rdr.Read())
            {
                resultado = rdr[0] + "";
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public bool HaySucursalesActivas()
        {
            ob.AbrirConexionBD();
            string sql = "SELECT COUNT(estadoS) FROM Sucursal WHERE EstadoS = 1";
            SqlCommand cmd = new SqlCommand(sql, ob.ObtenerConexion());
            int i = (int)cmd.ExecuteScalar();
            ob.CerrarConexionBD();

            if (i > 0) { return true; } else { return false; }
        }
    }
}
