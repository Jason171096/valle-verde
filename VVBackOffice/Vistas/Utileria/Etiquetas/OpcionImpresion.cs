using System;
using System.Drawing;
using System.Windows.Forms;
using ValleVerde.Programacion;

namespace ValleVerde.Vistas.Utileria
{
    public partial class OpcionImpresion : Form
    {

        ValleVerdeComun.Programacion.ConfiguracionBO configuracion;
        public OpcionImpresion(ValleVerdeComun.Programacion.ConfiguracionBO configuracion, bool showPic)
        {
            InitializeComponent();
            this.configuracion = configuracion;
            if (showPic)
                picEtiquetasNoImpresas.Visible = true;
            else
                picEtiquetasNoImpresas.Visible = false;
        }

        private void btnEtiqueta_Click(object sender, EventArgs e)
        {
            ImprimirEtiquetasProducto imprimir = new ImprimirEtiquetasProducto(true, configuracion);
            imprimir.ShowDialog();
        }

        private void btnEtiquetaSinPrecio_Click(object sender, EventArgs e)
        {
            ImprimirEtiquetasProducto imprimir = new ImprimirEtiquetasProducto(false, configuracion);
            imprimir.ShowDialog();
        }

        private void btnEscanearLuegoImprimir_Click(object sender, EventArgs e)
        {
            ValleVerdeComun.Vistas.InicioSesion.InicioSesion obi = new ValleVerdeComun.Vistas.InicioSesion.InicioSesion(false);
            obi.ShowDialog();

            ValleVerdeComun.Programacion.Huellas.ResultadoHuella usuario = obi.usuario;
            if (usuario != null)
            {
                EscanearLuegoImprimir escanear = new EscanearLuegoImprimir(usuario.IDUsuario);
                escanear.ShowDialog();
            }
        }

        private void btnCodigosPreescaneados_Click(object sender, EventArgs e)
        {
            CodigosPreescaneados preescaneados = new CodigosPreescaneados("preescaneados", configuracion);
            preescaneados.ShowDialog();
        }

        private void btnImprimirCambioPrecio_Click(object sender, EventArgs e)
        {
            CodigosPreescaneados etiqueta = new CodigosPreescaneados("cambioprecio", configuracion);
            etiqueta.ShowDialog();
        }
        private void btnEtiquetasNoImpresas_Click(object sender, EventArgs e)
        {
            CodigosPreescaneados noimpresas = new CodigosPreescaneados("noimpresos", configuracion);
            noimpresas.ShowDialog();
        }

        private void btnHistorialImpresiones_Click(object sender, EventArgs e)
        {
            new HistorialImpresionesEtiquetas().ShowDialog();
        }
        private void btnEntregar_Click(object sender, EventArgs e)
        {
            new EntregarEtiquetas().ShowDialog();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
