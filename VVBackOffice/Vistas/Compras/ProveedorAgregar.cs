using System;
using System.Windows.Forms;

namespace ValleVerde.Vistas.Compras
{
    public partial class ProveedorAgregar : Form
    {
        public ProveedorAgregar()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            new Programacion.ProveedorAgregar().AgregarProveedor(texBoxNom.Text, texBoxDir.Text, texBoxCiu.Text, texBoxEst.Text, texBoxTel.Text, Int32.Parse(texBoxDiaCre.Text), texBoxCorEle.Text, Int32.Parse(texBoxLimCre.Text), new bool[7] {cheBoxLun.Checked, cheBoxMar.Checked, cheBoxMie.Checked, cheBoxJue.Checked, cheBoxVie.Checked, cheBoxSab.Checked, cheBoxDom.Checked},texBoxRfc.Text, texBoxCel.Text, 777, DateTime.Now);
            this.Close();
        }

        private void ProveedorAgregar_Load(object sender, EventArgs e)
        {

        }
    }
}
