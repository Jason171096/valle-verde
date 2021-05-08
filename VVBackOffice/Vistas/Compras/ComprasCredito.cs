using Microsoft.Office.Interop.Excel;
using MigraDoc.DocumentObjectModel.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using ValleVerde.Programacion.Ventas;
using MessageBox = System.Windows.MessageBox;
using Size = System.Drawing.Size;

namespace ValleVerde.Vistas.Compras
{
    public partial class ComprasCredito : Form
    {

        List<String[]> cargartodo;
        bool HabilitadoSelectionChanged = true;
        List<String[]> cargarproveedorpendiente;
        Programacion.Compra.CreditoCompra prov = new Programacion.Compra.CreditoCompra();

        byte indIdComCreCom, indIdCom, indNomProv, indIdFac, indFecLim, indFecCom, indAde, indMot, indTot, indIdProv,
            indIdAboCreCom2, indIdFac2, indImp2,indFec2, indMetPag2,indUsu2,indRef2,
            indIdFac3,indFecLim3,indAde3, indCB3;
        
        long idProv;

        decimal TotalFactura, RestantePagar;

        private void tablafactura_SelectionChanged(object sender, EventArgs e)
        {
            if (HabilitadoSelectionChanged)
            {
                if (tablafactura.Rows.Count > 0)
                {
                    nombre.Text = tablafactura.CurrentRow.Cells[indNomProv].Value.ToString();
                    LabelProveedor1.Text = tablafactura.CurrentRow.Cells[indNomProv].Value.ToString();
                    labelIDcompra.Text = tablafactura.CurrentRow.Cells[indIdCom].Value.ToString();
                    labelSubFactura.Text = tablafactura.CurrentRow.Cells[indAde].Value.ToString();
                    labelTotalFactura.Text = tablafactura.CurrentRow.Cells[indTot].Value.ToString();
                    labelMotivo.Text = tablafactura.CurrentRow.Cells[indMot].Value.ToString();
                    labelNoFactura.Text = tablafactura.CurrentRow.Cells[indIdFac].Value.ToString();
                    labelresapag.Text = tablafactura.CurrentRow.Cells[indAde].Value.ToString();
                    labelabono.Text = tablafactura.CurrentRow.Cells[indTot].Value.ToString();
                    labelmotivoabono.Text = tablafactura.CurrentRow.Cells[indMot].Value.ToString();
                    idProv = (long)tablafactura.CurrentRow.Cells[indIdProv].Value;
                    labelprov.Text = tablafactura.CurrentRow.Cells[indNomProv].Value.ToString();
                    ActualizarCantidadesFactura();
                }
            }
        }

        public ComprasCredito()
        {
            InitializeComponent();
        }

        private void ComprasCredito_Load(object sender, EventArgs e)
        {           
            indIdComCreCom = 0;
            indIdCom = 1;
            indNomProv = 2;
            indIdFac = 3;
            indFecLim = 4;
            indFecCom = 5;
            indAde = 6;
            indMot = 7;
            indTot = 8;
            indIdProv = 9;

            indIdAboCreCom2 = 0;
            indIdFac2 = 1;
            indImp2 = 2;
            indFec2 = 3;
            indMetPag2 = 4;
            indUsu2 = 5;
            indRef2 = 6;

            indIdFac3 = 0;
            indFecLim3 = 1;
            indAde3 = 2;
            indCB3 = 3;

            tablaProveedores.Columns[0].Width = 70;

            tablafactura.Columns[1].Width = 160;
            tablafactura.Columns[3].Width = 160;
            tablafactura.Columns[6].Width = 200;
            tablafactura.Columns[7].Width = 185;

            tablaabono.Columns[0].Width = 140;
            tablaabono.Columns[2].Width = 180;
            tablaabono.Columns[3].Width = 280;
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;

            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(tablaprov, true, false);
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(tablafactura, false, false);
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(tablaabono, true, false);
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(tablaProveedores, true, false);
            //new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(tablaprovabono, true, false);

            btnBuscar.Enabled = false;

            CargarProveedores("-1","-1",1);
            Casilla();
            CargarFormasPago();
            ObtenerProveedorPendiente();
            ActualizarTablaFacturas(-1);                        
            RenglonRepetido();
            FechasFacturasLimite();
            SumarTotal();
            AdeudoTotal();
            ProximaFactura();
            RestarAbono();
            ActualizarCantidadesFactura();
            
            tablafactura.SelectionChanged += new EventHandler(tablafactura_SelectionChanged);
            tablaprovabono.CellValueChanged += new DataGridViewCellEventHandler(tablaprovabono_CellValueChanged);

        }

        private void tablaprovabono_CellValueChanged(object sender,  DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == indCB3)
            {
                ActualizarEtiquetasPage5();
            }           
        }

        private void ObtenerProveedorPendiente()
        {
            cargarproveedorpendiente = prov.ObtenerProveedoresComprasPendientes();
            tablaprov.Rows.Add(cargarproveedorpendiente[0]);
        }

        private void btnvolver_Click(object sender, EventArgs e)
        {
            checktodasfacturas.Checked = true;
            tabControl1.SelectedTab = tabPage1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            DialogResult resultado = (DialogResult)MessageBox.Show("Deseas abonar a la Factura que seleccionaste? ", "Salir", MessageBoxButton.YesNo);
            if(resultado == DialogResult.Yes)
            {
                LLenarAbonos();
                tabControl1.SelectedTab = tabPage2;
                TotalFactura = (decimal)tablafactura.SelectedRows[0].Cells[indTot].Value;
                ActualizarCantidadesFactura();
            }
            else
            {
                if(resultado == DialogResult.No)
                {
                    tabControl1.SelectedTab = tabPage1;
                }
            } 
        }

        private void ActualizarAbonos()
        {
            HabilitadoSelectionChanged = false;

            tablaabono.Rows.Clear();

            byte ultimorenglon;

            List<object[]> abonos = prov.ObtenerAbonosFacturaCreditoCompra(long.Parse(tablafactura.CurrentRow.Cells[indIdFac].Value.ToString()));
            for (int i = 0; i < abonos.Count; i++)
            {
                tablaabono.Rows.Add();
                ultimorenglon = (byte)(tablaabono.Rows.Count - 1);
                tablaabono.Rows[ultimorenglon].Cells[indIdAboCreCom2].Value = abonos[i][0];
                tablaabono.Rows[ultimorenglon].Cells[indImp2].Value = abonos[i][4];
                tablaabono.Rows[ultimorenglon].Cells[indFec2].Value = abonos[i][3];
                tablaabono.Rows[ultimorenglon].Cells[indMetPag2].Value = abonos[i][6];
                tablaabono.Rows[ultimorenglon].Cells[indUsu2].Value = abonos[i][2];
                tablaabono.Rows[ultimorenglon].Cells[indRef2].Value = abonos[i][5];
                tablaabono.Rows[ultimorenglon].Cells[indIdFac2].Value = abonos[i][1];
            }
            HabilitadoSelectionChanged = true;
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            List<object[]> obs = prov.ObtenerFacturasDeComprasPendientes(long.Parse(tablaProveedores.CurrentRow.Cells[indIdComCreCom].Value.ToString()));
            if (obs.Count > 0)
            {
                ActualizarTablaFacturas(long.Parse(tablaProveedores.CurrentRow.Cells[indIdComCreCom].Value.ToString()));
                RenglonRepetido();
                FechasFacturasLimite();
                SumarTotal();
                AdeudoTotal();
                ProximaFactura();
                Casilla();
                CargarFormasPago();
                tabControl1.SelectedTab = tabPage1;
            }
            else
                MessageBox.Show("Este Proveedor no tiene Facturas pendientes.");     
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void btnantigua_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            ProximaFactura();
            //AbonoProximo();
        }

        private void btnseleccionada_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
            //DataGridViewCheckBoxCell chkchecking = tablaprovabono.Rows[0].Cells[indCB3] as DataGridViewCheckBoxCell;
            CargarFacturasPendientesProveedor(idProv);
            LLenarAbonos();
        }

        private void CargarFormasPago()
        {
            List<String[]> res = prov.ObtenerFormaPago();

            cbFormaPago.DisplayMember = "Text";
            cbFormaPago.ValueMember = "Value";

            List<Object> items = new List<Object>();

            items.Add(new { Text = "Formas de Pago", Value = "-1" });

            foreach(String[] forma in res)
            {
                items.Add(new { Text = forma[1], Value = forma[0] });
            }
            cbFormaPago.DataSource = items;
        }

        private void btnabonar_Click(object sender, EventArgs e)
        {
            if(cbFormaPago.SelectedIndex==0)
            {
                MessageBox.Show("Debes Elegir una Forma de Abonar.", "Alerta");
            }
            else
            {
                    if (RestantePagar < decimal.Parse(textBox2.Text))
                    {
                        tabControl1.SelectedTab = tabPage4;
                    }

                    AbonarSeleccionada();
            }
            
        }

        private void btnregresar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void labelprov_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            CargarProveedores("-1","-1",1);
        }

        private void checkProveedor_CheckedChanged(object sender, EventArgs e)
        {
            if (checkProveedor.Checked)
            {
                btnBuscar.Enabled = true;
                checktodasfacturas.Checked = false;
            }
            else
                btnBuscar.Enabled = false;
        }

        private void checktodasfacturas_CheckedChanged(object sender, EventArgs e)
        {
            if(checktodasfacturas.Checked)
            {
                checkProveedor.Checked = false;
                Casilla();
                CargarFormasPago();
                ObtenerProveedorPendiente();
                ActualizarTablaFacturas(-1);
                RenglonRepetido();
                FechasFacturasLimite();
                SumarTotal();
                AdeudoTotal();
                ProximaFactura();
            }
        }

        private void ActualizarTablaFacturas(long idprov)
        {
            indIdComCreCom = 0;
            indIdCom = 1;
            indNomProv = 2;
            indIdFac = 3;
            indFecLim = 4;
            indFecCom = 5;
            indAde = 6;
            indMot = 7;
            indTot = 8;

            HabilitadoSelectionChanged = false;
            tablafactura.Rows.Clear();
            List<object[]> Factura = prov.ObtenerFacturasDeComprasPendientes(idprov); 
            for (int i = 0; i < Factura.Count; i++)
            {
                tablafactura.Rows.Add(new object[] { Factura[i][0], Factura[i][1], Factura[i][2], Factura[i][4], Factura[i][3], Factura[i][8], Factura[i][6], Factura[i][7], Factura[i][5],Factura[i][9] });
            }
            HabilitadoSelectionChanged = true;
            tablafactura.ClearSelection();
        }

        private void RenglonRepetido()
        {
            for(int i=0;i<tablafactura.Rows.Count;i++)
            {
                for(int j=0;j<tablafactura.Rows.Count;j++)
                {
                    if(i!=j)
                    {
                        if(tablafactura.Rows[i].Cells[indIdFac].Value.ToString() == tablafactura.Rows[j].Cells[indIdFac].Value.ToString())
                        {
                            tablafactura.Rows[i].DefaultCellStyle.ForeColor = Color.DarkGray;
                        }
                    }                    
                }
            }
        }

        private void FechasFacturasLimite()
        {
            int horas, tamano;
            DateTime fechalimite;
            DateTime fechaservidor = new DateTime();
            fechaservidor = prov.ObtenerFechaServidor();
            String fechare;

            for (int i=0;i<tablafactura.Rows.Count;i++)
            {
                if(tablafactura.Rows[i].Cells[indFecCom].Value.ToString()!="")
                {
                    fechalimite = DateTime.Parse(tablafactura.Rows[i].Cells[indFecCom].Value.ToString());
                    fechare= (fechalimite - fechaservidor) + "";
                    if (fechare.Substring(0, 1) == "-")
                    {
                        tablafactura.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }

                    else
                    {
                        fechalimite = DateTime.Parse(tablafactura.Rows[i].Cells[indFecCom].Value.ToString());
                        fechare = (fechalimite - fechaservidor) + "";
                        tamano = fechare.IndexOf(".");
                        if(tamano>0)
                        {
                            horas = int.Parse(fechare.Substring(0, tamano));
                            //MessageBox.Show("horas" + horas);
                            if(horas<3)
                            {
                                tablafactura.Rows[i].DefaultCellStyle.BackColor = Color.DarkOrange;
                            }
                            if(horas>=3 && horas<7)
                            {
                                tablafactura.Rows[i].DefaultCellStyle.BackColor = Color.Gold;
                            }
                        }
                        else
                        {
                            tablafactura.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
                        }
                    }                    
                }
            }
        }

        private void Casilla()
        {
            FechaLimite.SortMode = DataGridViewColumnSortMode.NotSortable;
            MotivoLimite.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void SumarTotal()
        {
            decimal suma = 0;
            foreach (DataGridViewRow row in tablafactura.Rows)
            {
                    suma += Convert.ToDecimal(row.Cells[indTot].Value);                
            }
            labelTotal.Text = Convert.ToString(suma);
        }

        private void AdeudoTotal()
        {
            decimal suma = 0;
            foreach(DataGridViewRow row in tablafactura.Rows)
            {
                suma += Convert.ToDecimal(row.Cells[indAde].Value);
            }
            labelSubTotal.Text = Convert.ToString(suma);
        }

        private void ProximaFactura()
        {
            for(int i=0;i<tablafactura.Rows.Count;i++)
            {
                if (tablafactura.Rows[i].Cells[indFecCom].Value.ToString() != "")
                {
                    labelProxFactura.Text = tablafactura.Rows[i].Cells[indFecCom].Value.ToString();
                    nombre.Text = tablafactura.Rows[i].Cells[indNomProv].Value.ToString();
                    LabelProveedor1.Text = tablafactura.Rows[i].Cells[indNomProv].Value.ToString();
                    labelIDcompra.Text = tablafactura.Rows[i].Cells[indIdCom].Value.ToString();
                    labelSubFactura.Text = tablafactura.Rows[i].Cells[indAde].Value.ToString();
                    labelTotalFactura.Text = tablafactura.Rows[i].Cells[indTot].Value.ToString();
                    labelMotivo.Text = tablafactura.Rows[i].Cells[indMot].Value.ToString();
                    labelNoFactura.Text = tablafactura.Rows[i].Cells[indIdFac].Value.ToString();
                    labelresapag.Text = tablafactura.Rows[i].Cells[indAde].Value.ToString();
                    labelabono.Text = tablafactura.Rows[i].Cells[indTot].Value.ToString();
                    labelmotivoabono.Text = tablafactura.Rows[i].Cells[indMot].Value.ToString();
                    labelprov.Text = tablafactura.Rows[i].Cells[indNomProv].Value.ToString();
                    
                    break;
                }               
            }
        }

        private void CargarProveedores(string estado, string ciudad, int activo)
        {
            tablaProveedores.Rows.Clear();
            cargartodo = prov.ObtenerTodosProveedores(estado, ciudad, textBox3.Text, activo);

            foreach (String[] todo in cargartodo)
            {               
                tablaProveedores.Rows.Add(todo[0], todo[1], todo[2], todo[3]);
            }
        }

        private void LLenarAbonos()
        {
            long clvverificar = (long.Parse(tablafactura.CurrentRow.Cells[3].Value.ToString()));
            List<object[]> Abonar = prov.ObtenerAbonosFacturaCreditoCompra(clvverificar);

            tablaabono.Rows.Clear();

            foreach(object[] verificar in Abonar)
            {
                tablaabono.Rows.Add(new object[] { verificar[indIdAboCreCom2], verificar[indIdFac2], verificar[indMetPag2], verificar[indFec2], verificar[indRef2], verificar[indImp2], verificar[indUsu2] });

                if (clvverificar == (long.Parse(tablaabono.CurrentRow.Cells[1].Value.ToString())))
                {

                }
                else
                {
                    tablaabono.Rows.Clear();
                }
            }
        }

        private void AbonoProximo()
        {
            long clvverificar = (long.Parse(tablafactura.CurrentRow.Cells[3].Value.ToString()));
            List<object[]> Abonar = prov.ObtenerAbonosFacturaCreditoCompra(clvverificar);

            foreach (object[] verificar in Abonar)
            {
                tablaabono.Rows.Add(new object[] { verificar[indIdAboCreCom2], verificar[indIdFac2], verificar[indMetPag2], verificar[indFec2], verificar[indRef2], verificar[indImp2], verificar[indUsu2] });

                if (clvverificar == (long.Parse(tablaabono.CurrentRow.Cells[1].Value.ToString())))
                {
                    
                }
                else
                {
                    tablaabono.CurrentRow.Cells[0].Value.ToString();
                }
            }
        }

        private void AbonarSeleccionada()
        {
            if(textBox2.Text=="")
            {
                MessageBox.Show("Debes Introducir un numerovalido");
            }
            else
            {
                List<object[]> Pago = prov.AgregarAbonoCreditoCompra(long.Parse(labelNoFactura.Text), decimal.Parse(textBox2.Text), DateTime.Now, cbFormaPago.SelectedIndex, 2 , textBoxreferencia.Text, true);
                tablaabono.Rows.Clear();
                LLenarAbonos();
                ActualizarCantidadesFactura();

            }                     
        }

        private void RestarAbono()
        {
            decimal resta = 0;

            foreach (DataGridViewRow row in tablaabono.Rows)
            {
                resta -= Convert.ToDecimal(tablaabono.Rows[0].Cells[2].Value.ToString());
            }

            labelresapag.Text = Convert.ToString(resta);
        }

        private void CargarFacturasPendientesProveedor(long idprov)
        {
            List<object[]> res = prov.ObtenerFacturasDeComprasPendientes(idprov);

            foreach(object[] cargar in res)
            {
                tablaprovabono.Rows.Add();
                tablaprovabono.Rows[tablaprovabono.Rows.Count - 1].Cells[indIdFac3].Value = cargar[4];
                tablaprovabono.Rows[tablaprovabono.Rows.Count - 1].Cells[indFecLim3].Value = cargar[8];
                tablaprovabono.Rows[tablaprovabono.Rows.Count - 1].Cells[indAde3].Value = cargar[6];
            }
            ActualizarEtiquetasPage5();
        }

        private void ActualizarCantidadesFactura()
        {
            decimal suma = 0;

            for(int i=0;i<tablaabono.Rows.Count;i++)
            {

                if(!(tablaabono.Rows[i].Cells[2].Value + "").Equals(""))
                {
                    suma += (decimal)tablaabono.Rows[i].Cells[2].Value;
                }

            }
            RestantePagar = TotalFactura - suma;
            labelresapag.Text = RestantePagar+"";
            labelabono.Text = TotalFactura + "";
            //labelsubabono.Text = RestantePagar + "";
        }

        private void ActualizarEtiquetasPage5()
        {
            decimal restantePagar = RestantePagar;

            for(int i=0;i<tablaprovabono.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell chkchecking = tablaprovabono.Rows[i].Cells[indCB3] as DataGridViewCheckBoxCell;
                if (chkchecking.Selected)
                {
                    restantePagar -= (decimal)tablaprovabono.CurrentRow.Cells[indAde3].Value;
                }
            }
            labelrestabono.Text = restantePagar+"";
        }
    }
}
