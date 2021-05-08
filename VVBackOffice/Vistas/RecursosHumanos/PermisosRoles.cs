using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion.RecursosHumanos;

namespace ValleVerde.Vistas.RecursosHumanos
{
    public partial class PermisosRoles : Form
    {
        private ObtenerRoles obr = new ObtenerRoles();
        private DataTable dt, dtp;
        private List<bool> perm = new List<bool>();

        public PermisosRoles()
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvRoles, true, false, 12, 12);

            //DataTable dt recibe un metodo q retorna DataTable
            dt = obr.BuscarRoles();
            //dt le pasa la tabla al DataGridView
            dgvRoles.DataSource = dt;
            dgvRoles.Columns[0].Visible = false;
            dgvRoles.ColumnHeadersVisible = false;
            dgvRoles.SelectionChanged += new EventHandler(dgvRoles_SelectionChanged); // Evento click en fila completa
            dtp = new DataTable();
        }

        // Implementacion de evento click en fila completa
        private void dgvRoles_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvRoles.CurrentRow != null)
                LlenarPermisos(Convert.ToInt32(dgvRoles.CurrentRow.Cells[0].Value));
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            // Guardar cambios con los checkboxes
            ActualizarPermisos();
            obr.GuardarPermisos(Convert.ToInt32(dgvRoles.CurrentRow.Cells[0].Value), perm);
            MessageBox.Show("Se han guardado los permisos actualizados para el Rol " + dgvRoles.CurrentRow.Cells[1].Value.ToString() + " correctamente.", "Permisos guardados: " + dgvRoles.CurrentRow.Cells[1].Value.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LlenarPermisos(int idRol)
        {
            dtp.Clear();
            dtp = obr.BuscarPermisos(idRol);
            perm.Clear();
            // Ciclo para llenar arreglo de permisos
            for (int i = 0; i < dtp.Columns.Count; i++)
                perm.Add(dtp.Rows[0].Field<bool>(i)); // Obtengo valores de la primera fila de cada columna entregando un booleano

            // *** Llenar permisos ***

            // Comunes
            cbVerificadorAcceder.Checked = perm[0];
            cbPedidoClienteAcceder.Checked = perm[1];
            cbDevolucionesVentasAcceder.Checked = perm[2];

            // BackOffice
            cbEtiquetasPendientesPegarAcceder.Checked = perm[3];
            cbPreescanearEtiquetas.Checked = perm[4];
            cbVerificarInventario.Checked = perm[5];
            cbKardexAcceder.Checked = perm[6];
            cbRecibirAcceder.Checked = perm[7];
            cbDevolucionesComprasAcceder.Checked = perm[8];
            cbProductosPendientesComprasAcceder.Checked = perm[9];
            cbAltaProducto.Checked = perm[10];
            cbPrecapturarProducto.Checked = perm[11];
            cbModificarProducto.Checked = perm[12];
            cbClavesAdicionalesAcceder.Checked = perm[13];
            cbEntradasSalidasProductoAcceder.Checked = perm[14];
            cbCotizacionCompras.Checked = perm[15];
            cbInicciarSesionBackOffice.Checked = perm[16];

            // Punto de Venta
            cbDesbloquearCaja.Checked = perm[17];
            cbHacerCorte.Checked = perm[18];
            cbHacerDevolucion.Checked = perm[19];
            cbEliminarProducto.Checked = perm[20];
            cbHacerCotizacionVenta.Checked = perm[21];
            cbIniciarSesionPuntoVenta.Checked = perm[22];
        }

        private void btnCrearRol_Click(object sender, EventArgs e)
        {
            if (!tbNomRol.Text.Equals(""))
            {
                obr.CrearRol(tbNomRol.Text.ToString());
                dt = obr.BuscarRoles();
                dgvRoles.DataSource = dt;
                tbNomRol.Text = "";
                obr.CrearPermisos(Convert.ToInt32(dgvRoles.Rows[dgvRoles.RowCount-1].Cells[0].Value));
                dgvRoles.Rows[dgvRoles.RowCount-1].Selected = true;
                dgvRoles.CurrentCell = dgvRoles.Rows[dgvRoles.RowCount - 1].Cells[1];
                dgvRoles_SelectionChanged(null, null);
                MessageBox.Show("Rol creado correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("El nombre del rol no puede estar vacio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        private void roundedButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvRoles.CurrentRow != null)
                new EditarRol(Convert.ToInt32(dgvRoles.CurrentRow.Cells[0].Value), dgvRoles.CurrentRow.Cells[1].Value.ToString(), dt, dgvRoles).Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvRoles.CurrentRow != null)
            {
                DialogResult dialogResult = MessageBox.Show("Esta seguro que desea eliminar el rol de " + dgvRoles.CurrentRow.Cells[1].Value.ToString() + "?. Esta accion no se puede deshacer", "Eliminar Rol", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int res = obr.EliminarRol(Convert.ToInt32(dgvRoles.CurrentRow.Cells[0].Value));
                    switch (res)
                    {
                        case 1:
                            dt = obr.BuscarRoles();
                            dgvRoles.DataSource = dt;
                            obr.CrearPermisos(Convert.ToInt32(dgvRoles.Rows[dgvRoles.RowCount - 1].Cells[0].Value));
                            dgvRoles.Rows[dgvRoles.RowCount - 1].Selected = true;
                            dgvRoles.CurrentCell = dgvRoles.Rows[dgvRoles.RowCount - 1].Cells[1];
                            dgvRoles_SelectionChanged(null, null);
                            break;
                        case -1:
                            MessageBox.Show("El rol no existe...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        case -2:
                            MessageBox.Show("El rol esta asociado actualmente con uno o mas usuarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                    }
                }
            }
        }

        private void ActualizarPermisos()
        {
            // Permisos comunes
            perm[0] = cbVerificadorAcceder.Checked;
            perm[1] = cbPedidoClienteAcceder.Checked;
            perm[2] = cbDevolucionesVentasAcceder.Checked;
            // Permisos BackOffice
            perm[3] = cbEtiquetasPendientesPegarAcceder.Checked;
            perm[4] = cbPreescanearEtiquetas.Checked;
            perm[5] = cbVerificarInventario.Checked;
            perm[6] = cbKardexAcceder.Checked;
            perm[7] = cbRecibirAcceder.Checked;
            perm[8] = cbDevolucionesComprasAcceder.Checked;
            perm[9] = cbProductosPendientesComprasAcceder.Checked;
            perm[10] = cbAltaProducto.Checked;
            perm[11] = cbPrecapturarProducto.Checked;
            perm[12] = cbModificarProducto.Checked;
            perm[13] = cbClavesAdicionalesAcceder.Checked;
            perm[14] = cbEntradasSalidasProductoAcceder.Checked;
            perm[15] = cbCotizacionCompras.Checked;
            perm[16] = cbInicciarSesionBackOffice.Checked;
            // Permisos Punto Venta
            perm[17] = cbDesbloquearCaja.Checked;
            perm[18] = cbHacerCorte.Checked;
            perm[19] = cbHacerDevolucion.Checked;
            perm[20] = cbEliminarProducto.Checked;
            perm[21] = cbHacerCotizacionVenta.Checked;
            perm[22] = cbIniciarSesionPuntoVenta.Checked;
        }

    }
}
