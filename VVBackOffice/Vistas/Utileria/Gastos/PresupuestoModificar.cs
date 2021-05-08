using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ValleVerde.Programacion.Gastos;

namespace ValleVerde.Vistas.Utileria.Gastos
{
    public partial class PresupuestoModificar : Form
    {
        ValleVerdeComun.ConexionBD obj = new ValleVerdeComun.ConexionBD();
        int IDPresupuesto;
        string nomSucursal;
        string nomServidor;
        bool esSucursal;

        SqlDataReader dr;


        public PresupuestoModificar(int IDPresupuesto, string nomServidor, string nomSucursal, bool esSucursal)
        {
            InitializeComponent();
            this.IDPresupuesto = IDPresupuesto;
            this.nomSucursal = nomSucursal;
            this.esSucursal = esSucursal;
            this.nomServidor = nomServidor;

            CargaPresupuesto();
            
            if (esSucursal)
            {
                lbSucursal.Visible = true;
                lbSucursal.Text = nomSucursal;
            }
        }

        public void CargaPresupuesto()
        {
            if (esSucursal)
            {
                try
                {
                    obj.AbrirConexionBD();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM OPENQUERY([" + nomServidor + "], 'SELECT * FROM Presupuestos WHERE IDPresupuesto= " + IDPresupuesto + "')", obj.ObtenerConexion());

                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        textBox1.Text = dr["Descripcion"].ToString();
                        textBox3.Text = dr["IDPresupuesto"].ToString();
                        textBox2.Text = dr["Presupuesto"].ToString();
                        checkBox1.Checked = Convert.ToBoolean(dr["Recurrente"]);
                        dateTimePicker6.Text = dr["Fecha"].ToString();
                    }
                    dr.Close();
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
                    SqlCommand cmd = new SqlCommand("Select * from Presupuestos where IDPresupuesto= " + IDPresupuesto + "", obj.ObtenerConexion());
                    
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        textBox1.Text = dr["Descripcion"].ToString();
                        textBox3.Text = dr["IDPresupuesto"].ToString();
                        textBox2.Text = dr["Presupuesto"].ToString();
                        checkBox1.Checked = Convert.ToBoolean(dr["Recurrente"]);
                        dateTimePicker6.Text = dr["Fecha"].ToString();
                    }
                    dr.Close();
                    obj.CerrarConexionBD();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo llenar los campos: " + ex.ToString());
                }
            }

            if (dateTimePicker6.Value < DateTime.Now.AddMonths(-1))
            {
                MessageBox.Show("Se recomienda NO modificar un Presupuesto mayor a un mes de antigûedad", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void butMod_Click(object sender, EventArgs e)
        {
            try
            {
                new Programacion.Gastos.PresupuestoModificar().ModificarPresupuesto(int.Parse(textBox3.Text), textBox1.Text, decimal.Parse(textBox2.Text), checkBox1.Checked, nomSucursal, esSucursal);
            }
            catch (Exception)
            {
                MessageBox.Show("Primero debes llenar los campos", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Close();
            new Presupuestos(esSucursal).Show();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            new Presupuestos(esSucursal).Show();
            Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            new Validaciones().SoloDecimales(sender, e);
            if (Convert.ToInt32(e.KeyChar) == 13)
                butMod.PerformClick();
        }
    }
}
