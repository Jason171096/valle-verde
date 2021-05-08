using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerdeComun.Programacion.Movivendor;
using Facturama;
using Facturama.Models;
using Facturama.Models.Request;
using ValleVerdeComun.Programacion.Facturama;
using System.Data.SqlClient;
using ValleVerdeComun.Programacion;

namespace ValleVerdeComun.Vistas
{
    public partial class VerVentas : Form
    {
        bool ventanaSecundaria = false;
        bool limpiandoDgv = false;
        Form parentSecundaria;

        Programacion.Cajas obc = new Programacion.Cajas();
        Programacion.ConfiguracionPV configuracionPV;
        Programacion.ConfiguracionBO configuracionBO;
        Programacion.Movivendor.MovivendorMetodos obMovivendor;
        Programacion.InterfazPrincipal form1;
        Programacion.Cliente cliente;
        decimal totalSinRecargasSerivicios = 0;
        int totalArticulos = 0;
        int formaPago = -1;
        string idCajaVenta = "", idFacturaRecibido = "";

        List<Product> productos = new List<Product>();
        Dictionary<string, decimal> cantidades = new Dictionary<string, decimal>();
        Dictionary<string, decimal> descuentos = new Dictionary<string, decimal>();
        Dictionary<string, decimal> impuestos = new Dictionary<string, decimal>();
        Dictionary<string, string> idsFacturama = new Dictionary<string, string>();

        public VerVentas(Programacion.InterfazPrincipal form1, Programacion.ConfiguracionPV configuracionPV, Programacion.ConfiguracionBO configuracionBO, MovivendorMetodos obMovivendor)
        {
            this.form1 = form1;

            this.configuracionPV = configuracionPV;
            this.configuracionBO = configuracionBO;
            this.obMovivendor = obMovivendor;
            InitializeComponent();

            if (configuracionBO != null)
            {
                btnDevolverSeleccionado.Visible = false;
                btnCancelarVenta.Visible = false;
                this.WindowState = FormWindowState.Maximized;
            }

            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvVentas,true,false, 15, 15);
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvProductos, true, false, 15, 15);


            //Ajustando ancho columanas
            //Ventas
            dgvVentas.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvVentas.Columns[0].Width = 80;
            dgvVentas.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvVentas.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvVentas.Columns[2].Width = 110;
            dgvVentas.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvVentas.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvVentas.Columns[3].Width = 105;
            dgvVentas.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //Productos
            dgvProductos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvProductos.Columns[0].Width = 150;
            dgvProductos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvProductos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvProductos.Columns[2].Width = 85;
            dgvProductos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvProductos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvProductos.Columns[3].Width = 120;
            dgvProductos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //dgvProductos.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //dgvProductos.Columns[4].Width = 90;
            //dgvProductos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvProductos.Columns[4].ValueType = new Panel().GetType();

            dgvProductos.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvProductos.Columns[8].Width = 120;
            dgvProductos.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns[8].Visible = false;

            dgvProductos.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvProductos.Columns[9].Width = 120;
            dgvProductos.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns[9].Visible = false;

            //Orden, oculta
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla().EstablecerColumnaOrden(dgvProductos, 5, true);


            dgvVentas.SelectionChanged += new EventHandler(CambioVentaSeleccionada);

            txtFolio.KeyDown += new KeyEventHandler(tb_KeyDown);
            this.KeyDown += new KeyEventHandler(Eventos_Teclas);

        }
        public void Eventos_Teclas(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
               
                case Keys.Up:
                    //dgv = (DataGridView)tabControl1.SelectedTab.Controls[0];
                    //index = dgv.SelectedRows[0].Index;
                    //if (index > 0)
                    //    dgv.Rows[index - 1].Selected = true;
                    break;
                case Keys.Down:
                    //dgv = (DataGridView)tabControl1.SelectedTab.Controls[0];
                    //index = dgv.SelectedRows[0].Index;
                    //if (index < dgv.Rows.Count - 1)
                    //    dgv.Rows[index + 1].Selected = true;
                    break;
                case Keys.Right:
                    this.ActiveControl = dgvProductos;
                    break;
                case Keys.Left:
                    this.ActiveControl = dgvVentas;
                    break;
                case Keys.D:
                    btnDevolverSeleccionado.PerformClick();
                    break;
                case Keys.F:
                    btnFacturar.PerformClick();
                    break;
                
            }


        }


        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar.PerformClick();

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Devoluciones_Load(object sender, EventArgs e)
        {
            //Cargar las ventas del dia seleccionado

            CargarVentasPorFecha();

        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            CargarVentasPorFecha();
        }

        public void CargarVentasPorFecha()
        {
            limpiandoDgv = true;
            dgvVentas.Rows.Clear();
            limpiandoDgv = false;

            List<string[]> ventas = obc.ObtenerVentasDelDia(dtpFecha.Value);

            foreach (string[] venta in ventas)
            {
                dgvVentas.Rows.Add(venta[0], DateTime.Parse(venta[1]).ToString("dd/MM/yyyy h:mm tt"), String.Format("{0:C}", decimal.Parse(venta[2])), venta[3]);
                dgvVentas.Rows[dgvVentas.Rows.Count - 1].Cells[3].Tag = venta[4] + "";
            }

            CambioVentaSeleccionada(null, null);
        }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CambioVentaSeleccionada(object sender, EventArgs e)
        {
            //Cargar productos de venta seleccionada
            if(dgvVentas.SelectedRows.Count > 0 && !limpiandoDgv)
            {
                decimal total = 0, importe = 0, comisionTotal = 0;
                totalSinRecargasSerivicios = 0;

                List<string> venta = obc.ObtenerDatosVenta(dgvVentas.SelectedRows[0].Cells[0].Value + "");

                lblFolio.Text = string.Format("{0:D11}", int.Parse(venta[0] + ""));
                lblFolio.Tag = venta[0] + "";
                lblFecha.Text = DateTime.Parse(venta[1]).ToString("dd/MM/yyyy h:mm tt") + "";
                lblCajero.Text = venta[2] + "";
                lblCajero.Tag = venta[8] + "";

                lblCaja.Text = venta[9] + "";
                idCajaVenta = venta[9] + "";
                idFacturaRecibido = venta[11] + "";
                

                cliente = new Programacion.Clientes().ObtenerClienteConID(venta[3] + "");

                if (cliente != null)
                {
                    
                    lblCliente.Text = cliente.nombre;
                    lblCliente.Tag = "1";//Significa que tiene cliente, usado en el boton facturar
                }
                else
                {
                    lblCliente.Text = "Venta al publico";
                    lblCliente.Tag = "0";
                }

                chkGastoParaTienda.Checked = Convert.ToBoolean(venta[12]+"");

                dgvProductos.Rows.Clear();
                totalArticulos = 0;
                //Cargar  productos en el ticket
                List<string[]> productos = obc.ObtenerProductosVenta(dgvVentas.SelectedRows[0].Cells[0].Value + "");
                foreach(string[] producto in productos)
                {
                    decimal cant,comision = 0;
                    string c = "";

                    try
                    {
                        cant = decimal.Parse(producto[3] + "");
                        if (cant % 1 == 0)
                            c = decimal.ToInt32(cant) + "";
                        else
                            c = cant + "";
                    }
                    catch
                    {
                        try
                        {
                            cant = decimal.Parse(producto[3].Substring(0, producto[3].IndexOf(" ")) + "");
                            if (cant % 1 == 0)
                                c = decimal.ToInt32(cant) + ""+ producto[3].Substring(producto[3].IndexOf(" "));
                            else
                                c = producto[3] + "";
                        }
                        catch
                        {
                            c = producto[3] + "";
                        }
                       
                    }
                    dgvProductos.Rows.Add(producto[1], producto[2],c, String.Format("{0:C}", decimal.Parse(producto[5])));
                    
                    //ID de la venta_produto
                    dgvProductos.Rows[dgvProductos.Rows.Count - 1].Cells[0].Tag = producto[0] + "";

                    //Piezas totales
                    dgvProductos.Rows[dgvProductos.Rows.Count - 1].Cells[2].Tag = producto[4] + "";
                    

                    if(producto[10]=="1"|| producto[10] == "True")//Pide peso
                    {
                        if(decimal.Parse(producto[7] + "") == 0)
                            totalArticulos += 1;
                    }
                    else
                    {
                        totalArticulos += (int)(decimal.Parse(producto[4] + "")- decimal.Parse(producto[7] + ""));
                    }
                   

                    //Completada
                    dgvProductos.Rows[dgvProductos.Rows.Count - 1].Cells[1].Tag = producto[6] + "";

                    //Devuelta
                    dgvProductos.Rows[dgvProductos.Rows.Count - 1].Cells[3].Tag = producto[7] + "";


                    //Precio por pieza
                    dgvProductos.Rows[dgvProductos.Rows.Count - 1].Cells[4].Tag = producto[8] + "";


                    //Si esta pendiente
                    if (producto[6] + "" == "0" || producto[6] + "" == "0.00")
                    {
                        dgvProductos.Rows[dgvProductos.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Yellow;
                        dgvProductos.Rows[dgvProductos.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = SystemColors.Highlight;
                        dgvProductos.Rows[dgvProductos.Rows.Count - 1].DefaultCellStyle.SelectionBackColor = Color.Yellow;
                        btnChecar.Enabled = true;
                    }
                    else
                    {
                        btnChecar.Enabled = false;
                    }

                    //Orden del producto
                    dgvProductos.Rows[dgvProductos.Rows.Count - 1].Cells[5].Value = producto[9];

                   
                    //Si ya esta devuelto totalmente
                    if (producto[7] + "" == producto[4] + "")
                    {
                        dgvProductos.Rows[dgvProductos.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Tomato;
                        dgvProductos.Rows[dgvProductos.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = SystemColors.Highlight;
                        dgvProductos.Rows[dgvProductos.Rows.Count - 1].DefaultCellStyle.SelectionBackColor = Color.Tomato;
                    }
                    else
                    {
                        //Si  esta devuelto PARCIALMENTE
                        if (decimal.Parse(producto[7] + "") > 0)
                        {
                            dgvProductos.Rows[dgvProductos.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Orange;
                            dgvProductos.Rows[dgvProductos.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = SystemColors.Highlight;
                            dgvProductos.Rows[dgvProductos.Rows.Count - 1].DefaultCellStyle.SelectionBackColor = Color.Orange;
                        }
                        

                    }

                    //Sku
                    dgvProductos.Rows[dgvProductos.Rows.Count - 1].Cells[6].Value = producto[11] + "";

                    //Destino
                    dgvProductos.Rows[dgvProductos.Rows.Count - 1].Cells[6].Tag = producto[12] + "";

                    //Piezas por caja
                    dgvProductos.Rows[dgvProductos.Rows.Count - 1].Cells[10].Value = producto[15];

                    //Cajas
                    dgvProductos.Rows[dgvProductos.Rows.Count - 1].Cells[11].Value = producto[16];

                    //Importe
                    dgvProductos.Rows[dgvProductos.Rows.Count - 1].Cells[9].Tag = producto[5] + "";


                    //Extra
                    dgvProductos.Rows[dgvProductos.Rows.Count - 1].Cells[7].Tag = producto[13] + "";

                    //Comision
                    comision = decimal.Parse(producto[14] + "");
                    dgvProductos.Rows[dgvProductos.Rows.Count - 1].Cells[8].Value = String.Format("{0:C}", comision);
                    dgvProductos.Rows[dgvProductos.Rows.Count - 1].Cells[8].Tag = comision+"";

                    importe = decimal.Parse(producto[8] + "") * (decimal.Parse(producto[4] + "") - decimal.Parse(producto[7] + ""));
                    total += importe + comision;
                    comisionTotal += comision;

                    //Si no es recarga o servicio sumarlo
                    if (producto[1] + "" != "")
                    {
                        totalSinRecargasSerivicios += importe;
                    }
                }

                if (comisionTotal > 0)
                    dgvProductos.Columns[8].Visible = true;
                else
                    dgvProductos.Columns[8].Visible = false;

                dgvProductos.Sort(dgvProductos.Columns[5], ListSortDirection.Ascending);

                //Cargar parte inferior
                lblTotal.Text = String.Format("{0:C}",decimal.Parse(venta[10] + ""));
                lblTotal.Tag = venta[10] + "";


                if (total != decimal.Parse(venta[4] + ""))
                {
                    lblTotal2T.Visible = true;
                    lblTotal2.Visible = true;
                    lblTotal2.Text = string.Format("{0:C}", total);
                    lblTotal2.Tag = total;
                }
                else
                {
                    lblTotal2T.Visible = false;
                    lblTotal2.Visible = false;
                    lblTotal2.Tag = total;
                }

                lblPagoCon.Text = String.Format("{0:C}", decimal.Parse(venta[5] )) + " - " + venta[7];
                lblPagoCon.Tag = venta[5];

                formaPago = int.Parse(venta[6]);
            }
            else
            {
                //Limpiar los campos del ticket
                lblFolio.Text = "";
                lblFecha.Text = "";
                lblCajero.Text = "";
                lblCaja.Text = "";
                lblCliente.Text = "";

                dgvProductos.Rows.Clear();

                lblTotal.Text = "$0.00";
                lblPagoCon.Text = "$0.00";
            }
            
        }

        public TextBox ObtenerTextBoxCodigo()
        {
            return txtFolio;
        }

        public Button ObtenerBotonAceptar() 
        {
            return btnBuscar;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Buscar en la base de datos la fecha de este folio, si existe regresa una fecha, si no null
            //Encontrada fa fecha se le asigna esa fecha al dtpFecha, esto causa que se recargen las ventas
            //Recargadas las ventas seleccionar el renglon donde se ubica nuestra venta a buscar
            if (txtFolio.Text.Length > 0)
            {
                //Checar si tiene check digit, si es asi fue leido con la bascula
                if (new ValleVerdeComun.Vistas.Inventario.CheckDigit().Check(txtFolio.Text, false) == txtFolio.Text)
                    txtFolio.Text = txtFolio.Text.Substring(0, txtFolio.Text.Length - 1);

                string buscar = "";

                if (!txtFolio.Text.Contains("."))
                    try
                    {
                        buscar = decimal.Parse(txtFolio.Text) + "";
                    }
                    catch { }
                string res = obc.ObtenerFechaVenta(buscar);


                if (res != "-1")
                {
                    dtpFecha.Value = Convert.ToDateTime(res);
                    dtpFecha_ValueChanged(null, null);

                    //Seleccionar el correspondiente a mi folio buscado

                    foreach (DataGridViewRow venta in dgvVentas.Rows)
                    {
                        if (venta.Cells[0].Value + "" == buscar)
                        {
                            //Lo encontre
                            venta.Selected = true;
                            dgvVentas.CurrentCell = venta.Cells[0];
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se encontro niguna venta con ese folio de ticket.");
                    txtFolio.SelectAll();

                }
            }

            if(configuracionPV!=null)
                form1.HabilitarEscaner();
        }

       

        private void txtFolio_TextChanged(object sender, EventArgs e)
        {

        }

        private void DevolverEvento(object sender, EventArgs e)
        {
            btnDevolverSeleccionado_Click(sender, e, false,true);
        }
        private void btnDevolverSeleccionado_Click(object sender, EventArgs e, bool yaAutorizado,bool redondear)
        {
            //Bloquear caja y reproducir sonido
            int resultado;

            if (yaAutorizado)
                resultado = 1;
            else
                resultado = form1.BloquearCaja(this,"Devolucion", true, "Autorizar devolucion", true);

            if (resultado == 1)
            {
                //Marcar como devuelto en bd
                if (dgvProductos.SelectedRows.Count > 0)
                {
                    DataGridView dgvProductosDevolver = new DataGridView();
                    dgvProductosDevolver.ColumnCount = 4;
                    dgvProductosDevolver.AllowUserToAddRows = false;
                    dgvProductosDevolver.AllowUserToDeleteRows = false;
                    dgvProductosDevolver.AllowUserToResizeRows = false;

                    int cantidadTotalDevolver = 0;
                    int cantidadTotalArticulosDevueltos = 0;
                    decimal montoTotalDevolver = 0;

                    for (int x = dgvProductos.SelectedRows.Count - 1; x >= 0; x--)
                    {
                        DataGridViewRow producto = dgvProductos.SelectedRows[x];
                        //Checar si ya esta devuela totalmente o si es recarga si se completo

                        if (producto.Cells[2].Tag + "" != producto.Cells[3].Tag + "")
                        {
                            //Checar que no sea recarga o que sea el sistema
                            if (producto.Cells[0].Value + "" != "")
                            {
                                //Marcar como devuelto en bd
                                //dgvProductos.SelectedRows[0].Cells[0].Tag representa el IDVent_Prod de la bd

                                //Preguntar si esta seguro, si es asi devolverlo y generar ticket

                                decimal cantidadDevolver = decimal.Parse(producto.Cells[2].Tag + "");
                                bool cont = true;
                                ValleVerdeComun.Programacion.Producto ob = new ValleVerdeComun.Programacion.Producto();
                                bool pidePeso = ob.PidePeso(producto.Cells[0].Value + "");
                                bool noUsaInventario = ob.NoUsaInventario(producto.Cells[0].Value + "");

                                //Si el ticket tiene mas de 1 preguntar cuantos
                                if (cantidadDevolver > 1 && pidePeso == false && noUsaInventario == false)
                                {
                                    //Preguntar cuantos va a devolver
                                    decimal cantDisp = decimal.Parse(producto.Cells[2].Tag + "") - decimal.Parse(producto.Cells[3].Tag + "");

                                    if (sender != null)
                                    {
                                        PedirCantidadDevolucion obpd = new PedirCantidadDevolucion();
                                        obpd.setDatos(cantDisp);
                                        obpd.ShowDialog(this);

                                        cantidadDevolver = obpd.cantidadDevolver;
                                    }
                                    else
                                        cantidadDevolver = cantDisp;

                                    if (cantidadDevolver == 0)
                                        cont = false;
                                }

                                if (cont)
                                {
                                    DialogResult res;
                                    decimal montoDevolver = (cantidadDevolver * (decimal.Parse(producto.Cells[4].Tag + "")));
                                    if(redondear)
                                        montoDevolver = new ValleVerdeComun.Programacion.Precios().RedondearTotal(montoDevolver);

                                    if (sender != null)
                                    {
                                        VerificarDatos obv = new VerificarDatos();
                                       
                                        obv.SetDatos("Producto", producto.Cells[1].Value + "", "Monto:", String.Format("{0:C}", montoDevolver));
                                        res = obv.ShowDialog();
                                    }
                                    else
                                        res = DialogResult.OK;


                                    if (res == DialogResult.OK)
                                    {
                                        montoTotalDevolver += decimal.Round(montoDevolver,2);
                                        //cantidadTotalDevolver += cantidadDevolver;

                                        obc.MarcarDevolucionVenta(producto.Cells[0].Tag + "", false, cantidadDevolver, configuracionPV.AlmacenActual, configuracionPV.IDTurno);
                                       
                                        if (pidePeso)
                                        {
                                            cantidadTotalDevolver += 1;
                                        }
                                        else
                                        {
                                            cantidadTotalDevolver += (int)cantidadDevolver;
                                        }
                                        
                                        dgvProductosDevolver.Rows.Add(cantidadDevolver, producto.Cells[1].Value + "", string.Format("{0:C}", (montoDevolver / cantidadDevolver)), string.Format("{0:C}", montoDevolver));

                                        cantidadTotalArticulosDevueltos++;
                                    }
                                }
                            }
                            else
                            {
                                if (sender != null) //Fue el usuario
                                    MessageBox.Show("No se pueden devolver recargas o servicios, para devolver uno que no se realizo correctamente utilice el boton verificar estado.");
                            }
                        }
                        else
                        {
                            if (sender != null) //Fue el usuario
                                MessageBox.Show("Este articulo ya fue devuelto");
                        }
                    }

                    if (cantidadTotalArticulosDevueltos > 0)
                    {
                        if(!redondear)
                            montoTotalDevolver = new ValleVerdeComun.Programacion.Precios().RedondearTotal(montoTotalDevolver);

                        form1.GenerarTicketDevolucion(dgvVentas.SelectedRows[0].Cells[0].Value + "", montoTotalDevolver, cantidadTotalDevolver, dgvProductosDevolver, cliente);
                        new Programacion.CajonDinero().AbrirCajon(form1.configuracionPV.ImpresoraTickets);
                    }


                    //Recargar
                    CambioVentaSeleccionada(null, null);

                }
            }

        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            //Bloquear caja y reproducir sonido
            int resultado = form1.BloquearCaja(this,"Cancelar venta", true, "Autorizar cancelacion",true);

            if (resultado == 1)
            {
                //Preguntar si esta seguro
                VerificarDatos obv = new VerificarDatos();

                obv.SetDatos("¿Estas seguro que deseas devolver toda la venta?", "Monto:", string.Format("{0:C}", new ValleVerdeComun.Programacion.Precios().RedondearTotal(totalSinRecargasSerivicios)));

                DialogResult res = obv.ShowDialog();

                if (res == DialogResult.OK)
                {
                    //Devolver todos los que hagan falta en la lista de productos de la venta
                    dgvProductos.MultiSelect = true;
                    dgvProductos.SelectAll();

                    btnDevolverSeleccionado_Click(null, null,true,false);

                    dgvProductos.MultiSelect = false;

                }
            }
        }

        private void chkGastoParaTienda_CheckedChanged(object sender, EventArgs e)
        {
            Programacion.Cajas obc = new Programacion.Cajas();
            obc.ActualizarVentaGastoParaTienda(lblFolio.Tag+"", chkGastoParaTienda.Checked);
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {

        }

        private void roundedButton5_Click(object sender, EventArgs e)
        {
            string idVenta = lblFolio.Tag + "";
            if (idVenta != "")
            {
                generarTicketVenta(false, idVenta, decimal.Parse(lblTotal.Tag+""), decimal.Parse(lblPagoCon.Tag+""), decimal.Parse(lblPagoCon.Tag + "")- decimal.Parse(lblTotal.Tag + ""), totalArticulos, formaPago, false);
                form1.impresoraTickets.Print();


                //this.Close();
                //this.Dispose();

            }
        }

        public void generarTicketVenta(bool esCotizacion, string folio, decimal total, decimal pagoCon, decimal cambio, int noArticulos, int formaPago, bool copiaClienteCredito)
        {
            form1.generarTicket.setAhorro(0);
            form1.generarTicket.setCliente(cliente);
            form1.generarTicket.setFecha(Convert.ToDateTime(lblFecha.Text));

            if (idFacturaRecibido != "-1")
            {
                //Cargar los datos para imprimir como factura
                DatosFactura datosFactura = new FacturamaMetodos(null).ObtenerDatosFactura(idFacturaRecibido);
                CargarProductosFacturacion();
                datosFactura.impuestos = impuestos;
                form1.generarTicket.setDatosFactura(datosFactura);
            }

            Programacion.Cajas obc = new Programacion.Cajas();
            ValleVerdeComun.Programacion.Huellas.ResultadoHuella usuarioBD = obc.ObtenerUsuarioConID(lblCajero.Tag+"");

            form1.generarTicket.setUsuario(usuarioBD);

            DataGridView dgvProductosTicket = new DataGridView();
            dgvProductosTicket.ColumnCount = 4;
            dgvProductosTicket.AllowUserToAddRows = false;
            dgvProductosTicket.AllowUserToDeleteRows = false;
            dgvProductosTicket.AllowUserToResizeRows = false;


            

            List<int> indicesRemarcar = new List<int>();
            List<int[]> indicesCajas = new List<int[]>();

            foreach (DataGridViewRow renglon in dgvProductos.Rows)
            {
                //Agregar solo los que no se han devuelto
                
                if (renglon.Cells[2].Tag != renglon.Cells[3].Tag)
                {
                    string c = "";
                    decimal cant = decimal.Parse(renglon.Cells[2].Tag + "");

                    if (cant % 1 == 0)
                        c = decimal.ToInt32(cant) + "";
                    else
                        c = cant + "";

                    if(decimal.ToInt32(decimal.Parse(renglon.Cells[11].Value+""))>0)//Entonces es caja
                        indicesCajas.Add(new int[] { renglon.Index, decimal.ToInt32(decimal.Parse(renglon.Cells[11].Value + "")), decimal.ToInt32(decimal.Parse(renglon.Cells[10].Value + "")) });

                    string comision = renglon.Cells[8].Value + "";
                    string totalCobrado;

                    if (comision != "" && comision != "$0.00")
                    {
                        totalCobrado = string.Format("{0:C}", decimal.Parse(renglon.Cells[9].Tag + "") + decimal.Parse(renglon.Cells[8].Tag + ""));
                        comision = "\n +" + comision + "\n ---------- \n " + totalCobrado;
                    }
                    else
                        comision = "";

                    dgvProductosTicket.Rows.Add(c, renglon.Cells[1].Value + "", string.Format("{0:C}", decimal.Parse(renglon.Cells[4].Tag + "")), renglon.Cells[3].Value + comision);

                    //si se le cobro comision marcarlo en el ticket
                    if (decimal.Parse(renglon.Cells[8].Tag + "") > 0)
                    {
                        indicesRemarcar.Add(renglon.Index);
                    }
                }


            }

            if (indicesCajas.Count > 0)
                form1.generarTicket.setIndicesMostrarCajas(indicesCajas);
            form1.generarTicket.setIndicesRemarcar(indicesRemarcar);
            form1.generarTicket.setDgvProductos(dgvProductosTicket);
            form1.generarTicket.GenerarTicketVenta(esCotizacion, folio, total, pagoCon, cambio, noArticulos, formaPago,"", copiaClienteCredito,chkGastoParaTienda.Checked,false);
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            if (obMovivendor != null && dgvProductos.SelectedRows.Count>0)
                if (dgvProductos.SelectedRows[0].Cells[0].Value + "" == "")//Es recarga
                {
                    string idTran = dgvProductos.SelectedRows[0].Cells[0].Tag + "";
                    //NOTA: movivendor requiere  que idtrans sea de 12 digitos exactamente
                    idTran = string.Format("{0:D12}", int.Parse(idTran));

                    string sku = dgvProductos.SelectedRows[0].Cells[6].Value + "";
                    string destino = dgvProductos.SelectedRows[0].Cells[6].Tag + "";
                    string monto = dgvProductos.SelectedRows[0].Cells[4].Tag + "";
                    string extra = dgvProductos.SelectedRows[0].Cells[7].Tag + "";
                    Programacion.Cajas obc = new Programacion.Cajas(); 

                    RespuestaVenta res = obMovivendor.ChecarStatusVenta(idTran, idCajaVenta, sku , destino,decimal.Parse(monto),extra,5,false);

                    if (res.rcode != "00" && res.rcode != "-2" && res.rcode != "-1001" && res.rcode != "88" && res.rcode != "89")
                    {
                        btnChecar.Enabled = false;

                        //No se pudo, marcarla en la bd y generar devolucion
                        obc.MarcarDevolucionVenta(res.id, true, 1, "", configuracionPV.IDTurno);

                        //generarTicket devolucion
                        DataGridView dgvProductosDevolver = new DataGridView();
                        dgvProductosDevolver.ColumnCount = 4;
                        dgvProductosDevolver.AllowUserToAddRows = false;
                        dgvProductosDevolver.AllowUserToDeleteRows = false;
                        dgvProductosDevolver.AllowUserToResizeRows = false;

                        dgvProductosDevolver.Rows.Add(1, dgvProductos.SelectedRows[0].Cells[1].Value + "", string.Format("{0:C}", decimal.Parse(monto)), string.Format("{0:C}", decimal.Parse(monto)));


                        form1.GenerarTicketDevolucion(dgvVentas.SelectedRows[0].Cells[0].Value + "", decimal.Parse(monto), 1, dgvProductosDevolver, cliente);


                        new Programacion.CajonDinero().AbrirCajon(form1.configuracionPV.ImpresoraTickets);
                    }
                    else
                    {
                        if (res.rcode == "00")
                        {
                            MessageBox.Show("El producto se cobro con exito en su momento");

                            //Marcarlo como exitoso
                            string pin = "", referencia="";
                            //Si me regreso un pin agregarlo al ticket
                            if (res.extra != null)
                            {
                                if (res.extra.Contains("PIN:"))
                                {
                                    pin = res.extra.Substring(res.extra.IndexOf("PIN:") + 4);
                                    if (pin.IndexOf("|") != -1)
                                        pin = pin.Substring(0, pin.Length - (pin.Length - pin.IndexOf("|")));

                                    if (pin.Length > 0 && sku != "ZNETFLIX")
                                        pin = "*********" + pin.Substring(pin.Length - 5);

                                }

                                //Si me regreso una referencia agregarlo al ticket
                                if (res.extra.Contains("REFERENCIA:"))
                                {
                                    referencia = res.extra.Substring(res.extra.IndexOf("REFERENCIA:") + 11);
                                    if (referencia.IndexOf("|") != -1)
                                        referencia = referencia.Substring(0, referencia.Length - (referencia.Length - referencia.IndexOf("|")));
                                    
                                    referencia = " - Referencia: " + referencia;
                                }
                            }
                            else
                                res.extra = "";

                            //Se pudo cobrar, guardar la fecha con la que se cobro

                            obc.MarcarFechaRecargaServicioVenta(idTran, res.fecha, pin + referencia, res.extra);

                        }
                        else
                            if (res.rcode != "-2" || res.rcode != "-1001")
                                MessageBox.Show(res.msgResp+"");
                    }
                }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (dgvVentas.SelectedRows.Count > 0)
            {
                //Solo si no esta facturada
                if (idFacturaRecibido == "-1")
                {

                    CargarProductosFacturacion();

                    if (productos.Count > 0)
                    {
                        Facturar obf = new Facturar(lblFolio.Tag + "", cliente, productos, cantidades, descuentos, impuestos, idsFacturama, decimal.Parse(lblTotal2.Tag + ""));

                        if (ventanaSecundaria)
                        {
                            obf.setParentParaSecundaria(form1);
                        }

                        obf.ShowDialog();

                        obf.Dispose();

                        //Actualizar la venta seleccionada por si cambio el cliente
                        CambioVentaSeleccionada(null, null);
                    }
                    else
                    {
                        MessageBox.Show("No se puede facturar una venta sin productos.");
                    }
                }
                else
                {
                    MessageBox.Show("Esta venta ya fue facturada");
                }
            }
           
        }private void CargarProductosFacturacion()
        {
            productos.Clear();
            cantidades.Clear();
            descuentos.Clear();
            idsFacturama.Clear();
           impuestos.Clear();

            List<string[]> catalogoImpuestos = new FacturamaMetodos(null).ObtenerCatalogoImpuestos();
            List<string[]> catalogoTipos = new FacturamaMetodos(null).ObtenerCatalogoTipsCFDI();

            Programacion.ClavesSAT ob = new Programacion.ClavesSAT();
            Programacion.Impuestos obi = new Programacion.Impuestos();
            Programacion.Producto obp = new Programacion.Producto();

            foreach (DataGridViewRow producto in dgvProductos.Rows)
            {
                //Facturar solo los no devueltos
                decimal cant = decimal.Parse(producto.Cells[2].Tag + "");
                decimal devueltos = decimal.Parse(producto.Cells[3].Tag + "");

                if (cant - devueltos > 0)
                {

                    String[] claveDescripcionSAT = ob.ObtenerClaveSATProducto(producto.Cells[0].Value + "");

                    Product p = new Product();
                    p.Id = producto.Cells[0].Value + "";
                    p.CodeProdServ = claveDescripcionSAT[0];
                    p.UnitCode = claveDescripcionSAT[2];
                    p.Unit = claveDescripcionSAT[3];
                    string nombre = producto.Cells[1].Value + "";

                    if (nombre.Length > 50)
                        p.Name = nombre.Substring(0, 50);
                    else
                        p.Name = nombre;
                    p.Description = producto.Cells[1].Value + "";
                    p.Price = new Programacion.Producto().QuitarImpuestos(producto.Cells[0].Value + "", decimal.Parse(producto.Cells[4].Tag + "")+(decimal.Parse(producto.Cells[8].Tag + "")/ (decimal)(cant - devueltos))); //Precio unitario mas la comision cobrada sin impuestos
                                                                                                                                                    // p.Taxes = new IEnumerable<Tax>().to;

                    //Agregar los impuestos

                    List<string[]> impuestosProd = obi.ObtenerImpuestosProducto(producto.Cells[0].Value + "");
                    List<Tax> taxes = new List<Tax>();
                    decimal precioBase = p.Price * cant - devueltos;

                    var decimals = 2;

                    foreach (string[] impuesto in impuestosProd)
                    {
                        //El nombre y el valor deven conicidir con los del catalogo
                        Tax t = new Tax();
                        //t.IsQuota = true;
                        t.IsRetention = false;
                        t.Rate = decimal.Parse(impuesto[2]) / 100;
                        //Buscando el nombre correcto
                        foreach (string[] imp in catalogoImpuestos)
                        {
                            if (imp[0] == impuesto[1])
                            {
                                t.Name = imp[0];
                                break;
                            }
                        }

                        t.Base = precioBase;
                        t.Total = Math.Round((precioBase) * t.Rate, decimals);

                        //Ponerlos en los impuestos 
                        string impu = impuesto[1] + " " + impuesto[2] + "%:";
                        if (!impuestos.ContainsKey(impu))
                            impuestos.Add(impu, t.Total);
                        else
                            impuestos[impu] += t.Total;


                        precioBase += t.Total;

                        taxes.Add(t);
                    }

                    if (taxes.Count > 0)
                        p.Taxes = taxes;

                    //La cantidad
                    cantidades.Add(p.Id, cant - devueltos);
                    descuentos.Add(p.Id, 0);
                    idsFacturama.Add(p.Id, obp.ObtenerIDFacturama(p.Id));

                    productos.Add(p);
                }
            }
        }

        private void lblCliente_Click(object sender, EventArgs e)
        {

        }

        public void setParentParaSecundaria(Form parent)
        {
            ventanaSecundaria = true;
            this.parentSecundaria = parent;
        }
    }
}
