using System;
using System.Collections.Generic;
using ValleVerde.Programacion.Reportes;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;

namespace ValleVerde
{
    public partial class ReportesVentas : Form
    {
        ReporteVentas Reporte = new ReporteVentas();
        private float totalVendido = 0;
        public ReportesVentas()
        {
            InitializeComponent();
            rbtnMes.Checked = true;
            rbtnNinguno.Checked = true;
            dtFechaInicial.MinDate = new DateTime(2018, 12, 01);
            dtFechaInicial.MaxDate = DateTime.Now.Date;
            dtFechaFinal.MinDate = new DateTime(2018, 12, 01);
            dtFechaFinal.MaxDate = DateTime.Now.Date;
        }

        #region LLenarComboxBox
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
            if(star)
                cboxMesYear.DataSource = new BindingSource(yearList, null);
            else
                cboxCYear.DataSource = new BindingSource(yearList, null);
        }

        private void Empleados()
        {
            //Cremamos la lista nombreemleados para obtener los empleados 
            List<String[]> nombreempleados = Reporte.Obtenerempleados();
            List<Object> empleadosObject = new List<Object>();
            foreach (String[] item in nombreempleados)
            {
                //Recorremos la lista de nombreempleados para añadirla en empleadosObject
                empleadosObject.Add(new { Value = int.Parse(item[1]), Text = item[0] });
            }
            //Añadimos empleadosObject al DataSource del comboboxEstacionEmpleado 
            cboxCajaEmpleado.ValueMember = "Value";
            cboxCajaEmpleado.DisplayMember = "Text";
            cboxCajaEmpleado.DataSource = empleadosObject;

        }
        private void Cajas()
        {
            //Creamos lista para obtener las estaciones se las añadimos al DataSource
            List<String> cajas = Reporte.Obtenercajas();
            cboxCajaEmpleado.DataSource = cajas;
        }
        #endregion
        #region CheckedChanged
        private void rbtnMes_CheckedChanged(object sender, EventArgs e)
        {
            cboxMesYear.DataSource = null;
            cboxMesYear.Enabled = true;
            Meses();
            Anos(false);
            dtFechaInicial.Enabled = false;
            dtFechaFinal.Enabled = false;
            cboxCYear.Enabled = true;
        }

        private void rbtnYear_CheckedChanged(object sender, EventArgs e)
        {
            cboxMesYear.DataSource = null;
            cboxMesYear.Enabled = true;
            Anos(true);
            dtFechaInicial.Enabled = false;
            dtFechaFinal.Enabled = false;
            cboxCYear.Enabled = false;
        }

        private void rbtnFecha_CheckedChanged(object sender, EventArgs e)
        {
            cboxMesYear.Enabled = false;
            dtFechaInicial.Enabled = true;
            dtFechaFinal.Enabled = true;
            cboxCYear.Enabled = false;
        }


        private void rbtnEmpleado_CheckedChanged(object sender, EventArgs e)
        {
            cboxCajaEmpleado.DataSource = null;
            Empleados();
            cboxCajaEmpleado.Enabled = true;
        }
        private void rbtnCaja_CheckedChanged(object sender, EventArgs e)
        {
            cboxCajaEmpleado.DataSource = null;
            Cajas();
            cboxCajaEmpleado.Enabled = true;
            
        }

        private void rbtnNinguno_CheckedChanged(object sender, EventArgs e)
        {
            cboxCajaEmpleado.DataSource = null;
            cboxCajaEmpleado.Enabled = false;
            
        }

        #endregion
        #region Ventas por Mes
        //Este metodo saca la grafica de las ventas del mes de los empleados
        private void MouthEmpleados(int pMouth, int pIDEmpleado, int pAnoV)
        {
            ListTupleMonth(pMouth, pIDEmpleado, "-1", pAnoV);
        }
        //Este metodo saca la grafica de las ventas del mes de las cajas
        private void MouthCaja(int pMouth, string pNombreCaja, int pAnoV)
        {
            ListTupleMonth(pMouth, -1, pNombreCaja, pAnoV);
        }
        //Este metodo saca las graficas de las ventas del mes
        private void Mouth(int pMouth, int pAnoV)
        {
            ListTupleMonth(pMouth, -1, "-1", pAnoV);
        }

        private void ListTupleMonth(int pMonth, int pIDEmpleado, string nombrecaja, int pAnoV)
        {
            //Se crea List<Tuple<>>
            List<Tuple<float, DateTime>> totalesdelmes = new List<Tuple<float, DateTime>>();
            //Dependiendo de los parametros recibidos entra al metodo para recoger las Ventas del Mes
            if (pIDEmpleado == -1 && nombrecaja == "-1")
                totalesdelmes = Reporte.VentasMes(pMonth, -1, "-1", pAnoV);
            else if (nombrecaja == "-1")
                totalesdelmes = Reporte.VentasMes(pMonth, pIDEmpleado, "-1", pAnoV);
            else if (pIDEmpleado == -1)
                totalesdelmes = Reporte.VentasMes(pMonth, -1, nombrecaja, pAnoV);

            //Si no se recibe ninguna venta este muestra un lblSinVentas
            if (totalesdelmes.Count == 0)
                lblSinVentas.Visible = true;
            else
            {
                lblSinVentas.Visible = false;
                ClearChartArea();
                DaysoftheMonth(totalesdelmes);
            }
            
        }
        //Metodo que cambiara la grafica en Meses a Dias
        private void DaysoftheMonth(List<Tuple<float, DateTime>> TotalesdelMes)
        {
            ChartArea chart = new ChartArea();
            CustomLabel custom;
            int star = 0, end = 2;
            int diasSaltos = 1; 
            foreach (Tuple<float, DateTime> item in TotalesdelMes)
            {
                chart1.Series[0].Points.AddXY(item.Item2.Day, item.Item1);
                while(diasSaltos != item.Item2.Day)
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
                totalVendido += item.Item1;
            }
            chart1.Series[0].ToolTip = "Venta \n Día: #VALX \nTotal: #VAL{C}";
            chart.AxisX.Title = "Días";
            chart.AxisY.Title = "Total";
            chart.AxisY.TitleFont = new Font("Arial", 16, FontStyle.Bold);
            chart.AxisX.TitleFont = new Font("Arial", 16, FontStyle.Bold);
            chart.AxisY.LabelStyle.Format = "{C0}";
            chart.BackColor = Color.Transparent;
            chart1.ChartAreas.Add(chart);
            lblTotalVendido.Text = string.Format("{0:C}", totalVendido);
        }
        #endregion
        #region Ventas por Año
        private void YearEmpleados(int pYear, int pIDEmpleado)
        {
            ListTupleYear(pYear, pIDEmpleado, "-1");
        }

        private void YearCaja(int pYear, string nombrecajas)
        {
            ListTupleYear(pYear, -1, nombrecajas);
        }

        private void Year(int pYear)
        {
            ListTupleYear(pYear, -1, "-1");
        }

        private void ListTupleYear(int pYear, int pIDEmpleado, string nombrecaja)
        {
            List<Tuple<float, DateTime>> totalesdelyear = new List<Tuple<float, DateTime>>();
            //Dependiendo de los parametros recibidos entra al metodo para recoger las Ventas del Año
            if (pIDEmpleado == -1 && nombrecaja == "-1")
                totalesdelyear = Reporte.VentasYear(pYear, -1, "-1");
            else if (nombrecaja == "-1")
                totalesdelyear = Reporte.VentasYear(pYear, pIDEmpleado, "-1");
            else if (pIDEmpleado == -1)
                totalesdelyear = Reporte.VentasYear(pYear, -1, nombrecaja);

            //Si no se recibe ninguna venta este muestra un lblSinVentas
            if (totalesdelyear.Count == 0)
                lblSinVentas.Visible = true;
            else
            {
                lblSinVentas.Visible = false;
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
                totalVendido += item.Item1;
            }
            chart1.Series[0].ToolTip = "Venta \n Mes: #VALX \n #VAL{C}";
            chart.AxisX.Title = "Meses";
            chart.AxisY.Title = "Total";
            chart.AxisY.TitleFont = new Font("Arial", 16, FontStyle.Bold);
            chart.AxisX.TitleFont = new Font("Arial", 16, FontStyle.Bold);
            chart.AxisY.LabelStyle.Format = "{C0}";
            chart.BackColor = Color.Transparent;
            chart1.ChartAreas.Add(chart);
            lblTotalVendido.Text = string.Format("{0:C}", totalVendido);
        }
        private string LlenarMeses(int pMonth)
        {
            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(pMonth);
            return monthName;
        }

        #endregion
        #region Ventas por Fecha
        private void FechaEmpleado(DateTime dateInicial, DateTime dateFinal, int pIDEmpleado)
        {
            ListTupleFechasDias(pIDEmpleado, "-1", dateInicial, dateFinal);
        }
        private void FechaCaja(DateTime dateInicial, DateTime dateFinal, string nombrecaja)
        {
            ListTupleFechasDias(-1, nombrecaja, dateInicial, dateFinal);
        }
        private void Fecha(DateTime dateInicial, DateTime dateFinal)
        {
            ListTupleFechasDias(-1, "-1", dateInicial, dateFinal);
        }
        private void ListTupleFechasDias(int idempleado, string nombrecaja, DateTime pFechaI, DateTime pFechaF)
        {
            List<Tuple<float, DateTime>> tuple = new List<Tuple<float, DateTime>>();
            if (idempleado == -1 && nombrecaja == "-1")
                tuple = Reporte.FechaVentas(pFechaI, pFechaF, -1, "-1");
            else if (idempleado != -1)
                tuple = Reporte.FechaVentas(pFechaI, pFechaF, idempleado, "-1");
            else if (nombrecaja != "-1")
                tuple = Reporte.FechaVentas(pFechaI, pFechaF, -1, nombrecaja);

            if (tuple.Count == 0)
                lblSinVentas.Visible = true;
            else
            {
                lblSinVentas.Visible = false;
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
                totalVendido += item.Item1;
            }
            chart1.Series[0].ToolTip = "";
            chart.AxisX.Title = "Días";
            chart.AxisY.Title = "Total";
            chart.AxisY.TitleFont = new Font("Arial", 16, FontStyle.Bold);
            chart.AxisX.TitleFont = new Font("Arial", 16, FontStyle.Bold);
            chart.AxisY.LabelStyle.Format = "{C0}";
            chart.BackColor = Color.Transparent;
            chart1.ChartAreas.Add(chart);
            lblTotalVendido.Text = string.Format("{0:C}", totalVendido);
        }
        #endregion
        #region Borrar Grafica
        private void Clear()//Contador siempre sera 0 para colocar las nuevas Labels de la nueva grafica junto con total vendido
        {
            chart1.Series[0].Points.Clear();
            totalVendido = 0;
            lblTotalVendido.Text = "$0";
        }

        private void ClearChartArea()
        {
            chart1.ChartAreas.Clear();
        }
        #endregion
        private void rbtnFiltrar_Click(object sender, EventArgs e)
        {
            Clear();
            if (rbtnMes.Checked && rbtnEmpleado.Checked)
                MouthEmpleados((int)cboxMesYear.SelectedValue, (int)cboxCajaEmpleado.SelectedValue, (int)cboxCYear.SelectedValue);
            else if (rbtnMes.Checked && rbtnCaja.Checked)
                MouthCaja((int)cboxMesYear.SelectedValue, cboxCajaEmpleado.SelectedItem.ToString(), (int)cboxCYear.SelectedValue);
            else if (rbtnMes.Checked && rbtnNinguno.Checked)
                Mouth((int)cboxMesYear.SelectedValue, (int)cboxCYear.SelectedValue);
            else if (rbtnYear.Checked && rbtnEmpleado.Checked)
                YearEmpleados((int)cboxMesYear.SelectedValue, (int)cboxCajaEmpleado.SelectedValue);
            else if (rbtnYear.Checked && rbtnCaja.Checked)
                YearCaja((int)cboxMesYear.SelectedValue, cboxCajaEmpleado.SelectedItem.ToString());
            else if (rbtnYear.Checked && rbtnNinguno.Checked)
                Year((int)cboxMesYear.SelectedValue);
            else if (rbtnFecha.Checked && rbtnEmpleado.Checked)
                FechaEmpleado(dtFechaInicial.Value.Date, dtFechaFinal.Value.Date, (int)cboxCajaEmpleado.SelectedValue);
            else if (rbtnFecha.Checked && rbtnCaja.Checked)
                FechaCaja(dtFechaInicial.Value.Date, dtFechaFinal.Value.Date, cboxCajaEmpleado.SelectedItem.ToString());
            else if (rbtnFecha.Checked)
                Fecha(dtFechaInicial.Value.Date, dtFechaFinal.Value.Date);
        }
    }
}
