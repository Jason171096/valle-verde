using System;
using System.Windows.Forms;

namespace ValleVerde.Vistas.Compras
{
    public partial class ProveedorEliminar : Form
    {
        public long idProSel;
        public ProveedorEliminar()
        {
            InitializeComponent();
        }

        private void butSelPro_Click(object sender, EventArgs e)
        {
            new Vistas.BuscarProveedor(null, this, null).Show();
        }

        private void butEli_Click(object sender, EventArgs e)
        {
            new Programacion.ProveedorEliminar().EliminarProveedor(idProSel);
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
