using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerdeComun.Vistas.Inventario
{
    public class CheckDigit
    {
        public string Check(string Raw_Data, bool checarSiEsDeBascula)
        {
            try
            {
                string RawDataHolder = "";

                if (checarSiEsDeBascula)
                    RawDataHolder = Raw_Data.Substring(0, 12);
                else
                    RawDataHolder = "0" + Raw_Data.Substring(0, 11);

                int even = 0;
                int odd = 0;

                for (int i = 0; i < RawDataHolder.Length; i++)
                {
                    if (i % 2 == 0)
                        odd += Int32.Parse(RawDataHolder.Substring(i, 1));
                    else
                        even += Int32.Parse(RawDataHolder.Substring(i, 1)) * 3;
                }//for

                int total = even + odd;
                int cs = total % 10;
                cs = 10 - cs;
                if (cs == 10)
                    cs = 0;

                if (checarSiEsDeBascula)
                    Raw_Data = RawDataHolder + cs.ToString()[0];
                else
                    Raw_Data = RawDataHolder.Substring(1) + cs.ToString()[0];
                return Raw_Data;
            }//try
            catch
            {
                return "-1";
            }//catch
        }
    }
}
