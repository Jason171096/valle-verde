using Pabo.Calendar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ValleVerde.Vistas.Reportes;
using ValleVerde.Programacion.Reportes;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Globalization;
using ValleVerde.Programacion.RecursosHumanos;
using ValleVerde.Programacion.Utileria;

namespace ValleVerde
{
    public partial class ReportesEmpleados : Form
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();
        ObtenerUsuariosyIrregularidades todosUsuarios = new ObtenerUsuariosyIrregularidades();
        DataTable dt = new DataTable();
        DataTable dtIrre = new DataTable();
        TemplateWord word = new TemplateWord();
        CopiaryPegarDocWord moverDoc = new CopiaryPegarDocWord();
        Validaciones v = new Validaciones();
        public ReportesEmpleados()
        {
            InitializeComponent();
            FormatDates();
            dt = todosUsuarios.TodosDatosUsuarios();
            dtIrre = todosUsuarios.UsuariosIrregularidades();
        }

        private void ReportesEmpleados_Load(object sender, EventArgs e)
        {
            CargarDataGridView();
            FormatosDataGrid();

            lblUsuario.Visible = false;
            lblVenta.Visible = false;
            
            List<Tuple<string ,string, string>> cumple = new List<Tuple<string, string, string>>();
            foreach(DataRow row in dt.Rows)
            {
                var tup = Tuple.Create(row[0].ToString(), row[1].ToString(), Convert.ToDateTime(row[5].ToString()).ToString("dd/MM/yyyy"));
                cumple.Add(tup);
            }


            //for (int i = 0; i < cumple.Count; i++)
            //{
            //    MessageBox.Show(cumple[i].Item3);
            //}
            //List<DateTime> datetime = new List<DateTime>();
            //    foreach (DataGridViewRow item in dataGridViewCumpleEmpleado.Rows)
            //    {
            //        int FechaActual = Convert.ToInt32(DateTime.Now.ToString("yyyy"))+1;
            //        var time = item.Cells[3].Value.ToString();
            //        int year = Convert.ToInt32(Format(time)); 
            //        if (FechaActual != year)
            //        {
            //            year += FechaActual - year;
            //        }
            //        datetime.Add(Convert.ToDateTime(Format2(time, year)));
            //    }
            //    datetime.Sort((a, b) => a.CompareTo(b));
            //    var greaterThanNow = datetime.SkipWhile(x => x <= DateTime.Now).First();
            //    lblCumple.Text = "Fecha proxima de cumpleañero es: " + greaterThanNow.AddYears(-1);
            //    if (greaterThanNow == DateTime.Now)
            //    {
            //        Notificaciones notificaciones = new Notificaciones();
            //        notificaciones.Texto = "Hoy es el cumpleaños";
            //        notificaciones.Show();
            //    }

           
           
        }
        //private string Format(string str)//Metodo para dar el primero formato de la fecha de cumpleaños
        //{
        //    var str1 = str.Substring(0, str.Length - 15);
        //    string[] split = str1.Split('/');
        //    return split[2];
        //}

        //private string Format2(string str, int year)//Metodo para dar el segundo formato de la fecha de cumpleaños
        //{
        //    var str1 = str.Substring(0, str.Length - 15);
        //    var stringBuilder = new StringBuilder(str1);
        //    stringBuilder.Remove(6, 4);
        //    stringBuilder.Insert(6, year + "");
        //    return stringBuilder.ToString();
        //}
        #region Acciones
        private void textBoxBuscarEmpleado_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("Convert(IDUsuario,'System.String') LIKE '%{0}%' OR Nombres LIKE '%{0}%'", textBoxBuscarEmpleado.Text);
            dataGridViewBuscarEmpleado.DataSource = dv;
        }
        private void btnDatosImprimir_Click(object sender, EventArgs e)
        {
            
        }

        private void btnListaEmpleados_Click(object sender, EventArgs e)
        {

        }
        private void btnActaAdministrativa_Click(object sender, EventArgs e)
        {
            //Si te da error es solamente de colocar el documento "ActaAdministrativa" Word en el Escritorio
            string WordActa = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Word\ActaAdministrativa.docx";
            moverDoc.CopiarDocumentosWord(WordActa, "ActaAdministrativa.docx");
            word.DocumentoWord("ActaAdministrativa.docx", dataGridViewBuscarEmpleado.CurrentRow.Cells[1].Value.ToString(),
                dataGridViewBuscarEmpleado.CurrentRow.Cells[2].Value.ToString());
        }
        private void btnConstanciaTrabajo_Click(object sender, EventArgs e)
        {
            //Si te da error es solamente de colocar el documento "ContanciaTrabajo" Word en el Escritorio
            string WordConstancia = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Word\ConstanciaTrabajo.docx";
            moverDoc.CopiarDocumentosWord(WordConstancia, "ConstanciaTrabajo.docx");
            word.DocumentoWord("ConstanciaTrabajo.docx", dataGridViewBuscarEmpleado.CurrentRow.Cells[1].Value.ToString(),
                dataGridViewBuscarEmpleado.CurrentRow.Cells[2].Value.ToString());
        }
        #endregion
        #region Ventas
        private void dataGridViewVentasEmple_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridViewVentasEmple.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dataGridViewVentasEmple.CurrentRow.Cells[1].Value.ToString();
            if (String.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Seleccione un empleado", "¡ADVERTENCIA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                VentaEmpleado venta = new VentaEmpleado();
                decimal suma = 0;
                dataGridViewVentasEmpleados.DataSource = venta.VentasEmpleados(txtID.Text, dtinicio.Value.Date, dtfin.Value.Date);
                dataGridViewVentasEmpleados.Columns[0].Width = 60;
                dataGridViewVentasEmpleados.Columns[1].Width = 150;
                dataGridViewVentasEmpleados.Columns[2].Width = 150;

                foreach (DataGridViewRow item in dataGridViewVentasEmpleados.Rows)
                {
                    suma += decimal.Parse(item.Cells[2].Value.ToString(), NumberStyles.Currency);
                }
                lblUsuario.Text = $"La suma total de ventas del Usuario: {txtNombre.Text}";
                lblVenta.Text = String.Format("Corresponde de: {0:C2}", suma);

                lblUsuario.Visible = true;
                lblVenta.Visible = true;
            }
        }
        #endregion
        #region Proximos Eventos
        private void FormatDates()//Metodo que llena el calendario con las fechas de nacimiento de los empleados
        {
            monthCalendar1.ActiveMonth.Month = int.Parse(DateTime.Now.ToString("MM"));
            monthCalendar1.ActiveMonth.Year = int.Parse(DateTime.Now.ToString("yyyy"));
            ob.AbrirConexionBD();
            SqlCommand sqlCommand = new SqlCommand($"select Nombres, FechaNacimiento from Usuario where Activo = 1", ob.ObtenerConexion());
            SqlCommand sqlCommand2 = new SqlCommand($"select count(FechaNacimiento) from Usuario where Activo = 1", ob.ObtenerConexion());
            List<string> listaF = new List<string>();
            List<string> listaN = new List<string>();
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
                while (reader.Read())
                {
                    listaN.Add(reader["Nombres"].ToString());
                    listaF.Add(Convert.ToDateTime(reader["FechaNacimiento"]).ToString("yyyy/MM/dd"));
                }
            int cout = Convert.ToInt32(sqlCommand2.ExecuteScalar());
            DateItem[] d = new DateItem[cout];
            d.Initialize();
            int FechaActual = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
            for (int i = 0; i < cout; i++)
            {
                d[i] = new DateItem();
            }
            for (int j = 0; j < cout; j++)
            {
                string[] birthday = listaF[j].Split('/');
                int year, month, day;
                int.TryParse(birthday[0], out year);
                int.TryParse(birthday[1], out month);
                int.TryParse(birthday[2], out day);
                if (FechaActual != year)
                {
                    year += FechaActual - year;
                }
                d[j].Date = new DateTime(year, month, day);
                d[j].BackColor1 = Color.Green;
                d[j].Text = "Birth";
                monthCalendar1.AddDateInfo(d);
            }
            ob.CerrarConexionBD();
        }

        private void monthCalendar1_DaySelected(object sender, DaySelectedEventArgs e)//Llena los dias seleccionados del calendario
        {
            string[] dia_seleccionado = e.Days;
        }

        #endregion
        #region Irregularidades
        private void dataGridViewIrreEmple_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxID.Text = dataGridViewIrreEmple.CurrentRow.Cells[0].Value.ToString();
            textBoxNom.Text = dataGridViewIrreEmple.CurrentRow.Cells[1].Value.ToString();
        }
        private void btnConfirmarIrre_Click_1(object sender, EventArgs e)
        {
            IrregularidadEmpleado irregularidad = new IrregularidadEmpleado();
            irregularidad.AgregarIrregularidad(textBoxID.Text, textBoxNom.Text, textBoxIrre.Text);
            textBoxID.Text = "";
            textBoxNom.Text = "";
            textBoxIrre.Text = "";
            //Lo delcaro null para que se borren los datos del datagrigview
            dataGridViewIrregularidades.DataSource = null;
            //Lo mando llamar para que se actualice la tabla
            ActualizarListaIrregularidad();
        }
        private void btnEliminarIrregularidad_Click(object sender, EventArgs e)
        {
            IrregularidadEmpleado irregularidad = new IrregularidadEmpleado();
            irregularidad.EliminarIrregularidad(dataGridViewIrregularidades.CurrentRow.Cells[0].Value.ToString(),
                dataGridViewIrregularidades.CurrentRow.Cells[1].Value.ToString(), dataGridViewIrregularidades.CurrentRow.Cells[2].Value.ToString());
            //Lo delcaro null para que se borren los datos del datagrigview
            dataGridViewIrregularidades.DataSource = null;
            //Lo mando llamar para que se actualice la tabla
            ActualizarListaIrregularidad();
        }

        private void ActualizarListaIrregularidad()
        {
            //Actualiza la tabla de Irregularidades 
            dtIrre.Clear();
            dtIrre = todosUsuarios.UsuariosIrregularidades();
            dataGridViewIrregularidades.DataSource = dtIrre;
        }

        #endregion
        #region Cargar DataGridView y Formatos

        private void CargarDataGridView()
        {
            //Carga el datagridview de Acciones
            DataView view1 = new DataView(dt);
            DataTable select1 = view1.ToTable("select", false, "IDUsuario", "Nombres", "Apellidos", "Celular");
            dataGridViewBuscarEmpleado.DataSource = select1;

            //Carga el datagridview de Proximos Eventos
            DataView view2 = new DataView(dt);
            DataTable select2 = view2.ToTable("select", false, "IDUsuario", "Nombres", "Apellidos", "FechaNacimiento", "FechaAlta");
            dataGridViewCumpleEmpleado.DataSource = select2;

            //Carga la DataGridview que esta en Irregularidades y de Ventas
            DataView view3 = new DataView(dt);
            DataTable select3 = view3.ToTable("select", false, "IDUsuario", "Nombres");
            dataGridViewIrreEmple.DataSource = select3;
            dataGridViewVentasEmple.DataSource = select3;

            //Carga la DataGridview que esta en Irregularidades

            DataView view4 = new DataView(dtIrre);
            DataTable select4 = view4.ToTable("select", false, "IDUsuario", "Nombres", "Irregularidad");
            dataGridViewIrregularidades.DataSource = select4;

        }

        private void FormatosDataGrid()
        {
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dataGridViewBuscarEmpleado, true, false);
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dataGridViewCumpleEmpleado, true, false);
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dataGridViewIrreEmple, true, false);
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dataGridViewVentasEmpleados, true, false);
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dataGridViewIrregularidades, true, false);
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dataGridViewVentasEmple, true, false);

            
        }

        #endregion
        #region Buscar
        private void txtBuscar2_TextChanged(object sender, EventArgs e)
        {
            dataGridViewIrreEmple.DataSource = Buscar(txtBuscar2);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            
            dataGridViewVentasEmple.DataSource = Buscar(txtBuscar);
        }

        private DataTable Buscar(TextBox text)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("Convert(IDUsuario,'System.String') LIKE '%{0}%' OR Nombres LIKE '%{0}%'", text.Text);
            
            DataTable select = dv.ToTable("select", false, "IDUsuario", "Nombres");
            return select;
        }





        #endregion
        #region Validaciones
        private void textBoxBuscarEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumerosyLetras(sender, e);
        }
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumerosyLetras(sender, e);
        }

        #endregion


    }
}
