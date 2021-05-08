using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion;
using ValleVerde.Programacion.RecursosHumanos;

namespace ValleVerde.Vistas.RecursosHumanos
{
    public partial class BajaCliente : Form
    {
        DatosClientes datosCliente;
        Cliente AC = new Cliente();
        public BajaCliente(DatosClientes datosCliente)
        {
            InitializeComponent();
            this.datosCliente = datosCliente;
        }

        private void BajaCliente_Load(object sender, EventArgs e)
        {
            textBoxID.Text = datosCliente.idcliente.ToString();
            textBoxNom.Text = datosCliente.nombres;
        }

        private void btnDarBaja_Click(object sender, EventArgs e)
        {
            AC.BajaCliente(datosCliente.nombres);
            Close();
        }
    }
}
