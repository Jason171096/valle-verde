using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion.Ventas;

namespace ValleVerde.Vistas.Ventas
{
    public partial class ImagenPromocion : Form
    {
        Promocion promo = new Promocion();
        bool banImgAdi;
        long idPromocion;
        public ImagenPromocion(long idPromocion)
        {
            InitializeComponent();
            this.idPromocion = idPromocion;

            label1.Parent = pictureBox1;
            label2.Parent = pictureBox1;
            label3.Parent = pictureBox1;
            pictureBox2.Parent = pictureBox1;

            
        }

        private void ImagenPromocion_Load(object sender, EventArgs e)
        {
            LlenarImagen();
        }

        private void LlenarImagen()
        {
            List<string[]> resPromo = promo.ObtenerPromocion(idPromocion);

            if (resPromo[0][6] != "0")
            {
                label1.Text = "OFERTA "+resPromo[0][6]+"% DE DESCUENTO";
            }
            else
            {
                label1.Text = "PROMOCIÓN";
            }

            label2.Text = resPromo[0][1];

            if (resPromo[0][2] != "")
            {
                label3.Text = "*Vigencia del "+DateTime.Parse(resPromo[0][2]).ToString("dddd, dd/MM/yyyy")+" al " + DateTime.Parse(resPromo[0][2]).ToString("dddd, dd/MM/yyyy") + "\n**Cantidad de PIEZAS LIMITADAS para la promoción";
            }
            else
            {
                label3.Text = "**Cantidad de PIEZAS LIMITADAS para la promoción";
            }

            List<object[]> resImg = promo.ObtenerImagenPromocion(idPromocion);
            if (resImg.Count > 0)
            {
                if (resImg[0][1] != null)
                {
                    byte[] b = (byte[])resImg[0][1];

                    Image img = Image.FromStream(new MemoryStream(b));

                    pictureBox2.Image = img;
                }
            }
            else
            {
                List<string[]> resProd = promo.ObtenerProductoPromocion(idPromocion+"");
                List<Image> ImgProd = promo.ObtenerImagenesProducto(resProd[0][2]);
                if (ImgProd.Count > 0)
                {
                    pictureBox2.Image = ImgProd[0];
                }                
            }
        }

        private void botonColorN_Click(object sender, EventArgs e)
        {
            ColorDialog colorN = new ColorDialog();
            colorN.Color = label2.ForeColor;
            if (colorN.ShowDialog() == DialogResult.OK)
            {
                label2.ForeColor = colorN.Color;
            }
        }

        private void botonFuenteN_Click(object sender, EventArgs e)
        {
            FontDialog fontN = new FontDialog();
            fontN.Font = label2.Font;
            if (fontN.ShowDialog() == DialogResult.OK)
            {
                label2.Font = fontN.Font;
            }
        }

        private void toggleNombre_SliderValueChanged(object sender, EventArgs e)
        {
            if (toggleNombre.IsOn)
            {
                textNombre.Enabled = true;
                botonColorN.Enabled = true;
                botonFuenteN.Enabled = true;
            }
            else
            {
                textNombre.Enabled = false;
                botonColorN.Enabled = false;
                botonFuenteN.Enabled = false;
            }
        }

        private void botonSubir_Click(object sender, EventArgs e)
        {
            banImgAdi = true;
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png|Todos los Archivos(*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.Multiselect = false;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //string imagen = openFileDialog1.FileName;
                    //pictureBox2.Image = Image.FromFile(imagen);
                    pictureBox2.Image = new Bitmap(openFileDialog1.FileName);
                    //pictureBox2.ImageLocation = openFileDialog1.FileName;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("El archivo seleccionado no es válido");
            }
        }

        private void botonExportar_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png|Todos los Archivos(*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var b = new Bitmap(panelImagen.Width, panelImagen.Height);
                    panelImagen.DrawToBitmap(b, new Rectangle(0, 0, panelImagen.Width, panelImagen.Height));
                    b.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Error");
            }
            
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            string resImg = promo.ExisteImagenPromocion(idPromocion);
            var b = new Bitmap(panelImagen.Width, panelImagen.Height);
            panelImagen.DrawToBitmap(b, new Rectangle(0, 0, panelImagen.Width, panelImagen.Height));
            if (resImg == "1")
            {
                if (banImgAdi)
                {
                    promo.ActualizarImagenPromocion(idPromocion, b, pictureBox2.Image);
                    banImgAdi = false;
                }
                else
                {
                    promo.ActualizarImagenPromocion(idPromocion, b, null);
                }
            }
            else
            {
                if (banImgAdi)
                {
                    promo.AgregarImagenPromocion(idPromocion, b, pictureBox2.Image);
                    banImgAdi = false;
                }
                else
                {
                    promo.AgregarImagenPromocion(idPromocion, b, null);
                }
            }
            MessageBox.Show("Imagen agregada con exito");
        }

        private void textNombre_TextChanged(object sender, EventArgs e)
        {
            label2.Text = textNombre.Text;
        }

        private void ColorT_Click(object sender, EventArgs e)
        {
            ColorDialog colorN = new ColorDialog();
            colorN.Color = label1.ForeColor;
            if (colorN.ShowDialog() == DialogResult.OK)
            {
                label1.ForeColor = colorN.Color;
            }
        }

        private void ColorF_Click(object sender, EventArgs e)
        {
            ColorDialog colorN = new ColorDialog();
            colorN.Color = label3.ForeColor;
            if (colorN.ShowDialog() == DialogResult.OK)
            {
                label3.ForeColor = colorN.Color;
            }
        }

        private void FuenteT_Click(object sender, EventArgs e)
        {
            FontDialog fontN = new FontDialog();
            fontN.Font = label1.Font;
            if (fontN.ShowDialog() == DialogResult.OK)
            {
                label1.Font = fontN.Font;
            }
        }

        private void FuenteF_Click(object sender, EventArgs e)
        {
            FontDialog fontN = new FontDialog();
            fontN.Font = label3.Font;
            if (fontN.ShowDialog() == DialogResult.OK)
            {
                label3.Font = fontN.Font;
            }
        }

        private void toggleModificar_SliderValueChanged(object sender, EventArgs e)
        {
            if (toggleModificar.IsOn)
            {
                ColorT.Enabled = true;
                ColorF.Enabled = true;
                FuenteT.Enabled = true;
                FuenteF.Enabled = true;
                textTitulo.Enabled = true;
            }
            else
            {
                ColorT.Enabled = false;
                ColorF.Enabled = false;
                FuenteT.Enabled = false;
                FuenteF.Enabled = false;
                textTitulo.Enabled = false;
            }
            
        }

        private void textTitulo_TextChanged(object sender, EventArgs e)
        {
            label1.Text = textTitulo.Text;
        }

        private void botonFondo_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png|Todos los Archivos(*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.Multiselect = false;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //string imagen = openFileDialog1.FileName;
                    //pictureBox2.Image = Image.FromFile(imagen);
                    pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                    //pictureBox2.ImageLocation = openFileDialog1.FileName;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("El archivo seleccionado no es válido");
            }
        }
    }
}
