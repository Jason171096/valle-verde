using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion.Inventario;

using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using Color = MigraDoc.DocumentObjectModel.Color;
using MigraDoc.DocumentObjectModel.Tables;
using Font = MigraDoc.DocumentObjectModel.Font;
using System.Diagnostics;
using Microsoft.Office.Core;
using System.Globalization;
using System.IO;

namespace ValleVerde
{
    public partial class AdministrarEntradasSalidas : Form
    {
        EntradasSalidas obj = new EntradasSalidas();
        ExportarTablaExcel exp = new ExportarTablaExcel();
        Button button = new Button();
        public AdministrarEntradasSalidas()
        {
            InitializeComponent();
            this.button.Click += new System.EventHandler(this.button_Click);
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvEntradasSalidas, true, false);
            //LlenarTabla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ValleVerdeComun.BuscarProducto(txtBuscar,button, false).ShowDialog(this);
        }

        private void button_Click(object sender, EventArgs e)
        {
            string nom = obj.ObtenerNombreProducto(txtBuscar.Text);
            labelCodigo.Text = txtBuscar.Text;
            labelDescripcion.Text = nom;
            //txtBuscar.Text = "";
        }

        private void toggleTodo_SliderValueChanged(object sender, EventArgs e)
        {
            //if (toggleTodo1.IsOn)
            //{
            //    toggleProducto.IsOn = false;
            //    toggleFecha.IsOn = false;
            //    LlenarTabla();
            //}
        }

        private void toggleFecha_SliderValueChanged(object sender, EventArgs e)
        {
            //if (toggleFecha.IsOn)
            //{
            //    dateinicio.Enabled = true;
            //    dateFin.Enabled = true;
            //    buttonMostrar.Enabled = true;
            //    toggleTodo1.IsOn = false;
            //}
            //else
            //{
            //    dateinicio.Enabled = false;
            //    dateFin.Enabled = false;
            //    buttonMostrar.Enabled = false;
            //}
        }

        private void toggleProducto_SliderValueChanged(object sender, EventArgs e)
        {
            if (toggleProducto.IsOn)
            {
                //toggleTodo1.IsOn = false;
                //toggleFecha.IsOn = true;
                //txtBuscar.Enabled = true;
                //button1.Enabled = true;
                toggleCompra.Visible = true;
                toggleVenta.Visible = true;
                labelCompra.Visible = true;
                labelVenta.Visible = true;
                labelDevolucion.Visible = true;
                toggleDevolucion.Visible = true;
            }
            else
            {
                txtBuscar.Text = "";
                //txtBuscar.Enabled = false;
                //button1.Enabled = false;
                toggleCompra.Visible = false;
                toggleVenta.Visible = false;
                labelCompra.Visible = false;
                labelVenta.Visible = false;
                labelDevolucion.Visible = false;
                toggleDevolucion.Visible = false;
            }
        }

        private void LlenarTabla()
        {
            DateTime fechaInicio = dateinicio.Value.Date;
            DateTime fechaFin = dateFin.Value.Date.AddDays(1).AddSeconds(-1);
            dgvEntradasSalidas.Rows.Clear();
            List<string[]> res = obj.ObtenerKardexProducto(toggleEntrada.IsOn,toggleSalida.IsOn,toggleCompra.IsOn,toggleVenta.IsOn,toggleDevolucion.IsOn,txtBuscar.Text,fechaInicio,fechaFin);

            foreach (string[] fila in res)
            {
                dgvEntradasSalidas.Rows.Add(fila[0], fila[1], fila[2], fila[3], fila[4], fila[5], fila[6], fila[9], fila[7], fila[8]);
            }
            dgvEntradasSalidas.ClearSelection();
        }

        private void toggleEntrada_SliderValueChanged(object sender, EventArgs e)
        {
            //if (toggleEntrada.IsOn == false)
            //{
            //    toggleTodo1.IsOn = false;
            //}
            //LlenarTabla();
        }

        private void toggleSalida_SliderValueChanged(object sender, EventArgs e)
        {
            //if (toggleSalida.IsOn == false)
            //{
            //    toggleTodo1.IsOn = false;
            //}
            //LlenarTabla();
        }

        private void buttonMostrar_Click(object sender, EventArgs e)
        {
            LlenarTabla();
            string nom = obj.ObtenerNombreProducto(txtBuscar.Text);
            labelCodigo.Text = txtBuscar.Text;
            labelDescripcion.Text = nom;
            //txtBuscar.Text = "";
        }

        private void toggleCompra_SliderValueChanged(object sender, EventArgs e)
        {
            //if (toggleCompra.IsOn)
            //{
            //    //LlenarTabla();
            //}
        }

        private void toggleVenta_SliderValueChanged(object sender, EventArgs e)
        {
            //LlenarTabla();
        }

        private void exportarExcel_Click(object sender, EventArgs e)
        {
            //exp.ExportarDataGridViewExcel(dgvEntradasSalidas);
            exp.GenerarExcel(dgvEntradasSalidas,2,-1);
        }

        private void botonPDF_Click(object sender, EventArgs e)
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

        public Document CreateDocument()
        {
            Document document = new Document();

            string fecha = DateTime.Now.ToString("dddd, dd/MM/yyyy HH:mm:ss");
            fecha = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(fecha);

            // Crear fuentes
            Font fueTit = new Font("Verdana", 18);
            fueTit.Bold = true;
            Font fueDoc = new Font("Verdana", 10);
            fueDoc.Bold = true;
            Font fueTab = new Font("Arial", 10);

            // Add a section to the document
            Section secCom = document.AddSection();
            // MessageBox.Show(secCom.PageSetup.PageFormat.ToString()); // = PageFormat.A4;
            secCom.PageSetup.PageFormat = PageFormat.Letter;
            secCom.PageSetup.TopMargin = 10;
            secCom.PageSetup.LeftMargin = 20;
            secCom.PageSetup.RightMargin = 0;
            secCom.PageSetup.BottomMargin = 50;


            // Añadir elementos a la seccion
            //string img = System.IO.Directory.GetCurrentDirectory();
            //System.Drawing.Image img = global::ValleVerde.Properties.Resources.LOGO;
            //img.Save();

            //string img = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Resources\\LOGO.png");
            //global::ValleVerde.Properties.Resources.LOGO);
            //System.Drawing.Image im = global::ValleVerde.Properties.Resources.LOGO;            
            MigraDoc.DocumentObjectModel.Shapes.Image image = secCom.AddImage("../../Resources/LOGO.png");
            //MigraDoc.DocumentObjectModel.Shapes.Image image = Properties.Resources.LOGO;
            //byte[] image1 = LoadImage("global::ValleVerde.Properties.Resources.LOGO.png");
            //string imageFilename = MigraDocFilenameFromByteArray(image1);

            //MigraDoc.DocumentObjectModel.Shapes.Image image = secCom.AddImage(imageFilename);
            image.Width = "4 cm";
            image.LockAspectRatio = true;

            Table tabDat = secCom.AddTable();

            secCom.AddParagraph();
            Table tab = secCom.AddTable();

            secCom.AddParagraph();
            Table foo = new Table();
            foo.AddColumn();
            foo.AddColumn();
            foo.AddRow();
            foo.Columns[0].Format.Alignment = ParagraphAlignment.Left;
            foo.Columns[1].Format.Alignment = ParagraphAlignment.Right;

            foo.Columns[0].Width = 472;
            foo.Columns[1].Width = 100;
            foo.Rows[0].Cells[0].AddParagraph("\tFecha: " + fecha);
            foo.Rows[0].Cells[1].AddParagraph().AddPageField();
            secCom.Footers.Primary.Add(foo.Clone());

            tabDat.AddColumn();
            tabDat.AddColumn();
            tabDat.AddRow();
            tabDat.AddRow();
            tabDat.AddRow();
            tabDat.Format.Font = fueDoc;

            tabDat.Columns[0].Width = 286;
            tabDat.Columns[1].Width = 286;

            tabDat.Columns[0].Format.Alignment = ParagraphAlignment.Left;
            tabDat.Columns[1].Format.Alignment = ParagraphAlignment.Left;
            tabDat.Rows[0].Cells[0].AddParagraph("");
            tabDat.Rows[0].Cells[1].AddParagraph("Fecha: " + fecha);
            tabDat.Rows[2].Cells[0].AddParagraph("\tCodigo Producto: \n\t" + labelCodigo.Text);
            tabDat.Rows[2].Cells[1].AddParagraph("Descripcion \n" + labelDescripcion.Text);
            tabDat.Format.Alignment = ParagraphAlignment.Center;


            for (int a = 0; a < dgvEntradasSalidas.ColumnCount; a++)
            {
                tab.AddColumn();
            }

            Row row = tab.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Shading.Color = Colors.PaleGreen;
            tab.Format.Font = fueTab;

                tab.Columns[0].Width = 80;
                tab.Columns[1].Width = 0;
                tab.Columns[2].Width = 0;
                //tab.Columns[2].Format.Alignment = ParagraphAlignment.Center;
                tab.Columns[3].Width = 65;
                tab.Columns[4].Width = 65;
                //tab.Columns[4].Format.Alignment = ParagraphAlignment.Right;
                tab.Columns[5].Width = 65;
                //tab.Columns[5].Format.Alignment = ParagraphAlignment.Center;
                tab.Columns[6].Width = 65;
                //tab.Columns[6].Format.Alignment = ParagraphAlignment.Right;
                tab.Columns[7].Width = 70;
                tab.Columns[8].Width = 55;
                tab.Columns[9].Width = 105;


            for (int b = 0; b < dgvEntradasSalidas.ColumnCount; b++)
            {
                if(b == 0 || b == 3 || b == 4 || b == 5 || b == 6 || b == 7 || b == 8 || b == 9)
                    row.Cells[b].AddParagraph(dgvEntradasSalidas.Columns[b].HeaderText);
            }

            tab.Borders.Color = Colors.Black;
            tab.Borders.Width = 0.25;
            tab.Rows.VerticalAlignment = VerticalAlignment.Center;

            for (int i = 0; i < dgvEntradasSalidas.RowCount; i++)
            {
                tab.AddRow();
                for (int j = 0; j < dgvEntradasSalidas.ColumnCount; j++)
                {
                    if (dgvEntradasSalidas.Rows[i].Cells[j].Value != null)
                    {
                        if (j == 0 || j == 3 || j == 4 || j == 5 || j == 6 || j == 7 || j == 8 || j == 9)
                            tab.Rows[i + 1].Cells[j].AddParagraph(dgvEntradasSalidas.Rows[i].Cells[j].Value.ToString());
                    }
                }
            }
            return document;
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button.PerformClick();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
