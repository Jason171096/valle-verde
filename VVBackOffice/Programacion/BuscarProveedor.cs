using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ValleVerde.Programacion
{
    class BuscarProveedor
    {
        ValleVerdeComun.ConexionBD obj = new ValleVerdeComun.ConexionBD();
        public List<String[]> ObtenerProveedores()
        {
            obj.AbrirConexionBD();

            // Llama procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ObtenerProveedores", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> res = new List<string[]>();
            String diaVis = "";
            Boolean unDiaVis = true;

            while (rdr.Read())
            {
                if (rdr[16].ToString().Equals("True"))
                {
                    diaVis = "Lun";
                    unDiaVis = false;
                }
                if (rdr[17].ToString().Equals("True"))
                {
                    if (unDiaVis == true)
                    {
                        diaVis += "Mar";
                        unDiaVis = false;
                    }
                    else
                        diaVis += ", Mar";
                }
                if (rdr[18].ToString().Equals("True"))
                {
                    if (unDiaVis == true)
                    {
                        diaVis += "Mié";
                        unDiaVis = false;
                    }
                    else
                        diaVis += ", Mié";
                }
                if (rdr[19].ToString().Equals("True"))
                {
                    if (unDiaVis == true)
                    {
                        diaVis += "Jue";
                        unDiaVis = false;
                    }
                    else
                        diaVis += ", Jue";
                }
                if (rdr[20].ToString().Equals("True"))
                {
                    if (unDiaVis == true)
                    {
                        diaVis += "Vie";
                        unDiaVis = false;
                    }
                    else
                        diaVis += ", Vie";
                }
                if (rdr[21].ToString().Equals("True"))
                {
                    if (unDiaVis == true)
                    {
                        diaVis += "Sáb";
                        unDiaVis = false;
                    }
                    else
                        diaVis += ", Sáb";
                }
                if (rdr[22].ToString().Equals("True"))
                {
                    if (unDiaVis == true)
                    {
                        diaVis += "Dom";
                        unDiaVis = false;
                    }
                    else
                        diaVis += ", Dom";
                }

                res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[10] + "", diaVis, rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[11] + "", rdr[5] + "", rdr[7] + "", rdr[6] + "", rdr[8] + ""});
            }
            
            obj.CerrarConexionBD();

            return res;
        }

        public List<String[]> ObtenerProveedor(String texBus)
        {
            obj.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("ObtenerProveedor", obj.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@texBus", texBus));
            /*
            cmd.Parameters.Add(new SqlParameter("@nom", nom));
            cmd.Parameters.Add(new SqlParameter("@dir", dir));
            cmd.Parameters.Add(new SqlParameter("@ciu", ciu));
            cmd.Parameters.Add(new SqlParameter("@est", est));
            cmd.Parameters.Add(new SqlParameter("@tel", tel));
            cmd.Parameters.Add(new SqlParameter("@diaCre", diaCre));
            cmd.Parameters.Add(new SqlParameter("@corEle", corEle));
            cmd.Parameters.Add(new SqlParameter("@limCre", limCre));
            cmd.Parameters.Add(new SqlParameter("@lun", diaVis[0]));
            cmd.Parameters.Add(new SqlParameter("@mar", diaVis[1]));
            cmd.Parameters.Add(new SqlParameter("@mie", diaVis[2]));
            cmd.Parameters.Add(new SqlParameter("@jue", diaVis[3]));
            cmd.Parameters.Add(new SqlParameter("@vie", diaVis[4]));
            cmd.Parameters.Add(new SqlParameter("@sab", diaVis[5]));
            cmd.Parameters.Add(new SqlParameter("@dom", diaVis[6]));
            cmd.Parameters.Add(new SqlParameter("@rfc", rfc));
            cmd.Parameters.Add(new SqlParameter("@cel", cel));
            cmd.Parameters.Add(new SqlParameter("@idUsu", idUsu));
            cmd.Parameters.Add(new SqlParameter("@fecUsu", fecUsu));
            */

            SqlDataReader rdr = cmd.ExecuteReader();

            List<String[]> res = new List<string[]>();
            String diaVis = "";
            Boolean unDiaVis = true;

            while (rdr.Read())
            {
                if (rdr[16].ToString().Equals("True"))
                {
                    diaVis = "Lun";
                    unDiaVis = false;
                }
                if (rdr[17].ToString().Equals("True"))
                {
                    if (unDiaVis == true)
                    {
                        diaVis += "Mar";
                        unDiaVis = false;
                    }
                    else
                        diaVis += ", Mar";
                }
                if (rdr[18].ToString().Equals("True"))
                {
                    if (unDiaVis == true)
                    {
                        diaVis += "Mié";
                        unDiaVis = false;
                    }
                    else
                        diaVis += ", Mié";
                }
                if (rdr[19].ToString().Equals("True"))
                {
                    if (unDiaVis == true)
                    {
                        diaVis += "Jue";
                        unDiaVis = false;
                    }
                    else
                        diaVis += ", Jue";
                }
                if (rdr[20].ToString().Equals("True"))
                {
                    if (unDiaVis == true)
                    {
                        diaVis += "Vie";
                        unDiaVis = false;
                    }
                    else
                        diaVis += ", Vie";
                }
                if (rdr[21].ToString().Equals("True"))
                {
                    if (unDiaVis == true)
                    {
                        diaVis += "Sáb";
                        unDiaVis = false;
                    }
                    else
                        diaVis += ", Sáb";
                }
                if (rdr[22].ToString().Equals("True"))
                {
                    if (unDiaVis == true)
                    {
                        diaVis += "Dom";
                        unDiaVis = false;
                    }
                    else
                        diaVis += ", Dom";
                }
                res.Add(new string[] { rdr[0] + "", rdr[1] + "", rdr[10] + "", diaVis, rdr[2] + "", rdr[3] + "", rdr[4] + "", rdr[11] + "", rdr[5] + "", rdr[7] + "", rdr[6] + "", rdr[8] + "" });
            }
            
            obj.CerrarConexionBD();

            return res;
        }
    }
}
