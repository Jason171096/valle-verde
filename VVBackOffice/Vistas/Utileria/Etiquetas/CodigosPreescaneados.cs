using System;
using System.Windows.Forms;
using ValleVerde.Programacion.Utileria;
using ValleVerde.Programacion;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace ValleVerde.Vistas.Utileria
{
    public partial class CodigosPreescaneados : Form
    {
        ValleVerdeComun.Programacion.ConfiguracionBO configuracion;
        ClaseCodigosPreescaneados codigosPreescaneados = new ClaseCodigosPreescaneados();
        HistorialCosto historial = new HistorialCosto();
        Validaciones v = new Validaciones();
        DataTable dt = new DataTable();
        private bool EtiquetaCambioPrecio = false, EtiquetaPreescaneada = false, horaActiva = false;


        public CodigosPreescaneados(string opcion, ValleVerdeComun.Programacion.ConfiguracionBO configuracion)
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgv, true, false);
            dgv.MultiSelect = true;
            this.configuracion = configuracion;

            if (opcion.Equals("cambioprecio"))
            {
                Text = "Etiqueta Cambio de Precio";
                dtpFechaHistorial.Visible = true;
                dtpHoraInicial.Visible = true;
                dtpHoraFinal.Visible = true;
                checkHora.Visible = true;
                lbInicial.Visible = true;
                lbFinal.Visible = true;
                dtpHoraInicial.Enabled = false;
                dtpHoraFinal.Enabled = false;
                dtpFechaHistorial.MinDate = new DateTime(2018, 12, 01);
                dtpFechaHistorial.MaxDate = DateTime.Now.Date;
                LLenarListBoxEtiquetaCambioPrecio(dtpFechaHistorial.Value, dtpHoraInicial.Value, dtpHoraFinal.Value, 1);
                EtiquetaCambioPrecio = true;
                EtiquetaPreescaneada = false;
            }
            else if(opcion.Equals("preescaneados"))
            {
                Text = "Codigos Preescaneados";
                lbBuscar.Visible = true;
                txtBuscar.Visible = true;
                btnBorrar.Visible = true;
                dt.Columns.Add("Codigo Producto");
                dt.Columns.Add("Producto");
                dt.Columns.Add("Usuario");
                LlenarEtiquetasPreescaneadas();
      
            }
            else if(opcion.Equals("noimpresos"))
            {
                Text = "Etiquetas no impresas";
                LLenarListBoxEtiquetaCambioPrecio(dtpFechaHistorial.Value, dtpHoraInicial.Value, dtpHoraFinal.Value, 2);
                EtiquetaCambioPrecio = true;
            }
            CambiarFuenteyTamano();
        }
       
        private void LLenarListBoxEtiquetaCambioPrecio(DateTime date, DateTime horainicial, DateTime horafinal, int impreso)
        {
            List<object[]> listHistorial = historial.CodigosHistorialCosto(date, horainicial, horafinal, horaActiva, impreso);
            if (impreso != 2)
            {
                DataTable data = new DataTable();
                data.Columns.Add("Codigo Producto");
                data.Columns.Add("Nombre");
                foreach (object[] item in listHistorial)
                {
                    data.Rows.Add(new object[] { item[1], item[2] });
                }
                dgv.DataSource = data;
                RemoveAutoSizeColumn();
                dgv.Columns[0].Width = 200;
                dgv.Columns[1].Width = 430;
            }
            else
            {  
                DataTable data = new DataTable();
                data.Columns.Add("Codigo Producto");
                data.Columns.Add("Nombre");
                data.Columns.Add("Fecha");
                foreach (object[] item in listHistorial)
                {
                    data.Rows.Add(new object[] { item[1], item[2], item[3] });
                }
                dgv.DataSource = data;
                RemoveAutoSizeColumn();
                dgv.Columns[0].Width = 120;
                dgv.Columns[1].Width = 290;
                dgv.Columns[2].Width = 220;
            }
            CambiarFuenteyTamano();
        }

        private void LlenarDatagridView()
        {
            dgv.DataSource = null;
            LLenarListBoxEtiquetaCambioPrecio(dtpFechaHistorial.Value, dtpHoraInicial.Value, dtpHoraFinal.Value, 1);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ImpresoraEtiquetas impresora = new ImpresoraEtiquetas();
            foreach (DataGridViewRow rows in dgv.SelectedRows)
            {
                impresora.SendZplOverUsb(configuracion.ImpresoraEtiquetas, rows.Cells[0].Value.ToString(), true, 1, EtiquetaCambioPrecio, EtiquetaPreescaneada, false);
            }
        }

        private void CambiarFuenteyTamano()
        {
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.DefaultCellStyle.Font = new Font("Arial", 12);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14);       
        }

        private void RemoveAutoSizeColumn()
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow rows in dgv.SelectedRows)
            {
                codigosPreescaneados.BorrarEtiquetas(rows.Cells[0].Value.ToString());
            }
            LlenarEtiquetasPreescaneadas();
        }
        private void LlenarEtiquetasPreescaneadas()
        {
            List<string[]> res = codigosPreescaneados.CodigosPreescaneados();
            dt.Rows.Clear();
            foreach (string[] item in res)
            {
                if (item[1].Equals(""))
                    dt.Rows.Add(item[0], item[2], item[4]);
                else
                    dt.Rows.Add(item[1], item[2], item[4]);
            }
            dgv.DataSource = dt;
            RemoveAutoSizeColumn();
            dgv.Columns[0].Width = 175;
            dgv.Columns[1].Width = 355;
            dgv.Columns[2].Width = 100;
            EtiquetaPreescaneada = true;
            EtiquetaCambioPrecio = false;
        }

        #region CheckHoraChange, ValueChange, TextChange, TextKeyPress
        private void checkHora_CheckedChanged(object sender, EventArgs e)
        {
            if(checkHora.Checked)
            {             
                dtpHoraInicial.Enabled = true;
                dtpHoraFinal.Enabled = true;
                horaActiva = true;
                LlenarDatagridView();
            }
            else
            {             
                dtpHoraInicial.Enabled = false;
                dtpHoraFinal.Enabled = false;
                horaActiva = false;
                LlenarDatagridView();
            }
        }

        private void dtpHoraInicial_ValueChanged(object sender, EventArgs e)
        {
            LlenarDatagridView();
        }

        private void dtpHoraFinal_ValueChanged(object sender, EventArgs e)
        {
            LlenarDatagridView();
        }

        private void dtpFechaHistorial_ValueChanged(object sender, EventArgs e)
        {
            LlenarDatagridView();
        }
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumerosyLetras(sender, e);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("Convert(ID_Usuario,'System.String') LIKE '%{0}%' OR Nombre_Usuario LIKE '%{0}%'", txtBuscar.Text);
            dgv.DataSource = dv;
        }

        #endregion      
    }
}
