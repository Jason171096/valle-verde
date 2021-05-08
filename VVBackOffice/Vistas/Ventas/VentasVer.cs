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
    public partial class VentasVer : Form
    {
        public VentasVer()
        {
            InitializeComponent();
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {

        }

        private void roundedButton4_Click(object sender, EventArgs e)
        {
            VentasVer obj = new VentasVer();
            obj.Show();
            this.Close();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            VentasVerPendientes obj = new VentasVerPendientes();
            obj.Show();
            this.Close();
        }
    }
}
