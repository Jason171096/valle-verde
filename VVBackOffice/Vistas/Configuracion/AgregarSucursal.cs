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
using ValleVerde.Programacion.Configuracion;

namespace ValleVerde.Vistas.Configuracion
{
    public partial class AgregarSucursal : Form
    {
        Sucursales suc = new Sucursales();
        long idSucursal;
        public AgregarSucursal(long idSucursal)
        {
            InitializeComponent();
            this.idSucursal = idSucursal;

            TabSucursal.Appearance = TabAppearance.FlatButtons;
            TabSucursal.ItemSize = new Size(0, 1);
            TabSucursal.SizeMode = TabSizeMode.Fixed;
        }

        private void AgregarSucursal_Load(object sender, EventArgs e)
        {
            if (idSucursal != 0)
            {
                botonAceptar.Enabled = false;
                botonAceptar.Visible = false;
                botonActualizar.Visible = true;
                botonActualizar.Enabled = true;
                LlenarCampos();
            }
            else
            {
                botonActualizar.Visible = false;
                botonActualizar.Enabled = false;
                botonAceptar.Enabled = true;
                botonAceptar.Visible = true;
            }
        }


        private void LlenarCampos()
        {
            string[] sucur = suc.ObtenerSucursalConID(idSucursal);
            textNombre.Text = sucur[1];
            textDomicilio.Text = sucur[2];
            textNExt.Text = sucur[3];
            textNInt.Text = sucur[4];
            textCol.Text = sucur[5];
            textCP.Text = sucur[6];
            textCiudad.Text = sucur[7];
            textEstado.Text = sucur[8];
            textPais.Text = sucur[9];
            textTel.Text = sucur[10];
            textCel.Text = sucur[11];
            textCorreo.Text = sucur[12];
            chkActivo.Checked = bool.Parse(sucur[13]);
            textSlogan.Text = sucur[14];
            textNomCort.Text = sucur[15];
            //16
            textNomServ.Text = sucur[17];
            textCon.Text = sucur[18];
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            if (textNombre.Text != "") 
            {
                if (textNomServ.Text == "" && textCon.Text == "")
                {
                    DialogResult result = MessageBox.Show("El servicio de Servidor Enlazado esta vacio\n¿Desea Continuar?", "¡¡Advertencia!!", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        suc.AltaSucursal(textNombre.Text, textDomicilio.Text, textNExt.Text, textNInt.Text, textCol.Text, int.Parse(textCP.Text),
                            textCiudad.Text, textEstado.Text, textPais.Text, textTel.Text, textCel.Text, textCorreo.Text, chkActivo.Checked, textSlogan.Text,
                            textNomCort.Text, pictureBox2.Image, textNomServ.Text, textCon.Text);
                    }
                }
                else
                {
                    suc.AltaSucursal(textNombre.Text, textDomicilio.Text, textNExt.Text, textNInt.Text, textCol.Text, int.Parse(textCP.Text),
                        textCiudad.Text, textEstado.Text, textPais.Text, textTel.Text, textCel.Text, textCorreo.Text, chkActivo.Checked, textSlogan.Text,
                        textNomCort.Text, pictureBox2.Image, textNomServ.Text, textCon.Text);
                }
            }
            else
            {
                MessageBox.Show("El campo Nombre es obligatorio","Error");
            }
            Close();
        }

        private void textNomServ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar) < 48 && (e.KeyChar) != 8 || (e.KeyChar) > 57 && (e.KeyChar) < 65 || (e.KeyChar) > 90 && (e.KeyChar) < 97 || (e.KeyChar) > 122)
            {
                e.Handled = true;
            }
        }

        private void botonActualizar_Click(object sender, EventArgs e)
        {
            if (textNombre.Text != "")
            {
                if (textNomServ.Text == "" && textCon.Text == "")
                {
                    DialogResult result = MessageBox.Show("El servicio de Servidor Enlazado esta vacio\n¿Desea Continuar?", "¡¡Advertencia!!", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            suc.ActualizarSucursal(idSucursal, textNombre.Text, textDomicilio.Text, textNExt.Text, textNInt.Text, textCol.Text, int.Parse(textCP.Text),
                                textCiudad.Text, textEstado.Text, textPais.Text, textTel.Text, textCel.Text, textCorreo.Text, chkActivo.Checked, textSlogan.Text,
                                textNomCort.Text, pictureBox2.Image, textNomServ.Text, textCon.Text);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error al Actualizar");
                        }
                    }
                }
                else
                {
                    try
                    {
                        suc.ActualizarSucursal(idSucursal, textNombre.Text, textDomicilio.Text, textNExt.Text, textNInt.Text, textCol.Text, int.Parse(textCP.Text),
                            textCiudad.Text, textEstado.Text, textPais.Text, textTel.Text, textCel.Text, textCorreo.Text, chkActivo.Checked, textSlogan.Text,
                            textNomCort.Text, pictureBox2.Image, textNomServ.Text, textCon.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al Actualizar" + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("El campo Nombre es obligatorio", "Error");
            }
            Close();
        }

        private void botonRegistro_Click(object sender, EventArgs e)
        {
            TabSucursal.SelectedTab = tab1;
        }

        private void botonServidor_Click(object sender, EventArgs e)
        {
            TabSucursal.SelectedTab = tab2;
        }

        private void botonSubir_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png|Todos los Archivos(*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.Multiselect = false;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //string imagen = openFileDialog1.FileName;
                    //pictureBox2.Image = Image.FromFile(imagen);
                    pictureBox2.Image = new Bitmap(openFileDialog1.FileName);
                    //pictureBox2.ImageLocation = openFileDialog1.FileName;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("El archivo seleccionado no es válido");
            }
           
        }



        private void BotonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ProbarConexion(bool botonaceptar)
        {
            if (textCon.Text!="")
            {
                string connetionString = "Data Source=" + textCon.Text + ";Initial Catalog=valleverde;User Id=usuario1;Password=cotija20";
                
                SqlConnection cnn = new SqlConnection(connetionString);
                try
                {
                    cnn.Open();
                    if (!botonaceptar)
                        MessageBox.Show("Conexion exitosa");
                    cnn.Close();
                    return true;
                }
                catch (Exception ex){ MessageBox.Show( ex.Message);}
            }
            MessageBox.Show("No se pudo conectar con el servidor.");
            return false;
        }

        private void btnProbar_Click(object sender, EventArgs e)
        {
            ProbarConexion(false);
        }
    }
}