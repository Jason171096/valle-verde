using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerdeComun.Vistas
{
    public partial class VerificarDatos : Form
    {
        public VerificarDatos()
        {
            InitializeComponent();
            this.TransparencyKey = Color.Turquoise;
            this.BackColor = Color.Turquoise;

            FormBorderStyle = FormBorderStyle.None;
        }

        private void VerificarDatos_Load(object sender, EventArgs e)
        {

        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
        }

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
        }

        public void SetDatos(string cuenta, string monto)
        {
            lblCuenta.Text = cuenta;
            lblMonto.Text = monto;
        }

        public void SetDatos(string etiqueta1, string valor1, string etiqueta2, string valor2)
        {
            lblContratoT.Text = etiqueta1;
            lblCuenta.Text = valor1;
            lblMontoT.Text = etiqueta2;
            lblMonto.Text = valor2;
        }

        public void SetDatos(string titulo, string etiqueta1, string valor1)
        {
            lblTitulo.Text = titulo;
            lblTitulo.Height += 85;
            lblMontoT.Text = etiqueta1;
            lblMonto.Text = valor1;
            lblContratoT.Visible = false;
            lblCuenta.Visible = false;
        }

        public void SetDatosPregunta(string titulo, string etiqueta1, string etiqueta2, string btnCancelar, string btnAceptar)
        {
            lblTitulo.Text = titulo;
            lblTitulo.Font = new Font(lblTitulo.Font.Name, 42);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            lblContratoT.Text = etiqueta1;
            lblContratoT.Font = new Font(lblContratoT.Font.Name, 26);
            lblContratoT.Width = lblTitulo.Width;
            lblContratoT.Visible = true;
            lblContratoT.TextAlign = ContentAlignment.MiddleLeft;
            lblContratoT.ForeColor = Color.White;
            lblContratoT.Padding = new Padding(10, 0, 10, 0);

            lblMontoT.Text = etiqueta2;
            lblMontoT.Font = new Font(lblMontoT.Font.Name, 22);
            lblMontoT.Width = lblTitulo.Width;
            lblMontoT.Visible = true;
            lblMontoT.TextAlign = ContentAlignment.MiddleLeft;
            lblMontoT.ForeColor = Color.White;
            lblMontoT.Padding = new Padding(10, 0, 10, 0);

            this.btnCancelar.Text = btnCancelar;
            this.btnAceptar.Text = btnAceptar;

            lblMonto.Visible = false;
            lblCuenta.Visible = false;
        }
    }
}
