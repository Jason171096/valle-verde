using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ValleVerde.Vistas.Compras;

namespace ValleVerde.Vistas
{
    public partial class BuscarProveedor : Form
    {
        Programacion.BuscarProveedor obj = new Programacion.BuscarProveedor();
        ProveedorModificar proMod;
        ProveedorEliminar proEli;
        HistorialCompras comVer;

        public BuscarProveedor(ProveedorModificar proMod, ProveedorEliminar proEli, HistorialCompras comVer)
        {
            InitializeComponent();
            this.proMod = proMod;
            this.proEli = proEli;
            this.comVer = comVer;
        }

        private void BuscarProveedor_Load(object sender, EventArgs e)
        {
            LlenarTabla();
            this.texBoxBus.KeyPress += new KeyPressEventHandler(CheckEnter);
        }

        private void butBus_Click(object sender, EventArgs e)
        {
            FiltrarTabla(texBoxBus.Text);
        }

        private void LlenarTabla()
        {
            List<String[]> pro = obj.ObtenerProveedores();

            foreach(String[] proveedor in pro)
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

        private void butAce_Click(object sender, EventArgs e)
        {
            if (proMod != null)
            {
                proMod.CargarDatosProveedor(datGriVieBusPro.SelectedRows[0].Cells[1].Value.ToString(), datGriVieBusPro.SelectedRows[0].Cells[2].Value.ToString(), datGriVieBusPro.SelectedRows[0].Cells[3].Value.ToString(), datGriVieBusPro.SelectedRows[0].Cells[4].Value.ToString(), datGriVieBusPro.SelectedRows[0].Cells[5].Value.ToString(), datGriVieBusPro.SelectedRows[0].Cells[6].Value.ToString(), datGriVieBusPro.SelectedRows[0].Cells[7].Value.ToString(), datGriVieBusPro.SelectedRows[0].Cells[8].Value.ToString(), datGriVieBusPro.SelectedRows[0].Cells[9].Value.ToString(), short.Parse(datGriVieBusPro.SelectedRows[0].Cells[10].Value.ToString()), float.Parse(datGriVieBusPro.SelectedRows[0].Cells[11].Value.ToString()));
                proMod.idProSel = long.Parse(datGriVieBusPro.SelectedRows[0].Cells[0].Value.ToString());
            }
            else
                if (proEli != null)
                {
                    proEli.CargarDatosProveedor(datGriVieBusPro.SelectedRows[0].Cells[1].Value.ToString(), datGriVieBusPro.SelectedRows[0].Cells[2].Value.ToString(), datGriVieBusPro.SelectedRows[0].Cells[3].Value.ToString(), datGriVieBusPro.SelectedRows[0].Cells[4].Value.ToString(), datGriVieBusPro.SelectedRows[0].Cells[5].Value.ToString(), datGriVieBusPro.SelectedRows[0].Cells[6].Value.ToString(), datGriVieBusPro.SelectedRows[0].Cells[7].Value.ToString(), datGriVieBusPro.SelectedRows[0].Cells[8].Value.ToString(), datGriVieBusPro.SelectedRows[0].Cells[9].Value.ToString(), short.Parse(datGriVieBusPro.SelectedRows[0].Cells[10].Value.ToString()), float.Parse(datGriVieBusPro.SelectedRows[0].Cells[11].Value.ToString()));
                    proEli.idProSel = long.Parse(datGriVieBusPro.SelectedRows[0].Cells[0].Value.ToString());
                }
                else
                    if (comVer != null)
                    {
                        comVer.idProSel = long.Parse(datGriVieBusPro.SelectedRows[0].Cells[0].Value.ToString());
                    }
            this.Close();
        }

        private void CheckEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                FiltrarTabla(texBoxBus.Text);
            }
        }

        private void datGriVieBusPro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void texBoxBus_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
