using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion.Utileria;

namespace ValleVerde.Vistas.Utileria
{
    public partial class EscanearLuegoImprimir : Form
    {
        Validaciones v = new Validaciones();
        ValleVerdeComun.BuscarProducto buscar;
        private string idusuario;
        public EscanearLuegoImprimir(string idusuario)
        {
            InitializeComponent();
            txtCodigo.TabIndex = 0;
            this.idusuario = idusuario;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ClaseCodigosPreescaneados guardar = new ClaseCodigosPreescaneados();
                guardar.GuardarEtiquetas(txtCodigo.Text, idusuario);
                txtCodigo.Text = "";
            }
            catch(Exception ex)
            {
                txtCodigo.Text = "";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnGuardar.PerformClick();
            }
            else if (e.KeyValue == 119 || e.KeyValue == 40)
            {
                buscar = new ValleVerdeComun.BuscarProducto(txtCodigo, btnGuardar, false);
                buscar.ShowDialog();
                txtCodigo.SelectAll();
            }
            else if (e.KeyCode == Keys.Escape)
                Close();
        }   

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar = new ValleVerdeComun.BuscarProducto(txtCodigo, btnGuardar, false);
            buscar.ShowDialog();
            txtCodigo.SelectAll();
        }
    }
}
