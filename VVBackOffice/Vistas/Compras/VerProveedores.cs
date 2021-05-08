using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using Color = MigraDoc.DocumentObjectModel.Color;
using MigraDoc.DocumentObjectModel.Tables;
using Font = MigraDoc.DocumentObjectModel.Font;
using System;
using System.Diagnostics;
using ValleVerde.Programacion.Inventario;
using Microsoft.Office.Core;
using System.Runtime.InteropServices;
using ValleVerde.Programacion.RecursosHumanos;
using Microsoft.Office.Interop.Excel;
using ScrollBars = System.Windows.Forms.ScrollBars;
using System.Windows.Input;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using Label = System.Windows.Forms.Label;
using TextBox = System.Windows.Forms.TextBox;

namespace ValleVerde.Vistas.Compras
{
    public partial class Proveedores : Form
    {

        List<String[]> cargartodo;
        bool bandera = false;

        Programacion.Compra.Proveedor prov = new Programacion.Compra.Proveedor();

        public Proveedores()
        {
            InitializeComponent();
        }

        private void VerProveedores_Load(object sender, EventArgs e)
        {
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(tablaprov, true, false);

            tablaprov.Columns[0].Width = 125;
            tablaprov.Columns[1].Width = 200;
            tablaprov.Columns[2].Width = 200;
            tablaprov.Columns[3].Width = 200;
            tablaprov.Columns[4].Width = 150;
            tablaprov.Columns[5].Width = 85;
            tablaprov.Columns[6].Width = 80;
            tablaprov.Columns[7].Width = 150;
            tablaprov.Columns[8].Width = 125;
            tablaprov.Columns[9].Width = 120;
            tablaprov.Columns[10].Width = 160;
            tablaprov.Columns[11].Width = 140;
            tablaprov.Columns[12].Width = 140;
            tablaprov.Columns[13].Width = 140;
            tablaprov.Columns[14].Width = 75;
            tablaprov.Columns[15].Width = 190;
            tablaprov.Columns[16].Width = 80;
            tablaprov.Columns[17].Width = 185;

            //Habilitar Edicion
            tablaprov.Columns[1].ReadOnly = false;
            tablaprov.Columns[2].ReadOnly = false;
            tablaprov.Columns[3].ReadOnly = false;
            tablaprov.Columns[4].ReadOnly = false;
            tablaprov.Columns[5].ReadOnly = false;
            tablaprov.Columns[6].ReadOnly = false;
            tablaprov.Columns[7].ReadOnly = false;
            tablaprov.Columns[8].ReadOnly = false;
            //tablaprov.Columns[9].ReadOnly = false;
            tablaprov.Columns[10].ReadOnly = false;
            tablaprov.Columns[11].ReadOnly = false;
            //tablaprov.Columns[13].ReadOnly = false;
            tablaprov.Columns[15].ReadOnly = false;
            tablaprov.Columns[16].ReadOnly = false;
            tablaprov.Columns[17].ReadOnly = false;

            //tablaprov.EditingControlShowing += new DataGridViewEditingControlShowingEventArgs(Letra);
            tablaprov.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(Letra);
            tablaprov.KeyPress += new KeyPressEventHandler(tablaprov_KeyPress);
            tablaprov.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(Numeros);
            tablaprov.KeyPress += new KeyPressEventHandler(tablaprov_KeyPress_1);
                

            CargarEstados();
            CargarCiudades();

            if (checktodo.Checked)
            {
                CargarTodo("-1","-1",-1);
            }

            
        }


        private void CargarTodo(string estado, string ciudad, int activo)
        {

            tablaprov.Rows.Clear();
            cargartodo= prov.ObtenerTodosProveedores(estado, ciudad,textBox1.Text, activo);

            //List<object> items = new List<object>();
            String Inactivo;


            foreach(String[] todo in cargartodo)
            {
                if (todo[14].Equals("True"))
                {
                    Inactivo = "Activo";
                }
                else
                {
                   Inactivo = "Inactivo";
                }
                    
                tablaprov.Rows.Add(todo[0],todo[1],todo[2],todo[3],todo[4],todo[5],todo[6], todo[7], todo[8], todo[9], todo[10], todo[11], todo[12], todo[13], Inactivo, todo[15], todo[16], todo[17]);
            }
            tablaprov.ClearSelection();
            bandera = true;
        }

        private void CargarEstados()
        {
            List<String[]> res = prov.ObtenerEstados();

            cbestado.DisplayMember = "Text";
            cbestado.ValueMember = "Value";
            
            List<Object> items = new List<Object>();

            items.Add(new { Text = "Todos los Estados", Value = "-1" });

            foreach (String[] estado in res)
            {
                items.Add(new { Text = estado[0], Value = estado[0]});
            }
            cbestado.DataSource = items;
        }

        private void CargarCiudades()
        {
            List<String[]> res = prov.ObtenerCiudades();

            cbciudad.DisplayMember = "Text";
            cbciudad.ValueMember = "Value";

            List<Object> items= new List<Object>();
            items.Add(new { Text = "Todas las Ciudades", Value = "-1" });

            foreach (String[] ciudad in res)
            {
                items.Add(new { Text = ciudad[0],Value = ciudad[0] });
            }

            cbciudad.DataSource = items;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int act = -1;
            if (checkBox1.Checked)
            {
                act = 1;
            }
            if (checkBox2.Checked)
            {
                act = 0;
            }
            CargarTodo((cbestado.SelectedItem as dynamic).Value + "",(cbciudad.SelectedItem as dynamic).Value + "",act);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            new ProveedorModificar().ShowDialog();
            Llenar();
        }

        private void pdf_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "PDF (*.pdf)|*.pdf";
                fichero.FileName = "InformacionProductos_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    // Create a MigraDoc document
                    Document document = CreateDocument();
                    document.UseCmykColor = true;

                    // ===== Unicode encoding and font program embedding in MigraDoc is demonstrated here =====

                    const bool unicode = false;

                    // Create a renderer for the MigraDoc document.
                    PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(unicode);

                    // Associate the MigraDoc document with a renderer
                    pdfRenderer.Document = document;

                    // Layout and render document to PDF
                    pdfRenderer.RenderDocument();

                    // Save the document...            
                    pdfRenderer.PdfDocument.Save(fichero.FileName);

                    // ...and start a viewer.
                    Process.Start(fichero.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar la informacion debido a: " + ex.ToString());
            }
        }

        private Document CreateDocument()
        {
            // Create a new MigraDoc document
            Document document = new Document();

            // Crear fuentes
            Font fueTit = new Font("Verdana", 18);
            fueTit.Bold = true;
            Font fueDoc = new Font("Verdana", 10);
            fueDoc.Bold = true;
            Font fueTab = new Font("Arial", 10);

            //
            //string titComStr = "Compra", titFacStr = "Factura";
            
            Color verTit = new Color(0, 255, 60);
            Color verRen = new Color(156, 255, 178);
            double ancTex;
            MedidorTexto mt = new MedidorTexto(fueTab);
            mt.Font = fueTab;
            //decimal subAjuProd, impAjuProd, totAjuProd, subAjuFac = 0, impAjuFac = 0, totAjuFac = 0;

            // Add a section to the document
            Section secCom = document.AddSection();
            secCom.PageSetup.PageFormat = PageFormat.Letter;
            // Añadir elementos a la seccion
            Paragraph tit = secCom.AddParagraph();
            Table tabDat = secCom.AddTable();
            secCom.AddParagraph();
            Table tab = secCom.AddTable();
            secCom.AddParagraph();
            //Table tabFin = secCom.AddTable();
            Table foo = new Table();
            foo.AddColumn();
            foo.AddColumn();
            foo.AddRow();
            foo.Columns[0].Format.Alignment = ParagraphAlignment.Left;
            foo.Columns[1].Format.Alignment = ParagraphAlignment.Right;
            foo.Columns[0].Width = 472;
            foo.Columns[1].Width = 100;
            foo.Rows[0].Cells[1].AddParagraph().AddPageField();

            secCom.Footers.Primary.Add(foo.Clone());
            secCom.PageSetup.TopMargin = 10;
            secCom.PageSetup.LeftMargin = 12;
            secCom.PageSetup.RightMargin = 0;
            secCom.PageSetup.BottomMargin = 50;
            //tit.AddFormattedText(titComStr, fueTit);
            tit.Format.Alignment = ParagraphAlignment.Center;
            tabDat.AddColumn();
            tabDat.AddColumn();
            tabDat.AddRow();
            tabDat.AddRow();
            tabDat.AddRow();
            tabDat.Format.Font = fueDoc;
            tabDat.Columns[0].Width = 367;
            tabDat.Columns[1].Width = 205;

            tabDat.Columns[0].Format.Alignment = ParagraphAlignment.Left;
            tabDat.Columns[1].Format.Alignment = ParagraphAlignment.Left;
            
            tabDat.Rows[2].Cells[0].AddParagraph("Proveedores ValleVerde ");
            tabDat.Rows[2].Cells[1].AddParagraph("Usuario: " );

            tab.AddColumn();
            tab.AddColumn();
            tab.AddColumn();
            tab.AddColumn();
           // tab.AddColumn();
            tab.AddColumn();

            tab.Borders.Color = Colors.Black;
            tab.Borders.Width = 0.25;
            tab.Rows.VerticalAlignment = VerticalAlignment.Center;
            tab.Format.Font = fueTab;
            //tab.Columns.Width = 198;//190

            tab.Columns[0].Width = 240;
            tab.Columns[1].Width = 170;
            tab.Columns[2].Width = 65;
            tab.Columns[3].Width = 55;
            //tab.Columns[4].Width = 110;
            tab.Columns[4].Width = 50;

            Row row = tab.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Shading.Color = Colors.PaleGreen;

            int a = 0;

            for (int b = 0; b < tablaprov.ColumnCount; b++)
            {
                    if (b == 1 || b == 2 || b == 5 || b == 6 ||  b == 14)
                    {
                        row.Cells[a].AddParagraph(tablaprov.Columns[b].HeaderText);
                        a++;
                    }       
            }

            for (int i = 0; i < tablaprov.RowCount; i++)
            {
                tab.AddRow(); 
                
                int c = 0;

                for (int j = 0; j < tablaprov.ColumnCount; j++)
                {
                    if (tablaprov.Rows[i].Cells[j].Value != null)
                    {
                       
                         if (j == 1 || j == 2 || j == 5 || j == 6  || j == 14)
                         {
                             tab.Rows[i + 1].Cells[c].AddParagraph(tablaprov.Rows[i].Cells[j].Value.ToString());
                            c++;
                         }
                    }
                }
            }

            //int col = 0;
            //double[] maxPunPorCol =
            //{
            //            0,
            //            0,
            //            0,
            //            0,
            //            0,
            //            0,
            //            0,
            //            0,
            //            0,
            //            0
            //        };
            //int[] minPunPorCol =
            //{
            //            40,
            //            1,
            //            30,//26
            //            36,
            //            38,
            //            38,
            //            44,
            //            24,
            //            29,
            //            44
            //        };

            return document;
        }

        private void excel_Click(object sender, EventArgs e)
        {
            ExportarTablaExcel obs = new ExportarTablaExcel();
            obs.GenerarExcel(tablaprov, -1, -1);
        }

        private void checktodo_CheckedChanged(object sender, EventArgs e)
        {
            if (checktodo.Checked)
            {
                checkestado.Checked = false;
                checkciudad.Checked = false;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                cbciudad.SelectedIndex = 0;
                cbestado.SelectedIndex = 0;
                CargarTodo("-1","-1",-1);

            }
        }

        private void cbestado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkestado.Checked)
            {
                CargarTodo((cbestado.SelectedItem as dynamic).Value +"", (cbciudad.SelectedItem as dynamic).Value + "", -1);
            }
        }

        private void checkestado_CheckedChanged(object sender, EventArgs e)
        {
            if (checkestado.Checked)
            {
                checktodo.Checked = false;
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
                checktodo.Checked = false;
                CargarTodo((cbestado.SelectedItem as dynamic).Value+"", (cbciudad.SelectedItem as dynamic).Value + "", 1);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                checktodo.Checked = false;
                CargarTodo((cbestado.SelectedItem as dynamic).Value + "", (cbciudad.SelectedItem as dynamic).Value + "", 0);
            }
        }

        private void checkciudad_CheckedChanged(object sender, EventArgs e)
        {
            if(checkciudad.Checked)
            {
                checktodo.Checked = false;
            }
           
        }

        private void cbciudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            int act = -1;
            if (checkBox1.Checked)
            {
                act = 1;
            }
            if(checkBox2.Checked)
            {
                act = 0;            
            }
            if (checkciudad.Checked)
            {
                CargarTodo((cbestado.SelectedItem as dynamic).Value + "", (cbciudad.SelectedItem as dynamic).Value+"", act);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox3.Checked)
            {
                tablaprov.Dock = DockStyle.None;
                tablaprov.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                tablaprov.ScrollBars = ScrollBars.Both;

                for (int x = 0; x < tablaprov.Columns.Count; x++)
                {
                    tablaprov.Columns[x].Visible = true;
                }
                int act = -1;
                if (checkBox1.Checked)
                {
                    act = 1;
                }
                if (checkBox2.Checked)
                {
                    act = 0;
                }
                CargarTodo((cbestado.SelectedItem as dynamic).Value + "", (cbciudad.SelectedItem as dynamic).Value + "", act);
            }
            else
            {
                new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(tablaprov, true, false);

                for (int x = 0; x < tablaprov.Columns.Count; x++)
                {
                    if(x == 1 || x == 2 || x == 5 || x == 6 || x == 14)
                    {
                        tablaprov.Columns[x].Visible = true;
                    }
                    else
                    {
                        tablaprov.Columns[x].Visible =false;
                    }
                    
                }

                int act = -1;
                if (checkBox1.Checked)
                {
                    act = 1;
                }
                if (checkBox2.Checked)
                {
                    act = 0;
                }
                CargarTodo((cbestado.SelectedItem as dynamic).Value + "", (cbciudad.SelectedItem as dynamic).Value + "", act);
            }
            tablaprov.Columns[9].Visible = false;
            tablaprov.Columns[12].Visible = false;
            tablaprov.Columns[13].Visible = false;
        }

        private void Llenar()
        {
            int act = -1;
            if (checkBox1.Checked)
            {
                act = 1;
            }
            if (checkBox2.Checked)
            {
                act = 0;
            }
            CargarTodo((cbestado.SelectedItem as dynamic).Value + "", (cbciudad.SelectedItem as dynamic).Value + "", act);
        }

        private void tablaprov_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 14)
            {
                DialogResult resultado = MessageBox.Show("Estas apunto de cambiar el estatus del proveedor,\n deseas realizar esta accion", "Salir", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    if (tablaprov.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == "Activo")
                    {
                        prov.ActualizarProveedorPorCampos(long.Parse(tablaprov.Rows[e.RowIndex].Cells[0].Value.ToString()), "Activo", "False");
                        tablaprov.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Inactivo";
                        MessageBox.Show("Cambiaste el estatus del proveedor");
                    }
                    else
                    if (tablaprov.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == "Inactivo")
                    {
                        prov.ActualizarProveedorPorCampos(long.Parse(tablaprov.Rows[e.RowIndex].Cells[0].Value.ToString()), "Activo", "True");
                        tablaprov.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Activo";
                        MessageBox.Show("Cambiaste el estatus del proveedor");
                    }
                }
                else
                {
                    MessageBox.Show("No realizaste ningun cambio");
                }
            }
        }

        private void Numeros(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(tablaprov_KeyPress_1);

            if (tablaprov.CurrentCell.ColumnIndex == 5 || tablaprov.CurrentCell.ColumnIndex == 6 || tablaprov.CurrentCell.ColumnIndex == 8 || tablaprov.CurrentCell.ColumnIndex == 11 || tablaprov.CurrentCell.ColumnIndex == 16) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(tablaprov_KeyPress_1);
                }
            }
        }

        private void tablaprov_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Solo se Permiten Numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }



        private bool SoloNumeros(int fila, int columna)
        {
            decimal can = 0;
            try
            {
                if (tablaprov.Rows[fila].Cells[columna].Value != null)
                {
                    can = decimal.Parse(tablaprov.Rows[fila].Cells[columna].Value + "");
                    if (can < 0)
                        throw new FormatException();

                    if (can.ToString().Contains("."))
                    {
                        MessageBox.Show("Este producto no puede contarse en decimales.");
                        can = 0;
                        return false;
                    }
                }                        
            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                {
                    MessageBox.Show("No puedes tener letras");
                    return false;
                }
            }
            return true;
        }

        private void tablaprov_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            String nom = "";
            Label lab = new Label();
            bool ban = false;

            if (bandera == true)
            {
                //if (tablaprov.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                //{
                    switch (e.ColumnIndex)
                    {
                        case 1:
                        if (tablaprov.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                        {
                            nom = tablaprov.Rows[e.RowIndex].Cells[1].Value.ToString();
                            MessageBox.Show("El Nombre del Proveedor cambio por: " + nom);
                            prov.ActualizarProveedorPorCampos(long.Parse(tablaprov.CurrentRow.Cells[0].Value.ToString()), "Nombre", nom);
                        }
                        else
                        {
                            MessageBox.Show("No puedes dejar vacio el Nombre del Proveedor, el nombre no cambiara.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Llenar();                           
                        }
                        
                            break;
                        case 2:
                            if(tablaprov.Rows[e.RowIndex].Cells[2].Value !=null)
                            {
                                nom = tablaprov.Rows[e.RowIndex].Cells[2].Value.ToString();
                            }
                            MessageBox.Show("El nombre de la direccion cambio por: " + nom);
                            prov.ActualizarProveedorPorCampos(long.Parse(tablaprov.CurrentRow.Cells[0].Value.ToString()), "Direccion", nom);
                            break;
                        case 3:                        
                            if(tablaprov.Rows[e.RowIndex].Cells[3].Value != null)
                            {
                                nom = tablaprov.Rows[e.RowIndex].Cells[3].Value.ToString();
                            }                           
                            MessageBox.Show("El nombre de la Ciudad Cambio por: " + nom);
                            prov.ActualizarProveedorPorCampos(long.Parse(tablaprov.CurrentRow.Cells[0].Value.ToString()), "Ciudad", nom);
                            break;
                        case 4:
                            if(tablaprov.Rows[e.RowIndex].Cells[4].Value !=null)
                            {
                                nom = tablaprov.Rows[e.RowIndex].Cells[4].Value.ToString();
                            }
                        //nom = tablaprov.Rows[e.RowIndex].Cells[4].Value.ToString();
                            MessageBox.Show("El nombre del Estado Cambio por: " + nom);
                            prov.ActualizarProveedorPorCampos(long.Parse(tablaprov.CurrentRow.Cells[0].Value.ToString()), "Estado", nom);
                            break;
                        case 5:
                            //ban = SoloNumeros(e.RowIndex, e.ColumnIndex);
                            if (tablaprov.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                            {
                                //if (ban)
                                    nom = tablaprov.Rows[e.RowIndex].Cells[5].Value.ToString();
                            }
                            MessageBox.Show("El Telefono Cambio por: " + nom);
                            prov.ActualizarProveedorPorCampos(long.Parse(tablaprov.CurrentRow.Cells[0].Value.ToString()), "Telefono", nom);
                            //Llenar();
                            break;
                        case 6:
                            //ban = SoloNumeros(e.RowIndex, e.ColumnIndex);
                            if (tablaprov.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                            {
                                //if (ban)
                                nom = tablaprov.Rows[e.RowIndex].Cells[6].Value.ToString();
                            }                                
                            MessageBox.Show("Los dias de credito Cambiaron por: " + nom);
                            prov.ActualizarProveedorPorCampos(long.Parse(tablaprov.CurrentRow.Cells[0].Value.ToString()), "DiasCredito", nom);
                            //Llenar();
                            break;
                        case 7:
                            
                            if(tablaprov.Rows[e.RowIndex].Cells[e.ColumnIndex].Value!=null)
                            {
                                nom = tablaprov.Rows[e.RowIndex].Cells[7].Value.ToString();
                            }                                                                                   
                            MessageBox.Show("El Correo Electronico Cambio por: " + nom);
                            prov.ActualizarProveedorPorCampos(long.Parse(tablaprov.CurrentRow.Cells[0].Value.ToString()), "Correo", nom);
                            break;
                        case 8:
                            //ban = SoloNumeros(e.RowIndex, e.ColumnIndex);
                            if (tablaprov.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                            {
                                //if(ban)
                                nom = tablaprov.Rows[e.RowIndex].Cells[8].Value.ToString();
                            }                            
                            MessageBox.Show("El Limite de Credito Cambio por: " + nom);
                            prov.ActualizarProveedorPorCampos(long.Parse(tablaprov.CurrentRow.Cells[0].Value.ToString()), "LimiteCredito", nom);
                            //Llenar();
                            break;
                        //case 9:
                        //    nom = tablaprov.Rows[e.RowIndex].Cells[9].Value.ToString();
                        //    MessageBox.Show("Los Dias de Visita Cambiaron por: " + nom);
                        //    prov.ActualizarProveedorPorCampos(long.Parse(tablaprov.CurrentRow.Cells[0].Value.ToString()), "IDDiasVisita", nom);
                        //    break;
                        case 10:
                            if(tablaprov.Rows[e.RowIndex].Cells[10].Value !=null)
                            {
                                nom = tablaprov.Rows[e.RowIndex].Cells[10].Value.ToString();
                            }
                            MessageBox.Show("El RFC Cambio por: " + nom);
                            prov.ActualizarProveedorPorCampos(long.Parse(tablaprov.CurrentRow.Cells[0].Value.ToString()), "RFC", nom);
                            break;
                        case 11:
                            //ban = SoloNumeros(e.RowIndex, e.ColumnIndex);
                            if (tablaprov.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                            {
                                //if(ban)
                                nom = tablaprov.Rows[e.RowIndex].Cells[11].Value.ToString();
                            }                                
                            MessageBox.Show("El Telefono Celular Cambio por: " + nom);
                            prov.ActualizarProveedorPorCampos(long.Parse(tablaprov.CurrentRow.Cells[0].Value.ToString()), "Celular", nom);
                            //Llenar();
                            break;
                        //case 12:
                        //    nom = tablaprov.Rows[e.RowIndex].Cells[12].Value.ToString();
                        //    MessageBox.Show("La IDUsuario Cambio por: " + nom);
                        //    prov.ActualizarProveedorPorCampos(long.Parse(tablaprov.CurrentRow.Cells[0].Value.ToString()), "IDUsuario", nom);
                        //    break;
                        case 13:
                            if(tablaprov.Rows[e.RowIndex].Cells[e.ColumnIndex].Value !=null)
                            {
                                nom = tablaprov.Rows[e.RowIndex].Cells[13].Value.ToString();
                            }
                            //tablaprov.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();                                                                                        
                            MessageBox.Show("La Fecha de Usuario Cambio por: " + nom);
                            prov.ActualizarProveedorPorCampos(long.Parse(tablaprov.CurrentRow.Cells[0].Value.ToString()), "FechaUsuario", nom);
                            break;
                        //case 14:
                        //nom = tablaprov.Rows[e.RowIndex].Cells[14].Value.ToString();
                        //MessageBox.Show("El CP Cambio por: " + nom);
                        //prov.ActualizarProveedorPorCampos(long.Parse(tablaprov.CurrentRow.Cells[0].Value.ToString()), "Activo", nom);
                        //break;
                        case 15:
                            if(tablaprov.Rows[e.RowIndex].Cells[e.ColumnIndex].Value!=null)
                            {
                                nom = tablaprov.Rows[e.RowIndex].Cells[15].Value.ToString();
                            }
                        //tablaprov.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();             
                            MessageBox.Show("El Nombre de la Colonia Cambio por: " + nom);
                            prov.ActualizarProveedorPorCampos(long.Parse(tablaprov.CurrentRow.Cells[0].Value.ToString()), "Colonia", nom);
                            break;
                        case 16:
                          //ban = SoloNumeros(e.RowIndex, e.ColumnIndex);
                            if (tablaprov.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                            {
                                //if(ban)
                                nom = tablaprov.Rows[e.RowIndex].Cells[16].Value.ToString();
                            }                                
                            MessageBox.Show("El CP Cambio por: " + nom);
                            prov.ActualizarProveedorPorCampos(long.Parse(tablaprov.CurrentRow.Cells[0].Value.ToString()), "CP", nom);
                            //Llenar();
                            break;
                        case 17:
                            if(tablaprov.Rows[e.RowIndex].Cells[e.ColumnIndex].Value!=null)
                            {
                                nom = tablaprov.Rows[e.RowIndex].Cells[17].Value.ToString();
                            }
                        //tablaprov.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                            MessageBox.Show("El Nombre de la Poblacion Cambio por: " + nom);
                            prov.ActualizarProveedorPorCampos(long.Parse(tablaprov.CurrentRow.Cells[0].Value.ToString()), "Poblacion", nom);
                            break;
                    }
                //}
            }
        }

        private void Agreagr_Click(object sender, EventArgs e)
        {
            new ProveedorAgregar().ShowDialog();
            Llenar();
        }

        private void Letra(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(tablaprov_KeyPress);
            if (tablaprov.CurrentCell.ColumnIndex == 3 || tablaprov.CurrentCell.ColumnIndex == 4 || tablaprov.CurrentCell.ColumnIndex == 15 || tablaprov.CurrentCell.ColumnIndex == 17) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(tablaprov_KeyPress);
                }
            }
        }

        private void tablaprov_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 33 && e.KeyChar <= 64 || e.KeyChar >= 91 && e.KeyChar <= 96 || e.KeyChar >= 123 && e.KeyChar <= 255)
            {
                MessageBox.Show("Solo se Permiten Letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        
    }
}