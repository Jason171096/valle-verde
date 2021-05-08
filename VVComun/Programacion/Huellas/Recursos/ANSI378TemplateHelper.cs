using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerdeComun.Programacion.Huellas.Recursos
{
    public class ANSI378TemplateHelper
    {
        private int MAX_LENGTH_POS = 8;
        private int MINUTIAE_ITEM_SIZE = 6;
        private byte[] Template;
        private int TemplateSize;
        private Minutiae[] MinutiaeList;

        public ANSI378TemplateHelper(byte[] template, int templateSize)
        {
            Template = new byte[templateSize];
            TemplateSize = templateSize;
            Template = template;
        }

        public Minutiae[] GetMinutiaeList()
        {
            ExtractANSI378Template();
            return MinutiaeList;
        }

        private void ExtractANSI378Template()
        {
            int numOfMinutiae = UnsignedByteToInt(Template[GetDataStartPosition()]);
            MinutiaeList = new Minutiae[numOfMinutiae];

            for (int i = 0; i < numOfMinutiae; i++)
            {
                MinutiaeList[i] = UnpackMinutiaeDataItem(i);
            }
        }
        public static int UnsignedByteToInt(byte b)
        {
            return (int)b & 0xFF;
        }

        private int GetDataStartPosition()
        {
            int pos = MAX_LENGTH_POS;
            int templateSize = Template[pos++] << 8;
            templateSize += Template[pos++];
            if (templateSize == 0)
            {
                templateSize = (Template[pos] << 24)
                           + (Template[pos + 1] << 16)
                           + (Template[pos + 2] << 8)
                           + Template[pos + 3];
                pos += 4;
            }
            pos += 19;

            return pos;
        }

        Minutiae UnpackMinutiaeDataItem(int n)
        {
            Minutiae minutiae = new Minutiae();
            int pos = GetDataStartPosition() + n * MINUTIAE_ITEM_SIZE + 1;
            minutiae.nType = (UnsignedByteToInt(Template[pos]) >> 6);
            minutiae.nX = ((UnsignedByteToInt(Template[pos]) & 0x03f) << 8) + UnsignedByteToInt(Template[pos + 1]);
            pos += 2;
            minutiae.nY = ((UnsignedByteToInt(Template[pos]) & 0x03f) << 8) + UnsignedByteToInt(Template[pos + 1]);
            pos += 2;
            int angle = UnsignedByteToInt(Template[pos++]) << 1;
            minutiae.nRotAngle = (angle * Math.PI) / 180;
            return minutiae;
        }


    }

}
