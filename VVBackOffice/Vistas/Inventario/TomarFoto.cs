using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Threading;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.IO;

namespace ValleVerde
{

   
    public partial class TomarFoto : Form
    {
        // Create class-level accesible variables
        VideoCapture capture;
        Mat frame;
        Bitmap image;
        private Thread camera;
        bool isCameraRunning = false;
        Image imagenRetornar;


        // Declare required methods
        private void CaptureCamera()
        {
            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            camera.Start();
        }

        private void CaptureCameraCallback()
        {

            frame = new Mat();
            capture = new VideoCapture(0);
            capture.Open(0);

            if (capture.IsOpened())
            {
                while (isCameraRunning)
                {

                    capture.Read(frame);
                    image = BitmapConverter.ToBitmap(frame);
                    if (pictureBoxC.Image != null)
                    {
                        pictureBoxC.Image.Dispose();
                    }
                    pictureBoxC.Image = image;
                }
            }
        }

        public TomarFoto()
        {
            InitializeComponent();
        }

        private void TomarFoto_Load(object sender, EventArgs e)
        {
            CaptureCamera();
            btnO.Text = "Detener";
            isCameraRunning = true;
        }

        private void roundedButton4_Click(object sender, EventArgs e)
        {
            CaptureCamera();
            btnO.Visible = true;
            isCameraRunning = true;
            btnT.Text = "Tomar foto";
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            if (isCameraRunning)
            {
                if (btnT.Text == "Listo")
                {
                    imagenRetornar = pictureBoxC.Image;
                } 
                else
                {
                    // Take snapshot of the current image generate by OpenCV in the Picture Box
                    Bitmap snapshot = new Bitmap(pictureBoxC.Image);

                    // Save in some directory
                    // in this example, we'll generate a random filename e.g 47059681-95ed-4e95-9b50-320092a3d652.png
                    // snapshot.Save(@"C:\Users\sdkca\Desktop\mysnapshot.png", ImageFormat.Png);
                    //snapshot.Save("C:/TempVV/1.jpeg", ImageFormat.Jpeg);
                    snapshot.Save(string.Format(@"C:\\TempVV\\1.png", Guid.NewGuid()), ImageFormat.Png);
                    capture.Release();
                    btnO.Text = "Tomar Otra";
                    btnT.Text = "Listo";
                    isCameraRunning = false;
                    btnO.Visible = true;
                }
               
            }
            else
            {
                Console.WriteLine("Cannot take picture if the camera isn't capturing image!");
            }
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            capture.Release();
            isCameraRunning = false;
            this.Close();
        }


       public Image obtenerFoto()
        {
            return imagenRetornar;
        }
    }

   
}
