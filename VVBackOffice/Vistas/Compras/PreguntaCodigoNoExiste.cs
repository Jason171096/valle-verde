using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerde.Vistas.Compras
{
    public partial class PreguntaCodigoNoExiste : Form
    {
        private string codBar;

        public PreguntaCodigoNoExiste(string codBar)
        {
            InitializeComponent();
            this.codBar = codBar;
            //KeyDown += new KeyEventHandler(presionaronTecla);
        }

        //private void presionaronTecla(object sender, KeyEventArgs e)
        //{
        //    if(e.KeyCode == Keys.Escape)
        //}

        private void PreguntaCodigoNoExiste_Load(object sender, EventArgs e)
        {
            label1.Text = "No existe producto ni caja con código de barras: " + codBar + ", ¿deseas darlo de alta?";
            bSi.Focus();
        }
    }
}
