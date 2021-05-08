using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ValleVerde.Vistas.Utileria.Gastos
{
    public partial class PresupuestoAgregar : Form
    {
        ValleVerdeComun.ConexionBD obj = new ValleVerdeComun.ConexionBD();
        string nomSucursal;
        string nomServidor;
        bool esSucursal;

        public PresupuestoAgregar(string nomServidor, string nomSucursal, bool esSucursal)
        {
            InitializeComponent();
            this.nomSucursal = nomSucursal;
            this.esSucursal = esSucursal;
            this.nomServidor = nomServidor;
        }

        private void PresupuestoAgregar_Load(object sender, EventArgs e)
        {
            CargaDescripcion();

            if (esSucursal)
            {
                lbSucursal.Visible = true;
                lbSucursal.Text = nomSucursal;
            }
        }

        private void butAgr_Click(object sender, EventArgs e)
        {
            try
            {
                new Programacion.Gastos.PresupuestoAgregar().AgregarPresupuesto(comboBox1.Text, textBox1.Text, checkBox1.Checked, nomSucursal, esSucursal);
                new Presupuestos(esSucursal).Show();
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Primero debes llenar los campos" + ex, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

     
        private void roundedButton1_Click(object sender, EventArgs e)
        {
            new Presupuestos(esSucursal).Show();
            Close();

        }

        private void CargaDescripcion()
        {
            DataTable dt1 = new DataTable();
            if (esSucursal)
            {
                try
                {
                    obj.AbrirConexionBD();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM OPENQUERY(["+nomServidor+"], 'SELECT DISTINCT Descripcion FROM Presupuestos WHERE MONTH(Fecha) = MONTH(GETDATE()) ORDER BY Descripcion ASC ')", obj.ObtenerConexion());

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt1);

                    comboBox1.DisplayMember = "Descripcion";
                    comboBox1.DataSource = dt1;

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
                    SqlCommand cmd = new SqlCommand("SELECT DISTINCT Descripcion FROM Presupuestos WHERE MONTH(Fecha) = MONTH(GETDATE()) ORDER BY Descripcion ASC ", obj.ObtenerConexion());

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt1);

                    comboBox1.DisplayMember = "Descripcion";
                    comboBox1.DataSource = dt1;

                    obj.CerrarConexionBD();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo llenar los campos: " + ex.ToString());
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            new Validaciones().SoloDecimales(sender, e);
            if (Convert.ToInt32(e.KeyChar) == 13)
                butAgr.PerformClick();
        }
    }
}
