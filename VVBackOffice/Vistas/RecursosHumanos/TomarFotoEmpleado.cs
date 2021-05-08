using System;
using System.Drawing;
using System.Windows.Forms;
using DarrenLee.Media;


namespace ValleVerde.Vistas.RecursosHumanos
{
    public partial class TomarFotoEmpleado : Form
    {
        private string rutaFoto = "";
        Camera camera;
        public TomarFotoEmpleado()
        {
            InitializeComponent();
            try
            {
                camera = new Camera();
                GetInfo();
                camera.OnFrameArrived += Camera_OnFrameArrived;
            }
            catch (Exception ex)
            {
                if (ex is ArgumentOutOfRangeException || ex is NullReferenceException)
                {
                    MessageBox.Show("No se detecto ninguna camara", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        private void GetInfo()
        {
            var cameraDevices = camera.GetCameraSources();
            foreach (var d in cameraDevices)
            {
                comboBoxDevices.Items.Add(d);
            }
            comboBoxDevices.SelectedIndex = 0;

            var cameraResolution = camera.GetSupportedResolutions();
            foreach (var r in cameraResolution)
            {
                comboBoxResolution.Items.Add(r);
            }
            comboBoxResolution.SelectedIndex = 0;
        }

        private void Camera_OnFrameArrived(object source, FrameArrivedEventArgs e)
        {
            Image image = e.GetFrame();
            pictureBoxCamara.Image = image;
        }

        private void ComboBoxDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            camera.ChangeCamera(comboBoxDevices.SelectedIndex);

        }
        private void comboBoxResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            camera.Start(comboBoxResolution.SelectedIndex);
        }
        private void TomarFotoEmpleado_FormClosing(object sender, FormClosingEventArgs e)
        {
            camera.Stop();
        }

        private void BtnTomarFoto_Click(object sender, EventArgs e)//Caturar foto y guardarla en un carpeta especifica
        {
            string filename = Application.LocalUserAppDataPath + @"\Image_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            camera.Capture(filename);
            rutaFoto = filename.Replace($"\\", "\\\\");
            camera.Stop();
            Close();
        }

        public Image ObtenerFoto()
        {          
            return Image.FromFile(rutaFoto + ".jpg");
        }
    }
}
