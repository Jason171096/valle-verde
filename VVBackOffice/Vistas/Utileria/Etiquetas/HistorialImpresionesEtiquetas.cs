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
    public partial class HistorialImpresionesEtiquetas : Form
    {
        ValleVerdeComun.Programacion.Usuario usuario = new ValleVerdeComun.Programacion.Usuario();
        ValleVerdeComun.Programacion.Usuarios usuarios = new ValleVerdeComun.Programacion.Usuarios();
        CHistorialImpresion cHistorial = new CHistorialImpresion();
        private bool _calendarDroppedDown = false;
        DataTable dt = new DataTable();
        List<string> columns = new List<string>();
        List<CheckBox> checkBoxes = new List<CheckBox>();
        public HistorialImpresionesEtiquetas()
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvHistorial, true, false);
            dt.Columns.Add("Usuario");
            dt.Columns.Add("Producto");
            dt.Columns.Add("Codigo Producto");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Pegado");
            dt.Columns.Add("Finalizado");
            dt.Columns.Add("Precio");
            dt.Columns.Add("Cambio_Precio");
            dt.Columns.Add("Recibio Usuario");
            LlenarTabla(DateTime.Now, DateTime.Now, 0);
            string and = " AND ";
            string pegado = "Pegado = 'True'";
            string finalizado = "Finalizado = 'True'";
            string conprecio = "Precio = 'True'";
            string cambio = "Cambio_Precio = 'True'";
            
            columns.Add(pegado);
            columns.Add(finalizado);
            columns.Add(conprecio);
            columns.Add(cambio);
            columns.Add(and);
        }
        private void LlenarTabla(DateTime dateini, DateTime datefin, int filtroFecha)
        {
            dgvHistorial.DataSource = null;
            dt.Rows.Clear();
            List<object[]> historial = cHistorial.ObtenerHistorialImpresion("-1", dateini, datefin, filtroFecha, -1, -1, -1, -1);
            
            foreach (object[] rows in historial)
            {
                string usuariorecibio;
                if (!rows[9].ToString().Equals(""))
                {
                    usuario = usuarios.ObtenerUsuario(rows[9].ToString(), true);
                    usuariorecibio = usuario.usuario;
                }
                else
                    usuariorecibio = "";
                if (rows[2].ToString().Equals(""))
                    //0.IDEtiqueta 1.CodigoProducto 2.ClaveAdicional 3.Fecha 4.Pegado 5.Cantidad 
                    //6.Finalizado 7.Precio 8.CambioPrecio 9.IDUsuarioRecibio 10.NombreUsuario 11.NombreProducto
                    dt.Rows.Add(rows[10], rows[11], rows[1], rows[3], rows[5], rows[4], rows[6], rows[7], rows[8], usuariorecibio);
                else
                    dt.Rows.Add(rows[10], rows[11], rows[2], rows[3], rows[5], rows[4], rows[6], rows[7], rows[8], usuariorecibio);
            }
            dgvHistorial.DataSource = dt;
            DarFormatoTabla();
        }

        private void DarFormatoTabla()
        {
            dgvHistorial.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvHistorial.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHistorial.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHistorial.DefaultCellStyle.Font = new Font("Arial", 12);
            dgvHistorial.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);
            foreach (DataGridViewColumn column in dgvHistorial.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
            dgvHistorial.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHistorial.Columns[0].Width = 100;//Usuario
            dgvHistorial.Columns[1].Width = 250;//Producto
            dgvHistorial.Columns[2].Width = 200;//Codigo Producto
            dgvHistorial.Columns[3].Width = 250;//Fecha
            dgvHistorial.Columns[4].Width = 75;//Cantidad
            dgvHistorial.Columns[5].Width = 75;//Pegado
            dgvHistorial.Columns[6].Width = 75;//Finalizado
            dgvHistorial.Columns[7].Width = 75;//Precio
            dgvHistorial.Columns[8].Width = 75;//CambioPrecio
            dgvHistorial.Columns[9].Width = 100;//RecibioUsuario
            dgvHistorial.Columns[8].HeaderText = "Cambio Precio";

        }
        private void checkFecha_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkFecha.Checked)
            {
                dtpFechaInicio.Enabled = true;
                dtpFechaFinal.Enabled = true;
            }
            else
            {
                dtpFechaInicio.Enabled = false;
                dtpFechaInicio.Value = DateTime.Now;
                dtpFechaFinal.Enabled = false;
                dtpFechaFinal.Value = DateTime.Now;
            }
        }

        private void dgvHistorial_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex >= 5 && e.ColumnIndex <= 8 && e.RowIndex >= 0)
                {
                    e.PaintBackground(e.CellBounds, true);
                    ControlPaint.DrawCheckBox(e.Graphics, e.CellBounds.X + 1, e.CellBounds.Y + 1,
                        e.CellBounds.Width - 2, e.CellBounds.Height - 2,
                        bool.Parse(e.FormattedValue.ToString()) ? ButtonState.Checked : ButtonState.Normal);
                    e.Handled = true;
                }
            }
            catch 
            {
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region DatePickerChangue

        private void HistorialImpresionesEtiquetas_Load(object sender, EventArgs e)
        {
            dtpFechaInicio.DropDown += new EventHandler(datTimPicFec_DropDown);
            dtpFechaInicio.CloseUp += new EventHandler(datTimPicFec_CloseUp);
            dtpFechaFinal.DropDown += new EventHandler(datTimPicFec_DropDown);
            dtpFechaFinal.CloseUp += new EventHandler(datTimPicFec_CloseUp);
        }
        //called when calendar drops down
        private void datTimPicFec_DropDown(object sender, EventArgs e)
        {
            _calendarDroppedDown = true;

        }
        //called when calendar closes
        private void datTimPicFec_CloseUp(object sender, EventArgs e)
        {
            _calendarDroppedDown = false;
            RefreshToolbox(null, null); //NOW we want to refresh display
        }

        //This method is called when ValueChanged is fired
        public void RefreshToolbox(object sender, EventArgs e)
        {
            if (dtpFechaInicio.Value >= dtpFechaFinal.Value)
                dtpFechaInicio.Value = dtpFechaFinal.Value;
            if (!_calendarDroppedDown) //only refresh the display once user has chosen a date from the calendar, not while they're paging through the days.
            {
                LlenarTabla(dtpFechaInicio.Value, dtpFechaFinal.Value, 1);
            }
        }


        #endregion
        #region CheckBox
        private void checkPegados_CheckedChanged(object sender, EventArgs e)
        {
            dgvHistorial.DataSource = FilterCheckBox(checkPegados, checkFinalizado, checkConPrecio, checkCambioPrecio);
        }

        private void checkFinalizado_CheckedChanged(object sender, EventArgs e)
        {
            dgvHistorial.DataSource = FilterCheckBox(checkPegados, checkFinalizado, checkConPrecio, checkCambioPrecio);
        }

        private void checkConPrecio_CheckedChanged(object sender, EventArgs e)
        {
            dgvHistorial.DataSource = FilterCheckBox(checkPegados, checkFinalizado, checkConPrecio, checkCambioPrecio);
        }

        private void checkCambioPrecio_CheckedChanged(object sender, EventArgs e)
        {
            dgvHistorial.DataSource = FilterCheckBox(checkPegados, checkFinalizado, checkConPrecio, checkCambioPrecio);
        }

        private DataView FilterCheckBox(CheckBox column1, CheckBox column2, CheckBox column3, CheckBox column4)
        {
            checkBoxes.Clear();
            string concat = "";
            int cont = 0;
            checkBoxes.Add(column1);
            checkBoxes.Add(column2);
            checkBoxes.Add(column3);
            checkBoxes.Add(column4);
            for (int i = 0; i < checkBoxes.Count; i++)
            {
                if(checkBoxes[i].Checked)
                {
                    if (cont >= 1)
                    {
                        concat += columns[4] + columns[i];
                    }
                    else
                    {
                        concat = columns[i];
                        cont++;
                    }

                }    
            }
            DataView dataView = new DataView(dt);
            dataView.RowFilter = concat;
            return dataView;
        }

        #endregion
    }
}
