using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Web.Script.Serialization;

namespace ValleVerdeComun
{
    public class ConexionBD
    {
        private string connetionString = null;
        private SqlConnection cnn;
        private string servidorTemp = "";


        public bool AbrirConexionBD()
        {
            //Abrir el archivo de configuracion y sacar el nombre del servidor
            
            string jsonFilePathPV = "configuracionPV.json";
            string jsonFilePathBO = "configuracionBO.json";
            string json, servidor = "";

            if (File.Exists(jsonFilePathPV) || File.Exists(jsonFilePathBO) || servidorTemp!="")
            {
                if (File.Exists(jsonFilePathPV) || File.Exists(jsonFilePathBO))
                {
                    if (File.Exists(jsonFilePathPV))
                        json = File.ReadAllText(jsonFilePathPV);
                    else
                        json = File.ReadAllText(jsonFilePathBO);

                    Dictionary<string, object> json_Dictionary = (new JavaScriptSerializer()).Deserialize<Dictionary<string, object>>(json);

                    foreach (var item in json_Dictionary)
                    {
                        // parse here
                        if (item.Key == "Servidor")
                        {
                            servidor = item.Value + "";
                            break;
                        }
                    }
                }
                else
                {
                    servidor = servidorTemp;
                }

                connetionString = "Data Source=" + servidor + ";Initial Catalog=valleverde;User Id=usuario1;Password=cotija20";
                //connetionString = "Data Source=JORGEGABRIEAFFC;Initial Catalog=valleverde;Trusted_Connection=True;";
                //connetionString = "Data Source=192.168.1.1,1400;Initial Catalog=valleverde;User Id=usuario1;Password=valleverde";
                cnn = new SqlConnection(connetionString);
                try
                {
                    cnn.Open();
                    //MessageBox.Show("Conexion exitosa");
                    return true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo conectar con el servidor: " + ex);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("No se pudo leer el archivo de configuracion del programa." );
                return false;
            }
        }

        public string ObtenerCadenaConexion()
        {
            return connetionString;
        }

        public void CerrarConexionBD()
        {
            cnn.Close();
        }

        public SqlConnection ObtenerConexion()
        {
            return cnn;
        }


    }
}
