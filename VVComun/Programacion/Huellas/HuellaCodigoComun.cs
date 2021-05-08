using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerdeComun.Programacion.Huellas
{
    public delegate void DelegateActualizarImagen(Image imagen);
    public delegate void DelegateActualizarMensaje(String mensaje);

    class HuellaCodigoComun
    {

        Recursos.Sensor sensorid;
        public byte[] m_bRawImageBuffer;
        public uint m_nWidth;
        public uint m_nHeight;
        public byte[] m_bTemplateBuffer;
        private bool m_bCancelCapture;
        public bool m_bSpoofEnabled;
        public bool m_bComTimeOut;
        public bool m_bSensorTriggerArmed;
        public string m_debugFolder; // Este se va a eliminar
        public uint m_MatchThreshold;
        public string m_sFolderPath;
        public uint m_SpoofThreshold;
        public bool m_SpoofThreshold_HighlySecured;
        public bool m_SpoofThreshold_Secured;
        public bool m_MatchThreshold_Convenient;
        public bool m_MatchThreshold_HighlySecured;
        public bool m_MatchThreshold_Secured;
        public bool m_SpoofThreshold_Convenient;
        public bool m_bNISTQuality;
        public bool m_bDevicePresent;

        public int m_nEnrollmentCaptureIndex = -1;

        public Programacion.Huellas.DelegateActualizarImagen ActualizarImagenDelegado;
        public Programacion.Huellas.DelegateActualizarMensaje ActualizarMensajeDelegado;
        Form ventana;
        PictureBox imgHuella;

        public HuellaCodigoComun()
        {

        }


        public HuellaCodigoComun(Form ventana, DelegateActualizarImagen ActualizarImagenDelegado, DelegateActualizarMensaje ActualizarMensajeDelegado, PictureBox imgHuella)
        {
            this.imgHuella = imgHuella;
            this.ventana = ventana;
            this.ActualizarImagenDelegado = ActualizarImagenDelegado;
            this.ActualizarMensajeDelegado = ActualizarMensajeDelegado;

            
            m_MatchThreshold = 0;
            m_bCancelCapture = false;
            m_bComTimeOut = false;

            OperatingSystem os = Environment.OSVersion;

            //Cargando configuraciones por defecto para el lector
            m_bSpoofEnabled = false;
            m_bSensorTriggerArmed = true;
            m_bNISTQuality = true;
            m_SpoofThreshold_Secured = true;
            m_SpoofThreshold_HighlySecured = false;
            m_SpoofThreshold_Convenient = false;
            m_MatchThreshold_Secured = false;
            m_MatchThreshold_HighlySecured = true;
            m_MatchThreshold_Convenient = false;

            m_sFolderPath = "C:\\ProgramData\\Lumidigm\\VV\\AppData";
            m_debugFolder = m_sFolderPath + "\\Debug";

            Version vs = os.Version;
            bool isExists = System.IO.Directory.Exists(m_sFolderPath);
            if (vs.Minor != 0)
            {
                if (!isExists)
                {
                    System.IO.Directory.CreateDirectory(m_sFolderPath);
                    System.IO.Directory.CreateDirectory(m_sFolderPath + "\\Database");
                    System.IO.Directory.CreateDirectory(m_sFolderPath + "\\Debug");
                }
                else
                {

                    if (!System.IO.Directory.Exists(m_debugFolder))
                        System.IO.Directory.CreateDirectory(m_sFolderPath + "\\Debug");

                }
            }
            m_debugFolder = m_debugFolder.Replace("\\", "/");
            m_debugFolder = m_debugFolder + "/";

            m_bDevicePresent = true;
            SetMatchAndSpoofThresholds();

        }

        public Recursos.Sensor ObtenerSensor(bool silenciarAlertas)
        {
            if (sensorid == null)
            {
                Recursos.LumiSDKWrapper.LumiStatus rc = Recursos.LumiSDKWrapper.LumiStatus.LUMI_STATUS_OK;

                Recursos.LumiSDKWrapper.LUMI_DEVICE sensorConectado = new Recursos.LumiSDKWrapper.LUMI_DEVICE();

                uint nNumDevices = 0;
                uint handle = 0;
                StringBuilder DevList = null;

                rc = Recursos.LumiSDKWrapper.LumiQueryNumberDevices(ref nNumDevices, DevList);

                if (rc != Recursos.LumiSDKWrapper.LumiStatus.LUMI_STATUS_OK)
                {
                    if(!silenciarAlertas)
                        MessageBox.Show("Error de instalacion del sensor de huellas.");
                    return null;
                }

                if (nNumDevices < 1)
                {
                    if (!silenciarAlertas)
                        MessageBox.Show("No se detecto ningun sensor conectado, por favor conecte uno y reinicie el programa.");
                    return null;
                }

                //Obteniendo el primero dispositivo conectado a la computadora
                rc = Recursos.LumiSDKWrapper.LumiQueryDevice(0, ref sensorConectado);

                if (rc != Recursos.LumiSDKWrapper.LumiStatus.LUMI_STATUS_OK)
                    return null;

                rc = Recursos.LumiSDKWrapper.LumiInit(sensorConectado.hDevHandle, ref handle);

                if (rc != Recursos.LumiSDKWrapper.LumiStatus.LUMI_STATUS_OK)
                {
                    if (!silenciarAlertas)
                        MessageBox.Show("No se pudo inicializar el lector de huellas, tal vez esta siendo usado por otra aplicacion.");

                }
                else
                {
                    //Vamos a regresar el primero que encontremos
                    sensorid = new Recursos.Sensor();
                    sensorid.handle = handle;
                    sensorid.SensorType = sensorConectado.SensorType;
                    sensorid.strIdentifier = sensorConectado.strIdentifier;

                    return sensorid;
                }

                return null;
            }
            else
            {
                return sensorid;
            }
        }

        public int PresenceDetectionCallback(IntPtr pImage, int width, int height, uint status)
        {

            if (m_nEnrollmentCaptureIndex != -1) return 0;

            if (ventana.IsDisposed)
            {
                return -2;
            }
            int nSize = width * height * 3; // 24 bpp format is returned from SDK
            byte[] pOutputImage = new byte[nSize];
            Recursos.Sensor sensorid = ObtenerSensor(false);
            Recursos.LumiSDKWrapper.LUMI_CONFIG deviceConfig;
            deviceConfig.eTemplateType = 0;
            deviceConfig.eTransInfo = 0;
            deviceConfig.nTriggerTimeout = 0;
            Recursos.LumiSDKWrapper.LumiGetConfig(sensorid.handle, ref deviceConfig);

            if (sensorid.SensorType == Recursos.LumiSDKWrapper.LUMI_SENSOR_TYPE.M32X)
            {
                System.Drawing.Bitmap bitmap1 = Properties.Resources.CaptureInProgress_M320_resized;
                BitmapData bmpData = bitmap1.LockBits(new Rectangle(0, 0, (int)bitmap1.Width, (int)bitmap1.Height), ImageLockMode.WriteOnly, bitmap1.PixelFormat);
                Marshal.Copy(bmpData.Scan0, pOutputImage, 0, nSize);
            }
            else
            {
                Marshal.Copy(pImage, pOutputImage, 0, nSize);
            }

            SetImage(ref pOutputImage, (uint)width, (uint)height, (int)status, null, 0);

            if (m_bCancelCapture)
            {
                m_bCancelCapture = false;
                ventana.Invoke(ActualizarImagenDelegado, new object[] { null });
                return -2;   // Return -2 to cancel the capture             
            }
            else
            {
                return 0;
            }


        }

        // Overloaded Method to set the image buffer into the Picture box control
        public void SetImage(ref byte[] snapShotRaw, ref byte[] image, uint width, uint height, byte[] pTemplate, uint nTempSz)
        {
            //if (width == 280)
            //{
            //    int breakme = 2;
            //}

            //// If M320, display composite image between 2ed and 3ed enrollment capture - do not show white PD image.
            //if (nEnrollmentCaptureIndex > 1 && width != 280)
            //{
            //    return;
            //}

            //m_nEnrollmentCaptureIndex = nEnrollmentCaptureIndex;

            SetImage(ref image, width, height, -1, pTemplate, nTempSz);
            m_bRawImageBuffer = new byte[snapShotRaw.Length];
            snapShotRaw.CopyTo(m_bRawImageBuffer, 0);

            if (pTemplate != null)
            {
                m_bTemplateBuffer = new byte[pTemplate.Length];
                pTemplate.CopyTo(m_bTemplateBuffer, 0);
            }
            m_nWidth = width;
            m_nHeight = height;
            //Marshal.Copy(snapShotRaw, 0, m_bRawImageBuffer[0], snapShotRaw.Length);
        }

        // Overloaded Method to set the image buffer into the Picture box control
        private void SetImage(ref byte[] image, uint width, uint height, int pdStatus, byte[] pTemplate, uint nTempSz)
        {


            Bitmap bmp = new Bitmap((int)width, (int)height, PixelFormat.Format24bppRgb);



            BitmapData bmpData = bmp.LockBits(
                                 new Rectangle(0, 0, bmp.Width, bmp.Height),
                                 ImageLockMode.WriteOnly, bmp.PixelFormat);

            Marshal.Copy(image, 0, bmpData.Scan0, image.Length);


            if (pTemplate != null)
            {
                bmp.UnlockBits(bmpData);
                DrawMinutiae(ref bmp, ref pTemplate, nTempSz);
                bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                                 ImageLockMode.WriteOnly, bmp.PixelFormat);
            }


            // Get aspect ratios
            float bmpAspectRatio = (float)width / (float)height;
            float imgControlAspectRatio = (float)imgHuella.Width / (float)imgHuella.Height;

            // Correct for aspect ration differnece between img control and bmp
            int widthDisplay = 0, heightDisplay = 0;
            if (Math.Abs((bmpAspectRatio - imgControlAspectRatio) / bmpAspectRatio) > .07)
            {
                if (bmpAspectRatio < 1)
                {
                    widthDisplay = imgHuella.Width;
                    heightDisplay = (int)(imgHuella.Width / bmpAspectRatio);
                }
                else
                {
                    // Currently don't have a sensor that falls into this category, so we'll do nothing.
                }
            }
            else
            {
                widthDisplay = imgHuella.Width;
                heightDisplay = imgHuella.Height;
            }

            bmp.UnlockBits(bmpData);
            // Resize to composite image size and draw arrows 
            ventana.Invoke(ActualizarImagenDelegado, new object[] { ResizeBitmapAndDrawArrows(bmp, widthDisplay, heightDisplay, pdStatus) });
        }

        private void DrawMinutiae(ref Bitmap bmp, ref byte[] template, uint templateSize)
        {
            try
            {
                ////// Get the minutia list
                Recursos.ANSI378TemplateHelper templateHelper = new Recursos.ANSI378TemplateHelper(template, (int)templateSize);
                Recursos.Minutiae[] minutiaeList = templateHelper.GetMinutiaeList();
                ////// Draw minutia on capturedImage.Image
                Graphics g = Graphics.FromImage(bmp);// this.LumiPictureBox1.CreateGraphics();


                Pen pen2;
                SolidBrush brush;

                for (int i = 0; i < minutiaeList.Length; i++)
                {
                    if (minutiaeList[i].nType == 1)
                    {
                        // Line ending minutiae
                        pen2 = new Pen(Color.Red);
                        brush = new SolidBrush(Color.Red);
                    }
                    else
                    {
                        // Bifurcation minutiae
                        pen2 = new Pen(Color.Green);
                        brush = new SolidBrush(Color.Green);
                    }

                    int nX = minutiaeList[i].nX;
                    int nY = minutiaeList[i].nY;

                    g.DrawEllipse(pen2, nX - 3, nY - 3, 6, 6);
                    g.FillEllipse(brush, nX - 3, nY - 3, 6, 6);

                    double nR = minutiaeList[i].nRotAngle;
                    int nX1;
                    int nY1;

                    // Draw the quiver                
                    nX1 = (int)(nX + (15.0 * Math.Cos(nR)));
                    nY1 = (int)(nY - (15.0 * Math.Sin(nR)));
                    g.DrawLine(pen2, nX, nY, nX1, nY1);

                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        public Bitmap ResizeBitmapAndDrawArrows(Bitmap image, int nWidth, int nHeight, int pdStatus)
        {
            Bitmap result = new Bitmap(nWidth, nHeight);
            using (Graphics graphics = Graphics.FromImage((Image)result))
            {
                graphics.DrawImage(image, 0, 0, nWidth, nHeight);
                //DrawArrow(graphics, pdStatus);
            }
            return result;
        }

        public void CaptureCancelled()
        {
            m_bCancelCapture = true;

        }

        public void CaptureTimeOut()
        {
            ventana.Invoke(ActualizarImagenDelegado, new object[] { null });
            //EnableControls();
        }
        public void ComTimeOut()
        {
           ventana.Invoke(ActualizarImagenDelegado, new object[] { null });
            //DisableControls();
        }

        public void EnrollFinished()
        {
            if (m_bComTimeOut == false)
            {
                //EnableEnrollControls();
                //UpdateExistingUserComboBox();
                //updatePictureBox1();
            }

        }

        public void VerifyFinished()
        {
            if (m_bComTimeOut == false)
            {
                //EnableVerifyControls();
            }
        }

        public int AcquStatusCallback(Recursos.LumiSDKWrapper.LUMI_ACQ_STATUS status)
        {

            if (status == Recursos.LumiSDKWrapper.LUMI_ACQ_STATUS.LUMI_ACQ_FINGER_PRESENT) return 0;

            ventana.Invoke(ActualizarMensajeDelegado, new object[] { "" });

            return -2;
        }

        void SetMatchAndSpoofThresholds()
        {
            //if (SensorList.Count == 0)
            //    return;
            Recursos.Sensor currentSensor = ObtenerSensor(false);
            if (currentSensor != null)
            {
                Recursos.LumiSDKWrapper.LumiStatus rc;
                Recursos.LumiSDKWrapper.LUMI_VERSION versInfo = new Recursos.LumiSDKWrapper.LUMI_VERSION();

                switch (currentSensor.SensorType)
                {
                    case Recursos.LumiSDKWrapper.LUMI_SENSOR_TYPE.VENUS:
                        {
                            uint Handle = 0;
                            Handle = currentSensor.handle;
                            rc = Recursos.LumiSDKWrapper.LumiGetVersionInfo(Handle, ref versInfo);
                            if (rc != Recursos.LumiSDKWrapper.LumiStatus.LUMI_STATUS_OK)
                                return;
                            uint version = Convert.ToUInt32(versInfo.fwrVersion);
                            uint deviceType = Convert.ToUInt32(versInfo.tnsVersion);

                            if (version > 21304)
                            {
                                if (m_MatchThreshold_HighlySecured)
                                    m_MatchThreshold = 27532;
                                else if (m_MatchThreshold_Secured)
                                    m_MatchThreshold = 23688;
                                else
                                    m_MatchThreshold = 20646;

                                if (m_SpoofThreshold_HighlySecured)
                                    m_SpoofThreshold = 5;
                                else if (m_SpoofThreshold_Secured)
                                    m_SpoofThreshold = 150;
                                else
                                    m_SpoofThreshold = 1050;
                            }
                            else if (version == 21304)
                            {
                                if (m_MatchThreshold_HighlySecured)
                                    m_MatchThreshold = 24298;
                                else if (m_MatchThreshold_Secured)
                                    m_MatchThreshold = 22418;
                                else
                                    m_MatchThreshold = 21548;

                                if (m_SpoofThreshold_HighlySecured)
                                    m_SpoofThreshold = 5;
                                else if (m_SpoofThreshold_Secured)
                                    m_SpoofThreshold = 150;
                                else
                                    m_SpoofThreshold = 1050;
                            }
                            else if (version <= 9538)
                            {
                                if (deviceType == 61)
                                {
                                    if (m_MatchThreshold_HighlySecured)
                                        m_MatchThreshold = 24298;
                                    else if (m_MatchThreshold_Secured)
                                        m_MatchThreshold = 22418;
                                    else
                                        m_MatchThreshold = 21548;

                                    if (m_SpoofThreshold_HighlySecured)
                                        m_SpoofThreshold = 100;
                                    else if (m_SpoofThreshold_Secured)
                                        m_SpoofThreshold = 200;
                                    else
                                        m_SpoofThreshold = 1000;

                                }
                                else
                                {
                                    if (m_MatchThreshold_HighlySecured)
                                        m_MatchThreshold = 24298;
                                    else if (m_MatchThreshold_Secured)
                                        m_MatchThreshold = 22418;
                                    else
                                        m_MatchThreshold = 21548;

                                    if (m_SpoofThreshold_HighlySecured)
                                        m_SpoofThreshold = 100;
                                    else if (m_SpoofThreshold_Secured)
                                        m_SpoofThreshold = 200;
                                    else
                                        m_SpoofThreshold = 1000;
                                }

                            }

                        }
                        break;
                    case Recursos.LumiSDKWrapper.LUMI_SENSOR_TYPE.V31X:
                    case Recursos.LumiSDKWrapper.LUMI_SENSOR_TYPE.V371:
                        {
                            if (m_MatchThreshold_HighlySecured)
                                m_MatchThreshold = 24739;
                            else if (m_MatchThreshold_Secured)
                                m_MatchThreshold = 21493;
                            else
                                m_MatchThreshold = 16873;

                            if (m_SpoofThreshold_HighlySecured)
                                m_SpoofThreshold = 5;
                            else if (m_SpoofThreshold_Secured)
                                m_SpoofThreshold = 150;
                            else
                                m_SpoofThreshold = 1050;

                        }
                        break;
                    case Recursos.LumiSDKWrapper.LUMI_SENSOR_TYPE.M300:
                        {
                            if (m_MatchThreshold_HighlySecured)
                                m_MatchThreshold = 29990;
                            else if (m_MatchThreshold_Secured)
                                m_MatchThreshold = 27520;
                            else
                                m_MatchThreshold = 26350;

                            if (m_SpoofThreshold_HighlySecured)
                                m_SpoofThreshold = 100;
                            else if (m_SpoofThreshold_Secured)
                                m_SpoofThreshold = 200;
                            else
                                m_SpoofThreshold = 1000;

                        }
                        break;
                    case Recursos.LumiSDKWrapper.LUMI_SENSOR_TYPE.M100:
                        {
                            if (m_MatchThreshold_HighlySecured)
                                m_MatchThreshold = 22418;
                            else if (m_MatchThreshold_Secured)
                                m_MatchThreshold = 22000;
                            else
                                m_MatchThreshold = 15000;

                            if (m_SpoofThreshold_HighlySecured)
                                m_SpoofThreshold = 100;
                            else if (m_SpoofThreshold_Secured)
                                m_SpoofThreshold = 200;
                            else
                                m_SpoofThreshold = 1000;

                        }
                        break;
                    case Recursos.LumiSDKWrapper.LUMI_SENSOR_TYPE.M32X:
                        {
                            if (m_MatchThreshold_HighlySecured)
                                m_MatchThreshold = 30762;
                            else if (m_MatchThreshold_Secured)
                                m_MatchThreshold = 26368;
                            else
                                m_MatchThreshold = 25331;

                            if (m_SpoofThreshold_HighlySecured)
                                m_SpoofThreshold = 100;
                            else if (m_SpoofThreshold_Secured)
                                m_SpoofThreshold = 200;
                            else
                                m_SpoofThreshold = 1000;

                        }
                        break;
                    case Recursos.LumiSDKWrapper.LUMI_SENSOR_TYPE.M31X:
                        {
                            if (m_MatchThreshold_HighlySecured)
                                m_MatchThreshold = 31448;
                            else if (m_MatchThreshold_Secured)
                                m_MatchThreshold = 26728;
                            else
                                m_MatchThreshold = 25668;

                            if (m_SpoofThreshold_HighlySecured)
                                m_SpoofThreshold = 100;
                            else if (m_SpoofThreshold_Secured)
                                m_SpoofThreshold = 200;
                            else
                                m_SpoofThreshold = 1000;

                        }
                        break;
                    default:
                        {
                        }
                        break;
                }
            }
        }


       
    }
}
