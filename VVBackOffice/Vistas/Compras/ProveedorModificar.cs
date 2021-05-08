using System;
using System.Windows.Forms;

namespace ValleVerde.Vistas.Compras
{
    public partial class ProveedorModificar : Form
    {
        public long idProSel;
        public ProveedorModificar()
        {
            InitializeComponent();
        }

        private void butSelPro_Click(object sender, EventArgs e)
        {
            new Vistas.BuscarProveedor(this, null, null).Show();
        }

        private void butMod_Click(object sender, EventArgs e)
        {
            new Programacion.ProveedorModificar().ModificarProveedor(idProSel, texBoxNom.Text, texBoxDir.Text, texBoxCiu.Text, texBoxEst.Text, texBoxTel.Text, short.Parse(texBoxDiaCre.Text), texBoxCorEle.Text, float.Parse(texBoxLimCre.Text), new bool[7] { cheBoxLun.Checked, cheBoxMar.Checked, cheBoxMie.Checked, cheBoxJue.Checked, cheBoxVie.Checked, cheBoxSab.Checked, cheBoxDom.Checked }, texBoxRfc.Text, texBoxCel.Text, 777, DateTime.Now);
            this.Close();
        }

        public void CargarDatosProveedor(String nom, String rfc, String diaVis, String dir, String ciu, String est, String cel, String tel, String corEle, short diaCre, float limCre)
        {
            texBoxNom.Text = nom;
            texBoxRfc.Text = rfc;
            texBoxDir.Text = dir;
            texBoxCiu.Text = ciu;
            texBoxEst.Text = est;
            texBoxCel.Text = cel;
            texBoxTel.Text = tel;
            texBoxCorEle.Text = corEle;
            texBoxDiaCre.Text = diaCre.ToString();
            texBoxLimCre.Text = limCre.ToString();
            if (diaVis.Contains("Lun"))
                cheBoxLun.Checked = true;
            else
                cheBoxLun.Checked = false;
            if (diaVis.Contains("Mar"))
                cheBoxMar.Checked = true;
            else
                cheBoxMar.Checked = false;
            if (diaVis.Contains("Mié"))
                cheBoxMie.Checked = true;
            else
                cheBoxMie.Checked = false;
            if (diaVis.Contains("Jue"))
                cheBoxJue.Checked = true;
            else
                cheBoxJue.Checked = false;
            if (diaVis.Contains("Vie"))
                cheBoxVie.Checked = true;
            else
                cheBoxVie.Checked = false;
            if (diaVis.Contains("Sáb"))
                cheBoxSab.Checked = true;
            else
                cheBoxSab.Checked = false;
            if (diaVis.Contains("Dom"))
                cheBoxDom.Checked = true;
            else
                cheBoxDom.Checked = false;
        }
    }
}
