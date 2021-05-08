using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion.Utileria;

namespace ValleVerde.Vistas.Utileria
{
    public partial class EntregarEtiquetas : Form
    {
        CHistorialImpresion cHistorial = new CHistorialImpresion();
        DataTable dt = new DataTable();
        public EntregarEtiquetas()
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvEtiquetasEntregar, true, false);
            dt.Columns.Add("IDEtiqueta");
            dt.Columns.Add("Producto");
            dt.Columns.Add("Codigo Producto");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("Cantidad");
            LlenarTabla(0);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEscanear_Click(object sender, EventArgs e)
        {
            ValleVerdeComun.Vistas.InicioSesion.InicioSesion obi = new ValleVerdeComun.Vistas.InicioSesion.InicioSesion(false);
            obi.ShowDialog();

            ValleVerdeComun.Programacion.Huellas.ResultadoHuella usuario = obi.usuario;
            if (usuario != null)
            {
                txtIDUsuario.Text = usuario.IDUsuario;
                txtNombreUsuario.Text = usuario.Nombres;
            }
        }

        private void LlenarTabla(int bandera)
        {
            dgvEtiquetasEntregar.DataSource = null;
            dt.Rows.Clear();
            List<object[]> historial = cHistorial.ObtenerHistorialImpresion("-1", dtpFecha.Value, dtpFecha.Value.AddDays(1), bandera, -1, -1, -1, -1);
            foreach (object[] rows in historial)
            {
                if (rows[9].ToString().Equals(""))
                {
                    if (rows[2].ToString().Equals(""))
                        //0.IDEtiqueta 1.CodigoProducto 2.ClaveAdicional 3.Fecha 4.Pegado 5.Cantidad 
                        //6.Finalizado 7.Precio 8.CambioPrecio 9.IDUsuarioRecibio 10.NombreUsuario 11.NombreProducto
                        dt.Rows.Add(rows[0], rows[11], rows[1], rows[10], rows[3], rows[5]);
                    else
                        dt.Rows.Add(rows[0], rows[11], rows[2], rows[10], rows[3], rows[5]);
                }
            }
            dgvEtiquetasEntregar.DataSource = dt;     
            RemoveAutoSizeColumn();
            CambiarFuenteyTamano();
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow rowsCheck in dgvEtiquetasEntregar.Rows)
            {
                if (!Convert.ToBoolean(rowsCheck.Cells[0].Value))
                    count++;
            }
            if (dgvEtiquetasEntregar.Rows.Count == count)
                MessageBox.Show("No puede entregar etiquetas si no tiene ninguno seleccionado", "¡ADVERTENCIA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if(txtIDUsuario.Text.Equals(""))
                    MessageBox.Show("Escoga un usuario para poder entregar", "¡ADVERTENCIA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    foreach (DataGridViewRow rowsCheck in dgvEtiquetasEntregar.Rows)
                    {
                        if (Convert.ToBoolean(rowsCheck.Cells[0].Value))
                        {
                            cHistorial.ActualizarHistorialImpresion(rowsCheck.Cells[1].Value.ToString(), txtIDUsuario.Text);
                            MessageBox.Show($"Etiquetas asignadas para pegar a {txtNombreUsuario.Text}", "¡EXITO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }                            
                    }  
                }
            }
        }

        private void CambiarFuenteyTamano()
        {
            dgvEtiquetasEntregar.Columns[1].Visible = false;
            dgvEtiquetasEntregar.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvEtiquetasEntregar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEtiquetasEntregar.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEtiquetasEntregar.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvEtiquetasEntregar.DefaultCellStyle.Font = new Font("Arial", 12);
            dgvEtiquetasEntregar.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);
            dgvEtiquetasEntregar.Columns[0].Width = 50;
            dgvEtiquetasEntregar.Columns[2].Width = 250;
            dgvEtiquetasEntregar.Columns[3].Width = 180;
            dgvEtiquetasEntregar.Columns[4].Width = 100;
            dgvEtiquetasEntregar.Columns[5].Width = 230;
            dgvEtiquetasEntregar.Columns[6].Width = 75;
            dgvEtiquetasEntregar.Columns[0].ReadOnly = false;
            dgvEtiquetasEntregar.Columns[2].ReadOnly = true;
            dgvEtiquetasEntregar.Columns[3].ReadOnly = true;
            dgvEtiquetasEntregar.Columns[4].ReadOnly = true;
            dgvEtiquetasEntregar.Columns[5].ReadOnly = true;
            dgvEtiquetasEntregar.Columns[6].ReadOnly = true;
        }

        private void RemoveAutoSizeColumn()
        {
            foreach (DataGridViewColumn column in dgvEtiquetasEntregar.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            LlenarTabla(1);
        }

        private void checkHora_CheckedChanged(object sender, EventArgs e)
        {
            if(checkFecha.Checked)
            {
                LlenarTabla(1);
                dtpFecha.Enabled = true;
            }
            else
            {
                dtpFecha.Enabled = false;
                LlenarTabla(0);
            }
        }
    }
}
