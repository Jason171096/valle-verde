using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

using ValleVerde.Programacion.Configuracion;

namespace ValleVerde.Vistas.Utileria.Gastos
{
    public partial class Gastos : Form
    {
        ValleVerdeComun.ConexionBD obj = new ValleVerdeComun.ConexionBD();
        bool esSucursal = false;
        
        public Gastos(bool esSucursal)
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(datGriVieGasto, true, false);

            dateTimePicker1.Value = DateTime.Now.Date;
            dateTimePicker2.Value = DateTime.Now.Date;
            this.esSucursal = esSucursal;
        }

        private void Gastos_Load(object sender, EventArgs e)
        {
            if (esSucursal)
            {
                Sucursales();
                new Programacion.Gastos.Gastos().CargarGastos(datGriVieGasto, dateTimePicker1, dateTimePicker2, 1, lbSucursal.Text, esSucursal);
                lbSucursal.Visible = true;
                lbServidor.Visible = true;

                comboBox1.Visible = true;
                checkBox1.Checked = true;
            }
            else
            {
                new Programacion.Gastos.Gastos().CargarGastos(datGriVieGasto, dateTimePicker1, dateTimePicker2, 1, lbSucursal.Text, false);
                lbSucursal.Visible = false;
                lbServidor.Visible = false;

                comboBox1.Visible = false;
            }

            Sucursales suc = new Sucursales();
            if (!suc.HaySucursalesActivas())
            {
                checkBox1.Visible = false;
            }

            semaforo();
            TotalGastado();
            PreparaBusquedas();
            Sucursales();
            Autocomplete();
        }

        private void PreparaBusquedas()
        {
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            BuscaFecha.Enabled = false;
        }

        private void semaforo()
        {
            // Semaforo de porcentaje. Agrega color a celdas
            foreach (DataGridViewRow row in datGriVieGasto.Rows)
            {
                try
                {
                    //obtiene el porcentaje del presupuesto restante
                    decimal band = (Convert.ToDecimal(row.Cells["GTotal"].Value) / Convert.ToDecimal(row.Cells["Presupuesto"].Value)) * 100;

                    // 50% gastado             
                    if (band >= 50)
                        row.Cells["Total"].Style.BackColor = ColorTranslator.FromHtml("#74C466");
                    // 70% gastado             
                    if (band >= 70)
                        row.Cells["Total"].Style.BackColor = Color.Yellow;
                    // 95% gastado
                    if (band >= 95)
                        row.Cells["Total"].Style.BackColor = Color.Red;
                }
                catch (Exception) { }
            }
        }

        private void BtnAgregar1_Click(object sender, EventArgs e)
        {
            //new GastoAgregar(lbServidor.Text, lbSucursal.Text, esSucursal).Show();
            GastoAgregar obj = new GastoAgregar(lbServidor.Text, lbSucursal.Text, esSucursal);
            if(esSucursal)
                obj.Text = "Agregar Gasto: "+lbSucursal.Text;
            
            obj.Show();
            Close();
        }

        //private void BtnMod1_Click(object sender, EventArgs e)
        //{
        //    if (datGriVieGasto.SelectedRows.Count != 0)
        //    {
        //        new GastoModificar(int.Parse(datGriVieGasto.SelectedCells[0].Value + ""), lbServidor.Text, lbSucursal.Text, esSucursal).Show();            
        //        new Programacion.Gastos.Gastos().CargarGastos(datGriVieGasto, dateTimePicker1, dateTimePicker2, 1, lbSucursal.Text, esSucursal);
        //        Close();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Primero debes seleccionar un gasto de la lista.", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        private void BtnMod1_Click(object sender, EventArgs e) 
        { 
            //modificar Gasto con autorizacion
            
            if (datGriVieGasto.SelectedRows.Count != 0)
            {
                ValleVerdeComun.Vistas.InicioSesion.InicioSesion obi = new ValleVerdeComun.Vistas.InicioSesion.InicioSesion(false);
                obi.ShowDialog();
                ValleVerdeComun.Programacion.Huellas.ResultadoHuella usuario = obi.usuario;


                if (usuario != null)
                {
                    if (!usuario.esAdministrador)
                    {
                        MessageBox.Show("No tiene permisos para editar Gastos", "!Error¡", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        obi.Close();
                        GastoModificar obj = new GastoModificar(int.Parse(datGriVieGasto.SelectedCells[0].Value + ""), lbServidor.Text, lbSucursal.Text, esSucursal);

                        if (esSucursal)
                            obj.Text = "Modificar Gasto: " + lbSucursal.Text;
                        obj.Show();
                        //new GastoModificar(int.Parse(datGriVieGasto.SelectedCells[0].Value + ""), lbServidor.Text, lbSucursal.Text, esSucursal).Show();
                        new Programacion.Gastos.Gastos().CargarGastos(datGriVieGasto, dateTimePicker1, dateTimePicker2, 1, lbSucursal.Text, esSucursal);
                        Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Primero debes seleccionar un gasto de la lista.", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnElim1_Click(object sender, EventArgs e)
        {
            if (datGriVieGasto.SelectedRows.Count != 0)
            {
                Programacion.Gastos.GastosEliminar obj = new Programacion.Gastos.GastosEliminar();
                
                DialogResult result = MessageBox.Show("¿Quieres Eliminar el Gasto?", "Eliminar Gasto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    obj.EliminarGasto(int.Parse(datGriVieGasto.SelectedCells[0].Value + ""), lbSucursal.Text, esSucursal); 
                }

                semaforo();
                TotalGastado();
                Limpiar.PerformClick();
            }
            else
            {
                MessageBox.Show("Primero debes seleccionar un gasto de la lista.", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void Limpiar_Click(object sender, EventArgs e)
        {
            new Programacion.Gastos.Gastos().CargarGastos(datGriVieGasto, dateTimePicker1, dateTimePicker2, 1, lbSucursal.Text, esSucursal);
            semaforo();
            TotalGastado();

            dateTimePicker1.ResetText();
            dateTimePicker1.Enabled = false;
            dateTimePicker2.ResetText();
            dateTimePicker2.Enabled = false;
            BuscaFecha.Enabled = false;
            cbBuscar.ResetText();
            radioButton1.Checked = false;
            radioButton3.Checked = false;
        }

        private void BuscaFecha_Click(object sender, EventArgs e)
        {
            // band en -1 para cargar por fechas
            new Programacion.Gastos.Gastos().CargarGastos(datGriVieGasto, dateTimePicker1, dateTimePicker2, -1, lbSucursal.Text, esSucursal);
            TotalGastado();
            semaforo();
        }

        private void  TotalGastado() 
        {
            // Suma total gastado
            decimal suma = 0;
            foreach (DataGridViewRow row in datGriVieGasto.Rows)
            {
                if (row.Cells["Importe"].Value != null )
                    suma += (Convert.ToDecimal(row.Cells["Importe"].Value));
            }
            labelTotalGasto.Text = string.Format("{0:C}", + suma);
        }
        
        private void radioButton3_MouseClick(object sender, MouseEventArgs e)
        {
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
            BuscaFecha.Enabled = true;
            cbBuscar.ResetText();
        }

        private void radioButton1_MouseClick(object sender, MouseEventArgs e) 
        {
            //band en 0 para cargar todos los gastos
            new Programacion.Gastos.Gastos().CargarGastos(datGriVieGasto, dateTimePicker1, dateTimePicker2, 0, lbSucursal.Text, esSucursal);
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            BuscaFecha.Enabled = false;
            cbBuscar.ResetText();
            semaforo();
            TotalGastado();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void datGriVieGasto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                BtnElim1.PerformClick();
            }
        }

        private void datGriVieGasto_DoubleClick(object sender, EventArgs e)
        {
            BtnMod1.PerformClick();
        }

        private void cbBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            new Validaciones().SoloNumerosyLetras(sender, e);
        }

        private void cbBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var dt = (DataTable)datGriVieGasto.DataSource;
                dt.DefaultView.RowFilter = string.Format("Convert(Importe, 'System.String') LIKE '%{0}%' OR Descripcion LIKE '%{0}%' OR Observacion LIKE '%{0}%' OR Folio LIKE '%{0}%'", cbBuscar.Text);
                datGriVieGasto.Refresh();
                semaforo();
                TotalGastado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void Autocomplete()
        {
            if (esSucursal)
            {
                try
                {
                    obj.AbrirConexionBD();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM OPENQUERY ([" + lbServidor.Text + "], 'SELECT DISTINCT Descripcion FROM Presupuestos WHERE MONTH(Fecha) = MONTH(GETDATE())')", obj.ObtenerConexion());

                    DataSet ds = new DataSet();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds, "Descripcion");
                    AutoCompleteStringCollection col = new
                    AutoCompleteStringCollection();
                    int i = 0;
                    for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        col.Add(ds.Tables[0].Rows[i]["Descripcion"].ToString());

                    }

                    cbBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    cbBuscar.AutoCompleteCustomSource = col;
                    cbBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
                    obj.CerrarConexionBD();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                DataTable dt1 = new DataTable();
                try
                {
                    obj.AbrirConexionBD();
                    SqlCommand cmd1 = new SqlCommand("SELECT * FROM OPENQUERY ([" + lbServidor.Text + "], 'SELECT DISTINCT Descripcion FROM Presupuestos WHERE MONTH(Fecha) = MONTH(GETDATE()) ORDER BY Descripcion ASC')", obj.ObtenerConexion());
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    da1.Fill(dt1);

                    cbBuscar.DisplayMember = "Descripcion";
                    cbBuscar.DataSource = dt1;
                    cbBuscar.ResetText();
                    obj.CerrarConexionBD();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    obj.AbrirConexionBD();
                    SqlCommand cmd = new SqlCommand("SELECT DISTINCT Descripcion FROM Presupuestos WHERE MONTH(Fecha) = MONTH(GETDATE())", obj.ObtenerConexion());

                    DataSet ds = new DataSet();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds, "Descripcion");
                    AutoCompleteStringCollection col = new
                    AutoCompleteStringCollection();
                    int i = 0;
                    for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        col.Add(ds.Tables[0].Rows[i]["Descripcion"].ToString());

                    }
                  
                    cbBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    cbBuscar.AutoCompleteCustomSource = col;
                    cbBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
                    obj.CerrarConexionBD();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                DataTable dt1 = new DataTable();
                try
                {
                    obj.AbrirConexionBD();
                    SqlCommand cmd1 = new SqlCommand("SELECT DISTINCT Descripcion FROM Presupuestos WHERE MONTH(Fecha) = MONTH(GETDATE()) ORDER BY Descripcion ASC", obj.ObtenerConexion());
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    da1.Fill(dt1);

                    cbBuscar.DisplayMember = "Descripcion";
                    cbBuscar.DataSource = dt1;
                    cbBuscar.ResetText();
                    obj.CerrarConexionBD();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var dt = (DataTable)datGriVieGasto.DataSource;
                dt.DefaultView.RowFilter = "Descripcion LIKE '%" + cbBuscar.Text + "%'";
                datGriVieGasto.Refresh();
                semaforo();
                TotalGastado();
            }
            catch (Exception){ }
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                esSucursal = true;
                lbSucursal.Visible = true;
                lbServidor.Visible = true;
                
                new Programacion.Gastos.Gastos().CargarGastos(datGriVieGasto, dateTimePicker1, dateTimePicker2, 0, lbSucursal.Text, esSucursal);

                comboBox1.Visible = true;
            }
            else
            {
                esSucursal = false;
                lbServidor.Visible = false;
                lbSucursal.Visible = false;
                comboBox1.Visible = false;

                new Programacion.Gastos.Gastos().CargarGastos(datGriVieGasto, dateTimePicker1, dateTimePicker2, 0, lbSucursal.Text, esSucursal);
            }

            TotalGastado();
            semaforo();
            Sucursales();
            Autocomplete();
        }

        public void Sucursales()
        {
            DataTable dt1 = new DataTable();
            try
            {
                obj.AbrirConexionBD();
                SqlCommand cmd = new SqlCommand("SELECT Nombre, NombreServidor FROM Sucursal WHERE EstadoS = 1", obj.ObtenerConexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt1);

                comboBox1.DisplayMember = "Nombre";
                comboBox2.DisplayMember = "NombreServidor";
                comboBox1.DataSource = dt1;
                comboBox2.DataSource = dt1;

                obj.CerrarConexionBD();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sucursal", "¡Error!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.SelectedItem = comboBox1.SelectedItem;
            lbSucursal.Text = comboBox1.Text;
            lbServidor.Text = comboBox2.Text;

            try
            {
                new Programacion.Gastos.Gastos().CargarGastos(datGriVieGasto, dateTimePicker1, dateTimePicker2, 0, lbSucursal.Text, esSucursal);
            }
            catch (Exception)
            {
                MessageBox.Show("Sucursal Sin Conexión", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}