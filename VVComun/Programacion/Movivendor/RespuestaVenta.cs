using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerdeComun.Programacion.Movivendor
{
    public class RespuestaVenta
    {
        public string codResp;
        public string msgResp;
        public string id;
        public string claveCanal;
        public string fecha;
        public string monto;
        public string rcode;
        public string confirma;
        public string extra;

        public RespuestaVenta(string codigoError,string mensajeError)
        {
            codResp = codigoError;
            rcode = codigoError;
            msgResp = mensajeError;
        }
        public RespuestaVenta(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jUser = jObject["ventaResp"];

            if(jUser == null)//Intentar como respuesta de checar
                jUser = jObject["statusVtaResp"];

            if (jUser == null)//Intentar como respuesta de checar
                jUser = jObject["reversoResp"];

            codResp = (string)jUser["codResp"];
            msgResp = (string)jUser["msgResp"];
            id = (string)jUser["id"];
            claveCanal = (string)jUser["claveCanal"];
            fecha = (string)jUser["fecha"];
            monto = (string)jUser["monto"];
            rcode = (string)jUser["rcode"];
            confirma = (string)jUser["confirma"];
            extra = (string)jUser["extra"];
        }
    }
}
