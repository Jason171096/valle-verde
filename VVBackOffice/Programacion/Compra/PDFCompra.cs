using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using Color = MigraDoc.DocumentObjectModel.Color;
using MigraDoc.DocumentObjectModel.Tables;
using Font = MigraDoc.DocumentObjectModel.Font;
using System;
using System.Diagnostics;

namespace ValleVerde.Vistas.Compras
{
    class PDFCompra
    {
        public string filename;
        bool impPorFac, visPre;
        object[,] prod, datFac;
        object[] datCom;
        public PDFCompra(bool impPorFac, bool visPre, object[] datCom, object[,] datFac, object[,] prod)
        {
            this.impPorFac = impPorFac;
            this.visPre = visPre;
            this.datCom = datCom;
            this.datFac = datFac;
            this.prod = prod;

            //MigraDoc
            // Create a MigraDoc document
            Document document = CreateDocument();
            document.UseCmykColor = true;

            // ===== Unicode encoding and font program embedding in MigraDoc is demonstrated here =====

            // A flag indicating whether to create a Unicode PDF or a WinAnsi PDF file.
            // This setting applies to all fonts used in the PDF document.
            // This setting has no effect on the RTF renderer.
            const bool unicode = false;

            // An enum indicating whether to embed fonts or not.
            // This setting applies to all font programs used in the document.
            // This setting has no effect on the RTF renderer.
            // (The term 'font program' is used by Adobe for a file containing a font. Technically a 'font file'
            // is a collection of small programs and each program renders the glyph of a character when executed.
            // Using a font in PDFsharp may lead to the embedding of one or more font programms, because each outline
            // (regular, bold, italic, bold+italic, ...) has its own fontprogram)

            // Create a renderer for the MigraDoc document.
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(unicode);

            // Associate the MigraDoc document with a renderer
            pdfRenderer.Document = document;

            // Layout and render document to PDF
            pdfRenderer.RenderDocument();

            // Save the document...
            filename = "Compra.pdf";
            pdfRenderer.PdfDocument.Save(filename);
            // ...and start a viewer.
            //Process.Start(filename);
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
            string titComStr = "Compra", titFacStr = "Factura";
            if(visPre)
            {
                titComStr += " (Vista previa)";
                titFacStr += " (Vista previa)";
            }
            Color verTit = new Color(0, 255, 60);
            Color verRen = new Color(156, 255, 178);
            double ancTex;
            MedidorTexto mt = new MedidorTexto(fueTab);
            mt.Font = fueTab;
            decimal subAjuProd, impAjuProd, totAjuProd, subAjuFac = 0, impAjuFac = 0, totAjuFac = 0; 

            // Add a section to the document
            Section secCom = document.AddSection();
            secCom.PageSetup.PageFormat = PageFormat.Letter;
            // Añadir elementos a la seccion
            Paragraph tit = secCom.AddParagraph();
            Table tabDat = secCom.AddTable();
            secCom.AddParagraph();
            Table tab = secCom.AddTable();
            secCom.AddParagraph();
            Table tabFin = secCom.AddTable();
            Table foo = new Table();
            foo.AddColumn();
            foo.AddColumn();
            foo.AddRow();
            foo.Columns[0].Format.Alignment = ParagraphAlignment.Left;
            foo.Columns[1].Format.Alignment = ParagraphAlignment.Right;
            foo.Columns[0].Width = 472;
            foo.Columns[1].Width = 100;
            foo.Rows[0].Cells[1].AddParagraph().AddPageField();
            if (datCom[0] != null)
                foo.Rows[0].Cells[0].AddParagraph("ID de compra: " + datCom[0] + "\tFecha: " + datCom[1]);
            secCom.Footers.Primary.Add(foo.Clone());
            secCom.PageSetup.TopMargin = 10;
            secCom.PageSetup.LeftMargin = 12;
            secCom.PageSetup.RightMargin = 0;
            secCom.PageSetup.BottomMargin = 50;
            tit.AddFormattedText(titComStr, fueTit);
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
            if (!visPre)
            {
                tabDat.Rows[0].Cells[0].AddParagraph("ID: " + datCom[0]);
                tabDat.Rows[0].Cells[1].AddParagraph("Fecha: " + datCom[1]);
            }
            tabDat.Rows[2].Cells[0].AddParagraph("Proveedor: " + datCom[2]);
            tabDat.Rows[2].Cells[1].AddParagraph("Usuario: " + datCom[3]);

            tab.AddColumn();
            tab.AddColumn();
            tab.AddColumn();

            tab.Borders.Color = Colors.Black;
            tab.Borders.Width = 0.25;
            tab.Rows.VerticalAlignment = VerticalAlignment.Center;
            tab.Format.Font = fueTab;
            tab.Columns.Width = 198;//190

            int col = 0;
            double[] maxPunPorCol =
            {
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0
                    };
            int[] minPunPorCol =
            {
                        40,
                        1,
                        30,//26
                        36,
                        38,
                        38,
                        44,
                        24,
                        29,
                        44
                    };
           
            //Console.WriteLine(tabFin.Columns[0].Width + ", " + tabFin.Columns[1].Width);
            //datCom[9] = 20000;

            Table tabTotEsp, tabTotAju = null, tabTotRea;
            
            if (datCom[18] != null)
            {
                tabFin.AddColumn();
                tabFin.AddColumn();
                tabFin.AddColumn();
                tabFin.AddRow();
                tabTotAju = tabFin.Rows[0].Cells[1].Elements.AddTable();
                tabTotRea = tabFin.Rows[0].Cells[2].Elements.AddTable();

                //Total por ajuste de la compra
                tabTotAju.AddColumn();
                tabTotAju.AddColumn();
                tabTotAju.AddColumn();
                tabTotAju.AddRow();
                tabTotAju.AddRow();
                tabTotAju.AddRow();
                tabTotAju.AddRow();
                tabTotAju.AddRow();
                tabTotAju.AddRow();
                tabTotAju.AddRow();
                tabTotAju.Rows[0].Cells[1].MergeRight = 1;
                tabTotAju.Rows[0].Format.Alignment = ParagraphAlignment.Center;
                tabTotAju.Format.Font = fueTab.Clone();

                tabTotAju.Rows[0].Cells[1].AddParagraph("Ajuste");
                tabTotAju.Rows[1].Cells[1].AddParagraph("Subtotal:");
                tabTotAju.Rows[2].Cells[1].AddParagraph("Impuestos:");
                tabTotAju.Rows[3].Cells[1].AddParagraph("Total:");
                tabTotAju.Rows[4].Cells[1].AddParagraph("Descuento:");
                tabTotAju.Rows[5].Cells[1].AddParagraph("Devolución:");
                tabTotAju.Rows[6].Cells[1].AddParagraph("Total a pagar:");

                tabTotAju.Format.Alignment = ParagraphAlignment.Right;
                tabTotAju.Columns[1].Format.Alignment = ParagraphAlignment.Left;
                tabTotAju.Columns[2].Format.Alignment = ParagraphAlignment.Right;

                tabTotAju.Rows[1].Cells[2].AddParagraph(string.Format("{0:c}", datCom[13]));
                tabTotAju.Rows[2].Cells[2].AddParagraph(string.Format("{0:c}", datCom[14]));
                tabTotAju.Rows[3].Cells[2].AddParagraph(string.Format("{0:c}", datCom[15]));
                tabTotAju.Rows[4].Cells[2].AddParagraph(string.Format("{0:c}", datCom[16]));
                tabTotAju.Rows[5].Cells[2].AddParagraph(string.Format("{0:c}", datCom[17]));
                tabTotAju.Rows[6].Cells[2].AddParagraph(string.Format("{0:c}", datCom[18]));

                tabTotAju.Columns[1].Width = 70;
                tabTotAju.Columns[2].Width = mt.MedirTexto(string.Format("{0:c}", datCom[18])).Width * 1.1;
                tabTotAju.Columns[0].Width = (198 - tabTotAju.Columns[1].Width - tabTotAju.Columns[2].Width) / 2;
                //Console.WriteLine(tabFin.Columns - tabTotAju.Columns[1].Width - tabTotAju.Columns[2].Width);
                //tabFin.Columns[0].Width = 594 - tabTotAju.Columns[0].Width - tabTotAju.Columns[1].Width;

                //Total real de la compra
                tabTotRea.AddColumn();
                tabTotRea.AddColumn();
                tabTotRea.AddColumn();
                tabTotRea.AddRow();
                tabTotRea.AddRow();
                tabTotRea.AddRow();
                tabTotRea.AddRow();
                tabTotRea.AddRow();
                tabTotRea.AddRow();
                tabTotRea.AddRow();
                tabTotRea.Format.Font = fueDoc.Clone();
                tabTotRea.Rows[0].Cells[1].MergeRight = 1;
                tabTotRea.Rows[0].Format.Alignment = ParagraphAlignment.Center;

                tabTotRea.Rows[0].Cells[1].AddParagraph("Real");
                tabTotRea.Rows[1].Cells[1].AddParagraph("Subtotal:");
                tabTotRea.Rows[2].Cells[1].AddParagraph("Impuestos:");
                tabTotRea.Rows[3].Cells[1].AddParagraph("Total:");
                tabTotRea.Rows[4].Cells[1].AddParagraph("Descuento:");
                tabTotRea.Rows[5].Cells[1].AddParagraph("Devolución:");
                tabTotRea.Rows[6].Cells[1].AddParagraph("Total a pagar:");

                tabTotRea.Format.Alignment = ParagraphAlignment.Right;
                tabTotRea.Columns[1].Format.Alignment = ParagraphAlignment.Left;
                tabTotRea.Columns[2].Format.Alignment = ParagraphAlignment.Right;

                tabTotRea.Rows[1].Cells[2].AddParagraph(string.Format("{0:c}", datCom[7]));
                tabTotRea.Rows[2].Cells[2].AddParagraph(string.Format("{0:c}", datCom[8]));
                tabTotRea.Rows[3].Cells[2].AddParagraph(string.Format("{0:c}", datCom[9]));
                tabTotRea.Rows[4].Cells[2].AddParagraph(string.Format("{0:c}", datCom[10]));
                tabTotRea.Rows[5].Cells[2].AddParagraph(string.Format("{0:c}", datCom[11]));
                tabTotRea.Rows[6].Cells[2].AddParagraph(string.Format("{0:c}", datCom[12]));

                mt.Font = fueDoc;
                tabFin.Columns.Width = 198;
                tabTotRea.Columns[1].Width = 90;
                tabTotRea.Columns[2].Width = mt.MedirTexto(string.Format("{0:c}", datCom[12])).Width * 1;
                tabTotRea.Columns[0].Width = 198 - tabTotRea.Columns[1].Width - tabTotRea.Columns[2].Width;
            }
            else
            {
                tabFin.AddColumn();
                tabFin.AddColumn();
                tabFin.AddRow();
                tabTotRea = tabFin.Rows[0].Cells[1].Elements.AddTable();

                //Total real de la compra
                tabTotRea.AddColumn();
                tabTotRea.AddColumn();
                tabTotRea.AddColumn();
                tabTotRea.AddRow();
                tabTotRea.AddRow();
                tabTotRea.AddRow();
                tabTotRea.AddRow();
                tabTotRea.AddRow();
                tabTotRea.AddRow();
                tabTotRea.AddRow();
                tabTotRea.Format.Font = fueDoc.Clone();
                tabTotRea.Rows[0].Cells[1].MergeRight = 1;
                tabTotRea.Rows[0].Format.Alignment = ParagraphAlignment.Center;

                tabTotRea.Rows[0].Cells[1].AddParagraph("Real");
                tabTotRea.Rows[1].Cells[1].AddParagraph("Subtotal:");
                tabTotRea.Rows[2].Cells[1].AddParagraph("Impuestos:");
                tabTotRea.Rows[3].Cells[1].AddParagraph("Total:");
                tabTotRea.Rows[4].Cells[1].AddParagraph("Descuento:");
                tabTotRea.Rows[5].Cells[1].AddParagraph("Devolución:");
                tabTotRea.Rows[6].Cells[1].AddParagraph("Total a pagar:");

                tabTotRea.Format.Alignment = ParagraphAlignment.Right;
                tabTotRea.Columns[1].Format.Alignment = ParagraphAlignment.Left;
                tabTotRea.Columns[2].Format.Alignment = ParagraphAlignment.Right;

                tabTotRea.Rows[1].Cells[2].AddParagraph(string.Format("{0:c}", datCom[7]));
                tabTotRea.Rows[2].Cells[2].AddParagraph(string.Format("{0:c}", datCom[8]));
                tabTotRea.Rows[3].Cells[2].AddParagraph(string.Format("{0:c}", datCom[9]));
                tabTotRea.Rows[4].Cells[2].AddParagraph(string.Format("{0:c}", datCom[10]));
                tabTotRea.Rows[5].Cells[2].AddParagraph(string.Format("{0:c}", datCom[11]));
                tabTotRea.Rows[6].Cells[2].AddParagraph(string.Format("{0:c}", datCom[12]));

                mt.Font = fueDoc;
                tabFin.Columns.Width = 297;
                tabTotRea.Columns[1].Width = 90;
                tabTotRea.Columns[2].Width = mt.MedirTexto(string.Format("{0:c}", datCom[12])).Width * 1;
                tabTotRea.Columns[0].Width = 297 - tabTotRea.Columns[1].Width - tabTotRea.Columns[2].Width;
            }
            //Total esperado de la compra
            tabTotEsp = tabFin.Rows[0].Cells[0].Elements.AddTable();
            tabTotEsp.AddColumn();
            tabTotEsp.AddColumn();
            tabTotEsp.AddRow();
            tabTotEsp.AddRow();
            tabTotEsp.AddRow();
            tabTotEsp.AddRow();
            tabTotEsp.AddRow();
            tabTotEsp.AddRow();
            tabTotEsp.AddRow();
            tabTotEsp.Format.Font = fueDoc.Clone();
            tabTotEsp.Rows[0].Cells[0].MergeRight = 1;
            tabTotEsp.Rows[0].Format.Alignment = ParagraphAlignment.Center;
            tabTotEsp.Format.Font = fueTab.Clone();

            tabTotEsp.Rows[0].Cells[0].AddParagraph("Esperado");
            tabTotEsp.Rows[1].Cells[0].AddParagraph("Subtotal:");
            tabTotEsp.Rows[2].Cells[0].AddParagraph("Impuestos:");
            tabTotEsp.Rows[3].Cells[0].AddParagraph("Total:");

            tabTotEsp.Format.Alignment = ParagraphAlignment.Right;
            tabTotEsp.Columns[0].Format.Alignment = ParagraphAlignment.Left;
            tabTotEsp.Columns[1].Format.Alignment = ParagraphAlignment.Right;

            tabTotEsp.Rows[1].Cells[1].AddParagraph(string.Format("{0:c}", datCom[4]));
            tabTotEsp.Rows[2].Cells[1].AddParagraph(string.Format("{0:c}", datCom[5]));
            tabTotEsp.Rows[3].Cells[1].AddParagraph(string.Format("{0:c}", datCom[6]));

            mt.Font = fueTab;
            tabTotEsp.Columns[0].Width = 70;
            tabTotEsp.Columns[1].Width = mt.MedirTexto(string.Format("{0:c}", datCom[6])).Width * 1.1;

            //tabFin.Borders.Color = new Color(200, 200, 200);
            //tabFin.Borders.Width = 0.75;
            //tabTotEsp.Borders.Color = Colors.LightGreen;
            //tabTotAju.Borders.Color = Colors.LightBlue;
            //tabTotRea.Borders.Color = Colors.Black;

            if (impPorFac)
            {
                //Imprimir por factura
                int numFac = datFac.GetLength(0),
                    con = 0, numCam = 3,
                    numCol = tab.Columns.Count;
                Row row = tab.AddRow();
                row.HeadingFormat = true;
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Format.Font.Bold = true;
                row.Shading.Color = verTit;

                tab.Columns[0].Format.Alignment = ParagraphAlignment.Left;
                tab.Columns[1].Format.Alignment = ParagraphAlignment.Right;
                tab.Columns[2].Format.Alignment = ParagraphAlignment.Right;

                row.Cells[0].AddParagraph("ID de factura");
                row.Cells[1].AddParagraph("Folio");
                row.Cells[2].AddParagraph("Total");
                //Imprime la primer sección, donde está la lista de facturas que pertenecen a la compra
                for (int ren = 1; ren <= datFac.GetLength(0); ren++)
                {
                    // Agrega renglon
                    if (ren % 2 == 0)
                        tab.AddRow().Shading.Color = verRen;
                    else
                        tab.AddRow();

                    for (col = 0; col < numCam; col++)
                    {
                        // Agrega contenido a esta celda del renlon
                        if (col == 0)
                        {
                            tab.Rows[ren].Cells[col].AddParagraph(datFac[ren - 1, 0].ToString());
                        }
                        else
                            if (col == 1)
                        {
                            tab.Rows[ren].Cells[col].AddParagraph(datFac[ren - 1, 1].ToString());
                        }
                        else
                                if (col == 2)
                        {
                            tab.Rows[ren].Cells[col].AddParagraph(string.Format("{0:c}", datFac[ren - 1, 10]));
                        }
                    }
                }
                
                //Imprime cada factura
                while (con < numFac)
                {
                    //idFac = long.Parse(datFac[con, 0].ToString());
                    Section secFac = document.AddSection();
                    //secFac.PageSetup.PageFormat = PageFormat.Letter;
                    // Añadir elementos a la seccion
                    Paragraph titFac = secFac.AddParagraph(); //Titulo
                    Table tabDatFac = secFac.AddTable(); //Tabla de datos de la factura
                    secFac.AddParagraph(); //Separador 1
                    Table tabFac = secFac.AddTable(); //Tabla de productos
                    secFac.AddParagraph(); //Separador 2
                    Table tabFinFac = secFac.AddTable(); //Tabla final
                    Table fooFac = new Table();
                    fooFac.AddColumn();
                    fooFac.AddColumn();
                    fooFac.AddRow();
                    fooFac.Columns[0].Format.Alignment = ParagraphAlignment.Left;
                    fooFac.Columns[1].Format.Alignment = ParagraphAlignment.Right;
                    fooFac.Columns[0].Width = 472;
                    fooFac.Columns[1].Width = 100;
                    fooFac.Rows[0].Cells[1].AddParagraph().AddPageField();
                    if(visPre)
                    {
                        if (!datFac[con, 1].ToString().Equals(""))
                            fooFac.Rows[0].Cells[0].AddParagraph("Folio: " + datFac[con, 1]);
                    }
                    else
                        if (datFac[con, 1].ToString().Equals(""))
                            fooFac.Rows[0].Cells[0].AddParagraph("ID de factura: " + datFac[con, 0] + "\tFecha: " + datCom[1]);
                        else
                            fooFac.Rows[0].Cells[0].AddParagraph("ID de factura: " + datFac[con, 0] + "\tFolio: " + datFac[con, 1] + "\tFecha: " + datCom[1]);
                    secFac.Footers.Primary.Add(fooFac.Clone());
                    //(secCom.Footers.Primary.Elements[0] as Table).Rows[0].Cells[0].AddParagraph("Funciona!");
                    secFac.PageSetup.StartingNumber = 1;

                    secFac.PageSetup.TopMargin = 10;
                    secFac.PageSetup.LeftMargin = 12;
                    secFac.PageSetup.RightMargin = 0;
                    secFac.PageSetup.BottomMargin = 50;
                    titFac.AddFormattedText(titFacStr, fueTit);
                    titFac.Format.Alignment = ParagraphAlignment.Center;
                    tabDatFac.AddColumn();
                    tabDatFac.AddColumn();
                    tabDatFac.AddRow();
                    tabDatFac.AddRow();
                    tabDatFac.AddRow();
                    tabDatFac.Format.Font = fueDoc.Clone();
                    tabDatFac.Columns[0].Width = 367;
                    tabDatFac.Columns[1].Width = 205;

                    tabDatFac.Columns[0].Format.Alignment = ParagraphAlignment.Left;
                    tabDatFac.Columns[1].Format.Alignment = ParagraphAlignment.Left;
                    tabDatFac.Rows[0].Cells[0].AddParagraph("ID: " + datFac[con, 0]);
                    if(!visPre)
                        tabDatFac.Rows[0].Cells[1].AddParagraph("Fecha: " + datCom[1]);
                    tabDatFac.Rows[2].Cells[0].AddParagraph("Proveedor: " + datCom[2]);
                    tabDatFac.Rows[2].Cells[1].AddParagraph("Usuario: " + datCom[3]);

                    tabFac.AddColumn(); //idProd Max: 80p
                    tabFac.AddColumn(); //descProd Max: 
                    tabFac.AddColumn(); //canUni Max: 55p
                    tabFac.AddColumn(); //preAct Max 52p
                    tabFac.AddColumn(); //preNueSinImp Max: 52p
                    tabFac.AddColumn(); //preNue Max: 52p
                    tabFac.AddColumn(); //Importe sin impuesto Max: 72p
                    tabFac.AddColumn(); //IVA Max: 32p
                    tabFac.AddColumn(); //IEPS Max: 32p
                    tabFac.AddColumn(); //Importe Max: 72p
                    tabFac.Borders.Color = Colors.Black;
                    tabFac.Borders.Width = 0.25;
                    tabFac.Rows.VerticalAlignment = VerticalAlignment.Center;
                    //tabFac.Format.Font = fueTab.Clone();
                    mt.Font = fueTab;

                    col = 0;
                    numCam = prod.GetLength(1) - 1;
                    numCol = tabFac.Columns.Count;
                    
                    while (col < numCol)
                    {
                        if (col != 1)
                            tabFac.Columns[col].Format.Alignment = ParagraphAlignment.Right;
                        else
                            tabFac.Columns[col].Format.Alignment = ParagraphAlignment.Left;
                        maxPunPorCol[col] = 0;
                        col++;
                    }

                    row = tabFac.AddRow();
                    row.HeadingFormat = true;
                    row.Format.Alignment = ParagraphAlignment.Center;
                    row.Format.Font.Bold = true;
                    row.Shading.Color = verTit;

                    row.Cells[0].AddParagraph("Código de barras");
                    row.Cells[1].AddParagraph("Descripción");

                    row.Cells[3].AddParagraph("Costo actual");
                    row.Cells[4].AddParagraph("Nuevo costo s/i");
                    row.Cells[5].AddParagraph("Nuevo costo");
                    row.Cells[6].AddParagraph("Importe s/i");
                    row.Cells[7].AddParagraph("IVA");
                    row.Cells[8].AddParagraph("IEPS");
                    row.Cells[9].AddParagraph("Importe");

                    int renFac = 1;
                    subAjuFac = 0;
                    impAjuFac = 0;
                    totAjuFac = 0;
                    for (int ren = 0; ren < prod.GetLength(0); ren++)
                    {
                        if (prod[ren, 0].Equals(datFac[con, 0]))
                        {
                            // Agrega renglon
                            if (ren % 2 == 0)
                                tabFac.AddRow().Shading.Color = verRen;
                            else
                                tabFac.AddRow();

                            for (col = 2; col < numCam; col++)
                            {
                                // Agrega contenido a esta celda del renglon
                                if (prod[ren, col] != null)
                                {
                                    if (col == 3)
                                    {
                                        maxPunPorCol[col - 2] = 1;
                                        tabFac.Rows[renFac].Cells[col - 2].AddParagraph(prod[ren, col].ToString());
                                    }
                                    else
                                        if (col == 2 || col == 4 || col == 9 || col == 10)
                                        tabFac.Rows[renFac].Cells[col - 2].AddParagraph(prod[ren, col].ToString());
                                    else
                                        tabFac.Rows[renFac].Cells[col - 2].AddParagraph(string.Format("{0:c}", prod[ren, col]));
                                    // Medimos el texto
                                    //ancTex = mt.MedirTexto(prod[ren, col].ToString()).Width;
                                    ancTex = mt.MedirTexto(((tabFac.Rows[renFac].Cells[col - 2].Elements[0] as Paragraph).Elements[0] as Text).Content).Width;
                                    //Si es más grande que textos anteriores, guardamos su medida
                                    if (ancTex > maxPunPorCol[col - 2])
                                        maxPunPorCol[col - 2] = ancTex;
                                }
                            }
                            totAjuProd = (decimal)prod[ren, 11];
                            totAjuFac += totAjuProd;
                            if (prod[ren, 8] != null)
                            {
                                subAjuProd = (decimal)prod[ren, 8];
                                subAjuFac += subAjuProd;
                                impAjuFac += totAjuProd - subAjuProd;
                            }
                            else
                            {
                                subAjuFac += totAjuProd;
                            }
                            renFac++;
                        }
                    }

                    datFac[con, 11] = subAjuFac;
                    datFac[con, 12] = impAjuFac;
                    datFac[con, 13] = totAjuFac;
                    datFac[con, 14] = datFac[con, 8];
                    datFac[con, 15] = datFac[con, 9];
                    datFac[con, 16] = totAjuFac - (decimal)datFac[con, 14] - (decimal)datFac[con, 15];

                    //Corregimos las medidas y obtenemos el ancho de la columna "Descripcion" (del producto)
                    col = 0;
                    ancTex = 594;
                    while (col < numCol)
                    {
                        if (col == 7 || col == 8)
                            tabFac.Columns[col].Width = maxPunPorCol[col] * 1.30;
                        else
                            tabFac.Columns[col].Width = maxPunPorCol[col] * 1.16;
                        if (col != 1)
                        {
                            if (tabFac.Columns[col].Width < minPunPorCol[col])
                            {
                                tabFac.Columns[col].Width = minPunPorCol[col];
                                if (col == 2)
                                    row.Cells[2].AddParagraph("Can.");
                            }
                            else
                                if (col == 2)
                                row.Cells[2].AddParagraph("Cantidad");

                            ancTex -= tabFac.Columns[col].Width;
                        }
                        Console.WriteLine("Columna " + col + ": " + tabFac.Columns[col].Width);
                        col++;
                    }
                    tabFac.Columns[1].Width = ancTex;

                    //Tabla final
                    Table tabTotEspFac, tabTotAjuFac = null, tabTotReaFac;
                    if (datCom[18] != null)
                    {
                        tabFinFac.AddColumn();
                        tabFinFac.AddColumn();
                        tabFinFac.AddColumn();
                        tabFinFac.AddRow();
                        tabTotAjuFac = tabFinFac.Rows[0].Cells[1].Elements.AddTable();
                        tabTotReaFac = tabFinFac.Rows[0].Cells[2].Elements.AddTable();

                        //Total por ajuste de la compra
                        tabTotAjuFac.AddColumn();
                        tabTotAjuFac.AddColumn();
                        tabTotAjuFac.AddColumn();
                        tabTotAjuFac.AddRow();
                        tabTotAjuFac.AddRow();
                        tabTotAjuFac.AddRow();
                        tabTotAjuFac.AddRow();
                        tabTotAjuFac.AddRow();
                        tabTotAjuFac.AddRow();
                        tabTotAjuFac.AddRow();
                        tabTotAjuFac.Rows[0].Cells[1].MergeRight = 1;
                        tabTotAjuFac.Rows[0].Format.Alignment = ParagraphAlignment.Center;
                        tabTotAjuFac.Format.Font = fueTab.Clone();

                        tabTotAjuFac.Rows[0].Cells[1].AddParagraph("Ajuste");
                        tabTotAjuFac.Rows[1].Cells[1].AddParagraph("Subtotal:");
                        tabTotAjuFac.Rows[2].Cells[1].AddParagraph("Impuestos:");
                        tabTotAjuFac.Rows[3].Cells[1].AddParagraph("Total:");
                        tabTotAjuFac.Rows[4].Cells[1].AddParagraph("Descuento:");
                        tabTotAjuFac.Rows[5].Cells[1].AddParagraph("Devolución:");
                        tabTotAjuFac.Rows[6].Cells[1].AddParagraph("Total a pagar:");

                        tabTotAjuFac.Format.Alignment = ParagraphAlignment.Right;
                        tabTotAjuFac.Columns[1].Format.Alignment = ParagraphAlignment.Left;
                        tabTotAjuFac.Columns[2].Format.Alignment = ParagraphAlignment.Right;

                        tabTotAjuFac.Rows[1].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 11]));
                        tabTotAjuFac.Rows[2].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 12]));
                        tabTotAjuFac.Rows[3].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 13]));
                        tabTotAjuFac.Rows[4].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 14]));
                        tabTotAjuFac.Rows[5].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 15]));
                        tabTotAjuFac.Rows[6].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 16]));

                        mt.Font = fueTab;
                        tabTotAjuFac.Columns[1].Width = 70;
                        tabTotAjuFac.Columns[2].Width = mt.MedirTexto(string.Format("{0:c}", datFac[con, 16])).Width * 1.1;
                        tabTotAjuFac.Columns[0].Width = (198 - tabTotAjuFac.Columns[1].Width - tabTotAjuFac.Columns[2].Width) / 2;
                        
                        //Total real de la compra
                        tabTotReaFac.AddColumn();
                        tabTotReaFac.AddColumn();
                        tabTotReaFac.AddColumn();
                        tabTotReaFac.AddRow();
                        tabTotReaFac.AddRow();
                        tabTotReaFac.AddRow();
                        tabTotReaFac.AddRow();
                        tabTotReaFac.AddRow();
                        tabTotReaFac.AddRow();
                        tabTotReaFac.AddRow();
                        tabTotReaFac.Format.Font = fueDoc.Clone();
                        tabTotReaFac.Rows[0].Cells[1].MergeRight = 1;
                        tabTotReaFac.Rows[0].Format.Alignment = ParagraphAlignment.Center;

                        tabTotReaFac.Rows[0].Cells[1].AddParagraph("Real");
                        tabTotReaFac.Rows[1].Cells[1].AddParagraph("Subtotal:");
                        tabTotReaFac.Rows[2].Cells[1].AddParagraph("Impuestos:");
                        tabTotReaFac.Rows[3].Cells[1].AddParagraph("Total:");
                        tabTotReaFac.Rows[4].Cells[1].AddParagraph("Descuento:");
                        tabTotReaFac.Rows[5].Cells[1].AddParagraph("Devolución:");
                        tabTotReaFac.Rows[6].Cells[1].AddParagraph("Total a pagar:");

                        tabTotReaFac.Format.Alignment = ParagraphAlignment.Right;
                        tabTotReaFac.Columns[1].Format.Alignment = ParagraphAlignment.Left;
                        tabTotReaFac.Columns[2].Format.Alignment = ParagraphAlignment.Right;

                        tabTotReaFac.Rows[1].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 5]));
                        tabTotReaFac.Rows[2].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 6]));
                        tabTotReaFac.Rows[3].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 7]));
                        tabTotReaFac.Rows[4].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 8]));
                        tabTotReaFac.Rows[5].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 9]));
                        tabTotReaFac.Rows[6].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 10]));

                        mt.Font = fueDoc;
                        tabFinFac.Columns.Width = 198;
                        tabTotReaFac.Columns[1].Width = 90;
                        tabTotReaFac.Columns[2].Width = mt.MedirTexto(string.Format("{0:c}", datFac[con, 10])).Width * 1.5;
                        tabTotReaFac.Columns[0].Width = 198 - tabTotReaFac.Columns[1].Width - tabTotReaFac.Columns[2].Width;
                    }
                    else
                    {
                        tabFinFac.AddColumn();
                        tabFinFac.AddColumn();
                        tabFinFac.AddRow();
                        tabTotReaFac = tabFinFac.Rows[0].Cells[1].Elements.AddTable();

                        //Total real de la compra
                        tabTotReaFac.AddColumn();
                        tabTotReaFac.AddColumn();
                        tabTotReaFac.AddColumn();
                        tabTotReaFac.AddRow();
                        tabTotReaFac.AddRow();
                        tabTotReaFac.AddRow();
                        tabTotReaFac.AddRow();
                        tabTotReaFac.AddRow();
                        tabTotReaFac.AddRow();
                        tabTotReaFac.AddRow();
                        tabTotReaFac.Format.Font = fueDoc.Clone();
                        tabTotReaFac.Rows[0].Cells[1].MergeRight = 1;
                        tabTotReaFac.Rows[0].Format.Alignment = ParagraphAlignment.Center;

                        tabTotReaFac.Rows[0].Cells[1].AddParagraph("Real");
                        tabTotReaFac.Rows[1].Cells[1].AddParagraph("Subtotal:");
                        tabTotReaFac.Rows[2].Cells[1].AddParagraph("Impuestos:");
                        tabTotReaFac.Rows[3].Cells[1].AddParagraph("Total:");
                        tabTotReaFac.Rows[4].Cells[1].AddParagraph("Descuento:");
                        tabTotReaFac.Rows[5].Cells[1].AddParagraph("Devolución:");
                        tabTotReaFac.Rows[6].Cells[1].AddParagraph("Total a pagar:");

                        tabTotReaFac.Format.Alignment = ParagraphAlignment.Right;
                        tabTotReaFac.Columns[1].Format.Alignment = ParagraphAlignment.Left;
                        tabTotReaFac.Columns[2].Format.Alignment = ParagraphAlignment.Right;

                        tabTotReaFac.Rows[1].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 5]));
                        tabTotReaFac.Rows[2].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 6]));
                        tabTotReaFac.Rows[3].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 7]));
                        tabTotReaFac.Rows[4].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 8]));
                        tabTotReaFac.Rows[5].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 9]));
                        tabTotReaFac.Rows[6].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 10]));

                        mt.Font = fueDoc;
                        tabFinFac.Columns.Width = 297;
                        tabTotReaFac.Columns[1].Width = 90;
                        tabTotReaFac.Columns[2].Width = mt.MedirTexto(string.Format("{0:c}", datFac[con, 10])).Width * 1.5;
                        tabTotReaFac.Columns[0].Width = 297 - tabTotReaFac.Columns[1].Width - tabTotReaFac.Columns[2].Width;
                    }
                    //Total esperado de la factura
                    tabTotEspFac = tabFinFac.Rows[0].Cells[0].Elements.AddTable();
                    tabTotEspFac.AddColumn();
                    tabTotEspFac.AddColumn();
                    tabTotEspFac.AddRow();
                    tabTotEspFac.AddRow();
                    tabTotEspFac.AddRow();
                    tabTotEspFac.AddRow();
                    tabTotEspFac.AddRow();
                    tabTotEspFac.AddRow();
                    tabTotEspFac.AddRow();
                    tabTotEspFac.Format.Font = fueDoc.Clone();
                    tabTotEspFac.Rows[0].Cells[0].MergeRight = 1;
                    tabTotEspFac.Rows[0].Format.Alignment = ParagraphAlignment.Center;
                    tabTotEspFac.Format.Font = fueTab.Clone();

                    tabTotEspFac.Rows[0].Cells[0].AddParagraph("Esperado");
                    tabTotEspFac.Rows[1].Cells[0].AddParagraph("Subtotal:");
                    tabTotEspFac.Rows[2].Cells[0].AddParagraph("Impuestos:");
                    tabTotEspFac.Rows[3].Cells[0].AddParagraph("Total:");

                    tabTotEspFac.Format.Alignment = ParagraphAlignment.Right;
                    tabTotEspFac.Columns[0].Format.Alignment = ParagraphAlignment.Left;
                    tabTotEspFac.Columns[1].Format.Alignment = ParagraphAlignment.Right;

                    tabTotEspFac.Rows[1].Cells[1].AddParagraph(string.Format("{0:c}", datFac[con, 2]));
                    tabTotEspFac.Rows[2].Cells[1].AddParagraph(string.Format("{0:c}", datFac[con, 3]));
                    tabTotEspFac.Rows[3].Cells[1].AddParagraph(string.Format("{0:c}", datFac[con, 4]));

                    mt.Font = fueTab;
                    tabTotEspFac.Columns[0].Width = 70;
                    tabTotEspFac.Columns[1].Width = mt.MedirTexto(string.Format("{0:c}", datFac[con, 4])).Width * 1.1;
                    //tabFinFac.AddColumn();
                    //tabFinFac.AddColumn();
                    //tabFinFac.AddRow();
                    //tabFinFac.AddRow();
                    //tabFinFac.AddRow();
                    //tabFinFac.AddRow();
                    //tabFinFac.AddRow();
                    //tabFinFac.AddRow();
                    //tabFinFac.Format.Font = fueDoc.Clone();

                    //tabFinFac.Rows[0].Cells[0].AddParagraph("Subtotal:");
                    //tabFinFac.Rows[1].Cells[0].AddParagraph("Impuestos:");
                    //tabFinFac.Rows[2].Cells[0].AddParagraph("Total:");
                    //tabFinFac.Rows[3].Cells[0].AddParagraph("Descuento:");
                    //tabFinFac.Rows[4].Cells[0].AddParagraph("Devolución:");
                    //tabFinFac.Rows[5].Cells[0].AddParagraph("Total a pagar:");

                    //tabFinFac.Rows[0].Cells[1].AddParagraph(string.Format("{0:c}", datFac[con, 2]));
                    //tabFinFac.Rows[1].Cells[1].AddParagraph(string.Format("{0:c}", datFac[con, 3]));
                    //tabFinFac.Rows[2].Cells[1].AddParagraph(string.Format("{0:c}", datFac[con, 4]));
                    //tabFinFac.Rows[3].Cells[1].AddParagraph(string.Format("{0:c}", datFac[con, 5]));
                    //tabFinFac.Rows[4].Cells[1].AddParagraph(string.Format("{0:c}", datFac[con, 6]));
                    //tabFinFac.Rows[5].Cells[1].AddParagraph(string.Format("{0:c}", datFac[con, 7]));

                    //tabFinFac.Format.Alignment = ParagraphAlignment.Right;
                    //tabFinFac.Columns[0].Format.Alignment = ParagraphAlignment.Left;
                    //tabFinFac.Columns[1].Format.Alignment = ParagraphAlignment.Right;

                    //mt.Font = fueTab;
                    //tabFinFac.Columns[0].Width = 100;
                    //tabFinFac.Columns[1].Width = mt.MedirTexto(string.Format("{0:c}", datFac[con, 0])).Width * 1.50;
                    //tabFinFac.Rows.LeftIndent = 594 - tabFinFac.Columns[0].Width - tabFinFac.Columns[1].Width;

                    con++;
                }
            }
            else
            {
                //Imprimir toda la compra

                tab.AddColumn();
                tab.AddColumn();
                tab.AddColumn();
                tab.AddColumn();
                tab.AddColumn();
                tab.AddColumn();
                tab.AddColumn();

                tab.Rows.Alignment = RowAlignment.Left;
                //tab.Rows.LeftIndent = 100;

                Row row = tab.AddRow();
                row.HeadingFormat = true;
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Format.Font.Bold = true;
                row.Shading.Color = verTit;

                tab.Columns[0].Format.Alignment = ParagraphAlignment.Left;
                tab.Columns[1].Format.Alignment = ParagraphAlignment.Right;
                tab.Columns[2].Format.Alignment = ParagraphAlignment.Right;
                int numCam = prod.GetLength(1) - 3, //1,
                numCol = tab.Columns.Count;
                while (col < numCol)
                {
                    if (col != 1)
                        tab.Columns[col].Format.Alignment = ParagraphAlignment.Right;
                    else
                        tab.Columns[col].Format.Alignment = ParagraphAlignment.Left;
                    col++;
                }

                row.Cells[0].AddParagraph("Código de barras");
                row.Cells[1].AddParagraph("Descripción");

                row.Cells[3].AddParagraph("Costo actual");
                row.Cells[4].AddParagraph("Nuevo costo s/i");
                row.Cells[5].AddParagraph("Nuevo costo");
                row.Cells[6].AddParagraph("Importe s/i");
                row.Cells[7].AddParagraph("IVA");
                row.Cells[8].AddParagraph("IEPS");
                row.Cells[9].AddParagraph("Importe");

                for (int ren = 0; ren < prod.GetLength(0); ren++)
                {
                    // Agrega renglon
                    if (ren % 2 == 0)
                        tab.AddRow().Shading.Color = verRen;
                    else
                        tab.AddRow();

                    for (col = 0; col < numCam; col++)
                    {
                        if (prod[ren, col + 2] != null)
                        {
                            if (col == 1)
                            {
                                maxPunPorCol[col] = 1;
                                tab.Rows[ren + 1].Cells[col].AddParagraph(prod[ren, col + 2].ToString());
                            }
                            else
                                if (col == 3 || col == 4 || col == 5 || col == 6 || col == 9)
                                    tab.Rows[ren + 1].Cells[col].AddParagraph(string.Format("{0:c}", prod[ren, col + 2]));
                                else
                                    tab.Rows[ren + 1].Cells[col].AddParagraph(prod[ren, col + 2].ToString());

                            // Medimos el texto
                            //ancTex = mt.MedirTexto(prod[ren, col + 2].ToString()).Width;
                            ancTex = mt.MedirTexto(((tab.Rows[ren + 1].Cells[col].Elements[0] as Paragraph).Elements[0] as Text).Content).Width;
                            //Si es más grande que textos anteriores, guardamos su medida
                            if (ancTex > maxPunPorCol[col])
                                maxPunPorCol[col] = ancTex;


                            //// Agrega contenido a esta celda del renlon
                            //tab.Rows[ren + 1].Cells[col].AddParagraph(prod[ren, col + 2].ToString());

                            //if (col == 1)
                            //    maxPunPorCol[col] = 1;
                            //// Medimos el texto
                            //ancTex = mt.MedirTexto(prod[ren, col + 2].ToString()).Width;
                            ////Si es más grande que textos anteriores, guardamos su medida
                            //if (ancTex > maxPunPorCol[col])
                            //    maxPunPorCol[col] = ancTex;
                        }
                    }
                }
                //Corregimos las medidas y obtenemos el ancho de la columna "Descripcion" (del producto)
                col = 0;
                ancTex = 594;
                while (col < numCol)
                {
                    if (col == 7 || col == 8)
                        tab.Columns[col].Width = maxPunPorCol[col] * 1.30;
                    else
                        tab.Columns[col].Width = maxPunPorCol[col] * 1.16;
                    if (col != 1)
                    {
                        if (tab.Columns[col].Width < minPunPorCol[col])
                        {
                            tab.Columns[col].Width = minPunPorCol[col];
                            if (col == 2)
                                row.Cells[2].AddParagraph("Can.");
                        }
                        else
                            if (col == 2)
                            row.Cells[2].AddParagraph("Cantidad");

                        ancTex -= tab.Columns[col].Width;
                    }
                    Console.WriteLine("Columna " + col + ": " + tab.Columns[col].Width);
                    col++;
                }
                tab.Columns[1].Width = ancTex;

                //tabTotRea.Rows[0].Cells[1].AddParagraph(string.Format("{0:c}", datCom[7]));
                //tabTotRea.Rows[1].Cells[1].AddParagraph(string.Format("{0:c}", datCom[8]));
                //tabTotRea.Rows[2].Cells[1].AddParagraph(string.Format("{0:c}", datCom[9]));
                //tabTotRea.Rows[3].Cells[1].AddParagraph(string.Format("{0:c}", datCom[10]));
                //tabTotRea.Rows[4].Cells[1].AddParagraph(string.Format("{0:c}", datCom[11]));
                //tabTotRea.Rows[5].Cells[1].AddParagraph(string.Format("{0:c}", datCom[12]));

                //mt.Font = fueDoc;
                //tabTotRea.Columns[0].Width = 100;
                //tabTotRea.Columns[1].Width = mt.MedirTexto(string.Format("{0:c}", datCom[12])).Width * 1;
                //tabTotRea.Rows.LeftIndent = 594 - tabTotRea.Columns[0].Width - tabTotRea.Columns[1].Width;
            }

            return document;
        }
    }
}
