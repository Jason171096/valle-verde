using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerdeComun.Programacion;

namespace ValleVerde.Vistas.Compras
{
    public partial class AltaRapida : Form
    {
        ValleVerdeComun.Programacion.Producto producto = new ValleVerdeComun.Programacion.Producto();
       // Programacion.Compra.Compras objCom = new Programacion.Compra.Compras();

        string codBar;
        public AltaRapida(string codBar)
        {
            InitializeComponent();
            this.codBar = codBar;
        }

        private void AltaRapida_Load(object sender, EventArgs e)
        {
            tbCodBar.Text = codBar;
            KeyDown += new KeyEventHandler(presionoTecla);
            tbCodBar.KeyDown += new KeyEventHandler(presionoTecla);
            tbNom.KeyDown += new KeyEventHandler(presionoTecla);
        }

        private void presionoTecla(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if (tbCodBar.Focused || tbNom.Focused)
                {
                    TextBox tb = new TextBox();
                    if (tbCodBar.Focused)
                        tb = tbCodBar;
                    else
                        if(tbNom.Focused)
                            tb = tbNom;


                    if (tb.Name.Equals("tbNom"))
                        bCon.PerformClick();
                    else
                        SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            else
                if (e.KeyCode == Keys.Escape)
                    Close();
        }
    }
}
