using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ValleVerde.Programacion;
using ValleVerde.Programacion.RecursosHumanos;

namespace ValleVerde.Vistas.RecursosHumanos
{
    public partial class RegistroCliente : Form
    {
        Cliente cliente = new Cliente();
        ObtenerCliente obtenerCliente = new ObtenerCliente();
        Validaciones v = new Validaciones();
        DatosClientes datosClientes;
        List<String[]> correos;
        public RegistroCliente(DatosClientes datosClientes)
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvCorreo, true, false);
            foreach (DataGridViewColumn column in dgvCorreo.Columns)
            {
                column.ReadOnly = false;
            }
            dgvCorreo.Columns[2].ReadOnly = true;
            dgvCorreo.AllowUserToAddRows = true;
            dgvCorreo.AllowUserToDeleteRows = true;
            dgvCorreo.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //Valores por defecto cuando se va a registrar nuevo cliente
            checkBoxCredito.Checked = false;
            txtDiasCredito.Enabled = false;
            txtLimiteCredito.Enabled = false;
            rbtnDescuento.Checked = false;
            rbtnUtilidad.Checked = false;
            textBoxDescuento.Enabled = false;
            textBoxUtilidad.Enabled = false;
            textBoxDescuento.Text = "-1.00";
            textBoxUtilidad.Text = "-1.00";
            txtDiasCredito.Text = "-1";
            txtLimiteCredito.Text = "-1";
            this.datosClientes = datosClientes;
            //Si los datosClientes arroja datos nulos entonces se declara que se va registrar nuevo cliente 
            if (datosClientes == null)
            {
                Text = "Alta Cliente";
                textBoxID.Enabled = false;
                label15.Enabled = false;
                btnBuscarCliente.Visible = false;
                btnModificarCliente.Visible = false;
            }//Si no es asi entonces esto significa que va a modificar el cliente
            else
            {
                Text = "Modificar Cliente";
                btnDarAlta.Visible = false;
                checkBoxActivo.Visible = true;
                LlenarClientes();
            }
        }
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            Close();//Cierra la ventana de ModificaCliente para abrir de nuevo el BuscarCliente
            BuscarCliente bc = new BuscarCliente();
            bc.ShowDialog();
            DatosClientes datosClientes = bc.ObtenerCliente();
            RegistroCliente obj = new RegistroCliente(datosClientes);
            obj.Show();

        }
        #region RadioButton and CheckBox
        private void rbtnDescuento_CheckedChanged_1(object sender, EventArgs e)
        {//Si el radiobutton es presionado se activa el textbox y se limpia su text
            if (rbtnDescuento.Checked)
            {
                textBoxDescuento.Enabled = true;
                textBoxDescuento.Text = "";
            }
            else
            {//Si es lo contrario se desactiva y se le manda un valor de -1
                textBoxDescuento.Enabled = false;
                textBoxDescuento.Text = "-1.00";
            }
        }

        private void rbtnUtilidad_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbtnUtilidad.Checked)
            {//Si el radiobutton es presionado se activa el textbox y se limpia su text
                textBoxUtilidad.Enabled = true;
                textBoxUtilidad.Text = "";
            }
            else
            {//Si es lo contrario se desactiva y se le manda un valor de -1
                textBoxUtilidad.Enabled = false;
                textBoxUtilidad.Text = "-1.00";
            }
        }

        private void checkBoxCredito_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBoxCredito.Checked)
            {//Si se presiona el checkbox de credito este habilita los cuandros de texto y los limpia
                txtDiasCredito.Enabled = true;
                txtLimiteCredito.Enabled = true;
                txtDiasCredito.Text = "";
                txtLimiteCredito.Text = "";
            }
            else
            {//Si lo desactiva los declara como desabilitados y les asigna un valor de -1
                txtDiasCredito.Enabled = false;
                txtLimiteCredito.Enabled = false;
                txtDiasCredito.Text = "-1";
                txtLimiteCredito.Text = "-1";
            }
        }
        #endregion
        #region AltayModificar
        private void btnDarAlta_Click(object sender, EventArgs e)
        {
            //No pueden estar vacios el txt de nombre y de apellido
            if (String.IsNullOrWhiteSpace(textBoxNom.Text))// || String.IsNullOrWhiteSpace(textBoxApe.Text))
                MessageBox.Show("No pueden estar los campos vacios de NOMBRE y APELLIDOS", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (!checkBoxCredito.Checked)//Si no esta activado 
            {
                if (String.IsNullOrWhiteSpace(textBoxUtilidad.Text) || String.IsNullOrWhiteSpace(textBoxDescuento.Text))
                {//Si sus valores estan vacio o en espacios en blanco se le asigna por defecto el valor de -1
                    textBoxUtilidad.Text = "-1.00";
                    textBoxDescuento.Text = "-1.00";
                }
                //Se da de alta el cliente
                AltaCliente();
                BorrarDatos();
            }
            else if (checkBoxCredito.Checked)
            {
                //No puende estar los txt de credito y de limitecrdito vacios 
                if (String.IsNullOrWhiteSpace(txtDiasCredito.Text) || String.IsNullOrWhiteSpace(txtLimiteCredito.Text))
                    MessageBox.Show("No pueden estar los campos vacios de CREDITO", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    //Se da de alta el cliente con su respectivo credito 
                    AltaCliente();
                    cliente.AltaCredito(txtDiasCredito.Text, txtLimiteCredito.Text);
                    BorrarDatos();
                }
            }
        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxNom.Text))// || String.IsNullOrWhiteSpace(textBoxApe.Text))
                MessageBox.Show("No pueden estar los campos vacios de NOMBRE y APELLIDOS", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (!checkBoxCredito.Checked)
            {
                if (String.IsNullOrWhiteSpace(textBoxUtilidad.Text) || String.IsNullOrWhiteSpace(textBoxDescuento.Text))
                {
                    textBoxUtilidad.Text = "-1.00";
                    textBoxDescuento.Text = "-1.00";
                }//Se modifica el cliente
                ModificarCliente();

            }
            else if (checkBoxCredito.Checked)
            {
                if (String.IsNullOrWhiteSpace(textBoxUtilidad.Text) || String.IsNullOrWhiteSpace(textBoxDescuento.Text))
                {
                    textBoxUtilidad.Text = "-1.00";
                    textBoxDescuento.Text = "-1.00";
                }
                if (String.IsNullOrWhiteSpace(txtDiasCredito.Text) || String.IsNullOrWhiteSpace(txtLimiteCredito.Text))
                    MessageBox.Show("No pueden estar los campos vacios de CREDITO", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    ModificarCliente();
                }
            }
        }

        private void AltaCliente()
        {
             string idcliente = cliente.AltaCliente(textBoxNom.Text, textBoxApe.Text, textBoxDir.Text, textBoxNumExt.Text, textBoxNumInt.Text, textBoxCP.Text, textBoxCol.Text, textBoxLoca.Text, textBoxCiu.Text, textBoxEstado.Text, textBoxPais.Text, textBoxTel.Text, textBoxRFC.Text, textBoxUtilidad.Text, textBoxDescuento.Text, checkBoxCredito.Checked, checkBoxPerFis.Checked);
            int numRows = dgvCorreo.Rows.Count;
            for (int i = 0; i < numRows; i++)
            {
                string correo = (string)dgvCorreo[1, i].Value;
                if (!String.IsNullOrWhiteSpace(correo))
                    cliente.AltaClienteCorreo(idcliente, correo);
            }
        }
        private void ModificarCliente()
        {
            cliente.ModificarCliente(textBoxID.Text, textBoxNom.Text, textBoxApe.Text, textBoxDir.Text, textBoxNumExt.Text, textBoxNumInt.Text, textBoxCP.Text,
                    textBoxCol.Text, textBoxLoca.Text, textBoxCiu.Text, textBoxEstado.Text, textBoxPais.Text, textBoxTel.Text,
                    textBoxRFC.Text, textBoxUtilidad.Text, textBoxDescuento.Text, checkBoxCredito.Checked,
                    checkBoxPerFis.Checked, txtDiasCredito.Text, txtLimiteCredito.Text, checkBoxActivo.Checked);
            int numRows = dgvCorreo.Rows.Count;
            for (int i = 0; i < numRows; i++)
            {
                string idcorreo = (string)dgvCorreo[0, i].Value;
                string correo = (string)dgvCorreo[1, i].Value;
                if (!String.IsNullOrWhiteSpace(correo))
                    cliente.ModificarClienteCorreo(idcorreo, textBoxID.Text, correo);
            }
        }
        #endregion
        #region LLenarDatosCliente
        public void LlenarClientes()
        {
            textBoxID.Text = datosClientes.idcliente.ToString();
            textBoxNom.Text = datosClientes.nombres;
            textBoxApe.Text = datosClientes.apellidos;
            textBoxDir.Text = datosClientes.direccion;
            textBoxNumExt.Text = datosClientes.numeroexterior;
            textBoxNumInt.Text = datosClientes.numerointerior;
            textBoxCP.Text = datosClientes.CP;
            textBoxCol.Text = datosClientes.colonia;
            textBoxLoca.Text = datosClientes.localidad;
            textBoxCiu.Text = datosClientes.ciudad;
            textBoxEstado.Text = datosClientes.estado;
            textBoxTel.Text = datosClientes.telefono;
            textBoxPais.Text = datosClientes.pais;
            textBoxRFC.Text = datosClientes.RFC;
            checkBoxCredito.Checked = datosClientes.credito;
            checkBoxPerFis.Checked = datosClientes.personafisica;
            txtDiasCredito.Text = datosClientes.diascredito.ToString();
            txtLimiteCredito.Text = datosClientes.limitecredito.ToString();
            checkBoxActivo.Checked = datosClientes.activo;

            if (datosClientes.descuentogeneral.ToString() != "-1.00")
            {//Si su valor es diferente a -1 entonces significa que el cliente tiene descuento general 
                rbtnDescuento.Checked = true;
                textBoxDescuento.Enabled = true;
                textBoxDescuento.Text = datosClientes.descuentogeneral.ToString();
            }
            else if (datosClientes.utilidadcosto.ToString() != "-1.00")
            {//Si su valor es diferente a -1 entonces significa que el cliente tiene utilidad costo
                rbtnUtilidad.Checked = true;
                textBoxUtilidad.Enabled = true;
                textBoxUtilidad.Text = datosClientes.utilidadcosto.ToString();
            }
            else
            {//Si los valores son de -1 entonces los desabilita 
                textBoxDescuento.Enabled = false;
                rbtnDescuento.Checked = false;
                textBoxUtilidad.Enabled = false;
                rbtnUtilidad.Checked = false;
            }
            if (!checkBoxCredito.Checked)//Si el checkbox es valor 0 o false desactiva los text
            {
                txtDiasCredito.Enabled = false;
                txtLimiteCredito.Enabled = false;
            }
            LLenarClienteCorreo();
        }
        public void LLenarClienteCorreo()
        {
            correos = obtenerCliente.ObtenerClienteCorreo(datosClientes.idcliente.ToString());
            foreach (string[] correo in correos)
            {
                dgvCorreo.Rows.Add(correo[1], correo[0]);
            }
        }
        #endregion
        #region Validaciones
        private void textBoxNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            //v.SoloLetras(e);
        }

        private void textBoxApe_KeyPress(object sender, KeyPressEventArgs e)
        {
            //v.SoloLetras(e);
        }

        private void textBoxTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }

        private void textBoxCiu_KeyPress(object sender, KeyPressEventArgs e)
        {
            //v.SoloLetras(e);
        }
        private void textBoxUtilidad_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            v.SoloDecimales(sender, e);
        }

        private void textBoxDescuento_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            v.SoloDecimales(sender, e);
        }

        private void txtDiasCredito_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }

        private void txtLimiteCredito_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }

        private void textBoxNumInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }

        private void textBoxNumExt_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }

        private void textBoxCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }

        private void textBoxCol_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloLetras(e);
        }

        private void textBoxLoca_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloLetras(e);
        }

        private void textBoxEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloLetras(e);
        }

        private void textBoxPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloLetras(e);
        }
        #endregion
        #region Borrar Datos Cliente
        private void BorrarDatos()
        {
            textBoxID.Clear();
            textBoxNom.Clear();
            textBoxApe.Clear();
            textBoxDir.Clear();
            textBoxNumExt.Clear();
            textBoxNumInt.Clear();
            textBoxCP.Clear();
            textBoxCol.Clear();
            textBoxLoca.Clear();
            textBoxCiu.Clear();
            textBoxEstado.Clear();
            textBoxPais.Clear();
            textBoxTel.Clear();
            textBoxRFC.Clear();
            dgvCorreo.Rows.Clear();
            textBoxUtilidad.Text = "-1";
            rbtnDescuento.Text = "-1";
            checkBoxCredito.Checked = false;
            txtDiasCredito.Text = "-1";
            txtLimiteCredito.Text = "-1";

        }




        #endregion

        private void dgvCorreo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 1: // Column index of needed dateTimePicker cell
                    try
                    {
                        if (e.RowIndex != -1)
                        {
                            dgvCorreo.Rows[e.RowIndex].Cells[2].Value = global::ValleVerde.Properties.Resources.darBajaUsuario1;
                            dgvCorreo.Refresh();
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Eliminar", "¡Error al eliminar!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 2:
                    try
                    {
                        if (dgvCorreo.Rows[e.RowIndex].Cells[0].Value != null)
                        {
                            string idcorreo = dgvCorreo.Rows[e.RowIndex].Cells[0].Value.ToString();
                            cliente.BajaClienteCorreo(idcorreo);
                        }
                        dgvCorreo.Rows.Remove(dgvCorreo.Rows[e.RowIndex]);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Eliminar", "¡Error al eliminar!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }

        private void RegistroCliente_Load(object sender, EventArgs e)
        {

        }

        private void textBoxNom_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
