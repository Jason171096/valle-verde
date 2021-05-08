using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerdeComun.Programacion;

namespace ValleVerdeComun.Vistas
{
    public partial class PedirFondo : Form
    {
        Label[] valoresMonedas, valoresBilletes;
        TextBox[] cantidadMonedas, verificarCantidadMonedas, cantidadBilletes, verificarCantidadBilletes;
        Label[] importeMonedas, importeBilletes;
        bool error = false;
        string idCaja;
        string idUsuario;
        bool esInicioDeTurno;
        int tipoVentana; //1=turno/corte, 2=verificacion, 3= tabulador
        string idTurno = "-1";
        decimal fondoSiguienteTurno = 0m;
        Stopwatch timer = new Stopwatch();
        public int duracionMinutos = 0, duracionSegundos = 0;
        InterfazPrincipal ventanaPrincipal;
        string impresoraTicket = "";

        public PedirFondo()
        {
            //Solo se usa para obtener los valores de monedas y  billetes
            tipoVentana = 4;

            InitializeComponent(); 
            ConfigurarValores();
        }
        public PedirFondo(InterfazPrincipal ventanaPrincipal, string idCaja,string idUsuario,bool esInicioDeTurno,int tipoVentana, bool mostrarAbrirCajon)
        {
            //Verificacion de fondos significa el turno ya estaba abierto y tengo que 
            //calcular cuanto dinero deberia haber en caja, despues verificar si es correcto
            //con lo contado por el usuario, todo esto al pulsar aceptar

            this.ventanaPrincipal = ventanaPrincipal;
            this.idCaja = idCaja;
            this.idUsuario = idUsuario;
            this.esInicioDeTurno = esInicioDeTurno;
            this.tipoVentana = tipoVentana;

            InitializeComponent();
            ConfigurarValores();


            if (tipoVentana == 3)
            {
                lblTitulo.Text = "Contar dinero";
            }
            else
            {
                if (tipoVentana == 4)
                {
                    lblTitulo.Text = "Sugerencia de fondo";
                }
            }

            if (!mostrarAbrirCajon)
                btnAbrirCajon.Visible = false;

        }

        public PedirFondo(string impresoraTicket, string idCaja, string idUsuario, bool esInicioDeTurno, int tipoVentana)
        {
            //Verificacion de fondos significa el turno ya estaba abierto y tengo que 
            //calcular cuanto dinero deberia haber en caja, despues verificar si es correcto
            //con lo contado por el usuario, todo esto al pulsar aceptar

            this.impresoraTicket = impresoraTicket;
            this.idCaja = idCaja;
            this.idUsuario = idUsuario;
            this.esInicioDeTurno = esInicioDeTurno;
            this.tipoVentana = tipoVentana;

            InitializeComponent();
            ConfigurarValores();


            if (tipoVentana == 3)
            {
                lblTitulo.Text = "Contar dinero";
            }
            else
            {
                if (tipoVentana == 4)
                {
                    lblTitulo.Text = "Sugerencia de fondo";
                }
            }

        }

        private void PedirFondo_Load(object sender, EventArgs e)
        {
            this.ActiveControl = c4;
            timer.Start();
        }

        private void ConfigurarValores()
        {

            //tabConteo.Appearance = TabAppearance.FlatButtons;
            //tabConteo.ItemSize = new Size(0, 1);
            //tabConteo.SizeMode = TabSizeMode.Fixed;

            valoresMonedas = new Label[] { v1, v2, v3, v4, v5, v6, v7, v8, v9 };
            cantidadMonedas = new TextBox[] { c1, c2, c3, c4, c5, c6, c7, c8, c9 };
            verificarCantidadMonedas = new TextBox[] { vc1, vc2, vc3, vc4, vc5, vc6, vc7, vc8, vc9 };
            importeMonedas = new Label[] { i1, i2, i3, i4, i5, i6, i7, i8, i9 };

            valoresBilletes = new Label[] { bv1, bv2, bv3, bv4, bv5, bv6 };
            cantidadBilletes = new TextBox[] { bc1, bc2, bc3, bc4, bc5, bc6 };
            verificarCantidadBilletes = new TextBox[] { vbc1, vbc2, vbc3, vbc4, vbc5, vbc6 };
            importeBilletes = new Label[] { bi1, bi2, bi3, bi4, bi5, bi6 };

            int index = 0;
            //Que el de cantidad se brinque al de verificar
            foreach (TextBox t in cantidadMonedas)
            {
                //Calcular totales
                decimal d = decimal.Parse(valoresMonedas[index].Tag + "");
                Label lbl = importeMonedas[index];
                TextBox txtVerificar = verificarCantidadMonedas[index];
                t.TextChanged += (sender2, e2) => cambioCantidad(d, sender2, e2, lbl, txtVerificar);
                t.Click += new EventHandler(TextBox1_Click);


                TextBox cantSiguiente = null;

                cantSiguiente = verificarCantidadMonedas[index];

                t.KeyPress += (sender2, e2) => definirSiguienteEnEnter(sender2, e2, cantSiguiente);
                t.Text = "0";
                index++;
            }

            //Que el de verificar se brinque a la siguiente cantidad
            index = 0;
            foreach (TextBox t in verificarCantidadMonedas)
            {
                decimal d = decimal.Parse(valoresMonedas[index].Tag + "");
                Label lbl = importeMonedas[index];
                TextBox txtCantidad = cantidadMonedas[index];
                t.TextChanged += (sender2, e2) => cambioCantidad(d, sender2, e2, lbl, txtCantidad);
                t.Click += new EventHandler(TextBox1_Click);

                TextBox cantSiguiente = null;

                if (index + 1 < cantidadMonedas.Length)
                    cantSiguiente = cantidadMonedas[index + 1];
                else
                {
                    //El siguiente el bc1
                    cantSiguiente = cantidadBilletes[0];
                }

                t.KeyPress += (sender2, e2) => definirSiguienteEnEnter(sender2, e2, cantSiguiente);
                t.Text = "0";
                index++;
            }

            index = 0;
            //Que brinque a verificar
            foreach (TextBox t in cantidadBilletes)
            {
                decimal d = decimal.Parse(valoresBilletes[index].Tag + "");
                Label lbl = importeBilletes[index];
                TextBox txtVerificar = verificarCantidadBilletes[index];
                t.TextChanged += (sender2, e2) => cambioCantidad(d, sender2, e2, lbl, txtVerificar);
                t.Click += new EventHandler(TextBox1_Click);

                TextBox cantSiguiente = null;

                //if (index + 1 < cantidadBilletes.Length)
                    cantSiguiente = verificarCantidadBilletes[index];
               

                t.KeyPress += (sender2, e2) => definirSiguienteEnEnter(sender2, e2, cantSiguiente);
                t.Text = "0";
                index++;
            }

            index = 0;
            //Que brinque a siguiente cantidad
            foreach (TextBox t in verificarCantidadBilletes)
            {
                decimal d = decimal.Parse(valoresBilletes[index].Tag + "");
                Label lbl = importeBilletes[index];
                TextBox txtVerificar = cantidadBilletes[index];
                t.TextChanged += (sender2, e2) => cambioCantidad(d, sender2, e2, lbl, txtVerificar);
                t.Click += new EventHandler(TextBox1_Click);

                TextBox cantSiguiente = null;

                if (index + 1 < cantidadBilletes.Length)
                    cantSiguiente = cantidadBilletes[index + 1];
                else
                {
                    //El siguiente el bc1
                    cantSiguiente = cantidadMonedas[0];
                }

                t.KeyPress += (sender2, e2) => definirSiguienteEnEnter(sender2, e2, cantSiguiente);
                t.Text = "0";
                index++;
            }

            
        }

        private void TextBox1_Click(object sender, System.EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(error == false)
            {
                //Si es una verificacion de fondos entonces ver si conicide lo contado por el usuario o no
                //si coincide regresar ok
                //si no coincice entonces marcar el cierre del turno
                Programacion.Cajas obc = new Programacion.Cajas();

                if (tipoVentana == 1)
                {
                    //Registrar en BD


                    if (!esInicioDeTurno)
                    {
                        //Preguntar si quiere dejar fondo al siguiente turno
                        FondoSiguienteTurno obf = new FondoSiguienteTurno(decimal.Parse(txtTotal.Tag + ""));
                        DialogResult r = obf.ShowDialog(this);

                        if (r == DialogResult.OK)
                        {
                            timer.Stop();
                            // Get the elapsed time as a TimeSpan value.
                            TimeSpan ts = timer.Elapsed;

                            // Format and display the TimeSpan value.
                            duracionMinutos = ts.Minutes;
                            duracionSegundos = ts.Seconds;

                            fondoSiguienteTurno = obf.ObtenerFondo();
                            idTurno = obc.AgregarFondoCaja(decimal.Parse(txtTotal.Tag + ""), fondoSiguienteTurno, idCaja, idUsuario, esInicioDeTurno);
                        }
                        else
                            idTurno = "-2";

                    }
                    else 
                        idTurno = obc.AgregarFondoCaja(decimal.Parse(txtTotal.Tag + ""), fondoSiguienteTurno, idCaja, idUsuario, esInicioDeTurno);
                    
                    if (idTurno != "-1" && idTurno != "-2")
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        if (idTurno != "-2")
                            this.DialogResult = DialogResult.Cancel;
                }
                else
                {
                    if (tipoVentana == 2)
                    {
                        //Es verificacion de fondos
                        idTurno = obc.ObtenerIDTurnoCaja(idCaja);

                        decimal dineroEnCaja = obc.ObtenerDineroEnCaja(idTurno);

                        if (dineroEnCaja == decimal.Parse(txtTotal.Tag + ""))
                            this.DialogResult = DialogResult.OK;
                        else
                        {
                            decimal fondoSiguienteTurno = 0m;
                            //Preguntar si quiere dejar fondo al siguiente turno
                            FondoSiguienteTurno obf = new FondoSiguienteTurno(decimal.Parse(txtTotal.Tag + ""));
                            DialogResult r = obf.ShowDialog(this);

                            if (r == DialogResult.OK)
                            {
                                fondoSiguienteTurno = obf.ObtenerFondo();
                            }

                            //Marcar cierre de turno
                            obc.AgregarFondoCaja(decimal.Parse(txtTotal.Tag + ""), fondoSiguienteTurno, idCaja, idUsuario, false);

                            this.DialogResult = DialogResult.No;
                        }
                    }
                    else
                    {
                        if (tipoVentana == 3 || tipoVentana == 4)
                        {
                            if(ObtenerFondoContado()> 0)
                                this.DialogResult = DialogResult.OK;
                            
                        }

                    }
                }
            }
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            if (error == false)
            {
                //if (btnCambiar.Tag + "" == "0")
                //{
                //    btnCambiar.Text = "< Monedas";
                //    btnCambiar.Tag = "1";
                //    tabConteo.SelectedIndex = 1;
                //    this.ActiveControl = bc1;
                //}
                //else
                //{
                //    btnCambiar.Text = "Billetes >";
                //    btnCambiar.Tag = "0";
                //    tabConteo.SelectedIndex = 0;
                //    this.ActiveControl = c1;
                //}
            }
        }

        protected void cambioCantidad(decimal valor, object cantidad, EventArgs e, Label lblImporte, TextBox cantidad2)
        {
            string cant = ((TextBox)cantidad).Text;
            if (cant == "")
                cant = "0";
            decimal d = 0;
            try
            {
                d = decimal.Parse(cant);
                if (d > 0)
                {
                    int x = ((TextBox)cantidad).SelectionStart;

                    if (((TextBox)cantidad).Text[0] == '0')
                        x++;
                    
                    ((TextBox)cantidad).Text = d + "";

                    ((TextBox)cantidad).SelectionStart = x;
                }

                if (d < 0)
                    d = 0;
            }
            catch { }
            lblImporte.Text = string.Format("{0:C}",valor * d );
            lblImporte.Tag = valor * d + "";

            //Si los dos no son iguales marcar error
            if(((TextBox)cantidad).Text!=cantidad2.Text)
            {
                cantidad2.BackColor = Color.Tomato;
                ((TextBox)cantidad).BackColor = Color.Tomato;
                
            }
            else
            {
                if (cantidad2.Text != "" && cantidad2.Text != "0")
                {
                    cantidad2.BackColor = Color.GreenYellow;
                    ((TextBox)cantidad).BackColor = Color.GreenYellow;
                }
                else
                {
                    cantidad2.BackColor = SystemColors.GradientActiveCaption;
                    ((TextBox)cantidad).BackColor = SystemColors.GradientActiveCaption;
                }
            }

            CalcularTotal();
        }

        protected void txtCantidadVerificar(object cantidad, EventArgs e, TextBox txtCantidadSiguiente)
        {
            
                if (txtCantidadSiguiente != null)
                    this.ActiveControl = txtCantidadSiguiente;
                
        }

        protected void definirSiguienteEnEnter(object cantidad, KeyPressEventArgs e, TextBox txtCantidadSiguiente)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtCantidadSiguiente != null)
                {
                    this.ActiveControl = txtCantidadSiguiente;
                    txtCantidadSiguiente.SelectAll();
                }
                //else
                //{
                //    if (error == false)
                //        if (tabConteo.SelectedIndex == 0)
                //        {
                //            btnCambiar.Text = "< Monedas";
                //            btnCambiar.Tag = "1";
                //            tabConteo.SelectedIndex = 1;
                //            this.ActiveControl = bc1;
                //        }
                //        else
                //        {
                //            //btnAceptar.PerformClick();

                //            btnCambiar.Text = "> Billetes";
                //            btnCambiar.Tag = "0";
                //            tabConteo.SelectedIndex = 0;
                //            this.ActiveControl = c4;
                //        }
                //}
                e.Handled = true;
                
            }
        }

        private void CalcularTotal()
        {
            decimal tot = 0;
            this.error = false;

            foreach(Label l in importeMonedas)
            {
                tot += decimal.Parse(l.Tag + "");
            }

            if(importeBilletes!=null)
                foreach (Label l in importeBilletes)
                {
                    tot += decimal.Parse(l.Tag + "");
                }

            if (cantidadMonedas != null)
                foreach (TextBox t in cantidadMonedas)
                {
                    if (t.BackColor == Color.Tomato)
                        error = true;
                }

            if (cantidadBilletes!=null)
                foreach (TextBox t in cantidadBilletes)
                {
                    if (t.BackColor == Color.Tomato)
                        error = true;
                }

            txtTotal.Text = string.Format("{0:C}",tot);
            txtTotal.Tag = tot+"";
        }

        public string ObtenerIDTurno()
        {
            return idTurno;
        }
    
        public Label[] ObtenerValoresMonedas()
        {
            return valoresMonedas;
        }

        public TextBox[] ObtenerCantidadesMonedas()
        {
            return cantidadMonedas;
        }

        private void roundedButton6_Click(object sender, EventArgs e)
        {
            //Si el usuario no es admin pedir autorizacion

            if (ventanaPrincipal == null)
            {
                DialogResult res = MessageBox.Show("Se requiere autorizacion de un usuario administrador para abrir el cajon de dinero");

                if (res == DialogResult.OK)
                {
                    ValleVerdeComun.Vistas.InicioSesion.InicioSesion obi = new ValleVerdeComun.Vistas.InicioSesion.InicioSesion(true);
                    obi.ShowDialog();

                    ValleVerdeComun.Programacion.Huellas.ResultadoHuella usuario = obi.usuario;

                    obi.Close();
                    obi.Dispose();

                    //Si tiene un usuario quiere decir que fue autorizado
                    if (usuario != null)
                    {
                        new CajonDinero().AbrirCajon(impresoraTicket);
                    }
                }
            }
            else
            {
                //Bloquear caja y reproducir sonido
                int resultado = ventanaPrincipal.BloquearCaja(this,"Abrir cajon del dinero", true, "Autorizar apertura", true);

                if (resultado == 1)
                {
                    new CajonDinero().AbrirCajon(ventanaPrincipal.configuracionPV.ImpresoraTickets);
                }
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public Label[] ObtenerImportesMonedas()
        {
            return importeMonedas;
        }

        public Label[] ObtenerValoresBilletes()
        {
            return valoresBilletes;
        }

        public TextBox[] ObtenerCantidadesBilletes()
        {
            return cantidadBilletes;
        }

        public Label[] ObtenerImportesBilletes()
        {
            return importeBilletes;
        }

        public decimal ObtenerFondoSiguienteTurno()
        {
            return fondoSiguienteTurno;
        }

        public decimal ObtenerFondoContado()
        {
            return decimal.Parse(txtTotal.Tag+"");
        }
    }
}
