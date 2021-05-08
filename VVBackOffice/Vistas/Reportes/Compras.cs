using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ValleVerde.Programacion.Reportes;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;

namespace ValleVerde
{
    public partial class ReportesCompras : Form
    {
        ReporteCompras Reporte = new ReporteCompras();
        private float totalComprado = 0;
        public ReportesCompras()
        {
            InitializeComponent();
            rbtnMes.Checked = true;
            rbtnNinguno.Checked = true;
            dtFechaInicial.MinDate = new DateTime(2018, 12, 01);
            dtFechaInicial.MaxDate = DateTime.Now.Date;
            dtFechaFinal.MinDate = new DateTime(2018, 12, 01);
            dtFechaFinal.MaxDate = DateTime.Now.Date;
        }

        #region LlenarComboBox
        private void Meses()
        {
            //Diccionario donde se guardaran los Meses con sus claves 
            Dictionary<string, int> Month = new Dictionary<string, int>();
            {
                Month.Add("Enero", 1);
                Month.Add("Febrero", 2);
                Month.Add("Marzo", 3);
                Month.Add("Abril", 4);
                Month.Add("Mayo", 5);
                Month.Add("Junio", 6);
                Month.Add("Julio", 7);
                Month.Add("Agosto", 8);
                Month.Add("Septiembre", 9);
                Month.Add("Octubre", 10);
                Month.Add("Noviembre", 11);
                Month.Add("Diciembre", 12);
            };
            //Pasamos el diccionario como DataSource del combobox
            cboxMesYear.DataSource = new BindingSource(Month, null);
            cboxMesYear.DisplayMember = "Key";
            cboxMesYear.ValueMember = "Value";
        }

        private void Anos(bool star)
        {
            //Creamos Lista con los años 
            List<int> yearList = new List<int>();
            int years = DateTime.Now.Year;
            for (int i = 10; i >= 0; i--)
            {
                //Añadimos a la lista los años con un rango de 10
                yearList.Add(years - 10 + i);
            }
            //Se lo pasamos al combobox
            if (star)
                cboxMesYear.DataSource = new BindingSource(yearList, null);
            else
                cboxCYear.DataSource = new BindingSource(yearList, null);
        }

        private void Lineas()
        {
            //Cremamos la lista nombrelineas para obtener los empleados 
            List<String[]> nombrelineas = Reporte.Obtenerlineas();
            List<Object> lineasObject = new List<Object>();
            foreach (String[] item in nombrelineas)
            {
                //Recorremos la lista de nombrelineas para añadirla en lineasObject
                lineasObject.Add(new { Value = int.Parse(item[0]), Text = item[1] });
            }
            //Añadimos lineasObject al DataSource del comboboxLineaFabriPro 
            cboxLineaFabriPro.ValueMember = "Value";
            cboxLineaFabriPro.DisplayMember = "Text";
            cboxLineaFabriPro.DataSource = lineasObject;

        }
        private void Marcas()
        {
            //Cremamos la lista nombremarcas para obtener los empleados 
            List<String[]> nombremarcas = Reporte.Obtenermarcas();
            List<Object> marcasObject = new List<Object>();
            foreach (String[] item in nombremarcas)
            {
                //Recorremos la lista de nombrelineas para añadirla en lineasObject
                marcasObject.Add(new { Value = int.Parse(item[0]), Text = item[1] });
            }
            //Añadimos lineasObject al DataSource del comboboxLineaFabriPro 
            cboxLineaFabriPro.ValueMember = "Value";
            cboxLineaFabriPro.DisplayMember = "Text";
            cboxLineaFabriPro.DataSource = marcasObject;
        }

        private void Fabricantes()
        {
            //Cremamos la lista nombrefabricante para obtener los empleados 
            List<String[]> nombrefabricante = Reporte.Obtenerfabricantes();
            List<Object> fabricanteObject = new List<Object>();
            foreach (String[] item in nombrefabricante)
            {
                //Recorremos la lista de nombrefabricante para añadirla en fabricanteObject
                fabricanteObject.Add(new { Value = int.Parse(item[0]), Text = item[1] });
            }
            //Añadimos lineasObject al DataSource del comboboxLineaFabriPro 
            cboxLineaFabriPro.ValueMember = "Value";
            cboxLineaFabriPro.DisplayMember = "Text";
            cboxLineaFabriPro.DataSource = fabricanteObject;
        }
        private void Proveedores()
        {
            //Cremamos la lista nombreproveedor para obtener los empleados 
            List<String[]> nombreproveedor = Reporte.Obtenerproveedores();
            List<Object> proveedorObject = new List<Object>();
            foreach (String[] item in nombreproveedor)
            {
                //Recorremos la lista de nombreproveedor para añadirla en proveedorObject
                proveedorObject.Add(new { Value = int.Parse(item[0]), Text = item[1] });
            }
            //Añadimos proveedorObject al DataSource del comboboxLineaFabriPro 
            cboxLineaFabriPro.ValueMember = "Value";
            cboxLineaFabriPro.DisplayMember = "Text";
            cboxLineaFabriPro.DataSource = proveedorObject;
        }

        #endregion
        #region CheckedChanged
        private void rbtnMes_CheckedChanged(object sender, EventArgs e)
        {
            cboxMesYear.DataSource = null;
            cboxMesYear.Enabled = true;
            cboxCYear.Enabled = true;
            Meses();
            Anos(false);
            dtFechaInicial.Enabled = false;
            dtFechaFinal.Enabled = false;
        }

        private void rbtnYear_CheckedChanged(object sender, EventArgs e)
        {
            cboxMesYear.DataSource = null;
            cboxMesYear.Enabled = true;
            Anos(true);
            cboxCYear.Enabled = false;
            dtFechaInicial.Enabled = false;
            dtFechaFinal.Enabled = false;
        }

        private void rbtnFecha_CheckedChanged(object sender, EventArgs e)
        {
            cboxMesYear.Enabled = false;
            cboxCYear.Enabled = false;
            dtFechaInicial.Enabled = true;
            dtFechaFinal.Enabled = true;
        }

        private void rbtnLinea_CheckedChanged(object sender, EventArgs e)
        {
            cboxLineaFabriPro.DataSource = null;
            Lineas();
            cboxLineaFabriPro.Enabled = true;
        }

        private void rbtnMarca_CheckedChanged(object sender, EventArgs e)
        {
            cboxLineaFabriPro.DataSource = null;
            Marcas();
            cboxLineaFabriPro.Enabled = true;
        }

        private void rbtnFabricante_CheckedChanged(object sender, EventArgs e)
        {
            cboxLineaFabriPro.DataSource = null;
            Fabricantes();
            cboxLineaFabriPro.Enabled = true;
        }

        private void rbtnProveedor_CheckedChanged(object sender, EventArgs e)
        {
            cboxLineaFabriPro.DataSource = null;
            Proveedores();
            cboxLineaFabriPro.Enabled = true;
        }

        private void rbtnNinguno_CheckedChanged(object sender, EventArgs e)
        {
            cboxLineaFabriPro.DataSource = null;
            cboxLineaFabriPro.Enabled = false;
        }
        #endregion
        #region Compras por Mes
        private void MonthLinea(int pMonth, int pYearC, string pIDlinea)
        {
            ListTupleMonth(pMonth, pYearC, pIDlinea, -1, -1, -1);
        }
        private void MonthMarca(int pMonth, int pYearC, int pIDmarca)
        {
            ListTupleMonth(pMonth, pYearC, "-1", pIDmarca, -1, -1);
        }
        private void MonthFabricante(int pMonth, int pYearC, int pIDfabricante)
        {
            ListTupleMonth(pMonth, pYearC, "-1", -1, pIDfabricante, -1);
        }
        private void MonthProveedor(int pMonth, int pYearC, int pIDproveedor)
        {
            ListTupleMonth(pMonth, pYearC, "-1", -1, -1, pIDproveedor);
        }
        private void Month(int pMonth, int pYearC)
        {
            ListTupleMonth(pMonth, pYearC, "-1", -1, -1, -1);
        }
        private void ListTupleMonth(int pMonth, int pYearM, string pIDlinea, int pIDmarca, int pIDfabricante, int pIDproveedor)
        {
            //Se crea List<Tuple<>>
            List<Tuple<float, DateTime>> totalesdelmes = new List<Tuple<float, DateTime>>();
            //Dependiendo de los parametros recibidos entra al metodo para recoger las Compras del Mes
            if (pIDlinea == "-1" && pIDmarca == -1 && pIDfabricante == -1 && pIDproveedor == -1)
                totalesdelmes = Reporte.ComprasMes(pMonth, pYearM, "-1", -1, -1, -1);
            else if (pIDlinea != "-1" && pIDmarca == -1 && pIDfabricante == -1 && pIDproveedor == -1)
                totalesdelmes = Reporte.ComprasMes(pMonth, pYearM, pIDlinea, -1, -1, -1);
            else if (pIDlinea == "-1" && pIDmarca != -1 && pIDfabricante == -1 && pIDproveedor == -1)
                totalesdelmes = Reporte.ComprasMes(pMonth, pYearM, "-1", pIDmarca, -1, -1);
            else if (pIDlinea == "-1" && pIDmarca == -1 && pIDfabricante != -1 && pIDproveedor == -1)
                totalesdelmes = Reporte.ComprasMes(pMonth, pYearM, "-1", -1, pIDfabricante, -1);
            else if (pIDlinea == "-1" && pIDmarca == -1 && pIDfabricante == -1 && pIDproveedor != -1)
                totalesdelmes = Reporte.ComprasMes(pMonth, pYearM, "-1", -1, -1, pIDproveedor);

            if (totalesdelmes.Count == 0)
                lblSinCompras.Visible = true;
            else
            {
                lblSinCompras.Visible = false;
                ClearChartArea();
                DaysoftheMonth(totalesdelmes);
            }
        }
        private void DaysoftheMonth(List<Tuple<float, DateTime>> TotalesdelMes)
        {
            ChartArea chart = new ChartArea();
            CustomLabel custom;
            int star = 0, end = 2;
            int diasSaltos = 1;
            foreach (Tuple<float, DateTime> item in TotalesdelMes)
            {
                chart1.Series[0].Points.AddXY(item.Item2.Day, item.Item1);
                while (diasSaltos != item.Item2.Day)
                {
                    chart1.Series[0].Points.AddXY(diasSaltos, 0);
                    custom = new CustomLabel(star, end, diasSaltos.ToString(), 0, LabelMarkStyle.None);
                    chart.AxisX.CustomLabels.Add(custom);
                    star += 1;
                    end += 1;
                    diasSaltos++;
                }
                custom = new CustomLabel(star, end, item.Item2.Day.ToString(), 0, LabelMarkStyle.None);
                chart.AxisX.CustomLabels.Add(custom);
                star += 1;
                end += 1;
                diasSaltos++;
                totalComprado += item.Item1;
            }
            chart1.Series[0].ToolTip = "Compra \n Día: #VALX \n #VAL{C}";
            chart.AxisX.Title = "Días";
            chart.AxisY.Title = "Total";
            chart.AxisY.TitleFont = new Font("Arial", 16, FontStyle.Bold);
            chart.AxisX.TitleFont = new Font("Arial", 16, FontStyle.Bold);
            chart.AxisY.LabelStyle.Format = "{C0}";
            chart.BackColor = Color.Transparent;
            chart1.ChartAreas.Add(chart);
            lblTotalComprado.Text = string.Format("{0:C}", totalComprado);
        }
        #endregion
        #region Compras por Año
        private void YearLinea(int pYear, string pIDlinea)
        {
            ListTupleYear(pYear, pIDlinea, -1, -1, -1);
        }
        private void YearMarca(int pYear, int pIDmarca)
        {
            ListTupleYear(pYear, "-1", pIDmarca, -1, -1);
        }
        private void YearFabricante(int pYear, int pIDfabricante)
        {
            ListTupleYear(pYear, "-1", -1, pIDfabricante, -1);
        }
        private void YearProveedor(int pYear, int pIDproveedor)
        {
            ListTupleYear(pYear, "-1", -1, -1, pIDproveedor);
        }
        private void Year(int pYear)
        {
            ListTupleYear(pYear, "-1", -1, -1, -1);
        }
        private void ListTupleYear(int pYear, string pIDlinea, int pIDmarca, int pIDfabricante, int pIDproveedor)
        {
            //Se crea List<Tuple<>>
            List<Tuple<float, DateTime>> totalesdelyear = new List<Tuple<float, DateTime>>();
            //Dependiendo de los parametros recibidos entra al metodo para recoger las Compras del Mes
            if (pIDlinea == "-1" && pIDmarca == -1 && pIDfabricante == -1 && pIDproveedor == -1)
                totalesdelyear = Reporte.ComprasYear(pYear, "-1", -1, -1, -1);
            else if (pIDlinea != "-1" && pIDmarca == -1 && pIDfabricante == -1 && pIDproveedor == -1)
                totalesdelyear = Reporte.ComprasYear(pYear, pIDlinea, -1, -1, -1);
            else if (pIDlinea == "-1" && pIDmarca != -1 && pIDfabricante == -1 && pIDproveedor == -1)
                totalesdelyear = Reporte.ComprasYear(pYear, "-1", pIDmarca, -1, -1);
            else if (pIDlinea == "-1" && pIDmarca == -1 && pIDfabricante != -1 && pIDproveedor == -1)
                totalesdelyear = Reporte.ComprasYear(pYear, "-1", -1, pIDfabricante, -1);
            else if (pIDlinea == "-1" && pIDmarca == -1 && pIDfabricante == -1 && pIDproveedor != -1)
                totalesdelyear = Reporte.ComprasYear(pYear, "-1", -1, -1, pIDproveedor);

            if (totalesdelyear.Count == 0)
                lblSinCompras.Visible = true;
            else
            {
                lblSinCompras.Visible = false;
                ClearChartArea();
                MonthsoftheYear(totalesdelyear);
            }
        }
        private void MonthsoftheYear(List<Tuple<float, DateTime>> TotalesdelYear)
        {
            ChartArea chart = new ChartArea();
            CustomLabel custom;
            int star = 0, end = 2;
            int mesesSaltos = 1;
            foreach (Tuple<float, DateTime> item in TotalesdelYear)
            {
                chart1.Series[0].Points.AddXY(item.Item2.Month, item.Item1);
                while (mesesSaltos != item.Item2.Month)
                {
                    chart1.Series[0].Points.AddXY(mesesSaltos, 0);
                    custom = new CustomLabel(star, end, LlenarMeses(mesesSaltos), 0, LabelMarkStyle.None);
                    chart.AxisX.CustomLabels.Add(custom);
                    star += 1;
                    end += 1;
                    mesesSaltos++;
                }
                custom = new CustomLabel(star, end, item.Item2.ToString("MMMM"), 0, LabelMarkStyle.None);
                chart.AxisX.CustomLabels.Add(custom);
                star += 1;
                end += 1;
                mesesSaltos++;
                totalComprado += item.Item1;
            }
            chart1.Series[0].ToolTip = "Compra \n Mes: #VALX \n #VAL{C}";
            chart.AxisX.Title = "Meses";
            chart.AxisY.Title = "Total";
            chart.AxisY.TitleFont = new Font("Arial", 16, FontStyle.Bold);
            chart.AxisX.TitleFont = new Font("Arial", 16, FontStyle.Bold);
            chart.AxisY.LabelStyle.Format = "{C0}";
            chart.BackColor = Color.Transparent;
            chart1.ChartAreas.Add(chart);
            lblTotalComprado.Text = string.Format("{0:C}", totalComprado);
        }
        private string LlenarMeses(int pMonth)
        {
            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(pMonth);
            return monthName;
        }
        #endregion
        #region Compras por Fecha
        private void FechaLinea(DateTime dateInicial, DateTime dateFinal, string pLinea)
        {
            ListTupleFechasDias(pLinea, -1, -1, -1, dateInicial, dateFinal);
        }

        private void FechaMarca(DateTime dateInicial, DateTime dateFinal, int pMarca)
        {
            ListTupleFechasDias("-1", pMarca, -1, -1, dateInicial, dateFinal);
        }

        private void FechaFabricante(DateTime dateInicial, DateTime dateFinal, int pFabricante)
        {
            ListTupleFechasDias("-1", -1, pFabricante, -1, dateInicial, dateFinal);
        }

        private void FechaProveedor(DateTime dateInicial, DateTime dateFinal, int pProveedor)
        {
            ListTupleFechasDias("-1", -1, -1, pProveedor, dateInicial, dateFinal);
        }
        private void Fecha(DateTime dateInicial, DateTime dateFinal)
        {
            ListTupleFechasDias("-1", -1, -1, -1, dateInicial, dateFinal);
        }
        private void ListTupleFechasDias(string pLinea, int pMarca, int pFabricante, int pProveedor, DateTime dateInicial, DateTime dateFinal)
        {
            List<Tuple<float, DateTime>> tuple = new List<Tuple<float, DateTime>>();
            if (pLinea == "-1" && pMarca == -1 && pFabricante == -1 && pProveedor == -1)
                tuple = Reporte.FechasCompras("-1", -1, -1, -1, dateInicial, dateFinal);

            else if (pLinea != "-1" && pMarca == -1 && pFabricante == -1 && pProveedor == -1)
                tuple = Reporte.FechasCompras(pLinea, -1, -1, -1, dateInicial, dateFinal);

            else if (pLinea == "-1" && pMarca != -1 && pFabricante == -1 && pProveedor == -1)
                tuple = Reporte.FechasCompras("-1", pMarca, -1, -1, dateInicial, dateFinal);

            else if (pLinea == "-1" && pMarca == -1 && pFabricante != -1 && pProveedor == -1)
                tuple = Reporte.FechasCompras("-1", -1, pFabricante, -1, dateInicial, dateFinal);

            else if (pLinea == "-1" && pMarca == -1 && pFabricante == -1 && pProveedor != -1)
                tuple = Reporte.FechasCompras("-1", -1, -1, pProveedor, dateInicial, dateFinal);

            if (tuple.Count == 0)
                lblSinCompras.Visible = true;
            else
            {
                lblSinCompras.Visible = false;
                ClearChartArea();
                FechasDias(tuple);
            }
        }

        private void FechasDias(List<Tuple<float, DateTime>> tuple)
        {
            ChartArea chart = new ChartArea();
            CustomLabel custom;
            int star, end, offset = 0, aux;
            foreach (Tuple<float, DateTime> item in tuple)
            {
                offset = item.Item2.Day;
                break;
            }
            foreach (Tuple<float, DateTime> item in tuple)
            {
                if (offset == item.Item2.Day)
                {
                    star = offset - 1;
                    end = offset + 1;
                }
                else
                {
                    aux = offset;
                    star = aux - 1;
                    end = aux + 1;
                }
                DataPoint dataPoint = new DataPoint();
                dataPoint.SetValueXY(offset, item.Item1);
                dataPoint.ToolTip = $"Venta \n Día: {item.Item2.Day} \n Mes: {LlenarMeses(item.Item2.Month)} \nTotal: {string.Format("{0:C}", item.Item1)}";
                chart1.Series[0].Points.Add(dataPoint);
                custom = new CustomLabel(star, end, item.Item2.Day.ToString(), 0, LabelMarkStyle.None);
                chart.AxisX.CustomLabels.Add(custom);
                offset++;
                totalComprado += item.Item1;
            }
            chart1.Series[0].ToolTip = "";
            chart.AxisX.Title = "Días";
            chart.AxisY.Title = "Total";
            chart.AxisY.TitleFont = new Font("Arial", 16, FontStyle.Bold);
            chart.AxisX.TitleFont = new Font("Arial", 16, FontStyle.Bold);
            chart.AxisY.LabelStyle.Format = "{C0}";
            chart.BackColor = Color.Transparent;
            chart1.ChartAreas.Add(chart);
            lblTotalComprado.Text = string.Format("{0:C}", totalComprado);
        }
        #endregion
        #region Borrar Graficas
        private void Clear()//Contador siempre sera 0 para colocar las nuevas Labels de la nueva grafica junto con total vendido
        {
            chart1.Series[0].Points.Clear();
            totalComprado = 0;
            lblTotalComprado.Text = "$0";
        }
        private void ClearChartArea()
        {
            chart1.ChartAreas.Clear();
        }
        #endregion

        private void rbtnFiltrar_Click(object sender, EventArgs e)
        {
            Clear();
            if (rbtnMes.Checked && rbtnLinea.Checked)
                MonthLinea((int)cboxMesYear.SelectedValue, (int)cboxCYear.SelectedValue, cboxLineaFabriPro.SelectedValue.ToString());

            else if (rbtnMes.Checked && rbtnMarca.Checked)
                MonthMarca((int)cboxMesYear.SelectedValue, (int)cboxCYear.SelectedValue, (int)cboxLineaFabriPro.SelectedValue);

            else if (rbtnMes.Checked && rbtnFabricante.Checked)
                MonthFabricante((int)cboxMesYear.SelectedValue, (int)cboxCYear.SelectedValue, (int)cboxLineaFabriPro.SelectedValue);

            else if (rbtnMes.Checked && rbtnProveedor.Checked)
                MonthProveedor((int)cboxMesYear.SelectedValue, (int)cboxCYear.SelectedValue, (int)cboxLineaFabriPro.SelectedValue);

            else if (rbtnMes.Checked && rbtnNinguno.Checked)
                Month((int)cboxMesYear.SelectedValue, (int)cboxCYear.SelectedValue);

            else if (rbtnYear.Checked && rbtnLinea.Checked)
                YearLinea((int)cboxMesYear.SelectedValue, cboxLineaFabriPro.SelectedValue.ToString());

            else if (rbtnMes.Checked && rbtnMarca.Checked)
                YearMarca((int)cboxMesYear.SelectedValue, (int)cboxLineaFabriPro.SelectedValue);

            else if (rbtnYear.Checked && rbtnFabricante.Checked)
                YearFabricante((int)cboxMesYear.SelectedValue, (int)cboxLineaFabriPro.SelectedValue);

            else if (rbtnYear.Checked && rbtnProveedor.Checked)
                YearProveedor((int)cboxMesYear.SelectedValue, (int)cboxLineaFabriPro.SelectedValue);

            else if (rbtnYear.Checked && rbtnNinguno.Checked)
                Year((int)cboxMesYear.SelectedValue);

            else if (rbtnFecha.Checked && rbtnLinea.Checked)
                FechaLinea(dtFechaInicial.Value.Date, dtFechaFinal.Value.Date, cboxLineaFabriPro.SelectedValue.ToString());

            else if (rbtnFecha.Checked && rbtnMarca.Checked)
                FechaMarca(dtFechaInicial.Value.Date, dtFechaFinal.Value.Date, (int)cboxLineaFabriPro.SelectedValue);

            else if (rbtnFecha.Checked && rbtnFabricante.Checked)
                FechaFabricante(dtFechaInicial.Value.Date, dtFechaFinal.Value.Date, (int)cboxLineaFabriPro.SelectedValue);

            else if (rbtnFecha.Checked && rbtnProveedor.Checked)
                FechaProveedor(dtFechaInicial.Value.Date, dtFechaFinal.Value.Date, (int)cboxLineaFabriPro.SelectedValue);

            else if (rbtnFecha.Checked && rbtnNinguno.Checked)
                Fecha(dtFechaInicial.Value.Date, dtFechaFinal.Value.Date);
           
        }
    }
}
