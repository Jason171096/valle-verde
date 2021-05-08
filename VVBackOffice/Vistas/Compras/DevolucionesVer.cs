using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ValleVerde.Programacion.Compra;

namespace ValleVerde.Vistas.Compras
{
    public partial class DevolucionesVer : Form
    {
        Devoluciones devoluciones = new Devoluciones();
        Programacion.Compra.Compras compras = new Programacion.Compra.Compras();
        Boolean limVen = false;
        private string idproveedor;
        private int count = 0;
        private bool _calendarDroppedDown = false, selectLlevaCompra = true;
        List<String[]> datCom;
        public DevolucionesVer()
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvCompras, true, false);
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvDevoluciones, true, false);
            datTimPicFecIni.MinDate = DateTime.Parse("01/12/2018");
            datTimPicFecFin.MinDate = DateTime.Parse("01/12/2018");
            datTimPicFecIni.MaxDate = DateTime.Now.Date;
            datTimPicFecFin.MaxDate = DateTime.Now.Date;
            CargarCompras(1, count, "-1", "-1", datTimPicFecIni.Value, datTimPicFecFin.Value);
        }
        #region RadioButtons
        private void radButCom_CheckedChanged(object sender, EventArgs e)
        {
            texBoxIdCom.Enabled = true;
            butBusIdCom.Enabled = true;
            butSelPro.Enabled = false;
            datTimPicFecIni.Enabled = false;
            datTimPicFecFin.Enabled = false;
        }

        private void radButPro_CheckedChanged(object sender, EventArgs e)
        {
            texBoxIdCom.Enabled = false;
            butBusIdCom.Enabled = false;
            butSelPro.Enabled = true;
            datTimPicFecIni.Enabled = false;
            datTimPicFecFin.Enabled = false;
        }

        private void radButFec_CheckedChanged(object sender, EventArgs e)
        {
            texBoxIdCom.Enabled = false;
            butBusIdCom.Enabled = false;
            butSelPro.Enabled = false;
            datTimPicFecIni.Enabled = true;
            datTimPicFecFin.Enabled = true;
        }

        private void radButSinCompra_CheckedChanged(object sender, EventArgs e)
        {
            texBoxIdCom.Enabled = false;
            butBusIdCom.Enabled = false;
            butSelPro.Enabled = false;
            datTimPicFecIni.Enabled = false;
            datTimPicFecFin.Enabled = false;
        }

        private void radButNin_CheckedChanged(object sender, EventArgs e)
        {
            texBoxIdCom.Enabled = false;
            butBusIdCom.Enabled = false;
            butSelPro.Enabled = false;
            datTimPicFecIni.Enabled = false;
            datTimPicFecFin.Enabled = false;
        }
        #endregion
        #region Eventos de DatePicker
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
            count = 0;
            if (!_calendarDroppedDown) //only refresh the display once user has chosen a date from the calendar, not while they're paging through the days.
            {

                if (datTimPicFecIni.Value > datTimPicFecFin.Value)
                    datTimPicFecIni.Value = datTimPicFecFin.Value;
                CargarCompras(4, count, "-1", "-1", datTimPicFecIni.Value, datTimPicFecFin.Value);

            }
        }
        #endregion
        private void butSelPro_Click(object sender, EventArgs e)
        {
            TextBox textBox = new TextBox();
            new BuscarProveedor2(textBox).ShowDialog();
            idproveedor = textBox.Text;
        }
        private void datGriVieNumCom_SelectionChanged(object sender, EventArgs e)
        {
            if (!limVen)
            {
            }
        }

        private void LimpiarVentana()
        {
            limVen = true;
            dgvCompras.Rows.Clear();
            labNumCom.Text = "-";
            labPro.Text = "-";
            labFecDev.Text = "-";
            labTotDev.Text = "-";
            limVen = false;
        }
        private void CargarCompras(int opcion, int count, string buscar, string idproveedor, DateTime dateI, DateTime dateF)
        {
            datCom = compras.ObtenerCompras(1, opcion, count, buscar, idproveedor, dateI, dateF);
            dgvCompras.ColumnCount = 3;
            dgvCompras.Columns[0].Name = "ID";
            dgvCompras.Columns[1].Name = "Nombre";
            dgvCompras.Columns[2].Name = "Fecha";
            foreach (string[] datos in datCom)
            {
                string[] row = new string[] { datos[0], datos[4], DateTime.Parse(datos[5]).ToShortDateString() };
                dgvCompras.Rows.Add(row);
            }
            dgvCompras.Columns[0].Visible = false;
        }

        private void CargarDevoluciones(bool LlevaCompra, int IDCompra)
        {
            List<object[]> rows = devoluciones.ObtenerDevoluciones(LlevaCompra, IDCompra);
            dgvDevoluciones.ColumnCount = 3;
            dgvDevoluciones.Columns[0].Name = "ID Devolucion";
            dgvDevoluciones.Columns[1].Name = "Codigo Producto";
            dgvDevoluciones.Columns[2].Name = "Nombre";
            dgvDevoluciones.Columns[3].Name = "Cantidad";
            dgvDevoluciones.Columns[4].Name = "Motivo";
            dgvDevoluciones.Columns[5].Name = "Costo";
            foreach (object[] row in rows)
            {
                object[] rowss = new object[] { row[0], row[1], row[2], row[3], row[4], row[5] };
                dgvDevoluciones.Rows.Add(rowss);
            }
            dgvDevoluciones.Columns[0].Visible = false;
        }

        private void dgvCompras_SelectionChanged(object sender, EventArgs e)
        {
            if (selectLlevaCompra)
                CargarDevoluciones(true, int.Parse(dgvCompras.CurrentRow.Cells[0].Value.ToString()));
            else
                CargarDevoluciones(false, int.Parse(dgvCompras.CurrentRow.Cells[0].Value.ToString()));
        }
    }
}
