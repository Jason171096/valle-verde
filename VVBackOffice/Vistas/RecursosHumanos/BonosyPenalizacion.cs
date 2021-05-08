using System;
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
    public partial class BonosyPenalizacion : Form
    {
        CBonosyPenalizacion cBonosyPenalizacion = new CBonosyPenalizacion();
        Validaciones v = new Validaciones();
        public BonosyPenalizacion()
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvBonos, true, false);
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvPenalizaciones, true, false);
            foreach (DataGridViewColumn column in dgvBonos.Columns)
            {//Las columnas se puedan editar
                column.ReadOnly = false;
            }
            foreach (DataGridViewColumn column in dgvPenalizaciones.Columns)
            {
                column.ReadOnly = false;
            }
            dgvBonos.AllowUserToAddRows = true;
            dgvBonos.AllowUserToDeleteRows = true;
            dgvBonos.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvPenalizaciones.AllowUserToAddRows = true;
            dgvPenalizaciones.AllowUserToDeleteRows = true;
            dgvPenalizaciones.SelectionMode = DataGridViewSelectionMode.CellSelect;

            LlenarBonos();
            LlenarPenalizaciones();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int numRowsBono = dgvBonos.Rows.Count;
            for (int i = 0; i < numRowsBono; i++)
            {
                string idbono = (string)dgvBonos[0, i].Value;
                string descripcion = (string)dgvBonos[1, i].Value;
                string importe = (string)dgvBonos[2, i].Value;
                if (!String.IsNullOrWhiteSpace(descripcion))
                {//Se verifica que las descripcion no este vacia
                    if (importe.Contains("$"))
                        importe = importe.Trim('$');
                    if (importe.Equals(""))
                        importe = "0";
                    if (idbono != null)
                        cBonosyPenalizacion.ModificarBono(idbono, descripcion, importe);
                    else
                        cBonosyPenalizacion.AltaBono(descripcion, importe);
                }
            }

            int numRowsPena = dgvPenalizaciones.Rows.Count;
            for (int i = 0; i < numRowsPena; i++)
            {
                string idpena = (string)dgvPenalizaciones[0, i].Value;
                string descripcion = (string)dgvPenalizaciones[1, i].Value;
                string importe = (string)dgvPenalizaciones[2, i].Value;
                if (!String.IsNullOrWhiteSpace(descripcion))
                {//Se verifica que las descripcion no este vacia
                    if (importe.Contains("$"))
                        importe = importe.Trim('$');
                    if (importe.Equals(""))
                        importe = "0";
                    if (idpena != null)
                        cBonosyPenalizacion.ModificarPenalizacion(idpena, descripcion, importe);
                    else
                        cBonosyPenalizacion.AltaPenalizacion(descripcion, importe);
                }
            }
            MessageBox.Show("Se EDITARON y se AGREGARON correctamente los bonos y penalizaciones", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ActualizarBonosyPena();
            
        }
        private void ActualizarBonosyPena()
        {
            dgvBonos.Rows.Clear();
            dgvPenalizaciones.Rows.Clear();
            LlenarBonos();
            LlenarPenalizaciones();
        }
        private void LlenarBonos()
        {
            //Obtiene la lista de los Bonos y los llena en el DataGridView
            List<object[]> bonos = cBonosyPenalizacion.ObtenerBonos();
            foreach (object[] rows in bonos)
            {
                dgvBonos.Rows.Add(rows[0] + "", rows[1] + "", FormatString(rows[2]));
            }
        }
        private void LlenarPenalizaciones()
        {
            //Obtiene la lista de las Penalizaciones y los llena en el DataGridView
            List<object[]> pena = cBonosyPenalizacion.ObtenerPenalizaciones();
            foreach (object[] rows in pena)
            {
                dgvPenalizaciones.Rows.Add(rows[0] + "", rows[1] + "", FormatString(rows[2]));
            }
        }
        private string FormatString(object value)
        {
            return string.Format("{0:C}", Double.Parse(value + ""));
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void dgvBonos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (e.ColumnIndex)
                {

                    case 1://Caso 1 y 2 se agrega la imagen del Basurero
                        dgvBonos.Rows[e.RowIndex].Cells[3].Value = global::ValleVerde.Properties.Resources.darBajaUsuario1;
                        dgvBonos.Refresh();
                        break;
                    case 2:
                        dgvBonos.Rows[e.RowIndex].Cells[3].Value = global::ValleVerde.Properties.Resources.darBajaUsuario1;
                        dgvBonos.Refresh();
                        break;
                    case 3:
                        //En el caso 3 se borra la Fila
                        if (dgvBonos.Rows[e.RowIndex].Cells[0].Value != null || dgvBonos.Rows[e.RowIndex].Cells[0].Value + "" != "")
                        {
                            cBonosyPenalizacion.EliminarBono(dgvBonos.Rows[e.RowIndex].Cells[0].Value + "");
                        }
                        dgvBonos.Rows.Remove(dgvBonos.Rows[e.RowIndex]);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eliminar", "¡Error al eliminar!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvPenalizaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (e.ColumnIndex)
                {
                    case 1:
                        //Caso 1 y 2 se agrega la imagen del Basurero
                        dgvPenalizaciones.Rows[e.RowIndex].Cells[3].Value = global::ValleVerde.Properties.Resources.darBajaUsuario1;
                        dgvPenalizaciones.Refresh();
                        break;
                    case 2:
                        dgvPenalizaciones.Rows[e.RowIndex].Cells[3].Value = global::ValleVerde.Properties.Resources.darBajaUsuario1;
                        dgvPenalizaciones.Refresh();
                        break;
                    case 3:
                        //En el caso 3 se borra la Fila
                        if (dgvPenalizaciones.Rows[e.RowIndex].Cells[0].Value != null)
                        {
                            cBonosyPenalizacion.EliminarPenalizacion(dgvPenalizaciones.Rows[e.RowIndex].Cells[0].Value + "");

                        }
                        dgvPenalizaciones.Rows.Remove(dgvPenalizaciones.Rows[e.RowIndex]);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eliminar", "¡Error al eliminar!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvBonos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //Solo se aceptan numeros, letras y decimales en las celdas
            if (dgvBonos.CurrentCell.ColumnIndex == 2)
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.KeyPress += new KeyPressEventHandler(v.SoloDecimales);
                }
            }
            else
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.KeyPress += new KeyPressEventHandler(v.SoloNumerosyLetras);
                }
            }
        }
        private void dgvPenalizaciones_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //Solo se aceptan numeros, letras y decimales en las celdas
            if (dgvPenalizaciones.CurrentCell.ColumnIndex == 2)
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.KeyPress += new KeyPressEventHandler(v.SoloDecimales);
                }
            }
            else
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.KeyPress += new KeyPressEventHandler(v.SoloNumerosyLetras);
                }
            }
        }
    }
}
