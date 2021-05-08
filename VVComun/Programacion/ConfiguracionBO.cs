using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Script.Serialization;

namespace ValleVerdeComun.Programacion
{
    public class ConfiguracionBO : AppSettingsBO<ConfiguracionBO>
    {
        public string Servidor = "-1";
        public string Impresora = "";
        public string ImpresoraEtiquetas = "";
        public string ImpresoraTickets = "";
        public string AnchoTicket = "";
    }

    public class AppSettingsBO<T> where T : new()
    {
        private const string DEFAULT_FILENAME = "configuracionBO.json";

        public void Save(string fileName = DEFAULT_FILENAME)
        {
            File.WriteAllText(fileName, (new JavaScriptSerializer()).Serialize(this));
        }

        public static void Save(T pSettings, string fileName = DEFAULT_FILENAME)
        {
            File.WriteAllText(fileName, (new JavaScriptSerializer()).Serialize(pSettings));
        }

        public static T Load(string fileName = DEFAULT_FILENAME)
        {
            T t = new T();
            if (File.Exists(fileName))
                t = (new JavaScriptSerializer()).Deserialize<T>(File.ReadAllText(fileName));
            return t;
        }
    }
}
