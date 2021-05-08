using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion.Configuracion;

namespace ValleVerde.Vistas.Configuracion
{
    public partial class AgregarProductoSucursal : Form
    {
        int idSucursal;
        List<string[]> productos = new List<string[]>();
        Button botonBuscar = new Button();
        Sucursales suc = new Sucursales();
        bool mod = true;

        public AgregarProductoSucursal(int idSucursal)
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvProductoSuc, true, false);
            utilidad.ReadOnly = false;
            precioSuc.ReadOnly = false;
            botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            this.idSucursal = idSucursal; 
        }

        private void AgregarProductoSucursal_Load(object sender, EventArgs e)
        {
            textBoxProducto.Select();
            LlenarCombos();
        }

        private void LlenarCombos()
        {
            CargarListaFabricantes();
            CargarListaLineas();
            CargarListaMarcas();
            CargarListaProveedores();
        }

        private void CargarListaFabricantes()
        {
            Programacion.Fabricantes ob = new Programacion.Fabricantes();

            List<String[]> res = ob.ObtenerFabricantes();

            cbFabricante.DisplayMember = "Text";
            cbFabricante.ValueMember = "Value";

            List<Object> items = new List<Object>();

            foreach (String[] fabricante in res)
            {
                items.Add(new { Text = fabricante[1], Value = fabricante[0] });

            }

            cbFabricante.DataSource = items;
        }

        private void CargarListaMarcas()
        {
            Programacion.Marcas ob = new Programacion.Marcas();

            List<String[]> res = ob.ObtenerMarcas();

            cbMarca.DisplayMember = "Text";
            cbMarca.ValueMember = "Value";

            List<Object> items = new List<Object>();

            foreach (String[] marca in res)
            {
                items.Add(new { Text = marca[1], Value = marca[0] });
            }

            cbMarca.DataSource = items;
        }

        private void CargarListaLineas()
        {
            Programacion.Lineas ob = new Programacion.Lineas();

            List<String[]> res = ob.ObtenerLineas();

            cbLinea.DisplayMember = "Text";
            cbLinea.ValueMember = "Value";

            List<Object> items = new List<Object>();


            foreach (String[] linea in res)
            {
                items.Add(new { Text = linea[1], Value = linea[0] });
            }

            cbLinea.DataSource = items;
        }

        private void CargarListaProveedores()
        {
            Programacion.Proveedor ob = new Programacion.Proveedor();

            List<String[]> res = ob.ObtenerProveedores();

            cbProveedor.DisplayMember = "Text";
            cbProveedor.ValueMember = "Value";

            List<Object> items = new List<Object>();

            foreach (String[] unidad in res)
            {
                items.Add(new { Text = unidad[1], Value = unidad[0] });
            }

            cbProveedor.DataSource = items;
        }

        private void botonProducto_Click(object sender, EventArgs e)
        {
            new ValleVerdeComun.BuscarProducto(textBoxProducto,botonBuscar,false).ShowDialog();
        }

        private void botonBuscar_Click(Object sender, EventArgs e)
        {
            string nom = suc.ObtenerNombreProducto(textBoxProducto.Text);

            if (nom != "")
            {
                List<decimal[]> resPrecio = suc.ObtenerPreciosCostoProducto(textBoxProducto.Text);
                decimal precioM = suc.ObtenerPrecioProducto(textBoxProducto.Text, resPrecio[0][1], -1, -1);
                decimal costo = suc.ObtenerCostoProducto(textBoxProducto.Text);
                dgvProductoSuc.Rows.Add(textBoxProducto.Text, nom, costo, resPrecio[0][0], precioM, 0, 0);
            }
            else
            {
                MessageBox.Show("El producto no Existe");
            }
            textBoxProducto.Text = "";
        }

        private void textBoxProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                botonBuscar.PerformClick();
            }
        }

        private void cbMarca_SelectionChangeCommitted(object sender, EventArgs e)
        {
            productos = new List<string[]>();
            MostrarProducto mp = new MostrarProducto(int.Parse(cbMarca.SelectedValue.ToString()), productos,1);
            mp.ShowDialog();
            AgregarProductoTabla(productos);
        }

        private void cbLinea_SelectionChangeCommitted(object sender, EventArgs e)
        {
            productos = new List<string[]>();
            MostrarProducto mp = new MostrarProducto(int.Parse(cbLinea.SelectedValue.ToString()), productos,2);
            mp.ShowDialog();
            AgregarProductoTabla(productos);
        }

        private void cbProveedor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            productos = new List<string[]>();
            MostrarProducto mp = new MostrarProducto(int.Parse(cbProveedor.SelectedValue.ToString()), productos,3);
            mp.ShowDialog();
            AgregarProductoTabla(productos);
        }

        private void cbFabricante_SelectionChangeCommitted(object sender, EventArgs e)
        {
            productos = new List<string[]>();
            MostrarProducto mp = new MostrarProducto(int.Parse(cbFabricante.SelectedValue.ToString()), productos,4);
            mp.ShowDialog();
            AgregarProductoTabla(productos);
        }

        private void AgregarProductoTabla(List<string[]> prod)
        {
            foreach (string[] resProd in prod)
            {
                string nom = suc.ObtenerNombreProducto(resProd[0]);

                if (nom != "")
                {
                    List<decimal[]> resPrecio = suc.ObtenerPreciosCostoProducto(resProd[0]);
                    decimal precioM = suc.ObtenerPrecioProducto(resProd[0], resPrecio[0][1], -1, -1);
                    decimal costo = suc.ObtenerCostoProducto(resProd[0]);
                    dgvProductoSuc.Rows.Add(resProd[0], nom, costo, resPrecio[0][0], precioM, 0, 0);
                }
                else
                {
                    MessageBox.Show("El producto no Existe");
                }
            }
        }

        private void dgvProductoSuc_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 5)
            {
                if (dgvProductoSuc.CurrentRow != null) 
                {
                    mod = false;
                    decimal ut = decimal.Parse(dgvProductoSuc.CurrentRow.Cells[5].Value.ToString());
                   List<decimal[]> resPrecio = suc.ObtenerPreciosCostoProducto(dgvProductoSuc.CurrentRow.Cells[0].Value.ToString());
                    decimal precioM = suc.ObtenerPrecioProducto(dgvProductoSuc.CurrentRow.Cells[0].Value.ToString(), resPrecio[0][1], ut, -1);
                    dgvProductoSuc.CurrentRow.Cells[6].Value = precioM;
                     
                }
            }
            if (e.ColumnIndex == 6)
            {
                if (dgvProductoSuc.CurrentRow != null)
                {
                    if (mod) 
                    { 
                        try
                        {
                            //string p = dgvProductoSuc.CurrentRow.Cells[6].Value.ToString();
                            //p = p.Substring(1, p.Length - 1);
                            double pre = Convert.ToDouble(dgvProductoSuc.CurrentRow.Cells[6].Value);
                            double cost = Convert.ToDouble(dgvProductoSuc.CurrentRow.Cells[2].Value);
                            double ut = pre * 100 / cost - 100;

                            if (ut > 0)
                                dgvProductoSuc.CurrentRow.Cells[5].Value = ut.ToString("N4");
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        mod = true;
                    }
                }
            }
        }

        private void botonAgregar_Click(object sender, EventArgs e)
        {
            List<string[]> encero = new List<string[]>();
            int corr = 0, dup = 0, s = 0, p = 0;
            if (dgvProductoSuc.Rows.Count > 0) 
            { 
                for (int i = 0; i < dgvProductoSuc.Rows.Count; i++)
                {
                    if (double.Parse(dgvProductoSuc.Rows[i].Cells[5].Value.ToString()) > 0)
                    {
                        string res = suc.AgregarUtilidadSucursal(dgvProductoSuc.Rows[i].Cells[0].Value.ToString(),idSucursal, double.Parse(dgvProductoSuc.Rows[i].Cells[5].Value.ToString()));

                        switch (res)
                        {
                            case "1":
                                corr++;
                                break;
                            case "-1":
                                dup++;
                                break;
                            case "-2":
                                s++;
                                break;
                            case "-3":
                                p++;
                                break;
                        }
                    }
                    else
                    {
                        encero.Add(new string[] { dgvProductoSuc.Rows[i].Cells[0].Value.ToString(), dgvProductoSuc.Rows[i].Cells[1].Value.ToString(), dgvProductoSuc.Rows[i].Cells[2].Value.ToString(), dgvProductoSuc.Rows[i].Cells[3].Value.ToString(), dgvProductoSuc.Rows[i].Cells[4].Value.ToString(), dgvProductoSuc.Rows[i].Cells[5].Value.ToString(), dgvProductoSuc.Rows[i].Cells[6].Value.ToString()});
                    }
                }
            }

            MessageBox.Show(corr+" Productos agregados correctamente");
            if (dup > 0)
            {
                MessageBox.Show(dup + " Productos ya se encontraban en la sucursal\nSe omitieron sin ningun cambio");
            }

            dgvProductoSuc.Rows.Clear();
            foreach (string[] productosSucursal in encero)
            {
                dgvProductoSuc.Rows.Add(productosSucursal[0], productosSucursal[1], productosSucursal[2], productosSucursal[3], productosSucursal[4], productosSucursal[5], productosSucursal[6]);
            }
        }

        
    }
}
