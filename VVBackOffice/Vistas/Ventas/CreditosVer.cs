using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion.Ventas;
using ValleVerde.Programacion.Compra;

using ValleVerde.Vistas.Ventas;
using System.Drawing.Printing;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using PdfSharp.Pdf.IO;
using System.Threading;

namespace ValleVerde
{
    public partial class CreditosVer : Form
    {
        CreditosClientes obj = new CreditosClientes();
        Vistas.Compras.QuitarCadenas objQuiCad = new Vistas.Compras.QuitarCadenas();


        string idCliente;
        string nombreCliente;

        string idUsuario;
        string nombreU;
        

        public CreditosVer(string IDCliente, string nombre, string idUsuario, string nombreU)
        {
            this.idCliente = IDCliente;
            this.nombreCliente = nombre;

            this.idUsuario = idUsuario;
            this.nombreU = nombreU;

            InitializeComponent();

            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvTicket, true, false);
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvNumTic, true, false);
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvAbonos, true, false);

        }

        private void CreditosVer_Load(object sender, EventArgs e)
        {
            tabCreditosClientes.Appearance = TabAppearance.FlatButtons;
            tabCreditosClientes.ItemSize = new Size(0, 1);
            tabCreditosClientes.SizeMode = TabSizeMode.Fixed;

            labelNombre.Text = nombreCliente;

            LlenaCredito();
        }

        public void LlenaCredito()
        {
            string[] credito = obj.ObtenerLimiteCredito(idCliente);
            if (credito[0] != "-1")
            {
                if (double.Parse(credito[2]) < 0)
                {
                    labelSaldoTotal.ForeColor = Color.LimeGreen;
                }
                labelSaldoTotal.Text = double.Parse(credito[2]).ToString("C2");
                labelLimite.Text = double.Parse(credito[0]).ToString("C2");
                labelCreditoRestante.Text = (double.Parse(credito[0]) - double.Parse(credito[2])).ToString("C2");
                labelDias.Text = credito[1];
                labelFechaHoy.Text = DateTime.Now.ToString("dd/MM/yyyy");

                radioButton1.Checked = true;
                togglePendientes.IsOn = true;
                LlenaTablaTicket(dateInicio.Value.Date, dateFin.Value.Date.AddDays(1).AddSeconds(-1), 0, togglePendientes.IsOn, radioFecha.Checked);
            }
            else
            {
                MessageBox.Show("El Cliente no tiene credito registrado");
                ClientesBuscar o = new ClientesBuscar();
                o.Show();
                this.Close();
            }
        }

        #region //Botones de la tab
        private void ventasCredito_Click(object sender, EventArgs e)
        {
            tabCreditosClientes.SelectedTab = tabPage1;
        }

        private void abonos_Click(object sender, EventArgs e)
        {
            tabCreditosClientes.SelectedTab = tabPage2;
            //validaTodas();
            LlenarAbonos();
        }
        #endregion

        private void LlenaTablaTicket(DateTime fechaInicio, DateTime fechaFin, int todas, bool pendiente, bool fecha)
        {
            int i = 0;
            float totcant = -1;
            dgvNumTic.Rows.Clear();
            
            List<string[]> res = obj.ObtenerVentasCredito(idCliente, fechaInicio, fechaFin, todas, pendiente, fecha);
            if (res.Count != 0)
            {
                foreach (string[] fila in res)
                {
                    string formatoFecha = DateTime.Parse(fila[1]).ToString("dddd, dd/MM/yyyy hh:mm:ss tt");

                    double Abono = double.Parse(fila[4]);
                    double Total = double.Parse(fila[5]);

                    dgvNumTic.Rows.Add(fila[0], CultureInfo.InvariantCulture.TextInfo.ToTitleCase(formatoFecha), fila[2], fila[3], Abono.ToString("C2"), Total.ToString("C2"));



                    if (fila[3] == "No")
                    {
                        dgvNumTic.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(244, 151, 23);

                    }
                    else
                    {
                        dgvNumTic.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                    }

                    List<string[]> auxDevueltos = obj.ObtenerProductosVenta(int.Parse(fila[0]));
                    foreach(string[] devuelto in auxDevueltos)
                    {
                        if (devuelto[7] != "")
                        {
                            float dev = float.Parse(devuelto[7]);
                            float cant = float.Parse(devuelto[4]);
                            totcant = cant - dev;
                        }                       
                    }
                    if (totcant == 0)
                    {
                        dgvNumTic.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                        totcant = -1;
                        if (togglePendientes.IsOn)
                        {
                            dgvNumTic.Rows.Remove(dgvNumTic.Rows[i]);
                            i = i-1;
                        }
                    }
                    i++;
                }
                dgvNumTic.ClearSelection();
            }
            else
            {
                MessageBox.Show("No tiene ventas a credito registradas");
            }
        }

        private void TicketCredito(int idcliente, int IDVenta)
        {
            int i = 0;
            float totcant = -1;
            dgvNumTic.Rows.Clear();

            List<string[]> res = obj.ObtenerTicketCredito(idcliente, IDVenta);
            if (res.Count != 0)
            {
                foreach (string[] fila in res)
                {
                    string formatoFecha = DateTime.Parse(fila[1]).ToString("dddd, dd/MM/yyyy hh:mm:ss tt");

                    double Abono = double.Parse(fila[4]);
                    double Total = double.Parse(fila[5]);

                    dgvNumTic.Rows.Add(fila[0], CultureInfo.InvariantCulture.TextInfo.ToTitleCase(formatoFecha), fila[2], fila[3], Abono.ToString("C2"), Total.ToString("C2"));



                    if (fila[3] == "No")
                    {
                        dgvNumTic.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(244, 151, 23);

                    }
                    else
                    {
                        dgvNumTic.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                    }

                    List<string[]> auxDevueltos = obj.ObtenerProductosVenta(int.Parse(fila[0]));
                    foreach (string[] devuelto in auxDevueltos)
                    {
                        if (devuelto[7] != "")
                        {
                            float dev = float.Parse(devuelto[7]);
                            float cant = float.Parse(devuelto[4]);
                            totcant = cant - dev;
                        }
                    }
                    if (totcant == 0)
                    {
                        dgvNumTic.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                        totcant = -1;
                        if (togglePendientes.IsOn)
                        {
                            dgvNumTic.Rows.Remove(dgvNumTic.Rows[i]);
                            i = i - 1;
                        }
                    }
                    i++;
                }
                dgvNumTic.ClearSelection();
            }
            else
            {
                MessageBox.Show("No tiene ventas a credito registradas");
            }
        }



        private void dgvNumTic_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            decimal nuevoValor;

            if (dgvNumTic.CurrentRow != null)
            {
                nombreCajero.Text = dgvNumTic.CurrentRow.Cells[2].Value.ToString();

                nuevoValor = decimal.Parse(objQuiCad.ObtenerCadenaLimpia(dgvNumTic.CurrentRow.Cells[4].Value + "", new string[] { "$", ",", "%" }));
                labelAbono.Text = nuevoValor.ToString("C2");
                float abonoaux = float.Parse(nuevoValor.ToString());

                int idVenta = int.Parse(dgvNumTic.CurrentRow.Cells[0].Value.ToString());
                LlenaTablaVenta(idVenta, abonoaux);
            }            
        }

        private void LlenaTablaVenta(int idVenta, float abono)
        {
            double totalVenta = 0;
            dgvTicket.Rows.Clear();
            List<string[]> res = obj.ObtenerProductosVenta(idVenta);

            foreach (string[] fila in res)
            {
                float cantidad = float.Parse(fila[4]);
                string unidad = fila[3];
                string descripcion = fila[2];
                float precio = float.Parse(fila[8]);
                double importe = double.Parse(fila[5]);

                if (fila[7] != "")
                {
                    float devuelto = float.Parse(fila[7]);
                    cantidad = cantidad - devuelto;
                    importe = cantidad * precio;
                }

                dgvTicket.Rows.Add(cantidad,unidad,descripcion,precio.ToString("C2"),importe.ToString("C2"));
                totalVenta += importe; 
            }
            labelSubTotal.Text = totalVenta.ToString("C2");
            labelTotal.Text = (totalVenta - abono).ToString("C");
            dgvTicket.ClearSelection();
        }

        private void radioFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFecha.Checked)
            {
                dateInicio.Enabled = true;
                dateFin.Enabled = true;                
            }
            else
            {
                dateInicio.Enabled = false;
                dateFin.Enabled = false;
            }
        }

        private void radioTodas_CheckedChanged(object sender, EventArgs e)
        {
            validaTodas();
        }

        private void validaTodas()
        {
            if (radioTodas.Checked)
            {
                dateInicio.Enabled = false;
                dateFin.Enabled = false;
                togglePendientes.IsOn = false;

                LlenaTablaTicket(dateInicio.Value.Date, dateFin.Value.Date.AddDays(1).AddSeconds(-1), 1, togglePendientes.IsOn, false);
            }
        }

        private void togglePendientes_Click(object sender, EventArgs e)
        {
            if (radioTodas.Checked)
            {
                radioTodas.Checked = false;
            }
            LlenaTablaTicket(dateInicio.Value.Date, dateFin.Value.Date.AddDays(1).AddSeconds(-1), 0, togglePendientes.IsOn, radioFecha.Checked); 
        }

        private void dateInicio_ValueChanged(object sender, EventArgs e)
        {
            LlenaTablaTicket(dateInicio.Value.Date, dateFin.Value.Date.AddDays(1).AddSeconds(-1), 0, togglePendientes.IsOn, radioFecha.Checked);
        }

        private void dateFin_ValueChanged(object sender, EventArgs e)
        {
            LlenaTablaTicket(dateInicio.Value.Date, dateFin.Value.Date.AddDays(1).AddSeconds(-1), 0, togglePendientes.IsOn, radioFecha.Checked);
        }

        private void roundedButton4_Click(object sender, EventArgs e)
        {
            Abonar o = new Abonar(nombreCliente, int.Parse(idCliente), 0, "", 0, labelSaldoTotal.Text, idUsuario, nombreU);
            o.ShowDialog();
            LlenaCredito();
        }

        private void pagarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                Abonar o = new Abonar(nombreCliente, int.Parse(idCliente), int.Parse(dgvNumTic.CurrentRow.Cells[0].Value.ToString()), labelTotal.Text, 1, labelSaldoTotal.Text, idUsuario, nombreU);
                o.ShowDialog();
                LlenaCredito();
            }
            catch (System.ObjectDisposedException) 
            {
                MessageBox.Show("Selseccione una Venta valida");
            }
        }

        private void abonarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                Abonar o = new Abonar(nombreCliente, int.Parse(idCliente), int.Parse(dgvNumTic.CurrentRow.Cells[0].Value.ToString()), labelTotal.Text, 2, labelSaldoTotal.Text, idUsuario, nombreU);
                o.ShowDialog();
                LlenaCredito();
            }
            catch (System.ObjectDisposedException) 
            {
                MessageBox.Show("Seleccione una Venta valida");
            }
        }

        //Tab 2 Abonos

        private void LlenarAbonos()
        {
            dgvAbonos.Rows.Clear();
            string fechaInicio = dateAbonoInicio.Value.Date.ToString("yyyy/MM/dd HH:mm:ss");
            string fechaFin = dateAbonoFin.Value.Date.AddDays(1).AddSeconds(-1).ToString("yyyy/MM/dd HH:mm:ss");
            List<string[]> res = obj.ObtenerAbonosCliente(int.Parse(idCliente), fechaInicio, fechaFin, radioButton1.Checked);

            foreach (string[] fila in res)
            {
                string formatoFecha = DateTime.Parse(fila[1]).ToString("dddd, dd/MM/yyyy HH:mm:ss");
                dgvAbonos.Rows.Add(fila[5],double.Parse(fila[0]).ToString("C2"), CultureInfo.InvariantCulture.TextInfo.ToTitleCase(formatoFecha), fila[2], fila[3], fila[4]);
            }
            dgvAbonos.ClearSelection();
        }

        private void TicketAbonos(int idcliente, int IDVenta)
        {
            dgvAbonos.Rows.Clear();
            string fechaInicio = dateAbonoInicio.Value.Date.ToString("yyyy/MM/dd HH:mm:ss");
            string fechaFin = dateAbonoFin.Value.Date.AddDays(1).AddSeconds(-1).ToString("yyyy/MM/dd HH:mm:ss");
            List<string[]> res = obj.ObtenerAbonosTicket(idcliente, IDVenta);

            foreach (string[] fila in res)
            {
                string formatoFecha = DateTime.Parse(fila[1]).ToString("dddd, dd/MM/yyyy HH:mm:ss");
                dgvAbonos.Rows.Add(fila[5], double.Parse(fila[0]).ToString("C2"), CultureInfo.InvariantCulture.TextInfo.ToTitleCase(formatoFecha), fila[2], fila[3], fila[4]);
            }
            dgvAbonos.ClearSelection();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                dateAbonoInicio.Enabled = false;
                dateAbonoFin.Enabled = false;
                LlenarAbonos();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                dateAbonoInicio.Enabled = true;
                dateAbonoFin.Enabled = true;
            }
        }

        private void dateAbonoInicio_ValueChanged(object sender, EventArgs e)
        {
            LlenarAbonos();
        }

        private void dateAbonoFin_ValueChanged(object sender, EventArgs e)
        {
            LlenarAbonos();
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void roundedButton1_Click(object sender, EventArgs e) //guarda 2 tablas en el pdf
        {
            GeneraPDF(dgvNumTic, null, dgvAbonos, false);
        }
        private void roundedButton3_Click(object sender, EventArgs e) // imprime 2 tablas 
        {
            GeneraPDF(dgvNumTic, null, dgvAbonos, true);
        }

        private void roundedButton2_Click(object sender, EventArgs e) //guarda 3 tablas en el pdf
        {
            if (dgvNumTic.CurrentRow != null)
            {
                string idVenta = dgvNumTic.CurrentRow.Cells[0].Value.ToString();

                TicketAbonos(int.Parse(idCliente), int.Parse(idVenta));
                TicketCredito(int.Parse(idCliente), int.Parse(idVenta));
            }

            GeneraPDF(dgvNumTic, dgvTicket, dgvAbonos, false);
            int milliseconds = 3000;
            Thread.Sleep(milliseconds);
            LlenaTablaTicket(dateInicio.Value.Date, dateFin.Value.Date.AddDays(1).AddSeconds(-1), 0, togglePendientes.IsOn, radioFecha.Checked);
            LlenarAbonos();
        }

        private void roundedButton5_Click(object sender, EventArgs e) // imprime 3 tablas 
        {
            if (dgvNumTic.CurrentRow != null)
            {
                string idVenta = dgvNumTic.CurrentRow.Cells[0].Value.ToString();

                TicketAbonos(int.Parse(idCliente), int.Parse(idVenta));
                TicketCredito(int.Parse(idCliente), int.Parse(idVenta));
            }

            GeneraPDF(dgvNumTic, dgvTicket, dgvAbonos, true);
            int milliseconds = 3000;
            Thread.Sleep(milliseconds);
            LlenaTablaTicket(dateInicio.Value.Date, dateFin.Value.Date.AddDays(1).AddSeconds(-1), 0, togglePendientes.IsOn, radioFecha.Checked);
            LlenarAbonos();
        }

        //public void Creapdf(DataGridView dgv1, DataGridView dgv2, DataGridView dgv3)
        //{
        //    if (dgv1.Rows.Count > 0)
        //    {
        //        SaveFileDialog sfd = new SaveFileDialog();
        //        sfd.Filter = "PDF (*.pdf)|*.pdf";
        //        sfd.FileName = "VentaCredito_" + labelNombre.Text + ".pdf";
        //        bool fileError = false;
        //        if (sfd.ShowDialog() == DialogResult.OK)
        //        {
        //            if (File.Exists(sfd.FileName))
        //            {
        //                try
        //                {
        //                    File.Delete(sfd.FileName);
        //                }
        //                catch (IOException ex)
        //                {
        //                    fileError = true;
        //                    MessageBox.Show("No fue posible escribir los datos" + ex.Message);
        //                }
        //            }
        //            if (!fileError)
        //            {
        //                try
        //                {
        //                    //bold font 
        //                    BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
        //                    iTextSharp.text.Font b1 = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
        //                    //bold font

        //                    //bold font 
        //                    BaseFont bf2 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
        //                    iTextSharp.text.Font bsal = new iTextSharp.text.Font(bf2, 16, iTextSharp.text.Font.BOLD, BaseColor.RED);
        //                    //bold font


        //                    //  font emisor/cliente
        //                    BaseFont a1 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
        //                    iTextSharp.text.Font a2 = new iTextSharp.text.Font(a1, 10);
        //                    BaseFont bft = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
        //                    iTextSharp.text.Font b2 = new iTextSharp.text.Font(bft, 10, iTextSharp.text.Font.BOLD);
        //                    //

        //                    //Salto de linea
        //                    Paragraph line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

        //                    //Encabezado
        //                    Chunk chunk = new Chunk("Ventas a Crédito      " + labelNombre.Text + "         " +
        //                                            " " + DateTime.Now + "     ");

        //                    //linea ticket
        //                    Paragraph lineTicket = new Paragraph("Ticket\n", b1);
        //                    lineTicket.Alignment = Element.ALIGN_LEFT;

        //                    //Linea productos
        //                    Paragraph lineProd = new Paragraph("Productos\n", b1);
        //                    lineProd.Alignment = Element.ALIGN_LEFT;

        //                    //Linea Abonos
        //                    Paragraph lineAbonos = new Paragraph("Abonos\n", b1);
        //                    lineProd.Alignment = Element.ALIGN_LEFT;

        //                    //Tabla encabezado
        //                    PdfPTable tablet1 = new PdfPTable(3);
        //                    tablet1.WidthPercentage = 100;
        //                    tablet1.HorizontalAlignment = 0;
        //                    tablet1.SpacingBefore = 20f;
        //                    tablet1.SpacingAfter = 30f;

        //                    //Cell 1 Imagen
        //                    PdfPCell cellt1 = new PdfPCell();
        //                    cellt1.Border = 0;
        //                    iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(Properties.Resources.LOGO, System.Drawing.Imaging.ImageFormat.Png);
        //                    imagen.BorderWidth = 0;
        //                    imagen.Alignment = Element.ALIGN_LEFT;
        //                    float percentage = 0.0f;
        //                    percentage = 150 / imagen.Width;
        //                    imagen.ScalePercent(percentage * 100);
        //                    //imagen.ScaleAbsolute(200, 150);
        //                    cellt1.AddElement(imagen);
        //                    tablet1.AddCell(cellt1);

        //                    //Cell 2 Datos emisor
        //                    Paragraph nomb = new Paragraph("Abarrotes y Licores Valle Verde S. de R.L. de C.V.", b2);
        //                    Paragraph dir = new Paragraph("Madero 100 Valle Verde, CP: 59940, Cotija, MICHOACAN DE OCAMPO, México\n", a2);

        //                    Chunk tel = new Chunk("Tel: ", b2);
        //                    Chunk tel1 = new Chunk("3541236693", a2);
        //                    Phrase p2 = new Phrase();
        //                    p2.Add(tel);
        //                    p2.Add(tel1);

        //                    cellt1 = new PdfPCell();
        //                    cellt1.Border = 0;
        //                    cellt1.AddElement(nomb);
        //                    cellt1.AddElement(dir);
        //                    cellt1.AddElement(p2);

        //                    tablet1.AddCell(cellt1);


        //                    //Cell 3 Datos Cliente
        //                    Paragraph clie = new Paragraph("Cliente", b2);
        //                    Paragraph nomcli = new Paragraph(labelNombre.Text, a2);

        //                    Chunk fecha = new Chunk("Fecha:  ", b2);
        //                    Chunk fecha1 = new Chunk(DateTime.Now.ToString(), a2);
        //                    Phrase pc1 = new Phrase();
        //                    pc1.Add(fecha);
        //                    pc1.Add(fecha1);

        //                    Phrase pc2 = new Phrase();
        //                    Chunk Saldo = new Chunk("\nSaldo a Pagar: \n", b1);
        //                    Chunk Saldo1 = new Chunk(labelSaldoTotal.Text, bsal);
        //                    pc2.Add(Saldo);
        //                    pc2.Add(Saldo1);

        //                    cellt1 = new PdfPCell();
        //                    cellt1.Border = 0;
        //                    cellt1.AddElement(clie);
        //                    cellt1.AddElement(nomcli);
        //                    cellt1.AddElement(pc1);
        //                    cellt1.AddElement(pc2);

        //                    tablet1.AddCell(cellt1);

        //                    //Tabla Ticket dgv1
        //                    PdfPTable pdfTable = new PdfPTable(dgv1.Columns.Count);
        //                    pdfTable.DefaultCell.Padding = 3;
        //                    pdfTable.WidthPercentage = 100;
        //                    pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

        //                    foreach (DataGridViewColumn column in dgv1.Columns)
        //                    {
        //                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, b1));
        //                        pdfTable.AddCell(cell);
        //                    }

        //                    foreach (DataGridViewRow row in dgv1.Rows)
        //                    {
        //                        foreach (DataGridViewCell cell in row.Cells)
        //                        {
        //                            pdfTable.AddCell(cell.Value.ToString());
        //                        }
        //                    }

        //                    //Tabla detalle Productos

        //                    PdfPTable pdfTable2 = new PdfPTable(dgv2.Columns.Count);
        //                    pdfTable2.DefaultCell.Padding = 3;
        //                    pdfTable2.WidthPercentage = 100;
        //                    pdfTable2.HorizontalAlignment = Element.ALIGN_LEFT;
        //                    float[] values = new float[5];
        //                    values[0] = 50;
        //                    values[1] = 50;
        //                    values[2] = 140;
        //                    values[3] = 70;
        //                    values[4] = 70;
        //                    pdfTable2.SetWidths(values);
        //                    foreach (DataGridViewColumn column in dgv2.Columns)
        //                    {
        //                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, b1));
        //                        pdfTable2.AddCell(cell);
        //                    }

        //                    foreach (DataGridViewRow row in dgv2.Rows)
        //                    {
        //                        foreach (DataGridViewCell cell in row.Cells)
        //                        {
        //                            pdfTable2.AddCell(cell.Value.ToString());
        //                        }
        //                    }

        //                    //Tabla detalle Abono
        //                    PdfPTable pdfTable3 = null;
        //                    if (dgv3 != null)
        //                    {
        //                        pdfTable3 = new PdfPTable(dgv3.Columns.Count);
        //                        pdfTable3.DefaultCell.Padding = 3;
        //                        pdfTable3.WidthPercentage = 100;
        //                        pdfTable3.HorizontalAlignment = Element.ALIGN_LEFT;

        //                        foreach (DataGridViewColumn column in dgv3.Columns)
        //                        {
        //                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, b1));
        //                            pdfTable3.AddCell(cell);
        //                        }

        //                        foreach (DataGridViewRow row in dgv3.Rows)
        //                        {
        //                            foreach (DataGridViewCell cell in row.Cells)
        //                            {
        //                                pdfTable3.AddCell(cell.Value.ToString());
        //                            }
        //                        }
        //                    }

        //                    using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
        //                    {
        //                        Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
        //                        PdfWriter.GetInstance(pdfDoc, stream);
        //                        pdfDoc.Open();
        //                        pdfDoc.Add(chunk);
        //                        pdfDoc.Add(tablet1);
        //                        pdfDoc.Add(lineTicket);
        //                        pdfDoc.Add(line);

        //                        pdfDoc.Add(pdfTable);
        //                        pdfDoc.Add(lineProd);
        //                        pdfDoc.Add(line);
        //                        pdfDoc.Add(pdfTable2);
        //                        if (dgv3 != null)
        //                        {
        //                            pdfDoc.Add(lineAbonos);
        //                            pdfDoc.Add(line);
        //                            pdfDoc.Add(pdfTable3);
        //                        }
        //                        pdfDoc.AddCreator("GS");
        //                        pdfDoc.Close();
        //                        stream.Close();
        //                    }
        //                    Process process = Process.Start(sfd.FileName);

        //                    //MessageBox.Show("¡Datos exportados correctamente!", "Inforacion");
        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show("Error :" + ex.Message);
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("¡No hay ningún registro para exportar!", "Información");
        //    }
        //}

        //public void Imprime(DataGridView dgv1, DataGridView dgv2, DataGridView dgv3)
        //{
        //    if (dgv1.Rows.Count > 0)
        //    {
        //        bool fileError = false;

        //        if (!fileError)
        //        {
        //            try
        //            {
        //                //bold font 
        //                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
        //                iTextSharp.text.Font b1 = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
        //                //bold font

        //                //bold font 
        //                BaseFont bf2 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
        //                iTextSharp.text.Font bsal = new iTextSharp.text.Font(bf2, 16, iTextSharp.text.Font.BOLD, BaseColor.RED);
        //                //bold font


        //                //  font emisor/cliente
        //                BaseFont a1 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
        //                iTextSharp.text.Font a2 = new iTextSharp.text.Font(a1, 10);
        //                BaseFont bft = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
        //                iTextSharp.text.Font b2 = new iTextSharp.text.Font(bft, 10, iTextSharp.text.Font.BOLD);
        //                //

        //                //Salto de linea
        //                Paragraph line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

        //                //Encabezado
        //                Chunk chunk = new Chunk("Ventas a Crédito      " + labelNombre.Text + "         " +
        //                                        " " + DateTime.Now + "     ");

        //                //linea ticket
        //                Paragraph lineTicket = new Paragraph("Ticket\n", b1);
        //                lineTicket.Alignment = Element.ALIGN_LEFT;

        //                //Linea productos
        //                Paragraph lineProd = new Paragraph("Productos\n", b1);
        //                lineProd.Alignment = Element.ALIGN_LEFT;

        //                //Linea Abonos
        //                Paragraph lineAbonos = new Paragraph("Abonos\n", b1);
        //                lineProd.Alignment = Element.ALIGN_LEFT;

        //                //Tabla encabezado
        //                PdfPTable tablet1 = new PdfPTable(3);
        //                tablet1.WidthPercentage = 100;
        //                tablet1.HorizontalAlignment = 0;
        //                tablet1.SpacingBefore = 20f;
        //                tablet1.SpacingAfter = 30f;

        //                //Cell 1 Imagen
        //                PdfPCell cellt1 = new PdfPCell();
        //                cellt1.Border = 0;
        //                iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(Properties.Resources.LOGO, System.Drawing.Imaging.ImageFormat.Png);
        //                imagen.BorderWidth = 0;
        //                imagen.Alignment = Element.ALIGN_LEFT;
        //                float percentage = 0.0f;
        //                percentage = 150 / imagen.Width;
        //                imagen.ScalePercent(percentage * 100);
        //                //imagen.ScaleAbsolute(200, 150);
        //                cellt1.AddElement(imagen);
        //                tablet1.AddCell(cellt1);

        //                //Cell 2 Datos emisor
        //                Paragraph nomb = new Paragraph("Abarrotes y Licores Valle Verde S. de R.L. de C.V.", b2);
        //                Paragraph dir = new Paragraph("Madero 100 Valle Verde, CP: 59940, Cotija, MICHOACAN DE OCAMPO, México\n", a2);

        //                Chunk tel = new Chunk("Tel: ", b2);
        //                Chunk tel1 = new Chunk("3541236693", a2);
        //                Phrase p2 = new Phrase();
        //                p2.Add(tel);
        //                p2.Add(tel1);

        //                cellt1 = new PdfPCell();
        //                cellt1.Border = 0;
        //                cellt1.AddElement(nomb);
        //                cellt1.AddElement(dir);
        //                cellt1.AddElement(p2);

        //                tablet1.AddCell(cellt1);


        //                //Cell 3 Datos Cliente
        //                Paragraph clie = new Paragraph("Cliente", b2);
        //                Paragraph nomcli = new Paragraph(labelNombre.Text, a2);

        //                Chunk fecha = new Chunk("Fecha:  ", b2);
        //                Chunk fecha1 = new Chunk(DateTime.Now.ToString(), a2);
        //                Phrase pc1 = new Phrase();
        //                pc1.Add(fecha);
        //                pc1.Add(fecha1);

        //                Phrase pc2 = new Phrase();
        //                Chunk Saldo = new Chunk("\nSaldo a Pagar: \n", b1);
        //                Chunk Saldo1 = new Chunk(labelSaldoTotal.Text, bsal);
        //                pc2.Add(Saldo);
        //                pc2.Add(Saldo1);

        //                cellt1 = new PdfPCell();
        //                cellt1.Border = 0;
        //                cellt1.AddElement(clie);
        //                cellt1.AddElement(nomcli);
        //                cellt1.AddElement(pc1);
        //                cellt1.AddElement(pc2);

        //                tablet1.AddCell(cellt1);

        //                //Tabla Ticket dgv1
        //                PdfPTable pdfTable = new PdfPTable(dgv1.Columns.Count);
        //                pdfTable.DefaultCell.Padding = 3;
        //                pdfTable.WidthPercentage = 100;
        //                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

        //                foreach (DataGridViewColumn column in dgv1.Columns)
        //                {
        //                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, b1));
        //                    pdfTable.AddCell(cell);
        //                }

        //                foreach (DataGridViewRow row in dgv1.Rows)
        //                {
        //                    foreach (DataGridViewCell cell in row.Cells)
        //                    {
        //                        pdfTable.AddCell(cell.Value.ToString());
        //                    }
        //                }

        //                //Tabla detalle Productos

        //                PdfPTable pdfTable2 = new PdfPTable(dgv2.Columns.Count);
        //                pdfTable2.DefaultCell.Padding = 3;
        //                pdfTable2.WidthPercentage = 100;
        //                pdfTable2.HorizontalAlignment = Element.ALIGN_LEFT;
        //                float[] values = new float[5];
        //                values[0] = 50;
        //                values[1] = 50;
        //                values[2] = 140;
        //                values[3] = 70;
        //                values[4] = 70;
        //                pdfTable2.SetWidths(values);
        //                foreach (DataGridViewColumn column in dgv2.Columns)
        //                {
        //                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, b1));
        //                    pdfTable2.AddCell(cell);
        //                }

        //                foreach (DataGridViewRow row in dgv2.Rows)
        //                {
        //                    foreach (DataGridViewCell cell in row.Cells)
        //                    {
        //                        pdfTable2.AddCell(cell.Value.ToString());
        //                    }
        //                }

        //                //Tabla detalle Abono
        //                PdfPTable pdfTable3 = null;
        //                if (dgv3 != null)
        //                {
        //                    pdfTable3 = new PdfPTable(dgv3.Columns.Count);
        //                    pdfTable3.DefaultCell.Padding = 3;
        //                    pdfTable3.WidthPercentage = 100;
        //                    pdfTable3.HorizontalAlignment = Element.ALIGN_LEFT;

        //                    foreach (DataGridViewColumn column in dgv3.Columns)
        //                    {
        //                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, b1));
        //                        pdfTable3.AddCell(cell);
        //                    }

        //                    foreach (DataGridViewRow row in dgv3.Rows)
        //                    {
        //                        foreach (DataGridViewCell cell in row.Cells)
        //                        {
        //                            pdfTable3.AddCell(cell.Value.ToString());
        //                        }
        //                    }
        //                }


        //                using (MemoryStream myMemoryStream = new MemoryStream())
        //                {
        //                    string newFile = "output.pdf";
        //                    Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
        //                    PdfWriter myPDFWriter = PdfWriter.GetInstance(pdfDoc, myMemoryStream);

        //                    pdfDoc.Open();
        //                    pdfDoc.Add(chunk);
        //                    pdfDoc.Add(tablet1);
        //                    pdfDoc.Add(lineTicket);
        //                    pdfDoc.Add(line);

        //                    pdfDoc.Add(pdfTable);
        //                    pdfDoc.Add(lineProd);
        //                    pdfDoc.Add(line);
        //                    pdfDoc.Add(pdfTable2);
        //                    if (dgv3 != null)
        //                    {
        //                        pdfDoc.Add(lineAbonos);
        //                        pdfDoc.Add(line);
        //                        pdfDoc.Add(pdfTable3);
        //                    }
        //                    pdfDoc.AddCreator("GS");
        //                    pdfDoc.Close();

        //                    byte[] content = myMemoryStream.ToArray();
        //                    using (FileStream fs = File.Create(newFile))
        //                    {
        //                        fs.Write(content, 0, (int)content.Length);
        //                    }
        //                    //Process process = Process.Start(newFile);

        //                    ProcessStartInfo psi = new ProcessStartInfo();
        //                    psi.UseShellExecute = true;
        //                    psi.Verb = "print";
        //                    psi.FileName = "output.pdf";
        //                    psi.WindowStyle = ProcessWindowStyle.Hidden;
        //                    psi.ErrorDialog = false;
        //                    psi.Arguments = "/p";
        //                    Process p = Process.Start(psi);
        //                    p.WaitForInputIdle();


        //                }

        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show("Error :" + ex.Message);
        //            }
        //        }
        //    }
        //}

        public void GeneraPDF(DataGridView dgv1, DataGridView dgv2, DataGridView dgv3, bool print)
        {
            //table font 
            BaseFont tf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            iTextSharp.text.Font t1 = new iTextSharp.text.Font(tf, 12);
            //boltabled font

            //bold font 
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            iTextSharp.text.Font b1 = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
            //bold font

            //bold font 
            BaseFont bf2 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            iTextSharp.text.Font bsal = new iTextSharp.text.Font(bf2, 16, iTextSharp.text.Font.BOLD, BaseColor.RED);
            //bold font

            //font emisor/cliente
            BaseFont a1 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            iTextSharp.text.Font a2 = new iTextSharp.text.Font(a1, 10);
            BaseFont bft = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            iTextSharp.text.Font b2 = new iTextSharp.text.Font(bft, 10, iTextSharp.text.Font.BOLD);
            //font emisor/cliente

            //Salto de linea
            Paragraph line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

            //Encabezado
            Chunk chunk = new Chunk("Ventas a Crédito      " + labelNombre.Text + "         " +
                                        " " + DateTime.Now + "     ");
            //linea ticket
            Paragraph lineTicket = new Paragraph("Ticket\n", b1);
            lineTicket.Alignment = Element.ALIGN_LEFT;

            //Linea productos
            Paragraph lineProd = new Paragraph("Productos\n", b1);
            lineProd.Alignment = Element.ALIGN_LEFT;

            //Linea Abonos
            Paragraph lineAbonos = new Paragraph("Abonos\n", b1);
            lineProd.Alignment = Element.ALIGN_LEFT;

            //Tabla encabezado
            PdfPTable tablet1 = new PdfPTable(3);
            tablet1.WidthPercentage = 100;
            tablet1.HorizontalAlignment = 0;
            tablet1.SpacingBefore = 20f;
            tablet1.SpacingAfter = 30f;

            //Cell 1 Imagen
            PdfPCell cellt1 = new PdfPCell();
            cellt1.Border = 0;
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(Properties.Resources.LOGO, System.Drawing.Imaging.ImageFormat.Png);
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_LEFT;
            float percentage = 0.0f;
            percentage = 150 / imagen.Width;
            imagen.ScalePercent(percentage * 100);
            //imagen.ScaleAbsolute(200, 150);
            cellt1.AddElement(imagen);
            tablet1.AddCell(cellt1);

            //Cell 2 Datos emisor
            Paragraph nomb = new Paragraph("Abarrotes y Licores Valle Verde S. de R.L. de C.V.", b2);
            Paragraph dir = new Paragraph("Madero 100 Valle Verde, CP: 59940, Cotija, MICHOACAN DE OCAMPO, México\n", a2);

            Chunk tel = new Chunk("Tel: ", b2);
            Chunk tel1 = new Chunk("3541236693", a2);
            Phrase p2 = new Phrase();
            p2.Add(tel);
            p2.Add(tel1);
            
            cellt1 = new PdfPCell();
            cellt1.Border = 0;
            cellt1.AddElement(nomb);
            cellt1.AddElement(dir);
            cellt1.AddElement(p2);

            tablet1.AddCell(cellt1);

            //Cell 3 Datos Cliente
            Paragraph clie = new Paragraph("Cliente", b2);
            Paragraph nomcli = new Paragraph(labelNombre.Text, a2);

            Chunk fecha = new Chunk("Fecha:  ", b2);
            Chunk fecha1 = new Chunk(DateTime.Now.ToString(), a2);
            Phrase pc1 = new Phrase();
            pc1.Add(fecha);
            pc1.Add(fecha1);

            Phrase pc2 = new Phrase();
            Chunk Saldo = new Chunk("\nSaldo Total a Pagar: \n", b1);
            Chunk Saldo1 = new Chunk(labelSaldoTotal.Text, bsal);
            pc2.Add(Saldo);
            pc2.Add(Saldo1);

            Phrase pc3 = null;
            if (dgv2 != null)
            {
                pc3 = new Phrase();
                Chunk SubSaldo = new Chunk("\n\nSaldo De Ticket: \n", b1);
                Chunk SubSaldo1 = new Chunk(labelTotal.Text, bsal);
                pc2.Add(SubSaldo);
                pc2.Add(SubSaldo1);
            }

            cellt1 = new PdfPCell();
            cellt1.Border = 0;
            cellt1.AddElement(clie);
            cellt1.AddElement(nomcli);
            cellt1.AddElement(pc1);
            cellt1.AddElement(pc2);
           
            if (dgv2 != null)
            {
                cellt1.AddElement(pc3);
            }

            tablet1.AddCell(cellt1);

            //Tabla Ticket dgv1
            PdfPTable pdfTable = new PdfPTable(dgv1.Columns.Count);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            float[] values = new float[6];
            values[0] = 50;
            values[1] = 140;
            values[2] = 70;
            values[3] = 40;
            values[4] = 70;
            values[5] = 70;
            pdfTable.SetWidths(values);

            foreach (DataGridViewColumn column in dgv1.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, b1));
                pdfTable.AddCell(cell);
            }

            foreach (DataGridViewRow row in dgv1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    //pdfTable.AddCell(cell.Value.ToString());
                    pdfTable.AddCell(new PdfPCell(new Phrase(cell.Value.ToString(), FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9))));
                }
            }

            //Tabla detalle Productos
            PdfPTable pdfTable2 = null;
            if(dgv2 !=null)
            {
                pdfTable2 = new PdfPTable(dgv2.Columns.Count);
                //PdfPTable pdfTable2 = new PdfPTable(dgv2.Columns.Count);
                pdfTable2.DefaultCell.Padding = 3;
                pdfTable2.WidthPercentage = 100;
                pdfTable2.HorizontalAlignment = Element.ALIGN_LEFT;
                float[] values2 = new float[5];
                values2[0] = 50;
                values2[1] = 50;
                values2[2] = 140;
                values2[3] = 70;
                values2[4] = 70;
                pdfTable2.SetWidths(values2);

                foreach (DataGridViewColumn column in dgv2.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, b1));
                    pdfTable2.AddCell(cell);
                }

                foreach (DataGridViewRow row in dgv2.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        pdfTable2.AddCell(new PdfPCell(new Phrase(cell.Value.ToString(), FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9))));

                    }
                }
            }

            //Tabla detalle Abono
            PdfPTable pdfTable3 = null;
            if (dgv3 != null)
            {
                pdfTable3 = new PdfPTable(dgv3.Columns.Count);
                pdfTable3.DefaultCell.Padding = 3;
                pdfTable3.WidthPercentage = 100;
                pdfTable3.HorizontalAlignment = Element.ALIGN_LEFT;
                float[] values3 = new float[6];
                values3[0] = 50;
                values3[1] = 70;
                values3[2] = 140;
                values3[3] = 50;
                values3[4] = 100;
                values3[5] = 50;
                pdfTable3.SetWidths(values3);

                foreach (DataGridViewColumn column in dgv3.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, b1));
                    pdfTable3.AddCell(cell);
                }

                foreach (DataGridViewRow row in dgv3.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        pdfTable3.AddCell(new PdfPCell(new Phrase(cell.Value.ToString(), FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9))));
                    }
                }
            }

            //Imprime o guarda PDF
            if (print) //imprime PDF
            {
                if (dgv1.Rows.Count > 0)
                {
                    bool fileError = false;

                    if (!fileError)
                    {
                        try
                        {
                            using (MemoryStream myMemoryStream = new MemoryStream())
                            {
                                string newFile = "output.pdf";
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter myPDFWriter = PdfWriter.GetInstance(pdfDoc, myMemoryStream);

                                pdfDoc.Open();
                                pdfDoc.Add(chunk);
                                pdfDoc.Add(tablet1);
                                pdfDoc.Add(lineTicket);
                                pdfDoc.Add(line);

                                pdfDoc.Add(pdfTable);
                                if (dgv2!=null)
                                {
                                    pdfDoc.Add(lineProd);
                                    pdfDoc.Add(line);
                                    pdfDoc.Add(pdfTable2);
                                }
                                if (dgv3 != null)
                                {
                                    pdfDoc.Add(lineAbonos);
                                    pdfDoc.Add(line);
                                    pdfDoc.Add(pdfTable3);
                                }
                                pdfDoc.AddCreator("GS");
                                pdfDoc.Close();

                                byte[] content = myMemoryStream.ToArray();
                                using (FileStream fs = File.Create(newFile))
                                {
                                    fs.Write(content, 0, (int)content.Length);
                                }
                                //Process process = Process.Start(newFile);

                                ProcessStartInfo psi = new ProcessStartInfo();
                                psi.UseShellExecute = true;
                                psi.Verb = "print";
                                psi.FileName = "output.pdf";
                                psi.WindowStyle = ProcessWindowStyle.Hidden;
                                psi.ErrorDialog = false;
                                psi.Arguments = "/p";
                                Process p = Process.Start(psi);
                                p.WaitForInputIdle();
                            }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error :" + ex.Message);
                    }
                }
            }
        }
            else // Solicita ruta para guardar PDF
            {
                if (dgv1.Rows.Count > 0)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "PDF (*.pdf)|*.pdf";
                    sfd.FileName = "VentaCredito_" + labelNombre.Text + ".pdf";
                    bool fileError = false;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(sfd.FileName))
                        {
                            try
                            {
                                File.Delete(sfd.FileName);
                            }
                            catch (IOException ex)
                            {
                                fileError = true;
                                MessageBox.Show("No fue posible escribir los datos" + ex.Message);
                            }
                        }
                        if (!fileError)
                        {
                            try
                            {
                                using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                                {
                                    Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                    PdfWriter.GetInstance(pdfDoc, stream);
                                    pdfDoc.Open();
                                    pdfDoc.Add(chunk);
                                    pdfDoc.Add(tablet1);
                                    pdfDoc.Add(lineTicket);
                                    pdfDoc.Add(line);

                                    pdfDoc.Add(pdfTable);
                                    if (dgv2 != null)
                                    {
                                        pdfDoc.Add(lineProd);
                                        pdfDoc.Add(line);
                                        pdfDoc.Add(pdfTable2);
                                    }
                                    if (dgv3 != null)
                                    {
                                        pdfDoc.Add(lineAbonos);
                                        pdfDoc.Add(line);
                                        pdfDoc.Add(pdfTable3);
                                    }
                                    pdfDoc.AddCreator("GS");
                                    pdfDoc.Close();
                                    stream.Close();
                                }
                                Process process = Process.Start(sfd.FileName);

                                //MessageBox.Show("¡Datos exportados correctamente!", "Inforacion");
                            }
                            catch (Exception){}
                        }
                    }
                }
                else
                {
                    MessageBox.Show("¡No hay ningún registro para exportar!", "Información");
                }
            }
        }
    }
}
