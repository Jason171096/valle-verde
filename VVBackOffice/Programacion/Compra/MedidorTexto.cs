using MigraDoc.DocumentObjectModel;
using PdfSharp.Drawing;
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace ValleVerde.Vistas.Compras
{
    class MedidorTexto
    {
        /// <summary>
        /// Initializes a new instance of the MedidorTexto class with the specified font.
        /// </summary>
        public MedidorTexto(Font font)
        {
            if (font == null)
                throw new ArgumentNullException("font");

            _font = font;
        }

        /// <summary>
        /// Returns the size of the bounding box of the specified text.
        /// </summary>
        public XSize MedirTexto(string text, UnitType unitType)
        {
            if (text == null)
                throw new ArgumentNullException("text");

            if (!Enum.IsDefined(typeof(UnitType), unitType))
                throw new InvalidEnumArgumentException();

            XGraphics graphics = Realize();

            XSize size = graphics.MeasureString(text, _gdiFont/*, new XPoint(0, 0), StringFormat.GenericTypographic*/);
            switch (unitType)
            {
                case UnitType.Point:
                    break;

                case UnitType.Centimeter:
                    size.Width = (float)(size.Width * 2.54 / 72);
                    size.Height = (float)(size.Height * 2.54 / 72);
                    break;

                case UnitType.Inch:
                    size.Width = size.Width / 72;
                    size.Height = size.Height / 72;
                    break;

                case UnitType.Millimeter:
                    size.Width = (float)(size.Width * 25.4 / 72);
                    size.Height = (float)(size.Height * 25.4 / 72);
                    break;

                case UnitType.Pica:
                    size.Width = size.Width / 12;
                    size.Height = size.Height / 12;
                    break;

                default:
                    Debug.Assert(false, "Missing unit type");
                    break;
            }
            return size;
        }

        /// <summary>
        /// Returns the size of the bounding box of the specified text in point.
        /// </summary>
        public XSize MedirTexto(string text)
        {
            return MedirTexto(text, UnitType.Point);
        }

        /// <summary>
        /// Gets or sets the font used for measurement.
        /// </summary>
        public Font Font
        {
            get { return _font; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                if (_font != value)
                {
                    _font = value;
                    _gdiFont = null;
                }
            }
        }
        Font _font;

        /// <summary>
        /// Initializes appropriate GDI+ objects.
        /// </summary>
        XGraphics Realize()
        {
            if (_graphics == null)
                _graphics = XGraphics.CreateMeasureContext(new XSize(2000, 2000), XGraphicsUnit.Point, XPageDirection.Downwards);

            //this.graphics.PageUnit = GraphicsUnit.Point;

            if (_gdiFont == null)
            {
                XFontStyle style = XFontStyle.Regular;
                if (_font.Bold)
                    style |= XFontStyle.Bold;
                if (_font.Italic)
                    style |= XFontStyle.Italic;

                _gdiFont = new XFont(_font.Name, _font.Size, style/*, System.Drawing.GraphicsUnit.Point*/);
            }
            return _graphics;
        }

        XFont _gdiFont;
        XGraphics _graphics;
    }
}