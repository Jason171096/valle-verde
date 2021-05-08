using Microsoft.Office.Core;
using Pabo.Calendar;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ValleVerde.Vistas.Utileria.Gastos
{
    public partial class GastoAgregar : Form
    {
        ValleVerdeComun.ConexionBD obj = new ValleVerdeComun.ConexionBD();
        bool esSucursal;
        string nomSucursal;
        string nomServidor;

        public GastoAgregar(string nomServidor, string nomSucursal, bool esSucursal)
        {
            InitializeComponent();
            dateTimePicker6.Value = DateTime.Now.Date;       
            dateTimePicker6.MaxDate = DateTime.Now.AddDays(1);
            dateTimePicker6.MinDate = DateTime.Now.AddDays(-30);
            this.nomSucursal = nomSucursal;
            this.esSucursal = esSucursal;
            this.nomServidor = nomServidor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargaDescripcion();

            if (esSucursal)
            {
                lbSucursal.Visible = true;
                lbSucursal.Text = nomSucursal;  
            }
        }

        private void CargaDescripcion()
        {
            DataTable dt1 = new DataTable();
            if (esSucursal)
            {
                try
                {
                    obj.AbrirConexionBD();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM OPENQUERY([" + nomServidor + "], 'SELECT DISTINCT Descripcion, IDPresupuesto FROM Presupuestos WHERE MONTH(Fecha) = MONTH(GETDATE()) ORDER BY Descripcion ASC ')", obj.ObtenerConexion());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt1);

                    comboBox1.DisplayMember = "IDPresupuesto";
                    comboBox2.DisplayMember = "Descripcion";

                    comboBox1.DataSource = dt1;
                    comboBox2.DataSource = dt1;

                    obj.CerrarConexionBD();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo llenar los campos: " + ex.ToString());
                }
            }
            else
            {
                try
                {
                    obj.AbrirConexionBD();
                    SqlCommand cmd = new SqlCommand("SELECT DISTINCT Descripcion, IDPresupuesto FROM Presupuestos WHERE MONTH(Fecha) = MONTH(GETDATE()) ORDER BY Descripcion ASC ", obj.ObtenerConexion());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt1);

                    comboBox1.DisplayMember = "IDPresupuesto";
                    comboBox2.DisplayMember = "Descripcion";

                    comboBox1.DataSource = dt1;
                    comboBox2.DataSource = dt1;

                    obj.CerrarConexionBD();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo llenar los campos: " + ex.ToString());
                }
            }
            
        }

        private void butAgr_Click(object sender, EventArgs e)
        {
            try
            {
                int band= new Programacion.Gastos.Presupuestos().PDisponible(0, int.Parse(comboBox1.Text), decimal.Parse(textBox1.Text),  comboBox2.Text, false, nomServidor, esSucursal);
                if (band == 1)
                {
                    try
                    {
                        new Programacion.Gastos.GastosAgregar().AgregarGasto(dateTimePicker6.Value, int.Parse(comboBox1.Text), decimal.Parse(textBox1.Text), textBox2.Text, textBox3.Text, nomSucursal, esSucursal);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al agregar Gasto", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Close();
                    new Gastos(esSucursal).Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al agregar Gasto", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            new Gastos(esSucursal).Show();
            Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            new Validaciones().SoloDecimales(sender, e);
            if (Convert.ToInt32(e.KeyChar) == 13)
                butAgr.PerformClick();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
                textBox1.Focus();
        }
    }
}
