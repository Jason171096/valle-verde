using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion.Ventas;

namespace ValleVerde.Vistas.Ventas
{
    public partial class ProductoPromo : Form
    {
        Promocion promo = new Promocion();
        Button boton = new Button();
        List<string[]> listRes = new List<string[]>();
        public ProductoPromo(List<string[]> res)
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvProducto, true, false);
            dgvProducto.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            dgvProducto.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);

            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvMarca, true, false);
            dgvMarca.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            dgvMarca.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);

            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvLinea, true, false);
            dgvLinea.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            dgvLinea.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);

            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvFabricante, true, false);
            dgvFabricante.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            dgvFabricante.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);

            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvProveedor, true, false);
            dgvProveedor.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            dgvProveedor.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);

            boton.Click += new System.EventHandler(this.boton_Click);

            CargarListaMarcas();
            CargarListaLineas();
            CargarListaFabricantes();
            CargarListaProveedores();

            this.listRes = res;
        }

        private void toggleProducto_SliderValueChanged(object sender, EventArgs e)
        {
            if (toggleProducto.IsOn)
            {
                textProducto.Enabled = true;
                buscar.Enabled = true;
                //toggleMarca.IsOn = false;
                //toggleLinea.IsOn = false;
                //toggleFabricante.IsOn = false;
                //toggleProvvedor.IsOn = false;
            }
            else
            {
                textProducto.Enabled = false;
                buscar.Enabled = false;
            }
        }

        private void toggleMarca_SliderValueChanged(object sender, EventArgs e)
        {
            if (toggleMarca.IsOn)
            {
                comboMarca.Enabled = true;
                dgvMarca.Enabled = true;
                //toggleProducto.IsOn = false;
                //toggleLinea.IsOn = false;
                //toggleFabricante.IsOn = false;
                //toggleProvvedor.IsOn = false;
            }
            else
            {
                comboMarca.Enabled = false;
                dgvMarca.Enabled = false;
            }
        }

        private void toggleLinea_SliderValueChanged(object sender, EventArgs e)
        {
            if (toggleLinea.IsOn)
            {
                comboLinea.Enabled = true;
                //toggleProducto.IsOn = false;
                //toggleMarca.IsOn = false;
                //toggleFabricante.IsOn = false;
                //toggleProvvedor.IsOn = false;
            }
            else
            {
                comboLinea.Enabled = false;
            }
        }

        private void toggleFabricante_SliderValueChanged(object sender, EventArgs e)
        {
            if (toggleFabricante.IsOn)
            {
                comboFabricante.Enabled = true;
                //toggleProducto.IsOn = false;
                //toggleLinea.IsOn = false;
                //toggleMarca.IsOn = false;
                //toggleProvvedor.IsOn = false;
            }
            else
            {
                comboFabricante.Enabled = false;
            }
        }

        private void toggleProvvedor_SliderValueChanged(object sender, EventArgs e)
        {
            if (toggleProvvedor.IsOn)
            {
                comboProveedor.Enabled = true;
                //toggleProducto.IsOn = false;
                //toggleLinea.IsOn = false;
                //toggleFabricante.IsOn = false;
                //toggleMarca.IsOn = false;
            }
            else
            {
                comboProveedor.Enabled = false;
            }
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            new ValleVerdeComun.BuscarProducto(textProducto,boton,false).ShowDialog(this);
        }

        private void boton_Click(object sender, EventArgs e)
        {
            string nombre = promo.ObtenerNombreProducto(textProducto.Text);
            int i = 0;
            bool ban = false;
            if (textProducto.Text != "")
            {
                if (dgvProducto.Rows.Count <= 0)
                {
                    dgvProducto.Rows.Add(textProducto.Text, nombre);
                }
                else
                {
                    while (i < dgvProducto.Rows.Count)
                    {
                        if (dgvProducto.Rows[i].Cells[0].Value.ToString() == textProducto.Text)
                        {
                            MessageBox.Show("No se puede agregar el mismo producto");
                            ban = false;
                            break;
                        }
                        else
                        {
                            ban = true;
                        }
                        i++;
                    }
                    if (ban)
                    {
                        dgvProducto.Rows.Add(textProducto.Text, nombre);
                    }
                }
            }
            dgvProducto.ClearSelection();
        }

        private void CargarListaFabricantes()
        {
            Programacion.Fabricantes ob = new Programacion.Fabricantes();

            List<String[]> res = ob.ObtenerFabricantes();

            comboFabricante.DisplayMember = "Text";
            comboFabricante.ValueMember = "Value";

            List<Object> items = new List<Object>();
            items.Add(new { Text = "", Value = "" });
            foreach (String[] fabricante in res)
            {
                items.Add(new { Text = fabricante[1], Value = fabricante[0] });

            }

            comboFabricante.DataSource = items;
        }

        private void CargarListaMarcas()
        {
            Programacion.Marcas ob = new Programacion.Marcas();

            List<String[]> res = ob.ObtenerMarcas();

            comboMarca.DisplayMember = "Text";
            comboMarca.ValueMember = "Value";

            List<Object> items = new List<Object>();
            items.Add(new { Text = "", Value = "" });
            foreach (String[] marca in res)
            {
                items.Add(new { Text = marca[1], Value = marca[0] });
            }

            comboMarca.DataSource = items;
        }

        private void CargarListaLineas()
        {
            Programacion.Lineas ob = new Programacion.Lineas();

            List<String[]> res = ob.ObtenerLineas();

            comboLinea.DisplayMember = "Text";
            comboLinea.ValueMember = "Value";

            List<Object> items = new List<Object>();
            items.Add(new { Text = "", Value = "" });
            foreach (String[] linea in res)
            {
                items.Add(new { Text = linea[1], Value = linea[0] });
            }

            comboLinea.DataSource = items;
        }

        private void CargarListaProveedores()
        {
            Programacion.Proveedor ob = new Programacion.Proveedor();

            List<String[]> res = ob.ObtenerProveedores();

            comboProveedor.DisplayMember = "Text";
            comboProveedor.ValueMember = "Value";

            List<Object> items = new List<Object>();
            items.Add(new { Text = "", Value = "" });
            foreach (String[] unidad in res)
            {
                items.Add(new { Text = unidad[1], Value = unidad[0] });
            }

            comboProveedor.DataSource = items;
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if(textProducto.Text != "" && toggleProducto.IsOn)
            {
                for (int i = 0; i < dgvProducto.Rows.Count; i++)
                {
                    listRes.Add(new String[] { dgvProducto.Rows[i].Cells[0].Value.ToString(), dgvProducto.Rows[i].Cells[1].Value.ToString(), "Producto" });
                }
                //this.Dispose();
            }

            if (comboMarca.SelectedValue.ToString() != "" && toggleMarca.IsOn)
            {
                for (int i = 0; i < dgvMarca.Rows.Count; i++)
                {
                    listRes.Add(new String[] { dgvMarca.Rows[i].Cells[0].Value.ToString(), dgvMarca.Rows[i].Cells[1].Value.ToString(), "Marca" });
                }
                //this.Dispose();
            }

            if (comboLinea.SelectedValue.ToString() != "" && toggleLinea.IsOn)
            {
                for (int i = 0; i < dgvLinea.Rows.Count; i++)
                {
                    listRes.Add(new String[] { dgvLinea.Rows[i].Cells[0].Value.ToString(), dgvLinea.Rows[i].Cells[1].Value.ToString(), "Linea" });
                }
                //this.Dispose();
            }

            if (comboFabricante.SelectedValue.ToString() != "" && toggleFabricante.IsOn)
            {
                for (int i = 0; i < dgvFabricante.Rows.Count; i++)
                {
                    listRes.Add(new String[] { dgvFabricante.Rows[i].Cells[0].Value.ToString(), dgvFabricante.Rows[i].Cells[1].Value.ToString(), "Fabricante" });
                }
                //this.Dispose();
            }

            if (comboProveedor.SelectedValue.ToString() != "" && toggleProvvedor.IsOn)
            {
                for (int i = 0; i < dgvProveedor.Rows.Count; i++)
                {
                    listRes.Add(new String[] { dgvProveedor.Rows[i].Cells[0].Value.ToString(), dgvProveedor.Rows[i].Cells[1].Value.ToString(), "Proveedor" });
                }
                //this.Dispose();
            }
            this.Dispose();
        }

        private void comboMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            bool ban = false;
            if (((comboMarca.SelectedItem as dynamic).Text + "") != "")
            {
                if (dgvMarca.Rows.Count <= 0)
                {
                    dgvMarca.Rows.Add((comboMarca.SelectedItem as dynamic).Value + "", (comboMarca.SelectedItem as dynamic).Text + "");
                }
                else
                {
                    while (i < dgvMarca.Rows.Count)
                    {
                        if (dgvMarca.Rows[i].Cells[0].Value.ToString() == (comboMarca.SelectedItem as dynamic).Value + "")
                        {
                            MessageBox.Show("No se puede agregar el mismo producto");
                            ban = false;
                            break;
                        }
                        else
                        {
                            ban = true;
                        }
                        i++;
                    }
                    if (ban)
                    {
                        dgvMarca.Rows.Add((comboMarca.SelectedItem as dynamic).Value + "", (comboMarca.SelectedItem as dynamic).Text + "");
                    }
                }
            }
            dgvMarca.ClearSelection();
        }

        private void comboLinea_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            bool ban = false;
            if (((comboLinea.SelectedItem as dynamic).Text + "") != "")
            {
                if (dgvLinea.Rows.Count <= 0)
                {
                    dgvLinea.Rows.Add((comboLinea.SelectedItem as dynamic).Value + "", (comboLinea.SelectedItem as dynamic).Text + "");
                }
                else
                {
                    while (i < dgvLinea.Rows.Count)
                    {
                        if (dgvLinea.Rows[i].Cells[0].Value.ToString() == (comboLinea.SelectedItem as dynamic).Value + "")
                        {
                            MessageBox.Show("No se puede agregar el mismo producto");
                            ban = false;
                            break;
                        }
                        else
                        {
                            ban = true;
                        }
                        i++;
                    }
                    if (ban)
                    {
                        dgvLinea.Rows.Add((comboLinea.SelectedItem as dynamic).Value + "", (comboLinea.SelectedItem as dynamic).Text + "");
                    }
                }
            }
            dgvLinea.ClearSelection();
        }

        private void comboFabricante_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            bool ban = false;
            if (((comboFabricante.SelectedItem as dynamic).Text + "") != "")
            {
                if (dgvFabricante.Rows.Count <= 0)
                {
                    dgvFabricante.Rows.Add((comboFabricante.SelectedItem as dynamic).Value + "", (comboFabricante.SelectedItem as dynamic).Text + "");
                }
                else
                {
                    while (i < dgvFabricante.Rows.Count)
                    {
                        if (dgvFabricante.Rows[i].Cells[0].Value.ToString() == (comboFabricante.SelectedItem as dynamic).Value + "")
                        {
                            MessageBox.Show("No se puede agregar el mismo producto");
                            ban = false;
                            break;
                        }
                        else
                        {
                            ban = true;
                        }
                        i++;
                    }
                    if (ban)
                    {
                        dgvFabricante.Rows.Add((comboFabricante.SelectedItem as dynamic).Value + "", (comboFabricante.SelectedItem as dynamic).Text + "");
                    }
                }
            }
            dgvFabricante.ClearSelection();
        }

        private void comboProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            bool ban = false;
            if (((comboProveedor.SelectedItem as dynamic).Text + "") != "")
            {
                if (dgvProveedor.Rows.Count <= 0)
                {
                    dgvProveedor.Rows.Add((comboProveedor.SelectedItem as dynamic).Value + "", (comboProveedor.SelectedItem as dynamic).Text + "");
                }
                else
                {
                    while (i < dgvProveedor.Rows.Count)
                    {
                        if (dgvProveedor.Rows[i].Cells[0].Value.ToString() == (comboProveedor.SelectedItem as dynamic).Value + "")
                        {
                            MessageBox.Show("No se puede agregar el mismo producto");
                            ban = false;
                            break;
                        }
                        else
                        {
                            ban = true;
                        }
                        i++;
                    }
                    if (ban)
                    {
                        dgvProveedor.Rows.Add((comboProveedor.SelectedItem as dynamic).Value + "", (comboProveedor.SelectedItem as dynamic).Text + "");
                    }
                }
            }
            dgvProveedor.ClearSelection();
        }

        private void eliminaProducto_Click(object sender, EventArgs e)
        {
            if (dgvProducto.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Debes seleccionar un elemnto primero");
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Seguro que desea eliminar este producto de la promoción?","Advertencia",MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) 
                {
                    dgvProducto.Rows.Remove(dgvProducto.CurrentRow);
                }
            }
        }

        private void eliminaMarca_Click(object sender, EventArgs e)
        {
            if (dgvMarca.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Debes seleccionar un elemnto primero");
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Seguro que desea eliminar la Marca de la promoción?", "Advertencia", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    dgvMarca.Rows.Remove(dgvMarca.CurrentRow);
                }
            }
        }

        private void eliminaLinea_Click(object sender, EventArgs e)
        {
            if (dgvLinea.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Debes seleccionar un elemnto primero");
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Seguro que desea eliminar la Linea de la promoción?", "Advertencia", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    dgvLinea.Rows.Remove(dgvLinea.CurrentRow);
                }
            }
        }

        private void eliminaFabricante_Click(object sender, EventArgs e)
        {
            if (dgvFabricante.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Debes seleccionar un elemnto primero");
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Seguro que desea eliminar el Fabricante de la promoción?", "Advertencia", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    dgvFabricante.Rows.Remove(dgvFabricante.CurrentRow);
                }
            }
        }

        private void eliminaProveedor_Click(object sender, EventArgs e)
        {
            if (dgvProveedor.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Debes seleccionar un elemnto primero");
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Seguro que desea eliminar el Proveedor de la promoción?", "Advertencia", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    dgvProveedor.Rows.Remove(dgvProveedor.CurrentRow);
                }
            }
        }
    }
}
