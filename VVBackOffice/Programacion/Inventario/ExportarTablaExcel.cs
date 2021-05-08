using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Reporting.Map.WebForms.BingMaps;

namespace ValleVerde.Programacion.Inventario
{
    class ExportarTablaExcel
    {


        public void GenerarExcel(DataGridView tabla, int columnaCodigo, int columnaAlterna)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            excel.Application.Workbooks.Add(true);

            int IndiceColumna = 0;

            foreach (DataGridViewColumn col in tabla.Columns) //columnas
            {
                IndiceColumna++;

                excel.Cells[1, IndiceColumna] = col.HeaderText;
            }

            int IndiceFila = 0;

            foreach (DataGridViewRow row in tabla.Rows) //filas
            {
                IndiceFila++;

                IndiceColumna = 0;
                if (columnaCodigo != -1) {
                    excel.Cells[IndiceFila + 1, columnaCodigo].NumberFormat = "0";
                }
                if (columnaAlterna != -1)
                {
                    excel.Cells[IndiceFila + 1, columnaAlterna].NumberFormat = "0";
                }
                foreach (DataGridViewColumn col in tabla.Columns) //columnas
                {
                    IndiceColumna++;
                    ///excel.Columns[IndiceColumna].AutoFit();
                    excel.Cells[IndiceFila + 1, IndiceColumna] = row.Cells[col.Name].Value;
                }

               
            }

            IndiceColumna = 0;
            foreach (DataGridViewColumn col in tabla.Columns) //columnas
            {
                IndiceColumna++;
                excel.Columns[IndiceColumna].AutoFit();
            }

            excel.Visible = true;

        }

        public void ExportarDataGridViewExcel(DataGridView grd)
        {
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.FileName = "ArchivoEntradaSalida_"+DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;

                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libros_trabajo = aplicacion.Workbooks.Add();
                    hoja_trabajo =
                        (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);

                    //Recorremos el DataGridView rellenando la hoja de trabajo
                    

                    for (int i = 0; i < grd.Rows.Count; i++)
                    {
                        for (int j = 0; j < grd.Columns.Count; j++)
                        {
                            if ((grd.Rows[i].Cells[j].Value == null) == false)
                            {
                                hoja_trabajo.Cells[i, j + 1] = grd.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }
                    libros_trabajo.SaveAs(fichero.FileName,
                        Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libros_trabajo.Close(true);
                    aplicacion.Quit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar la informacion debido a: " + ex.ToString());
            }

        }
    }
}
