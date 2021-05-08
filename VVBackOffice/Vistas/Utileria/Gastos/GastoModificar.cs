using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion.Gastos;

namespace ValleVerde.Vistas.Utileria.Gastos
{
    public partial class GastoModificar : Form
    {
        ValleVerdeComun.ConexionBD obj = new ValleVerdeComun.ConexionBD();        
        readonly int IDGasto;
        bool esSucursal;
        string nomSucursal;
        string nomServidor;

        public GastoModificar(int IDGasto, string nomServidor, string nomSucursal, bool esSucursal)
        {
            InitializeComponent();
            
            this.IDGasto = IDGasto;
            this.nomSucursal = nomSucursal;
            this.esSucursal = esSucursal;
            this.nomServidor = nomServidor;

            CargaGasto();
           
            if (esSucursal)
            {
                lbSucursal.Visible = true;
                lbSucursal.Text = nomSucursal;

            }
        }
        public void CargaGasto()
        {
            if (esSucursal)
            {
                try
                {
                    obj.AbrirConexionBD();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM OPENQUERY([" + nomServidor + "], 'Select g.IDGasto, g.Fecha, p.Descripcion, g.Observacion, g.Importe, g.IDPresupuesto, g.Folio from Gastos g inner join Presupuestos p on g.IDPresupuesto = p.IDPresupuesto where IDGasto=" + IDGasto + "')", obj.ObtenerConexion());
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        textBox4.Text = dr["IDGasto"].ToString();
                        dateTimePicker6.Text = dr["Fecha"].ToString();
                        comboBox2.Text = dr["Descripcion"].ToString();
                        textBox2.Text = dr["Observacion"].ToString();
                        textBox1.Text = dr["Importe"].ToString();
                        textBox3.Text = dr["IDPresupuesto"].ToString();
                        textBox5.Text = dr["Folio"].ToString();
                    }
                    dr.Close();
                    obj.CerrarConexionBD();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo llenar los campos: " + ex.ToString(), "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    obj.AbrirConexionBD();
                    SqlCommand cmd = new SqlCommand("Select * from Gastos g inner join Presupuestos p on g.IDPresupuesto = p.IDPresupuesto where IDGasto=" + IDGasto + "", obj.ObtenerConexion());
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        textBox4.Text = dr["IDGasto"].ToString();
                        dateTimePicker6.Text = dr["Fecha"].ToString();
                        comboBox2.Text = dr["Descripcion"].ToString();
                        textBox2.Text = dr["Observacion"].ToString();
                        textBox1.Text = dr["Importe"].ToString();
                        textBox3.Text = dr["IDPresupuesto"].ToString();
                        textBox5.Text = dr["Folio"].ToString();
                    }
                    dr.Close();
                    obj.CerrarConexionBD();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo llenar los campos: " + ex.ToString(), "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (dateTimePicker6.Value < DateTime.Now.AddMonths(-1))
            {
                MessageBox.Show("Se recomienda NO modificar un gasto mayor a un mes de antigûedad", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void butMod_Click(object sender, EventArgs e)
        {
            int band = new Programacion.Gastos.Presupuestos().PDisponible(int.Parse(textBox4.Text), int.Parse(textBox3.Text), decimal.Parse(textBox1.Text), comboBox2.Text, true, nomServidor, esSucursal);
            if (band == 1)
            {
                try
                {
                    new Programacion.Gastos.GastosModificar().ModificarGasto(int.Parse(textBox4.Text), dateTimePicker6.Value, int.Parse(textBox3.Text), decimal.Parse(textBox1.Text), textBox2.Text, textBox5.Text, nomSucursal, esSucursal);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al Modificar", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Close();
                new Gastos(esSucursal).Show();
            }
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            new Gastos(esSucursal).Show();
            Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            new Validaciones().SoloDecimales(sender, e);
            if (Convert.ToInt32(e.KeyChar) == 13)
                butMod.PerformClick();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
                textBox5.Focus();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
                textBox1.Focus();
        }
    }
}
