using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using Color = MigraDoc.DocumentObjectModel.Color;
using MigraDoc.DocumentObjectModel.Tables;
using Font = MigraDoc.DocumentObjectModel.Font;
using System;
using ValleVerde.Programacion;
using ValleVerde.Vistas.Compras;

namespace ValleVerde.Vistas.RecursosHumanos
{
    class PDFEmpleado
    {
        public string filename;
        bool impPorFac, visPre;
        object[,] prod, datFac;
        object[] datCom;
        ValleVerdeComun.Programacion.Usuario datosEmpleados;
        public PDFEmpleado(ValleVerdeComun.Programacion.Usuario datos)
        {
            datosEmpleados = datos;
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
            filename = "Empleado.pdf";
            pdfRenderer.PdfDocument.Save(filename);
            // ...and start a viewer.
            //Process.Start(filename);
        }

        private Document CreateDocument()
        {
            // Create a new MigraDoc document
            Document document = new Document();

            // Crear fuentes
            Font fueTit = new Font("Verdana", 28);
            fueTit.Bold = true;
            Font fueDoc = new Font("Verdana", 20);
            fueDoc.Bold = true;
            Font fueTab = new Font("Arial", 20);

            //
            string titComStr = "Empleado";

            //Color verTit = new Color(0, 255, 60);
            //Color verRen = new Color(156, 255, 178);

            // Add a section to the document
            Section secCom = document.AddSection();
            secCom.PageSetup.PageFormat = PageFormat.Letter;
            // Añadir elementos a la seccion
            Paragraph tit = secCom.AddParagraph();
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
            foo.Rows[0].Cells[1].AddParagraph().AddPageField();
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
                tabDat.Rows[0].Cells[0].AddParagraph("ID: " + datosEmpleados.idUsuario);
                tabDat.Rows[0].Cells[1].AddParagraph("Fecha: " );
            }
            tabDat.Rows[2].Cells[0].AddParagraph("Proveedor: " );
            tabDat.Rows[2].Cells[1].AddParagraph("Usuario: " );

            tab.AddColumn();
            tab.AddColumn();
            tab.AddColumn();

            tab.Borders.Color = Colors.Black;
            tab.Borders.Width = 0.25;
            tab.Rows.VerticalAlignment = VerticalAlignment.Center;
            tab.Format.Font = fueTab;
            tab.Columns.Width = 198;//190

            tab.AddRow();
            tab.AddRow();
            tab.AddRow();
            tab.AddRow();
            tab.AddRow();
            tab.AddRow();
            tab.AddRow();
            tab.AddRow();
            tab.AddRow();
            tab.AddRow();
            tab.AddRow();
            tab.AddRow();
            tab.AddRow();
            tab.AddRow();
            tab.AddRow();
            tab.AddRow();
            tab.AddRow();
            tab.AddRow();
            tab.AddRow();
            tab.AddRow();

            tab.Rows[0].Cells[1].AddParagraph("Nombre");
            tab.Rows[1].Cells[1].AddParagraph("Apellidos:");
            tab.Rows[2].Cells[1].AddParagraph("Direccion:");
            tab.Rows[3].Cells[1].AddParagraph("Colonia:");
            tab.Rows[4].Cells[1].AddParagraph("Ciudad:");
            tab.Rows[5].Cells[1].AddParagraph("Municipio:");
            tab.Rows[6].Cells[1].AddParagraph("Sexo:");
            tab.Rows[7].Cells[1].AddParagraph("Celular:");
            tab.Rows[8].Cells[1].AddParagraph("Telefono:");
            tab.Rows[9].Cells[1].AddParagraph("Email:");
            tab.Rows[10].Cells[1].AddParagraph("Puesto:");
            tab.Rows[11].Cells[1].AddParagraph("CURP:");
            tab.Rows[12].Cells[1].AddParagraph("RFC:");
            tab.Rows[13].Cells[1].AddParagraph("Fecha Nacimiento:");
            tab.Rows[14].Cells[1].AddParagraph("Lugar Nacimiento:");
            tab.Rows[15].Cells[1].AddParagraph("Estado Civil:");

            tab.Format.Alignment = ParagraphAlignment.Right;
            tab.Columns[1].Format.Alignment = ParagraphAlignment.Left;
            tab.Columns[2].Format.Alignment = ParagraphAlignment.Right;

            tab.Rows[0].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.nombres));
            tab.Rows[1].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.apellidos));
            tab.Rows[2].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.direccion));
            tab.Rows[3].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.colonia));
            tab.Rows[4].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.ciudad));
            tab.Rows[5].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.municipio));
            tab.Rows[6].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.sexo));
            tab.Rows[7].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.celular));
            tab.Rows[8].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.telefono));
            tab.Rows[9].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.email));
            tab.Rows[10].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.rol));
            tab.Rows[11].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.curp));
            tab.Rows[12].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.rfc));
            tab.Rows[13].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.fechaNacimiento.ToShortDateString()));
            tab.Rows[14].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.lugarNacimiento));
            tab.Rows[15].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.estadoCivil));


            Table tabTotEsp, tabTotAju = null, tabTotRea;
            
            if (datosEmpleados.idUsuario != null)
            {
                //tabFin.AddColumn();
                //tabFin.AddColumn();
                //tabFin.AddColumn();
                //tabFin.AddRow();

                //Total por ajuste de la compra




                //tabTotAju.Rows[1].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.nombres));
                //tabTotAju.Rows[2].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.apellidos));
                //tabTotAju.Rows[3].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.fechaalta.ToShortDateString()));
                //tabTotAju.Rows[4].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.nivelacademico));
                //tabTotAju.Rows[5].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.municipio));
                //tabTotAju.Rows[6].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.lugarnacimiento));

                //tabTotAju.Columns[1].Width = 70;
                //tabTotAju.Columns[0].Width = (198 - tabTotAju.Columns[1].Width - tabTotAju.Columns[2].Width) / 2;
                ////Console.WriteLine(tabFin.Columns - tabTotAju.Columns[1].Width - tabTotAju.Columns[2].Width);
                ////tabFin.Columns[0].Width = 594 - tabTotAju.Columns[0].Width - tabTotAju.Columns[1].Width;

                ////Total real de la compra
                //tabTotRea.AddColumn();
                //tabTotRea.AddColumn();
                //tabTotRea.AddColumn();
                //tabTotRea.AddRow();
                //tabTotRea.AddRow();
                //tabTotRea.AddRow();
                //tabTotRea.AddRow();
                //tabTotRea.AddRow();
                //tabTotRea.AddRow();
                //tabTotRea.AddRow();
                //tabTotRea.AddRow();
                //tabTotRea.AddRow();
                //tabTotRea.AddRow();
                //tabTotRea.AddRow();
                //tabTotRea.AddRow();
                //tabTotRea.AddRow();
                //tabTotRea.AddRow();
                //tabTotRea.AddRow();
                //tabTotRea.AddRow();
                //tabTotRea.AddRow();
                //tabTotRea.AddRow();
                //tabTotRea.AddRow();
                //tabTotRea.AddRow();
                //tabTotRea.AddRow();
                //tabTotRea.Format.Font = fueDoc.Clone();
                //tabTotRea.Rows[0].Cells[1].MergeRight = 1;
                //tabTotRea.Rows[0].Format.Alignment = ParagraphAlignment.Center;

                //tabTotRea.Rows[0].Cells[1].AddParagraph("Nombre");
                //tabTotRea.Rows[1].Cells[1].AddParagraph("Apellidos:");
                //tabTotRea.Rows[2].Cells[1].AddParagraph("Direccion:");
                //tabTotRea.Rows[3].Cells[1].AddParagraph("Colonia:");
                //tabTotRea.Rows[4].Cells[1].AddParagraph("Ciudad:");
                //tabTotRea.Rows[5].Cells[1].AddParagraph("Municipio:");
                //tabTotRea.Rows[6].Cells[1].AddParagraph("Sexo:");
                //tabTotRea.Rows[7].Cells[1].AddParagraph("Celular:");
                //tabTotRea.Rows[8].Cells[1].AddParagraph("Telefono:");
                //tabTotRea.Rows[9].Cells[1].AddParagraph("Email:");
                //tabTotRea.Rows[10].Cells[1].AddParagraph("Puesto:");
                //tabTotRea.Rows[11].Cells[1].AddParagraph("CURP:");
                //tabTotRea.Rows[12].Cells[1].AddParagraph("RFC:");
                //tabTotRea.Rows[13].Cells[1].AddParagraph("Fecha Nacimiento:");
                //tabTotRea.Rows[14].Cells[1].AddParagraph("Lugar Nacimiento:");
                //tabTotRea.Rows[15].Cells[1].AddParagraph("Estado Civil:");

                //tabTotRea.Format.Alignment = ParagraphAlignment.Right;
                //tabTotRea.Columns[1].Format.Alignment = ParagraphAlignment.Left;
                //tabTotRea.Columns[2].Format.Alignment = ParagraphAlignment.Right;

                //tabTotRea.Rows[0].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.nombres));
                //tabTotRea.Rows[1].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.apellidos));
                //tabTotRea.Rows[2].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.direccion));
                //tabTotRea.Rows[3].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.colonia));
                //tabTotRea.Rows[4].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.ciudad));
                //tabTotRea.Rows[5].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.municipio)); 
                //tabTotRea.Rows[6].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.sexo));
                //tabTotRea.Rows[7].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.celular));
                //tabTotRea.Rows[8].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.telefono));
                //tabTotRea.Rows[9].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.email));
                //tabTotRea.Rows[10].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.puesto));
                //tabTotRea.Rows[11].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.curp));
                //tabTotRea.Rows[12].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.rfc));
                //tabTotRea.Rows[13].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.fechanacimiento.ToShortDateString()));
                //tabTotRea.Rows[14].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.lugarnacimiento));
                //tabTotRea.Rows[15].Cells[2].AddParagraph(string.Format("{0:c}", datosEmpleados.estadocivil));

            }
            ////Total esperado de la compra
            //tabTotEsp = tabFin.Rows[0].Cells[0].Elements.AddTable();
            //tabTotEsp.AddColumn();
            //tabTotEsp.AddColumn();
            //tabTotEsp.AddRow();
            //tabTotEsp.AddRow();
            //tabTotEsp.AddRow();
            //tabTotEsp.AddRow();
            //tabTotEsp.AddRow();
            //tabTotEsp.AddRow();
            //tabTotEsp.AddRow();
            //tabTotEsp.Format.Font = fueDoc.Clone();
            //tabTotEsp.Rows[0].Cells[0].MergeRight = 1;
            //tabTotEsp.Rows[0].Format.Alignment = ParagraphAlignment.Center;
            //tabTotEsp.Format.Font = fueTab.Clone();

            //tabTotEsp.Rows[0].Cells[0].AddParagraph("Esperado");
            //tabTotEsp.Rows[1].Cells[0].AddParagraph("Subtotal:");
            //tabTotEsp.Rows[2].Cells[0].AddParagraph("Impuestos:");
            //tabTotEsp.Rows[3].Cells[0].AddParagraph("Total:");

            //tabTotEsp.Format.Alignment = ParagraphAlignment.Right;
            //tabTotEsp.Columns[0].Format.Alignment = ParagraphAlignment.Left;
            //tabTotEsp.Columns[1].Format.Alignment = ParagraphAlignment.Right;

            //tabTotEsp.Rows[1].Cells[1].AddParagraph(string.Format("{0:c}", datCom[4]));
            //tabTotEsp.Rows[2].Cells[1].AddParagraph(string.Format("{0:c}", datCom[5]));
            //tabTotEsp.Rows[3].Cells[1].AddParagraph(string.Format("{0:c}", datCom[6]));


            //if (impPorFac)
            //{
            //    //Imprimir por factura
            //    int numFac = datFac.GetLength(0),
            //        con = 0, numCam = 3,
            //        numCol = tab.Columns.Count;
            //    Row row = tab.AddRow();
            //    row.HeadingFormat = true;
            //    row.Format.Alignment = ParagraphAlignment.Center;
            //    row.Format.Font.Bold = true;
            //    row.Shading.Color = verTit;

            //    tab.Columns[0].Format.Alignment = ParagraphAlignment.Left;
            //    tab.Columns[1].Format.Alignment = ParagraphAlignment.Right;
            //    tab.Columns[2].Format.Alignment = ParagraphAlignment.Right;

            //    row.Cells[0].AddParagraph("ID de factura");
            //    row.Cells[1].AddParagraph("Folio");
            //    row.Cells[2].AddParagraph("Total");



            //    while (con < numFac)
            //    {
            //        //idFac = long.Parse(datFac[con, 0].ToString());
            //        Section secFac = document.AddSection();
            //        //secFac.PageSetup.PageFormat = PageFormat.Letter;
            //        // Añadir elementos a la seccion
            //        Paragraph titFac = secFac.AddParagraph(); //Titulo
            //        Table tabDatFac = secFac.AddTable(); //Tabla de datos de la factura
            //        secFac.AddParagraph(); //Separador 1
            //        Table tabFac = secFac.AddTable(); //Tabla de productos
            //        secFac.AddParagraph(); //Separador 2
            //        Table tabFinFac = secFac.AddTable(); //Tabla final
            //        Table fooFac = new Table();
            //        fooFac.AddColumn();
            //        fooFac.AddColumn();
            //        fooFac.AddRow();
            //        fooFac.Columns[0].Format.Alignment = ParagraphAlignment.Left;
            //        fooFac.Columns[1].Format.Alignment = ParagraphAlignment.Right;
            //        fooFac.Columns[0].Width = 472;
            //        fooFac.Columns[1].Width = 100;
            //        fooFac.Rows[0].Cells[1].AddParagraph().AddPageField();
            //        if (visPre)
            //        {
            //            if (!datFac[con, 1].ToString().Equals(""))
            //                fooFac.Rows[0].Cells[0].AddParagraph("Folio: " + datFac[con, 1]);
            //        }
            //        else
            //            if (datFac[con, 1].ToString().Equals(""))
            //            fooFac.Rows[0].Cells[0].AddParagraph("ID de factura: " + datFac[con, 0] + "\tFecha: " + datCom[1]);
            //        else
            //            fooFac.Rows[0].Cells[0].AddParagraph("ID de factura: " + datFac[con, 0] + "\tFolio: " + datFac[con, 1] + "\tFecha: " + datCom[1]);
            //        secFac.Footers.Primary.Add(fooFac.Clone());
            //        //(secCom.Footers.Primary.Elements[0] as Table).Rows[0].Cells[0].AddParagraph("Funciona!");
            //        secFac.PageSetup.StartingNumber = 1;

            //        secFac.PageSetup.TopMargin = 10;
            //        secFac.PageSetup.LeftMargin = 12;
            //        secFac.PageSetup.RightMargin = 0;
            //        secFac.PageSetup.BottomMargin = 50;
            //        titFac.AddFormattedText(titFacStr, fueTit);
            //        titFac.Format.Alignment = ParagraphAlignment.Center;
            //        tabDatFac.AddColumn();
            //        tabDatFac.AddColumn();
            //        tabDatFac.AddRow();
            //        tabDatFac.AddRow();
            //        tabDatFac.AddRow();
            //        tabDatFac.Format.Font = fueDoc.Clone();
            //        tabDatFac.Columns[0].Width = 367;
            //        tabDatFac.Columns[1].Width = 205;

            //        tabDatFac.Columns[0].Format.Alignment = ParagraphAlignment.Left;
            //        tabDatFac.Columns[1].Format.Alignment = ParagraphAlignment.Left;
            //        tabDatFac.Rows[0].Cells[0].AddParagraph("ID: " + datFac[con, 0]);
            //        if (!visPre)
            //            tabDatFac.Rows[0].Cells[1].AddParagraph("Fecha: " + datCom[1]);
            //        tabDatFac.Rows[2].Cells[0].AddParagraph("Proveedor: " + datCom[2]);
            //        tabDatFac.Rows[2].Cells[1].AddParagraph("Usuario: " + datCom[3]);

            //        tabFac.AddColumn(); //idProd Max: 80p
            //        tabFac.AddColumn(); //descProd Max: 
            //        tabFac.AddColumn(); //canUni Max: 55p
            //        tabFac.AddColumn(); //preAct Max 52p
            //        tabFac.AddColumn(); //preNueSinImp Max: 52p
            //        tabFac.AddColumn(); //preNue Max: 52p
            //        tabFac.AddColumn(); //Importe sin impuesto Max: 72p
            //        tabFac.AddColumn(); //IVA Max: 32p
            //        tabFac.AddColumn(); //IEPS Max: 32p
            //        tabFac.AddColumn(); //Importe Max: 72p
            //        tabFac.Borders.Color = Colors.Black;
            //        tabFac.Borders.Width = 0.25;
            //        tabFac.Rows.VerticalAlignment = VerticalAlignment.Center;



            //        row = tabFac.AddRow();
            //        row.HeadingFormat = true;
            //        row.Format.Alignment = ParagraphAlignment.Center;
            //        row.Format.Font.Bold = true;
            //        row.Shading.Color = verTit;

            //        row.Cells[0].AddParagraph("Código de barras");
            //        row.Cells[1].AddParagraph("Descripción");

            //        row.Cells[3].AddParagraph("Costo actual");
            //        row.Cells[4].AddParagraph("Nuevo costo s/i");
            //        row.Cells[5].AddParagraph("Nuevo costo");
            //        row.Cells[6].AddParagraph("Importe s/i");
            //        row.Cells[7].AddParagraph("IVA");
            //        row.Cells[8].AddParagraph("IEPS");
            //        row.Cells[9].AddParagraph("Importe");

            //        //Tabla final
            //        Table tabTotEspFac, tabTotAjuFac = null, tabTotReaFac;
            //        if (datCom[18] != null)
            //        {
            //            tabFinFac.AddColumn();
            //            tabFinFac.AddColumn();
            //            tabFinFac.AddColumn();
            //            tabFinFac.AddRow();
            //            tabTotAjuFac = tabFinFac.Rows[0].Cells[1].Elements.AddTable();
            //            tabTotReaFac = tabFinFac.Rows[0].Cells[2].Elements.AddTable();

            //            //Total por ajuste de la compra
            //            tabTotAjuFac.AddColumn();
            //            tabTotAjuFac.AddColumn();
            //            tabTotAjuFac.AddColumn();
            //            tabTotAjuFac.AddRow();
            //            tabTotAjuFac.AddRow();
            //            tabTotAjuFac.AddRow();
            //            tabTotAjuFac.AddRow();
            //            tabTotAjuFac.AddRow();
            //            tabTotAjuFac.AddRow();
            //            tabTotAjuFac.AddRow();
            //            tabTotAjuFac.Rows[0].Cells[1].MergeRight = 1;
            //            tabTotAjuFac.Rows[0].Format.Alignment = ParagraphAlignment.Center;
            //            tabTotAjuFac.Format.Font = fueTab.Clone();

            //            tabTotAjuFac.Rows[0].Cells[1].AddParagraph("Ajuste");
            //            tabTotAjuFac.Rows[1].Cells[1].AddParagraph("Subtotal:");
            //            tabTotAjuFac.Rows[2].Cells[1].AddParagraph("Impuestos:");
            //            tabTotAjuFac.Rows[3].Cells[1].AddParagraph("Total:");
            //            tabTotAjuFac.Rows[4].Cells[1].AddParagraph("Descuento:");
            //            tabTotAjuFac.Rows[5].Cells[1].AddParagraph("Devolución:");
            //            tabTotAjuFac.Rows[6].Cells[1].AddParagraph("Total a pagar:");

            //            tabTotAjuFac.Format.Alignment = ParagraphAlignment.Right;
            //            tabTotAjuFac.Columns[1].Format.Alignment = ParagraphAlignment.Left;
            //            tabTotAjuFac.Columns[2].Format.Alignment = ParagraphAlignment.Right;

            //            tabTotAjuFac.Rows[1].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 11]));
            //            tabTotAjuFac.Rows[2].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 12]));
            //            tabTotAjuFac.Rows[3].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 13]));
            //            tabTotAjuFac.Rows[4].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 14]));
            //            tabTotAjuFac.Rows[5].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 15]));
            //            tabTotAjuFac.Rows[6].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 16]));


            //            //Total real de la compra
            //            tabTotReaFac.AddColumn();
            //            tabTotReaFac.AddColumn();
            //            tabTotReaFac.AddColumn();
            //            tabTotReaFac.AddRow();
            //            tabTotReaFac.AddRow();
            //            tabTotReaFac.AddRow();
            //            tabTotReaFac.AddRow();
            //            tabTotReaFac.AddRow();
            //            tabTotReaFac.AddRow();
            //            tabTotReaFac.AddRow();
            //            tabTotReaFac.Format.Font = fueDoc.Clone();
            //            tabTotReaFac.Rows[0].Cells[1].MergeRight = 1;
            //            tabTotReaFac.Rows[0].Format.Alignment = ParagraphAlignment.Center;

            //            tabTotReaFac.Rows[0].Cells[1].AddParagraph("Real");
            //            tabTotReaFac.Rows[1].Cells[1].AddParagraph("Subtotal:");
            //            tabTotReaFac.Rows[2].Cells[1].AddParagraph("Impuestos:");
            //            tabTotReaFac.Rows[3].Cells[1].AddParagraph("Total:");
            //            tabTotReaFac.Rows[4].Cells[1].AddParagraph("Descuento:");
            //            tabTotReaFac.Rows[5].Cells[1].AddParagraph("Devolución:");
            //            tabTotReaFac.Rows[6].Cells[1].AddParagraph("Total a pagar:");

            //            tabTotReaFac.Format.Alignment = ParagraphAlignment.Right;
            //            tabTotReaFac.Columns[1].Format.Alignment = ParagraphAlignment.Left;
            //            tabTotReaFac.Columns[2].Format.Alignment = ParagraphAlignment.Right;

            //            tabTotReaFac.Rows[1].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 5]));
            //            tabTotReaFac.Rows[2].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 6]));
            //            tabTotReaFac.Rows[3].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 7]));
            //            tabTotReaFac.Rows[4].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 8]));
            //            tabTotReaFac.Rows[5].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 9]));
            //            tabTotReaFac.Rows[6].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 10]));


            //        }
            //        else
            //        {
            //            tabFinFac.AddColumn();
            //            tabFinFac.AddColumn();
            //            tabFinFac.AddRow();
            //            tabTotReaFac = tabFinFac.Rows[0].Cells[1].Elements.AddTable();

            //            //Total real de la compra
            //            tabTotReaFac.AddColumn();
            //            tabTotReaFac.AddColumn();
            //            tabTotReaFac.AddColumn();
            //            tabTotReaFac.AddRow();
            //            tabTotReaFac.AddRow();
            //            tabTotReaFac.AddRow();
            //            tabTotReaFac.AddRow();
            //            tabTotReaFac.AddRow();
            //            tabTotReaFac.AddRow();
            //            tabTotReaFac.AddRow();
            //            tabTotReaFac.Format.Font = fueDoc.Clone();
            //            tabTotReaFac.Rows[0].Cells[1].MergeRight = 1;
            //            tabTotReaFac.Rows[0].Format.Alignment = ParagraphAlignment.Center;

            //            tabTotReaFac.Rows[0].Cells[1].AddParagraph("Real");
            //            tabTotReaFac.Rows[1].Cells[1].AddParagraph("Subtotal:");
            //            tabTotReaFac.Rows[2].Cells[1].AddParagraph("Impuestos:");
            //            tabTotReaFac.Rows[3].Cells[1].AddParagraph("Total:");
            //            tabTotReaFac.Rows[4].Cells[1].AddParagraph("Descuento:");
            //            tabTotReaFac.Rows[5].Cells[1].AddParagraph("Devolución:");
            //            tabTotReaFac.Rows[6].Cells[1].AddParagraph("Total a pagar:");

            //            tabTotReaFac.Format.Alignment = ParagraphAlignment.Right;
            //            tabTotReaFac.Columns[1].Format.Alignment = ParagraphAlignment.Left;
            //            tabTotReaFac.Columns[2].Format.Alignment = ParagraphAlignment.Right;

            //            tabTotReaFac.Rows[1].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 5]));
            //            tabTotReaFac.Rows[2].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 6]));
            //            tabTotReaFac.Rows[3].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 7]));
            //            tabTotReaFac.Rows[4].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 8]));
            //            tabTotReaFac.Rows[5].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 9]));
            //            tabTotReaFac.Rows[6].Cells[2].AddParagraph(string.Format("{0:c}", datFac[con, 10]));

            //        }
            //        //Total esperado de la factura
            //        tabTotEspFac = tabFinFac.Rows[0].Cells[0].Elements.AddTable();
            //        tabTotEspFac.AddColumn();
            //        tabTotEspFac.AddColumn();
            //        tabTotEspFac.AddRow();
            //        tabTotEspFac.AddRow();
            //        tabTotEspFac.AddRow();
            //        tabTotEspFac.AddRow();
            //        tabTotEspFac.AddRow();
            //        tabTotEspFac.AddRow();
            //        tabTotEspFac.AddRow();
            //        tabTotEspFac.Format.Font = fueDoc.Clone();
            //        tabTotEspFac.Rows[0].Cells[0].MergeRight = 1;
            //        tabTotEspFac.Rows[0].Format.Alignment = ParagraphAlignment.Center;
            //        tabTotEspFac.Format.Font = fueTab.Clone();

            //        tabTotEspFac.Rows[0].Cells[0].AddParagraph("Esperado");
            //        tabTotEspFac.Rows[1].Cells[0].AddParagraph("Subtotal:");
            //        tabTotEspFac.Rows[2].Cells[0].AddParagraph("Impuestos:");
            //        tabTotEspFac.Rows[3].Cells[0].AddParagraph("Total:");

            //        tabTotEspFac.Format.Alignment = ParagraphAlignment.Right;
            //        tabTotEspFac.Columns[0].Format.Alignment = ParagraphAlignment.Left;
            //        tabTotEspFac.Columns[1].Format.Alignment = ParagraphAlignment.Right;

            //        tabTotEspFac.Rows[1].Cells[1].AddParagraph(string.Format("{0:c}", datFac[con, 2]));
            //        tabTotEspFac.Rows[2].Cells[1].AddParagraph(string.Format("{0:c}", datFac[con, 3]));
            //        tabTotEspFac.Rows[3].Cells[1].AddParagraph(string.Format("{0:c}", datFac[con, 4]));

            //        con++;
            //    }
            //}
            //else
            //{
            //    //Imprimir toda la compra

            //    tab.AddColumn();
            //    tab.AddColumn();
            //    tab.AddColumn();
            //    tab.AddColumn();
            //    tab.AddColumn();
            //    tab.AddColumn();
            //    tab.AddColumn();

            //    tab.Rows.Alignment = RowAlignment.Left;
            //    tab.Rows.LeftIndent = 100;

            //    Row row = tab.AddRow();
            //    row.HeadingFormat = true;
            //    row.Format.Alignment = ParagraphAlignment.Center;
            //    row.Format.Font.Bold = true;
            //    row.Shading.Color = verTit;

            //    tab.Columns[0].Format.Alignment = ParagraphAlignment.Left;
            //    tab.Columns[1].Format.Alignment = ParagraphAlignment.Right;
            //    tab.Columns[2].Format.Alignment = ParagraphAlignment.Right;
            //    int numCam = prod.GetLength(1) - 1,
            //    numCol = tab.Columns.Count;

            //    row.Cells[0].AddParagraph("Código de barras");
            //    row.Cells[1].AddParagraph("Descripción");

            //    row.Cells[3].AddParagraph("Costo actual");
            //    row.Cells[4].AddParagraph("Nuevo costo s/i");
            //    row.Cells[5].AddParagraph("Nuevo costo");
            //    row.Cells[6].AddParagraph("Importe s/i");
            //    row.Cells[7].AddParagraph("IVA");
            //    row.Cells[8].AddParagraph("IEPS");
            //    row.Cells[9].AddParagraph("Importe");
            //}
            return document;
        }
    }
}
