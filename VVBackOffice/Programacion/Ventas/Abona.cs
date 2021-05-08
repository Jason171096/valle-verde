using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerde.Programacion.Ventas
{    
    class Abona
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();
        public string AgregarAbonosCredito(int IDCliente, decimal abono, int formaPago, int idVenta, int IDUsuario)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("AgregarAbonosCredito", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@IDCliente", IDCliente));
            cmd.Parameters.Add(new SqlParameter("@abono", abono));
            cmd.Parameters.Add(new SqlParameter("@formaPago", formaPago));
            cmd.Parameters.Add(new SqlParameter("@idVenta", idVenta));
            cmd.Parameters.Add(new SqlParameter("@IDUsuario", IDUsuario));
            cmd.Parameters.Add(new SqlParameter("@IDTurno", -1));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            string resultado = "";

            while (rdr.Read())
            {
                resultado =  rdr[0] +"";
            }

            ob.CerrarConexionBD();

            return resultado;
        }
    }
}
