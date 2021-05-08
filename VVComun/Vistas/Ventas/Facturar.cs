using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerdeComun.Programacion;
using Facturama;
using Facturama.Models;
using Facturama.Models.Request;
using ValleVerdeComun.Programacion.Facturama;

namespace ValleVerdeComun.Vistas
{
    public partial class Facturar : Form
    {
        Inventario.ImagenFlotante obi;
        bool ventanaSecundaria = false;
        Form parentSecundaria;

        //Facturacion
        Cliente cliente;
        List<Product> productos;
        Dictionary<string, decimal> cantidades;
        Dictionary<string, decimal> descuentos;
        Dictionary<string, decimal> impuestos;
        Dictionary<string, string> idsFacturama;
        bool asignarCliente = false;
        string idVenta;
        Programacion.Facturama.FacturamaMetodos obf = new Programacion.Facturama.FacturamaMetodos(null);
        DatosFactura datosFactura;

        public Facturar(string idVenta, Cliente cliente, List<Product> productos, Dictionary<string, decimal> cantidades, Dictionary<string, decimal> descuentos, Dictionary<string, decimal> impuestos, Dictionary<string, string> idsFacturama, decimal total)
        {
            InitializeComponent();

            this.FormClosing += Form_Closing;
            this.KeyDown += new KeyEventHandler(Eventos_Teclas);

            tcFacturar.Appearance = TabAppearance.FlatButtons;
            tcFacturar.ItemSize = new Size(0, 1);
            tcFacturar.SizeMode = TabSizeMode.Fixed;

            this.idVenta = idVenta;
            this.productos = productos;
            this.cantidades = cantidades;
            this.descuentos = descuentos;
            this.impuestos = impuestos;
            this.idsFacturama = idsFacturama;

            lblTotal.Text = string.Format("{0:C}",total);

            if (cliente == null)
            {
                tcFacturar.SelectedIndex = 0;

            }
            else
            {
                tcFacturar.SelectedIndex = 1;
                this.cliente = cliente;
                asignarCliente = false;

                LlenarDatos();

                
            }
        }

        private void Facturar_Load(object sender, EventArgs e)
        {

        }

        private void Form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (obi != null)
            {
                obi.Close();
                obi.Dispose();
            }

        }

        public void Eventos_Teclas(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.F4:
                    btnAsignarCliente.PerformClick();
                    break;
                
            }



        }

        private void CargarUsosCFDI()
        {
            if (cbUsoCFDI != null)
                cbUsoCFDI.DataSource = null;

            List<String[]> res = obf.ObtenerUsosCFDI(cliente.rfc);

            List<Object> items = new List<Object>();

            int i = 0, i2 = 0;
            string usoCfdi = "";
            if (cliente != null)
            {
                if (cliente.UsoCFDI != "")
                    usoCfdi = cliente.UsoCFDI;
                else
                    usoCfdi = "G03";
            }
            else
                usoCfdi = "G03";

            foreach (String[] uso in res)
            {
                items.Add(new { Text = uso[3] + " - " + uso[2], Value = uso[3] });

                if (uso[3].Contains(usoCfdi))
                    i2 = i;
                i++;
            }

            if (items.Count > 0)
            {
                cbUsoCFDI.DataSource = items;
                cbUsoCFDI.DisplayMember = "Text";
                cbUsoCFDI.ValueMember = "Value";

                cbUsoCFDI.DropDownWidth = DropDownWidth(cbUsoCFDI);

                //Seleccionar uno por defecto
                cbUsoCFDI.SelectedIndex = i2;

            }

            
        }

        private void CargarFormasPago()
        {
            if (cbFormaPago != null)
                cbFormaPago.DataSource = null;

            List<String[]> res = obf.ObtenerFormasPago();

            List<Object> items = new List<Object>();

            int i = 0, i2 = 0;
            foreach (String[] uso in res)
            {
                items.Add(new { Text = uso[1] + " - " + uso[0], Value = uso[1] });

                if (uso[1].Contains("P01"))
                    i2 = i;
                i++;
            }

            cbFormaPago.DataSource = items;
            cbFormaPago.DisplayMember = "Text";
            cbFormaPago.ValueMember = "Value";

            cbFormaPago.DropDownWidth = DropDownWidth(cbFormaPago);

            //Seleccionar uno por defecto
            cbFormaPago.SelectedIndex = i2;

        }

        private int DropDownWidth(ComboBox myCombo)
        {
            int maxWidth = 0;
            int temp = 0;
            Label label1 = new Label();

            foreach (var obj in myCombo.Items)
            {
                label1.Text = obj.ToString();
                label1.Font = myCombo.Font;
                temp = label1.PreferredWidth;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            label1.Dispose();
            return maxWidth;
        }

        private string[] GenerarFactura()
        {
            Client cliente = new Client();
            cliente.CfdiUse = cbUsoCFDI.SelectedValue.ToString();
            cliente.Name = this.cliente.nombre + " " + this.cliente.apellidos;
            cliente.Rfc = this.cliente.rfc;
            cliente.Email = this.cliente.correos.Count > 0 ? this.cliente.correos[0] : "a@gmail.com";
            cliente.Address = new Address();
            cliente.Address.Street = this.cliente.direccion;
            cliente.Address.ExteriorNumber = this.cliente.numeroExterior;
            cliente.Address.InteriorNumber = this.cliente.numeroInterior;
            cliente.Address.Neighborhood = this.cliente.colonia;
            cliente.Address.ZipCode = this.cliente.cp;
            cliente.Address.Locality = this.cliente.localidad;
            cliente.Address.Municipality = this.cliente.ciudad;
            cliente.Address.State = this.cliente.estado;
            cliente.Address.Country = this.cliente.pais;
            cliente.Id = this.cliente.IDFacturama;


            return obf.CrearFactura(cliente, cbUsoCFDI.Text, this.cliente.idCliente, productos, cantidades, descuentos, idsFacturama, cbFormaPago.SelectedValue.ToString());
        }

        private void btnAsignarCliente_Click(object sender, EventArgs e)
        {
            Vistas.BuscarCliente obc = new Vistas.BuscarCliente(false);
            obc.ShowDialog(this);

            this.cliente = obc.ObtenerCliente();

            if (this.cliente != null)
            {
                //Marcarlo para Guardarlo en BD y hacer cambios en la ventana
                tcFacturar.SelectedIndex = 1;
                asignarCliente = true;

                LlenarDatos();
                
            }
        }

        private void LlenarDatos()
        {

            lblNombreCliente.Text = "" + this.cliente.nombre + " " + this.cliente.apellidos;
            lblNombreCliente.Visible = true;
            lblNombreCliente.Tag = this.cliente.idCliente;

            if (this.cliente.rfc != "")
            {
                lblRFC.Text = this.cliente.rfc;
                btnAgregarRFC.Visible = false;
            }
            else
            {
                lblRFC.Text = "--Sin R.F.C.--";
               // btnAgregarRFC.Visible = true;
            }

            if (this.cliente.correos.Count > 0)
            {
                lblCorreo.Text = this.cliente.correos[0];
                btnAgregarCorreo.Visible = false;
            }
            else
            {
                lblCorreo.Text = "--Sin correo--";
               // btnAgregarCorreo.Visible = true;
            }

            CargarUsosCFDI();
            CargarFormasPago();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            if (cliente.rfc != "" && ((chkEnviar.Checked && cliente.correos.Count > 0) || !chkEnviar.Checked))
            {
                string[] resultados = GenerarFactura();

                //Si se pudo facturar asignar el cliente y guardar el id de la factura

                if (resultados[0] != "-1")
                {
                    new Cajas().AsignarFacturaVenta(idVenta, resultados[0]);

                    if (asignarCliente)
                    {
                        //La venta no tenia cliente o se le cambio, guardarle el que se le facturo
                        new Cajas().AsignarClienteVenta(idVenta, cliente.idCliente);

                    }
                    datosFactura = obf.ObtenerDatosFactura();
                    datosFactura.impuestos = impuestos;

                    //Enviarla a los correos
                    foreach(string correo in cliente.correos)
                    {
                        obf.EnviarFacturaPorCorreo(resultados[0], correo);
                        
                    }

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(resultados[1]);
                    this.DialogResult = DialogResult.Cancel;
                }

                this.Close();
            }
            else
            {
                //Completar datos minimos
                MessageBox.Show("Completa los datos.");
            }
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            tcFacturar.SelectedIndex = 0;
            this.cliente = null;
        }

        private void btnAgregarRFC_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarCorreo_Click(object sender, EventArgs e)
        {

        }

        public void setParentParaSecundaria(Form parent)
        {
            ventanaSecundaria = true;
            this.parentSecundaria = parent;
        }

        private void timerActualizarImagenFlotante_Tick(object sender, EventArgs e)
        {
            if (ventanaSecundaria && !cbUsoCFDI.DroppedDown && !cbFormaPago.DroppedDown)
            {
                if (obi == null)
                {
                    obi = new ValleVerdeComun.Vistas.Inventario.ImagenFlotante();
                    obi.Show(parentSecundaria);
                }
                obi.setImagenFlotante(ObtenerPanelDuplicar());
               
            }
        }

        private Panel ObtenerPanelDuplicar()
        {
            if (tcFacturar.SelectedIndex == 0)
            {
                //Poner letrero de facturacion
                Panel p = new Panel();
                p.Size = panelDatosFacturacion.Size;
                p.BackColor = tabPage4.BackColor;

                Label l = new Label();
                l.Font = label2.Font;
                l.Dock = DockStyle.Fill;
                l.TextAlign = ContentAlignment.MiddleCenter;
                l.Text = "Facturacion";
                l.BackColor = tabPage4.BackColor;

                p.Controls.Add(l);

                return p;
            }
            else
                return panelDatosFacturacion;
        }

        public DatosFactura ObtenerDatosFacturacion()
        {
            return datosFactura;
        }
    }

}