using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Data.Linq;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;

namespace ValleVerdeComun.Programacion
{
    public class Producto
    {
        ConexionBD ob = new ConexionBD();

        public int DarAltaProducto(string codBarras, string nombre, string descripcion, decimal existencia, int idFab, int idMarca, int idLinea, int idUnidad, int idAlmacen, string localizacion, bool noUsaInventario, bool bloqueado, bool pidePeso, float costo, decimal minimo, decimal merma, float utilidadSucursales)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AltaProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@codBarras", codBarras));
            cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
            cmd.Parameters.Add(new SqlParameter("@descripcion", descripcion));
            cmd.Parameters.Add(new SqlParameter("@existencia", existencia));
            cmd.Parameters.Add(new SqlParameter("@IDFabricante", idFab));
            cmd.Parameters.Add(new SqlParameter("@IDMarca", idMarca));
            cmd.Parameters.Add(new SqlParameter("@IDLinea", idLinea));
            cmd.Parameters.Add(new SqlParameter("@IDUnidad", idUnidad));
            cmd.Parameters.Add(new SqlParameter("@IDAlmacen", idAlmacen));
            cmd.Parameters.Add(new SqlParameter("@localizacion", localizacion));
            cmd.Parameters.Add(new SqlParameter("@noUsaInventario", noUsaInventario));
            cmd.Parameters.Add(new SqlParameter("@bloqueado", bloqueado));
            cmd.Parameters.Add(new SqlParameter("@pidepeso", pidePeso));
            cmd.Parameters.Add(new SqlParameter("@costo", costo));
            cmd.Parameters.Add(new SqlParameter("@minimo", minimo));
            cmd.Parameters.Add(new SqlParameter("@merma", merma));
            cmd.Parameters.Add(new SqlParameter("@utilidadSucursales", utilidadSucursales));

            int res = -10;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = Convert.ToInt32(rdr[0]);
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public int ModificarProducto(string codigoOriginal, string codBarras, string nombre, string descripcion, int idFab, int idMarca, int idLinea, int idUnidad, bool noUsaInventario, bool bloqueado, bool pidePeso, decimal costo, decimal minimo, decimal merma, float utilidadSucursales)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ModificarProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@codigoOriginal", codigoOriginal));
            cmd.Parameters.Add(new SqlParameter("@codBarras", codBarras));
            cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
            cmd.Parameters.Add(new SqlParameter("@descripcion", descripcion));
            cmd.Parameters.Add(new SqlParameter("@IDFabricante", idFab));
            cmd.Parameters.Add(new SqlParameter("@IDMarca", idMarca));
            cmd.Parameters.Add(new SqlParameter("@IDLinea", idLinea));
            cmd.Parameters.Add(new SqlParameter("@IDUnidad", idUnidad));
            cmd.Parameters.Add(new SqlParameter("@noUsaInventario", noUsaInventario));
            cmd.Parameters.Add(new SqlParameter("@bloqueado", bloqueado));
            cmd.Parameters.Add(new SqlParameter("@pidepeso", pidePeso));
            cmd.Parameters.Add(new SqlParameter("@costo", costo));
            cmd.Parameters.Add(new SqlParameter("@minimo", minimo));
            cmd.Parameters.Add(new SqlParameter("@merma", merma));
            cmd.Parameters.Add(new SqlParameter("@utilidadSucursales", utilidadSucursales));

            int res = -10;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = Convert.ToInt32(rdr[0]);
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public void ActualizarCostoProducto(string idProd, decimal cosPro)
        {
            ob.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ActualizarCostoProducto", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));
            cmd.Parameters.Add(new SqlParameter("@cosPro", cosPro));
            cmd.ExecuteReader();

            ob.CerrarConexionBD();
        }
        public void EliminarRelacionesConProveedores(string codBarras)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("EliminarRelacionesConProveedores", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@codBarras", codBarras));

            cmd.ExecuteReader();

            ob.CerrarConexionBD();
        }

        public int AgregarProveedorProducto(string idProd, string idProv)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AgregarProveedorProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@codBarras", idProd));
            cmd.Parameters.Add(new SqlParameter("@idProv", idProv));

            int res = -10;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = Convert.ToInt32(rdr[0]);
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public int AgregarImpuestoProducto(string idProd, string idImpuesto)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AgregarImpuestoProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@codBarras", idProd));
            cmd.Parameters.Add(new SqlParameter("@idImpuesto", idImpuesto));

            int res = -10;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = Convert.ToInt32(rdr[0]);
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public void EliminarRelacionesConImpuestos(string codBarras)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("EliminarRelacionesConImpuestos", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@codBarras", codBarras));

            cmd.ExecuteReader();

            ob.CerrarConexionBD();
        }

        public string EliminarPrecios(string codBarras)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("EliminarPrecios", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;


            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@codBarras", codBarras));

            string res = "-1";
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = rdr[0]+"";
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public void EliminarRelacionConClaveSAT(string codBarras)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("EliminarRelacionConClaveSAT", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@codBarras", codBarras));

            cmd.ExecuteReader();

            ob.CerrarConexionBD();
        }

        public void EliminarRelacionesConImagenes(string codBarras)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("EliminarRelacionesConImagenes", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@codBarras", codBarras));

            cmd.ExecuteReader();

            ob.CerrarConexionBD();
        }

        public void EliminarClavesAdicionalesAnteriores(string codBarras)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("EliminarClavesAdicionalesAnteriores", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@codBarras", codBarras));

            cmd.ExecuteReader();

            ob.CerrarConexionBD();
        }

        public void EliminarProductoExtraAnterior(string codBarras)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("EliminarProductoExtraAnterior", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@codBarras", codBarras));

            cmd.ExecuteReader();

            ob.CerrarConexionBD();
        }

        public void AgregarImagenProducto(string idProd, Image img)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AgregarImagenProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@codBarras", idProd));
            cmd.Parameters.Add(new SqlParameter("@img", ImageToByteArray(img)));

            // execute the command
            cmd.ExecuteReader();

            ob.CerrarConexionBD();
        }

        private byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms,ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public int AgregarPrecioProducto(string idProd, string utilidad, string cantidad, string idHistorialCosto)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AgregarPrecioProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@codBarras", idProd));
            cmd.Parameters.Add(new SqlParameter("@utilidad", utilidad));
            cmd.Parameters.Add(new SqlParameter("@cantidad", cantidad));
            cmd.Parameters.Add(new SqlParameter("@idHistorialCosto", idHistorialCosto));

            int res = -10;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = Convert.ToInt32(rdr[0]);
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public Boolean ExisteProductoConCodigo(TextBox cod, bool incluirBloqueados, bool ocupoTengaPrecios, bool debeCoincidirExactamente, string idAlmacen)
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ExisteProductoConCodigo", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Cod", cod.Text));
            cmd.Parameters.Add(new SqlParameter("@idAlmacen", idAlmacen));
            cmd.Parameters.Add(new SqlParameter("@debeCoincidirExactamente", debeCoincidirExactamente));

            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                int res = -1;
                string codigoResultado = "";
                while (rdr.Read())
                {
                    res = int.Parse(rdr[0] + "");
                    codigoResultado = rdr[1] + "";
                }
                ob.CerrarConexionBD();

                //Si el codigo que resulto es diferente al que mande significa
                //que el que mande era clave adicional
                if (codigoResultado != cod.Text)
                    cod.Text = codigoResultado;

                switch (res)
                {
                    case 1:
                        return true;
                    case -1:
                        return false;
                    case -2:
                        if (incluirBloqueados)
                            return true;
                        else
                            return false;
                    case -3:
                        if (ocupoTengaPrecios)
                            return false;
                        else
                            return true;

                }
                return false;
            }


        }

        public Boolean EsClaveAdicional(string cod)
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("EsClaveAdicional", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Cod", cod));

            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                int res = -1;
                while (rdr.Read())
                {
                    res = int.Parse(rdr[0] + "");
                }
                ob.CerrarConexionBD();

                if (res == 1)
                    return true;
                else
                    return false;
            }


        }

        public Boolean NoUsaInventario(string cod)
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("NoUsaInventario", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Cod", cod));

            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                int res = -1;
                while (rdr.Read())
                {
                    res = int.Parse(rdr[0] + "");
                }
                ob.CerrarConexionBD();

                if (res == 1)
                    return true;
                else
                    return false;
            }


        }

        public Boolean PidePeso(string cod)
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("PidePeso", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Cod", cod));

            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                int res = -1;
                while (rdr.Read())
                {
                    res = int.Parse(rdr[0] + "");
                }
                ob.CerrarConexionBD();

                if (res == 1)
                    return true;
                else
                    return false;
            }


        }

        public Boolean EstaBloqueado(string cod)
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("EstaBloqueado", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Cod", cod));

            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                int res = -1;
                while (rdr.Read())
                {
                    res = int.Parse(rdr[0] + "");
                }
                ob.CerrarConexionBD();

                if (res == 1)
                    return true;
                else
                    return false;
            }


        }

        public string ExisteClaveAdicionalParaProducto(string cod, decimal cant)
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ExisteClaveAdicionalParaProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Cod", cod));
            cmd.Parameters.Add(new SqlParameter("@cant", cant));

            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                string res = "-1";
                while (rdr.Read())
                {
                    res = rdr[0] + "";
                }
                ob.CerrarConexionBD();
                return res;
            }


        }

        public List<string> ObtenerDatosClaveAdicional(string cod)
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerDatosClaveAdicional", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Cod", cod));

            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                List<string> res = new List<string>(); ;
                while (rdr.Read())
                {
                    if (rdr[0] + "" != "-1")
                    {
                        res.Add(rdr[0] + "");
                        res.Add(rdr[1] + "");
                        res.Add(rdr[2] + "");
                    }
                    else
                    {
                        res.Add(rdr[0] + "");
                        break;
                    }
                }
                ob.CerrarConexionBD();

                return res;
            }


        }

        public List<string[]> DatosClavesAdicionalesParaProducto(string cod)
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("DatosClavesAdicionalesParaProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Cod", cod));

            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                List<string[]> res = new List<string[]>(); ;
                while (rdr.Read())
                {
                    if (rdr[0] + "" != "-1")
                    {
                        res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "" });
                    }
                }
                ob.CerrarConexionBD();

                return res;
            }


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

        public List<String[]> ObtenerLocalizacion(string idProd)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerLocalizacion", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> res = new List<string[]>();
            while (rdr.Read())
            {
                res.Add(new String[] { rdr[0] + "", rdr[1] + "", rdr[2] + "" });
            }

            ob.CerrarConexionBD();

            return res;
        }

        public List<String[]> ObtenerClavesAdicionales(string idProd)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerClavesAdicionales", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> res = new List<string[]>();
            while (rdr.Read())
            {
                res.Add(new String[] { rdr[0] + "", rdr[1] + "", rdr[2] + "" });
            }

            ob.CerrarConexionBD();

            return res;
        }

        public List<String[]> ObtenerProductoExtra(string idProd)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerProductoExtra", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> res = new List<string[]>();
            while (rdr.Read())
            {
                res.Add(new String[] { rdr[0] + "", rdr[1] + "", rdr[2] + "" });
            }

            ob.CerrarConexionBD();

            return res;
        }

        public List<String[]> ObtenerProductosPrecapturados()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerProductosPrecapturados", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> res = new List<string[]>();
            while (rdr.Read())
            {
                res.Add(new String[] { rdr[0] + "", rdr[1] + "", rdr[2] + "" });
            }

            ob.CerrarConexionBD();

            return res;
        }

        public int AgregarClaveAdicional(string idProd, string claveAd, string descripcion, string piezas)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AgregarClaveAdicional", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@codBarras", idProd));
            cmd.Parameters.Add(new SqlParameter("@idClaveAd", claveAd));
            cmd.Parameters.Add(new SqlParameter("@descripcion", descripcion));
            cmd.Parameters.Add(new SqlParameter("@piezas", piezas));

            int res = -10;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = Convert.ToInt32(rdr[0]);
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public int AgregarProductoExtra(string idProd, string claveProdExtra, string descripcion, string piezas)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AgregarProductoExtra", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@codBarras", idProd));
            cmd.Parameters.Add(new SqlParameter("@claveProdExtra", claveProdExtra));
            cmd.Parameters.Add(new SqlParameter("@descripcion", descripcion));
            cmd.Parameters.Add(new SqlParameter("@piezas", piezas));

            int res = -10;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = Convert.ToInt32(rdr[0]);
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public string ObtenerNombreProducto(string idProd)
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerNombreProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));

            string res = "";
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = rdr[0] + "";
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public string ObtenerDescripcionProducto(string idProd)
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerDescripcionProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));

            string res = "";
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = rdr[0] + "";
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public decimal ObtenerExistenciaTotalProducto(string idProd)
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerExistenciaTotalProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));

            decimal res = 0;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = decimal.Parse(rdr[0] + "");
                }
            }
            //com
            ob.CerrarConexionBD();
            return res;
        }

        public decimal ObtenerMinimoInventario(string idProd)
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerMinimoInventario", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));

            decimal res = 0;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = decimal.Parse(rdr[0] + "");
                }
            }
            //com
            ob.CerrarConexionBD();
            return res;
        }

        public decimal ObtenerMerma(string idProd)
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerMerma", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));

            decimal res = 0;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = decimal.Parse(rdr[0] + "");
                }
            }
            //com
            ob.CerrarConexionBD();
            return res;
        }

        public decimal ObtenerUtilidadSucursal(string idProd)
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerUtilidadSucursal", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));

            decimal res = 0;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = decimal.Parse(rdr[0] + "");
                }
            }
            //com
            ob.CerrarConexionBD();
            return res;
        }

        public decimal ObtenerExistenciaProducto(string idProd,string idAlmacen)
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerExistenciaProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));
            cmd.Parameters.Add(new SqlParameter("@idAlmacen", idAlmacen));

            decimal res = 0;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = decimal.Parse(rdr[0] + "");
                }
            }
            //com
            ob.CerrarConexionBD();
            return res;
        }

        public int EliminarProducto(string idProd)
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("EliminarProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@codBarras", idProd));

            int res = 0;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = int.Parse(rdr[0] + "");
                }
            }
            //com
            ob.CerrarConexionBD();
            return res;
        }

        public List<String[]> ObtenerProductos(int marca, int linea, int fabricante, int proveedor, int almacen, bool precioDeCosto, int numeroProductosPorPagina, int numeroPagina, string buscar,bool soloClavesAdicionales)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerProductos", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@marca", marca));
            cmd.Parameters.Add(new SqlParameter("@linea", linea));
            cmd.Parameters.Add(new SqlParameter("@fabricante", fabricante));
            cmd.Parameters.Add(new SqlParameter("@proveedor", proveedor));
            cmd.Parameters.Add(new SqlParameter("@almacen", almacen));
            cmd.Parameters.Add(new SqlParameter("@precioDeCosto", precioDeCosto));
            cmd.Parameters.Add(new SqlParameter("@numeroProductosPorPagina", numeroProductosPorPagina));
            cmd.Parameters.Add(new SqlParameter("@numeroPagina", numeroPagina));
            cmd.Parameters.Add(new SqlParameter("@buscar", buscar));
            cmd.Parameters.Add(new SqlParameter("@soloClavesAdicionales", soloClavesAdicionales)); 

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> res = new List<string[]>();
            while (rdr.Read())
            {
                res.Add(new String[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "" });
            }

            ob.CerrarConexionBD();

            return res;
        }

        public decimal QuitarImpuestos(string idProducto, decimal precioVendido)
        {
            List<string[]> impuestosProd = new Impuestos().ObtenerImpuestosProducto(idProducto);

            //Quitarlos invertidos, para uqe no afecte cuando se vuelvan a agregar
            for (int i = impuestosProd.Count - 1; i >= 0; i--)
            {
                precioVendido /= (1 + (decimal.Parse(impuestosProd[i][2]) / 100.00m));
            }

            return precioVendido;
        }

        public string ObtenerIDFacturama(string idProd)
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerIDFacturama", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));

            string res = "";
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = rdr[0] + "";
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public void AsignarIDFacturama(string idProducto, string idFacturama)
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AsignarIDFacturamaProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idProducto", idProducto));
            cmd.Parameters.Add(new SqlParameter("@idFacturama", idFacturama));

            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console

                while (rdr.Read())
                {

                }
                ob.CerrarConexionBD();


            }




        }

    }


}
