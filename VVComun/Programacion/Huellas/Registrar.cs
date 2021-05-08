using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerdeComun.Programacion.Huellas
{
    class Registrar
    {
        private string idUsuario = "-1";

        private Recursos.LumiSDKWrapper.LumiStatus _rc;
        private string _statusMessage;
        private uint _hHandle = 0;
        Recursos.Sensor lectorHuellas;

        HuellaCodigoComun obh;
        Vistas.RegistrarHuella.RegistrarHuella inicioSesionForm;

        public Registrar(Vistas.RegistrarHuella.RegistrarHuella inicioSesionForm, string idUsuario)
        {
            this.inicioSesionForm = inicioSesionForm;
            this.idUsuario = idUsuario;

            obh = new HuellaCodigoComun(inicioSesionForm, inicioSesionForm.ActualizarImagenDelegado, inicioSesionForm.ActualizarMensajeDelegado, inicioSesionForm.imgHuella);
            lectorHuellas = obh.ObtenerSensor(false);
            if (lectorHuellas != null)
                _hHandle = lectorHuellas.handle;



        }

        public void Run()
        {
            if (lectorHuellas != null)
            {
                //Habilitar esta linea
                //this.registrarHuellaForm.btnRegistrar.Enable = false;
                uint width = 0, height = 0;
                int nSpoof = 0;
                GetWidthAndHeight(ref width, ref height);
                byte[] snapShot24bpp = new byte[width * height * 3]; // multiply by 3 to get 24bppRgb format
                byte[] template1 = new byte[5000]; //array to hold the template
                byte[] template2 = new byte[5000]; //array to hold the template
                byte[] template3 = new byte[5000]; //array to hold the template


                uint templateLen1 = 0;
                uint templateLen2 = 0;
                uint templateLen3 = 0;

                uint nMatchScore1 = 0;
                uint nMatchScore2 = 0;
                uint nMatchScore3 = 0;

                int nSpoofScore = 0;

                Recursos.LumiSDKWrapper.LumiPresenceDetectCallbackDelegate del = new Recursos.LumiSDKWrapper.LumiPresenceDetectCallbackDelegate(obh.PresenceDetectionCallback);

                Recursos.LumiSDKWrapper.LUMI_PROCESSING_MODE processingMode;
                processingMode.bExtract = 0;
                processingMode.bLatent = 0;
                processingMode.bSpoof = 0;
                Recursos.LumiSDKWrapper.LumiStatus pStatus = Recursos.LumiSDKWrapper.GetProcessingMode(_hHandle, ref processingMode);
                if (pStatus != Recursos.LumiSDKWrapper.LumiStatus.LUMI_STATUS_OK)
                {
                    MessageBox.Show("Enrollment failed. Unable to Set the Spoof detection mode");
                    //Habilitar esta linea
                    //this.registrarHuellaForm.btnRegistrar.Enable = false;
                    return;
                }

                if (obh.m_bSpoofEnabled == true)
                    processingMode.bSpoof = 1;
                else
                    processingMode.bSpoof = 0;

                pStatus = Recursos.LumiSDKWrapper.SetProcessingMode(_hHandle, processingMode);
                if (pStatus != Recursos.LumiSDKWrapper.LumiStatus.LUMI_STATUS_OK)
                {
                    MessageBox.Show("Enrollment failed. Unable to Set the Spoof detection mode");
                    //Habilitar esta linea
                    //this.registrarHuellaForm.btnRegistrar.Enable = false;
                    return;
                }
                //////////////////////////////////
                inicioSesionForm.Invoke(inicioSesionForm.ActualizarMensajeDelegado, new object[] { "Coloca el dedo en el sensor para comenzar el registro." });
                if (EnrollAndDisplay(0, snapShot24bpp, template1, ref templateLen1, width, height, ref nSpoof, del) == false)
                {
                    obh.EnrollFinished();
                    //Habilitar esta linea
                    //this.registrarHuellaForm.btnRegistrar.Enable = false;
                    return;
                }
                if (inicioSesionForm.m_bClosingApp == true)
                {
                    CloseScanner();
                    //Habilitar esta linea
                    //this.registrarHuellaForm.btnRegistrar.Enable = false;
                    return;
                }

                /////////////

                if (obh.m_bSpoofEnabled == true)
                {
                    if (nSpoof > 1050)
                    {
                        inicioSesionForm.Invoke(inicioSesionForm.ActualizarMensajeDelegado, new object[] { "Enrollment failed. Please enroll with real finger" });
                        obh.EnrollFinished();
                        //Habilitar esta linea
                        //this.registrarHuellaForm.btnRegistrar.Enable = false;
                        return;
                    }

                }

                // Force Finger Lift between enrollment insertions
                inicioSesionForm.Invoke(inicioSesionForm.ActualizarMensajeDelegado, new object[] { "Please lift finger and place again" });
                ForceFingerLift();


                inicioSesionForm.Invoke(inicioSesionForm.ActualizarMensajeDelegado, new object[] { "Coloca por segunda vez el dedo en el lector." });
                if (EnrollAndDisplay(1, snapShot24bpp, template2, ref templateLen2, width, height, ref nSpoof, del) == false)
                {
                    obh.EnrollFinished();
                    //Habilitar esta linea
                    //this.registrarHuellaForm.btnRegistrar.Enable = false;
                    return;
                }
                if (inicioSesionForm.m_bClosingApp == true)
                {
                    CloseScanner();
                    //Habilitar esta linea
                    //this.registrarHuellaForm.btnRegistrar.Enable = false;
                    return;
                }

                if (obh.m_bSpoofEnabled == true)
                {
                    if (nSpoof > 1050)
                    {
                        inicioSesionForm.Invoke(inicioSesionForm.ActualizarMensajeDelegado, new object[] { "Fallo el registro de huella. Por favor registrar un dedo real." });
                        obh.EnrollFinished();
                        //Habilitar esta linea
                        //this.registrarHuellaForm.btnRegistrar.Enable = false;
                        return;
                    }

                }

                Recursos.LumiSDKWrapper.LumiMatch(_hHandle, template1, ref templateLen1, template2, ref templateLen2, ref nMatchScore1, ref nSpoofScore);

                if (nMatchScore1 < obh.m_MatchThreshold)
                {
                    inicioSesionForm.Invoke(inicioSesionForm.ActualizarMensajeDelegado, new object[] { "Fallo el registro de huella. Por favor use el mismo dedo." });
                    obh.EnrollFinished();
                    //Habilitar esta linea
                    //this.registrarHuellaForm.btnRegistrar.Enable = false;
                    return;
                }

                // Force Finger Lift between enrollment insertions
                inicioSesionForm.Invoke(inicioSesionForm.ActualizarMensajeDelegado, new object[] { "Por favor levante y coloque el dedo nuevamente" });
                ForceFingerLift();

                inicioSesionForm.Invoke(inicioSesionForm.ActualizarMensajeDelegado, new object[] { "Coloca por tercera vez el dedo en el lector." });
                if (EnrollAndDisplay(2, snapShot24bpp, template3, ref templateLen3, width, height, ref nSpoof, del) == false)
                {
                    obh.EnrollFinished();
                    //Habilitar esta linea
                    //this.registrarHuellaForm.btnRegistrar.Enable = false;
                    return;
                }
                if (inicioSesionForm.m_bClosingApp == true)
                {
                    CloseScanner();
                    //Habilitar esta linea
                    //this.registrarHuellaForm.btnRegistrar.Enable = false;
                    return;
                }
                if (obh.m_bSpoofEnabled == true)
                {
                    if (nSpoof > 1050)
                    {
                        inicioSesionForm.Invoke(inicioSesionForm.ActualizarMensajeDelegado, new object[] { "Fallo el registro de huella. Por favor registrar un dedo real." });
                        obh.EnrollFinished();
                        //Habilitar esta linea
                        //this.registrarHuellaForm.btnRegistrar.Enable = false;
                        return;
                    }

                }

                ///////////////
                Recursos.LumiSDKWrapper.LumiMatch(_hHandle, template2, ref templateLen2, template3, ref templateLen3, ref nMatchScore2, ref nSpoofScore);

                if (nMatchScore2 < obh.m_MatchThreshold)
                {
                    inicioSesionForm.Invoke(inicioSesionForm.ActualizarMensajeDelegado, new object[] { "Fallo el registro de huella. Por favor use el mismo dedo." });
                    obh.EnrollFinished();
                    //Habilitar esta linea
                    //this.registrarHuellaForm.btnRegistrar.Enable = false;
                    return;
                }
                Recursos.LumiSDKWrapper.LumiMatch(_hHandle, template1, ref templateLen1, template3, ref templateLen3, ref nMatchScore3, ref nSpoofScore);

                //Crear el objeto que las guardara en BD
                ValleVerdeComun.Programacion.Huellas.BaseDatos.Huellas obhBD = new ValleVerdeComun.Programacion.Huellas.BaseDatos.Huellas();

                if (nMatchScore1 > nMatchScore2)
                {
                    if (nMatchScore1 > nMatchScore3)
                    {
                        if (nMatchScore2 > nMatchScore3)
                        {
                            //Guardar en BD
                            //MessageBox.Show("voy a guardar: "+template2.ToString()+" y: "+templateLen2);
                            //m_form.m_currentSubject.addData(template2, templateLen2, m_form.m_CurrentHotSpot);
                            obhBD.AltaNuevaHuella(idUsuario, template2, templateLen2);
                        }
                        else
                        {
                            //Guardar en BD
                            //MessageBox.Show("voy a guardar: " + template1.ToString() + " y: " + templateLen1);
                            //m_form.m_currentSubject.addData(template1, templateLen1, m_form.m_CurrentHotSpot);
                            obhBD.AltaNuevaHuella(idUsuario, template1, templateLen1);
                        }

                    }
                    else
                    {
                        //Guardar en BD
                        //MessageBox.Show("voy a guardar: " + template1.ToString() + " y: " + templateLen1);
                        //m_form.m_currentSubject.addData(template1, templateLen1, m_form.m_CurrentHotSpot);
                        obhBD.AltaNuevaHuella(idUsuario, template1, templateLen1);
                    }


                }
                else
                {
                    if (nMatchScore2 > nMatchScore3)
                    {
                        if (nMatchScore1 > nMatchScore3)
                        {
                            //Guardar en BD
                            //MessageBox.Show("voy a guardar: " + template2.ToString() + " y: " + templateLen2);
                            //m_form.m_currentSubject.addData(template2, templateLen2, m_form.m_CurrentHotSpot);
                            obhBD.AltaNuevaHuella(idUsuario, template2, templateLen2);
                        }
                        else
                        {
                            //Guardar en BD
                            //MessageBox.Show("voy a guardar: " + template3.ToString() + " y: " + templateLen3);
                            // m_form.m_currentSubject.addData(template3, templateLen3, m_form.m_CurrentHotSpot);
                            obhBD.AltaNuevaHuella(idUsuario, template3, templateLen3);
                        }
                    }
                    else
                    {
                        //Guardar en BD
                        //MessageBox.Show("voy a guardar: " + template3.ToString() + " y: " + templateLen3);
                        //m_form.m_currentSubject.addData(template3, templateLen3, m_form.m_CurrentHotSpot);
                        obhBD.AltaNuevaHuella(idUsuario, template3, templateLen3);
                    }

                }

                inicioSesionForm.Invoke(inicioSesionForm.ActualizarMensajeDelegado, new object[] { "Registro exitoso" });

                obh.EnrollFinished();
                CloseScanner();

                inicioSesionForm.Invoke(inicioSesionForm.CerrarVentana, new object[] { });
                //Habilitar esta linea
                //this.registrarHuellaForm.btnRegistrar.Enable = false;
            }
        }
        public void GetWidthAndHeight(ref uint width, ref uint height)
        {
            try
            {
                uint nBPP = 0, nDPI = 0;
                _rc = Recursos.LumiSDKWrapper.LumiGetImageParams(_hHandle, ref width, ref height, ref nBPP, ref nDPI);
                if (_rc != Recursos.LumiSDKWrapper.LumiStatus.LUMI_STATUS_OK)
                {
                    throw new Exception("FAIL: lumiGetImageSize");
                }
                else
                {
                    _statusMessage += "PASS: Image Size = " + width.ToString() + " X " + height.ToString() + "\r\n";
                }

            }
            catch (Exception err)
            {
                _statusMessage += "An Error occured: " + err.ToString() + "\r\n";
                throw err;
            }
            finally { }
        }

        public bool EnrollAndDisplay(int nEnrollmentCaptureIndex, byte[] snapShot24bppPointer, byte[] template1Pointer, ref uint templateSize, uint width, uint height, ref int nSpoof, Recursos.LumiSDKWrapper.LumiPresenceDetectCallbackDelegate callbackFunc)
        {
            uint nNFIQ = 0;
            byte[] snapShot = new byte[width * height];
            Recursos.LumiSDKWrapper.LumiStatus Status = EnrollImage(snapShot, snapShot24bppPointer, template1Pointer, ref templateSize, width, height, ref nSpoof, callbackFunc, ref nNFIQ);

            if (inicioSesionForm.m_bClosingApp == true)
            {
                CloseScanner();
                return false;
            }


            /*if (m_form.m_bNISTQuality == true)
            {
                m_form.Invoke(m_form.m_DelegateNISTStatus, new object[] { "NIST Quality = " + nNFIQ.ToString(), m_form.Blue });
                m_form.Invoke(m_form.m_DelegateSetNISTImage, new object[] { nNFIQ });

            }
            else
            {
                m_form.Invoke(m_form.m_DelegateNISTStatus, new object[] { "", m_form.Blue });
            }*/
            if (Status == Recursos.LumiSDKWrapper.LumiStatus.LUMI_STATUS_CANCELLED_BY_USER)
            {
                obh.CaptureCancelled();
                inicioSesionForm.Invoke(inicioSesionForm.ActualizarMensajeDelegado, new object[] { "Enroll Cancelled by User" });
                return false;
            }

            if (Status == Recursos.LumiSDKWrapper.LumiStatus.LUMI_STATUS_ERROR_TIMEOUT)
            {
                obh.CaptureTimeOut();
                inicioSesionForm.Invoke(inicioSesionForm.ActualizarMensajeDelegado, new object[] { "Sensor Time Out. " });

                return false;
            }
            if (Status == Recursos.LumiSDKWrapper.LumiStatus.LUMI_STATUS_ERROR_TIMEOUT_LATENT)
            {
                obh.CaptureTimeOut();
                inicioSesionForm.Invoke(inicioSesionForm.ActualizarMensajeDelegado, new object[] { "Sensor Latent Time Out.\nPlease lift the finger and then place again" });
                return false;
            }
            if (Status == Recursos.LumiSDKWrapper.LumiStatus.LUMI_STATUS_ERROR_SENSOR_COMM_TIMEOUT)
            {
                obh.m_bComTimeOut = true;
                obh.ComTimeOut();
                inicioSesionForm.Invoke(inicioSesionForm.ActualizarMensajeDelegado, new object[] { "Sensor Communication Time Out.\n Please re-connect the device and restart the application" });
                return false;
            }

            obh.SetImage(ref snapShot, ref snapShot24bppPointer, (uint)width, (uint)height, template1Pointer, templateSize);
            GC.KeepAlive(callbackFunc);

            return true;
        }

        public Recursos.LumiSDKWrapper.LumiStatus EnrollImage(byte[] snapShot, byte[] snapShot24bppPointer, byte[] template1Pointer, ref uint templateSize, uint width, uint height, ref int spoof, Recursos.LumiSDKWrapper.LumiPresenceDetectCallbackDelegate callbackFunc, ref uint nNFIQ)
        {
            try
            {
                //byte[] snapShot = new byte[width * height]; // Array to hold raw data 8 bpp format 

                // Make sure Presence Detection is on.
                // Because we need another definition for LumiSetOption, we call the SetPresenceDetectionMode
                // static method on the object LumiSDKLumiSetOption.  This is because the LumiSDKWrapper
                // has the LumiSetOption defined to take the LumiPresenceDetectCallbackDelegate argument while for
                // setting PD mode, we need it to take an integer pointer argument instead.
                if (obh.m_bSensorTriggerArmed == true)
                {
                    Recursos.LumiSDKLumiSetOption.SetPresenceDetectionMode(_hHandle, Recursos.LumiSDKWrapper.LUMI_PRES_DET_MODE.LUMI_PD_ON);
                }
                else
                {
                    Recursos.LumiSDKLumiSetOption.SetPresenceDetectionMode(_hHandle, Recursos.LumiSDKWrapper.LUMI_PRES_DET_MODE.LUMI_PD_OFF);
                }

                // Set the address of the presence detection callback function   
                IntPtr prtDel = Marshal.GetFunctionPointerForDelegate(callbackFunc);
                _rc = Recursos.LumiSDKWrapper.LumiSetOption(_hHandle, Recursos.LumiSDKWrapper.LUMI_OPTIONS.LUMI_OPTION_SET_PRESENCE_DET_CALLBACK, prtDel, (uint)IntPtr.Size);
                _rc = Recursos.LumiSDKWrapper.LumiSetDCOptions(_hHandle, obh.m_debugFolder, 0);
                _rc = Recursos.LumiSDKWrapper.LumiCaptureEx(_hHandle, snapShot, template1Pointer, ref templateSize, ref spoof, null);


                if (_rc != Recursos.LumiSDKWrapper.LumiStatus.LUMI_STATUS_OK)
                {
                    return _rc;
                }
                else
                {
                    _statusMessage += "PASS: lumiCaptureProcess rc = " + _rc + " spoof = " + spoof + "\r\n";
                }

                //GetNISTScore(snapShot, ref nNFIQ);

                Recursos.LumiSDKWrapper.LumiSetOption(_hHandle, Recursos.LumiSDKWrapper.LUMI_OPTIONS.LUMI_OPTION_SET_PRESENCE_DET_CALLBACK, IntPtr.Zero, (uint)IntPtr.Size); // size of int is 4

                ConvertRawImageTo24bpp(snapShot24bppPointer, snapShot, snapShot.Length);

                return _rc;
            }
            catch (Exception err)
            {
                _statusMessage += "An Error occured: " + err.ToString() + "\r\n";
                throw err;
            }
            finally { }
        }

        public void ConvertRawImageTo24bpp(byte[] snapShot24bppPointer, byte[] snapshotPointer, int snapShotLength)
        {
            int innerOffset = 0;
            for (int offset = 0; offset < snapShotLength; offset++)
            {
                for (int counter = 1; counter <= 3; counter++)
                {
                    snapShot24bppPointer[innerOffset] = snapshotPointer[offset];
                    innerOffset += 1;
                }
            }
        }

        public void CloseScanner()
        {
            try
            {
                _rc = Recursos.LumiSDKWrapper.LumiClose(_hHandle);
                _rc = Recursos.LumiSDKWrapper.LumiExit();
            }
            catch (Exception err)
            {
                _statusMessage += "An Error occured: " + err.ToString() + "  _rc = " + _rc + "\r\n";
                throw err;
            }
            finally { }
        }

        public void ForceFingerLift()
        {
            Recursos.LumiSDKWrapper.LumiAcqStatusCallbackDelegate del = new Recursos.LumiSDKWrapper.LumiAcqStatusCallbackDelegate(obh.AcquStatusCallback);

            Recursos.LumiSDKWrapper.LUMI_ACQ_STATUS nStatus = Recursos.LumiSDKWrapper.LUMI_ACQ_STATUS.LUMI_ACQ_BUSY;

            Recursos.LumiSDKWrapper.LumiStatus rc = Recursos.LumiSDKWrapper.LumiDetectFinger(_hHandle, ref nStatus, del);

            if (rc != Recursos.LumiSDKWrapper.LumiStatus.LUMI_STATUS_OK)
            {
                return;
            }
        }
    }

}
