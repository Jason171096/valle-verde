using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerdeComun.Programacion.Huellas.Recursos
{
    public class Sensor
    {
        public uint handle;
        public Recursos.LumiSDKWrapper.LUMI_SENSOR_TYPE SensorType;
        public string strIdentifier;
    }
}
