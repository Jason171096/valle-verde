using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ValleVerde.Programacion;
using ValleVerde.Programacion.RecursosHumanos;
using ValleVerde.Programacion.Utileria;
using ValleVerdeComun.Programacion;

namespace ValleVerde.Vistas.RecursosHumanos
{
    public partial class ExEmpleados : Form
    {
        public ExEmpleados()
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvExEmpleados, true, false, 14, 14);
        }
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();
        DataTable dt = new DataTable("Usuario");
        Usuario AE = new Usuario();
        TemplateWord word = new TemplateWord();
        CopiaryPegarDocWord moverDoc = new CopiaryPegarDocWord();
        Usuario datosUsuario;
        Usuarios OE = new Usuarios();
        

        private void textBoxBuscarExEmpleado_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("Convert(IDUsuario,'System.String') LIKE '%{0}%' OR Nombres LIKE '%{0}%'", textBoxBuscarExEmpleado.Text);
            dgvExEmpleados.DataSource = dv;
        }

        private void ExEmpleados_Load(object sender, EventArgs e)
        {
            try
            {
                ob.AbrirConexionBD();
                using (SqlDataAdapter da = new SqlDataAdapter("select Nombres, Usuario, Apellidos, Celular, Email from Usuario where Activo = 0", ob.ObtenerConexion()))
                {
                    da.Fill(dt);
                    dgvExEmpleados.DataSource = dt;
                }
                ob.CerrarConexionBD();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnImprimirEx_Click(object sender, EventArgs e)
        {
            SeleccionarUsuario();
            PDFEmpleado pdf = new PDFEmpleado(datosUsuario);
            Process.Start(pdf.filename);
        }

        private void btnReingresar_Click(object sender, EventArgs e)
        {
            EmpleadoInactivo ei = new EmpleadoInactivo();
            ei.Empleadoinactivo(dgvExEmpleados.CurrentRow.Cells[0].Value.ToString(), dgvExEmpleados.CurrentRow.Cells[1].Value.ToString(), true);
            MessageBox.Show("Empleado reingresado de forma correcta", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnListaExEmpleados_Click(object sender, EventArgs e)
        {
            DatosTodosExEmpleados datosTodosExEmpleados = new DatosTodosExEmpleados();
            datosTodosExEmpleados.Show();
        }

        private void btnCartaReco_Click(object sender, EventArgs e)
        {
            //Si te da error es solamente de colocar el documento "CartaRecomendacion" Word en el Escritorio
            string WordRecomendacion = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Word\CartaRecomendacion.docx";
            moverDoc.CopiarDocumentosWord(WordRecomendacion, "CartaRecomendacion.docx");
            word.DocumentoWord("CartaRecomendacion.docx", dgvExEmpleados.CurrentRow.Cells[1].Value.ToString(),
                dgvExEmpleados.CurrentRow.Cells[2].Value.ToString());
        }

        private void SeleccionarUsuario()
        {
            string idUsuario = dgvExEmpleados.CurrentRow.Cells[0].Value.ToString();
            datosUsuario = OE.ObtenerUsuario(idUsuario, false);
            Close();
        }
    }
}
