using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Windows.Forms;
using ValleVerde.Vistas.Compras;

namespace ValleVerde.Programacion.Compra
{
    class Compras
    {
        ValleVerdeComun.ConexionBD obj = new ValleVerdeComun.ConexionBD();

        public List<String[]> ObtenerCompras(int verCompras, int opcion, int numeroPagina, string buscar, string idproveedor, DateTime dateI, DateTime dateF)
        {
            obj.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("ObtenerCompras", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vercompras", SqlDbType.Int).Value = verCompras;
            cmd.Parameters.AddWithValue("@opcion", SqlDbType.Int).Value = opcion;
            cmd.Parameters.AddWithValue("@numeroPagina", SqlDbType.Int).Value = numeroPagina;
            cmd.Parameters.AddWithValue("@buscar", SqlDbType.NVarChar).Value = buscar;
            cmd.Parameters.AddWithValue("@idproveedor", SqlDbType.BigInt).Value = idproveedor;
            cmd.Parameters.AddWithValue("@fechaI", SqlDbType.Date).Value = dateI;
            cmd.Parameters.AddWithValue("@fechaF", SqlDbType.Date).Value = dateF;
            SqlDataReader rdr = cmd.ExecuteReader();
            List<String[]> res = new List<string[]>();
            
            while (rdr.Read())
            {
                res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + "", rdr[6] + "", rdr[7] + "", rdr[8] + "", 
                    rdr[9] + "", rdr[10] + "", rdr[11] + "", rdr[12] + "", rdr[13] + "", rdr[14] + "", rdr[15] + "",rdr[16]+""});
            }

            obj.CerrarConexionBD();

            return res;
        }

        internal List<object[]> ObtenerDevolucionCompraEntrantes(long idDevComSal)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerDevolucionCompraEntrantes", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idDevComSal", idDevComSal));

            SqlDataReader rdr = cmd.ExecuteReader();

            List<object[]> res = new List<object[]>();

            while (rdr.Read())
            {
                res.Add(new object[] { rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7] });
            }

            obj.CerrarConexionBD();

            return res;
        }

        internal void EliminarDevolucionCompra(long idDevCom)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("EliminarDevolucionCompra", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idDevCom", idDevCom));

            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal void RelacionarDevolucionesCompraPedido(long idPed)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("RelacionarDevolucionesCompraPedido", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idPed", idPed));
            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal void ActualizarProductoDevolucionSalida(long idDevComSal, decimal can, string mot)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ActualizarProductoDevolucionSalida", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idDevComSal", idDevComSal));
            cmd.Parameters.Add(new SqlParameter("@can", can));
            cmd.Parameters.Add(new SqlParameter("@mot", mot));
            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal List<object[]> ObtenerTipoDevolucionCompra()
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SELECT IDTipoDevolucionCompra, Descripcion FROM TipoDevolucionCompra", obj.ObtenerConexion());
            cmd.CommandType = CommandType.Text;

            SqlDataReader rdr = cmd.ExecuteReader();

            List<object[]> res = new List<object[]>();

            while (rdr.Read())
                res.Add(new object[] { rdr[0], rdr[1] });

            obj.CerrarConexionBD();

            return res;
        }

        internal void EliminarProductoDevolucionCompra(long idDevComSal)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("EliminarDevolucionCompraSaliente", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idDevComSal", idDevComSal));

            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal void ConfirmarDevolucionCompra(long idProv)
        {
            obj.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("ConfirmarDevolucionCompra", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProv", idProv));

            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal long CrearDevolucion(long idProv)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("CrearDevolucionCompra", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProv", idProv));

            SqlDataReader rdr = cmd.ExecuteReader();

            long res = new long();

            while (rdr.Read())
                res = long.Parse(rdr[0] + "");

            obj.CerrarConexionBD();

            return res;
        }

        internal List<object[]> ObtenerProveedoresDevolucion()
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerProveedoresDevolucion", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = cmd.ExecuteReader();

            List<object[]> res = new List<object[]>();

            while (rdr.Read())
                res.Add(new object[] { rdr[0], rdr[1] });

            obj.CerrarConexionBD();

            return res;
        }

        internal string ObtenerDescripcionProducto(string idProd)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SELECT Nombre FROM Producto WHERE IDProducto = '" + idProd + "'", obj.ObtenerConexion());
            cmd.CommandType = CommandType.Text;

            SqlDataReader rdr = cmd.ExecuteReader();
            string res = "";
            while (rdr.Read())
            {
                res = rdr[0] + "";
            }

            obj.CerrarConexionBD();

            return res;
        }

        internal long AgregarProductoAPedido(long idPed, string idProd, string idClaAdi, decimal can, decimal uniPorCaj, bool altCom, long idProdPen)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("AgregarProductoAPedido", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idPed", idPed));
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));
            cmd.Parameters.Add(new SqlParameter("@idClaAdi", idClaAdi));
            cmd.Parameters.Add(new SqlParameter("@can", can));
            cmd.Parameters.Add(new SqlParameter("@uniPorCaj", uniPorCaj));
            cmd.Parameters.Add(new SqlParameter("@altCom", altCom));
            cmd.Parameters.Add(new SqlParameter("@idProdPen", idProdPen));

            SqlDataReader rdr = cmd.ExecuteReader();
            long res = new long();
            while (rdr.Read())
            {
                res = long.Parse(rdr[0] + "");
            }

            obj.CerrarConexionBD();

            return res;
        }

        public List<object[]> ObtenerFacturas(long idCompra)
        {
            obj.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("ObtenerFacturas", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idcompra", SqlDbType.BigInt).Value = idCompra;
            SqlDataReader rdr = cmd.ExecuteReader();
            List<object[]> res = new List<object[]>();
            while (rdr.Read())
            {
                res.Add(new object[] { rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9] });
            }

            obj.CerrarConexionBD();

            return res;
        }

        public List<object[]> ObtenerProductosFactura(string idfactura)
        {
            obj.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("ObtenerProductosFactura", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idFac", SqlDbType.BigInt).Value = idfactura;
            SqlDataReader rdr = cmd.ExecuteReader();
            List<object[]> res = new List<object[]>();
            while (rdr.Read())
            {
                res.Add(new object[] { rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9] });
            }

            obj.CerrarConexionBD();

            return res;
        }

        internal long AgregarSalidaDevolucionCompra(long idProv, string idProd, long idPed)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("AgregarSalidaDevolucionCompra", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProv", idProv));
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));
            cmd.Parameters.Add(new SqlParameter("@idPed", idPed));
            SqlDataReader rdr = cmd.ExecuteReader();

            long res = new long();

            while (rdr.Read())
            {
                res = long.Parse(rdr[0] + "");
            }

            obj.CerrarConexionBD();

            return res;
        }

        internal long AgregarEntradaDevolucionCompra(long idDevComSal, long idTipDev, long idPed, string idProd, decimal can, decimal cos)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("AgregarEntradaDevolucionCompra", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idDevComSal", idDevComSal));
            cmd.Parameters.Add(new SqlParameter("@idTipDev", idTipDev));
            cmd.Parameters.Add(new SqlParameter("@idPed", idPed));
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));
            cmd.Parameters.Add(new SqlParameter("@can", can));
            cmd.Parameters.Add(new SqlParameter("@cos", cos));
            //cmd.Parameters.Add(new SqlParameter("@conf", conf));
            SqlDataReader rdr = cmd.ExecuteReader();

            long res = new long();

            while (rdr.Read())
            {
                res = long.Parse(rdr[0] + "");
            }

            obj.CerrarConexionBD();

            return res;
        }

        internal List<object[]> ObtenerProductosDevolucionPedido(long idPed)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerProductosDevolucionPedido", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idPed", idPed));

            SqlDataReader rdr = cmd.ExecuteReader();

            List<object[]> res = new List<object[]>();

            while (rdr.Read())
                res.Add(new object[] { rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11] });

            obj.CerrarConexionBD();

            return res;
        }

        internal void AutorizarProductosCotizacion()
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("AutorizarProductosCotizacion", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal void ActualizarProductoNoAutorizado(long idProdEspCot, bool sel)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ActualizarProductoNoAutorizado", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProdEspCot", idProdEspCot));
            cmd.Parameters.Add(new SqlParameter("@sel", sel));

            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal List<object[]> ObtenerDescuentosExtra(long idFac)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerDescuentosExtra", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idFac", idFac));

            SqlDataReader rdr = cmd.ExecuteReader();

            List<object[]> res = new List<object[]>();

            while (rdr.Read())
                res.Add(new object[] { rdr[0], rdr[1], rdr[2], rdr[3], rdr[4] });

            obj.CerrarConexionBD();

            return res;
        }

        internal void EliminarProductoEscaneadoPedido(long idProdPed)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("EliminarProductoEscaneadoPedido", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProdPed", idProdPed));
            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal long AgregarDescuentoExtraFacturaPendiente(long idFac, string idProd)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("AgregarDescuentoExtraFacturaPendiente", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idFac", idFac));
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));
            SqlDataReader rdr = cmd.ExecuteReader();

            long res = new long();

            while (rdr.Read())
                res = (long)rdr[0];

            obj.CerrarConexionBD();

            return res;
        }

        internal List<object[]> ObtenerDatosProductoPedido(long idPed, string codBar, bool prodFuePed)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerDatosProductoPedido", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idPed", idPed));
            cmd.Parameters.Add(new SqlParameter("@codBar", codBar));
            cmd.Parameters.Add(new SqlParameter("@prodFuePed", prodFuePed));
            SqlDataReader rdr = cmd.ExecuteReader();

            List<object[]> res = new List<object[]>();

            while (rdr.Read())
            {
                res.Add(new object[] { rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10] });
            }

            obj.CerrarConexionBD();

            return res;
        }

        internal List<object[]> ObtenerDevolucionCompraSalientes(long idProv, long idDevComSal, long idPed, bool conf, bool devDenCom)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerDevolucionCompraSalientes", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProv", idProv));
            cmd.Parameters.Add(new SqlParameter("@idDevComSal", idDevComSal));
            cmd.Parameters.Add(new SqlParameter("@idPed", idPed));
            cmd.Parameters.Add(new SqlParameter("@conf", conf));
            cmd.Parameters.Add(new SqlParameter("@devDenCom", devDenCom));
            SqlDataReader rdr = cmd.ExecuteReader();

            List<object[]> res = new List<object[]>();

            while (rdr.Read())
                res.Add(new object[] { rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12] });

            obj.CerrarConexionBD();

            return res;
        }

        internal void ActualizarDescuentoGeneralFactura(long idFac, decimal? des)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ActualizarDescuentoGeneralFactura", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idFac", idFac));
            if (des == null)
                cmd.Parameters.Add(new SqlParameter("@des", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@des", des));
            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal void ActualizarEsPorcentajePedido(long idPed, bool? esPor)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ActualizarEsPorcentajePedido", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idPed", idPed));
            if(esPor == null)
                cmd.Parameters.Add(new SqlParameter("@esPor", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@esPor", esPor));
            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal void EliminarDescuentoExtra(long idDesExt)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("EliminarDescuentoExtra", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idDesExt", idDesExt));
            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal void ActualizarFolioFactura(long idFac, string fol)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ActualizarFolioFactura", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idFac", idFac));
            cmd.Parameters.Add(new SqlParameter("@fol", fol));
            SqlDataReader rdr = cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal void ActualizarEsFactura(long idFac, CheckBox esFac)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = null;
            if (esFac.Checked)
                cmd = new SqlCommand("UPDATE Factura SET EsFactura =" + 1 + " WHERE IDFactura =" + idFac, obj.ObtenerConexion());
            else
                cmd = new SqlCommand("UPDATE Factura SET EsFactura =" + 0 + " WHERE IDFactura =" + idFac, obj.ObtenerConexion());
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal List<string[]> ObtenerAlmacenes()
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerAlmacenes", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> res = new List<string[]>();

            while (rdr.Read())
                res.Add(new string[] { rdr[0] + "", rdr[1] + "" });
            
            obj.CerrarConexionBD();

            return res;
        }

        internal void EliminarPedidosVacios()
        {
            obj.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("EliminarPedidosVacios", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal void EliminarFacturasPendientesVacias(long idPed)
        {
            obj.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("EliminarFacturasPendientesVacias", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idPed", idPed));
            
            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal void ActualizarDescuentosAntesImpuestos(long idPed, bool? desAntImp)
        {
            obj.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("ActualizarDescuentosAntesImpuestos", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idPed", idPed));
            if(desAntImp == null)
                cmd.Parameters.Add(new SqlParameter("@desAntImp", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@desAntImp", desAntImp));
            
            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal void ActualizarCantidadDescuentoExtra(long idDesExt, decimal can)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ActualizarCantidadDescuentoExtra", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idDesExt", idDesExt));
            cmd.Parameters.Add(new SqlParameter("@can", can));
            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }


        internal void EliminarFacturaPendiente(long idFac)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("EliminarFacturaPendiente", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idFac", idFac));
            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal void ActualizarCostosIncluyenImpuestosFacturaCompra(long idPed, bool cosIncImp)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ActualizarCostosIncluyenImpuestosFacturaCompra", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idPed", idPed));
            cmd.Parameters.Add(new SqlParameter("@cosIncImp", cosIncImp));
            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal void ActualizarMotivoDescuentoExtra(long idDesExt, string mot)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ActualizarMotivoDescuentoExtra", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idDesExt", idDesExt));
            cmd.Parameters.Add(new SqlParameter("@mot", mot));
            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal void ActualizarDescuentoProductoFacturaPendiente(long idProdPed, decimal? can)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ActualizarDescuentoProductoFacturaPendiente", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProdPed", idProdPed));
            if(can == null)
                cmd.Parameters.Add(new SqlParameter("@can", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@can", can));
            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal long AgregarProductoFacturaPendiente(long idFac, long idPed, string idProd, string idClaAdi, decimal canRec, decimal impo, decimal canDes, bool prodFuePed, long idProdPen)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("AgregarProductoFacturaPendiente", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idFac", idFac));
            cmd.Parameters.Add(new SqlParameter("@idPed", idPed));
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));
            cmd.Parameters.Add(new SqlParameter("@idClaAdi", idClaAdi));
            cmd.Parameters.Add(new SqlParameter("@canRec", canRec));
            cmd.Parameters.Add(new SqlParameter("@impo", impo));
            cmd.Parameters.Add(new SqlParameter("@canDes", canDes));
            cmd.Parameters.Add(new SqlParameter("@prodFuePed", prodFuePed));
            cmd.Parameters.Add(new SqlParameter("@idProdPen", idProdPen));

            SqlDataReader rdr = cmd.ExecuteReader();

            long res = new long();

            while (rdr.Read())
                res = (long)rdr[0];

            obj.CerrarConexionBD();

            return res;
        }

        internal void ActualizarImporteProductoFacturaCompra(long idProdPed, decimal impo)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ActualizarImporteProductoFacturaCompra", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProdPed", idProdPed));
            cmd.Parameters.Add(new SqlParameter("@impo", impo));
            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal void CambiarIndicesProductoFacturas(long idProdPed, short ind)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("CambiarIndicesProductoFacturas", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProducto_pedido", idProdPed));
            cmd.Parameters.Add(new SqlParameter("@indicenuevo", ind));
            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal void ActualizarCantidadProductoFacturaPendiente(long idProdPed, decimal canRec)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ActualizarCantidadProductoFacturaPendiente", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProdPed", idProdPed));
            cmd.Parameters.Add(new SqlParameter("@canRec", canRec));
            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal void ActualizarCostoProductoFacturaPendiente(long idProdPed, decimal cosRec)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ActualizarCostoProductoFacturaPendiente", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProdPed", idProdPed));
            cmd.Parameters.Add(new SqlParameter("@cosRec", cosRec));
            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal List<String[]> ObtenerTodosProductosCotizacionesRecibidas()
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerTodosProductosCotizacionesRecibidas", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> res = new List<string[]>();

            while (rdr.Read())
                res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + "", rdr[6] + "", rdr[7] + "" });
            obj.CerrarConexionBD();

            return res;
        }

        internal void EliminarProductoCotizacionRecibida(long idCot, string idClaAdi, string idProd)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("EliminarProductoCotizacionRecibida", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idCot", idCot));
            cmd.Parameters.Add(new SqlParameter("@idClaAdi", idClaAdi));
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));
            SqlDataReader rdr = cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal long CrearFacturaPendiente(long idPed)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("CrearFacturaPendiente", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idPed", idPed));
            SqlDataReader rdr = cmd.ExecuteReader();

            long res = new long();

            while (rdr.Read())
                res = long.Parse(rdr[0] + "");

            obj.CerrarConexionBD();

            return res;
        }

        public List<object[]> ObtenerProveedoresPedidos()
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerProveedoresPedidos", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = cmd.ExecuteReader();

            List<object[]> res = new List<object[]>();

            while (rdr.Read())
            {
                res.Add(new object[] { rdr[0], rdr[1], rdr[2], rdr[3], rdr[4] });
            }

            obj.CerrarConexionBD();

            return res;
        }

        internal List<string[]> ObtenerProductosCotizacionRecibida(long idCot)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerProductosCotizacionRecibida", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idCot", idCot));
            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> res = new List<string[]>();

            while (rdr.Read())
                res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + "" });

            obj.CerrarConexionBD();

            return res;
        }

        internal void MarcarMejorPrecio(long idCot)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("UPDATE Cotizacion SET MejorPrecio = 1 WHERE IDCotizacion = " + idCot, obj.ObtenerConexion());
            cmd.CommandType = CommandType.Text;

            SqlDataReader rdr = cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        public List<object[]> ObtenerProductosPedido(long idPed)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerProductosPedido", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idPed", idPed));
            SqlDataReader rdr = cmd.ExecuteReader();

            List<object[]> res = new List<object[]>();

            while (rdr.Read())
                res.Add(new object[] { rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13] });

            obj.CerrarConexionBD();

            return res;
        }

        internal void ActualizarNuevoCosto(long idProdPed, decimal nueCos)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ActualizarNuevoCosto", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProdPed", idProdPed));
            cmd.Parameters.Add(new SqlParameter("@nueCos", nueCos));
            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal void ActualizarCantidadDevueltaFacturaCompra(long idProdPed, decimal canDev)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ActualizarCantidadDevueltaFacturaCompra", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProdPed", idProdPed));
            cmd.Parameters.Add(new SqlParameter("@canDev", canDev));
            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        public List<String[]> ObtenerCompraDatos(long idCom)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerCompraDatos", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idCom", idCom));
            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> res = new List<string[]>();

            while (rdr.Read())
            {
                if(rdr[0]+""!="-1")
                    res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + "", rdr[6] + "", rdr[7] + "", rdr[8] + "", rdr[9] + "", rdr[10] + "", rdr[11] + "", rdr[12] + "" });
            }

            if (res.Count == 0)
            {
                res.Clear();
                res.Add(new string[] { "-1" });
            }

            obj.CerrarConexionBD();

            return res;
        }

        internal void ActualizarMotivoDevolucionFacturaCompra(long idProdPed, string motDev)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ActualizarMotivoDevolucionFacturaCompra", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProdPed", idProdPed));
            cmd.Parameters.Add(new SqlParameter("@motDev", motDev));

            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal string ObtenerNombreProveedor(long idProv)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SELECT Nombre FROM Proveedor WHERE IDProveedor = " + idProv, obj.ObtenerConexion());
            cmd.CommandType = CommandType.Text;

            SqlDataReader rdr = cmd.ExecuteReader();

            String res = "";

            while (rdr.Read())
                res = rdr[0] + "";

            obj.CerrarConexionBD();

            return res;
        }

        internal string[] ExisteProductoConClaveAdicional(string codBar)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ExisteProductoConCodigo", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Cod", codBar));
            cmd.Parameters.Add(new SqlParameter("@idAlmacen", -1));
            cmd.Parameters.Add(new SqlParameter("@debeCoincidirExactamente", true));

            SqlDataReader rdr = cmd.ExecuteReader();

            String[] res = null;

            while (rdr.Read())
                res = new string[] { rdr[0].ToString(), rdr[1].ToString() };

            obj.CerrarConexionBD();

            return res;
        }

        internal List<object[]> ObtenerMarcas()
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerMarcas", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = cmd.ExecuteReader();

            List<object[]> res = new List<object[]>();

            while (rdr.Read())
                res.Add(new object[] { rdr[0], rdr[1] });

            obj.CerrarConexionBD();

            return res;
        }

        internal List<object[]> ObtenerProductosFacturaPendiente(long idFac)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerProductosFacturaPendiente", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idFac", idFac));

            SqlDataReader rdr = cmd.ExecuteReader();

            //List<DatosProductoPedido> res = new List<DatosProductoPedido>();
            List<object[]> res2 = new List<object[]>();
            while (rdr.Read())
                //res.Add(new DatosProductoPedido("", "", rdr[0].ToString(), rdr[1].ToString(), rdr[5].ToString(), rdr[6].ToString(), rdr[11].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[7].ToString(), rdr[8].ToString(), rdr[9].ToString(), rdr[14].ToString(), rdr[12].ToString(), rdr[13].ToString(), "", rdr[15].ToString(), rdr[10].ToString(), rdr[16].ToString(), rdr[17].ToString(), ""));
                res2.Add(new object[] { rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23] });
            obj.CerrarConexionBD();

            return res2;
        }

        internal void ActualizarCostoProductoCotizacion(long idCot, string idClaAdi, string idProd, decimal cos)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ActualizarCostoProductoCotizacion", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idCot", idCot));
            cmd.Parameters.Add(new SqlParameter("@idClaAdi", idClaAdi));
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));
            cmd.Parameters.Add(new SqlParameter("@cos", cos));

            SqlDataReader rdr = cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal sbyte EliminarProductoFacturaPendiente(long idFac, string idProd, string idClaAdi, bool prodPed, short ind, bool eliPorFac)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("EliminarProductoFacturaPendiente", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("idFac", idFac));
            cmd.Parameters.Add(new SqlParameter("idProd", idProd));
            cmd.Parameters.Add(new SqlParameter("idClaAdi", idClaAdi));
            cmd.Parameters.Add(new SqlParameter("prodPed", prodPed));
            cmd.Parameters.Add(new SqlParameter("ind", ind));
            cmd.Parameters.Add(new SqlParameter("eliPorFac", eliPorFac));
            SqlDataReader rdr = cmd.ExecuteReader();

            sbyte res = 0;
            while (rdr.Read())
                res = sbyte.Parse(rdr[0].ToString());

            obj.CerrarConexionBD();

            return res;
        }

        internal List<object[]> ObtenerLineas()
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerLineas", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = cmd.ExecuteReader();

            List<object[]> res = new List<object[]>();

            while (rdr.Read())
                res.Add(new object[] { rdr[0], rdr[1] });

            obj.CerrarConexionBD();

            return res;
        }

        internal List<string[]> ObtenerProveedoresCotizacionesRecibidas()
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerProveedoresCotizacionesRecibidas", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = cmd.ExecuteReader();

            List<string[]> res = new List<string[]>();

            while (rdr.Read())
                res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "" });

            obj.CerrarConexionBD();

            return res;
        }

        internal List<object[]> ObtenerFabricantes()
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerFabricantes", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = cmd.ExecuteReader();

            List<object[]> res = new List<object[]>();

            while (rdr.Read())
                res.Add(new object[] { rdr[0], rdr[1] });

            obj.CerrarConexionBD();

            return res;
        }

        internal List<string[]> ObtenerFacturasPendientes(long idPed)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerFacturasPendientes", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idPed", idPed));

            SqlDataReader rdr = cmd.ExecuteReader();

            List<string[]> res = new List<string[]>();

            while (rdr.Read())
                res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "" });

            obj.CerrarConexionBD();

            return res;
        }

        internal List<object[]> ObtenerProveedores()
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerProveedores", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = cmd.ExecuteReader();

            List<object[]> res = new List<object[]>();

            while (rdr.Read())
                res.Add(new object[] { rdr[0], rdr[1] });

            obj.CerrarConexionBD();

            return res;
        }

        internal bool ExisteClaveAdicional(string codBar)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ExisteClaveAdicional", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idClaAdi", codBar));

            SqlDataReader rdr = cmd.ExecuteReader();

            bool res = false;

            while (rdr.Read())
                if (rdr[0].ToString().Equals("1"))
                    res = true;
                else
                    res = false;

            obj.CerrarConexionBD();

            return res;
        }

        public void EliminarProductoEnEsperaCotizacion(string idProd)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("EliminarProductoEnEsperaCotizacion", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));

            SqlDataReader rdr = cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        public List<string> ObtenerDatosPedido(long idPed)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerDatosPedido", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idPed", idPed));
            
            SqlDataReader rdr = cmd.ExecuteReader();

            List<String> res = new List<string>();

            while (rdr.Read())
            {
                res.Add(rdr[0] + "");
                res.Add(rdr[1] + "");
                res.Add(rdr[2] + "");
                res.Add(rdr[3] + "");
                res.Add(rdr[4] + "");
                res.Add(rdr[5] + "");
            }

            obj.CerrarConexionBD();

            return res;
        }

        internal List<string[]> ObtenerProductosSugeridos(UInt16 tabPagInd, long idCat, Int16 diaCub)
        {
            String nomPar = "";

            obj.AbrirConexionBD();

            SqlCommand cmd = null;
            
            switch (tabPagInd)
            {
                case 0:
                    cmd = new SqlCommand("ObtenerProductosSugeridosMarca", obj.ObtenerConexion());
                    nomPar = "@idMar";
                    break;
                case 1:
                    cmd = new SqlCommand("ObtenerProductosSugeridosLinea", obj.ObtenerConexion());
                    nomPar = "@idLin";
                    break;
                case 2:
                    cmd = new SqlCommand("ObtenerProductosSugeridosFabricante", obj.ObtenerConexion());
                    nomPar = "@idFab";
                    break;
                case 3:
                    cmd = new SqlCommand("ObtenerProductosSugeridosProveedor", obj.ObtenerConexion());
                    nomPar = "@idProv";
                    break;
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter(nomPar, idCat));
            cmd.Parameters.Add(new SqlParameter("@diaCub", diaCub));
            cmd.Parameters.Add(new SqlParameter("@fecIni", DateTime.Today.AddYears(-1)));
            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> res = new List<string[]>();

            while (rdr.Read())
                res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + "" });

            obj.CerrarConexionBD();

            return res;
        }

        internal sbyte ModificarProductoEnEsperaCotizacion(string idProd, string idClaAdi, byte tipCot, byte valCam, short canCaj, decimal canUni, bool cotPor, short diaCub, long idUsu)
        {
            obj.AbrirConexionBD();

            SqlCommand cmd = null;

            cmd = new SqlCommand("ModificarProductoEnEsperaCotizacion", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));
            cmd.Parameters.Add(new SqlParameter("@tipCot", tipCot));
            cmd.Parameters.Add(new SqlParameter("@valCam", valCam));
            cmd.Parameters.Add(new SqlParameter("@canCaj", canCaj));
            cmd.Parameters.Add(new SqlParameter("@canUni", canUni));
            cmd.Parameters.Add(new SqlParameter("@cotPor", cotPor));
            cmd.Parameters.Add(new SqlParameter("@diaCub", diaCub));
            cmd.Parameters.Add(new SqlParameter("@idUsu", idUsu));

            SqlDataReader rdr = cmd.ExecuteReader();

            sbyte res = 0;

            while (rdr.Read())
                res = sbyte.Parse(rdr[0] + "");

            obj.CerrarConexionBD();

            return res;
        }

        public void EliminarProductoMejorPrecio(string idProd)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("EliminarProductoMejorPrecio", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));

            SqlDataReader rdr = cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal object[] GenerarCompra(long idPed, long idAlm)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("GenerarCompra", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idPed", idPed));
            cmd.Parameters.Add(new SqlParameter("@idAlm", idAlm));

            SqlDataReader rdr = cmd.ExecuteReader();

            object[] res = new object[2];

            while (rdr.Read())
            {
                res[0] = rdr[0];
                res[1] = rdr[1];
            }

            obj.CerrarConexionBD();

            return res;
        }

        public void ActualizarProductoMejorPrecio(string idProd, double nueCan)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ActualizarProductoMejorPrecio", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));
            cmd.Parameters.Add(new SqlParameter("@nueCan", nueCan));

            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal decimal ObtenerCostoProducto(string idProd)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerCostoProducto", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));

            SqlDataReader rdr = cmd.ExecuteReader();

            decimal res = new decimal();

            while (rdr.Read())
            {
                string s = rdr[0].ToString();
                res = decimal.Parse(s);
            }

            obj.CerrarConexionBD();

            return res;
        }

        internal decimal CostoPromedioProductoMasCantidadRecibir(string idProd, decimal canRec, decimal cosRec)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerCostoPromedioProductoMasCantidadRecibir", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));
            cmd.Parameters.Add(new SqlParameter("@canRec", canRec));
            cmd.Parameters.Add(new SqlParameter("@cosRec", cosRec));

            SqlDataReader rdr = cmd.ExecuteReader();

            decimal res = new decimal();

            while (rdr.Read())
                res = (decimal)rdr[0];

            obj.CerrarConexionBD();

            return res;
        }

        public List<string[]> ObtenerProductosMejoresPrecios(long idCot)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerProductosMejoresPrecios", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idCot", idCot));

            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> res = new List<string[]>();

            while (rdr.Read())
                res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + "", rdr[6] + "", rdr[7] + "" } );

            obj.CerrarConexionBD();

            return res;
        }

        public long GenerarPedido(long idCot, long idProv, double sub, double imp, double tot)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("GenerarPedido", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idCot", idCot));
            cmd.Parameters.Add(new SqlParameter("@idProv", idProv));
            cmd.Parameters.Add(new SqlParameter("@sub", sub));
            cmd.Parameters.Add(new SqlParameter("@imp", imp));
            cmd.Parameters.Add(new SqlParameter("@tot", tot));

            SqlDataReader rdr = cmd.ExecuteReader();

            long idPed = 0;

            while (rdr.Read())
            {
                idPed = long.Parse(rdr[0] + "");
            }

            obj.CerrarConexionBD();

            return idPed;
        }

        public void AgregarProductoPedido(long idPed, long idCot, string idProd, bool esCaj)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("AgregarProductoPedido", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idPed", idPed));
            cmd.Parameters.Add(new SqlParameter("@idCot", idCot));
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));
            cmd.Parameters.Add(new SqlParameter("@esCaj", esCaj));

            SqlDataReader rdr = cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        public void EliminarCotizacion(long idProv)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("EliminarProveedorMejoresPrecios", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProv", idProv));

            SqlDataReader rdr = cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        public List<string[]> ObtenerProveedoresMejoresPrecios()
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerProveedoresMejoresPrecios", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = cmd.ExecuteReader();

            List<string[]> res = new List<string[]>();

            while (rdr.Read())
            {
                res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "" });

                //idProv = rdr[0] + "";

                //if(res.Any())
                //{
                //    if (!res[res.Count - 1][0].Equals(idProv))
                //        res.Add(new string[] { rdr[0] + "", rdr[1] +"", rdr[2] + "" });
                //}
                //else
                //    res.Add(new string[] { idProv, rdr[1] + "", rdr[2] + "" });
            }

            obj.CerrarConexionBD();

            return res;
        }

        internal sbyte CodigoEsCajaOProducto(string cod)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("CodigoEsCajaOProducto", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@cod", cod));
            SqlDataReader rdr = cmd.ExecuteReader();

            sbyte res = new sbyte();

            while (rdr.Read())
            {
                res = sbyte.Parse(rdr[0] + "");
            }

            obj.CerrarConexionBD();

            return res;
        }

        internal void ActualizarTotalesFactura(long idFac, decimal sub, decimal imp, decimal tot, decimal descu, decimal dev, decimal totAPag)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ActualizarTotalesFactura", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idFac", idFac));
            cmd.Parameters.Add(new SqlParameter("@sub", sub));
            cmd.Parameters.Add(new SqlParameter("@imp", imp));
            cmd.Parameters.Add(new SqlParameter("@tot", tot));
            cmd.Parameters.Add(new SqlParameter("@descu", descu));
            cmd.Parameters.Add(new SqlParameter("@dev", dev));
            cmd.Parameters.Add(new SqlParameter("@totAPag", totAPag));
            SqlDataReader rdr = cmd.ExecuteReader();
            
            obj.CerrarConexionBD();
        }

        public List<string[]> ObtenerCompraProductos(long idCom)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerCompraProductos", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idCom", idCom));
            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> res = new List<string[]>();

            while (rdr.Read())
            {
                res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "" });
            }

            obj.CerrarConexionBD();

            return res;
        }

        internal bool ExisteProductoEnEsperaCotizacion(string codBar)
        {
            throw new NotImplementedException();
        }

        public void ModificarProductoCotizacionSolicitud(string idPro, short nueCan, bool enEsp)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ModificarProductoCotizacionSolicitud", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idPro", idPro));
            cmd.Parameters.Add(new SqlParameter("@nueCan", nueCan));
            cmd.Parameters.Add(new SqlParameter("@enEsp", enEsp));

            SqlDataReader rdr = cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        public List<String[]> ObtenerComprasIDsPorProveedor(long idPro)
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerComprasIDsPorProveedor", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idPro", idPro));
            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> res = new List<string[]>();

            while (rdr.Read())
            {
                res.Add(new string[] { rdr[0] + "" });
            }

            obj.CerrarConexionBD();

            return res;
        }

        public bool ExisteProductoMejorPrecio(string idProd)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ExisteProductoMejorPrecio", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));

            SqlDataReader rdr = cmd.ExecuteReader();

            bool exi = false;

            while (rdr.Read())
            {
                if (rdr[0].ToString().Equals("1"))
                    exi = true;
                else
                    exi = false;
            }

            obj.CerrarConexionBD();
            
            return exi;
        }

        public List<String[]> ObtenerComprasIDsPorFecha(DateTime fecIni, DateTime fecFin)
        {
            obj.AbrirConexionBD();
            fecFin = fecFin.AddDays(1);
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerComprasIDsPorFecha", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@fecIni", fecIni));
            cmd.Parameters.Add(new SqlParameter("@fecFin", fecFin));

            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> res = new List<string[]>();

            while (rdr.Read())
            {
                res.Add(new string[] { rdr[0] + "" });
            }

            obj.CerrarConexionBD();

            return res;
        }

        public List<string[]> ProductosEsperaSeparadosProveedor(long idProv)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerProductosEsperaSeparadosProveedor", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProv", idProv));

            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> res = new List<string[]>();

            while (rdr.Read())
            {
                res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "" });
            }

            obj.CerrarConexionBD();

            return res;
        }

        internal bool ExisteProducto(string codBar)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ExisteProducto", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProd", codBar));

            SqlDataReader rdr = cmd.ExecuteReader();

            bool res = new bool();

            while (rdr.Read())
                res = bool.Parse(rdr[0] + "");

            obj.CerrarConexionBD();

            return res;
        }

        internal void AgregarProductosCotizacion(string idProd, byte tipCot, long idCat, byte numCat, short diaCub, bool sobEsc, long idUsu)
        {
            obj.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("AgregarProductosACotizar", obj.ObtenerConexion());

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("idProd", idProd));
            cmd.Parameters.Add(new SqlParameter("tipCot", tipCot));
            cmd.Parameters.Add(new SqlParameter("idCat", idCat));
            cmd.Parameters.Add(new SqlParameter("numCat", numCat));
            cmd.Parameters.Add(new SqlParameter("diaCub", diaCub));
            cmd.Parameters.Add(new SqlParameter("sobEsc", sobEsc));
            cmd.Parameters.Add(new SqlParameter("idUsu", idUsu));
            cmd.CommandTimeout = 86400;
            
            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal List<object[]> ObtenerProductosACotizar(bool prodAut)
        {
            obj.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("ObtenerProductosACotizar", obj.ObtenerConexion());

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@esAdm", prodAut));
            cmd.CommandTimeout = 600;

            SqlDataReader rdr = cmd.ExecuteReader();

            List<object[]> res = new List<object[]>();

            while (rdr.Read())
                res.Add(new object[] { rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14] });

            obj.CerrarConexionBD();

            return res;
        }

        public List<string[]> ObtenerComprasIDsContado()
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerComprasIDsContado", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> res = new List<string[]>();

            while (rdr.Read())
            {
                res.Add(new string[] { rdr[0] + "" });
            }

            obj.CerrarConexionBD();

            return res;
        }

        internal List<string[]> ObtenerProveedoresPorProducto(string idProd)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerProveedoresProducto", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));

            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> res = new List<string[]>();

            while (rdr.Read())
                res.Add(new string[] { rdr[0] + "", rdr[1] + "" });

            obj.CerrarConexionBD();

            return res;
        }

        public List<string[]> ObtenerComprasIDsCredito()
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SELECT IDCompra FROM CreditoCompra", obj.ObtenerConexion());
            cmd.CommandType = CommandType.Text;

            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> res = new List<string[]>();

            while (rdr.Read())
            {
                res.Add(new string[] { rdr[0] + "" });
            }

            obj.CerrarConexionBD();

            return res;
        }

        public void AgregarProductoEsperaCotizacion(string idProdStr, string idClaAdiStr, long idUsu)
        {
            // short canCaj, decimal canUni, bool cotPorCaj, short diaCub
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("AgregarProductoEsperaCotizacion", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProd", idProdStr));
            cmd.Parameters.Add(new SqlParameter("@idClaAdi", idClaAdiStr));
            cmd.Parameters.Add(new SqlParameter("@idUsu", idUsu));

            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal bool ProveedorVendeProductoOCaja(long idProv, string codBar)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ProveedorVendeProductoOCaja", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProv", idProv));
            cmd.Parameters.Add(new SqlParameter("@codBar", codBar));
            //SqlParameter returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Bit);
            //returnParameter.Direction = ParameterDirection.ReturnValue;

            SqlDataReader rdr = cmd.ExecuteReader();

            bool res = new bool();

            while(rdr.Read())
            {
                res = bool.Parse(rdr[0] + "");
            }

            obj.CerrarConexionBD();

            return res;
        }

        internal List<string[]> ObtenerProveedoresCotizaciones()
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SELECT Cotizacion.IDCotizacion, Cotizacion.IDProveedor, Nombre FROM Cotizacion INNER JOIN Proveedor ON Cotizacion.IDProveedor = Proveedor.IDProveedor", obj.ObtenerConexion());
            cmd.CommandType = CommandType.Text;

            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> res = new List<string[]>();

            while (rdr.Read())
                res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "" });

            obj.CerrarConexionBD();

            return res;
        }

        internal List<string[]> ObtenerProductosCotizacionSeparados(long idCot)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerProductosCotizacionSeparados", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idCot", idCot));

            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> res = new List<string[]>();

            while (rdr.Read())
                res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + "", rdr[6] + "", rdr[7] + "" });
            
            obj.CerrarConexionBD();

            return res;
        }

        internal void SepararPorProveedor(bool remCan)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SepararPorProveedor", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@remCan", remCan));
            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        public List<string[]> ObtenerProductosEnEsperaCotizacion()
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerProductosEnEsperaCotizacion", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> res = new List<string[]>();

            while (rdr.Read())
                res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + "", rdr[6] + "", rdr[7] + "", rdr[8] + "", rdr[9] + "" });

            obj.CerrarConexionBD();

            return res;
        }

        public List<string[]> ObtenerProductosListaExcelSolicitud(long idLib)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerProductosListaExcelSolicitud", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idLib", idLib));

            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> pro = new List<String[]>();

            while (rdr.Read())
            {
                pro.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "" });
            }

            obj.CerrarConexionBD();

            return pro;
        }

        public void ActualizarCantidadCotizacionSolicitud(string idProd, int nueCan)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ActualizarCantidadCotizacionSolicitud", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));
            cmd.Parameters.Add(new SqlParameter("@nueCan", nueCan));

            SqlDataReader rdr = cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal void EliminarClaveAdicionalProductoCotizacion(long idCot, string idProd)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("EliminarClaveAdicionalProductoCotizacion", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idCot", idCot));
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));

            SqlDataReader rdr = cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        public void EliminarProductoCotizacionSolicitud(string idProd)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("EliminarProductoCotizacionSolicitud", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));

            SqlDataReader rdr = cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        public long RegistrarLibroExcel(long idProv, DateTime fecCre)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("RegistrarLibroExcel", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProv", idProv));
            cmd.Parameters.Add(new SqlParameter("@fecCre", fecCre));

            SqlDataReader rdr = cmd.ExecuteReader();

            long idLib = 0;

            while (rdr.Read())
            {
                idLib = long.Parse(rdr[0] + "");
            }

            obj.CerrarConexionBD();

            return idLib;
        }

        internal void ModificarLibroExcel(int v)
        {
            throw new NotImplementedException();
        }

        public void ProductosRegresarEspera()
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("UPDATE ProductoEsperaPedido SET EnEspera = 1;", obj.ObtenerConexion());
            cmd.CommandType = CommandType.Text;

            SqlDataReader rdr = cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        public void ProductosEliminarSinEspera()
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ProductosEliminarSinEspera", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        public int AgregarProductosListaExcelSolicitud(long idLib, List<string> ren)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("AgregarProductoListaExcelSolicitud", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idLib", idLib));
            cmd.Parameters.Add(new SqlParameter("@idProd", ren[0]));
            cmd.Parameters.Add(new SqlParameter("@can", ren[2]));

            SqlDataReader rdr = cmd.ExecuteReader();

            int res = 0;

            while (rdr.Read())
            {
                res = int.Parse(rdr[0] + "");
            }

            obj.CerrarConexionBD();

            return res;
        }

        public void ModificarProductoListaExcelSolicitud(String idProd)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ModificarProductoSinEspera", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));

            SqlDataReader rdr = cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        public long AgregarLibroExcelSolicitud(long idProv, string nomArc)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("AgregarLibroExcelSolicitud", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProv", idProv));
            cmd.Parameters.Add(new SqlParameter("@nomArc", nomArc));

            SqlDataReader rdr = cmd.ExecuteReader();

            long idLib = 0;

            while (rdr.Read())
            {
                idLib = int.Parse(rdr[0] + "");
            }

            obj.CerrarConexionBD();

            return idLib;
        }

        internal decimal ObtenerTotalDescuentosExtra(long idFac)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerTotalDescuentosExtra", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idFac", idFac));

            SqlDataReader rdr = cmd.ExecuteReader();

            decimal res = new decimal();

            while (rdr.Read())
            {
                res = decimal.Parse(rdr[0].ToString());
            }

            obj.CerrarConexionBD();

            return res;
        }

        public List<string[]> ObtenerListasExcelSolicitud()
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerListasExcelSolicitud", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> lib = new List<String[]>();

            while (rdr.Read())
            {
                lib.Add(new string[] { rdr[0] + "", rdr[1] + "" });
            }

            obj.CerrarConexionBD();

            return lib;
        }

        public long AgregarLibroExcelRecibido(string nomArc)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("AgregarLibroExcelSolicitud", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nomArc", nomArc));

            SqlDataReader rdr = cmd.ExecuteReader();

            long idLib = 0;

            while (rdr.Read())
            {
                idLib = int.Parse(rdr[0] + "");
            }

            obj.CerrarConexionBD();

            return idLib;
        }

        public void EliminarLibroExcelSolicitud(long idProv)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("EliminarLibroExcelSolicitud", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProv", idProv));

            SqlDataReader rdr = cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        public int AgregarProductoCotizacion(long idCot, string idProd, string idClaAdi)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("AgregarProductoCotizacion", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idCot", idCot));
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));
            cmd.Parameters.Add(new SqlParameter("@idClaAdi", idClaAdi));

            SqlDataReader rdr = cmd.ExecuteReader();

            int res = 0;

            while (rdr.Read())
            {
                res = int.Parse(rdr[0] + "");
            }

            obj.CerrarConexionBD();

            return res;
        }

        public int AgregarProductoMejorPrecio(List<string[]> mejPre)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("AgregarProductoMejorPrecio", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProd", mejPre[0][2]));
            cmd.Parameters.Add(new SqlParameter("@idProv", mejPre[0][0]));
            cmd.Parameters.Add(new SqlParameter("@can", mejPre[0][4]));
            cmd.Parameters.Add(new SqlParameter("@pre", mejPre[0][5]));

            SqlDataReader rdr = cmd.ExecuteReader();

            int res = 0;

            while (rdr.Read())
            {
                res = int.Parse(rdr[0] + "");
            }

            obj.CerrarConexionBD();

            return res;
        }

        internal List<string[]> ObtenerProductosUltimosMeses(int tabPagInd, long idCat)
        {
            String nomPar = "";

            obj.AbrirConexionBD();

            SqlCommand cmd = null;

            switch (tabPagInd)
            {
                case 0:
                    cmd = new SqlCommand("ObtenerProductosUltimosMesesMarca", obj.ObtenerConexion());
                    nomPar = "@idMar";
                    break;
                case 1:
                    cmd = new SqlCommand("ObtenerProductosUltimosMesesLinea", obj.ObtenerConexion());
                    nomPar = "@idLin";
                    break;
                case 2:
                    cmd = new SqlCommand("ObtenerProductosUltimosMesesFabricante", obj.ObtenerConexion());
                    nomPar = "@idFab";
                    break;
                case 3:
                    cmd = new SqlCommand("ObtenerProductosUltimosMesesProveedor", obj.ObtenerConexion());
                    nomPar = "@idProv";
                    break;
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter(nomPar, idCat));
            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> res = new List<string[]>();

            while (rdr.Read())
                res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + "" });

            obj.CerrarConexionBD();

            return res;
        }

        internal List<string[]> ObtenerProductosBajosInventario(int tabPagInd, long idCat)
        {
            String nomPar = "";

            obj.AbrirConexionBD();

            SqlCommand cmd = null;

            switch (tabPagInd)
            {
                case 0:
                    cmd = new SqlCommand("ObtenerProductosBajosInventarioMarca", obj.ObtenerConexion());
                    nomPar = "@idMar";
                    break;
                case 1:
                    cmd = new SqlCommand("ObtenerProductosBajosInventarioLinea", obj.ObtenerConexion());
                    nomPar = "@idLin";
                    break;
                case 2:
                    cmd = new SqlCommand("ObtenerProductosBajosInventarioFabricante", obj.ObtenerConexion());
                    nomPar = "@idFab";
                    break;
                case 3:
                    cmd = new SqlCommand("ObtenerProductosBajosInventarioProveedor", obj.ObtenerConexion());
                    nomPar = "@idProv";
                    break;
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter(nomPar, idCat));
            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> res = new List<string[]>();

            while (rdr.Read())
                res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[5] + "" });

            obj.CerrarConexionBD();

            return res;
        }

        internal int ObtenerUnidadesPorCaja(string idClaAdi)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerUnidadesPorCaja", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idClaAdi", idClaAdi));

            SqlDataReader rdr = cmd.ExecuteReader();

            int res = new int();

            while (rdr.Read())
                res = (int)rdr[0];

            obj.CerrarConexionBD();

            return res;
        }

        internal void ActualizarTotalesPedido(long idPed, decimal sub, decimal imp, decimal tot, decimal descu, decimal dev, decimal totAPag)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ActualizarTotalesPedido", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idPed", idPed));
            cmd.Parameters.Add(new SqlParameter("@sub", sub));
            cmd.Parameters.Add(new SqlParameter("@imp", imp));
            cmd.Parameters.Add(new SqlParameter("@tot", tot));
            cmd.Parameters.Add(new SqlParameter("@descu", descu));
            cmd.Parameters.Add(new SqlParameter("@dev", dev));
            cmd.Parameters.Add(new SqlParameter("@totAPag", totAPag));

            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal void MarcarExcelGenerado(long idCot)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("UPDATE Cotizacion SET ExcelGenerado = 1 WHERE IDCotizacion = " + idCot, obj.ObtenerConexion());
            cmd.CommandType = CommandType.Text;

            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }

        internal string ObtenerListaImpuestos(string idProd)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerListaImpuestos", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));

            SqlDataReader rdr = cmd.ExecuteReader();

            string res = "";

            while (rdr.Read())
                res = rdr[0] + "";

            obj.CerrarConexionBD();

            return res;
        }

        internal void MarcarAltaCompleta(long idProdPed, bool altCom)
        {
            obj.AbrirConexionBD();
            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("MarcarAltaCompleta", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProdPed", idProdPed));
            cmd.Parameters.Add(new SqlParameter("@altCom", altCom));
            SqlDataReader rdr = cmd.ExecuteReader();

            //string res = "";

            //while (rdr.Read())
            //    res = rdr[0] + "";

            obj.CerrarConexionBD();

            //return res;
        }

        internal List<object[]> ObtenerProductosPendientes(long idProv, long idPed)
        {
            obj.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("ObtenerProductosPendientes", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProv", idProv));
            cmd.Parameters.Add(new SqlParameter("@idPed", idPed));

            SqlDataReader rdr = cmd.ExecuteReader();

            List<object[]> res = new List<object[]>();

            while(rdr.Read())
            {
                res.Add(new object[] { rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11] });
            }

            obj.CerrarConexionBD();

            return res;
        }

        internal void MarcarProductoPendiente(long idProdPen, bool pen)
        {
            obj.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("MarcarProductoPendiente", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("idProdPen", idProdPen));
            cmd.Parameters.Add(new SqlParameter("pen", pen));

            cmd.ExecuteReader();

            obj.CerrarConexionBD();
        }
    }
}
