using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace ValleVerde.Programacion.Utileria
{
    //En esta clase la usamos para obtener los 3 mejores precios las 3 cantidades y el nombre del producto
    public class ProductoPrecioTop
    {
        //Iniciamos las variables que ocupamos
        public string nombreproducto;
        public decimal cantidad1;
        public decimal cantidad2;
        public decimal cantidad3;
        public decimal precio1;
        public decimal precio2;
        public decimal precio3;
        public decimal costoTarj1;
        public decimal costoTarj2;
        public decimal costoTarj3;
        public decimal preciotarj1;
        public decimal preciotarj2;
        public decimal preciotarj3;
        public decimal precioClaveAdicional;
        public decimal precioTarjClaveAdicional;
        public decimal costoTarjClaveAdicional;
        //El primer constructor recibe el id del producto
        public ProductoPrecioTop(string pnombrecodigo)
        {
            nombreproducto = pnombrecodigo;
        }
        //El segundo constructor recibe 4 parametros le añadimos el id producto para que no interfiera con el tercero
        //Reciben el top de cantidades que tiene el producto
        public ProductoPrecioTop(decimal pcantidad1, decimal pcantidad2, decimal pcantidad3, string variablenousable)
        {
            //nombrecodigo = pnombrecodigo;
            cantidad1 = pcantidad1;
            cantidad2 = pcantidad2;
            cantidad3 = pcantidad3;
        }
        //El tercer constructor recibe 3 parametros que son el precio de las cantidades de los productos
        public ProductoPrecioTop(decimal pprecio1, decimal pprecio2, decimal pprecio3)
        {
            precio1 = pprecio1;
            precio2 = pprecio2;
            precio3 = pprecio3;
        }
        public ProductoPrecioTop(decimal ppreciotarj1, decimal pcostotarj1, decimal ppreciotarj2, decimal pcostotarj2, decimal ppreciotarj3, decimal pcostotarj3)
        {
            preciotarj1 = ppreciotarj1;
            preciotarj2 = ppreciotarj2;
            preciotarj3 = ppreciotarj3;
            costoTarj1 = pcostotarj1;
            costoTarj2 = pcostotarj2;
            costoTarj3 = pcostotarj3;
        }

        public ProductoPrecioTop(decimal pprecioClaveAdicional, decimal pprecioTarjClaveAdicional, decimal pcostoTarjClaveAdicional, string variablenousable, string variablenousable1)
        {
            precioClaveAdicional = pprecioClaveAdicional;
            precioTarjClaveAdicional = pprecioTarjClaveAdicional;
            costoTarjClaveAdicional = pcostoTarjClaveAdicional;
        }
    }
    public class ObtenerProductoPrecioTop
    {
        //Instanciamos los 3 constructores y creamos 2 listas 
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();
        List<String> cantidades = new List<String>();
        List<String> precios = new List<String>();
        List<String> preciosTarj = new List<String>();
        ProductoPrecioTop cantidadProductoPrecioTop;
        ProductoPrecioTop precioProductoPrecioTop;
        ProductoPrecioTop precioProductoTarjeta;
        ProductoPrecioTop nombreproducto;
        ProductoPrecioTop precioClaveAdicional;
        
        //Este metodo devuelve la variable de cantidad de productos 
        public ProductoPrecioTop Obtenercantidadproductopreciotop(string productocodigo)
        {
            ob.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("ObtenerCantidadProductoTop", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idproducto", productocodigo));

            // execute the command
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                cantidades.Add(reader[0].ToString());
            }
            //Despues de ejecutar el procedimiento convertimos la lista en un array
            String[] array = cantidades.ToArray();
            //Le asignamos los valores del array a la variable instanciada del tercer constructor
            //El primer parametro recibe un string vacio por que no se necesita
            switch(array.Length)
            {
                case 1:
                    cantidadProductoPrecioTop = new ProductoPrecioTop(decimal.Parse(array[0].ToString()),
                    0, 0, "");
                    break;
                case 2:
                    cantidadProductoPrecioTop = new ProductoPrecioTop(decimal.Parse(array[0].ToString()),
                    decimal.Parse(array[1].ToString()), 0, "");
                    break;
                case 3:
                    cantidadProductoPrecioTop = new ProductoPrecioTop(decimal.Parse(array[0].ToString()),
                    decimal.Parse(array[1].ToString()), decimal.Parse(array[2].ToString()), "");
                    break;
            }
            ob.CerrarConexionBD();
            return cantidadProductoPrecioTop;
        }
        //Este metodo devuelve la variable de precios de productos 
        public ProductoPrecioTop Obtenerprecioproductopreciotop(string productocodigo)
        {
            //Comenzamos recorriendo la variable instancia del primero metodo en un foreach
            //Para saber cuantas cantidades hay y que se ejecute la cantidad de veces respecto de la variable
            foreach (var array in cantidades)
            {
                ob.AbrirConexionBD();
                SqlCommand cmd = new SqlCommand("ObtenerPrecioProducto", ob.ObtenerConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Cod", productocodigo));
                //Aqui pasamos la variable array respecto de cantidades 
                cmd.Parameters.Add(new SqlParameter("@Cant", decimal.Parse(array)));
                cmd.Parameters.Add(new SqlParameter("@utilidadSobreCosto", -1));
                cmd.Parameters.Add(new SqlParameter("@descuento", -1));
                cmd.Parameters.Add(new SqlParameter("@pagoConTarjeta", false));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    precios.Add(reader[0].ToString());
                }
                ob.CerrarConexionBD();
            }
            //Despues de ejecutar el procedimiento convertimos la lista en un array
            String[] arrays = precios.ToArray();

            switch(arrays.Length)
            {
                case 1:
                    precioProductoPrecioTop = new ProductoPrecioTop(decimal.Parse(arrays[0].ToString()), 0, 0);
                    break;
                case 2:
                    precioProductoPrecioTop = new ProductoPrecioTop(decimal.Parse(arrays[0].ToString()),
                   decimal.Parse(arrays[1].ToString()), 0);
                    break;
                case 3:
                    precioProductoPrecioTop = new ProductoPrecioTop(decimal.Parse(arrays[0].ToString()),
                   decimal.Parse(arrays[1].ToString()), decimal.Parse(arrays[2].ToString()));
                    break;
            }
            //Le asignamos los valores del array a la variable instanciada del tercer constructor
            return precioProductoPrecioTop;
        }
        public ProductoPrecioTop Obtenerprecioproductotarjeta(string productocodigo) 
        {
            foreach (var array in cantidades)
            {
                ob.AbrirConexionBD();
                SqlCommand cmd = new SqlCommand("ObtenerPrecioProducto", ob.ObtenerConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Cod", productocodigo));
                //Aqui pasamos la variable array respecto de cantidades 
                cmd.Parameters.Add(new SqlParameter("@Cant", decimal.Parse(array)));
                cmd.Parameters.Add(new SqlParameter("@utilidadSobreCosto", -1));
                cmd.Parameters.Add(new SqlParameter("@descuento", -1));
                cmd.Parameters.Add(new SqlParameter("@pagoConTarjeta", true));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    preciosTarj.Add(reader[0].ToString());
                    preciosTarj.Add(reader[2].ToString());
                }
                ob.CerrarConexionBD();
            }
            //Despues de ejecutar el procedimiento convertimos la lista en un array
            while (preciosTarj.Count < 6)
            {
                preciosTarj.Add("0");
            }
            precioProductoTarjeta = new ProductoPrecioTop(decimal.Parse(preciosTarj[0]),
            decimal.Parse(preciosTarj[1]), decimal.Parse(preciosTarj[2]), decimal.Parse(preciosTarj[3]), 
            decimal.Parse(preciosTarj[4]), decimal.Parse(preciosTarj[5]));
            cantidades.Clear();
            precios.Clear();
            preciosTarj.Clear();
            return precioProductoTarjeta;
        }
        //Este metodo devuelve la variable de nombre de producto
        public ProductoPrecioTop Obtenernombreproducto(string productocodigo)
        {
            ob.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("ObtenerNombreProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Cod", productocodigo));

            // execute the command
            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                nombreproducto = new ProductoPrecioTop(reader[0].ToString());
            }
            ob.CerrarConexionBD();
            return nombreproducto;
        }

        public bool ComprobarClaveAdicional(string codigoproducto)
        {
            ob.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("ExisteProductoConCodigo", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Cod", codigoproducto));
            cmd.Parameters.Add(new SqlParameter("@idAlmacen", -1));
            cmd.Parameters.Add(new SqlParameter("@debeCoincidirExactamente", 1));

            string codigoproductoconsultar = "";
            // execute the command
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                 codigoproductoconsultar = reader[1].ToString();
            }
            ob.CerrarConexionBD();

            if (codigoproductoconsultar != codigoproducto)
                return true;
            else
                return false;
           
        }

        public ProductoPrecioTop ObtenerprecioproductoClaveAdicional(string codigoproducto)
        {
            ob.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("ObtenerPrecioProductoClaveAdicional", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@claveAdicional", codigoproducto));

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                precioClaveAdicional = new ProductoPrecioTop(decimal.Parse(reader[0].ToString()), decimal.Parse(reader[1].ToString()), decimal.Parse(reader[2].ToString()), "", "");
            }
            ob.CerrarConexionBD();

            return precioClaveAdicional;
        }
    }
}
