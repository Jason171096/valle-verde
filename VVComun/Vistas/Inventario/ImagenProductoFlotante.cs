using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerdeComun
{
    public partial class ImagenProductoFlotante : Form
    {
        float x1, y1, x2, y2;

        public void setImage(Image img)
        {
            if (img == null)
                img = Properties.Resources.unknown;

            if (img != null)
            {
                pictureBox1.Image = img.GetThumbnailImage(img.Width, img.Height, null, new IntPtr());
                img.Dispose();
            }
            else
            {
                pictureBox1.Image = img;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public ImagenProductoFlotante(float x1, float y1, float x2, float y2)
        {
            InitializeComponent();
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
        }

        private void ImagenProductoFlotante_Load(object sender, EventArgs e)
        {
            ActualizarUbicacion(this.x1, this.y1, this.x2, this.y2);
        }

        public void ActualizarUbicacion(float x1, float y1, float x2, float y2)
        {
            Point p = new Point((int)(x1 + x2 + 10), (int)(y1 + y2 - 300));
            this.Location = p;
        }

       
    }
}
