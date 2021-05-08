﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ValleVerdeComun.Programacion
{
    class Fabricantes
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();

        public List<String[]> ObtenerFabricantes()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerFabricantes", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<String[]> resultado = new List<String[]>();

            while (rdr.Read())
            {
                resultado.Add(new String[] {rdr[0]+"", rdr[1]+"", rdr[2]+""});
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public string ObtenerFabricanteProducto(string idProd)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerFabricanteProducto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Cod", idProd));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            string res = "";
            while (rdr.Read())
            {
                res = rdr[0] + "";
            }

            ob.CerrarConexionBD();

            return res;
        }

        public void AltaNuevo(String Nombre, String Descripcion)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AltaFabricante", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Nom", Nombre));
            cmd.Parameters.Add(new SqlParameter("@des", Descripcion));


            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();
            
            // iterate through results, printing each to console
            while (rdr.Read())
            {
                Console.WriteLine("Product: {0,-35} Total: {1,2}", rdr["ProductName"], rdr["Total"]);
            }
            

            ob.CerrarConexionBD();
        }

        public int NoProductosFabricante(String IDFabricante)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("NoProductosFabricante", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Id", IDFabricante));


            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            // iterate through results, printing each to console
            int nop = 0;

            while (rdr.Read())
            {
                nop = int.Parse(rdr[0]+"");
            }

            
            ob.CerrarConexionBD();

            return nop;
        }

       public int EliminarFabricante(String IDFabricante)
       {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("EliminarFabricante", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@Id", IDFabricante));


            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            // iterate through results, printing each to console
            int res = 0;

            while (rdr.Read())
            {
                res = int.Parse(rdr[0] + "");
            }


            ob.CerrarConexionBD();
            return res;
       }
    }
}
