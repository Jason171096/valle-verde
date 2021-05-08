using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerde
{
    public partial class DevolucionesVer : Form
    {
        public DevolucionesVer()
        {
            InitializeComponent();
        }

        private void Devoluciones_Load(object sender, EventArgs e)
        {
            tabDevoluciones.Appearance = TabAppearance.FlatButtons;
            tabDevoluciones.ItemSize = new Size(0, 1);
            tabDevoluciones.SizeMode = TabSizeMode.Fixed;
        }
    }
}
