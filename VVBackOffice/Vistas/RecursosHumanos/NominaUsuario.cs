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
using ValleVerde.Vistas.Compras;
using ValleVerdeComun.Programacion;

namespace ValleVerde.Vistas.RecursosHumanos
{
    public partial class NominaUsuario : Form
    {
        CBonosyPenalizacion cBonosyPenalizacion = new CBonosyPenalizacion();
        QuitarCadenas quitar = new QuitarCadenas();
        Validaciones v = new Validaciones();
        private Usuario usuario;
        private double salarioContrato, salarioIMSS;
        object value = "0", text = "SELECCIONAR";
        public NominaUsuario()
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvSubTotalBonoyPena, true, false);
            dgvSubTotalBonoyPena.Columns[0].ReadOnly = true;
            dgvSubTotalBonoyPena.Columns[1].ReadOnly = true;
            LlenarCboxBono();
            LLenarCboxPena();
            DarFormatoTabla();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarEmpleado buscarEmpleado = new BuscarEmpleado();
            buscarEmpleado.ShowDialog();
            usuario = buscarEmpleado.ObtenerUsuario();
            txtNombre.Text = usuario.nombres;
            txtApellido.Text = usuario.apellidos;
            txtUsuario.Text = usuario.usuario;
            txtSalarioBase.Text = Format(usuario.salarioContrato);
            txtSalarioIMSS.Text = Format(usuario.salarioImss);
            lbSalarioBase.Text = txtSalarioBase.Text;
            lbSalarioIMSS.Text = txtSalarioIMSS.Text;
            salarioContrato = Convert.ToDouble(usuario.salarioContrato);
            salarioIMSS = Convert.ToDouble(usuario.salarioImss);
            UpdateLabelsPago();
        }

        private void btnBonoyPena_Click(object sender, EventArgs e)
        {
            Hide();
            new BonosyPenalizacion().ShowDialog();
            LlenarCboxBono();
            LLenarCboxPena();
            Show();
        }

        private void LlenarCboxBono()
        {   
            List<object[]> ListBonos = cBonosyPenalizacion.ObtenerBonos();
            cboxBono.DisplayMember = "Text";
            cboxBono.ValueMember = "Value";
            List<object> Bono = new List<object>();
            //Bono.Add(new { value, text });
            foreach (object[] bono in ListBonos)
            {
                Bono.Add(new { Value = bono[2], Text = bono[1] });
            }
            cboxBono.DataSource = Bono;
        }
        private void LLenarCboxPena()
        {
            List<object[]> ListPena = cBonosyPenalizacion.ObtenerPenalizaciones();
            cboxPena.DisplayMember = "Text";
            cboxPena.ValueMember = "Value";
            List<Object> Pena = new List<Object>();
            //Pena.Add(new { value, text });
            foreach (object[] pena in ListPena)
            {
                Pena.Add(new { Value = pena[2], Text = pena[1] });
            }
            cboxPena.DataSource = Pena;
        }

        private void btnAsignarPena_Click(object sender, EventArgs e)
        {
            dgvSubTotalBonoyPena.Rows.Add(2, cboxPena.GetItemText(cboxPena.SelectedItem), txtPena.Text);
            UpdateLabelsPago();
        }
        private void btnAsignarBono_Click(object sender, EventArgs e)
        {
            dgvSubTotalBonoyPena.Rows.Add(1, cboxBono.GetItemText(cboxBono.SelectedItem), txtBono.Text);
            UpdateLabelsPago();
        }
        private void btnAsignarFaltante_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtDescripcion.Text) || String.IsNullOrWhiteSpace(txtImporte.Text))
            {
                MessageBox.Show("Los campos de DESCRIPCIÓN e IMPORTE no pueden estar vacios", "¡ADVERTENCIA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dgvSubTotalBonoyPena.Rows.Add(3, txtDescripcion.Text, Format(txtImporte.Text));
                UpdateLabelsPago();
            }
        }
        private void cboxBono_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBono.Text = Format(cboxBono.SelectedValue);
        }
        private void cboxPena_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPena.Text = Format(cboxPena.SelectedValue);
        }
        private void dgvSueltoTotal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                dgvSubTotalBonoyPena.Rows.Remove(dgvSubTotalBonoyPena.Rows[e.RowIndex]);
                UpdateLabelsPago();
            }
        }
        private string Format(object cad)
        {
            return string.Format("{0:C}", Double.Parse(cad.ToString())); ;
        }

        private void UpdateLabelsPago()
        {
            //Index de dgvSueldoTotal 1 = Bonos, 2 = Penalizaciones, 3 = Faltante
            double bonos = 0, pena = 0, faltante = 0, TotalFaltante = 0, TotalBono = 0;
            foreach (DataGridViewRow index in dgvSubTotalBonoyPena.Rows)
            {  
                switch(index.Cells[0].Value)
                {
                    case 1:
                        string value1 = quitar.ObtenerCadenaLimpia(dgvSubTotalBonoyPena.Rows[index.Index].Cells[2].Value + "", new string[] { "$" });
                        bonos += Convert.ToDouble(value1);
                        break;
                    case 2:
                        string value2 = quitar.ObtenerCadenaLimpia(dgvSubTotalBonoyPena.Rows[index.Index].Cells[2].Value + "", new string[] { "$" });
                        pena += Convert.ToDouble(value2);
                        break;
                    case 3:
                        string value3 = quitar.ObtenerCadenaLimpia(dgvSubTotalBonoyPena.Rows[index.Index].Cells[2].Value + "", new string[] { "$" });
                        faltante += Convert.ToDouble(value3);
                        break;
                }
            }
            lbBonos.Text = Format(bonos);
            lbPena.Text = Format(pena);
            lbFaltante.Text = Format(faltante);
            TotalFaltante = pena + faltante;
            TotalBono = bonos + salarioContrato + salarioIMSS;
            lbTotalFaltante.Text = Format(TotalFaltante);
            lbTotalBonos.Text = Format(TotalBono);
            lbTotalFaltante2.Text = Format(TotalFaltante);
            lbTotalBonos2.Text = Format(TotalBono);
            lbSueltoTotal.Text = Format((TotalBono - TotalFaltante)+"");
        }

        private void DarFormatoTabla()
        {
            dgvSubTotalBonoyPena.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSubTotalBonoyPena.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
        }
        #region CheckBox and KeyPress
        private void checkCajero_CheckedChanged(object sender, EventArgs e)
        {
            if (checkFaltante.Checked)
            {
                txtImporte.Enabled = true;
                txtDescripcion.Enabled = true;
                btnAsignarFaltante.Enabled = true;
            }
            else
            {
                txtImporte.Enabled = false;
                txtDescripcion.Enabled = false;
                btnAsignarFaltante.Enabled = false;
                txtImporte.Text = "";
                txtDescripcion.Text = "";
            }
        }
        private void checkImporBono_CheckedChanged(object sender, EventArgs e)
        {
            if (checkImporBono.Checked)
            {
                txtBono.Enabled = true;
                cboxBono.Enabled = false;
                txtBono.Tag = txtBono.Text;
            }
            else
            {
                txtBono.Enabled = false;
                cboxBono.Enabled = true;
                txtBono.Text = txtBono.Tag.ToString();
            }
        }
        private void checkImporPena_CheckedChanged(object sender, EventArgs e)
        {
            if (checkImporPena.Checked)
            {
                txtPena.Enabled = true;
                cboxPena.Enabled = false;
                txtPena.Tag = txtPena.Text;
            }
            else
            {
                txtPena.Enabled = false;
                cboxPena.Enabled = true;
                txtPena.Text = txtPena.Tag.ToString();
            }
        }
        private void txtBono_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloDecimales(sender, e);
        }
        private void checkImporPena_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloDecimales(sender, e);
        }
        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloDecimales(sender, e);
        }
        #endregion
    }
}
