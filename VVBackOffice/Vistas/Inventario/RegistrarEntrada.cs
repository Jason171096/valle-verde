using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using ValleVerde.Programacion.Inventario;

namespace ValleVerde
{
    public partial class RegistrarEntrada : Form
    {
        EntradaRegistrar obj = new EntradaRegistrar();
        Validaciones valida = new Validaciones();
        Button boton = new Button();
        int bandera;
        bool merma;
        int idUsuario;

        public RegistrarEntrada(int bandera, string idUsuario)
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvEntrada, true, false);
            boton.Click += new EventHandler(buttonLlenar_Click);
            this.bandera = bandera;
            this.idUsuario = int.Parse(idUsuario);
            if (bandera == 0)
            {
                comboconcepto.Items.Add("Ajuste");
                comboconcepto.Items.Add("Faltante Almacen");
                this.merma = false;

                labelAlmacenAntes.Visible = false;
                comboAlmacenAntes.Visible = false;
            }
            else
            {
                comboconcepto.Items.Add("Merma");
                comboconcepto.Items.Add("Sobrante Almacen");
                comboAlmacen.DisplayMember = "Text";
                comboAlmacen.ValueMember = "Value";
                comboAlmacen.Items.Add(new { Text = "Estante Merma", Value = 5 });
                this.merma = true;

                labelAlmacenAntes.Visible = true;
                comboAlmacenAntes.Visible = true;
            }
        }

        private void RegistrarEntrada_Load(object sender, EventArgs e)
        {
            comboconcepto.SelectedIndex = 0;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new ValleVerdeComun.BuscarProducto(textProducto, boton, false).ShowDialog(this);
        }

        private void buttonLlenar_Click(object sender, EventArgs e)
        {
            string[] res = obj.ObtenerProducto(textProducto.Text);
            List<string[]> auxres = obj.ObtenerAlmacenProducto(textProducto.Text);

            textdescripcion.Text = res[1];
            textExistencia.Text = res[3];
            textPrecio.Text = res[2];

            int cant = obj.ObtenerCantidadImagenesProducto(textProducto.Text);
            if (cant > 0)
                try
                {
                    pictureBoxProducto.Image = obj.ObtenerImagenesProducto(textProducto.Text)[0];
                }
                catch { }

            comboAlmacen.Items.Clear();            
            comboAlmacen.DisplayMember = "Text";
            comboAlmacen.ValueMember = "Value";

            comboAlmacenAntes.Items.Clear();
            comboAlmacenAntes.DisplayMember = "Text";
            comboAlmacenAntes.ValueMember = "Value";
            if (bandera == 1)
            {
                comboAlmacen.Items.Add(new { Text = "Estante Merma", Value = 5 });
                
            }
            foreach (string[] almacen in auxres)
            {
                comboAlmacen.Items.Add(new { Text = almacen[1], Value = almacen[0] });
                comboAlmacenAntes.Items.Add(new { Text = almacen[1], Value = almacen[0] });
            }
            comboAlmacen.SelectedIndex = 0;
            comboAlmacenAntes.SelectedIndex = 0;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRegiatrar_Click(object sender, EventArgs e)
        {
            float cantidaAjustada = 0;
            
            for (int i = 0; i < dgvEntrada.Rows.Count; i++)
            {
                if (dgvEntrada.Rows[i].Cells[6].Value.ToString() == "Merma" || dgvEntrada.Rows[i].Cells[6].Value.ToString() == "Sobrante Almacen")
                {
                    cantidaAjustada = float.Parse(dgvEntrada.Rows[i].Cells[3].Value.ToString()) - float.Parse(dgvEntrada.Rows[i].Cells[4].Value.ToString()); 
                }
                else
                {
                    cantidaAjustada = float.Parse(dgvEntrada.Rows[i].Cells[3].Value.ToString()) + float.Parse(dgvEntrada.Rows[i].Cells[4].Value.ToString());
                }

                string idProducto = dgvEntrada.Rows[i].Cells[0].Value.ToString();
                int idAlmacen = int.Parse(dgvEntrada.Rows[i].Cells[5].Value.ToString());
                float cantidad = float.Parse(dgvEntrada.Rows[i].Cells[4].Value.ToString());
                string concepto = dgvEntrada.Rows[i].Cells[6].Value.ToString();
                string observacion = dgvEntrada.Rows[i].Cells[7].Value.ToString();
                int antes = int.Parse(dgvEntrada.Rows[i].Cells[8].Value.ToString());

                obj.ActualizarExistenciaProducto(idProducto, idAlmacen, /*cantidaAjustada.ToString(),*/ cantidad, concepto, observacion, merma,antes,idUsuario);
                
            }
            dgvEntrada.Rows.Clear();
            MessageBox.Show("Agregado con exito");
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            dgvEntrada.Rows.Add(textProducto.Text, textdescripcion.Text, (comboAlmacen.SelectedItem as dynamic).Text + "", textExistencia.Text, textCantidad.Text, (comboAlmacen.SelectedItem as dynamic).Value + "", comboconcepto.SelectedItem.ToString(), textObservacion.Text,(comboAlmacenAntes.SelectedItem as dynamic).Value + "");
            
            dgvEntrada.ClearSelection();
            textCantidad.Text = "";
            textdescripcion.Text = "";
            textExistencia.Text = "";
            textPrecio.Text = "";
            textProducto.Text = "";
            comboAlmacen.Items.Clear();
            comboAlmacen.Items.Add(new { Text = "", Value = "" });
            comboAlmacen.SelectedIndex = 0;
            comboAlmacenAntes.Items.Clear();
            comboAlmacenAntes.Items.Add(new { Text = "", Value = "" });
            comboAlmacenAntes.SelectedIndex = 0;

            pictureBoxProducto.Image = global::ValleVerde.Properties.Resources.producto_placeholder200;
        }

        private void dgvEntrada_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult result = MessageBox.Show("Seguro que desea quitar este elemento?", "Quitar", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                dgvEntrada.Rows.Remove(dgvEntrada.CurrentRow);
            }
            else if (result == DialogResult.No)
            {
            }            
        }

        private void textCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.SoloDecimales(sender, e);
        }
    }
}
