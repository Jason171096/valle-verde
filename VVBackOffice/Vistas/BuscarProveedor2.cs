using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerde.Vistas
{
    public partial class BuscarProveedor2 : Form
    {
        Programacion.BuscarProveedor obj = new Programacion.BuscarProveedor();
        TextBox texBoxIdPro;

        public BuscarProveedor2(TextBox texBox)
        {
            InitializeComponent();
            texBoxIdPro = texBox;
        }

        private void BuscarProveedor2_Load(object sender, EventArgs e)
        {
            LlenarTabla();
            this.texBoxBus.KeyPress += new KeyPressEventHandler(CheckEnter);
        }

        private void LlenarTabla()
        {
            List<String[]> pro = obj.ObtenerProveedores();

            foreach (String[] proveedor in pro)
            {
                datGriVieBusPro.Rows.Add(proveedor[0], proveedor[1], proveedor[2], proveedor[3], proveedor[4], proveedor[5], proveedor[6], proveedor[7], proveedor[8], proveedor[9], proveedor[10], proveedor[11]);
            }
        }

        private void FiltrarTabla(String texBus)
        {
            List<String[]> pro = obj.ObtenerProveedor(texBus);

            datGriVieBusPro.Rows.Clear();
            foreach (String[] proveedor in pro)
            {
                datGriVieBusPro.Rows.Add(proveedor[0], proveedor[1], proveedor[2], proveedor[3], proveedor[4], proveedor[5], proveedor[6], proveedor[7], proveedor[8], proveedor[9], proveedor[10], proveedor[11]);
            }
        }

        private void CheckEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                FiltrarTabla(texBoxBus.Text);
            }
        }

        private void butAce_Click(object sender, EventArgs e)
        {
            texBoxIdPro.Text = datGriVieBusPro.SelectedRows[0].Cells[0].Value + "";
            this.Close();
        }

        private void butBus_Click(object sender, EventArgs e)
        {
            FiltrarTabla(texBoxBus.Text);
        }
    }
}
