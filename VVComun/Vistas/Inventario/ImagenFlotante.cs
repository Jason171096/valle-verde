using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerdeComun.Vistas.Inventario
{
    public partial class ImagenFlotante : Form
    {
        Color color;
        Label lblTitulo;
        int duracion = -1;

        public ImagenFlotante(int duracion)
        {
            InitializeComponent();
            this.TransparencyKey = Color.Turquoise;
            this.BackColor = Color.Turquoise;

            FormBorderStyle = FormBorderStyle.None;
            this.duracion = duracion;

            Shown += Form1_Shown;

        }

        public ImagenFlotante()
        {
            InitializeComponent();
            this.TransparencyKey = Color.Turquoise;
            this.BackColor = Color.Turquoise;

            FormBorderStyle = FormBorderStyle.None;
        }

        private void ImegenFlotante_Load(object sender, EventArgs e)
        {

            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (duracion != -1)
            {
                this.Refresh();
                Thread.Sleep(duracion);
                this.Close();
            }
        }

        public void setTitulo(string titulo,Color color)
        {
            FontFamily fontFamily = new FontFamily("Arial");
            Font fontB = new Font(
           fontFamily,
           40,
           FontStyle.Regular,
           GraphicsUnit.Pixel);

            if(lblTitulo == null)
                lblTitulo = new Label();
            lblTitulo.Text = titulo;
            lblTitulo.AutoSize = false;
            lblTitulo.Height = 45;
            lblTitulo.Width = this.Width;
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.TextAlign = ContentAlignment.BottomCenter;
            lblTitulo.Font = fontB;
            lblTitulo.Top = 10;
            if (color != null)
            {
                panel1.BackColor = color;
                this.color = color;
            }
            if(!panel1.Controls.Contains(lblTitulo))
                panel1.Controls.Add(lblTitulo);
        }

        public void setImagenFlotante(Panel panel)
        {
            if (panel.Width != 0)
            {
                var bc = panel.BackColor;
                if (color != null)
                    panel.BackColor = color;

                Bitmap b = new Bitmap(panel.Width, panel.Height);
                panel.DrawToBitmap(b, new Rectangle(0, 0, b.Width, b.Height));
                pictureBox1.Image = b;

                panel.BackColor = bc;
            }
        }

        public void setTiempoCerrar(int tiempo)
        {
            timer1.Interval = tiempo;
            timer1.Enabled = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
