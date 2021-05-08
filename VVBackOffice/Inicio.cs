using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Data.SqlClient;

namespace ValleVerde
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            this.TransparencyKey = Color.Turquoise;
            this.BackColor = Color.Turquoise;

            FormBorderStyle = FormBorderStyle.None;

            this.Shown += new EventHandler(Form1_Shown);
        }

        private void Form1_Shown(Object sender, EventArgs e)
        {
            this.Refresh();
            //Verificar si ya esta configurada la caja, si no es asi correo el asistente de configuracion primero
            string path = Directory.GetCurrentDirectory();
            string target = "configuracionBO.json";
            if (!File.Exists(target))
            {
                //Ejecutar el asistente de configuracion

                //Se cargan las configuraciones basicas pre-configuradas
                ValleVerdeComun.Programacion.ConfiguracionBO settings = ValleVerdeComun.Programacion.ConfiguracionBO.Load();
                
                

                //Permite modificar las configuraciones
                new Vistas.ConfigurarPrograma(settings).ShowDialog();
                this.Visible = false;

                //Guarda las configuraciones elegidas por el usuario
                settings.Save();

                AbrirBackOffoce();

                this.Close();
            }
            else
            {

                //Ya esta configurada la caja, abrir inicio de sesion y posterior a form1 


                AbrirBackOffoce();
                
                this.Close();

            }
        }

        public void AbrirBackOffoce()
        {
            //Cargar archivo de configuracion y obtener nombre del servidor, usuario y contraseña
            ValleVerdeComun.Programacion.ConfiguracionBO settings = ValleVerdeComun.Programacion.ConfiguracionBO.Load();

            //Probar la conexion para poder continuar
            if (ProbarConexion(settings.Servidor))
            {
                ValleVerdeComun.Vistas.InicioSesion.InicioSesion obi = new ValleVerdeComun.Vistas.InicioSesion.InicioSesion(false);
                obi.ShowDialog();

                ValleVerdeComun.Programacion.Huellas.ResultadoHuella usuario = obi.usuario;

                obi.Close();

                this.Visible = false;

                if (usuario != null)
                    new Formulario(usuario, settings).ShowDialog();
            }
        }

        private bool ProbarConexion(string servidor)
        {
            string connetionString = "Data Source=" + servidor + ";Initial Catalog=valleverde;User Id=usuario1;Password=cotija20";
            //connetionString = "Data Source=JORGEGABRIEAFFC;Initial Cata log=valleverde;Trusted_Connection=True;";
            //connetionString = "Data Source=192.168.1.1,1400;Initial Catalog=valleverde;User Id=usuario1;Password=valleverde";
            SqlConnection cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                //MessageBox.Show("Conexion exitosa");
                cnn.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar con el servidor.");
                return false;
            }
        }
    }
}
