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

namespace ValleVerdeComun.Vistas.RegistrarHuella
{
    public delegate void DelegateCerrarVentana();


    public partial class RegistrarHuella : Form
    {
        public bool m_bClosingApp;

        public DelegateCerrarVentana CerrarVentana;
        public Programacion.Huellas.DelegateActualizarImagen ActualizarImagenDelegado;
        public Programacion.Huellas.DelegateActualizarMensaje ActualizarMensajeDelegado;

        private string idUsuario;

        public RegistrarHuella(string idUsuario)
        {
            InitializeComponent();

            CerrarVentana = new DelegateCerrarVentana(this.CerrarVentanaMetodo);
            ActualizarImagenDelegado = new Programacion.Huellas.DelegateActualizarImagen(this.ActualizarImagenLector);
            ActualizarMensajeDelegado = new Programacion.Huellas.DelegateActualizarMensaje(this.ActualizarMensajeLector);

            this.idUsuario = idUsuario;
        }

        public void CerrarVentanaMetodo()
        {
            this.Close();
        }

        private void RegistrarHuella_Load(object sender, EventArgs e)
        {

        }

        private void ActualizarImagenLector(Image imagen)
        {
            imgHuella.Image = imagen;
        }

        private void ActualizarMensajeLector(String mensaje)
        {
            txtMensaje.Text = mensaje;
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ProcesoRegistrarHuella));
            thread.Start();
            
        }

        public void ProcesoRegistrarHuella()
        {
            if (idUsuario != "")
            {
                Programacion.Huellas.Registrar registrarHuellas = new Programacion.Huellas.Registrar(this, idUsuario);
                registrarHuellas.Run();

                
            }
        }
    }
}
