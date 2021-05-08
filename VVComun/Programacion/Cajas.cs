using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerdeComun.Programacion
{
    public class Cajas
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();

        public Boolean ExisteCajaConNombre(string nombre)
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ExisteCajaConNombre", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@nom", nombre));

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

                switch (res)
                {
                    case 1:
                        return true;
                    case -1:
                        return false;
                   

                }
                return false;
            }

           


        }

        public Boolean ExisteTicket(string idTicket)
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ExisteTicket", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTicket", idTicket));

            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                bool res = false;
                while (rdr.Read())
                {
                    if (int.Parse(rdr[0] + "") == 1)
                        res = true;
                }
                ob.CerrarConexionBD();

                
                return res;
            }




        }

        public int AltaCaja(string nombre, string idAlmacen)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AltaCaja", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
            cmd.Parameters.Add(new SqlParameter("@idAlmacen", idAlmacen));

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

        public int ActualizarPrecioTicketBD(string idTicket,string idProducto, decimal precio, decimal descuento,decimal comision)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ActualizarPrecioTicketBD", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTicket", idTicket));
            cmd.Parameters.Add(new SqlParameter("@idProducto", idProducto));
            cmd.Parameters.Add(new SqlParameter("@precio", precio));
            cmd.Parameters.Add(new SqlParameter("@descuento", descuento));
            cmd.Parameters.Add(new SqlParameter("@comision", comision));

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

        public int ActualizarOrdenTicketBD(string idTicket, string idProducto, int ordenTicket,bool esProducto)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ActualizarOrdenTicketBD", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTicket", idTicket));
            cmd.Parameters.Add(new SqlParameter("@idProducto", idProducto));
            cmd.Parameters.Add(new SqlParameter("@ordenTicket", ordenTicket));
            cmd.Parameters.Add(new SqlParameter("@esProducto", esProducto));

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

        public string[] ConvertirTicketEnVenta(string idticket,decimal totalCobrado, decimal pagoCon, string idCaja, string idUsuario,bool esGastoParaTienda)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ConvertirTicketEnVenta", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTicket", idticket));
            cmd.Parameters.Add(new SqlParameter("@totalCobrado", totalCobrado));
            cmd.Parameters.Add(new SqlParameter("@pagoCon", pagoCon));
            cmd.Parameters.Add(new SqlParameter("@idCaja", idCaja));
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
            cmd.Parameters.Add(new SqlParameter("@esGastoParaTienda", esGastoParaTienda));

            string[] res = new string[2];
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res[0] = rdr[0] + "";
                    res[1] = rdr[1] + "";
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public int AgregarFormaPago(string idVenta, int formaPago, decimal monto, string referencia)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AgregarFormaPago", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idVenta", idVenta));
            cmd.Parameters.Add(new SqlParameter("@formaPago", formaPago));
            cmd.Parameters.Add(new SqlParameter("@monto", monto));
            cmd.Parameters.Add(new SqlParameter("@referencia", referencia));

            int res = -1;
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

        public int AgregarACredito(string idVenta, string idCliente)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AgregarACredito", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idVenta", idVenta));
            cmd.Parameters.Add(new SqlParameter("@idCliente", idCliente));

            int res = -1;
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

        public int AltaTicket(string idCaja, string nombreTicket)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AltaTicket", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idCaja", idCaja));
            cmd.Parameters.Add(new SqlParameter("@nombreTicket", nombreTicket));

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

        public int AgregarProductoTicket(string idTicket, string codigoProd, decimal cant, decimal precio, string claveAdicional, decimal piezasPorCaja, bool seAutorizoVentaSinExistencia, decimal descuento,int ordenTicket)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AgregarProductoTicket", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTicket", idTicket));
            cmd.Parameters.Add(new SqlParameter("@codigoProd", codigoProd));
            cmd.Parameters.Add(new SqlParameter("@cant", cant));
            cmd.Parameters.Add(new SqlParameter("@precio", precio));
            cmd.Parameters.Add(new SqlParameter("@claveAdicional", claveAdicional));
            cmd.Parameters.Add(new SqlParameter("@piezasPorCaja", piezasPorCaja));
            cmd.Parameters.Add(new SqlParameter("@seAutorizoVentaSinExistencia", seAutorizoVentaSinExistencia));
            cmd.Parameters.Add(new SqlParameter("@descuento", descuento));
            cmd.Parameters.Add(new SqlParameter("@ordenTicket", ordenTicket));
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

        public int AgregarRecargaServicioTicketBD(string idTicket, string sku, string descripcion, string destino, decimal monto, string extra,int ordenTicket)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AgregarRecargaServicioTicketBD", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTicket", idTicket));
            cmd.Parameters.Add(new SqlParameter("@sku", sku));
            cmd.Parameters.Add(new SqlParameter("@descripcion", descripcion));
            cmd.Parameters.Add(new SqlParameter("@destino", destino));
            cmd.Parameters.Add(new SqlParameter("@monto", monto));
            cmd.Parameters.Add(new SqlParameter("@extra", extra));
            cmd.Parameters.Add(new SqlParameter("@ordenTicket", ordenTicket));
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

        public int EliminarTicket(string idTicket,bool aunqueTengaProductos)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("EliminarTicket", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTicket", idTicket));
            cmd.Parameters.Add(new SqlParameter("@aunqueTengaProductos", aunqueTengaProductos));

            int res = -1;
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

        public List<string[]> ObtenerTicketsCaja(string idCaja)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerTicketsCaja", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idCaja", idCaja));

            List<string[]> res = new List<string[]>();
            // execute the command 
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res.Add(new string[] { rdr[0] +"", rdr[1] + "" , rdr[2] + "", rdr[3] + "" });
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public string[] ObtenerTicketCotizacion(string idTicket,string idCaja)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerTicketCotizacion", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTicket", idTicket));
            cmd.Parameters.Add(new SqlParameter("@idCaja", idCaja));

            string[] res = null;
            // execute the command 
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + ""};
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public string[] ObtenerTicketParaPedido(string idCaja, string idPedido)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerTicketParaPedido", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idCaja", idCaja));
            cmd.Parameters.Add(new SqlParameter("@idPedido", idPedido));

            string[] res = null;
            // execute the command 
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    if(rdr[0] + ""!="-1")
                        res = new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "" };
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public List<string[]> ObtenerProductosTicket(string idTicket)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerProductosTicket", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTicket", idTicket));

            List<string[]> res = new List<string[]>();
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + "", rdr[6] + "" });
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public List<string[]> ObtenerRecargasServiciosTicket(string idTicket)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerRecargasServiciosTicket", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTicket", idTicket));

            List<string[]> res = new List<string[]>();
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + "" });
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public int EliminarTicketRecargaServicio(string idTicket,string sku,string destino,decimal monto)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("EliminarTicketRecargaServicio", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTicket", idTicket));
            cmd.Parameters.Add(new SqlParameter("@sku", sku));
            cmd.Parameters.Add(new SqlParameter("@destino", destino));
            cmd.Parameters.Add(new SqlParameter("@monto", monto));

            int res = -1;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = int.Parse( rdr[0] + "");
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public int ActualizarComisionRecargaServicioTicketBD(string idTicket, string sku, string destino, decimal monto,decimal comision)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ActualizarComisionRecargaServicioTicketBD", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTicket", idTicket));
            cmd.Parameters.Add(new SqlParameter("@sku", sku));
            cmd.Parameters.Add(new SqlParameter("@destino", destino));
            cmd.Parameters.Add(new SqlParameter("@monto", monto));
            cmd.Parameters.Add(new SqlParameter("@comision", comision));

            int res = -1;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = int.Parse(rdr[0] + "");
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public List<string[]> ObtenerRecargasServiciosVenta(string idVenta,bool incluirServicios, bool incluirComisiones)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerRecargasServiciosVenta", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idVenta", idVenta));
            cmd.Parameters.Add(new SqlParameter("@incluirServicios", incluirServicios));
            cmd.Parameters.Add(new SqlParameter("@incluirComisiones", incluirComisiones));

            List<string[]> res = new List<string[]>();
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                        res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + "", rdr[6] + "" });
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public int MarcarDevolucionVenta(string IDVent_Prod, bool esRecargaServicio, decimal cantDevolver,string idAlmacen,string idTurno)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("MarcarDevolucionVenta", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@IDVent_Prod", IDVent_Prod));
            cmd.Parameters.Add(new SqlParameter("@esRecargaServicio", esRecargaServicio));
            cmd.Parameters.Add(new SqlParameter("@cantDevolver", cantDevolver));
            cmd.Parameters.Add(new SqlParameter("@idAlmacen", idAlmacen));
            cmd.Parameters.Add(new SqlParameter("@idTurno", idTurno));

            int res = -1;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = int.Parse(rdr[0] + "");
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public int MarcarFechaRecargaServicioVenta(string idProducto, string fecha, string pin,string extra)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("MarcarFechaRecargaServicioVenta", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idProducto", idProducto));
            cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
            cmd.Parameters.Add(new SqlParameter("@extra", extra));
            cmd.Parameters.Add(new SqlParameter("@pin", pin));

            int res = -1;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = int.Parse(rdr[0] + "");
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public int EliminarVentaRecargaServicioConID(string idVenta_RecargaServicio)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("EliminarVentaRecargaServicioConID", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idVenta_RecargaServicio", idVenta_RecargaServicio));

            int res = -1;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = int.Parse(rdr[0] + "");
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public int ConvertirTicketACotizacion(string idTicket)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ConvertirTicketACotizacion", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTicket", idTicket));

            int res = -1;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = int.Parse(rdr[0] + "");
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public List<string[]> ConvertirCotizacionATicket(string idTicket)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ConvertirCotizacionATicket", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTicket", idTicket));

            List<string[]>  res =new List<string[]>();
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res.Add(new string[] { rdr[0] + "", rdr[1] + "" });
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public int  ConvertirPedidoATicket(string idPedido, string idTicket)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ConvertirPedidoATicket", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idPedido", idPedido));
            cmd.Parameters.Add(new SqlParameter("@idTicket", idTicket));

            int res = -10;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = int.Parse(rdr[0] + "" );
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public bool EsTicketCotizacion(string idTicket)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("EsTicketCotizacion", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTicket", idTicket));

            bool res = false;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    string s = rdr[0] + "";
                    if (s != "-1")
                        res = Convert.ToBoolean(s);
                    else
                        return false;
                    

                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public bool TieneTurnoAbierto(string idCaja)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("TieneTurnoAbierto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idCaja", idCaja));

            bool res = false;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    string s = rdr[0] + "";
                    if (s == "1")
                        res = true;
                    


                }
            }

            ob.CerrarConexionBD();
            return res;
        }


        public List<string[]> ObtenerVentasDelDia(System.DateTime fecha)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerVentasDelDia", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@fecha", fecha));

            List<string[]> res = new List<string[]>();
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "" });
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public string ObtenerNombreCajero(string idUsuario)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerNombreCajero", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));

            string res = "-1";
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

        public List<string> ObtenerDatosVenta(string idVenta)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerDatosVenta", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idVenta", idVenta));

            List<string> res = new List<string>();
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res.Add( rdr[0] + "");
                    res.Add(rdr[1] + "");
                    res.Add(rdr[2] + "");
                    res.Add(rdr[3] + "");
                    res.Add(rdr[4] + "");
                    res.Add(rdr[5] + "");
                    res.Add(rdr[6] + "");
                    res.Add(rdr[7] + "");
                    res.Add(rdr[8] + "");
                    res.Add(rdr[9] + "");
                    res.Add(rdr[10] + "");
                    res.Add(rdr[11] + "");
                    res.Add(rdr[12] + "");
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public List<string[]> ObtenerProductosVenta(string idVenta)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerProductosVenta", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idVenta", idVenta));

            List<string[]> res = new List<string[]>();
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + "", rdr[6] + "", rdr[7] + "", rdr[8] + "", rdr[9] + "", rdr[10] + "", rdr[11] + "", rdr[12] + "", rdr[13] + "", rdr[14] + "", rdr[15] + "", rdr[16] + "" });
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public string ObtenerFechaVenta(string idVenta)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerFechaVenta", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idVenta", idVenta));

            string res = "-1";
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

        public string AgregarFondoCaja(decimal fondoActual,decimal fondoSiguienteTurno,string idCaja, string idUsuario, bool esInicioTurno)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AgregarFondoCaja", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@fondoActual", fondoActual));
            cmd.Parameters.Add(new SqlParameter("@fondoSiguienteTurno", fondoSiguienteTurno));
            cmd.Parameters.Add(new SqlParameter("@idCaja", idCaja));
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
            cmd.Parameters.Add(new SqlParameter("@esInicioTurno", esInicioTurno));

            string res = "-1";
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

        public decimal ObtenerDineroEnCaja(string idTurno)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerDineroEnCaja", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTurno", idTurno));
            
            decimal res = 0m;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = decimal.Parse(rdr[0] + "");


                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public int ActualizarUsuarioTurno(string idCaja,string idUsuario)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ActualizarUsuarioTurno", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idCaja", idCaja));
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));

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

            ob.CerrarConexionBD();
            return res;
        }

        public ValleVerdeComun.Programacion.Huellas.ResultadoHuella ObtenerUsuarioTurno(string idCaja)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerUsuarioTurno", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idCaja", idCaja));

            ValleVerdeComun.Programacion.Huellas.ResultadoHuella res = null;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = new ValleVerdeComun.Programacion.Huellas.ResultadoHuella(rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", Convert.ToBoolean( rdr[4] + ""));


                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public ValleVerdeComun.Programacion.Huellas.ResultadoHuella ObtenerUsuarioConID(string idUsuario)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerUsuarioConID", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idUsuario", @idUsuario));

            ValleVerdeComun.Programacion.Huellas.ResultadoHuella res = null;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = new ValleVerdeComun.Programacion.Huellas.ResultadoHuella(rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", Convert.ToBoolean(rdr[4] + ""));


                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public int ActualizarVentaGastoParaTienda(string idVenta,bool esGastoParaVenta)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ActualizarVentaGastoParaTienda", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idVenta", idVenta));
            cmd.Parameters.Add(new SqlParameter("@esGastoParaVenta", esGastoParaVenta));

            int res = -1;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = int.Parse(rdr[0] + "");
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public string ObtenerIDTurnoCaja(string idCaja)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerIDTurnoCaja", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idCaja", idCaja));

            string res = "-1";
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

        public int RegistrarEntradaSalida(string idTurno,decimal monto,string motivo,bool esEntrada)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("RegistrarEntradaSalida", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTurno", idTurno));
            cmd.Parameters.Add(new SqlParameter("@monto", monto));
            cmd.Parameters.Add(new SqlParameter("@motivo", motivo));
            cmd.Parameters.Add(new SqlParameter("@esEntrada", esEntrada));

            int res = -1;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = int.Parse(rdr[0] + "");
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public string[] AgregarAbonosCredito(string IDCliente, decimal abono, string IDUsuario, string IDTurno)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AgregarAbonosCredito", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@IDCliente", IDCliente));
            cmd.Parameters.Add(new SqlParameter("@formapago", ""));
            cmd.Parameters.Add(new SqlParameter("@abono", abono));
            cmd.Parameters.Add(new SqlParameter("@idVenta", -1));
            cmd.Parameters.Add(new SqlParameter("@IDUsuario", @IDUsuario));
            cmd.Parameters.Add(new SqlParameter("@idTurno", IDTurno));


            string[] res = null;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = new string[] { rdr[0] + "" , rdr[1] + "" , rdr[2] + "" };
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public decimal ObtenerComision(string sku)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerComision", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@sku", sku));

            decimal res = 0m;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = decimal.Parse(rdr[0] + "");


                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public int AsignarClienteVenta(string idVenta, string idCliente)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AsignarClienteVenta", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idVenta", idVenta));
            cmd.Parameters.Add(new SqlParameter("@idCliente", idCliente));

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

            ob.CerrarConexionBD();
            return res;
        }

        public int AsignarFacturaVenta(string idVenta, string idFactura)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AsignarFacturaVenta", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idVenta", idVenta));
            cmd.Parameters.Add(new SqlParameter("@idFactura", idFactura));

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

            ob.CerrarConexionBD();
            return res;
        }

        public int CrearPedidoCaja(string idCaja, string idProducto, decimal cantidad)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("CrearPedidoCaja", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@IDCaja", idCaja));
            cmd.Parameters.Add(new SqlParameter("@IDProducto", idProducto));
            cmd.Parameters.Add(new SqlParameter("@Cantidad", cantidad));

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
    }
}
