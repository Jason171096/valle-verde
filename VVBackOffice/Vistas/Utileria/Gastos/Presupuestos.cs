using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

using ValleVerde.Programacion.Configuracion;


namespace ValleVerde.Vistas.Utileria.Gastos
{
    public partial class Presupuestos : Form
    {
        ValleVerdeComun.ConexionBD obj = new ValleVerdeComun.ConexionBD();
        bool esSucursal = false;

        public Presupuestos(bool esSucursal)
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(datGriVieBusPres, true, false);
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(datGriViePresAnual, true, false);
            comboBoxMes.SelectedIndex = DateTime.Now.Month - 1;
            dateAno.Value = DateTime.Now.Date;
            this.esSucursal = esSucursal;
        }

        private void Presupuestos_Load(object sender, EventArgs e)      
        {
            if (esSucursal)
            {
                Sucursales();
                new Programacion.Gastos.Presupuestos().CargarPresupuesto(datGriVieBusPres, comboBoxMes, dateAno, 1, lbSucursal.Text, esSucursal);
                
                lbSucursal.Visible = true;
                lbServidor.Visible = true;

                comboBox1.Visible = true;
                checkBox1.Checked = true;
            }
            else
            {
                new Programacion.Gastos.Presupuestos().CargarPresupuesto(datGriVieBusPres, comboBoxMes, dateAno, 1, lbSucursal.Text, false /*!esSucursal*/);
                
                lbSucursal.Visible = false;
                lbServidor.Visible = false;

                comboBox1.Visible = false;
            }

            Sucursales suc = new Sucursales();
            if (!suc.HaySucursalesActivas())
            {
                checkBox1.Visible = false;
            }

            tabPage2.Parent = null;
            comboBoxMes.Enabled = false;
            dateAno.Enabled = false;
            BuscaFecha.Enabled = false;

            radioButton1.Checked = false;
            radioButton3.Checked = false;

            Totales();
            semaforo();
            Sucursales();
            Autocomplete();
        }

        private void semaforo()
        {
            // Semaforo de porcentaje
            if (tabControl1.SelectedTab == tabPage1)
            {
                foreach (DataGridViewRow row in datGriVieBusPres.Rows)
                {
                    try
                    {
                        decimal band = 0;
                        if (row.Cells["Total"].Value != null)
                            band = (Convert.ToDecimal(row.Cells["Total"].Value) / Convert.ToDecimal(row.Cells["Presupuesto"].Value)) * 100;

                        // 50% gastado             
                        if (band <= 50)
                            row.Cells["Total"].Style.BackColor = ColorTranslator.FromHtml("#74C466");
                        // 70% gastado             
                        if (band <= 30)
                            row.Cells["Total"].Style.BackColor = Color.Yellow;
                        // 95% gastado
                        if (band <= 5)
                            row.Cells["Total"].Style.BackColor = Color.Red;
                    }
                    catch (Exception) { }
                }
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                foreach (DataGridViewRow row in datGriViePresAnual.Rows)
                {
                    try
                    {
                        decimal band = 0;
                        if (row.Cells["TotalAnual"].Value != null)
                            band = (Convert.ToDecimal(row.Cells["TotalGastado"].Value) / Convert.ToDecimal(row.Cells["TotalAnual"].Value)) * 100;

                        // 50% gastado             
                        if (band >= 50)
                            row.Cells["TotalSobrante"].Style.BackColor = ColorTranslator.FromHtml("#74C466");
                        // 70% gastado             
                        if (band >= 70)
                            row.Cells["TotalSobrante"].Style.BackColor = Color.Yellow;
                        // 95% gastado
                        if (band >= 95)
                            row.Cells["TotalSobrante"].Style.BackColor = Color.Red;
                    }
                    catch (Exception ) { }
                }
            }
        }

        private void Totales()
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                decimal asignado = 0, sobrante = 0; //calcular totales y semaforo Mensual

                foreach (DataGridViewRow row in datGriVieBusPres.Rows)
                {
                    if (row.Cells["Presupuesto"].Value != null)
                        asignado += (Convert.ToDecimal(row.Cells["Presupuesto"].Value));
                }
                labelTotalAsig.Text = string.Format("{0:C}", +asignado);

                // Suma total Restante
                foreach (DataGridViewRow row in datGriVieBusPres.Rows)
                {
                    if (row.Cells["Total"].Value != null)
                        sobrante += (Convert.ToDecimal(row.Cells["Total"].Value));
                }
                labelTotalSobr.Text = string.Format("{0:C}", + sobrante);

                //Gastado
                labelTotalGast.Text = string.Format("{0:C}", +(asignado - sobrante));

                //Semaforo  totales
                if (asignado != 0)
                {
                    decimal band2 = ((asignado - sobrante) / asignado) * 100;

                    if (band2==0)
                    {
                        labelTotalSobr.Text = string.Format("{0:C}", +asignado);
                        labelTotalSobr.BackColor = Color.Transparent;
                    }
                    
                    if (band2 > 0)
                        labelTotalSobr.BackColor = Color.Transparent;
                    if (band2 >= 50)
                        labelTotalSobr.BackColor = ColorTranslator.FromHtml("#74C466");
                    if (band2 >= 70)
                        labelTotalSobr.BackColor = Color.Yellow;
                    if (band2 >= 95)
                        labelTotalSobr.BackColor = Color.Red;
                }
                
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                decimal asignado = 0, gastado = 0, sobrante = 0;//calcular totales y semaforo Anual
                
                try
                {   // Suma total Asignado
                    foreach (DataGridViewRow row in datGriViePresAnual.Rows)
                    {
                        if (row.Cells["TotalAnual"].Value != null)
                            asignado += (Convert.ToDecimal(row.Cells["TotalAnual"].Value));
                    }
                    labelTotalAsig.Text = string.Format("{0:C}", +asignado);

                    // Suma total Restante
                    foreach (DataGridViewRow row in datGriViePresAnual.Rows)
                    {
                        if (row.Cells["TotalSobrante"].Value != null)
                            sobrante += (Convert.ToDecimal(row.Cells["TotalSobrante"].Value));
                    }
                    labelTotalSobr.Text = string.Format("{0:C}", +sobrante);

                    // Gastado
                    foreach (DataGridViewRow row in datGriViePresAnual.Rows)
                    {
                        if (row.Cells["TotalGastado"].Value != null)
                            gastado += (Convert.ToDecimal(row.Cells["TotalGastado"].Value));
                    }
                    labelTotalGast.Text = string.Format("{0:C}", +gastado);

                    //Semaforo  totales
                    if (asignado != 0)
                    {
                        decimal band2 = (gastado / asignado) * 100;

                        if (band2 == 0)
                        {
                            labelTotalSobr.Text = string.Format("{0:C}", +asignado);
                            labelTotalSobr.BackColor = ColorTranslator.FromHtml("#74C466");
                        }
                        if (band2 > 0)
                            labelTotalSobr.BackColor = Color.Transparent;
                        if (band2 >= 50)
                            labelTotalSobr.BackColor = ColorTranslator.FromHtml("#74C466");
                        if (band2 >= 70)
                            labelTotalSobr.BackColor = Color.Yellow;
                        if (band2 >= 95)
                            labelTotalSobr.BackColor = Color.Red;
                    }
                }
                catch (Exception) { } 
            }
        }
        private void BtnAgregar1_Click(object sender, EventArgs e)
        {
            //new PresupuestoAgregar(lbServidor.Text, lbSucursal.Text, esSucursal).Show();
            PresupuestoAgregar obj = new PresupuestoAgregar(lbServidor.Text, lbSucursal.Text, esSucursal);
            if (esSucursal)
                obj.Text = "Agregar Gasto: " + lbSucursal.Text;

            obj.Show();
            Close();
        }

        private void radioButton1_MouseClick(object sender, MouseEventArgs e)
        {
            //mostrar todo
            comboBoxMes.Enabled = false;
            dateAno.Enabled = false;
            BuscaFecha.Enabled = false;

            if (tabControl1.SelectedTab == tabPage1)
                new Programacion.Gastos.Presupuestos().CargarPresupuesto(datGriVieBusPres, comboBoxMes, dateAno, 0, lbSucursal.Text, esSucursal);
            else if (tabControl1.SelectedTab == tabPage2)
                new Programacion.Gastos.PresupuestoAnual().CargarPresupuestoAnual(datGriViePresAnual, dateAno, 0, lbSucursal.Text, esSucursal);

            Totales();
            semaforo();
        }

        private void radioButton3_MouseClick(object sender, MouseEventArgs e)
        {
            comboBoxMes.Enabled = true;
            dateAno.Enabled = true;
            BuscaFecha.Enabled = true;
        }

        private void BuscaFecha_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
                new Programacion.Gastos.Presupuestos().CargarPresupuesto(datGriVieBusPres, comboBoxMes, dateAno, 1, lbSucursal.Text, esSucursal);
            else if (tabControl1.SelectedTab == tabPage2)
                new Programacion.Gastos.PresupuestoAnual().CargarPresupuestoAnual(datGriViePresAnual, dateAno, 1, lbSucursal.Text, esSucursal);

            Totales();
            semaforo();
        }

        //private void BtnMod1_Click(object sender, EventArgs e)
        //{
        //    //Modificar
        //    if (datGriVieBusPres.SelectedRows.Count != 0)
        //    {
        //        new PresupuestoModificar(int.Parse(datGriVieBusPres.SelectedCells[0].Value + ""), lbServidor.Text, lbSucursal.Text, esSucursal).Show();
        //        new Programacion.Gastos.Presupuestos().CargarPresupuesto(datGriVieBusPres, comboBoxMes, dateAno, 1, lbSucursal.Text, esSucursal);
        //        Close();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Primero debes seleccionar un Presupuesto de la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        private void BtnMod1_Click(object sender, EventArgs e)
        {
            //Modificar Presupuesto con autorizacion

            if (datGriVieBusPres.SelectedRows.Count != 0)
            {
                ValleVerdeComun.Vistas.InicioSesion.InicioSesion obi = new ValleVerdeComun.Vistas.InicioSesion.InicioSesion(false);
                obi.ShowDialog();
                ValleVerdeComun.Programacion.Huellas.ResultadoHuella usuario = obi.usuario;

                if (usuario != null)
                {
                    if (!usuario.esAdministrador)
                    {
                        MessageBox.Show("No tiene permiso de editar Presupuestos", "!Error¡", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        obi.Close();
                        PresupuestoModificar obj = new PresupuestoModificar(int.Parse(datGriVieBusPres.SelectedCells[0].Value + ""), lbServidor.Text, lbSucursal.Text, esSucursal);
                        if (esSucursal)
                            obj.Text = "Modificar Gasto: " + lbSucursal.Text;
                        obj.Show();
                        //new PresupuestoModificar(int.Parse(datGriVieBusPres.SelectedCells[0].Value + ""), lbServidor.Text, lbSucursal.Text, esSucursal).Show();
                        new Programacion.Gastos.Presupuestos().CargarPresupuesto(datGriVieBusPres, comboBoxMes, dateAno, 1, lbSucursal.Text, esSucursal);
                        Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Primero debes seleccionar un Presupuesto de la lista.", "!Error¡", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnElim1_Click(object sender, EventArgs e)
        {
            //Eliminar
            if (datGriVieBusPres.SelectedRows.Count != 0)
            {
                Programacion.Gastos.PresupuestoEliminar obj = new Programacion.Gastos.PresupuestoEliminar();

                DialogResult result = MessageBox.Show("¿Quieres Eliminar el Presupuesto?", "Eliminar Presupuesto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    obj.EliminarPresupuesto(int.Parse(datGriVieBusPres.SelectedCells[0].Value + ""), lbSucursal.Text, esSucursal);
                }

                semaforo();
                Totales();
                Limpiar.PerformClick();
            }
            else
            {
                MessageBox.Show("Primero debes seleccionar un Presupuesto de la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            cbBuscar.ResetText();
            comboBoxMes.SelectedIndex = DateTime.Now.Month - 1;
            dateAno.ResetText();
            comboBoxMes.Enabled = false;
            dateAno.Enabled = false;
            radioButton1.Checked = false;
            radioButton3.Checked = false;
            BuscaFecha.Enabled = false;

            if (tabControl1.SelectedTab == tabPage1)
                new Programacion.Gastos.Presupuestos().CargarPresupuesto(datGriVieBusPres, comboBoxMes, dateAno, 1,lbSucursal.Text, esSucursal);

            else if (tabControl1.SelectedTab == tabPage2)
                new Programacion.Gastos.PresupuestoAnual().CargarPresupuestoAnual(datGriViePresAnual, dateAno, 1, lbSucursal.Text, esSucursal);

            semaforo();
            Totales();
        }


        private void roundedButton1_Click(object sender, EventArgs e)
        {
            //Pestaña Mensual
            if (roundedButton1.Text == "Mensual")
            {
                if (tabPage1.Parent == null)
                {
                    tabControl1.TabPages.Insert(0, tabPage1);
                }
                tabPage2.Parent = null;
                roundedButton1.Text = "Anual";

                BtnAgregar1.Enabled = true;
                BtnMod1.Enabled = true;
                BtnElim1.Enabled = true;
                
                comboBoxMes.Visible = true;

                dateAno.Size = new Size(69, 30);
                dateAno.Location = new Point(210, 57); 

            }
            //Pestaña Anual
            else if (roundedButton1.Text == "Anual")
            {
                cbBuscar.ResetText();

                if (tabPage2.Parent == null)
                {
                    tabControl1.TabPages.Insert(0, tabPage2);
                }
                tabPage1.Parent = null;

                roundedButton1.Text = "Mensual";

                BtnAgregar1.Enabled = false;
                BtnMod1.Enabled = false;
                BtnElim1.Enabled = false;
                comboBoxMes.Visible = false;
                dateAno.Size = new Size(104, 30);
                dateAno.Location = new Point(89, 57);
            }

            Limpiar.PerformClick();
            semaforo();
            Totales();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void datGriVieBusPres_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                BtnElim1.PerformClick();
            }
        }

        private void datGriVieBusPres_DoubleClick(object sender, EventArgs e)
        {
            BtnMod1.PerformClick();
        }

        private void Autocomplete()
        {
            if (esSucursal)
            {
                try
                {
                    obj.AbrirConexionBD();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM OPENQUERY([" + lbServidor.Text + "], 'SELECT DISTINCT Descripcion FROM Presupuestos WHERE MONTH(Fecha) = MONTH(GETDATE())')", obj.ObtenerConexion());

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
                    SqlCommand cmd1 = new SqlCommand("SELECT * FROM OPENQUERY([" + lbServidor.Text + "], 'SELECT DISTINCT Descripcion FROM Presupuestos WHERE MONTH(Fecha) = MONTH(GETDATE()) ORDER BY Descripcion ASC')", obj.ObtenerConexion());

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
            //Busca en Pestañas
            if (tabControl1.SelectedTab == tabPage1)
            {
                try
                {
                    var dt = (DataTable)datGriVieBusPres.DataSource;
                    dt.DefaultView.RowFilter = "Descripcion LIKE '%" + cbBuscar.Text + "%'";
                    datGriVieBusPres.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                try
                {
                    var dt = (DataTable)datGriViePresAnual.DataSource;
                    dt.DefaultView.RowFilter = "Descripcion LIKE '%" + cbBuscar.Text + "%'";
                    datGriViePresAnual.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            semaforo();
            Totales();
        }

        private void cbBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            new Validaciones().SoloNumerosyLetras(sender, e);
        }

        private void cbBuscar_TextChanged(object sender, EventArgs e)
        {
            //Busca en Pestañas
            if (tabControl1.SelectedTab == tabPage1)
            {
                try
                {
                    var dt = (DataTable)datGriVieBusPres.DataSource;
                    dt.DefaultView.RowFilter = "Descripcion LIKE '%" + cbBuscar.Text + "%'";
                    datGriVieBusPres.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                try
                {
                    var dt = (DataTable)datGriViePresAnual.DataSource;
                    dt.DefaultView.RowFilter = "Descripcion LIKE '%" + cbBuscar.Text + "%'";
                    datGriViePresAnual.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            semaforo();
            Totales();
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                esSucursal = true;
                lbSucursal.Visible = true;
                lbServidor.Visible = true;

                new Programacion.Gastos.Presupuestos().CargarPresupuesto(datGriVieBusPres, comboBoxMes, dateAno, 1, lbSucursal.Text, esSucursal);
                
                comboBox1.Visible = true;

            }
            else
            {
                esSucursal = false;
                lbServidor.Visible = false;
                lbSucursal.Visible = false;
                comboBox1.Visible = false;

                new Programacion.Gastos.Presupuestos().CargarPresupuesto(datGriVieBusPres, comboBoxMes, dateAno, 1, lbSucursal.Text, esSucursal);
            }
           
            Totales();
            semaforo();
            Sucursales();
            Autocomplete();
        }

        public void Sucursales()
        {
            DataTable dt1 = new DataTable();

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.SelectedItem = comboBox1.SelectedItem;
            lbSucursal.Text = comboBox1.Text;
            lbServidor.Text = comboBox2.Text;
            
            try
            {
                new Programacion.Gastos.Presupuestos().CargarPresupuesto(datGriVieBusPres, comboBoxMes, dateAno, 1, lbSucursal.Text, esSucursal);
            }
            catch(Exception)
            {
                MessageBox.Show("Sucursal Sin Conexión", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
