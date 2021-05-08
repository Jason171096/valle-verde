using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion.Configuracion;

namespace ValleVerde.Vistas.Configuracion
{
    public partial class Cotizacion : Form
    {
        Programacion.Configuracion.Cotizacion obc = new Programacion.Configuracion.Cotizacion();
        public Cotizacion()
        {
            InitializeComponent();
        }

        private void Cotizacion_Load(object sender, EventArgs e)
        {
            Llenado();
            valida();
        }

        private void Llenado()
        {
            decimal duracionHoras = obc.ObtenerDuracion();
            Horas.Value = duracionHoras;

            bool respetar = obc.ObtenerRespetar();
            toggleRespetar.IsOn = respetar;
        }

        private void toggleDuracion_Click(object sender, EventArgs e)
        {
            valida();
        }

        private void toggleSinLimite_Click(object sender, EventArgs e)
        {
            if (toggleSinLimite.IsOn)
            {
                Horas.Value = 0;
                Horas.Enabled = false;
            }
            else
            {
                Horas.Enabled = true;
            }
        }

        private void agregarDuracion_Click(object sender, EventArgs e)
        {
            string duracion = Horas.Value.ToString();
            string res = obc.ModicarConfigCot("DuracionCotizacionesEnHoras", duracion);
            ValidaError(res);
        }

        private void toggleRespetar_Click(object sender, EventArgs e)
        {
            int aux;
            bool respCot = toggleRespetar.IsOn;
            if (respCot)
            {
                aux = 1;
            }
            else
            {
                aux = 0;
            }
            string res = obc.ModicarRespetarCot("RespetarPreciosCotizacion", aux);
            ValidaError(res);
        }

        private void valida()
        {
            if (toggleDuracion.IsOn)
            {
                Horas.Enabled = true;
                toggleSinLimite.Enabled = true;
                label3.Visible = true;
            }
            else
            {
                Horas.Enabled = false;
                toggleSinLimite.Enabled = false;
                label3.Visible = false;
            }

            if (Horas.Value == 0)
            {
                toggleSinLimite.IsOn = true;
            }
            else
            {
                toggleSinLimite.IsOn = false;
            }
        }
        
        private void ValidaError(string resultado)
        {
            if (resultado != "-1")
            {
                MessageBox.Show("Ocurrio un error en la modificación", "Error");
            }
        }
    }
}
