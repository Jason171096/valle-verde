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
    public partial class Sucursal : Form
    {
        Sucursales suc = new Sucursales();
        public Sucursal()
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvSucursales,true,false);
        }

        private void Sucursal_Load(object sender, EventArgs e)
        {
            LlenarTabla();
        }

        private void LlenarTabla()
        {
            dgvSucursales.Rows.Clear();
            List<string[]> resSuc = suc.ObtenerSucursales();
            foreach (string[] sucursal in resSuc)
            {
                dgvSucursales.Rows.Add(sucursal[0], sucursal[1], sucursal[2], sucursal[3], sucursal[4], sucursal[5], sucursal[6]);
            }
            dgvSucursales.ClearSelection();
        }

        private void botonAgregar_Click(object sender, EventArgs e)
        {
            AgregarSucursal ags = new AgregarSucursal(0);
            ags.ShowDialog();
            LlenarTabla();
            
        }

        private void botonEditar_Click(object sender, EventArgs e)
        {
            AgregarSucursal ags = new AgregarSucursal(long.Parse(dgvSucursales.CurrentRow.Cells[0].Value.ToString()));
            ags.Text = "Editar Sucursal";
            ags.ShowDialog();
            LlenarTabla();

        }

        private void botonAgregarProductos_Click(object sender, EventArgs e)
        {
            if (dgvSucursales.CurrentRow.Cells[0].Value != null) 
            {
                AgregarProductoSucursal aps = new AgregarProductoSucursal(int.Parse(dgvSucursales.CurrentRow.Cells[0].Value.ToString()));
                aps.ShowDialog();
            }
        }

        private void BotonEliminar_Click(object sender, EventArgs e)
        {
            if (dgvSucursales.SelectedRows.Count != 0)
            {
                Sucursales obj = new Sucursales();

                DialogResult result = MessageBox.Show("¿Quieres Eliminar La Sucursal?", "Eliminar Sucursal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    obj.EliminarSucursal(int.Parse(dgvSucursales.SelectedCells[0].Value + ""));
                }
            }
            else
            {
                MessageBox.Show("Primero debes seleccionar un elemento de la lista.", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            LlenarTabla();
        }

        private void BotonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
