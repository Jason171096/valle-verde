using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion.Configuracion;

namespace ValleVerde.Vistas.Configuracion
{
    public partial class Tickets2 : Form
    {
        SeleccionTicket obj = new SeleccionTicket();
        public Tickets2()
        {
            InitializeComponent();            
        }

        private void Tickets2_Load(object sender, EventArgs e)
        {
            LlenadoCombo();
        }

        private void LlenadoCombo()
        {
            List<string[]> res = obj.ObtenerTickets();

            ventas.DisplayMember = "Text";
            ventas.ValueMember = "Value";
            devolucion.DisplayMember = "Text";
            devolucion.ValueMember = "Value";
            foreach (string[] tic in res)
            {
                ventas.Items.Add(new { Value = tic[0], Text = tic[1] });
                devolucion.Items.Add(new { Value = tic[0], Text = tic[1] });
            }
            string nombreVentas = obj.getTicketsVentas();
            ventas.SelectedIndex = ventas.FindStringExact(nombreVentas);

            string nombreDevolucion = obj.getTicketsDevolucion();
            devolucion.SelectedIndex = devolucion.FindStringExact(nombreDevolucion);

            decimal maximoPendientes = obj.getMaximoPendientes();
            TicketsPendientes.Value = maximoPendientes;

            ValidaToggle();
        }

        private void toggle1_Click(object sender, EventArgs e)
        {
            ValidaToggle();
        }

        private void toggleDevolucion_Click(object sender, EventArgs e)
        {
            ValidaToggle();
        }

        private void togglePendientes_Click(object sender, EventArgs e)
        {
            ValidaToggle();
        }

        private void ValidaToggle()
        {
            if (toggleVentas.IsOn)
            {
                ventas.Enabled = true;
            }
            else
            {
                ventas.Enabled = false;
            }

            if (toggleDevolucion.IsOn)
            {
                devolucion.Enabled = true;
            }
            else
            {
                devolucion.Enabled = false;
            }

            if (togglePendientes.IsOn)
            {
                TicketsPendientes.Enabled = true;
            }
            else
            {
                TicketsPendientes.Enabled = false;
            }
        }

        private void ventas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string setVentas = (ventas.SelectedItem as dynamic).Value + "";
            string res = obj.ModicarConfig("IDTicketVentas", setVentas);
            ValidaError(res);
        }

        private void devolucion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string setDevolucion = (devolucion.SelectedItem as dynamic).Value + "";
            string res = obj.ModicarConfig("IDTicketDevoluciones", setDevolucion);
            ValidaError(res);
        }

        private void agregarMaxPend_Click(object sender, EventArgs e)
        {
            string setMaxPedientes = TicketsPendientes.Value.ToString();
            string res = obj.ModicarConfig("numeroTicketsMaximo", setMaxPedientes);
            ValidaError(res);
        }

        private void ValidaError(string resultado)
        {
            if (resultado != "-1")
            {
                MessageBox.Show("Ocurrio un error en la modificación","Error");
            }
        }
    }
}
