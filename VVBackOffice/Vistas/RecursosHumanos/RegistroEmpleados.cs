using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ValleVerde.Programacion.RecursosHumanos;
using ValleVerdeComun.Programacion;

namespace ValleVerde.Vistas.RecursosHumanos
{
    public partial class RegistroEmpleados : Form
    {
        Usuarios AE = new Usuarios();
        Validaciones v = new Validaciones();
        OpenFileDialog Buscar = new OpenFileDialog();
        Usuarios OE = new Usuarios();
        ObtenerRoles roles = new ObtenerRoles();
        

        private Usuario datosUsuario;
        private Usuario datosUsuarioFoto;

        List<Object> huellasObject;
        List<string[]> hijos;


        DateTimePicker dtp = new DateTimePicker();
        Rectangle rectangle;

        private bool boolSelectIndexChange = false;

        public RegistroEmpleados(Usuario datosUsuario, Usuario datosUsuarioFoto, string huellas)
        {
            InitializeComponent();
            #region Modify DataGridViewHijos and DatePicker
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvHijos, true, false);
            foreach (DataGridViewColumn column in dgvHijos.Columns)
            {
                column.ReadOnly = false;
            }
            dgvHijos.Columns[1].ReadOnly = true;
            dgvHijos.AllowUserToAddRows = true;
            dgvHijos.AllowUserToDeleteRows = true;
            dgvHijos.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dtp.Font = new Font("Microsoft Sans Serif", 15);

            dgvHijos.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.MouseEnter += new EventHandler(dtp_Enter);
            dtp.Leave += new EventHandler(dtp_Leave);
            dtp.TextChanged += new EventHandler(dtp_Enter);
            dtp.MaxDate = DateTime.Now.Date;
            #endregion
            #region Municipios de ComboBox
            comboBoxMun.Items.Add("Acuitzio");
            comboBoxMun.Items.Add("Aguililla");
            comboBoxMun.Items.Add("Álvaro Obregón");
            comboBoxMun.Items.Add("Angamacutiro");
            comboBoxMun.Items.Add("Angangueo");
            comboBoxMun.Items.Add("Apatzingán");
            comboBoxMun.Items.Add("Aporo");
            comboBoxMun.Items.Add("Aquila");
            comboBoxMun.Items.Add("Ario");
            comboBoxMun.Items.Add("Arteaga");
            comboBoxMun.Items.Add("Briseñas");
            comboBoxMun.Items.Add("Buenavista");
            comboBoxMun.Items.Add("Carácuaro");
            comboBoxMun.Items.Add("Charapan");
            comboBoxMun.Items.Add("Charo");
            comboBoxMun.Items.Add("Chavinda");
            comboBoxMun.Items.Add("Cherán");
            comboBoxMun.Items.Add("Chilchota");
            comboBoxMun.Items.Add("Chinicuila");
            comboBoxMun.Items.Add("Chucándiro");
            comboBoxMun.Items.Add("Churintzio");
            comboBoxMun.Items.Add("Churumuco");
            comboBoxMun.Items.Add("Coahuayana");
            comboBoxMun.Items.Add("Coalcomán de Vázquez Pallares");
            comboBoxMun.Items.Add("Coeneo");
            comboBoxMun.Items.Add("Cojumatlán de Régules");
            comboBoxMun.Items.Add("Contepec");
            comboBoxMun.Items.Add("Copándaro");
            comboBoxMun.Items.Add("Cotija");
            comboBoxMun.Items.Add("Cuitzeo");
            comboBoxMun.Items.Add("Ecuandureo");
            comboBoxMun.Items.Add("Epitacio Huerta");
            comboBoxMun.Items.Add("Erongarícuaro");
            comboBoxMun.Items.Add("Gabriel Zamora");
            comboBoxMun.Items.Add("Hidalgo");
            comboBoxMun.Items.Add("Huandacareo");
            comboBoxMun.Items.Add("Huaniqueo");
            comboBoxMun.Items.Add("Huetamo");
            comboBoxMun.Items.Add("Huiramba");
            comboBoxMun.Items.Add("Indaparapeo");
            comboBoxMun.Items.Add("Irimbo");
            comboBoxMun.Items.Add("Ixtlán");
            comboBoxMun.Items.Add("Jacona");
            comboBoxMun.Items.Add("Jiménez");
            comboBoxMun.Items.Add("Jiquilpan");
            comboBoxMun.Items.Add("José Sixto Verduzco");
            comboBoxMun.Items.Add("Juárez");
            comboBoxMun.Items.Add("Jungapeo");
            comboBoxMun.Items.Add("La Huacana");
            comboBoxMun.Items.Add("La Piedad");
            comboBoxMun.Items.Add("Lagunillas");
            comboBoxMun.Items.Add("Lázaro Cárdenas");
            comboBoxMun.Items.Add("Los Reyes");
            comboBoxMun.Items.Add("Madero");
            comboBoxMun.Items.Add("Maravatío");
            comboBoxMun.Items.Add("Marcos Castellanos");
            comboBoxMun.Items.Add("Morelia");
            comboBoxMun.Items.Add("Morelos");
            comboBoxMun.Items.Add("Múgica");
            comboBoxMun.Items.Add("Nahuatzen");
            comboBoxMun.Items.Add("Nocupétaro");
            comboBoxMun.Items.Add("Nuevo Parangaricutiro");
            comboBoxMun.Items.Add("Nuevo Urecho");
            comboBoxMun.Items.Add("Numarán");
            comboBoxMun.Items.Add("Ocampo");
            comboBoxMun.Items.Add("Pajacuarán");
            comboBoxMun.Items.Add("Panindícuaro");
            comboBoxMun.Items.Add("Paracho");
            comboBoxMun.Items.Add("Parácuaro");
            comboBoxMun.Items.Add("Pátzcuaro");
            comboBoxMun.Items.Add("Penjamillo");
            comboBoxMun.Items.Add("Peribán");
            comboBoxMun.Items.Add("Purépero");
            comboBoxMun.Items.Add("Puruándiro");
            comboBoxMun.Items.Add("Queréndaro");
            comboBoxMun.Items.Add("Quiroga");
            comboBoxMun.Items.Add("Sahuayo");
            comboBoxMun.Items.Add("Salvador Escalante");
            comboBoxMun.Items.Add("San Lucas");
            comboBoxMun.Items.Add("Santa Ana Maya");
            comboBoxMun.Items.Add("Senguio");
            comboBoxMun.Items.Add("Susupuato");
            comboBoxMun.Items.Add("Tacámbaro");
            comboBoxMun.Items.Add("Tancítaro");
            comboBoxMun.Items.Add("Tangamandapio");
            comboBoxMun.Items.Add("Tangancícuaro");
            comboBoxMun.Items.Add("Tanhuato");
            comboBoxMun.Items.Add("Taretan");
            comboBoxMun.Items.Add("Tarímbaro");
            comboBoxMun.Items.Add("Tepalcatepec");
            comboBoxMun.Items.Add("Tingambato");
            comboBoxMun.Items.Add("Tingüindín");
            comboBoxMun.Items.Add("Tiquicheo de Nicolás Romero");
            comboBoxMun.Items.Add("Tlalpujahua");
            comboBoxMun.Items.Add("Tlazazalca");
            comboBoxMun.Items.Add("Tocumbo");
            comboBoxMun.Items.Add("Tumbiscatío");
            comboBoxMun.Items.Add("Turicato");
            comboBoxMun.Items.Add("Tuxpan");
            comboBoxMun.Items.Add("Tuzantla");
            comboBoxMun.Items.Add("Tzintzuntzan");
            comboBoxMun.Items.Add("Tzitzio");
            comboBoxMun.Items.Add("Uruapan");
            comboBoxMun.Items.Add("Venustiano Carranza	");
            comboBoxMun.Items.Add("Villamar");
            comboBoxMun.Items.Add("Vista Hermosa");
            comboBoxMun.Items.Add("Yurécuaro");
            comboBoxMun.Items.Add("Zacapu");
            comboBoxMun.Items.Add("Zamora");
            comboBoxMun.Items.Add("Zináparo ");
            comboBoxMun.Items.Add("Zinapécuaro");
            comboBoxMun.Items.Add("Ziracuaretiro");
            comboBoxMun.Items.Add("Zitácuaro");
            #endregion
            #region Sexo de ComboBox
            comboBoxSexo.Items.Add("Masculino");
            comboBoxSexo.Items.Add("Femenino");
            #endregion
            #region EstadoCivil de ComboBox 
            comboBoxEstCiv.Items.Add("Soltero");
            comboBoxEstCiv.Items.Add("Casado");
            comboBoxEstCiv.Items.Add("Divorciado");
            comboBoxEstCiv.Items.Add("Viudo");
            comboBoxEstCiv.Items.Add("Separado");
            comboBoxEstCiv.Items.Add("Union Libre");
            comboBoxEstCiv.Items.Add("Otro");
            #endregion
            #region TipoSangre de ComboBox
            comboBoxTipSan.Items.Add("Se desconoce");
            comboBoxTipSan.Items.Add("O-");
            comboBoxTipSan.Items.Add("O+");
            comboBoxTipSan.Items.Add("A-");
            comboBoxTipSan.Items.Add("A+");
            comboBoxTipSan.Items.Add("B-");
            comboBoxTipSan.Items.Add("B+");
            comboBoxTipSan.Items.Add("AB-");
            comboBoxTipSan.Items.Add("AB+");
            #endregion
            #region NivelAcademico de ComboBox
            comboBoxNivAca.Items.Add("Ninguno");
            comboBoxNivAca.Items.Add("Primaria");
            comboBoxNivAca.Items.Add("Secundaria");
            comboBoxNivAca.Items.Add("Preparatoria");
            comboBoxNivAca.Items.Add("Carrera");
            comboBoxNivAca.Items.Add("Universidad");
            comboBoxNivAca.Items.Add("Postgrado");
            #endregion
            #region CasaPropia de ComboBox
            comboBoxCasPro.Items.Add("Propia");
            comboBoxCasPro.Items.Add("Prestada");
            comboBoxCasPro.Items.Add("Rentada");
            comboBoxCasPro.Items.Add("Hipotecada");
            #endregion
            #region Fajas y Playeras de ComboBox
            comboBoxTallaFaja.Items.Add("Chica");
            comboBoxTallaFaja.Items.Add("Mediana");
            comboBoxTallaFaja.Items.Add("Grande");
            comboBoxTallaFaja.Items.Add("Extra Grande");

            comboBoxTallaPlayera.Items.Add("Chica");
            comboBoxTallaPlayera.Items.Add("Mediana");
            comboBoxTallaPlayera.Items.Add("Grande");
            comboBoxTallaPlayera.Items.Add("Extra Grande");

            comboBoxTallaSueter.Items.Add("Chica");
            comboBoxTallaSueter.Items.Add("Mediana");
            comboBoxTallaSueter.Items.Add("Grande");
            comboBoxTallaSueter.Items.Add("Extra Grande");

            #endregion
            #region Roles de ComboBox  
            LlenarComboBoxRoles();
            #endregion    

            if (datosUsuario == null)
            {
                Text = "Alta Empleado";
                btnBuscarEmpleado.Visible = false;
                btnModificarEmpleado.Visible = false;
                panelHuellas.Visible = false;
                btnAsignarHorario.Visible = false;

            }
            else if (datosUsuario != null && huellas.Equals("Huellas"))
            {
                Text = "Modificar Empleado";
                btnDarAlta.Visible = false;
                btnBorrarCampos.Visible = false;
                tabControl1.SelectedIndex = 3;
                this.datosUsuario = datosUsuario;
                this.datosUsuarioFoto = datosUsuario;
                LlenarDatosUsuario();
                ValleVerdeComun.Vistas.RegistrarHuella.RegistrarHuella obr = new ValleVerdeComun.Vistas.RegistrarHuella.RegistrarHuella(datosUsuario.idUsuario.ToString());
                obr.ShowDialog();
                obr.Close();
            }
            else
            {
                Text = "Modificar Empleado";
                textBoxID.Enabled = false;
                label15.Enabled = false;
                btnDarAlta.Visible = false;
                btnBorrarCampos.Visible = false;
                this.datosUsuario = datosUsuario;
                this.datosUsuarioFoto = datosUsuarioFoto;
                LlenarDatosUsuario();
            }
        }

        private void BtnBuscarEmpleado_Click(object sender, EventArgs e)
        {
            Close();
            BuscarEmpleado be = new BuscarEmpleado();
            be.ShowDialog();
            Usuario datosUsuario = be.ObtenerUsuario();
            Usuario datosUsuarioFoto = be.ObtenerUsuarioFoto();
            if (datosUsuario != null)
                new RegistroEmpleados(datosUsuario, datosUsuarioFoto, "").Show();

        }
        #region Alta
        private void BtnDarAlta_Click(object sender, EventArgs e)
        {
            if (textBoxNom.Text == "" || textBoxApe.Text == "")
                MessageBox.Show("Operacion invalida los campos de NOMBRE y APELLIDOS no deben estar vacios", "¡ADVERTENCIA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
            {
                string id = AE.AltaUsuario(textBoxNom.Text, textBoxApe.Text, textBoxDir.Text,
                textBoxCol.Text, textBoxCiu.Text, comboBoxMun.Text, comboBoxSexo.Text, textBoxCel.Text, textBoxTel.Text, textBoxEmail.Text,
                textBoxConEmer.Text, textBoxNumEme.Text, dateTimePickerFecAlt.Value.Date, comboBoxRol.Text, textBoxSalIMSS.Text, textBoxSalCon.Text,
                textBoxNSS.Text, textBoxCurp.Text, textBoxRFC.Text, textBoxBenNom.Text, textBoxParBen.Text, dateTimePickerNaciBen.Value.Date,
                textBoxLugNac.Text, dateTimePickerFecNac.Value.Date, comboBoxEstCiv.Text, comboBoxTipSan.Text, comboBoxNivAca.Text,
                comboBoxCasPro.Text, textBoxObs.Text, true, txtUsuario.Text, txtContrasena.Text, checkAdmin.Checked, comboBoxTallaFaja.Text,
                comboBoxTallaPlayera.Text, comboBoxTallaSueter.Text, textBoxNumPlu.Text,
                CEmpresa.Checked, CPuesto.Checked, CCapaticacion.Checked, CRecepcionFaj.Checked, CRecepcionUni.Checked);

                AE.AltaUsuarioFoto(id, pictureBoxFoto.Image);

                if (txtIDRol.Text.Equals(""))
                    txtIDRol.Text = "26";

                AE.AltaModificaUsuarioRol(id, txtIDRol.Text);

                 List<bool[]> obtenerPermisos = ObtenerCheckBoxPermisos();

                AE.AltaModificaUsuarioPermisos(id, txtIDRol.Text, obtenerPermisos);

                int numRows = dgvHijos.Rows.Count;

                for (int i = 0; i < numRows; i++)
                {
                    string name = (string)dgvHijos[0, i].Value;
                    string date = (string)dgvHijos[1, i].Value;
                    if (!String.IsNullOrWhiteSpace(name) || !String.IsNullOrWhiteSpace(date))
                        AE.AltaUsuarioHijos(textBoxID.Text, name, date);
                }

                BorrarCampos();
            }
        }

        #endregion
        #region  Modificar
        private void BtnModificarEmpleado_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea modificar a este empleado?", "¡ADVERTENCIA!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
                if (textBoxID.Text.Equals("") || textBoxNom.Text.Equals("") || textBoxApe.Text.Equals(""))
                    MessageBox.Show("No se puede modificar un usuario sin escribir su ID o Nombres o Apellidos", "¡ADVERTENCIA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    AE.ModificarUsuario(textBoxID.Text, textBoxNom.Text, textBoxApe.Text, textBoxDir.Text,
                    textBoxCol.Text, textBoxCiu.Text, comboBoxMun.Text, comboBoxSexo.Text, textBoxCel.Text, textBoxTel.Text, textBoxEmail.Text,
                    textBoxConEmer.Text, textBoxNumEme.Text, dateTimePickerFecAlt.Value.Date, comboBoxRol.Text, textBoxSalIMSS.Text, textBoxSalCon.Text,
                    textBoxNSS.Text, textBoxCurp.Text, textBoxRFC.Text, textBoxBenNom.Text, dateTimePickerNaciBen.Value.Date, textBoxParBen.Text,
                    textBoxLugNac.Text, dateTimePickerFecNac.Value.Date, comboBoxEstCiv.Text, comboBoxTipSan.Text, comboBoxNivAca.Text,
                    comboBoxCasPro.Text, textBoxObs.Text, txtUsuario.Text, txtContrasena.Text, checkAdmin.Checked, comboBoxTallaFaja.Text,
                    comboBoxTallaPlayera.Text, comboBoxTallaSueter.Text, textBoxNumPlu.Text,
                    CEmpresa.Checked, CPuesto.Checked, CCapaticacion.Checked, CRecepcionFaj.Checked, CRecepcionUni.Checked);

                    AE.ModificarUsuarioFoto(textBoxID.Text, pictureBoxFoto.Image);

                    if (txtIDRol.Text.Equals(""))
                        txtIDRol.Text = "26";

                    AE.AltaModificaUsuarioRol(textBoxID.Text, txtIDRol.Text);

                    List<bool[]> obtenerPermisos = ObtenerCheckBoxPermisos();
 
                    AE.AltaModificaUsuarioPermisos(textBoxID.Text, txtIDRol.Text, obtenerPermisos);

                    int numRows = dgvHijos.Rows.Count;
                    for (int i = 0; i < numRows - 1; i++)
                    {
                        string name = (string)dgvHijos[0, i].Value;
                        string date = (string)dgvHijos[1, i].Value;
                        if (!String.IsNullOrWhiteSpace(name) || !String.IsNullOrWhiteSpace(date))
                            if (dgvHijos[2, i].Value != null)
                                AE.ModificarUsuarioHijos(dgvHijos[2, i].Value.ToString(), textBoxID.Text, name, date);
                            else
                                AE.AltaUsuarioHijos(textBoxID.Text, name, date);
                    }
                    dgvHijos.Rows.Clear();
                    LlenarHijos();
                }
        }
        #endregion
        #region Foto
        private void BtnTomarFoto_Click(object sender, EventArgs e)
        {
            TomarFotoEmpleado fe = new TomarFotoEmpleado();
            try
            {
                fe.ShowDialog();
                pictureBoxFoto.Image = fe.ObtenerFoto();
            }
            catch (ObjectDisposedException ex)
            {

            }
        }


        private void btnSubir_Click(object sender, EventArgs e)
        {
            Buscar.Filter = "Archivos de Imagen| *.png; *.jpg";
            Buscar.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            if (Buscar.ShowDialog() == DialogResult.OK)
            {
                pictureBoxFoto.ImageLocation = Buscar.FileName;
            }
        }
        #endregion
        #region Borrar Campos
        private void BtnBorrarCampos_Click(object sender, EventArgs e)
        {
            BorrarCampos();
        }
        public void BorrarCampos()
        {
            textBoxID.Clear(); textBoxNom.Clear(); textBoxApe.Clear(); textBoxDir.Clear();
            textBoxCol.Clear(); textBoxCiu.Clear(); comboBoxMun.SelectedIndex = -1; comboBoxSexo.SelectedIndex = -1; textBoxCel.Clear();
            textBoxTel.Clear(); textBoxEmail.Clear(); textBoxConEmer.Clear(); textBoxNumEme.Clear(); pictureBoxFoto.Image = null;
            dateTimePickerFecAlt.ResetText(); comboBoxRol.SelectedIndex = -1; textBoxSalIMSS.Clear(); textBoxSalCon.Clear();
            textBoxNSS.Clear(); textBoxCurp.Clear(); textBoxRFC.Clear();
            textBoxBenNom.Clear(); textBoxParBen.Clear(); dateTimePickerNaciBen.ResetText();
            textBoxLugNac.Clear(); dateTimePickerFecNac.ResetText();
            comboBoxEstCiv.SelectedIndex = -1; comboBoxTipSan.SelectedIndex = -1; comboBoxNivAca.SelectedIndex = -1; comboBoxCasPro.SelectedIndex = -1;
            dgvHijos.Rows.Clear(); dgvHijos.Refresh(); textBoxObs.Clear(); txtUsuario.Clear(); txtContrasena.Clear(); checkAdmin.Checked = false;
            CEmpresa.Checked = false; CPuesto.Checked = false; CCapaticacion.Checked = false;
            CRecepcionUni.Checked = false; CRecepcionFaj.Checked = false;
            comboBoxTallaFaja.SelectedIndex = -1; comboBoxTallaPlayera.SelectedIndex = -1;
            comboBoxTallaSueter.SelectedIndex = -1; textBoxNumPlu.Clear();
            ClearCheckList();
        }
        private void ClearCheckList()
        {
            checkListBack.ClearSelected();
            checkListVenta.ClearSelected();
            checkListComunes.ClearSelected();
        }
        #endregion 
        #region Validaciones
        private void TextBoxNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloLetras(e);
        }

        private void TextBoxApe_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloLetras(e);
        }

        private void TextBoxCol_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloLetras(e);
        }

        private void TextBoxCiu_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloLetras(e);
        }

        private void TextBoxCel_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }

        private void TextBoxTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }

        private void TextBoxNumEme_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }

        private void TextBoxLugNac_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloLetras(e);
        }

        private void TextBoxEstCiv_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloLetras(e);
        }

        private void TextBoxNivAca_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloLetras(e);
        }

        private void TextBoxHijos_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }
        private void textBoxConEmer_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloLetras(e);
        }
        private void textBoxSalIMSS_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }

        private void textBoxSalCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }

        private void textBoxBenNom_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            v.SoloLetras(e);
        }
        private void textBoxParBen_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloLetras(e);
        }
        private void textBoxLugNac_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            v.SoloLetras(e);
        }
        private void textBoxNumPlu_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }
        #endregion
        #region Huellas
        public void roundedButton3_Click(object sender, EventArgs e)
        {
            ValleVerdeComun.Vistas.RegistrarHuella.RegistrarHuella obr = new ValleVerdeComun.Vistas.RegistrarHuella.RegistrarHuella(datosUsuario.idUsuario.ToString());
            obr.ShowDialog();
            LlenarHuellas();
            obr.Close();
        }

        private void btnEliminarHuella_Click(object sender, EventArgs e)
        {
            EliminarHuella eh = new EliminarHuella();
            eh.Eliminarhuella(lbHuellas.SelectedValue.ToString(), textBoxID.Text, lbHuellas.GetItemText(lbHuellas.SelectedItem));
            huellasObject.RemoveAt(lbHuellas.SelectedIndex);
            lbHuellas.DataSource = null;
            LlenarHuellas();

        }

        public void LlenarHuellas()
        {
            List<String[]> huellasString = OE.ObtenerHuellas(datosUsuario.idUsuario);
            if (huellasString.Count != 0)
            {
                lbHuellas.DisplayMember = "Text";
                lbHuellas.ValueMember = "Value";
                huellasObject = new List<Object>();
                foreach (String[] huella in huellasString)
                {
                    huellasObject.Add(new { Value = huella[0], Text = huella[1] });
                }
                lbHuellas.DataSource = huellasObject;
            }
        }

        #endregion
        #region Hijos
        private void LlenarHijos()
        {
            hijos = OE.ObtenerUsuarioHijos(datosUsuario.idUsuario);
            foreach (string[] hijo in hijos)
            {
                dgvHijos.Rows.Add(hijo[1], hijo[2], hijo[0]);
            }
        }
        #endregion
        #region LlenarDatosUsuario
        public void LlenarDatosUsuario()
        {
            textBoxID.Text = datosUsuario.idUsuario.ToString();
            textBoxNom.Text = datosUsuario.nombres;
            textBoxApe.Text = datosUsuario.apellidos;
            textBoxDir.Text = datosUsuario.direccion;
            textBoxCol.Text = datosUsuario.colonia;
            textBoxCiu.Text = datosUsuario.ciudad;
            comboBoxMun.Text = datosUsuario.municipio;
            comboBoxSexo.Text = datosUsuario.sexo;
            textBoxCel.Text = datosUsuario.celular;
            textBoxTel.Text = datosUsuario.telefono;
            textBoxEmail.Text = datosUsuario.email;
            textBoxConEmer.Text = datosUsuario.contactoEmergencia;
            textBoxNumEme.Text = datosUsuario.numerosEmergencia;

            dateTimePickerFecAlt.Text = datosUsuario.fechaAlta.ToString();
            comboBoxRol.Text = datosUsuario.rol;
            textBoxSalIMSS.Text = datosUsuario.salarioImss;
            textBoxSalCon.Text = datosUsuario.salarioContrato;
            textBoxNSS.Text = datosUsuario.imss;
            textBoxCurp.Text = datosUsuario.curp;
            textBoxRFC.Text = datosUsuario.rfc;
            textBoxBenNom.Text = datosUsuario.beneficiarioNomina;
            textBoxParBen.Text = datosUsuario.parentescoBeneficiario;
            dateTimePickerNaciBen.Text = datosUsuario.fechaNacBeneficiario.ToString();

            textBoxLugNac.Text = datosUsuario.lugarNacimiento;
            dateTimePickerFecNac.Text = datosUsuario.fechaNacimiento.ToString();
            comboBoxEstCiv.Text = datosUsuario.estadoCivil;
            comboBoxTipSan.Text = datosUsuario.tipoSangre;
            comboBoxNivAca.Text = datosUsuario.nivelAcademico;
            comboBoxCasPro.Text = datosUsuario.casaPropia;
            textBoxObs.Text = datosUsuario.observaciones;

            txtUsuario.Text = datosUsuario.usuario;
            txtContrasena.Text = datosUsuario.contrasena;
            checkAdmin.Checked = datosUsuario.esAdministrador;

            comboBoxTallaFaja.Text = datosUsuario.tallaFaja;
            comboBoxTallaPlayera.Text = datosUsuario.tallaPlayera;
            comboBoxTallaSueter.Text = datosUsuario.tallaSueter;
            textBoxNumPlu.Text = datosUsuario.numeroPlumero;
            CEmpresa.Checked = datosUsuario.cEmpresa;
            CPuesto.Checked = datosUsuario.cPuesto;

            CCapaticacion.Checked = datosUsuario.cCapacitacion;
            CRecepcionUni.Checked = datosUsuario.cRecepcionUni;
            CRecepcionFaj.Checked = datosUsuario.cRecepcionFaj;
            if (datosUsuarioFoto != null)
                pictureBoxFoto.Image = datosUsuarioFoto.foto;

            LlenarHijos();
            LlenarHuellas();
            LlenarRolyPermisosUsuario();
        }

        #endregion
        #region Horario
        private void btnAsignarHorario_Click(object sender, EventArgs e)
        {
            HorariosEmpleados HE = new HorariosEmpleados();
            HE.AsignarUsuario(datosUsuario.idUsuario.ToString());
            HE.ShowDialog();
        }
        #endregion
        #region DataGridViewHijos
        private void dtp_Enter(object sender, EventArgs e)
        {
            if (dgvHijos.CurrentCell.ColumnIndex != 0)
                dgvHijos.CurrentCell.Value = dtp.Text.ToString();
        }
        private void dtp_Leave(object sender, EventArgs e)
        {
            dtp.Visible = false;
        }

        private void dgvHijos_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {

                case 1: // Column index of needed dateTimePicker cell
                    try
                    {
                        if (e.RowIndex != -1)
                        {
                            rectangle = dgvHijos.GetCellDisplayRectangle(1, e.RowIndex, true); //  
                            dtp.Size = new Size(rectangle.Width, rectangle.Height); //  
                            dtp.Location = new Point(rectangle.X, rectangle.Y); //  
                            dtp.Visible = true;
                            dgvHijos.Rows[e.RowIndex].Cells[3].Value = global::ValleVerde.Properties.Resources.darBajaUsuario1;
                            dgvHijos.Refresh();
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Eliminar", "¡Error al eliminar!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;
                case 3:
                    try
                    {
                        if (dgvHijos.Rows[e.RowIndex].Cells[2].Value != null)
                        {
                            string idhijo = dgvHijos.Rows[e.RowIndex].Cells[2].Value.ToString();
                            AE.BajaUsuarioHijos(idhijo);
                        }
                        dgvHijos.Rows.Remove(dgvHijos.Rows[e.RowIndex]);
                        dtp.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Eliminar", "¡Error al eliminar!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }

        private void dgvHijos_ColumnWidthChanged_1(object sender, DataGridViewColumnEventArgs e)
        {
            dtp.Visible = false;
        }

        private void dgvHijos_Scroll_1(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
        }
        private void dgvHijos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                dgvHijos.Enabled = false;
                dgvHijos.GetNextControl(dgvHijos, false).Focus();
                dgvHijos.Enabled = true;
                e.Handled = true;
            }
        }

        #endregion
        #region Roles y Permisos
        private void LlenarRolyPermisosUsuario()
        {
            List<String[]> Rol = OE.ObtenerRolUsuario(datosUsuario.idUsuario);
            foreach (string[] rol in Rol)
            {
                txtIDRol.Text = rol[0];
                txtRolActual.Text = rol[1];
            }
            PermisosUsuario pu = AE.ObtenerPermisosUsuario(datosUsuario.idUsuario + "");
            #region Permisos BackOffice
            checkListBack.SetItemChecked(0, pu.IniciarSesionBackOffice);
            checkListBack.SetItemChecked(1, pu.CotizacionCompras);
            checkListBack.SetItemChecked(2, pu.RecibirCotizacion);
            checkListBack.SetItemChecked(3, pu.GenerarPedidoCompras);
            checkListBack.SetItemChecked(4, pu.RecibirPedidoCompras);
            checkListBack.SetItemChecked(5, pu.HistorialCompras);
            checkListBack.SetItemChecked(6, pu.AdministrarProveedores);
            checkListBack.SetItemChecked(7, pu.EliminarProveedor);
            checkListBack.SetItemChecked(8, pu.VerDevolucionesCompras);
            checkListBack.SetItemChecked(9, pu.HacerDevolucionesCompras);
            checkListBack.SetItemChecked(10, pu.VerComprasCredito);
            checkListBack.SetItemChecked(11, pu.VerFacturas);

            checkListBack.SetItemChecked(12, pu.GenerarFacturas);
            checkListBack.SetItemChecked(13, pu.VerCreditosVentas);
            checkListBack.SetItemChecked(14, pu.Promociones);
            checkListBack.SetItemChecked(15, pu.AltaProducto);
            checkListBack.SetItemChecked(15, pu.PrecapturarProducto);
            checkListBack.SetItemChecked(17, pu.ModificarProducto);
            checkListBack.SetItemChecked(18, pu.ClavesAdicionalesAcceder);
            checkListBack.SetItemChecked(19, pu.ActualizarUbicacion);
            checkListBack.SetItemChecked(20, pu.AjustarPrecio);
            checkListBack.SetItemChecked(21, pu.ReporteExistencias);
            checkListBack.SetItemChecked(22, pu.TraspasarMercancia);
            checkListBack.SetItemChecked(23, pu.AdministrarEntradasSalidas);

            checkListBack.SetItemChecked(24, pu.RegistrarEntrada);
            checkListBack.SetItemChecked(25, pu.RegistrarSalida);
            checkListBack.SetItemChecked(26, pu.AdministrarFabricantes);
            checkListBack.SetItemChecked(27, pu.AdministrarMarcas);
            checkListBack.SetItemChecked(28, pu.AdministrarLineas);
            checkListBack.SetItemChecked(29, pu.AdministrarAlmacenes);
            checkListBack.SetItemChecked(30, pu.AdministrarUnidades);
            checkListBack.SetItemChecked(31, pu.AdministrarInmobiliario);
            checkListBack.SetItemChecked(32, pu.AltaEmpleado);
            checkListBack.SetItemChecked(33, pu.ModificarEmpleado);
            checkListBack.SetItemChecked(34, pu.BajaEmpleado);
            checkListBack.SetItemChecked(35, pu.VerExEmpleados);

            checkListBack.SetItemChecked(36, pu.AdministrarHorarios);
            checkListBack.SetItemChecked(37, pu.AdministrarBonosPenalizaciones);
            checkListBack.SetItemChecked(38, pu.AdministrarPermisosRoles);
            checkListBack.SetItemChecked(39, pu.AltaCliente);
            checkListBack.SetItemChecked(40, pu.ModificarCliente);
            checkListBack.SetItemChecked(41, pu.BajaCliente);
            checkListBack.SetItemChecked(42, pu.ReporteVentas);
            checkListBack.SetItemChecked(43, pu.ReporteCompras);
            checkListBack.SetItemChecked(44, pu.ReporteEmpleados);
            checkListBack.SetItemChecked(45, pu.ReporteFinanzas);
            checkListBack.SetItemChecked(46, pu.ReporteChecador);
            checkListBack.SetItemChecked(47, pu.ImportarProductosExcel);

            checkListBack.SetItemChecked(48, pu.Presupuestos);
            checkListBack.SetItemChecked(49, pu.VerificarInventario);
            checkListBack.SetItemChecked(50, pu.Gastos);
            checkListBack.SetItemChecked(51, pu.Gafete);
            checkListBack.SetItemChecked(52, pu.ConfiguracionBackOffice);
            checkListBack.SetItemChecked(53, pu.EtiquetasPendientesPegarAcceder);
            checkListBack.SetItemChecked(54, pu.PreescanearEtiquetas);
            checkListBack.SetItemChecked(55, pu.KardexAcceder);
            checkListBack.SetItemChecked(56, pu.ProductosPendientesComprasAcceder);
            #endregion
            #region Permisos Punto de Venta
            checkListVenta.SetItemChecked(0, pu.IniciarSesionPuntoVenta);
            checkListVenta.SetItemChecked(1, pu.DesbloquearCaja);
            checkListVenta.SetItemChecked(2, pu.HacerCorte);
            checkListVenta.SetItemChecked(3, pu.HacerDevolucion);
            checkListVenta.SetItemChecked(4, pu.EliminarProducto);
            checkListVenta.SetItemChecked(5, pu.HacerCotizacionVenta);
            #endregion
            #region Permisos Comunes
            checkListComunes.SetItemChecked(0, pu.PedidoClienteAcceder);
            checkListComunes.SetItemChecked(1, pu.DevolucionesVentasAcceder);
            checkListComunes.SetItemChecked(2, pu.VerVentas);
            #endregion

        }

        private void LlenarComboBoxRoles()
        {
            List<String[]> Roles = roles.ObtenerTodosRoles();
            cboxRol.DisplayMember = "Text";
            cboxRol.ValueMember = "Value";
            List<Object> listRoles = new List<Object>();
            listRoles.Add(new { Value = "0", Text = "ROL Y PERMISOS ACTUALES" });
            foreach (string[] rol in Roles)
            {
                listRoles.Add(new { Value = rol[0], Text = rol[1] });
            }
            cboxRol.DataSource = listRoles;
            lbPermisos.Text = "Permisos Actuales";
        }
        #endregion

        private void cboxRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boolSelectIndexChange)
            {
                string index = cboxRol.SelectedValue.ToString();
                txtIDRol.Text = index;
                if (!index.Equals("0"))
                {
                    lbPermisos.Text = "Permisos Actuales";
                    ClearCheckList();
                    List<bool[]> ListPermisos = roles.ObtenerRolesPermisos(int.Parse(index));
                    int i = 0, j = 0, countComunes = checkListComunes.Items.Count, countBack = checkListBack.Items.Count + countComunes, countVenta = checkListVenta.Items.Count + countBack;
                    foreach (bool[] values in ListPermisos)
                    {
                        foreach (bool tyf in values)
                        {
                            if (j < countComunes)
                            {
                                checkListComunes.SetItemChecked(i, tyf);
                                i++;
                                if (j == countComunes - 1)
                                    i = 0;
                                j++;
                            }
                            else if (j >= countComunes && j < countBack)
                            {
                                checkListBack.SetItemChecked(i, tyf);
                                i++;
                                if (j == countBack - 1)
                                    i = 0;
                                j++;
                            }
                            else if (j >= countBack && j < countVenta)
                            {
                                checkListVenta.SetItemChecked(i, tyf);
                                i++;
                                if (j == countVenta-1)
                                    i = 0;
                                j++;
                            }
                        }
                    }
                }
                else
                {
                    lbPermisos.Text = "Permisos Actuales";
                    ClearCheckList();
                    LlenarRolyPermisosUsuario();
                }
            }
            boolSelectIndexChange = true;
            
        }
        private List<bool[]> ObtenerCheckBoxPermisos()
        {
            List<bool[]> listPermisos = new List<bool[]>();
            for (int i = 0; i < checkListComunes.Items.Count; i++)
            {
                listPermisos.Add(new bool[] { checkListComunes.GetItemChecked(i) });
            }
            for (int i = 0; i < checkListBack.Items.Count; i++)
            {
                listPermisos.Add(new bool[] { checkListBack.GetItemChecked(i) });
            }
            for (int i = 0; i < checkListVenta.Items.Count; i++)
            {
                listPermisos.Add(new bool[] { checkListVenta.GetItemChecked(i) });
            }
            return listPermisos;
        }
    }
}




