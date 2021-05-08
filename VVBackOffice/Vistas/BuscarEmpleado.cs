using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ValleVerde.Programacion.RecursosHumanos;
using ValleVerde.Programacion;
using ValleVerdeComun.Programacion;

namespace ValleVerde.Vistas
{
    public partial class BuscarEmpleado : Form
    {
        Validaciones v = new Validaciones();
        Usuarios OE = new Usuarios();
        BuscarEmpleadoyCliente BEC = new BuscarEmpleadoyCliente();
        DataTable dt;
        Usuario datosUsuario;
        Usuario datosUsuarioFoto;
        public BuscarEmpleado()
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvBuscarEmpleado, true, false, 14, 14);
            
        }

        private void BuscarEmpleado_Load(object sender, EventArgs e)
        {
            //DataTable dt recibe un metodo de la clase BEC BuscarEmpleado que es un DataTable
            dt = BEC.BuscarEmpleado();
            //dt le pasa la tabla al DataGridViewBuscarEmpleado
            dgvBuscarEmpleado.DataSource = dt;
            DarFormatoTabla();
        }
        
        private void TextBoxBuscarEmpleado_TextChanged(object sender, EventArgs e)
        {
            //Declaramos DataView para ver la tabla de DataTable dt
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("Convert(IDUsuario,'System.String') LIKE '%{0}%' OR Nombres LIKE '%{0}%'", textBoxBuscarEmpleado.Text);
            dgvBuscarEmpleado.DataSource = dv;
        }

        private void DataGridViewBuscarEmpleado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarUsuario();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            SeleccionarUsuario();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void SeleccionarUsuario()
        {       
            string idUsuario = dgvBuscarEmpleado.CurrentRow.Cells[0].Value.ToString();
            datosUsuario = OE.ObtenerUsuario(idUsuario, true);
            datosUsuarioFoto = OE.ObtenerUsuarioFoto(idUsuario);
            Close();          
        }

        public Usuario ObtenerUsuario()
        {
            return datosUsuario;
        }

        public Usuario ObtenerUsuarioFoto()
        {
            return datosUsuarioFoto;
        }

        private void textBoxBuscarEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumerosyLetras(sender, e);
        }
        private void DarFormatoTabla()
        {
            dgvBuscarEmpleado.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBuscarEmpleado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBuscarEmpleado.Columns[0].Width = 100;
            dgvBuscarEmpleado.Columns[1].Width = 300;
            dgvBuscarEmpleado.Columns[2].Width = 300;
            dgvBuscarEmpleado.Columns[3].Width = 250;
            dgvBuscarEmpleado.Columns[4].Width = 300;
        }
    }
}
