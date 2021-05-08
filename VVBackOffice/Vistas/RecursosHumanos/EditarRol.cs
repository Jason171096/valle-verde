using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion.RecursosHumanos;

namespace ValleVerde.Vistas.RecursosHumanos
{
    public partial class EditarRol : Form
    {
        private int idRol;
        private string nom;
        private DataTable dt;
        private DataGridView dgv;

        public EditarRol(int idRol, string nom, DataTable dt, DataGridView dgv)
        {
            InitializeComponent();
            this.idRol = idRol;
            this.nom = nom;
            this.dt = dt;
            this.dgv = dgv;
            lblNombre.Text = nom;
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(!tbNombre.Text.Equals(""))
            {
                ObtenerRoles obr = new ObtenerRoles();
                obr.CambiarRol(idRol, tbNombre.Text.ToString());
                dgv.CurrentRow.Cells[1].Value = tbNombre.Text.ToString();
                Close();
            } else
                MessageBox.Show("El nombre del rol no puede estar vacio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
