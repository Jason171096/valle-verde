using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion.Ventas;

namespace ValleVerde.Vistas.Ventas
{
    public partial class Promociones : Form
    {
        List<string[]> listRes = new List<string[]>();
        List<string[]> listAdicional = new List<string[]>();
        Label labelHorario = new Label();
        int idHorario = 0;
        bool banEditar = false;
        bool banderaImagen = false;
        bool banImgAdi = false;
        string idPromocion;

        Promocion promo = new Promocion();

        public Promociones()
        {
            InitializeComponent();

            label10.Parent = pictureBox1;
            label11.Parent = pictureBox1;
            label13.Parent = pictureBox1;
            pictureBox2.Parent = pictureBox1;
            label12.Parent = pictureBox2;

            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvPromocion, true, false);
            dgvPromocion.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14);
        }
        
        private void Promociones_Load(object sender, EventArgs e)
        {
            if (toggleFecha.IsOn)
            {
                fechaInicio.Enabled = true;
                fechaFin.Enabled = true;
                toggleNuncaExpira.IsOn = false;

            }
            else
            {
                fechaInicio.Enabled = false;
                fechaFin.Enabled = false;
            }

            if (togglePrecio.IsOn)
            {
                comboPrecio.Enabled = true;
            }
            else
            {
                comboPrecio.Enabled = false;
            }

            LlenarTabla();
        }

        private void LlenarTabla()
        {
            dgvPromocion.Rows.Clear();
            List<string[]> resultado = promo.ObtenerPromociones();
            string inicio = "", fin = "",tiempoRes = "";
            string nomBotProd = "", nomBotAdic = "";
            DateTime fFin = new DateTime(), fInicio = new DateTime();
            foreach (string[] fila in resultado)
            {
                if (fila[2] != "")
                {
                    fInicio = DateTime.Parse(fila[2]);
                    fFin = DateTime.Parse(fila[3]).AddDays(1).AddSeconds(-1);
                    inicio = fInicio.ToString("dd/MM/yyyy");
                    fin = fFin.ToString("dd/MM/yyyy");
                    string[] resHorario = promo.ObtenerHorarioPromocion(fila[5]);
                    string horario = resHorario[((byte)fFin.DayOfWeek) + 2];
                    horario = horario.Substring(17, 14);
                    fFin = DateTime.Parse(fin+" "+horario);
                    tiempoRes = (fFin - DateTime.Now) + "";
                    if (tiempoRes.Substring(0,1) == "-")
                    {
                        tiempoRes = "00:00:00";
                    }
                }
                else
                {
                    fInicio = new DateTime();
                    fFin = new DateTime(); ;
                    inicio = "";
                    fin = "";
                    tiempoRes = "";
                }

                List<string[]> resProd = promo.ObtenerProductoPromocion(fila[0]);
                List<string[]> resAdic = promo.ObtenerProductosAdicionalesPromocion(fila[0]);

                if (resProd.Count > 0)
                {
                    nomBotProd = "Ver Productos";
                }
                else
                {
                    nomBotProd = "Asignar a";
                }

                if (resAdic.Count > 0)
                {
                    nomBotAdic = "Ver Productos";
                }
                else
                {
                    nomBotAdic = "No Tiene";
                }

                dgvPromocion.Rows.Add(fila[0], fila[1],nomBotProd, inicio, fin,tiempoRes, fila[4],nomBotAdic, fila[8]);
            }
            dgvPromocion.ClearSelection();
        }

        private void anadir_Click(object sender, EventArgs e)
        {
            listRes = new List<string[]>();
            ProductoPromo productoPromo = new ProductoPromo(listRes);
            productoPromo.ShowDialog();
        }

        private void adicional_Click(object sender, EventArgs e)
        {
            PromoProductoAdicional proadi = new PromoProductoAdicional(listAdicional);
            proadi.ShowDialog();
        }

        private void buttonHorario_Click(object sender, EventArgs e)
        {
            Horario horario = new Horario(labelHorario);
            horario.ShowDialog();
            idHorario = int.Parse(labelHorario.Text);
        }

        private void toggleFecha_SliderValueChanged(object sender, EventArgs e)
        {
            if (toggleFecha.IsOn)
            {
                fechaInicio.Enabled = true;
                fechaFin.Enabled = true;
                toggleNuncaExpira.IsOn = false;

            }
            else
            {
                fechaInicio.Enabled = false;
                fechaFin.Enabled = false;
            }
        }

        private void toggleNuncaExpira_SliderValueChanged(object sender, EventArgs e)
        {
            if (toggleNuncaExpira.IsOn)
            {
                toggleFecha.IsOn = false;
            }
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (banderaImagen == false)
            {
                botonGenerar.PerformClick();
            }
            DateTime fInicio = fechaInicio.Value.Date;
            DateTime fFin = fechaFin.Value.Date;
            int idpromo = 0, usarPre = -1;
            bool nuncaExpira = false;

            if (banEditar == false)
            {
                if (textNombre.Text != "")
                {
                    if (listRes.Count > 0)
                    {
                        List<string[]> resHorario = promo.ObtenerTodosHorariosPromocion();
                        if (resHorario.Count > 0)
                        {
                            if (idHorario == 0)
                            {
                                idHorario = int.Parse(resHorario[0][0]);
                            }

                            if (toggleNuncaExpira.IsOn)
                            {
                                nuncaExpira = true;
                            }

                            if (comboPrecio.SelectedIndex <= 0 || togglePrecio.IsOn == false)
                            {
                                usarPre = -1;
                            }
                            else
                            {
                                usarPre = comboPrecio.SelectedIndex;
                            }

                            idpromo = int.Parse(promo.AgregarPromocion(textNombre.Text, fInicio, fFin, int.Parse(textCantidadLimite.Text), idHorario, int.Parse(textDescuento.Text), usarPre, "Activa", nuncaExpira));

                            foreach (string[] res in listRes)
                            {
                                promo.AgregarPromocionProducto(idpromo, res[0], res[2]);
                            }

                            listRes = new List<string[]>();

                            if (listAdicional.Count > 0)
                            {
                                foreach (string[] resAdicional in listAdicional)
                                {
                                    promo.AgregarPromocionProductosAdicionales(idpromo, resAdicional[0], int.Parse(resAdicional[2]), int.Parse(resAdicional[3]));
                                }
                                listAdicional = new List<string[]>();
                            }
                            var b = new Bitmap(panelImagen.Width, panelImagen.Height);
                            panelImagen.DrawToBitmap(b, new Rectangle(0, 0, panelImagen.Width, panelImagen.Height));
                            PictureBox pictureBoxPromo = new PictureBox();
                            pictureBoxPromo.Image = b;
                            if (banImgAdi)
                            {
                                promo.AgregarImagenPromocion(idpromo, pictureBoxPromo.Image, pictureBox2.Image);
                                banImgAdi = false;
                            }
                            else
                            {
                                promo.AgregarImagenPromocion(idpromo, pictureBoxPromo.Image, null);
                            }
                            

                            LlenarTabla();
                            banderaImagen = false;
                            textNombre.Text = "";
                            textCantidadLimite.Text = "0";
                            textDescuento.Text = "0";
                            panelImagen.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("No esta seleccionado el horario");
                        }                       
                    }
                    else
                    {
                        MessageBox.Show("La promoción no se le asigno a nadie\n favor de asignarla", "ERROR");
                    }
                }
                else
                {
                    MessageBox.Show("El campo nombre esta vacio", "Error");
                }
            }
            else
            {
                string Estado = "";
                if(DateTime.Now > fInicio && DateTime.Now < fFin)
                {
                    Estado = "Activa";
                }
                else if (fFin < DateTime.Now)
                {
                    Estado = "Terminada";
                }
                else
                {
                    Estado = "En Espera";
                }
                //Actualizar
                promo.ActualizaPromocion(long.Parse(idPromocion),textNombre.Text, fInicio, fFin, int.Parse(textCantidadLimite.Text), idHorario, int.Parse(textDescuento.Text), usarPre, Estado, nuncaExpira);
                if (chkActImg.Checked)
                {
                    var b = new Bitmap(panelImagen.Width, panelImagen.Height);
                    panelImagen.DrawToBitmap(b, new Rectangle(0, 0, panelImagen.Width, panelImagen.Height));
                    if (banImgAdi)
                    {
                        promo.ActualizarImagenPromocion(long.Parse(idPromocion), b, pictureBox2.Image);
                        banImgAdi = false;
                    }
                    else
                    {
                        promo.ActualizarImagenPromocion(long.Parse(idPromocion), b, null);
                    }
                    
                }
                anadir.Enabled = true;
                adicional.Enabled = true;
                botonPausar.Enabled = true;
                botonTerminar.Enabled = true;
                botonImagen.Enabled = true;
                banEditar = true;

                textNombre.Text = "";
                textCantidadLimite.Text = "";
                textDescuento.Text = "0";
                panelImagen.Visible = false;
                LlenarTabla();
            }
        }

        private void togglePrecio_SliderValueChanged(object sender, EventArgs e)
        {
            if (togglePrecio.IsOn)
            {
                comboPrecio.Enabled = true;
            }
            else
            {
                comboPrecio.Enabled = false;
            }
        }

        private void codigoProducto_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if (dgvPromocion.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Ver Productos")
                {
                    VerProductosPromocion ver = new VerProductosPromocion(dgvPromocion.Rows[e.RowIndex].Cells[0].Value.ToString(),1);
                    ver.ShowDialog();
                }
                else if (dgvPromocion.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Asignar a")
                {
                    List<string[]> resProd = new List<string[]>();
                    ProductoPromo obj = new ProductoPromo(resProd);
                    obj.Show();
                }
            }
            if (e.ColumnIndex == 7)
            {
                if (dgvPromocion.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Ver Productos")
                {
                    VerProductosPromocion ver = new VerProductosPromocion(dgvPromocion.Rows[e.RowIndex].Cells[0].Value.ToString(),2);
                    ver.ShowDialog();
                }
                else if (dgvPromocion.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "No Tiene")
                {
                    DialogResult result = MessageBox.Show("¿Desea agregar Productos adicionales?","Advertencia",MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        List<string[]> resAdicional = new List<string[]>();
                        PromoProductoAdicional adicional = new PromoProductoAdicional(resAdicional);
                        adicional.ShowDialog();
                        if (resAdicional.Count != 0) 
                        {
                            foreach (string[] Adicional in resAdicional)
                            {
                                promo.AgregarPromocionProductosAdicionales(int.Parse(dgvPromocion.Rows[e.RowIndex].Cells[0].Value.ToString()), Adicional[0], int.Parse(Adicional[2]), int.Parse(Adicional[3]));
                            }
                            //MessageBox.Show(resAdicional[0][0]);
                            LlenarTabla();
                        }
                    }
                }
            }
           
        }

        private void botonPausar_Click(object sender, EventArgs e)
        {
            if (dgvPromocion.CurrentRow.Cells[8].Value.ToString() == "Pausada")
            {
                promo.ActualizarEstadoPromocion(dgvPromocion.CurrentRow.Cells[0].Value.ToString(), "Activa");
                LlenarTabla();
            }
            else if (dgvPromocion.CurrentRow.Cells[8].Value.ToString() == "Activa")
            {
                promo.ActualizarEstadoPromocion(dgvPromocion.CurrentRow.Cells[0].Value.ToString(), "Pausada");
                LlenarTabla();
            }            
        }

        private void botonTerminar_Click(object sender, EventArgs e)
        {
            promo.ActualizarEstadoPromocion(dgvPromocion.CurrentRow.Cells[0].Value.ToString(), "Terminada");
            LlenarTabla();
        }

        private void botonEditar_Click(object sender, EventArgs e)
        {
            if (botonEditar.Text == "Editar")
            {
                botonEditar.Text = "Cancelar";
                botonEditar.Image = global::ValleVerde.Properties.Resources.cancelar;
                banEditar = true;
                chkActImg.Visible = true;
                idPromocion = dgvPromocion.CurrentRow.Cells[0].Value.ToString();
                List<string[]> resPromo = promo.ObtenerPromocion(long.Parse(idPromocion));
                textNombre.Text = resPromo[0][1];
                if (resPromo[0][2] == "" && resPromo[0][3] == "")
                {
                    toggleFecha.IsOn = false;
                    toggleNuncaExpira.IsOn = true;
                }
                else
                {
                    toggleFecha.IsOn = true;
                    toggleNuncaExpira.IsOn = false;
                    fechaInicio.Value = DateTime.Parse(resPromo[0][2]);
                    fechaFin.Value = DateTime.Parse(resPromo[0][3]);
                }

                textCantidadLimite.Text = resPromo[0][4];
                idHorario = int.Parse(resPromo[0][5]);
                textDescuento.Text = resPromo[0][6];
                if (resPromo[0][7] == "-1")
                {
                    togglePrecio.IsOn = false;
                }
                else
                {
                    togglePrecio.IsOn = true;
                    comboPrecio.SelectedIndex = int.Parse(resPromo[0][7]);
                }

                anadir.Enabled = false;
                adicional.Enabled = false;
                botonPausar.Enabled = false;
                botonTerminar.Enabled = false;
                botonImagen.Enabled = false;
            }
            else if (botonEditar.Text == "Cancelar")
            {
                botonEditar.Text = "Editar";
                botonEditar.Image = global::ValleVerde.Properties.Resources.image_edit_24;
                textNombre.Text = "";
                textDescuento.Text = "0";
                textCantidadLimite.Text = "0";
                idHorario = 0;
                anadir.Enabled = true;
                adicional.Enabled = true;
                botonPausar.Enabled = true;
                botonTerminar.Enabled = true;
                botonImagen.Enabled = true;
            }
            
        }

        private void botonGenerar_Click(object sender, EventArgs e)
        {
            panelImagen.Visible = true;
            banderaImagen = true;
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            label13.Text = "";
            pictureBox2.Image = null;
            pictureBox1.Visible = true;
            label10.Text = textNombre.Text;
            if (toggleFecha.IsOn)
            {
                label11.Text = "*Vigencia del "+fechaInicio.Value.Date.ToString("dd/MM/yyyy")+" al "+fechaFin.Value.Date.ToString("dd/MM/yyyyy");
            }
            else
            {
                label11.Text = "**Cantidad de PIEZAS LIMITADAS para la promoción";
            }
            if (listRes.Count > 0)
            {
                if (listRes[0][2] == "Producto")
                {
                    string auxidProd = listRes[0][0];
                    int cant = promo.ObtenerCantidadImagenesProducto(auxidProd);
                    if (cant > 0)
                    {
                        try
                        {
                            pictureBox2.Image = promo.ObtenerImagenesProducto(auxidProd)[0];
                        }
                        catch { }
                    }
                    else
                    {
                        label12.Text = textNombre.Text;
                    }
                }
                else
                {
                    label12.Text = textNombre.Text;
                }
            }

            if (int.Parse(textDescuento.Text) > 0)
            {
                label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label13.Text = "OFERTA " + textDescuento.Text + "%";
            }
            else
            {
                label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label13.Text = "PROMOCIÓN ";
            }
            if (togglePrecio.IsOn && int.Parse(textDescuento.Text) == 0)
            {
                label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label13.Text = "PROMOCIÓN A PRECIO DE MAYOREO ";
            }

        }

        private void botonImagen_Click(object sender, EventArgs e)
        {
            idPromocion = dgvPromocion.CurrentRow.Cells[0].Value.ToString();

            ImagenPromocion ob = new ImagenPromocion(long.Parse(idPromocion));
            ob.ShowDialog();
        }

        private void SubirImagen_Click(object sender, EventArgs e)
        {
            banImgAdi = true;
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
    }
}
