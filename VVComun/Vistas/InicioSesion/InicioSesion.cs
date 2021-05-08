using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerdeComun.Programacion;

namespace ValleVerdeComun.Vistas.InicioSesion
{
    public delegate void DelegateObtenerResultadoVerificacion(Programacion.Huellas.ResultadoHuella usuario);
    

    public partial class InicioSesion : Form
    {
        // Use kernel32.dll to load the LumiAPI.dll manually.
        // This gets around the issue of the DllImport search
        // path rule that prevents relative paths.
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr LoadLibrary(string lpFileName);
        bool habilitarHuella = false;

        Programacion.Huellas.Verificar verifyWithPresDetect;
        Programacion.InicioSesion.InicioSesion objIniSes = new Programacion.InicioSesion.InicioSesion();
        public Programacion.Huellas.ResultadoHuella usuario;
        bool debeSerAdministrador;
        public bool m_bClosingApp;
        public bool debeSerUsuarioQuePuedeDesbloquearCajar = false;

        public DelegateObtenerResultadoVerificacion ObtenerResultadoVerificacion;
        public Programacion.Huellas.DelegateActualizarImagen ActualizarImagenDelegado;
        public Programacion.Huellas.DelegateActualizarMensaje ActualizarMensajeDelegado;

        private string idUsuarioNecesario = "-1";

        public InicioSesion(bool debeSerAdministrador)
        {
            

            InitializeComponent();

            this.debeSerAdministrador = debeSerAdministrador;

            LoadLumiSDK();

            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            m_bClosingApp = false;

            ObtenerResultadoVerificacion = new DelegateObtenerResultadoVerificacion(this.ResultadoVerificacion);
            ActualizarImagenDelegado = new Programacion.Huellas.DelegateActualizarImagen(this.ActualizarImagenLector);
            ActualizarMensajeDelegado = new Programacion.Huellas.DelegateActualizarMensaje(this.ActualizarMensajeLector);

            Shown += Form1_Shown;

        }

        public void SetUsuarioNecesario(string idUsuarioNecesario,string nombre)
        {
            //Debe ser este usuario o un administrador, como resultado regresare a este usuario
            this.idUsuarioNecesario = idUsuarioNecesario;
            this.lblUsuarioNecesario.Visible = true;
            this.lblUsuarioNecesario.Text = "*Debes ingresar como administrador o "+nombre+" para continuar.";
        }

        private void LoadLumiSDK()
        {
            Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string strCurDir = Environment.CurrentDirectory;

            string strLumiAPIDLL = strCurDir + "\\SDK-L\\bin\\LumiAPI.dll";

            IntPtr pDll = IntPtr.Zero;

            pDll = LoadLibrary(strLumiAPIDLL);

            //IntPtr pDll = IntPtr.Zero;
            //pDll = LoadLibrary("C:\\Program Files (x86)\\HID Global\\Lumidigm Release v6.01.26\\SDK\\bin\\LumiAPI.dll");
            
            if (pDll != IntPtr.Zero)
            {
                habilitarHuella = true;

                //Checar si hay un sensor conectado
                if (new Programacion.Huellas.HuellaCodigoComun().ObtenerSensor(true) == null)
                {
                    habilitarHuella = false;
                    Console.WriteLine("No se pudo encontrar lectores conectados.");
                }
            }

            else
            {
                habilitarHuella = false;
                Console.WriteLine("No se pudo encontrar LumiAPI.dll en el sistema.");
            }

        }

        private void InicioSesion_Load(object sender, EventArgs e)
        {
            new BuscadorComboBox(this, comboBox1);

            //Registramos el evento de la tecla 'Enter'
            comboBox1.KeyDown += new KeyEventHandler(tb_KeyDown);
            textBox1.KeyDown += new KeyEventHandler(tb_KeyDown);
            roundedButton1.KeyDown += new KeyEventHandler(tb_KeyDown);

            

            //Cargar usuarios
            CargarUsuarios();

            if (habilitarHuella)
            {
                //Iniciar lectura del dedo
                VerificarHuella();
            }
            else
            {
                //Ocultar controles
                panelHuella.Visible = false;
                this.Width = 383;
                lblTitulo.Text = "Ingresa tus datos para iniciar sesion en el sistema";
                this.CenterToScreen();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Focus();
            this.Activate();


            comboBox1.SelectAll();
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((comboBox1.Text.Length == 0 || textBox1.Text.Length == 0) && btnRetry.Visible == true)
                    btnRetry.PerformClick();
                else
                    if (comboBox1.Focused)
                        textBox1.Focus();
                    else
                        if (textBox1.Focused)
                            roundedButton1.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;

            }
           
        }

        private void CargarUsuarios()
        {
            List<Usuario> usuarios = new Usuarios().ObtenerUsuarios();

            if (usuarios != null)
                foreach (Usuario usuario in usuarios)
                    if (usuario.usuario != "")
                    {
                        if (debeSerUsuarioQuePuedeDesbloquearCajar)
                        {
                            if (new Usuarios().ObtenerPermisosUsuario(usuario.idUsuario).DesbloquearCaja)
                            {
                                if (debeSerAdministrador)
                                {
                                    if (usuario.esAdministrador)
                                        comboBox1.Items.Add(usuario.usuario);
                                    else
                                        comboBox1.Items.Add(usuario.usuario);
                                }
                                else
                                    comboBox1.Items.Add(usuario.usuario);
                            }
                        }
                        else
                        {
                            if (debeSerAdministrador)
                            {
                                if (usuario.esAdministrador)
                                    comboBox1.Items.Add(usuario.usuario);
                                else
                                    comboBox1.Items.Add(usuario.usuario);
                            }
                            else
                                comboBox1.Items.Add(usuario.usuario);
                        }
                    }
        }

        public void VerificarHuella()
        {
            Thread thread = new Thread(new ThreadStart(HiloVerificarHuella));
            thread.Start();
        }

        public void HiloVerificarHuella()
        {
            verifyWithPresDetect = new Programacion.Huellas.Verificar(this, debeSerAdministrador,idUsuarioNecesario);
            verifyWithPresDetect.Run();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnRetry.Visible = false;
            VerificarHuella();
        }

        private void ResultadoVerificacion(Programacion.Huellas.ResultadoHuella usuario)
        {
            if (usuario != null)
            {
                //Guardar el usuario por si la ventana que me invovo necesita de el
 
                this.usuario = usuario;
                this.Hide();
            }
            else
            {
                btnRetry.Visible = true;
            }
        }

        private void ActualizarImagenLector(Image imagen)
        {
            imgHuella.Image = imagen;
        }

        private void ActualizarMensajeLector(String mensaje)
        {
            txtMensaje.Text = mensaje;
        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            m_bClosingApp = true;
            // Determine if text has changed in the textbox by comparing to original text.
            if (verifyWithPresDetect != null )
            {
                verifyWithPresDetect.CloseScanner();
            }
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            Programacion.Huellas.ResultadoHuella usuario = objIniSes.VerificarUsuarioContrasena(comboBox1.Text, textBox1.Text,debeSerAdministrador,idUsuarioNecesario);

            if (usuario != null)
            {
                //Guardar el usuario por si la ventana que me invovo necesita de el

                this.usuario = usuario;

                //Cerrar el lector para evitar errores
                m_bClosingApp = true;

                if (verifyWithPresDetect != null)
                {
                    verifyWithPresDetect.CloseScanner();
                }
                this.Hide();

            }
            else
            {
                MessageBox.Show("Verificar usuario y contraseña.");
                textBox1.Text = "";
                textBox1.SelectAll();
            }
        }
    }
}
