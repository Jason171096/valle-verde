using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerdeComun.Programacion
{
   
    public class ConfiguracionGlobal
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();

        public DatosConfiguracionGlobal ObtenerConfiguracionGlobal()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerConfiguracionGlobal", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;


            DatosConfiguracionGlobal res = null;
            // execute the command 
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = new DatosConfiguracionGlobal(decimal.Parse(rdr[0] + ""),int.Parse( rdr[1] + ""), int.Parse(rdr[2] + ""), int.Parse(rdr[3] + ""),Convert.ToBoolean(rdr[4] + ""), int.Parse(rdr[5] + ""), decimal.Parse(rdr[6] + ""), decimal.Parse(rdr[7] + ""),int.Parse(rdr[8] + ""), rdr[9] + "", rdr[10] + "", rdr[11] + "", rdr[12] + "", rdr[13] + "", rdr[14] + "", rdr[15] + "", rdr[16] + "", rdr[17] + "", rdr[18] + "");
                    
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public DatosEmpresa ObtenerDatosEmpresa()
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerDatosEmpresa", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;


            DatosEmpresa res = null;
            // execute the command 
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    byte[] b = (byte[])rdr.GetValue(4);

                    Image img = Image.FromStream(new MemoryStream(b));

                    res = new DatosEmpresa(
                    rdr[0] + "",
                    rdr[1] + "",
                    rdr[2] + "",
                    rdr[3] + "",
                   img,
                    rdr[5] + "",
                    rdr[6] + "",
                    rdr[7] + "",
                    rdr[8] + "",
                    rdr[9] + "",
                    rdr[10] + "",
                    rdr[11] + "",
                    rdr[12] + "");
                }
            }

            ob.CerrarConexionBD();
            return res;
        }

        public DatosTicket ObtenerConfiguracionTicket(string idTicket)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerConfiguracionTicket", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idTicket", idTicket));


            DatosTicket res = null;
            // execute the command 
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    res = new DatosTicket(int.Parse(rdr[0] + "")
                    , rdr[1] + ""
                    , rdr[2] + ""
                    , rdr[3] + ""
                    , rdr[4] + ""
                    , rdr[5] + ""
                    , Convert.ToBoolean(rdr[6] + "")
                    , Convert.ToBoolean(rdr[7] + "")
                    , Convert.ToBoolean(rdr[8] + "")
                    , Convert.ToBoolean(rdr[9] + "")
                    , Convert.ToBoolean(rdr[10] + "")
                    , Convert.ToBoolean(rdr[11] + "")
                    , int.Parse(rdr[12] + "")
                    , Convert.ToBoolean(rdr[13] + "")
                    , Convert.ToBoolean(rdr[14] + "")
                    , Convert.ToBoolean(rdr[15] + "")
                    , Convert.ToBoolean(rdr[16] + "")
                    , Convert.ToBoolean(rdr[17] + "")
                    , Convert.ToBoolean(rdr[18] + "")
                    , Convert.ToBoolean(rdr[19] + "")
                    , Convert.ToBoolean(rdr[20] + "")
                    , Convert.ToBoolean(rdr[21] + "")
                     , Convert.ToBoolean(rdr[22] + ""));
                }
            }

            ob.CerrarConexionBD();
            return res;
        }


    }
}
