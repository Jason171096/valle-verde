using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion;
using ValleVerde.Programacion.RecursosHumanos;
using ValleVerdeComun.Programacion;

namespace ValleVerde.Vistas.RecursosHumanos
{
    public partial class MotivoBaja : Form
    {
        private Usuario datosUsuario;
        public MotivoBaja(Usuario datosUsuario, Usuario datosUsuarioFoto)
        {
            InitializeComponent();
            #region Desempeño de ComboBox
            comboBoxDesempeño.Items.Add("Deficiente");
            comboBoxDesempeño.Items.Add("Regular");
            comboBoxDesempeño.Items.Add("Bueno");
            comboBoxDesempeño.Items.Add("Excelente");
            #endregion
            #region Motivo Baja de ComboBox
            comboBoxMotivoBaja.Items.Add("Renuncia Voluntaria");
            comboBoxMotivoBaja.Items.Add("Recision de Contrato");
            #endregion
            this.datosUsuario = datosUsuario;
            textBoxID.Text = datosUsuario.idUsuario.ToString();
            textBoxNom.Text = datosUsuario.nombres;
            if (datosUsuarioFoto != null)
            {
                picFoto.Image = datosUsuarioFoto.foto;
            }

        }
        EmpleadoInactivo ei = new EmpleadoInactivo();
        private void btnDarBaja_Click(object sender, EventArgs e)
        {
            ei.Empleadoinactivo(datosUsuario.idUsuario.ToString(), datosUsuario.nombres, false);
            MessageBox.Show("Empleado dado de baja correctamente", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
