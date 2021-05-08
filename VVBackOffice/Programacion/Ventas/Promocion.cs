using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerde.Programacion.Ventas
{
    class Promocion
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();

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

        public string AgregarHorarioPromocion(string nombre,string lunes, string martes, string miercoles, string jueves, string viernes, string sabado, string domingo)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AgregarHorarioPromocion", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
            cmd.Parameters.Add(new SqlParameter("@lunes", lunes));
            cmd.Parameters.Add(new SqlParameter("@martes", martes));
            cmd.Parameters.Add(new SqlParameter("@miercoles", miercoles));
            cmd.Parameters.Add(new SqlParameter("@jueves", jueves));
            cmd.Parameters.Add(new SqlParameter("@viernes", viernes));
            cmd.Parameters.Add(new SqlParameter("@sabado", sabado));
            cmd.Parameters.Add(new SqlParameter("@domingo", domingo));

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

        public List<string[]> ObtenerTodosHorariosPromocion()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerTodosHorariosPromocion", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<string[]> res = new List<string[]>();

            while (rdr.Read())
            {
                res.Add(new String[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + "", rdr[6] + "", rdr[7] + "", rdr[8] + "" });
            }

            ob.CerrarConexionBD();

            return res;
        }

        public string AgregarPromocion(string nombre, DateTime fechaInicio, DateTime fechaFin, int cantidadLimite, int idHorario, int descuento, int usarPrecio, string Estado,bool nuncaExpira)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AgregarPromocion", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
            if (nuncaExpira)
            {
                cmd.Parameters.Add(new SqlParameter("@fechaInicio", DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@fechaFin", DBNull.Value));
            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
                cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
            }
            cmd.Parameters.Add(new SqlParameter("@cantidadLimite", cantidadLimite));
            cmd.Parameters.Add(new SqlParameter("@idHorario", idHorario));
            cmd.Parameters.Add(new SqlParameter("@descuento", descuento));
            cmd.Parameters.Add(new SqlParameter("@usarPrecio", usarPrecio));
            cmd.Parameters.Add(new SqlParameter("@Estado", Estado));

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

        public string AgregarPromocionProducto(int idPromocion, string idAquien, string tipoAQuien)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AgregarPromocionProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idPromocion", idPromocion));
            cmd.Parameters.Add(new SqlParameter("@idAquien", idAquien));
            cmd.Parameters.Add(new SqlParameter("@tipoAQuien", tipoAQuien));

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

        public string AgregarPromocionProductosAdicionales(int idPromocion, string idProductoAdicional, int cantidad, int descuento)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AgregarPromocionProductosAdicionales", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idPromocion", idPromocion));
            cmd.Parameters.Add(new SqlParameter("@idProductoAdicional", idProductoAdicional));
            cmd.Parameters.Add(new SqlParameter("@cantidad", cantidad));
            cmd.Parameters.Add(new SqlParameter("@descuento", descuento));

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

        public string ObtenerCantidadPreciosProducto(string Cod)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerCantidadPreciosProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Cod", Cod));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            string res ="";

            while (rdr.Read())
            {
                res = rdr[0] + "";
            }

            ob.CerrarConexionBD();

            return res;
        }

        public List<string[]> ObtenerPromociones()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerPromociones", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<string[]> res = new List<string[]>();

            while (rdr.Read())
            {
                res.Add(new String[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + "", rdr[6] + "", rdr[7] + "", rdr[8] + "" });
            }

            ob.CerrarConexionBD();

            return res;
        }

        public string[] ObtenerHorarioPromocion(string idHorario)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("SELECT * FROM HorarioPromocion WHERE IDHorario = "+idHorario+"", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            //cmd.CommandType = CommandType.StoredProcedure;

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            string[] res = new string[9];

            while (rdr.Read())
            {
                res = (new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + "", rdr[6] + "", rdr[7] + "", rdr[8] + "" });
            }

            ob.CerrarConexionBD();

            return res;
        }

        public List<string[]> ObtenerProductosAdicionalesPromocion(string idPromocion)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("SELECT * FROM Promocion_ProductoAdicional WHERE IDPromocion = " + idPromocion + "", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            //cmd.CommandType = CommandType.StoredProcedure;

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<string[]> res = new List<string[]>();

            while (rdr.Read())
            {
                res.Add(new String[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + ""});
            }

            ob.CerrarConexionBD();

            return res;
        }

        public List<string[]> ObtenerProductoPromocion(string idPromocion)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("SELECT * FROM Promocion_Producto WHERE IDPromocion = " + idPromocion + "", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            //cmd.CommandType = CommandType.StoredProcedure;

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<string[]> res = new List<string[]>();

            while (rdr.Read())
            {
                res.Add(new String[] { rdr[0] + "", rdr[1] + "", rdr[2] + ""});
            }

            ob.CerrarConexionBD();

            return res;
        }

        public string ActualizarEstadoPromocion(string idPromocion, string nEstado)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ActualizarEstadoPromocion", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idPromocion", idPromocion));
            cmd.Parameters.Add(new SqlParameter("@nuevoEstado", nEstado));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            string res = "0";

            while (rdr.Read())
            {
                res = rdr + "";
            }

            ob.CerrarConexionBD();

            return res;
        }

        public List<string[]> ObtenerPromocion(long idPromocion)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerPromocionConID", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idPromocion", idPromocion));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<string[]> res = new List<string[]>();

            while (rdr.Read())
            {
                res.Add(new String[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + "", rdr[6] + "", rdr[7] + "", rdr[8] + "", rdr[9] + ""});
            }

            ob.CerrarConexionBD();

            return res;
        }

        public string ActualizaPromocion(long idPromocion, string nombrePromo, DateTime fechaInicio, DateTime fechaFin, int cantidadLimite, long idHorario,int decuento, int usaPrecio, string nEstado, bool nuncaExpira)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ActualizarPromocion", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idPromocion", idPromocion));
            cmd.Parameters.Add(new SqlParameter("@nombrePromo", nombrePromo));
            if (nuncaExpira)
            {
                cmd.Parameters.Add(new SqlParameter("@fechaInicio", DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@fechaFin", DBNull.Value));
            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
                cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
            }
            cmd.Parameters.Add(new SqlParameter("@cantidadLimite", cantidadLimite));
            cmd.Parameters.Add(new SqlParameter("@idHorario", idHorario));
            cmd.Parameters.Add(new SqlParameter("@decuento", decuento));
            cmd.Parameters.Add(new SqlParameter("@usaPrecio", usaPrecio));
            cmd.Parameters.Add(new SqlParameter("@estado", nEstado));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            string res = "0";

            while (rdr.Read())
            {
                res = rdr + "";
            }

            ob.CerrarConexionBD();

            return res;
        }

        public int ObtenerCantidadImagenesProducto(string idProd)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerCantidadImagenesProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            int res = 0;
            while (rdr.Read())
            {
                res = int.Parse(rdr[0] + "");
            }

            ob.CerrarConexionBD();

            return res;
        }
        
        public List<Image> ObtenerImagenesProducto(string idProd)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerImagenesProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            List<Image> res = new List<Image>();
            while (rdr.Read())
            {
                byte[] b = (byte[])rdr.GetValue(0);

                Image img = Image.FromStream(new MemoryStream(b));

                res.Add(img);
            }

            ob.CerrarConexionBD();

            return res;
        }

        public void AgregarImagenPromocion(long idPromocion, Image imagen, Image adicional)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AgregarImagenPromocion", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idPromocion", idPromocion));
            cmd.Parameters.Add(new SqlParameter("@imagen", ImageToByteArra(imagen)));
            if (adicional != null)
            {
                cmd.Parameters.Add(new SqlParameter("@imgAdicional", ImageToByteArra(adicional)));
            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@imgAdicional", DBNull.Value));
            }

            // execute the command
            cmd.ExecuteReader();

            ob.CerrarConexionBD();
        }

        public void ActualizarImagenPromocion(long idPromocion, Image imagen, Image adicional)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ModificarImagenPromocion", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idPromocion", idPromocion));
            cmd.Parameters.Add(new SqlParameter("@imagen", ImageToByteArra(imagen)));
            if (adicional != null)
            {
                cmd.Parameters.Add(new SqlParameter("@imgAdicional", ImageToByteArra(adicional)));
            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@imgAdicional", DBNull.Value));
            }
            

            // execute the command
            cmd.ExecuteReader();

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

        public List<object[]> ObtenerImagenPromocion(long idProd)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerImagenPromocion", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            List<object[]> res = new List<object[]>();
            while (rdr.Read())
            { 
                res.Add(new object[] { rdr[0], rdr[1] });
            }

            ob.CerrarConexionBD();

            return res;
        }

        public string ExisteImagenPromocion(long idPromo)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ExisteImagenPromocion", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idPromo", idPromo));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            string res = "0";
            while (rdr.Read())
            {
                res = rdr[0] + "";
            }

            ob.CerrarConexionBD();

            return res;
        }
    }
}
