using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerdeComun.Programacion
{
    public class GenerarTicket
    {
        ConfiguracionPV configuracionPV;
        ConfiguracionBO configuracionBO;
        DatosConfiguracionGlobal configuracionGlobal;
        ValleVerdeComun.Programacion.Huellas.ResultadoHuella usuario;
        Cliente cliente;
        PrintDocument impresoraTickets;
        decimal ahorro = 0.0m;
        string rutaImprimir;
        DataGridView dgvProductos;
        List<int> indicesRemarcar;
        List<int[]> indicesCajas;
        Nullable <DateTime> fecha;
        DatosFactura datosFactura;



        FlowLayoutPanel ticket;
        string folio;
        int anchoTicket;
        DatosEmpresa datosEmpresa;
        DatosTicket datosTicket;

        static FontFamily fontFamily = new FontFamily("Arial");
        Font font = new Font(
           fontFamily,
           24,
           FontStyle.Regular,
           GraphicsUnit.Pixel);
        Font font_1 = new Font(
          fontFamily,
          24,
          FontStyle.Bold,
          GraphicsUnit.Pixel);
        Font fontB = new Font(
           fontFamily,
           26,
           FontStyle.Bold,
           GraphicsUnit.Pixel);
        Font fontB0 = new Font(
         fontFamily,
         32,
         FontStyle.Regular,
         GraphicsUnit.Pixel);
        Font fontB0_1 = new Font(
        fontFamily,
        32,
        FontStyle.Bold,
        GraphicsUnit.Pixel);
        Font fontB1 = new Font(
          fontFamily,
          36,
          FontStyle.Bold,
          GraphicsUnit.Pixel);
        Font fontB1_2 = new Font(
          fontFamily,
          36,
          FontStyle.Regular,
          GraphicsUnit.Pixel);
        Font fontB2 = new Font(
          fontFamily,
          44,
          FontStyle.Bold,
          GraphicsUnit.Pixel);
        Font fontB2_1 = new Font(
          fontFamily,
          44,
          FontStyle.Bold,
          GraphicsUnit.Pixel);
        Font fontB3 = new Font(
         fontFamily,
         60,
         FontStyle.Bold,
         GraphicsUnit.Pixel);
        public GenerarTicket(ConfiguracionPV configuracionPV, ConfiguracionBO configuracionBO, DatosConfiguracionGlobal configuracionGlobal, PrintDocument impresoraTickets)
        {
            this.configuracionPV = configuracionPV;
            this.configuracionBO = configuracionBO;
            this.configuracionGlobal = configuracionGlobal;
            this.impresoraTickets = impresoraTickets;
            this.impresoraTickets.PrintPage += ImprimirTicket;
        }

        public void setUsuario(ValleVerdeComun.Programacion.Huellas.ResultadoHuella usuario)
        {
            this.usuario = usuario;
        }

        public void setCliente(Cliente cliente)
        {
            this.cliente = cliente;
        }

        public void setAhorro(decimal ahorro)
        {
            this.ahorro = ahorro;
        }

        public void setFecha(DateTime fecha)
        {
            this.fecha = fecha;
        }

        public void setDatosFactura(DatosFactura datosFactura)
        {
            this.datosFactura = datosFactura;
        }

        public void setDgvProductos(DataGridView dgvProductos)
        {
            this.dgvProductos = dgvProductos;
        }

        public void setIndicesRemarcar(List<int> indicesRemarcar)
        {
            this.indicesRemarcar = indicesRemarcar;
        }

        public void setIndicesMostrarCajas(List<int[]> indicesCajas)
        {
            this.indicesCajas = indicesCajas;
        }

        private void ImprimirTicket(object o, PrintPageEventArgs e)
        {
            if (rutaImprimir != "")
                try
                {
                    e.Graphics.Clear(Color.White);

                    //impresoraTickets.PrinterSettings.PaperSizes

                    Image i = Image.FromFile(rutaImprimir);

                    Rectangle m = e.PageBounds;


                    if ((double)i.Width / (double)i.Height > (double)m.Width / (double)m.Height) // image is wider
                    {
                        m.Height = (int)((double)i.Height / (double)i.Width * (double)m.Width);
                        m.Width = (int)impresoraTickets.PrinterSettings.DefaultPageSettings.PrintableArea.Width;
                    }
                    else
                    {
                        m.Width = (int)((double)i.Width / (double)i.Height * (double)m.Height);
                    }
                    e.Graphics.DrawImage(i, m);

                    Point loc = new Point(0, 0);
                    //e.Graphics.DrawImage(i, loc);
                }
                catch { }
        }

        public void GenerarTicketVenta(bool esCotizacion, string folio, decimal total, decimal pagoCon, decimal cambio, int noArticulos, int formaPago, string referencia, bool copiaClienteCredito, bool esGastoDeTienda, bool usarTicketSecundario)
        {
            FlowLayoutPanel ticketOriginal = null;
            if (usarTicketSecundario)
                ticketOriginal = ticket;

            if (noArticulos > 0)
            {
                //Este cambia el ticket original cuando usarTicketSecundario es true
                ConfigurarTicket(folio, configuracionGlobal.IDTicketVentas + "");

                if (datosTicket != null)
                {
                    IncluirLogo();

                    IncluirDatosEmpresa();

                    IncluirDatosTicket(1);

                    IncluirDatosFactura();

                    if (esCotizacion)
                    {
                        IncluirTitulo("Cotizacion");
                    }

                    if (esGastoDeTienda)
                    {
                        IncluirTitulo("Gasto de tienda");
                    }

                    if(formaPago == 4)
                    {
                        IncluirTitulo("Venta a credito");
                    }

                    IncluirMensajeCabecera();

                    IncluirTablaProductos();

                    //Checar forma de pago, si es a credito imprime diferente
                    if (formaPago != 4)
                    {
                        IncluirTotales(1,total,pagoCon,cambio, referencia, formaPago);
                    }
                    else
                    {
                        //Fue a credito, indicarlo

                        IncluirTotales(1, total, -1, -1, referencia, formaPago);

                        IncluirSaldoCliente(formaPago);

                        //Genera la copia del cliente
                        IncluirFirmaCliente(total,pagoCon,cambio,noArticulos,formaPago,copiaClienteCredito, referencia, esGastoDeTienda);


                    }

                    IncluirAhorro(esCotizacion);

                    IncluirNumeroArticulos(noArticulos);

                    if (!esGastoDeTienda)
                        IncluirMensajesPie();

                    if (esCotizacion)
                    {
                        IncluirLeyendaDuracionCotizacion();
                    }

                    IncluirCodigoFactura();

                    if (esGastoDeTienda)
                    {
                        IncluirFirmasCorte(false);
                    }

                    IncluirCodigoBarras();

                    if(!copiaClienteCredito)
                        GuardarTicket(1);
                    else
                        GuardarTicket(2);

                }
            }

            if (copiaClienteCredito)
            {
                ticket = ticketOriginal;
            }
            else
            {
                LimpiarTicket();
            }
        }

        public void GenerarTicketDevolucion(string folio, decimal total, int noArticulos)
        {
            if (noArticulos > 0)
            {
                ConfigurarTicket(folio, configuracionGlobal.IDTicketDevoluciones + "");

                if (datosTicket != null)
                {
                    //IncluirLogo();

                    IncluirDatosEmpresa();

                    IncluirDatosTicket(1);

                    IncluirTitulo("Devolucion");
                    
                    IncluirTablaProductos();

                    //Checar forma de pago, si es a credito imprime diferente
                    IncluirTotales(1, total, -1, -1,"",-1);

                    IncluirNumeroArticulos(noArticulos);

                    IncluirCodigoBarras();

                    GuardarTicket(3);

                }
            }
            impresoraTickets.Print();
            LimpiarTicket();
        }

        public void GenerarTicketSalida(string folio, decimal total, string motivo, Vistas.PedirFondo obPedirFondo)
        {
           
            ConfigurarTicket(folio, configuracionGlobal.IDTicketDevoluciones + "");

            if (datosTicket != null)
            {
                //IncluirLogo();

                IncluirDatosEmpresa();

                IncluirDatosTicket(4);

                IncluirTitulo("Salida de dinero");

                AgregarSubTotal("Motivo: " + motivo, fontB1_2);

                AgregarTotal("Total: ", total, fontB1);

                IncluirEspacio();

                if(obPedirFondo != null)
                    IncluirTotalEntregado(obPedirFondo, total, 0, obPedirFondo.duracionMinutos, obPedirFondo.duracionSegundos, false);

                IncluirFirmasCorte(false);

                GuardarTicket(7);

            }
           
            impresoraTickets.Print();
            LimpiarTicket();
        }

        public Vistas.PedirFondo GenerarTicketCorteTurno(Vistas.PedirFondo obPedirFondo)
        {
            Vistas.PedirFondo obFondoSugerido = null; 
            Programacion.Corte obc = new Programacion.Corte();

            ConfigurarTicket(obPedirFondo.ObtenerIDTurno(),true);

            IncluirLogo();

            IncluirDatosEmpresaCorte();

            IncluirTitulo("Corte de Turno");

            IncluirDatosTicket(2);

            IncluirTitulo("Resumen");

            decimal[] totales = obc.ObtenerTotalesVentas(folio);

            IncluirResumenCorte(totales);

            IncluirTotalesVentas(obc, totales[0]);

            IncluirTotalesDevoluciones(obc, totales[2]);

            IncluirTotalesSalidas(obc, totales[3]);

            IncluirTotalesGastosTienda(obc, totales[4]);

            IncluirTotalesFondoDeCaja(obc, totales[6], totales[12]);

            IncluirTotalEntregado(obPedirFondo, totales[10], totales[8], obPedirFondo.duracionMinutos, obPedirFondo.duracionSegundos, true);

            if (obPedirFondo.ObtenerFondoSiguienteTurno() > 0)
                obFondoSugerido = GenerarSugeridoFondoCaja(true,true,false, "Sugerencia de fondo de caja", obPedirFondo.ObtenerFondoSiguienteTurno(), obPedirFondo.ObtenerCantidadesMonedas(), obPedirFondo.ObtenerCantidadesBilletes());

            IncluirFirmasCorte(true);

            GuardarTicket(4);




            LimpiarTicket();

            return obFondoSugerido;
        }

        public void GenerarConteoFondo(string titulo , string folio,Vistas.PedirFondo obPedirFondo, decimal totalContado, bool incluirFirmas)
        {
            if (totalContado > 0)
            {
                ConfigurarTicketConteoFondo(folio);

                IncluirTitulo(titulo);

                IncluirDatosTicket(4);

                GenerarTablaDinero(obPedirFondo, -1, null, null,-1,true);

                IncluirEspacio();

                AgregarTotal("Total contado: ", totalContado, fontB1);

                if (incluirFirmas)
                    IncluirFirmasCorte(false);

                GuardarTicket(5);
            }
            LimpiarTicket();
        }

        public Vistas.PedirFondo GenerarSugeridoFondoCaja(bool ticketYaConfigurado, bool sumarParaCompletar, bool incluirEnTicket, string titulo, decimal fondoSiguienteTurno, TextBox[] cantidadesDisponiblesMonedas, TextBox[] cantidadesDisponiblesBilletes)
        {
            Vistas.PedirFondo obPedirFondo = null;

            if (fondoSiguienteTurno > 0)
            {
                if(!ticketYaConfigurado)
                    ConfigurarTicket();

                if(incluirEnTicket)
                    IncluirTitulo(titulo);

                obPedirFondo = new Vistas.PedirFondo();

                if (cantidadesDisponiblesMonedas != null && cantidadesDisponiblesBilletes != null)
                    GenerarTablaDinero(obPedirFondo, fondoSiguienteTurno, cantidadesDisponiblesMonedas, cantidadesDisponiblesBilletes,100, incluirEnTicket);
                
                if (incluirEnTicket)
                    IncluirEspacio();

                decimal total = obPedirFondo.ObtenerFondoContado();

                if (total != fondoSiguienteTurno)
                {
                    if (incluirEnTicket)
                    {
                        AgregarTotal("Total: ", total, fontB1);
                        AgregarTotal("Agregar extra para completar: ", fondoSiguienteTurno - total, fontB1);

                        IncluirTitulo("Sugerencia para completar");
                    }

                    Vistas.PedirFondo obPedirFondo2 = new Vistas.PedirFondo();
                    Vistas.PedirFondo sugeridos = new Vistas.PedirFondo();

                    //Hacer que tenga disponibles 100 de cada uno para completar

                    int i = 0;
                    foreach (TextBox cantidad in obPedirFondo2.ObtenerCantidadesMonedas()){
                        if(i > 2)
                            cantidad.Text = "100";
                        else
                            cantidad.Text = "0";
                        i++;
                    }
                    i = 0;
                    foreach (TextBox cantidad in obPedirFondo2.ObtenerCantidadesBilletes())
                    {
                        if (i > 2)
                            cantidad.Text = "100";
                        else
                            cantidad.Text = "0";
                        i++;
                    }

                    GenerarTablaDinero(sugeridos, fondoSiguienteTurno - total, obPedirFondo2.ObtenerCantidadesMonedas(), obPedirFondo2.ObtenerCantidadesBilletes(),20, incluirEnTicket);

                    if (sumarParaCompletar)
                    {
                        i = 0;
                        foreach (TextBox cantidad in obPedirFondo.ObtenerCantidadesMonedas())
                        {
                            cantidad.Text = int.Parse(cantidad.Text) + int.Parse(sugeridos.ObtenerCantidadesMonedas()[i].Text)+"";

                            i++;
                        }

                        i = 0;
                        foreach (TextBox cantidad in obPedirFondo.ObtenerCantidadesBilletes())
                        {
                            cantidad.Text = int.Parse(cantidad.Text) + int.Parse(sugeridos.ObtenerCantidadesBilletes()[i].Text) + "";

                            i++;
                        }
                    }

                    if (incluirEnTicket)
                    {
                        IncluirEspacio();

                        AgregarTotal("Total: ", fondoSiguienteTurno - total, fontB1);

                        IncluirEspacio();

                        AgregarTotal("Total deseado: ", fondoSiguienteTurno, fontB1);
                    }
                }
                else
                    AgregarTotal("Total: ", fondoSiguienteTurno, fontB1);

                if(!ticketYaConfigurado)
                    GuardarTicket(5);
            }
            if (!ticketYaConfigurado)
                LimpiarTicket();

            return obPedirFondo;
        }

        public void GenerarTicketAbono(string folio, decimal abono, decimal pagoCon, decimal cambio, decimal limite, decimal saldo)
        {
            
            
            ConfigurarTicket(folio,false);

            if (datosTicket != null)
            {
                IncluirLogo();

                IncluirDatosEmpresa();

                IncluirDatosTicket(3);

                IncluirTitulo("Abono a crédito");

                AgregarTotal("Abono: ", abono, fontB1_2);
                if(saldo>= 0)
                    AgregarTotal("Saldo restante: ", saldo, fontB1_2);
                else
                    AgregarTotal("Saldo a favor: ", -saldo, fontB1_2);

                AgregarTotal("Limite de crédito: ", limite, fontB1_2);

                IncluirEspacio();

                IncluirTotales(3, abono, pagoCon, cambio,"",-1);

                
                //if (!copiaClienteCredito)
                //    GuardarTicket(1);
                //else
                //    GuardarTicket(2);

                GuardarTicket(6);
            }
            

            LimpiarTicket();
        }

        private void ConfigurarTicket()
        {
            if(configuracionPV!=null)
                anchoTicket = int.Parse(configuracionPV.AnchoTicket) * 10;
            else
                anchoTicket = int.Parse(configuracionBO.AnchoTicket) * 10;

            ticket = new FlowLayoutPanel();
            ticket.Width = anchoTicket;
            ticket.AutoSize = true;
            ticket.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ticket.WrapContents = true;
            ticket.FlowDirection = FlowDirection.TopDown;
            ticket.Padding = new Padding(0);
            ticket.BackColor = Color.White;

            ConfiguracionGlobal obcg = new ConfiguracionGlobal();
            datosEmpresa = obcg.ObtenerDatosEmpresa();

            //Confogurarlo con todo habilitado, es corte
            datosTicket = new DatosTicket(0, "Corte de turno", "", "", "", "", true, true, true, true, true, true, 2, false, false, false, false, true, true, true, true, false, true);

        }
        private void ConfigurarTicket(string folio,bool esCorte)
        {
            this.folio = string.Format("{0:D12}", int.Parse(folio));
            if (configuracionPV != null)
                anchoTicket = int.Parse(configuracionPV.AnchoTicket) * 10;
            else
                anchoTicket = int.Parse(configuracionBO.AnchoTicket) * 10;

            ticket = new FlowLayoutPanel();
            ticket.Width = anchoTicket;
            ticket.AutoSize = true;
            ticket.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ticket.WrapContents = true;
            ticket.FlowDirection = FlowDirection.TopDown;
            ticket.Padding = new Padding(0);
            ticket.BackColor = Color.White;

            ConfiguracionGlobal obcg = new ConfiguracionGlobal();
            datosEmpresa = obcg.ObtenerDatosEmpresa();

            string titulo = "";
            if(esCorte)
                titulo = "Corte de turno";
            else
                titulo = "Abono";
            //Confogurarlo con todo habilitado, es corte
            datosTicket = new DatosTicket(0,titulo,"","","","",true,true,true,true,true,true,2,false,false,false,false,true,true,true,true,false,true);

        }

        private void ConfigurarTicketConteoFondo(string folio)
        {
            this.folio = string.Format("{0:D12}", int.Parse(folio));
            if (configuracionPV != null)
                anchoTicket = int.Parse(configuracionPV.AnchoTicket) * 10;
            else
                anchoTicket = int.Parse(configuracionBO.AnchoTicket) * 10;

            ticket = new FlowLayoutPanel();
            ticket.Width = anchoTicket;
            ticket.AutoSize = true;
            ticket.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ticket.WrapContents = true;
            ticket.FlowDirection = FlowDirection.TopDown;
            ticket.Padding = new Padding(0);
            ticket.BackColor = Color.White;

            ConfiguracionGlobal obcg = new ConfiguracionGlobal();
            datosEmpresa = obcg.ObtenerDatosEmpresa();

            string titulo = "";
            titulo = "Sugerido";
            //Confogurarlo con todo habilitado, es corte
            datosTicket = new DatosTicket(0, titulo, "", "", "", "", false, false, false, false, false, false, 2, false, false, false, false, false, false, true, true, false, false);

        }

        private void ConfigurarTicket(string folio,string idTicketAUsar)
        {
            this.folio = string.Format("{0:D12}", int.Parse(folio));
            if (configuracionPV != null)
                anchoTicket = int.Parse(configuracionPV.AnchoTicket) * 10;
            else
                anchoTicket = int.Parse(configuracionBO.AnchoTicket) * 10;

            ticket = new FlowLayoutPanel();
            ticket.Width = anchoTicket;
            ticket.AutoSize = true;
            ticket.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ticket.WrapContents = true;
            ticket.FlowDirection = FlowDirection.TopDown;
            ticket.Padding = new Padding(0);
            ticket.BackColor = Color.White;

            ConfiguracionGlobal obcg = new ConfiguracionGlobal();
            datosEmpresa = obcg.ObtenerDatosEmpresa();

            datosTicket = obcg.ObtenerConfiguracionTicket(idTicketAUsar);

        }

        private void IncluirLogo()
        {
            //Logo
            if (datosTicket.incluirLogo)
            {
                //Imagen
                PictureBox img = new PictureBox();
                Image i = datosEmpresa.logotipo;
                img.SizeMode = PictureBoxSizeMode.CenterImage;

                int anchoO = i.Width;
                int altoO = i.Height;

                int anchoN = (int)(anchoTicket * 0.9);

                int factorCrecimiento = anchoN * 100 / anchoO;
                int altoN = factorCrecimiento * altoO / 100;

                //img.Left = (anchoTicket - img.Width) / 2;
                Bitmap objBitmap = new Bitmap(i, new Size(anchoN, altoN));
                img.Image = objBitmap;
                img.MinimumSize = new Size(anchoTicket, altoN);
                img.MaximumSize = new Size(anchoTicket, altoN);
                img.Height = altoN;
                img.Width = anchoTicket;
                img.Left = 0;

                ticket.Controls.Add(img);
            }
        }

        private void IncluirEspacio()
        {
            //Espacio
            Label lblEspacio = new Label();
            lblEspacio.Text = " ";
            lblEspacio.AutoSize = true;
            lblEspacio.MinimumSize = new Size(anchoTicket, 0);
            lblEspacio.MaximumSize = new Size(anchoTicket, 0);
            lblEspacio.Width = anchoTicket;
            lblEspacio.Left = 0;
            lblEspacio.TextAlign = ContentAlignment.MiddleCenter;
            lblEspacio.Font = fontB;
            ticket.Controls.Add(lblEspacio);
        }
        
        private void IncluirDatosEmpresa()
        {
            if (datosTicket.incluirRFC)
            {
                Label lblRFC = new Label();
                lblRFC.Text = "R.F.C. " + datosEmpresa.rfc;
                lblRFC.AutoSize = true;
                lblRFC.MinimumSize = new Size(anchoTicket, 0);
                lblRFC.MaximumSize = new Size(anchoTicket, 0);
                lblRFC.Width = anchoTicket;
                lblRFC.Left = 0;
                lblRFC.TextAlign = ContentAlignment.MiddleCenter;
                lblRFC.Font = fontB;
                lblRFC.Margin = new Padding(0);
                ticket.Controls.Add(lblRFC);
            }

            if (datosTicket.incluirDireccion)
            {
                Label lblDireccion = new Label();
                lblDireccion.Text = datosEmpresa.domicilio + ", " + datosEmpresa.colonia + ", " + datosEmpresa.ciudad + ", " + datosEmpresa.estado + ", " + datosEmpresa.CP;
                lblDireccion.AutoSize = true;
                lblDireccion.MinimumSize = new Size(anchoTicket, 0);
                lblDireccion.MaximumSize = new Size(anchoTicket, 0);
                lblDireccion.Width = anchoTicket;
                lblDireccion.Left = 0;
                lblDireccion.TextAlign = ContentAlignment.MiddleCenter;
                lblDireccion.Font = fontB;
                lblDireccion.Margin = new Padding(0);
                ticket.Controls.Add(lblDireccion);
            }

            if (datosTicket.incluirCorreoElectronico)
            {
                Label lblCorreo = new Label();
                lblCorreo.Text = "Correo: " + datosEmpresa.correo;
                lblCorreo.AutoSize = true;
                lblCorreo.MinimumSize = new Size(anchoTicket, 0);
                lblCorreo.MaximumSize = new Size(anchoTicket, 0);
                lblCorreo.Width = anchoTicket;
                lblCorreo.Left = 0;
                lblCorreo.TextAlign = ContentAlignment.MiddleCenter;
                lblCorreo.Font = fontB;
                lblCorreo.Margin = new Padding(0);
                ticket.Controls.Add(lblCorreo);
            }

            if (datosTicket.incluirTelefono)
            {
                Label lblTelefono = new Label();
                lblTelefono.Text = "Telefono: " + datosEmpresa.telefono1;
                lblTelefono.AutoSize = true;
                lblTelefono.MinimumSize = new Size(anchoTicket, 0);
                lblTelefono.MaximumSize = new Size(anchoTicket, 0);
                lblTelefono.Width = anchoTicket;
                lblTelefono.Left = 0;
                lblTelefono.TextAlign = ContentAlignment.MiddleCenter;
                lblTelefono.Font = fontB;
                lblTelefono.Margin = new Padding(0);
                ticket.Controls.Add(lblTelefono);
            }

            IncluirEspacio();

        }

        private void IncluirDatosFactura()
        {
            if (datosFactura != null)
            {
                IncluirTitulo("Factura");

                //Datos del cliente al que se facturo
                Label lblNombre = new Label();
                lblNombre.Text = "Nombre receptor: " + datosFactura.nombreReceptor;
                lblNombre.AutoSize = true;
                lblNombre.MinimumSize = new Size(anchoTicket, 0);
                lblNombre.MaximumSize = new Size(anchoTicket, 0);
                lblNombre.Width = anchoTicket;
                lblNombre.Left = 0;
                lblNombre.TextAlign = ContentAlignment.MiddleLeft;
                lblNombre.Font = font;
                lblNombre.Margin = new Padding(0);
                ticket.Controls.Add(lblNombre);

                Label lblRFC = new Label();
                lblRFC.Text = "RFC receptor: " + datosFactura.rfcReceptor;
                lblRFC.AutoSize = true;
                lblRFC.MinimumSize = new Size(anchoTicket, 0);
                lblRFC.MaximumSize = new Size(anchoTicket, 0);
                lblRFC.Width = anchoTicket;
                lblRFC.Left = 0;
                lblRFC.TextAlign = ContentAlignment.MiddleLeft;
                lblRFC.Font = font;
                lblRFC.Margin = new Padding(0);
                ticket.Controls.Add(lblRFC);

                Label lblUso = new Label();
                lblUso.Text = "Uso CFDI: " + datosFactura.usoCFDI;
                lblUso.AutoSize = true;
                lblUso.MinimumSize = new Size(anchoTicket, 0);
                lblUso.MaximumSize = new Size(anchoTicket, 0);
                lblUso.Width = anchoTicket;
                lblUso.Left = 0;
                lblUso.TextAlign = ContentAlignment.MiddleLeft;
                lblUso.Font = font;
                lblUso.Margin = new Padding(0);
                ticket.Controls.Add(lblUso);

                Label lblFolioFiscal = new Label();
                lblFolioFiscal.Text = "Folio fiscal: " + datosFactura.UUID;
                lblFolioFiscal.AutoSize = true;
                lblFolioFiscal.MinimumSize = new Size(anchoTicket, 0);
                lblFolioFiscal.MaximumSize = new Size(anchoTicket, 0);
                lblFolioFiscal.Width = anchoTicket;
                lblFolioFiscal.Left = 0;
                lblFolioFiscal.TextAlign = ContentAlignment.MiddleLeft;
                lblFolioFiscal.Font = font;
                lblFolioFiscal.Margin = new Padding(0);
                ticket.Controls.Add(lblFolioFiscal);

                Label lblFechaEmision = new Label();
                lblFechaEmision.Text = "Fecha emision: " + datosFactura.fechaEmision;
                lblFechaEmision.AutoSize = true;
                lblFechaEmision.MinimumSize = new Size(anchoTicket, 0);
                lblFechaEmision.MaximumSize = new Size(anchoTicket, 0);
                lblFechaEmision.Width = anchoTicket;
                lblFechaEmision.Left = 0;
                lblFechaEmision.TextAlign = ContentAlignment.MiddleLeft;
                lblFechaEmision.Font = font;
                lblFechaEmision.Margin = new Padding(0);
                ticket.Controls.Add(lblFechaEmision);

                Label lblNoCertificado = new Label();
                lblNoCertificado.Text = "No. Certificado Digital: " + datosFactura.noCertificadoEmisor;
                lblNoCertificado.AutoSize = true;
                lblNoCertificado.MinimumSize = new Size(anchoTicket, 0);
                lblNoCertificado.MaximumSize = new Size(anchoTicket, 0);
                lblNoCertificado.Width = anchoTicket;
                lblNoCertificado.Left = 0;
                lblNoCertificado.TextAlign = ContentAlignment.MiddleLeft;
                lblNoCertificado.Font = font;
                lblNoCertificado.Margin = new Padding(0);
                ticket.Controls.Add(lblNoCertificado);

                Label lblNoCertificadoSat = new Label();
                lblNoCertificadoSat.Text = "Número de Serie Certificado del SAT: " + datosFactura.noCertificadoSat;
                lblNoCertificadoSat.AutoSize = true;
                lblNoCertificadoSat.MinimumSize = new Size(anchoTicket, 0);
                lblNoCertificadoSat.MaximumSize = new Size(anchoTicket, 0);
                lblNoCertificadoSat.Width = anchoTicket;
                lblNoCertificadoSat.Left = 0;
                lblNoCertificadoSat.TextAlign = ContentAlignment.MiddleLeft;
                lblNoCertificadoSat.Font = font;
                lblNoCertificadoSat.Margin = new Padding(0);
                ticket.Controls.Add(lblNoCertificadoSat);

                IncluirEspacio();
            }
        }

        private void IncluirCodigoFactura()
        {
            if (datosFactura != null)
            {
                //QR
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode("https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?id=" + datosFactura.UUID + "&re=" + datosFactura.rfcEmisor + "&rr=" + datosFactura.rfcReceptor + "&tt=" + datosFactura.total + "&fe=" + datosFactura.selloDigital.Substring(datosFactura.selloDigital.Length - 8, 8), QRCodeGenerator.ECCLevel.M);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);

                PictureBox codigoQR = new PictureBox();
                codigoQR.Image = new Bitmap(qrCodeImage, new Size(anchoTicket / 2, anchoTicket / 2));
                codigoQR.SizeMode = PictureBoxSizeMode.CenterImage;
                //codigoQR.MinimumSize = new Size(anchoTicket/2, anchoTicket / 2);
                //codigoQR.MaximumSize = new Size(anchoTicket / 2, anchoTicket / 2);
                //codigoQR.Height = anchoTicket / 2;
                //codigoQR.Width = anchoTicket;
                //codigoQR.Left = anchoTicket / 4;

                codigoQR.MinimumSize = new Size(anchoTicket, codigoQR.Image.Height);
                codigoQR.MaximumSize = new Size(anchoTicket, codigoQR.Image.Height);
                codigoQR.Height = codigoQR.Image.Height;
                codigoQR.Width = anchoTicket;
                codigoQR.Left = 0;

                ticket.Controls.Add(codigoQR);

                Label lblSello = new Label();
                lblSello.Text = "Sello Digital del CFDI: ";
                lblSello.AutoSize = true;
                lblSello.MinimumSize = new Size(anchoTicket, 0);
                lblSello.MaximumSize = new Size(anchoTicket, 0);
                lblSello.Width = anchoTicket;
                lblSello.Left = 0;
                lblSello.TextAlign = ContentAlignment.MiddleLeft;
                lblSello.Font = font_1;
                lblSello.Margin = new Padding(0);
                ticket.Controls.Add(lblSello);

                Label lblSello2 = new Label();
                lblSello2.Text = datosFactura.selloDigital;
                lblSello2.AutoSize = true;
                lblSello2.MinimumSize = new Size(anchoTicket, 0);
                lblSello2.MaximumSize = new Size(anchoTicket, 0);
                lblSello2.Width = anchoTicket;
                lblSello2.Left = 0;
                lblSello2.TextAlign = ContentAlignment.MiddleLeft;
                lblSello2.Font = font;
                lblSello2.Margin = new Padding(0);
                ticket.Controls.Add(lblSello2);

                Label lblSelloSat = new Label();
                lblSelloSat.Text = "Sello Digital del SAT:";
                lblSelloSat.AutoSize = true;
                lblSelloSat.MinimumSize = new Size(anchoTicket, 0);
                lblSelloSat.MaximumSize = new Size(anchoTicket, 0);
                lblSelloSat.Width = anchoTicket;
                lblSelloSat.Left = 0;
                lblSelloSat.TextAlign = ContentAlignment.MiddleLeft;
                lblSelloSat.Font = font_1;
                lblSelloSat.Margin = new Padding(0);
                ticket.Controls.Add(lblSelloSat);

                Label lblSelloSat2 = new Label();
                lblSelloSat2.Text = datosFactura.selloDigitalSAT;
                lblSelloSat2.AutoSize = true;
                lblSelloSat2.MinimumSize = new Size(anchoTicket, 0);
                lblSelloSat2.MaximumSize = new Size(anchoTicket, 0);
                lblSelloSat2.Width = anchoTicket;
                lblSelloSat2.Left = 0;
                lblSelloSat2.TextAlign = ContentAlignment.MiddleLeft;
                lblSelloSat2.Font = font;
                lblSelloSat2.Margin = new Padding(0);
                ticket.Controls.Add(lblSelloSat2);

                Label lblCadenaComplemento = new Label();
                lblCadenaComplemento.Text = "Cadena Original del complemento de Certificacion Digital del SAT:";
                lblCadenaComplemento.AutoSize = true;
                lblCadenaComplemento.MinimumSize = new Size(anchoTicket, 0);
                lblCadenaComplemento.MaximumSize = new Size(anchoTicket, 0);
                lblCadenaComplemento.Width = anchoTicket;
                lblCadenaComplemento.Left = 0;
                lblCadenaComplemento.TextAlign = ContentAlignment.MiddleLeft;
                lblCadenaComplemento.Font = font_1;
                lblCadenaComplemento.Margin = new Padding(0);
                ticket.Controls.Add(lblCadenaComplemento);

                Label lblCadenaComplemento2 = new Label();
                lblCadenaComplemento2.Text = datosFactura.cadenaComplementoSat;
                lblCadenaComplemento2.AutoSize = true;
                lblCadenaComplemento2.MinimumSize = new Size(anchoTicket, 0);
                lblCadenaComplemento2.MaximumSize = new Size(anchoTicket, 0);
                lblCadenaComplemento2.Width = anchoTicket;
                lblCadenaComplemento2.Left = 0;
                lblCadenaComplemento2.TextAlign = ContentAlignment.MiddleLeft;
                lblCadenaComplemento2.Font = font;
                lblCadenaComplemento2.Margin = new Padding(0);
                ticket.Controls.Add(lblCadenaComplemento2);

                IncluirEspacio();

                Label lblLeyenda = new Label();
                lblLeyenda.Text = "Este documento es una representación impresa de un CFDI.";
                lblLeyenda.AutoSize = true;
                lblLeyenda.MinimumSize = new Size(anchoTicket, 0);
                lblLeyenda.MaximumSize = new Size(anchoTicket, 0);
                lblLeyenda.Width = anchoTicket;
                lblLeyenda.Left = 0;
                lblLeyenda.TextAlign = ContentAlignment.MiddleCenter;
                lblLeyenda.Font = font;
                lblLeyenda.Margin = new Padding(0);
                ticket.Controls.Add(lblLeyenda);

            }
        }

        private void IncluirDatosEmpresaCorte()
        {
            
            Label lblRFC = new Label();
            lblRFC.Text = "R.F.C. " + datosEmpresa.rfc;
            lblRFC.AutoSize = true;
            lblRFC.MinimumSize = new Size(anchoTicket, 0);
            lblRFC.MaximumSize = new Size(anchoTicket, 0);
            lblRFC.Width = anchoTicket;
            lblRFC.Left = 0;
            lblRFC.TextAlign = ContentAlignment.MiddleCenter;
            lblRFC.Font = fontB;
            lblRFC.Margin = new Padding(0);
            ticket.Controls.Add(lblRFC);
            

            
            Label lblDireccion = new Label();
            lblDireccion.Text = datosEmpresa.domicilio + ", " + datosEmpresa.colonia + ", " + datosEmpresa.ciudad + ", " + datosEmpresa.estado + ", " + datosEmpresa.CP;
            lblDireccion.AutoSize = true;
            lblDireccion.MinimumSize = new Size(anchoTicket, 0);
            lblDireccion.MaximumSize = new Size(anchoTicket, 0);
            lblDireccion.Width = anchoTicket;
            lblDireccion.Left = 0;
            lblDireccion.TextAlign = ContentAlignment.MiddleCenter;
            lblDireccion.Font = fontB;
            lblDireccion.Margin = new Padding(0);
            ticket.Controls.Add(lblDireccion);

            IncluirEspacio();

        }

        private void IncluirDatosTicket(int tipoTicket)
        {
            FlowLayoutPanel panelDatosTicket = new FlowLayoutPanel();
            panelDatosTicket.Width = anchoTicket;
            panelDatosTicket.AutoSize = true;
            panelDatosTicket.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelDatosTicket.WrapContents = true;
            panelDatosTicket.FlowDirection = FlowDirection.LeftToRight;
            panelDatosTicket.Padding = new Padding(0);
            panelDatosTicket.BackColor = Color.White;

            FlowLayoutPanel panelDatosTicketIzquierda = new FlowLayoutPanel();
            panelDatosTicketIzquierda.Width = anchoTicket;
            panelDatosTicketIzquierda.AutoSize = true;
            panelDatosTicketIzquierda.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelDatosTicketIzquierda.WrapContents = true;
            panelDatosTicketIzquierda.FlowDirection = FlowDirection.TopDown;
            panelDatosTicketIzquierda.Padding = new Padding(0);
            panelDatosTicketIzquierda.BackColor = Color.White;

            //Folio
            Label lblFolio = new Label();
            switch (tipoTicket) 
            {
                case 1://Venta
                    lblFolio.Text = "Ticket: " + folio;
                    break;
                case 2://Corte
                case 4://Corte
                    lblFolio.Text = "Turno: " + folio;
                    break;
                case 3://Abono
                    lblFolio.Text = "Abono: " + folio;
                    break;
            }
            lblFolio.AutoSize = true;
            lblFolio.MinimumSize = new Size(300, 0);
            lblFolio.MaximumSize = new Size(300, 0);
            lblFolio.Width = 300;
            lblFolio.Left = anchoTicket - 300;
            lblFolio.TextAlign = ContentAlignment.MiddleRight;
            lblFolio.Font = fontB;

            if (datosTicket.incluirCaja)
            {
                Label lblCaja = new Label();
                if (configuracionPV!=null)
                    lblCaja.Text = "Caja: " + configuracionPV.NombreCaja;
                else
                    lblCaja.Text = "BackOffice";
                lblCaja.AutoSize = true;
                lblCaja.MinimumSize = new Size(anchoTicket - lblFolio.Width, 0);
                lblCaja.MaximumSize = new Size(anchoTicket - lblFolio.Width, 0);
                lblCaja.Width = anchoTicket - lblFolio.Width;
                lblCaja.Left = 0;
                lblCaja.TextAlign = ContentAlignment.MiddleLeft;
                lblCaja.Font = font;
                lblCaja.Margin = new Padding(0);
                panelDatosTicketIzquierda.Controls.Add(lblCaja);
            }

            if (datosTicket.incluirEmpleado)
            {
                Label lblUsuario = new Label();
                switch (tipoTicket)
                {
                    case 1://Venta
                    case 3://Abono
                        lblUsuario.Text = "Cajero: " + usuario.IDUsuario;
                        break;
                    case 2://Corte
                    case 4://Corte
                        lblUsuario.Text = "Cajero: " + usuario.Nombres + " " + usuario.Apellidos;
                        break;
                    
                }

                lblUsuario.AutoSize = true;
                lblUsuario.MinimumSize = new Size(anchoTicket - lblFolio.Width, 0);
                lblUsuario.MaximumSize = new Size(anchoTicket - lblFolio.Width, 0);
                lblUsuario.Width = anchoTicket - lblFolio.Width;
                lblUsuario.Left = 0;
                lblUsuario.TextAlign = ContentAlignment.MiddleLeft;
                lblUsuario.Font = font;
                lblUsuario.Margin = new Padding(0);
                panelDatosTicketIzquierda.Controls.Add(lblUsuario);
            }

            

            
            
            //Fecha
            Label lblFecha = new Label();
            if(fecha==null)
                lblFecha.Text = "Fecha: " + DateTime.Now;
            else
                lblFecha.Text = "Fecha: " + fecha;
            lblFecha.AutoSize = true;
            lblFecha.MinimumSize = new Size(anchoTicket - lblFolio.Width, 0);
            lblFecha.MaximumSize = new Size(anchoTicket - lblFolio.Width, 0);
            lblFecha.Width = anchoTicket - lblFolio.Width;
            lblFecha.Left = 0;
            lblFecha.TextAlign = ContentAlignment.MiddleLeft;
            lblFecha.Font = font;
            lblFecha.Margin = new Padding(0);
            panelDatosTicketIzquierda.Controls.Add(lblFecha);
            
            if (tipoTicket == 2)
            {
                Programacion.Corte obc = new Programacion.Corte();

                string[] datosTurno = obc.ObtenerDatosCorte(folio);

                //Fecha inicio
                Label lblFechaInicio = new Label();
                lblFechaInicio.Text = "Fecha inicio: " + DateTime.Parse(datosTurno[3]).ToString("dd/MM/yyyy h:mm tt") + "";
                lblFechaInicio.AutoSize = true;
                lblFechaInicio.MinimumSize = new Size(anchoTicket - lblFolio.Width, 0);
                lblFechaInicio.MaximumSize = new Size(anchoTicket - lblFolio.Width, 0);
                lblFechaInicio.Width = anchoTicket - lblFolio.Width;
                lblFechaInicio.Left = 0;
                lblFechaInicio.TextAlign = ContentAlignment.MiddleLeft;
                lblFechaInicio.Font = font;
                lblFechaInicio.Margin = new Padding(0);
                panelDatosTicketIzquierda.Controls.Add(lblFechaInicio);

                //Fecha cierre
                Label lblFechaCierre = new Label();
                lblFechaCierre.Text = "Fecha cierre: " + DateTime.Parse(datosTurno[6]).ToString("dd/MM/yyyy h:mm tt") + "";
                lblFechaCierre.AutoSize = true;
                lblFechaCierre.MinimumSize = new Size(anchoTicket - lblFolio.Width, 0);
                lblFechaCierre.MaximumSize = new Size(anchoTicket - lblFolio.Width, 0);
                lblFechaCierre.Width = anchoTicket - lblFolio.Width;
                lblFechaCierre.Left = 0;
                lblFechaCierre.TextAlign = ContentAlignment.MiddleLeft;
                lblFechaCierre.Font = font;
                lblFechaCierre.Margin = new Padding(0);
                panelDatosTicketIzquierda.Controls.Add(lblFechaCierre);
            }

            if (cliente != null)
            {
                //Nombre del cliente
                Label lblNombreCliente = new Label();
                lblNombreCliente.Text = "Cliente: " + cliente.nombre + " " + cliente.apellidos;
                lblNombreCliente.AutoSize = true;
                lblNombreCliente.MinimumSize = new Size(anchoTicket - lblFolio.Width, 0);
                lblNombreCliente.MaximumSize = new Size(anchoTicket - lblFolio.Width, 0);
                lblNombreCliente.Width = anchoTicket - lblFolio.Width;
                lblNombreCliente.Left = 0;
                lblNombreCliente.TextAlign = ContentAlignment.MiddleLeft;
                lblNombreCliente.Font = fontB;
                lblNombreCliente.Margin = new Padding(0);
                panelDatosTicketIzquierda.Controls.Add(lblNombreCliente);
            }

            panelDatosTicket.Controls.Add(panelDatosTicketIzquierda);

            panelDatosTicket.Controls.Add(lblFolio);

            ticket.Controls.Add(panelDatosTicket);
            if(tipoTicket != 2)
                IncluirEspacio();
        }

        private void IncluirTitulo(string titulo)
        {
            //Leyenda cotizacion
            Label lblTitulo = new Label();
            if(titulo.Length>0)
                lblTitulo.Text = "-- " + titulo + " --";
            else
            {
                for (int x = 0; x < lblTitulo.Width/2; x++)
                    lblTitulo.Text += "-";

            }

            lblTitulo.AutoSize = true;
            lblTitulo.MinimumSize = new Size(anchoTicket, 0);
            lblTitulo.MaximumSize = new Size(anchoTicket, 0);
            lblTitulo.Width = anchoTicket;
            lblTitulo.Left = 0;
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Font = fontB2;
            lblTitulo.Margin = new Padding(5, 25, 5, 25);
            ticket.Controls.Add(lblTitulo);
        }

        private void IncluirMensajeCabecera()
        {
            if (datosTicket.incluirMensajeCabecera)
            {
                Label lblMensajeCabecera = new Label();
                lblMensajeCabecera.Text = datosTicket.mensajeCabecera;
                lblMensajeCabecera.AutoSize = true;
                lblMensajeCabecera.MinimumSize = new Size(anchoTicket, 0);
                lblMensajeCabecera.MaximumSize = new Size(anchoTicket, 0);
                lblMensajeCabecera.Width = anchoTicket;
                lblMensajeCabecera.Left = 0;
                lblMensajeCabecera.TextAlign = ContentAlignment.MiddleCenter;
                lblMensajeCabecera.Font = fontB;
                ticket.Controls.Add(lblMensajeCabecera);

                IncluirEspacio();
            }
        }
       
        private void IncluirTablaProductos()
        {
            //Tabla de productos
            DataGridView dgv = GenerarTablaTicket(anchoTicket, fontB0, fontB0_1);
            Panel p = new Panel();
            p.AutoSize = true;
            p.MinimumSize = new Size(anchoTicket + 4, 0);
            p.MaximumSize = new Size(anchoTicket + 4, 0);
            p.Controls.Add(dgv);
            p.Left = -2;
            ticket.Controls.Add(p);
        }
        private DataGridView GenerarTablaTicket(int anchoTicket, Font font, Font fontNegritas)
        {
            DataGridView dgvP = new DataGridView();

            dgvP.ColumnCount = 4;

            dgvP.Columns[0].Name = "Cant.";
            dgvP.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvP.Columns[0].Width = 90;
            dgvP.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;

            dgvP.Columns[1].Name = "Articulo";
            dgvP.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
            dgvP.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            dgvP.Columns[2].Name = "Precio";
            dgvP.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvP.Columns[2].Width = 120;
            dgvP.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            dgvP.Columns[3].Name = "Importe";
            dgvP.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvP.Columns[3].Width = 120;
            dgvP.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            
            //if(indicesCajas != null)
            // if (indicesCajas.Count < 1)
            //    dgvP.Columns[0].Visible = false;

            //new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvP, false, false);

            //Formato
            //dgvP.Width = anchoTicket;
            dgvP.Dock = DockStyle.Fill;
            dgvP.RowHeadersVisible = false;
            dgvP.BackgroundColor = Color.White; ;
            dgvP.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvP.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvP.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            dgvP.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvP.EnableHeadersVisualStyles = false;
            dgvP.ColumnHeadersDefaultCellStyle.Font = font;
            dgvP.DefaultCellStyle.Font = font;
            dgvP.BorderStyle = BorderStyle.None;
            dgvP.GridColor = Color.White;
            dgvP.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvP.DefaultCellStyle.BackColor = Color.White;
            dgvP.RowsDefaultCellStyle.SelectionBackColor = Color.Transparent;
            dgvP.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
            dgvP.AutoSize = true;

            //Linea punteada
            dgvP.CellPainting += paintCeldaPersonalizada;


            //Para que las celdas se adapten al texto de un producto
            dgvP.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvP.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvP.MultiSelect = false;
            //dgvP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvP.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            foreach (DataGridViewColumn dgvc in dgvP.Columns)
            {
                dgvc.ReadOnly = true;
            }
            dgvP.AllowUserToAddRows = false;
            dgvP.AllowUserToDeleteRows = false;
            dgvP.AllowUserToResizeRows = false;


            foreach (DataGridViewRow renglon in dgvProductos.Rows)
            {
                decimal cant;
                string c = "";

                try
                {
                    cant = decimal.Parse(renglon.Cells[0].Value + "");
                    if (cant % 1 == 0)
                        c = decimal.ToInt32(cant) + "";
                    else
                        c = cant + "";
                }
                catch
                {
                    c = renglon.Cells[0].Value + "";
                }

               

                dgvP.Rows.Add(c, renglon.Cells[1].Value + "", renglon.Cells[2].Value + "", renglon.Cells[3].Value + "");
            }


            //Remarcar los indicados
            if (indicesRemarcar != null)
            {
                foreach(int i in indicesRemarcar)
                {
                    dgvP.Rows[i].DefaultCellStyle.Font = fontNegritas;
                }
            }

            //Poner las cajas
            if (indicesCajas != null)
            {
                if (indicesCajas.Count > 0)
                {
                    DataGridViewImageColumn col = new DataGridViewImageColumn();
                    col.Width = 70;
                    col.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    dgvP.Columns.Insert(0, col);
                    dgvP.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                    for (int i = 0; i < dgvProductos.Rows.Count; i++)
                    {
                        Image img = ObtenerImagenCaja(0,0);
                        dgvP.Rows[i].Cells[0].Value = img;
                    }

                    foreach (int[] i in indicesCajas)
                    {
                        Image img = ObtenerImagenCaja(i[1], i[2]);
                        dgvP.Rows[i[0]].Cells[0].Value = img;
                    }
                }
            }

            dgvP.CurrentCell = null;

           
            return dgvP;
        }

        private Image ObtenerImagenCaja(int cant, int piezasPorCaja)
        {


            if (cant > 0)
            {
                Image img = Properties.Resources.cajaTicket100;

                Panel p = new Panel();
                p.Width = 100;
                p.Height = 112;
                p.BackColor = Color.White;

                PictureBox pb = new PictureBox();
                pb.Image = img;
                pb.Size = new Size(90, 90);
                // pb.Margin = new Padding(0, 0, 0, 10);
                pb.Dock = DockStyle.Fill;

                pb.Paint += new PaintEventHandler((sender, e) =>
                {
                    e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                    SizeF textSize = e.Graphics.MeasureString(cant + "", fontB2_1);
                    PointF locationToDraw = new PointF();
                    locationToDraw.X = (pb.Width / 2) - (textSize.Width / 2) - 7;
                    locationToDraw.Y = (pb.Height / 2) - (textSize.Height / 2) + 13;

                    e.Graphics.DrawString(cant + "", fontB2_1, Brushes.Black, locationToDraw);

                    textSize = e.Graphics.MeasureString(piezasPorCaja + " pzas.", font_1);
                    locationToDraw = new PointF();
                    locationToDraw.X = (pb.Width / 2) - (textSize.Width / 2);
                    locationToDraw.Y = (pb.Height) - (textSize.Height) + 2;

                    e.Graphics.DrawString(piezasPorCaja + " pzas.", font_1, Brushes.Black, locationToDraw);
                });

                p.Controls.Add(pb);

                Bitmap b = new Bitmap(p.Width, p.Height);
                p.DrawToBitmap(b, new Rectangle(0, 0, b.Width, b.Height));


                return b;
            }
            else
                return Properties.Resources.blanco100;
        }

        private void paintCeldaPersonalizada(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.PaintBackground(e.ClipBounds, true);
            e.PaintContent(e.ClipBounds);

            if (e.RowIndex == -1)
            {
                if (e.ColumnIndex == 0 && indicesCajas != null)
                {
                    e.AdvancedBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
                    e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                    e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                }
                else
                {
                    using (Pen p = new Pen(Brushes.Black, 4))
                    {
                        //p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        e.Graphics.DrawRectangle(p, new Rectangle(e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Right, e.CellBounds.Bottom));
                    }
                }
            }
            else
            {
                if (e.ColumnIndex == 0 && e.RowIndex > -1 && indicesCajas != null)
                {
                    e.AdvancedBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
                    e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                    e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                }
                else
                {
                    using (Pen p = new Pen(Brushes.Black, 4))
                    {
                        p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        e.Graphics.DrawLine(p, new Point(e.CellBounds.Left, e.CellBounds.Bottom),
                                               new Point(e.CellBounds.Right, e.CellBounds.Bottom));
                    }

                    using (Pen p2 = new Pen(Brushes.Black, 2))
                    {
                        //p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        //e.Graphics.DrawLine(p2, new Point(e.CellBounds.Right, e.CellBounds.Top),
                        //new Point(e.CellBounds.Right, e.CellBounds.Bottom));
                        if ((e.ColumnIndex != 1 && indicesCajas != null) || (e.ColumnIndex != 0 && indicesCajas == null))
                            e.Graphics.DrawLine(p2, new Point(e.CellBounds.Left, e.CellBounds.Top),
                                               new Point(e.CellBounds.Left, e.CellBounds.Bottom));

                    }
                }
            }
            e.Handled = true;
        }

        private void IncluirTotales(int tipoTicket,decimal total, decimal pagoCon,decimal cambio, string referencia,int formaPago)
        {
            //Total y Pago con
            FlowLayoutPanel pt = new FlowLayoutPanel();
            pt.FlowDirection = FlowDirection.LeftToRight;

            //Si fue faturado mostrar el total de cada impuesto cobrado
            if (datosFactura != null)
            {
                decimal subtotal = datosFactura.total;
                var sortedDict = from entry in datosFactura.impuestos orderby entry.Key ascending select entry;

                foreach (KeyValuePair<string, decimal> entry in sortedDict)
                {
                    subtotal -= entry.Value;
                }

                Label lblSubTotal = new Label();
                lblSubTotal.Text = "Subtotal: " + string.Format("{0:C}", subtotal);
                lblSubTotal.AutoSize = true;
                lblSubTotal.MinimumSize = new Size(anchoTicket, 0);
                lblSubTotal.MaximumSize = new Size(anchoTicket, 0);
                lblSubTotal.Width = anchoTicket / 2;
                lblSubTotal.Left = 0;
                lblSubTotal.TextAlign = ContentAlignment.MiddleLeft;
                lblSubTotal.Margin = new Padding(5, 10, 5, 10);
                lblSubTotal.Font = font;
                ticket.Controls.Add(lblSubTotal);

                foreach (KeyValuePair<string, decimal> entry in datosFactura.impuestos)
                {
                    Label lblImpuesto = new Label();
                    lblImpuesto.Text = entry.Key + string.Format("{0:C}", entry.Value);
                    lblImpuesto.AutoSize = true;
                    lblImpuesto.MinimumSize = new Size(anchoTicket, 0);
                    lblImpuesto.MaximumSize = new Size(anchoTicket, 0);
                    lblImpuesto.Width = anchoTicket / 2;
                    lblImpuesto.Left = 0;
                    lblImpuesto.TextAlign = ContentAlignment.MiddleLeft;
                    lblImpuesto.Margin = new Padding(5, 10, 5, 10);
                    lblImpuesto.Font = font;
                    ticket.Controls.Add(lblImpuesto);
                }

                //El total solo si es direfente del cobrado
                if(total != datosFactura.total)
                {
                    Label lblTotalFactura = new Label();
                    lblTotalFactura.Text = "Total Factura: " + string.Format("{0:C}", datosFactura.total);
                    lblTotalFactura.AutoSize = true;
                    lblTotalFactura.MinimumSize = new Size(anchoTicket, 0);
                    lblTotalFactura.MaximumSize = new Size(anchoTicket, 0);
                    lblTotalFactura.Width = anchoTicket / 2;
                    lblTotalFactura.Left = 0;
                    lblTotalFactura.TextAlign = ContentAlignment.MiddleLeft;
                    lblTotalFactura.Margin = new Padding(5, 10, 5, 10);
                    lblTotalFactura.Font = font;
                    ticket.Controls.Add(lblTotalFactura);
                }
            }

            Label lblTotal = new Label();
            lblTotal.Text = "Total: " + string.Format("{0:C}", total);
            lblTotal.AutoSize = true;
            lblTotal.MinimumSize = new Size(anchoTicket, 0);
            lblTotal.MaximumSize = new Size(anchoTicket, 0);
            lblTotal.Width = anchoTicket / 2;
            lblTotal.Left = 0;
            lblTotal.TextAlign = ContentAlignment.MiddleLeft;
            lblTotal.Margin = new Padding(5, 10, 5, 10);
            lblTotal.Font = fontB1;
            ticket.Controls.Add(lblTotal);


            if (tipoTicket != 2)
            {
                if (pagoCon != -1 && cambio != -1)
                {
                    if (tipoTicket == 1)
                    {
                        FlowLayoutPanel panelPagoCon = new FlowLayoutPanel();
                        panelPagoCon.Width = anchoTicket;
                        panelPagoCon.AutoSize = true;
                        panelPagoCon.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                        panelPagoCon.WrapContents = true;
                        panelPagoCon.FlowDirection = FlowDirection.LeftToRight;
                        panelPagoCon.Padding = new Padding(0);
                        panelPagoCon.BackColor = Color.White;

                        Label lblPagoCon = new Label();
                        lblPagoCon.Text = "Su pago: " + string.Format("{0:C}", pagoCon);
                        lblPagoCon.AutoSize = true;
                        lblPagoCon.MinimumSize = new Size(anchoTicket / 2, 0);
                        lblPagoCon.MaximumSize = new Size(anchoTicket / 2, 0);
                        lblPagoCon.Width = anchoTicket / 2;
                        lblPagoCon.Left = 0;
                        lblPagoCon.TextAlign = ContentAlignment.MiddleLeft;
                        lblPagoCon.Font = fontB1;
                        lblPagoCon.Margin = new Padding(5, 5, 5, 5);
                        //ticket.Controls.Add(lblPagoCon);
                        panelPagoCon.Controls.Add(lblPagoCon);

                        //Cambio
                        Label lblCambio = new Label();
                        lblCambio.Text = "Cambio: " + string.Format("{0:C}", cambio);
                        lblCambio.AutoSize = true;
                        lblCambio.MinimumSize = new Size(anchoTicket / 2, 0);
                        lblCambio.MaximumSize = new Size(anchoTicket / 2, 0);
                        lblCambio.Width = anchoTicket / 2;
                        //lblCambio.Left = anchoTicket / 2;
                        lblCambio.TextAlign = ContentAlignment.MiddleRight;
                        lblCambio.Font = fontB2;
                        lblCambio.Margin = new Padding(5, 5, 5, 5);
                        panelPagoCon.Controls.Add(lblCambio);
                        ticket.Controls.Add(panelPagoCon);

                        if (referencia != "")
                        {
                            Label lblReferencia = new Label();
                            if (formaPago == 2)
                                lblReferencia.Text = "Aut.: " + referencia;
                            else
                                lblReferencia.Text = "Ref.: " + referencia;
                            lblReferencia.AutoSize = true;
                            lblReferencia.MinimumSize = new Size(anchoTicket, 0);
                            lblReferencia.MaximumSize = new Size(anchoTicket, 0);
                            lblReferencia.Width = anchoTicket;
                            lblReferencia.Left = 0;
                            lblReferencia.TextAlign = ContentAlignment.MiddleLeft;
                            lblReferencia.Margin = new Padding(5, 10, 5, 10);
                            lblReferencia.Font = fontB1_2;
                            ticket.Controls.Add(lblReferencia);
                        }
                    }
                    else
                    {
                        lblTotal.Font = fontB2;

                        FlowLayoutPanel panelPagoCon = new FlowLayoutPanel();
                        panelPagoCon.Width = anchoTicket;
                        panelPagoCon.AutoSize = true;
                        panelPagoCon.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                        panelPagoCon.WrapContents = true;
                        panelPagoCon.FlowDirection = FlowDirection.LeftToRight;
                        panelPagoCon.Padding = new Padding(0);
                        panelPagoCon.BackColor = Color.White;

                        Label lblPagoCon = new Label();
                        lblPagoCon.Text = "Su pago: " + string.Format("{0:C}", pagoCon);
                        lblPagoCon.AutoSize = true;
                        lblPagoCon.MinimumSize = new Size(anchoTicket / 2, 0);
                        lblPagoCon.MaximumSize = new Size(anchoTicket / 2, 0);
                        lblPagoCon.Width = anchoTicket / 2;
                        lblPagoCon.Left = 0;
                        lblPagoCon.TextAlign = ContentAlignment.MiddleLeft;
                        lblPagoCon.Font = fontB1;
                        lblPagoCon.Margin = new Padding(5, 5, 5, 5);
                        //ticket.Controls.Add(lblPagoCon);
                        panelPagoCon.Controls.Add(lblPagoCon);

                        //Cambio
                        Label lblCambio = new Label();
                        lblCambio.Text = "Cambio: " + string.Format("{0:C}", cambio);
                        lblCambio.AutoSize = true;
                        lblCambio.MinimumSize = new Size(anchoTicket / 2, 0);
                        lblCambio.MaximumSize = new Size(anchoTicket / 2, 0);
                        lblCambio.Width = anchoTicket / 2;
                        //lblCambio.Left = anchoTicket / 2;
                        lblCambio.TextAlign = ContentAlignment.MiddleRight;
                        lblCambio.Font = fontB1;
                        lblCambio.Margin = new Padding(5, 5, 5, 5);
                        panelPagoCon.Controls.Add(lblCambio);
                        ticket.Controls.Add(panelPagoCon);

                        if (referencia != "")
                        {
                            Label lblReferencia = new Label();
                            if(formaPago == 2)
                                lblReferencia.Text = "Aut.: " + referencia;
                            else
                                lblReferencia.Text = "Ref.: " + referencia;
                            lblReferencia.AutoSize = true;
                            lblReferencia.MinimumSize = new Size(anchoTicket, 0);
                            lblReferencia.MaximumSize = new Size(anchoTicket, 0);
                            lblReferencia.Width = anchoTicket;
                            lblReferencia.Left = 0;
                            lblReferencia.TextAlign = ContentAlignment.MiddleLeft;
                            lblReferencia.Margin = new Padding(5, 10, 5, 10);
                            lblReferencia.Font = fontB1_2;
                            ticket.Controls.Add(lblReferencia);
                        }
                    }
                }
            }
            else
                lblTotal.Font = fontB2;

            
        }

        private void IncluirSaldoCliente(int formaPago)
        {
            //Checar si imprimir el saldo actual del cliente
            if (datosTicket.incluirSaldoActual && cliente != null && formaPago == 4)
            {
                Programacion.Clientes obc = new Programacion.Clientes();
                DatosCredito datosCredito = obc.ObtenerCreditoCliente(cliente.idCliente);

                //Saldo actual
                Label lblSaldoActual = new Label();
                lblSaldoActual.Text = "Saldo actual: " + string.Format("{0:C}", datosCredito.saldo);
                lblSaldoActual.AutoSize = true;
                lblSaldoActual.MinimumSize = new Size(anchoTicket, 0);
                lblSaldoActual.MaximumSize = new Size(anchoTicket, 0);
                lblSaldoActual.Width = anchoTicket / 2;
                lblSaldoActual.Left = 0;
                lblSaldoActual.TextAlign = ContentAlignment.MiddleCenter;
                lblSaldoActual.Margin = new Padding(5, 10, 5, 10);
                lblSaldoActual.Font = fontB1;
                ticket.Controls.Add(lblSaldoActual);
            }
        }
        
        private void IncluirFirmaCliente(decimal total, decimal pagoCon, decimal cambio, int noArticulos,int formaPago, bool copiaClienteCredito, string referencia, bool esGastoDeTienda)
        {
            //Checar si requiere firma, si requiere firma debe imprimir otro ticket pero que diga copia del cliente
            if (cliente.requiereFirma && !copiaClienteCredito)
            {
                //Leyenda Copia del negocio
                Label lblCopiaNegocio = new Label();
                lblCopiaNegocio.Text = "Copia del negocio";
                lblCopiaNegocio.AutoSize = true;
                lblCopiaNegocio.MinimumSize = new Size(anchoTicket, 0);
                lblCopiaNegocio.MaximumSize = new Size(anchoTicket, 0);
                lblCopiaNegocio.Width = anchoTicket / 2;
                lblCopiaNegocio.Left = 0;
                lblCopiaNegocio.TextAlign = ContentAlignment.MiddleCenter;
                lblCopiaNegocio.Margin = new Padding(5, 10, 5, 10);
                lblCopiaNegocio.Font = fontB1;
                ticket.Controls.Add(lblCopiaNegocio);

                //Leyenda Firma
                Label lblLeyendaFirma = new Label();
                lblLeyendaFirma.Text = "Firma del cliente:";
                lblLeyendaFirma.AutoSize = true;
                lblLeyendaFirma.MinimumSize = new Size(anchoTicket, 0);
                lblLeyendaFirma.MaximumSize = new Size(anchoTicket, 0);
                lblLeyendaFirma.Width = anchoTicket / 2;
                lblLeyendaFirma.Left = 0;
                lblLeyendaFirma.TextAlign = ContentAlignment.MiddleCenter;
                lblLeyendaFirma.Margin = new Padding(5, 30, 5, 10);
                lblLeyendaFirma.Font = fontB0;
                ticket.Controls.Add(lblLeyendaFirma);

                //Leyenda Firma2
                Label lblLeyendaFirma2 = new Label();
                lblLeyendaFirma2.Text = "_______________________";
                lblLeyendaFirma2.AutoSize = true;
                lblLeyendaFirma2.MinimumSize = new Size(anchoTicket, 0);
                lblLeyendaFirma2.MaximumSize = new Size(anchoTicket, 0);
                lblLeyendaFirma2.Width = anchoTicket / 2;
                lblLeyendaFirma2.Left = 0;
                lblLeyendaFirma2.TextAlign = ContentAlignment.MiddleCenter;
                lblLeyendaFirma2.Margin = new Padding(5, 40, 5, 10);
                lblLeyendaFirma2.Font = fontB1;
                ticket.Controls.Add(lblLeyendaFirma2);

                //Nombre del cliente
                Label lblNombreCliente = new Label();
                lblNombreCliente.Text = cliente.nombre + " " + cliente.apellidos;
                lblNombreCliente.AutoSize = true;
                lblNombreCliente.MinimumSize = new Size(anchoTicket, 0);
                lblNombreCliente.MaximumSize = new Size(anchoTicket, 0);
                lblNombreCliente.Width = anchoTicket / 2;
                lblNombreCliente.Left = 0;
                lblNombreCliente.TextAlign = ContentAlignment.MiddleCenter;
                lblNombreCliente.Margin = new Padding(5, 7, 5, 30);
                lblNombreCliente.Font = fontB0;
                ticket.Controls.Add(lblNombreCliente);

                //Si el cliente ocupa firmar entonces ocupo sacar una copia para el y otra para el negocio, el negocio se queda con el firmado
                //GenerarTicket obt = new GenerarTicket(configuracionPV,configuracionBO,configuracionGlobal,impresoraTickets);
                
                GenerarTicketVenta(false, folio, total, pagoCon, cambio, noArticulos, formaPago, referencia, true, esGastoDeTienda,true);
                impresoraTickets.Print();


            }
        }
    
        private void IncluirAhorro(bool esCotizacion)
        {
            //Ahorro
            if (ahorro > 0)
            {
                Label lblAhorro = new Label();
                if (esCotizacion)
                    lblAhorro.Text = "Usted ahorra: " + string.Format("{0:C}", ahorro) + " comprando en " + datosEmpresa.nombreCorto;
                else
                    lblAhorro.Text = "Usted ahorro: " + string.Format("{0:C}", ahorro) + " comprando en " + datosEmpresa.nombreCorto;

                lblAhorro.AutoSize = true;
                lblAhorro.MinimumSize = new Size(anchoTicket, 0);
                lblAhorro.MaximumSize = new Size(anchoTicket, 0);
                lblAhorro.Width = anchoTicket / 2;
                lblAhorro.Left = 0;
                lblAhorro.TextAlign = ContentAlignment.MiddleLeft;
                lblAhorro.Font = fontB2;
                lblAhorro.Margin = new Padding(5, 10, 5, 10);
                ticket.Controls.Add(lblAhorro);
            }
        }
    
        private void IncluirNumeroArticulos(int noArticulos)
        {
            //No. Articulos
            Label lbNoArticulos = new Label();
            lbNoArticulos.Text = "No. Articulos: ";
            lbNoArticulos.AutoSize = true;
            lbNoArticulos.MinimumSize = new Size(anchoTicket, 0);
            lbNoArticulos.MaximumSize = new Size(anchoTicket, 0);
            lbNoArticulos.Width = anchoTicket;
            lbNoArticulos.Left = 0;
            lbNoArticulos.TextAlign = ContentAlignment.MiddleCenter;
            lbNoArticulos.Font = fontB2;
            lbNoArticulos.Margin = new Padding(5, 10, 5, 10);
            ticket.Controls.Add(lbNoArticulos);

            Label lbNoArticulos2 = new Label();
            lbNoArticulos2.Text = noArticulos + "";
            lbNoArticulos2.AutoSize = true;
            lbNoArticulos2.MinimumSize = new Size(anchoTicket, 0);
            lbNoArticulos2.MaximumSize = new Size(anchoTicket, 0);
            lbNoArticulos2.Width = anchoTicket;
            lbNoArticulos2.Left = 0;
            lbNoArticulos2.TextAlign = ContentAlignment.MiddleCenter;
            lbNoArticulos2.Font = fontB3;
            lbNoArticulos2.Margin = new Padding(5, 10, 5, 10);
            ticket.Controls.Add(lbNoArticulos2);

            IncluirEspacio();
        }

        private void IncluirMensajesPie()
        {
            //Pie
            if (datosTicket.incluirMensajePie1)
            {
                Label lblMensaje = new Label();
                lblMensaje.Text = datosTicket.mensajePie1;
                lblMensaje.AutoSize = true;
                lblMensaje.MinimumSize = new Size(anchoTicket, 0);
                lblMensaje.MaximumSize = new Size(anchoTicket, 0);
                lblMensaje.Width = anchoTicket;
                lblMensaje.Left = 0;
                lblMensaje.TextAlign = ContentAlignment.MiddleCenter;
                lblMensaje.Font = font;
                lblMensaje.Margin = new Padding(0);
                ticket.Controls.Add(lblMensaje);

            }

            if (datosTicket.incluirMensajePie2)
            {
                Label lblMensaje = new Label();
                lblMensaje.Text = datosTicket.mensajePie2;
                lblMensaje.AutoSize = true;
                lblMensaje.MinimumSize = new Size(anchoTicket, 0);
                lblMensaje.MaximumSize = new Size(anchoTicket, 0);
                lblMensaje.Width = anchoTicket;
                lblMensaje.Left = 0;
                lblMensaje.TextAlign = ContentAlignment.MiddleCenter;
                lblMensaje.Font = font;
                lblMensaje.Margin = new Padding(0);
                ticket.Controls.Add(lblMensaje);

            }

            if (datosTicket.incluirMensajePie3)
            {
                Label lblMensaje = new Label();
                lblMensaje.Text = datosTicket.mensajePie3;
                lblMensaje.AutoSize = true;
                lblMensaje.MinimumSize = new Size(anchoTicket, 0);
                lblMensaje.MaximumSize = new Size(anchoTicket, 0);
                lblMensaje.Width = anchoTicket;
                lblMensaje.Left = 0;
                lblMensaje.TextAlign = ContentAlignment.MiddleCenter;
                lblMensaje.Font = font;
                lblMensaje.Margin = new Padding(0);
                ticket.Controls.Add(lblMensaje);

            }

            if (datosTicket.incluirSlogan)
            {
                Label lblMensaje = new Label();
                lblMensaje.Text = datosEmpresa.slogan;
                lblMensaje.AutoSize = true;
                lblMensaje.MinimumSize = new Size(anchoTicket, 0);
                lblMensaje.MaximumSize = new Size(anchoTicket, 0);
                lblMensaje.Width = anchoTicket;
                lblMensaje.Left = 0;
                lblMensaje.TextAlign = ContentAlignment.MiddleCenter;
                lblMensaje.Font = fontB;
                lblMensaje.Margin = new Padding(5, 15, 5, 15);
                ticket.Controls.Add(lblMensaje);

            }
        }
   
        private void IncluirLeyendaDuracionCotizacion()
        {
            configuracionGlobal = new ConfiguracionGlobal().ObtenerConfiguracionGlobal();

            if (configuracionGlobal.DuracionCotizacionesEnHoras > 0)
            {
                //Leyenda expiracion de la cotizacion
                Label lblCotizacionTitulo = new Label();
                lblCotizacionTitulo.AutoSize = true;
                lblCotizacionTitulo.MinimumSize = new Size(anchoTicket, 0);
                lblCotizacionTitulo.MaximumSize = new Size(anchoTicket, 0);
                lblCotizacionTitulo.Width = anchoTicket;
                lblCotizacionTitulo.Left = 0;
                lblCotizacionTitulo.TextAlign = ContentAlignment.MiddleCenter;
                lblCotizacionTitulo.Font = font;
                lblCotizacionTitulo.Margin = new Padding(5, 10, 5, 10);
                lblCotizacionTitulo.Text = "*Esta cotizacion expira dentro de " + configuracionGlobal.DuracionCotizacionesEnHoras + " hora(s)";
                ticket.Controls.Add(lblCotizacionTitulo);
            }



            //Leyenda expiracion de los precios de la cotizacion
            Label lblCotizacionPreciosTitulo = new Label();
            lblCotizacionPreciosTitulo.AutoSize = true;
            lblCotizacionPreciosTitulo.MinimumSize = new Size(anchoTicket, 0);
            lblCotizacionPreciosTitulo.MaximumSize = new Size(anchoTicket, 0);
            lblCotizacionPreciosTitulo.Width = anchoTicket;
            lblCotizacionPreciosTitulo.Left = 0;
            lblCotizacionPreciosTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblCotizacionPreciosTitulo.Font = font;
            lblCotizacionPreciosTitulo.Margin = new Padding(5, 10, 5, 10);

            if (configuracionGlobal.respetarPreciosCotizacion)
            {
                //Poner que los precios se respetan por tantas horas
                lblCotizacionPreciosTitulo.Text = "*Los precios de la cotizacion seran respetados ";
            }
            else
            {
                //poner que sujeto a cambio son previo aviso
                lblCotizacionPreciosTitulo.Text = "*Los precios de la cotización estan sujetos a cambio sin previo aviso";
            }

            ticket.Controls.Add(lblCotizacionPreciosTitulo);
        }

        private void IncluirCodigoBarras()
        {
            //Poner codigo de barras con el folio
            PictureBox codigoBarras = new PictureBox();
            BarcodeLib.Barcode barCode = new BarcodeLib.Barcode();
            barCode.IncludeLabel = true;
            codigoBarras.Image = barCode.Encode(BarcodeLib.TYPE.EAN13, folio, Color.Black, Color.White, 400, 180);
            codigoBarras.SizeMode = PictureBoxSizeMode.CenterImage;


            codigoBarras.MinimumSize = new Size(anchoTicket, codigoBarras.Image.Height + 30);
            codigoBarras.MaximumSize = new Size(anchoTicket, codigoBarras.Image.Height + 30);
            codigoBarras.Height = codigoBarras.Image.Height + 30;
            codigoBarras.Width = anchoTicket;
            codigoBarras.Left = 0;


            ticket.Controls.Add(codigoBarras);
        }

        private void GuardarTicket(int tipo)
        {
            //Mostrar el ticket para evitar error de altura en el datagridview
            Form f = new Form();
            f.Controls.Add(ticket);
            f.Width = 100;
            f.Height = 100;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            f.Show();

            f.Hide();
            


            //Ajustar altura

            int al = 0;
            foreach (Control c in ticket.Controls)
            {
                al += c.Height;
            }
            al = 0;
            ticket.Height = al + 20;

            //Guardar como imagen

            Bitmap b = new Bitmap(ticket.Width, ticket.Height);
            ticket.DrawToBitmap(b, new Rectangle(0, 0, b.Width, b.Height));

            string ruta = "C:\\TempVV\\Ticket\\";
            Directory.CreateDirectory(ruta);

            switch (tipo)
            {
                case 1:
                    ruta = ruta + "ticketVenta.png";
                    break;
                case 2:
                    ruta = ruta + "ticketVentaCliente.png";
                    break;
                case 3:
                    ruta = ruta + "ticketDevolucion.png";
                    break;
                case 4:
                    ruta = ruta + "ticketCorte.png";
                    break;
                case 5:
                    ruta = ruta + "ticketSugeridoFondo.png";
                    break;
                case 6:
                    ruta = ruta + "ticketAbono.png";
                    break;
                case 7:
                    ruta = ruta + "ticketSalida.png";
                    break;
            }


            b.Save(ruta, ImageFormat.Png);

            //Actualizar ruta para imprimir
            rutaImprimir = ruta;
            f.Close();
            f.Dispose();
            b.Dispose();
        }

        private void LimpiarTicket()
        {
            //Limpiar por si me vuelven mandar llamar no tener clientes incorrectos

            ahorro = 0;
            cliente = null;
            usuario = null;
            dgvProductos = null;
            indicesRemarcar = null;
            indicesCajas = null;
            fecha = null;
            if(ticket!= null)
             ticket.Controls.Clear();
        }

        private void IncluirResumenCorte(decimal[] totales)
        {
            AgregarTotal("Total de ventas: ", totales[0], fontB1_2);
            AgregarTotal("Total de devoluciones: ", -totales[2], fontB1_2);
            AgregarTotal("Total de gastos de tienda: ", -totales[4], fontB1_2);
            AgregarTotal("Total de ventas neto: ", totales[5], fontB1_2);
            AgregarTotal("Total de abonos: ", totales[13], fontB1_2);
            IncluirEspacio();
            AgregarTotal("Fondo de caja: ", totales[6] + totales[12], fontB1_2);
            IncluirEspacio();
            AgregarTotal("Dinero en caja: ", totales[7]+ totales[3], fontB1_2);
            AgregarTotal("Total de ventas otra forma de pago: ", -totales[1], fontB1_2);
            AgregarTotal("Total de salidas: ", -totales[3], fontB1_2);
            AgregarTotal("Fondo para siguiente turno: ", -totales[8], fontB1_2);
            AgregarTotal("Total a entregar: ", totales[9], fontB2);
            IncluirEspacio();
            AgregarTotal("Total entregado: ", totales[10], fontB2);

            if (totales[11]  < 0)
                AgregarTotal("Falto: ", -totales[11], fontB2);
            else
                if (totales[11] > 0)
                    AgregarTotal("Sobro: ", totales[11], fontB2);
        }

        private void IncluirTotalesVentas(Programacion.Corte obc, decimal totalVentas)
        {
            decimal[] totales = obc.ObtenerTotalesVentasDesglosado(folio);


            IncluirTitulo("Ventas");

            AgregarTotal("En Efectivo: ", totales[0], fontB1);

            AgregarTotal("Con Tarjeta: ", totales[1], fontB1);
            List<string[]> desglosado = obc.ObtenerTotalesTarjeta(folio);

            if (desglosado.Count > 0)
            {
                foreach (string[] total in desglosado) 
                {
                    //Folio venta - total
                    AgregarSubTotal("Folio: " + total[0], decimal.Parse(total[1]),"", fontB1_2); 
                }
                IncluirEspacio();
            }
           
            AgregarTotal("Con Vale: ", totales[2], fontB1);
            desglosado = obc.ObtenerTotalesVale(folio);

            if (desglosado.Count > 0)
            {
                foreach (string[] total in desglosado)
                {
                    //Folio venta - total
                    string e = "";
                    if (total[2]!="")
                        e = "Ref.: " + total[2];
                    AgregarSubTotal("Folio: " + total[0], decimal.Parse(total[1]),e, fontB1_2);
                }
                IncluirEspacio();
            }

            AgregarTotal("A Credito: ", totales[3], fontB1);
            desglosado = obc.ObtenerTotalesCredito(folio);

            if (desglosado.Count > 0)
            {
                foreach (string[] total in desglosado)
                {
                    //Folio venta - total
                    string e = "";
                    AgregarSubTotal("Folio: " + total[0], decimal.Parse(total[1]), e, fontB1_2);
                }
                IncluirEspacio();
            }

            AgregarTotal("Con Cheque: ", totales[4], fontB1);
            desglosado = obc.ObtenerTotalesCheque(folio);

            if (desglosado.Count > 0)
            {
                foreach (string[] total in desglosado)
                {
                    //Folio venta - total
                    string e = "";
                    if (total[2] != "")
                        e = "Ref.: " + total[2];
                    AgregarSubTotal("Folio: " + total[0], decimal.Parse(total[1]), e, fontB1_2);
                }
                IncluirEspacio();
            }

            AgregarTotal("Con Transferencia: ", totales[5], fontB1);
            desglosado = obc.ObtenerTotalesTransferencia(folio);

            if (desglosado.Count > 0)
            {
                foreach (string[] total in desglosado)
                {
                    //Folio venta - total
                    string e = "";
                    if (total[2]!="")
                        e = "Ref.: " + total[2];
                    AgregarSubTotal("Folio: " + total[0], decimal.Parse(total[1]),e, fontB1_2);
                }
                IncluirEspacio();
            }

            IncluirEspacio();
            AgregarTotal("Total de ventas: ", totalVentas, fontB1);

        }

        private void IncluirTotalesDevoluciones(Programacion.Corte obc, decimal totalDevoluciones)
        {
            if (totalDevoluciones > 0)
            {
                IncluirTitulo("Devoluciones");

                List<string[]> desglosado = obc.ObtenerTotalesDevolucionesDesglosado(folio);

                if (desglosado.Count > 0)
                {
                    foreach (string[] total in desglosado)
                    {
                        //Folio venta - total
                        AgregarTotal("Venta con folio: " + total[0], decimal.Parse(total[1]), fontB1_2);
                    }
                    IncluirEspacio();
                }

                AgregarTotal("Total de devoluciones: ", totalDevoluciones, fontB1);
            }
        }

        private void IncluirTotalesSalidas(Programacion.Corte obc, decimal totalSalidas)
        {
            if (totalSalidas > 0)
            {
                IncluirTitulo("Salidas");

                List<string[]> desglosado = obc.ObtenerTotalesSalidasDesglosado(folio);

                if (desglosado.Count > 0)
                {
                    foreach (string[] total in desglosado)
                    {
                        //Folio venta - total
                        AgregarTotal(total[0], decimal.Parse(total[1]), fontB1_2);
                    }
                    IncluirEspacio();
                }

                AgregarTotal("Total de salidas: ", totalSalidas, fontB1);
            }
        }

        private void IncluirTotalesGastosTienda(Programacion.Corte obc, decimal totalGastos)
        {
            if (totalGastos > 0)
            {
                IncluirTitulo("Gastos de tienda");

                List<string[]> desglosado = obc.ObtenerTotalesGastosTiendaDesglosado(folio);

                if (desglosado.Count > 0)
                {
                    foreach (string[] total in desglosado)
                    {
                        //Folio venta - total
                        AgregarTotal("Venta con folio: " + total[0], decimal.Parse(total[1]), fontB1_2);
                    }
                    IncluirEspacio();
                }

                AgregarTotal("Total de gastos de tienda: ", totalGastos, fontB1);
            }
        }

        private void IncluirTotalesFondoDeCaja(Programacion.Corte obc, decimal fondoInicial, decimal totalEntradas)
        {
             

            if (totalEntradas > 0)
            {
                IncluirTitulo("Fondo de caja");

                AgregarTotal("Fondo inicial: ", fondoInicial, fontB1_2);
                AgregarTotal("Total de entradas: ", totalEntradas, fontB1_2);

                List<string[]> desglosado = obc.ObtenerTotalesEntradasDesglosado(folio);

                if (desglosado.Count > 0)
                {
                    foreach (string[] total in desglosado)
                    {
                        //Folio venta - total
                        AgregarSubTotal(total[0], decimal.Parse(total[1]),"", fontB1_2);
                    }
                    IncluirEspacio();
                }

                AgregarTotal("Total de fondo de caja: ", totalEntradas+fondoInicial, fontB1);
            }
        }

        private void IncluirFirmasCorte(bool incluirFirmaRecibido)
        {
            IncluirTitulo("Firmas");
            

            //Leyenda Firma2
            Label lblLeyendaFirma2 = new Label();
            lblLeyendaFirma2.Text = "_______________________";
            lblLeyendaFirma2.AutoSize = true;
            lblLeyendaFirma2.MinimumSize = new Size(anchoTicket, 0);
            lblLeyendaFirma2.MaximumSize = new Size(anchoTicket, 0);
            lblLeyendaFirma2.Width = anchoTicket / 2;
            lblLeyendaFirma2.Left = 0;
            lblLeyendaFirma2.TextAlign = ContentAlignment.MiddleCenter;
            lblLeyendaFirma2.Margin = new Padding(5, 40, 5, 10);
            lblLeyendaFirma2.Font = fontB1;
            ticket.Controls.Add(lblLeyendaFirma2);

            //Leyenda Firma
            Label lblLeyendaFirma = new Label();
            lblLeyendaFirma.Text = "Firma del cajero";
            lblLeyendaFirma.AutoSize = true;
            lblLeyendaFirma.MinimumSize = new Size(anchoTicket, 0);
            lblLeyendaFirma.MaximumSize = new Size(anchoTicket, 0);
            lblLeyendaFirma.Width = anchoTicket / 2;
            lblLeyendaFirma.Left = 0;
            lblLeyendaFirma.TextAlign = ContentAlignment.MiddleCenter;
            lblLeyendaFirma.Margin = new Padding(5, 30, 5, 10);
            lblLeyendaFirma.Font = fontB0;
            ticket.Controls.Add(lblLeyendaFirma);

           

            //Leyenda Firma2
            Label lblLeyendaFirma4 = new Label();
            lblLeyendaFirma4.Text = "_______________________";
            lblLeyendaFirma4.AutoSize = true;
            lblLeyendaFirma4.MinimumSize = new Size(anchoTicket, 0);
            lblLeyendaFirma4.MaximumSize = new Size(anchoTicket, 0);
            lblLeyendaFirma4.Width = anchoTicket / 2;
            lblLeyendaFirma4.Left = 0;
            lblLeyendaFirma4.TextAlign = ContentAlignment.MiddleCenter;
            lblLeyendaFirma4.Margin = new Padding(5, 40, 5, 10);
            lblLeyendaFirma4.Font = fontB1;
            ticket.Controls.Add(lblLeyendaFirma4);

            //Leyenda Firma
            Label lblLeyendaFirma3 = new Label();
            lblLeyendaFirma3.Text = "Firma del encargado";
            lblLeyendaFirma3.AutoSize = true;
            lblLeyendaFirma3.MinimumSize = new Size(anchoTicket, 0);
            lblLeyendaFirma3.MaximumSize = new Size(anchoTicket, 0);
            lblLeyendaFirma3.Width = anchoTicket / 2;
            lblLeyendaFirma3.Left = 0;
            lblLeyendaFirma3.TextAlign = ContentAlignment.MiddleCenter;
            lblLeyendaFirma3.Margin = new Padding(5, 30, 5, 10);
            lblLeyendaFirma3.Font = fontB0;
            ticket.Controls.Add(lblLeyendaFirma3);

            if (incluirFirmaRecibido)
            {
                //Leyenda Firma2
                Label lblLeyendaFirma5 = new Label();
                lblLeyendaFirma5.Text = "_______________________";
                lblLeyendaFirma5.AutoSize = true;
                lblLeyendaFirma5.MinimumSize = new Size(anchoTicket, 0);
                lblLeyendaFirma5.MaximumSize = new Size(anchoTicket, 0);
                lblLeyendaFirma5.Width = anchoTicket / 2;
                lblLeyendaFirma5.Left = 0;
                lblLeyendaFirma5.TextAlign = ContentAlignment.MiddleCenter;
                lblLeyendaFirma5.Margin = new Padding(5, 40, 5, 10);
                lblLeyendaFirma5.Font = fontB1;
                ticket.Controls.Add(lblLeyendaFirma5);

                //Leyenda Firma
                Label lblLeyendaFirma6 = new Label();
                lblLeyendaFirma6.Text = "Firma de quien recibio";
                lblLeyendaFirma6.AutoSize = true;
                lblLeyendaFirma6.MinimumSize = new Size(anchoTicket, 0);
                lblLeyendaFirma6.MaximumSize = new Size(anchoTicket, 0);
                lblLeyendaFirma6.Width = anchoTicket / 2;
                lblLeyendaFirma6.Left = 0;
                lblLeyendaFirma6.TextAlign = ContentAlignment.MiddleCenter;
                lblLeyendaFirma6.Margin = new Padding(5, 30, 5, 10);
                lblLeyendaFirma6.Font = fontB0;
                ticket.Controls.Add(lblLeyendaFirma6);
            }
        }

        private void IncluirTotalEntregado(Vistas.PedirFondo obPedirFondo, decimal totalEntregado,decimal fondoSiguienteTurno, int duracionMinutos, int duracionSegundos, bool incluirFondoSiguienteTurno)
        {

            IncluirTitulo("Total entregado");

            GenerarTablaDinero(obPedirFondo,-1,null,null,-1,true);

            if (incluirFondoSiguienteTurno)
            {
                IncluirEspacio();

                AgregarTotal("Total a entregar: ", (fondoSiguienteTurno + totalEntregado), fontB1_2);
                AgregarTotal("Fondo para siguiente turno: ", -fondoSiguienteTurno, fontB1_2);
            }

            IncluirEspacio();

            AgregarTotal("Total entregado: ", totalEntregado, fontB1);
            if(duracionMinutos > 0)
                AgregarSubTotal("Contado en: "+ duracionMinutos + " minutos", fontB1_2);
            else
                AgregarSubTotal("Contado en: " + duracionSegundos + " segundos", fontB1_2);

        }

        private void GenerarTablaDinero(Vistas.PedirFondo obPedirFondo,decimal cantidadSugerida, TextBox[] cantidadesDisponiblesMonedas, TextBox[] cantidadesDisponiblesBilletes, int limitePorDenominacion,bool incluirEnTicket)
        {
            //bool seAlteraronCantidades1 = false;
            //bool seAlteraronCantidades2 = false;
            List<decimal[]> cantidadesAsignadas1;
            List<decimal[]> cantidadesAsignadas2;

            do
            {
                cantidadesAsignadas1 = null;
                cantidadesAsignadas2 = null;
                if (cantidadSugerida == -1 || cantidadSugerida > 0)
                {
                    Label lblTitulo = new Label();
                    lblTitulo.Text = "Conteo de monedas";
                    lblTitulo.AutoSize = true;
                    lblTitulo.MinimumSize = new Size(anchoTicket, 0);
                    lblTitulo.MaximumSize = new Size(anchoTicket, 0);
                    lblTitulo.Width = anchoTicket;
                    lblTitulo.Left = 0;
                    lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
                    lblTitulo.Font = fontB1;
                    lblTitulo.Margin = new Padding(5);
                    if (incluirEnTicket)
                        ticket.Controls.Add(lblTitulo);


                    //seAlteraronCantidades1 = AgregarTablaCantidadDinero(ref cantidadSugerida, cantidadesDisponiblesMonedas, obPedirFondo.ObtenerValoresMonedas(), obPedirFondo.ObtenerCantidadesMonedas(), obPedirFondo.ObtenerImportesMonedas(), fontB1_2, limitePorDenominacion);
                    cantidadesAsignadas1 = AgregarTablaCantidadDinero(ref cantidadSugerida, cantidadesDisponiblesMonedas, obPedirFondo.ObtenerValoresMonedas(), obPedirFondo.ObtenerCantidadesMonedas(), obPedirFondo.ObtenerImportesMonedas(), fontB1_2, limitePorDenominacion, incluirEnTicket);

                    Label lblTitulo2 = new Label();
                    lblTitulo2.Text = "Conteo de billetes";
                    lblTitulo2.AutoSize = true;
                    lblTitulo2.MinimumSize = new Size(anchoTicket, 0);
                    lblTitulo2.MaximumSize = new Size(anchoTicket, 0);
                    lblTitulo2.Width = anchoTicket;
                    lblTitulo2.Left = 0;
                    lblTitulo2.TextAlign = ContentAlignment.MiddleLeft;
                    lblTitulo2.Font = fontB1;
                    lblTitulo2.Margin = new Padding(5);
                    if(incluirEnTicket)
                        ticket.Controls.Add(lblTitulo2);

                    //seAlteraronCantidades2 = AgregarTablaCantidadDinero(ref cantidadSugerida, cantidadesDisponiblesBilletes, obPedirFondo.ObtenerValoresBilletes(), obPedirFondo.ObtenerCantidadesBilletes(), obPedirFondo.ObtenerImportesBilletes(), fontB1_2, limitePorDenominacion);
                    cantidadesAsignadas2 = AgregarTablaCantidadDinero(ref cantidadSugerida, cantidadesDisponiblesBilletes, obPedirFondo.ObtenerValoresBilletes(), obPedirFondo.ObtenerCantidadesBilletes(), obPedirFondo.ObtenerImportesBilletes(), fontB1_2, limitePorDenominacion, incluirEnTicket);

                    //La primer pasada por este codigo asigno
                    //monedas y billetes, si no se puede asignar lo deseado
                    //Repetir hasta que ya no se opueda asignar nada
                    //Para eso a las cantidades disponibles quitarle las 
                    //ya asignadas



                    //Checar si se pudo asignar todo
                    if (cantidadSugerida > 0)
                    {
                        //Falto asignar mas cambio para poder cumplir
                        if(cantidadesAsignadas1!= null)
                            foreach(decimal[] cantidadAsignada in cantidadesAsignadas1)
                            {
                                cantidadesDisponiblesMonedas[(int)cantidadAsignada[0]].Text = (decimal.Parse(cantidadesDisponiblesMonedas[(int)cantidadAsignada[0]].Text))  - cantidadAsignada[1] + "";
                            }

                        if (cantidadesAsignadas2 != null)
                            foreach (decimal[] cantidadAsignada in cantidadesAsignadas2)
                            {
                                cantidadesDisponiblesBilletes[(int)cantidadAsignada[0]].Text = (decimal.Parse(cantidadesDisponiblesBilletes[(int)cantidadAsignada[0]].Text)) - cantidadAsignada[1] + "";
                            }

                        //Remover del ticket los ultimos 4 controles
                        if (cantidadesAsignadas1 != null || cantidadesAsignadas2 != null)
                        {
                            if (incluirEnTicket)
                            {
                                ticket.Controls.RemoveAt(ticket.Controls.Count - 1);
                                ticket.Controls.RemoveAt(ticket.Controls.Count - 1);
                                ticket.Controls.RemoveAt(ticket.Controls.Count - 1);
                                ticket.Controls.RemoveAt(ticket.Controls.Count - 1);
                            }
                        }
                    }
                    else
                    {
                        //Ya se asignaron, ya no repetir
                        break;
                    }
                }
            }
            while (cantidadesAsignadas1 != null || cantidadesAsignadas2 != null);
        }

        private List<decimal[]> AgregarTablaCantidadDinero(ref decimal cantidadSugerida, TextBox[] cantidadesDisponibles, Label[] valores, TextBox[] cantidades, Label[] importes,Font font,int limitePorDenominacion, bool incluirEnTicket)
        {
            //bool seAlteraronCantidades = false;
            List<decimal[]> cantidadesAsignadas = null; //retorna el indice y la cantidad agregada

             if (cantidadSugerida > 0 && cantidadesDisponibles!=null)
            {
                //Alterar vectores para cumplir con el sugerido
                int i = 0;
                foreach(TextBox cantidad in cantidades)
                {
                    decimal cant = 0;
                    decimal importe = 0;

                    if (int.Parse(cantidadesDisponibles[i].Text) > limitePorDenominacion && limitePorDenominacion != -1)
                        cant = limitePorDenominacion;
                    else
                        cant = int.Parse(cantidadesDisponibles[i].Text);

                    //Checar si no me paso
                    while (cantidadSugerida - (cant * decimal.Parse(valores[i].Tag + "")) < 0) 
                    {
                        //Disminuir cant hasta llegar al sugerido que no se pase
                        cant--;
                    }

                    importe = cant * decimal.Parse(valores[i].Tag + "");
                    cantidadSugerida -= importe;

                    if (cant > 0)
                    {
                        if (cantidadesAsignadas == null)
                            cantidadesAsignadas = new List<decimal[]>();
                        //seAlteraronCantidades = true;
                        cantidadesAsignadas.Add(new decimal[] { i, cant });
                    }
                    
                    cant += decimal.Parse(cantidades[i].Text);

                    cantidades[i].Text = cant + "";

                    importe = cant * decimal.Parse(valores[i].Tag + "");
                    importes[i].Text = string.Format("{0:C}",importe);
                    importes[i].Tag = importe;

                    

                    i++;
                }
            }


            TableLayoutPanel tablaTotales = new TableLayoutPanel();
            tablaTotales.RowCount = valores.Length+1;
            tablaTotales.ColumnCount = 3;
            int d = ((int)(font.Size + 5) * tablaTotales.RowCount);
            tablaTotales.MinimumSize = new Size(anchoTicket, d);
            tablaTotales.MaximumSize = new Size(anchoTicket, d);
            tablaTotales.Width = anchoTicket;

            tablaTotales.RowStyles.Clear();
            tablaTotales.ColumnStyles.Clear();
            for(int x=0;x< tablaTotales.RowCount;x++)
            {
                tablaTotales.RowStyles.Add(new RowStyle(SizeType.Absolute, font.Size + 5));

            }
            

            tablaTotales.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, anchoTicket/3));
            tablaTotales.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, anchoTicket / 3));
            tablaTotales.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, anchoTicket / 3));

            Label l1 = new Label();
            l1.Text = "Valor";
            l1.AutoSize = true;
            l1.Dock = DockStyle.Fill;
            l1.Left = 0;
            l1.TextAlign = ContentAlignment.MiddleCenter;
            l1.Margin = new Padding(0);
            l1.Font = font;
            tablaTotales.Controls.Add(l1);

            Label l2 = new Label();
            l2.Text = "Cantidad";
            l2.AutoSize = true;
            l2.Dock = DockStyle.Fill;
            l2.Left = 0;
            l2.TextAlign = ContentAlignment.MiddleCenter;
            l2.Margin = new Padding(0);
            l2.Font = font;
            tablaTotales.Controls.Add(l2);

            Label l3 = new Label();
            l3.Text = "Importe";
            l3.AutoSize = true;
            l3.Dock = DockStyle.Fill;
            l3.Left = 0;
            l3.TextAlign = ContentAlignment.MiddleCenter;
            l3.Margin = new Padding(0);
            l3.Font = font;
            tablaTotales.Controls.Add(l3);

            int index = 0;
            foreach (Label l in valores)
            {

                ////Total titulo
                Label lblTotal = new Label();
                lblTotal.Text = l.Text;
                lblTotal.AutoSize = true;
                lblTotal.Dock = DockStyle.Fill;
                lblTotal.Left = 0;
                lblTotal.TextAlign = ContentAlignment.MiddleCenter;
                lblTotal.Margin = new Padding(0);
                lblTotal.Font = font;
                tablaTotales.Controls.Add(lblTotal);

                ////Total titulo
                Label lblTotal2 = new Label();
                lblTotal2.Text = cantidades[index].Text;
                lblTotal2.AutoSize = true;
                lblTotal2.Dock = DockStyle.Fill;
                lblTotal2.Left = 0;
                lblTotal2.TextAlign = ContentAlignment.MiddleCenter;
                lblTotal2.Margin = new Padding(0);
                lblTotal2.Font = font;
                tablaTotales.Controls.Add(lblTotal2);
                
                ////Total monto
                Label lblTotal1 = new Label();
                lblTotal1.Text = importes[index].Text;
                lblTotal1.AutoSize = true;
                lblTotal1.Dock = DockStyle.Fill;
                lblTotal1.Left = 0;
                lblTotal1.TextAlign = ContentAlignment.MiddleRight;
                lblTotal1.Margin = new Padding(0);
                lblTotal1.Font = font;
                tablaTotales.Controls.Add(lblTotal1);

                index++;
            }

            if(incluirEnTicket)
                ticket.Controls.Add(tablaTotales);

            return cantidadesAsignadas;
        }

        private void AgregarTotal(string titulo, decimal monto,Font font)
        {
            TableLayoutPanel tablaTotales = new TableLayoutPanel();
            tablaTotales.RowCount = 1;
            tablaTotales.ColumnCount = 2;
            tablaTotales.MinimumSize = new Size(anchoTicket, Convert.ToInt32(font.Size) + 5 );
            tablaTotales.MaximumSize = new Size(anchoTicket, Convert.ToInt32(font.Size) + 5);
            tablaTotales.Width = anchoTicket;

            tablaTotales.RowStyles.Clear();
            tablaTotales.ColumnStyles.Clear();
            tablaTotales.RowStyles.Add(new RowStyle(SizeType.Absolute, font.Size+5));
            tablaTotales.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 0));
            tablaTotales.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 0));

            

            ////Total titulo
            Label lblTotal = new Label();
            lblTotal.Text = titulo;
            lblTotal.AutoSize = true;
            //lblTotal.MinimumSize = new Size(anchoTicket, 0);
            //lblTotal.MaximumSize = new Size(anchoTicket, 0);
            //lblTotal.Width = anchoTicket ;
            lblTotal.Dock = DockStyle.Fill;
            lblTotal.Left = 0;
            lblTotal.TextAlign = ContentAlignment.MiddleLeft;
            lblTotal.Margin = new Padding(0);
            lblTotal.Font = font;
            tablaTotales.Controls.Add(lblTotal);

            ////Total monto
            Label lblTotal1 = new Label();
            lblTotal1.Text = string.Format("{0:C}", monto);
            lblTotal1.AutoSize = true;
            //lblTotal1.MinimumSize = new Size(anchoTicket, 0);
            //lblTotal1.MaximumSize = new Size(anchoTicket, 0);
            //lblTotal1.Width = anchoTicket ;
            lblTotal1.Dock = DockStyle.Fill;
            lblTotal1.Left = 0;
            lblTotal1.TextAlign = ContentAlignment.MiddleRight;
            lblTotal1.Margin = new Padding(0);
            lblTotal1.Font = font;
            tablaTotales.Controls.Add(lblTotal1);

            ticket.Controls.Add(tablaTotales);
        }

        private void AgregarSubTotal(string titulo, decimal monto, string extra, Font font)
        {
            TableLayoutPanel tablaTotales = new TableLayoutPanel();
            tablaTotales.RowCount = 1;
            if(extra == "")
                tablaTotales.ColumnCount = 2;
            else
                tablaTotales.ColumnCount = 3;
            tablaTotales.MinimumSize = new Size(anchoTicket, Convert.ToInt32(font.Size) + 5);
            tablaTotales.MaximumSize = new Size(anchoTicket, Convert.ToInt32(font.Size) + 5);
            tablaTotales.Width = anchoTicket;

            tablaTotales.RowStyles.Clear();
            tablaTotales.ColumnStyles.Clear();
            tablaTotales.RowStyles.Add(new RowStyle(SizeType.Absolute, font.Size + 5));
            tablaTotales.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 0));
            
            if (tablaTotales.ColumnCount == 3)
            {
                tablaTotales.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 0));
                tablaTotales.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 0));
            }
            else
                tablaTotales.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));



            ////Total titulo
            Label lblTotal = new Label();
            lblTotal.Text = titulo;
            lblTotal.AutoSize = true;
            //lblTotal.MinimumSize = new Size(anchoTicket, 0);
            //lblTotal.MaximumSize = new Size(anchoTicket, 0);
            //lblTotal.Width = anchoTicket ;
            lblTotal.Dock = DockStyle.Fill;
            lblTotal.Left = 0;
            lblTotal.TextAlign = ContentAlignment.MiddleLeft;
            lblTotal.Margin = new Padding(50,0,0,0);
            lblTotal.Font = font;
            tablaTotales.Controls.Add(lblTotal);

            if (extra != "")
            {
                ////Total titulo
                Label lblTotal2 = new Label();
                lblTotal2.Text = extra;
                lblTotal2.AutoSize = true;
                //lblTotal.MinimumSize = new Size(anchoTicket, 0);
                //lblTotal.MaximumSize = new Size(anchoTicket, 0);
                //lblTotal.Width = anchoTicket ;
                lblTotal2.Dock = DockStyle.Fill;
                lblTotal2.Left = 0;
                lblTotal2.TextAlign = ContentAlignment.MiddleLeft;
                lblTotal2.Margin = new Padding(0);
                lblTotal2.Font = font;
                tablaTotales.Controls.Add(lblTotal2);
            }

            ////Total monto
            Label lblTotal1 = new Label();
            lblTotal1.Text = string.Format("{0:C}", monto);
            lblTotal1.AutoSize = true;
            //lblTotal1.MinimumSize = new Size(anchoTicket, 0);
            //lblTotal1.MaximumSize = new Size(anchoTicket, 0);
            //lblTotal1.Width = anchoTicket ;
            lblTotal1.Dock = DockStyle.Fill;
            lblTotal1.Left = 0;
            lblTotal1.TextAlign = ContentAlignment.MiddleRight;
            lblTotal1.Margin = new Padding(0, 0, 80, 0);
            lblTotal1.Font = font;
            tablaTotales.Controls.Add(lblTotal1);

            ticket.Controls.Add(tablaTotales);
        }

        private void AgregarSubTotal(string titulo, Font font)
        {
            TableLayoutPanel tablaTotales = new TableLayoutPanel();
            tablaTotales.RowCount = 1;
            tablaTotales.ColumnCount = 1;
            tablaTotales.MinimumSize = new Size(anchoTicket, Convert.ToInt32(font.Size) + 5);
            tablaTotales.MaximumSize = new Size(anchoTicket, Convert.ToInt32(font.Size) + 5);
            tablaTotales.Width = anchoTicket;

            tablaTotales.RowStyles.Clear();
            tablaTotales.ColumnStyles.Clear();
            tablaTotales.RowStyles.Add(new RowStyle(SizeType.Absolute, font.Size + 5));
            tablaTotales.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 0));

            



            ////Total titulo
            Label lblTotal = new Label();
            lblTotal.Text = titulo;
            lblTotal.AutoSize = true;
            //lblTotal.MinimumSize = new Size(anchoTicket, 0);
            //lblTotal.MaximumSize = new Size(anchoTicket, 0);
            //lblTotal.Width = anchoTicket ;
            lblTotal.Dock = DockStyle.Fill;
            lblTotal.Left = 0;
            lblTotal.TextAlign = ContentAlignment.MiddleLeft;
            lblTotal.Margin = new Padding(0, 0, 0, 0);
            lblTotal.Font = font;
            tablaTotales.Controls.Add(lblTotal);

            ticket.Controls.Add(tablaTotales);
        }


    }
}
