using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace ValleVerde.Vistas
{
    public partial class GenerarPedido : Form
    {
        Programacion.Compra.Compras objCom = new Programacion.Compra.Compras();
        bool habilitadoSelectionChanged = true;

        public GenerarPedido()
        {
            InitializeComponent();
        }

        private void GenerarPedido_Load(object sender, EventArgs e)
        {
            datGriVieProv.SelectionChanged += new EventHandler(datGriVieProv_SelectionChanged);
            ActualizarProveedoresCotizacionesRecibidas();
            if (datGriVieProv.Rows.Count > 0)
                ActualizarProductosCotizacionRecibida(long.Parse(datGriVieProv.Rows[0].Cells[0].Value.ToString()));
        } 

        private void datGriVieProv_SelectionChanged(object sender, EventArgs e)
        {
            if(habilitadoSelectionChanged)
            {
                ActualizarProductosCotizacionRecibida(long.Parse(datGriVieProv.SelectedRows[0].Cells[0].Value.ToString()));
            }
        }

        private void ActualizarProductosCotizacionRecibida(long idCot)
        {
            datGriVieProd.Rows.Clear();

            List<string[]> productos = objCom.ObtenerProductosCotizacionRecibida(idCot);

            foreach (string[] producto in productos)
            {
                if (bool.Parse(producto[3]))
                {
                    producto[1] = "Caja con " + producto[4] + " " + producto[5].ToLower() + "s de " + producto[1];
                    producto[2] = (decimal.Parse(producto[2]) / decimal.Parse(producto[4])).ToString();
                }

                datGriVieProd.Rows.Add(new string[] { producto[0], producto[1], producto[2] });
            }
        }

        private void butRecCarLisExc_Click(object sender, EventArgs e)
        {
            //Abrir cuadro de dialogo
            string[] rutasArchivos;
            List<long> idLib = new List<long>();

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\ValleVerde\\Cotizaciones";
                openFileDialog.Filter = "Archivos de excel (*.xls)|*.xls";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the paths of specified files
                    rutasArchivos = openFileDialog.FileNames;
                                       
                    int ind = 0;
                    //Importar de Excel
                    Excel.Application xlApp = new Excel.Application();
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    Excel.Range range;

                    string celAct;
                    int conRen;
                    int conCol;
                    int numRen = 0;
                    decimal cos = -1;

                    foreach (string rutaArchivo in rutasArchivos)
                    {
                        //Cargar archivo de excel
                        xlWorkBook = xlApp.Workbooks.Open(rutaArchivo, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                        range = xlWorkSheet.UsedRange;
                        numRen = range.Rows.Count;
                        List<String> ren = new List<String>();

                        //datGriVieProv.Rows.Add(new string[] { (range.Cells[1, 100] as Excel.Range).Value2 + "", (range.Cells[1, 101] as Excel.Range).Value2 + "", objCom.ObtenerNombreProveedor(long.Parse((range.Cells[1, 101] as Excel.Range).Value2 + "")) });

                        for (conRen = 2; conRen <= numRen; conRen++)
                        {
                            for (conCol = 1; conCol <= 6; conCol++)
                            {
                                celAct = (range.Cells[conRen, conCol] as Excel.Range).Value2 + "";
                                ren.Add(celAct);
                            }

                            try
                            {
                                cos = decimal.Parse(ren[4]);
                            }
                            catch (Exception ex) { MessageBox.Show(ex.Message); }

                            //if (ren[5].ToLower().Contains("si"))
                            //    try
                            //    {
                            //        cos = decimal.Parse(ren[4]);
                            //    }
                            //    catch (Exception ex) { MessageBox.Show(ex.Message); }
                            //else
                            //    try
                            //    {
                            //        cos = decimal.Parse((range.Cells[conRen, 5] as Excel.Range).Value2 + "") / decimal.Parse((range.Cells[conRen, 101] as Excel.Range).Value2 + "");
                            //    }
                            //    catch (Exception ex) { MessageBox.Show(ex.Message); }

                            objCom.ActualizarCostoProductoCotizacion(long.Parse((range.Cells[1, 100] as Excel.Range).Value2 + ""), (range.Cells[conRen, 1] as Excel.Range).Value2 + "", (range.Cells[conRen, 2] as Excel.Range).Value2 + "", cos);
                            
                            //datGriVieProd.Rows.Add(new object[] { ren[1], ren[2], ren[3], preUni });

                            ren.Clear();
                        }

                        xlWorkBook.Close(true, null, null);
                        Marshal.ReleaseComObject(xlWorkSheet);
                        Marshal.ReleaseComObject(xlWorkBook);

                        ind++;
                    }
                    xlApp.Quit();

                    Marshal.ReleaseComObject(xlApp);

                    butBusMejPre.Enabled = true;
                    
                    ActualizarProveedoresCotizacionesRecibidas();
                }
            }
        }

        private void ActualizarProveedoresCotizacionesRecibidas()
        {
            habilitadoSelectionChanged = false;

            datGriVieProv.Rows.Clear();

            List<string[]> proveedores = objCom.ObtenerProveedoresCotizacionesRecibidas();

            foreach (string[] proveedor in proveedores)
                datGriVieProv.Rows.Add(new string[] { proveedor[0], proveedor[1], proveedor[2] });

            datGriVieProv.ClearSelection();
            habilitadoSelectionChanged = true;

            if (datGriVieProv.Rows.Count != 0)
                datGriVieProv.Rows[0].Selected = true;
        }

        private void butBusMejPre_Click(object sender, EventArgs e)
        {
            new Compras.ElegirProveedores().Show();
            this.Close();
        }
    }
}
