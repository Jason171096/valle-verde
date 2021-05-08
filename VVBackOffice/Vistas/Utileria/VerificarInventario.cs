using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;
using TextBox = System.Windows.Forms.TextBox;

namespace ValleVerde.Vistas.Utileria
{
    public partial class VerificarInventario : Form
    {

        List<String[]> ListaPAV;
        List<Object> itemsU = new List<Object>();

        Programacion.Utileria.VerificarInventario verinv = new Programacion.Utileria.VerificarInventario();
        bool seleccionHabilitada = true;
        bool cerrarventana = true;
        int indRenSel;

        decimal suma = 0;

        public VerificarInventario()
        {
            InitializeComponent();

            CargarListaUbicaciones();

        }

        private void CargarListaUbicaciones()
        {
            Programacion.Ubicacion ob = new Programacion.Ubicacion();

            List<String[]> res = ob.ObtenerUbicaciones();

            cbubicacion.DisplayMember = "Text";
            cbubicacion.ValueMember = "Value";

            List<Object> items = new List<Object>();

            foreach (String[] ubicacion in res)
            {
                items.Add(new { Text = ubicacion[1], Value = ubicacion[0] });
            }

            cbubicacion.DataSource = items;

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void VerificarInventario_Load_1(object sender, EventArgs e)
        {
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(tablaver, true, false);
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(tablaalma, true, false);

            //tablaver.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            tablaver.Columns[1].Width = 155;

            tablaalma.Columns[3].ReadOnly = false;

            LLenarTablaVer(true);

            LlenarListaUbicaciones();

            tablaalma.CellBeginEdit += new DataGridViewCellCancelEventHandler(dataGriedEscribir_CellBeginEdit);
            tablaalma.CellValueChanged += new DataGridViewCellEventHandler(CapturaCantidades_CellValueChanged);
            tablaver.SelectionChanged += new EventHandler(tablaver_SelectionChanged);
            this.FormClosing += new FormClosingEventHandler(VerificarInventario_FormClosing);
        }

        private void LLenarTablaVer(bool seleccionarPrimero)
        {
            ListaPAV = verinv.ObtenerProductosAVerificar();
            foreach (String[] Producto in ListaPAV)
            {
                tablaver.Rows.Add(Producto[0], Producto[1], Producto[2], Producto[3]);
            }
            if (seleccionarPrimero)
            {
                tablaver.Rows[0].Selected = true;
                tablaver.CurrentCell = tablaver.Rows[0].Cells[1];
            }
            else
            {
                tablaver.Rows[tablaver.RowCount - 1].Selected = true;
                tablaver.CurrentCell = tablaver.Rows[tablaver.RowCount - 1].Cells[1];
            }
            tablaver_SelectionChanged(null, null);
        }

        private void CapturaCantidades_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if(e.ColumnIndex ==3)
            {
                decimal can = 0;
                try
                {
                    can = decimal.Parse(tablaalma.Rows[e.RowIndex].Cells[3].Value + "");

                    if (can < 0)
                        throw new FormatException();
                        MessageBox.Show("No puedes tener letras");
                    
                    if (!bool.Parse(tablaver.SelectedRows[0].Cells[3].Value.ToString()))
                    {
                        if (can.ToString().Contains("."))
                        {
                            MessageBox.Show("Este producto no puede contarse en decimales.");
                            can = 0;
                        }
                    }
                    
                    tablaalma.Rows[e.RowIndex].Cells[3].Value = can;
                    //Mandar llamar el metodo que suma
                    //Actualizar en la base de datos a traves de un procedimiento almacenado
                    //verinv.ActualizarCantidadUbicacion(long.Parse(tablaalma.SelectedRows[0].Cells[0].Value.ToString()), can);
                    verinv.ActualizarUbicacionAVerrificar(tablaalma.CurrentRow.Cells[0].Value.ToString(), (float)can);
                }
                catch(Exception ex)
                {
                    if (ex is FormatException || ex is NullReferenceException || ex is ArgumentNullException || ex is OverflowException)
                    {
                        tablaalma.Rows[e.RowIndex].Cells[3].Value = 0.0000;
                    }
                }
                CalcularCantidadTotal();
               
            }
            
        }

        private void LlenarListaUbicaciones()
        {
            List<String[]> ListaUbi = verinv.ObtenerUbicaciones();

            cbubicacion.DisplayMember = "Text";
            cbubicacion.ValueMember = "Value";

            

            foreach (String[] index in ListaUbi)
                itemsU.Add(new { Text = index[1], Value = index[0] });
            

            cbubicacion.DataSource = itemsU;

        }

        private void dataGriedEscribir_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if(e.ColumnIndex==3)
            {
                tablaver.SelectedRows[0].DefaultCellStyle.BackColor = Color.Green;
                seleccionHabilitada = false;
                finalizar.Enabled = true;
            }
        }

        private void tablaver_SelectionChanged(Object sender, EventArgs e)
        {
            if (seleccionHabilitada)
            {
                finalizar.Enabled = false;
                if(tablaver.SelectedRows[0].DefaultCellStyle.BackColor == Color.Green)
                {
                    tablaver.ReadOnly = true;
                    finalizar.Enabled = false;
                }
                else
                {
                    //if(tablaver.SelectedRows[0].DefaultCellStyle.BackColor == Color.Green)
                    //{
                    //    tablaalma.ReadOnly = true;
                    //    finalizar.Enabled = false;
                    //}
                    //else
                    //{
                        tablaalma.ReadOnly = false;
                        tablaalma.Columns[1].ReadOnly = true;
                        tablaalma.Columns[3].ReadOnly = false;
                    //}

                    txtnom.Text = tablaver.CurrentRow.Cells[2].Value.ToString(); 

                    LlenarTablaalma(); 

                    indRenSel = tablaver.SelectedRows[0].Index;
                    String codigo = tablaver.CurrentRow.Cells[1].Value.ToString();
                    TextBox tb = new TextBox();
                    tb.Text = codigo;

                    if (codigo != "")
                    {
                        ValleVerdeComun.Programacion.Producto ob = new ValleVerdeComun.Programacion.Producto();

                        tb.Enabled = false;

                        int cant = ob.ObtenerCantidadImagenesProducto(codigo);
                        if (cant > 0)   
                        {
                            pictureBox1.Image = ob.ObtenerImagenesProducto(codigo)[0];
                        }   
                        else
                            pictureBox1.Image = null;
                    }
                }
                
            }
            
            else
                if(tablaver.RowCount > 0)
                    tablaver.Rows[indRenSel].Selected = true;                    
        }

        private void LlenarTablaalma()
        {
            String ClvVerificar = tablaver.SelectedRows[0].Cells[0].Value.ToString();
            String nomUbica = "";
            List<String[]> ListaUAV = verinv.ObtenerUbicacionesAVerificar(ClvVerificar, "21");

            tablaalma.Rows.Clear();
            List<string[]> listaUbicacion = verinv.ObtenerUbicaciones();
            foreach (String[] Producto in ListaUAV)
            {
                foreach (string[] res in listaUbicacion)
                {
                    if (res[0] + "" == Producto[1] + "")
                    {
                        nomUbica = res[1] + "";
                    }
                }
                tablaalma.Rows.Add(Producto[0], nomUbica, Producto[2], Producto[3]);
            }
        }

        private void tablaver_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            new ValleVerdeComun.BuscarProducto(textBox2, Aceptar, false).ShowDialog(this);
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {

            int i = 0;
            bool ban = true;

            if (tablaver.Rows.Count == 0)
            {
                InsertarProducto();
            }
            else
            {
                seleccionHabilitada = false;
                tablaver.Rows.Clear();
                seleccionHabilitada = true;
                while (i<tablaver.Rows.Count)
                {
                    if(tablaver.Rows[i].Cells[1].Value.ToString() == textBox2.Text)
                    {
                        MessageBox.Show("No se pueden repetir los productos en la lista a verificar.");
                        ban = false;
                        break;
                    }
                    else
                    {
                        ban = true;
                    }
                    i++;
                }
                if(ban)
                {
                    InsertarProducto();
                }        
            }
        }

        private void InsertarProducto()
        {
            //object[] obs = verinv.VerificarExistencia(textBox2.Text);
            object oba = verinv.AgregarProductosAVerificar(textBox2.Text);

            switch (oba)
            {
                case -1:
                    MessageBox.Show("Ese Codigo de producto no existe ");
                    break;
                case -2:
                    MessageBox.Show("EL producto ya existe en la lista a verificar");
                    break;
                default:
                   // MessageBox.Show();
                //    tablaver.Rows.Add(new object[] { "", oba[0], oba[1], oba[2] });
                    break;
            }
            LLenarTablaVer(false);
        }

        private void finalizar_Click(object sender, EventArgs e)
        {
            object VericarResultado = verinv.ObtenerExistenciaTotalProducto(tablaver.SelectedRows[0].Cells[1].Value.ToString());
            String ClvVerificar = tablaver.SelectedRows[0].Cells[0].Value.ToString();

            if (suma == (decimal)VericarResultado)
            {
                seleccionHabilitada = true;
                List<String[]> ListaAVE = verinv.ActualizarVerificarExistencia(ClvVerificar);
                cerrarventana = true;
                finalizar.Enabled = false;
                textBox3.Text = "";
                MessageBox.Show("Productos contados con exito.");
                //tablaalma.ReadOnly = true;
            }
            else
            {
                DialogResult resultado = MessageBox.Show("No coincide con la existencia total actual. ¿Seguro deseas finalizar? Recuerda que no podras realizar cambios.", "Salir", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    // List<string[]> listAUAV = verinv.ActualizarUbicacionAVerrificar(tablaalma.CurrentRow.Cells[0].Value.ToString(), float.Parse(tablaalma.CurrentRow.Cells[3].Value.ToString()));
                    seleccionHabilitada = true;
                    List<String[]> ListaAVE = verinv.ActualizarVerificarExistencia(ClvVerificar);
                    cerrarventana = true;
                    finalizar.Enabled = false;
                    textBox3.Text = "";
                    //tablaalma.ReadOnly = true;
                }
                else
                if (resultado == DialogResult.No)
                {
                    //MessageBox.Show("Puedes realizar cambios asegurate, de colocar los resultados correctos");
                    cerrarventana = false;
                }
            }

            //if (tablaver.CurrentRow.Cells[3].Value.ToString() == "False")
            //{
            //    if (tablaalma.CurrentRow.Cells[3].Value.ToString().Contains("."))
            //    {
            //        MessageBox.Show("Este producto no puede tener numeros decimales");
            //    }
            //    else
            //    {
            //        MessageBox.Show("¿Estas seguro de finalizar, recuerda que no podras modificar la cantidad de productos?");
                   
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("¿Estas seguro de finalizar, recuerda que no podras modificar la cantidad de productos?");
            //    List<string[]> listAUAV = verinv.ActualizarUbicacionAVerrificar(tablaalma.CurrentRow.Cells[0].Value.ToString(), float.Parse(tablaalma.CurrentRow.Cells[3].Value.ToString()));
            //    seleccionHabilitada = true;
            //    List<String[]> ListaAVE = verinv.ActualizarVerificarExistencia(ClvVerificar);
            //}
        }
        private void nom_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void CalcularCantidadTotal()
        {
            suma = 0;
            foreach (DataGridViewRow row in tablaalma.Rows)
            {
                suma += Convert.ToDecimal(row.Cells[3].Value);
            }
            textBox3.Text = Convert.ToString(suma);
        }

        private void VerificarInventario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!seleccionHabilitada)
                finalizar.PerformClick();

            if (!cerrarventana)
                e.Cancel = true;
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            int i = 0;
            bool ban = true;

            if (tablaalma.Rows.Count == 0)
            {
                InsertarUbicacion();
            }
            else
            {
                while (i < tablaalma.Rows.Count)
                {
                    if (tablaalma.Rows[i].Cells[1].Value.ToString() == cbubicacion.Text)
                    {
                        MessageBox.Show("NO SE PUEDE REPETIR UNA UBICACION");
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
                    InsertarUbicacion();
                }
            }
        }

        private void InsertarUbicacion()
        {
            object obr = verinv.AgregarUbicacionAVerificar(long.Parse(tablaver.CurrentRow.Cells[0].Value.ToString()), long.Parse(cbubicacion.SelectedValue.ToString()), long.Parse("22"));

            switch (obr)
            {
                case -1:
                    MessageBox.Show("El IDUbicacion ya existe...");
                    break;
            }
            LlenarTablaalma();
        }

        private void txtnom_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}