using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using ValleVerde.Programacion.Inventario;

namespace ValleVerde.Vistas.Utileria
{
    public partial class ImportarEcxelProductos : Form
    {
        Importar imp = new Importar();
        DataGridView dgvArchivo = new DataGridView();
        public ImportarEcxelProductos()
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvArchivo, true, false);
            dgvArchivo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvArchivo.Dock = DockStyle.None;
            dgvArchivo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            dgvArchivo.Size = new Size(panel1.Width -5, panel1.Height-5);
            dgvArchivo.RowHeadersVisible = false;
            panel1.Controls.Add(dgvArchivo);
            //tabla();
        }

        private void tabla()
        {
            dgvArchivo.ColumnCount = 20;
            //dgvArchivo.Columns[0].Name = "codigo";
            //dgvArchivo.Columns[0].HeaderText = "Codigo";
            dgvArchivo.Columns[0].Visible = true;
            dgvArchivo.Columns[0].Frozen = false;
            dgvArchivo.Columns[0].Width = 160;

            //dgvArchivo.Columns[1].Name = "nombre";
            //dgvArchivo.Columns[1].HeaderText = "Nombre";
            dgvArchivo.Columns[1].Visible = true;
            dgvArchivo.Columns[1].Frozen = false;
            dgvArchivo.Columns[1].Width = 450;

            //dgvArchivo.Columns[2].Name = "costo";
            //dgvArchivo.Columns[2].HeaderText = "Precio Costo";
            dgvArchivo.Columns[2].Visible = true;
            dgvArchivo.Columns[2].Frozen = false;
            dgvArchivo.Columns[2].Width = 120;
            dgvArchivo.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //dgvArchivo.Columns[3].Name = "utilidad";
            //dgvArchivo.Columns[3].HeaderText = "Utilidad";
            dgvArchivo.Columns[3].Visible = true;
            dgvArchivo.Columns[3].Frozen = false;
            dgvArchivo.Columns[3].Width = 80;
            dgvArchivo.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dgvArchivo.Columns[4].Name = "precio";
            //dgvArchivo.Columns[4].HeaderText = "Precio Publico";
            dgvArchivo.Columns[4].Visible = true;
            dgvArchivo.Columns[4].Frozen = false;
            dgvArchivo.Columns[4].Width = 110;
            dgvArchivo.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //dgvArchivo.Columns[5].Name = "cant2";
            //dgvArchivo.Columns[5].HeaderText = "Cant 2";
            dgvArchivo.Columns[5].Visible = true;
            dgvArchivo.Columns[5].Frozen = false;
            dgvArchivo.Columns[5].Width = 95;
            dgvArchivo.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dgvArchivo.Columns[6].Name = "util2";
            //dgvArchivo.Columns[6].HeaderText = "Util 2";
            dgvArchivo.Columns[6].Visible = true;
            dgvArchivo.Columns[6].Frozen = false;
            dgvArchivo.Columns[6].Width = 80;
            dgvArchivo.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dgvArchivo.Columns[7].Name = "precio2";
            //dgvArchivo.Columns[7].HeaderText = "Precio 2";
            dgvArchivo.Columns[7].Visible = true;
            dgvArchivo.Columns[7].Frozen = false;
            dgvArchivo.Columns[7].Width = 110;
            dgvArchivo.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //dgvArchivo.Columns[8].Name = "cant3";
            //dgvArchivo.Columns[8].HeaderText = "Cant 3";
            dgvArchivo.Columns[8].Visible = true;
            dgvArchivo.Columns[8].Frozen = false;
            dgvArchivo.Columns[8].Width = 95;
            dgvArchivo.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dgvArchivo.Columns[9].Name = "util3";
            //dgvArchivo.Columns[9].HeaderText = "Util 3";
            dgvArchivo.Columns[9].Visible = true;
            dgvArchivo.Columns[9].Frozen = false;
            dgvArchivo.Columns[9].Width = 80;
            dgvArchivo.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dgvArchivo.Columns[10].Name = "precio3";
            //dgvArchivo.Columns[10].HeaderText = "Precio 3";
            dgvArchivo.Columns[10].Visible = true;
            dgvArchivo.Columns[10].Frozen = false;
            dgvArchivo.Columns[10].Width = 110;
            dgvArchivo.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //dgvArchivo.Columns[11].Name = "cant4";
            //dgvArchivo.Columns[11].HeaderText = "Cant 4";
            dgvArchivo.Columns[11].Visible = true;
            dgvArchivo.Columns[11].Frozen = false;
            dgvArchivo.Columns[11].Width = 95;
            dgvArchivo.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dgvArchivo.Columns[12].Name = "util4";
            //dgvArchivo.Columns[12].HeaderText = "Util 4";
            dgvArchivo.Columns[12].Visible = true;
            dgvArchivo.Columns[12].Frozen = false;
            dgvArchivo.Columns[12].Width = 80;
            dgvArchivo.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dgvArchivo.Columns[13].Name = "precio4";
            //dgvArchivo.Columns[13].HeaderText = "Precio 4";
            dgvArchivo.Columns[13].Visible = true;
            dgvArchivo.Columns[13].Frozen = false;
            dgvArchivo.Columns[13].Width = 110;
            dgvArchivo.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //dgvArchivo.Columns[14].Name = "cant5";
            //dgvArchivo.Columns[14].HeaderText = "Cant 5";
            dgvArchivo.Columns[14].Visible = true;
            dgvArchivo.Columns[14].Frozen = false;
            dgvArchivo.Columns[14].Width = 95;
            dgvArchivo.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dgvArchivo.Columns[15].Name = "util5";
            //dgvArchivo.Columns[15].HeaderText = "Util 5";
            dgvArchivo.Columns[15].Visible = true;
            dgvArchivo.Columns[15].Frozen = false;
            dgvArchivo.Columns[15].Width = 80;
            dgvArchivo.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dgvArchivo.Columns[16].Name = "precio5";
            //dgvArchivo.Columns[16].HeaderText = "Precio 5";
            dgvArchivo.Columns[16].Visible = true;
            dgvArchivo.Columns[16].Frozen = false;
            dgvArchivo.Columns[16].Width = 110;
            dgvArchivo.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //dgvArchivo.Columns[17].Name = "existencia";
            //dgvArchivo.Columns[17].HeaderText = "Exixtencia";
            dgvArchivo.Columns[17].Visible = true;
            dgvArchivo.Columns[17].Frozen = false;
            dgvArchivo.Columns[17].Width = 120;
            dgvArchivo.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //dgvArchivo.Columns[18].Name = "iva";
            //dgvArchivo.Columns[18].HeaderText = "IVA";
            dgvArchivo.Columns[18].Visible = true;
            dgvArchivo.Columns[18].Frozen = false;
            dgvArchivo.Columns[18].Width = 80;
            dgvArchivo.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dgvArchivo.Columns[19].Name = "ieps";
            //dgvArchivo.Columns[19].HeaderText = "IEPS";
            dgvArchivo.Columns[19].Visible = true;
            dgvArchivo.Columns[19].Frozen = false;
            dgvArchivo.Columns[19].Width = 80;
            dgvArchivo.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvArchivo.Dock = DockStyle.None;
            dgvArchivo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }

        private void ImportarEcxelProductos_Load(object sender, EventArgs e)
        {
            importar();
            LlenarCombo();
        }
        
        private void importar()
        {
            //Abrir cuadro de dialogo
            string[] rutasArchivos;
            List<long> idLib = new List<long>();

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the paths of specified files
                    rutasArchivos = openFileDialog.FileNames;

                    //int ind = 0;

                    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                    Microsoft.Office.Interop.Excel.Range range;

                    string celAct;
                    int conRen;
                    int conCol;
                    int numRen = 0;

                    foreach (string rutaArchivo in rutasArchivos)
                    {
                        //Cargar archivo de excel
                        xlWorkBook = xlApp.Workbooks.Open(rutaArchivo, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                        xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                        range = xlWorkSheet.UsedRange;
                        numRen = range.Rows.Count;
                        //List<String> ren = new List<String>();

                        if (range.Columns.Count == 20)
                        {
                            tabla();
                        }
                        else
                        {
                            dgvArchivo.ColumnCount = 20;
                            for (int i = 0; i < 20; i++)
                            {
                                dgvArchivo.Columns[i].Visible = false;
                                dgvArchivo.Columns[i].Frozen = false;
                            }
                            for (int i = 0; i < range.Columns.Count; i++)
                            {
                                dgvArchivo.Columns[i].Visible = true;
                                dgvArchivo.Columns[i].Frozen = false;
                                dgvArchivo.Columns[i].Width = 160;
                                dgvArchivo.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }

                            dgvArchivo.Dock = DockStyle.None;
                            dgvArchivo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                        }

                        for (int Col = 1; Col <= range.Columns.Count; Col++)
                        {
                            string tituloCabecera = (range.Cells[1, Col] as Microsoft.Office.Interop.Excel.Range).Value2 + "";
                            dgvArchivo.Columns[Col-1].HeaderText = tituloCabecera;
                        }

                        for (conRen = 2; conRen <= numRen; conRen++)
                        {
                            dgvArchivo.Rows.Add();
                            for (conCol = 1; conCol <= range.Columns.Count; conCol++)
                            {
                                celAct = (range.Cells[conRen, conCol] as Microsoft.Office.Interop.Excel.Range).Value2 + "";
                                //ren.Add(celAct);                                
                                dgvArchivo.Rows[conRen - 2].Cells[conCol-1].Value = celAct;
                            }

                            //dgvArchivo.Rows.Add(new object[] { ren[0], ren[1], ren[2], ren[3], ren[4], ren[5], ren[6], ren[7], ren[8], ren[9], ren[10], ren[11], ren[12], ren[13], ren[14], ren[15], ren[16], ren[17], ren[18], ren[19] });

                            //ren.Clear();
                        }

                        xlWorkBook.Close(true, null, null);
                        Marshal.ReleaseComObject(xlWorkSheet);
                        Marshal.ReleaseComObject(xlWorkBook);

                        //ind++;
                    }
                    xlApp.Quit();

                    Marshal.ReleaseComObject(xlApp);
                }
            }
        }
    
        private void LlenarCombo()
        {
            combo1.Items.Add("");
            combo2.Items.Add("");
            combo3.Items.Add("");
            combo4.Items.Add("");
            combo5.Items.Add("");
            combo6.Items.Add("");
            combo7.Items.Add("");
            combo8.Items.Add("");
            combo9.Items.Add("");
            combo10.Items.Add("");
            combo11.Items.Add("");
            combo12.Items.Add("");
            combo13.Items.Add("");
            combo14.Items.Add("");
            combo15.Items.Add("");
            combo16.Items.Add("");
            combo17.Items.Add("");
            combo18.Items.Add("");
            combo19.Items.Add("");
            combo20.Items.Add("");

            combo1.SelectedIndex = 0;
            combo2.SelectedIndex = 0;
            combo3.SelectedIndex = 0;
            combo4.SelectedIndex = 0;
            combo5.SelectedIndex = 0;
            combo6.SelectedIndex = 0;
            combo7.SelectedIndex = 0;
            combo8.SelectedIndex = 0;
            combo9.SelectedIndex = 0;
            combo10.SelectedIndex = 0;
            combo11.SelectedIndex = 0;
            combo12.SelectedIndex = 0;
            combo13.SelectedIndex = 0;
            combo14.SelectedIndex = 0;
            combo15.SelectedIndex = 0;
            combo16.SelectedIndex = 0;
            combo17.SelectedIndex = 0;
            combo18.SelectedIndex = 0;
            combo19.SelectedIndex = 0;
            combo20.SelectedIndex = 0;

            for (int i = 0; i < dgvArchivo.Columns.Count; i++) 
            {
                combo1.Items.Add(dgvArchivo.Columns[i].HeaderText);
                    if (dgvArchivo.Columns[i].HeaderText.Contains(label2.Text) || dgvArchivo.Columns[i].HeaderText == "Codigo")
                        combo1.SelectedIndex = i + 1;                
                combo2.Items.Add(dgvArchivo.Columns[i].HeaderText);
                    if (dgvArchivo.Columns[i].HeaderText.Contains(label3.Text))                
                        combo2.SelectedIndex = i + 1;                
                combo3.Items.Add(dgvArchivo.Columns[i].HeaderText);
                    if (dgvArchivo.Columns[i].HeaderText.Contains(label4.Text))                
                        combo3.SelectedIndex = i + 1;                
                combo4.Items.Add(dgvArchivo.Columns[i].HeaderText);
                    if (dgvArchivo.Columns[i].HeaderText.Contains(label5.Text))
                        combo4.SelectedIndex = i + 1;
                combo5.Items.Add(dgvArchivo.Columns[i].HeaderText);
                    if (dgvArchivo.Columns[i].HeaderText.Contains(label6.Text) || dgvArchivo.Columns[i].HeaderText == "Precio Publico")
                        combo5.SelectedIndex = i + 1;
                combo6.Items.Add(dgvArchivo.Columns[i].HeaderText);
                    if (dgvArchivo.Columns[i].HeaderText.Contains(label7.Text) || dgvArchivo.Columns[i].HeaderText == "Cant 2")
                        combo6.SelectedIndex = i + 1;
                combo7.Items.Add(dgvArchivo.Columns[i].HeaderText);
                    if (dgvArchivo.Columns[i].HeaderText.Contains(label8.Text) || dgvArchivo.Columns[i].HeaderText == "Util 2")
                        combo7.SelectedIndex = i + 1;
                combo8.Items.Add(dgvArchivo.Columns[i].HeaderText);
                    if (dgvArchivo.Columns[i].HeaderText.Contains(label9.Text))
                        combo8.SelectedIndex = i + 1;
                combo9.Items.Add(dgvArchivo.Columns[i].HeaderText);
                    if (dgvArchivo.Columns[i].HeaderText.Contains(label10.Text) || dgvArchivo.Columns[i].HeaderText == "Cant 3")
                        combo9.SelectedIndex = i + 1;
                combo10.Items.Add(dgvArchivo.Columns[i].HeaderText);
                    if (dgvArchivo.Columns[i].HeaderText.Contains(label11.Text) || dgvArchivo.Columns[i].HeaderText == "Util 3")
                        combo10.SelectedIndex = i + 1;
                combo11.Items.Add(dgvArchivo.Columns[i].HeaderText);
                    if (dgvArchivo.Columns[i].HeaderText.Contains(label12.Text))
                        combo11.SelectedIndex = i + 1;
                combo12.Items.Add(dgvArchivo.Columns[i].HeaderText);
                    if (dgvArchivo.Columns[i].HeaderText.Contains(label13.Text) || dgvArchivo.Columns[i].HeaderText == "Cant 4")
                        combo12.SelectedIndex = i + 1;
                combo13.Items.Add(dgvArchivo.Columns[i].HeaderText);
                    if (dgvArchivo.Columns[i].HeaderText.Contains(label14.Text) || dgvArchivo.Columns[i].HeaderText == "Util 4")
                        combo13.SelectedIndex = i + 1;
                combo14.Items.Add(dgvArchivo.Columns[i].HeaderText);
                    if (dgvArchivo.Columns[i].HeaderText.Contains(label15.Text))
                        combo14.SelectedIndex = i + 1;
                combo15.Items.Add(dgvArchivo.Columns[i].HeaderText);
                    if (dgvArchivo.Columns[i].HeaderText.Contains(label16.Text) || dgvArchivo.Columns[i].HeaderText == "Cant 5")
                        combo15.SelectedIndex = i + 1;
                combo16.Items.Add(dgvArchivo.Columns[i].HeaderText);
                    if (dgvArchivo.Columns[i].HeaderText.Contains(label17.Text) || dgvArchivo.Columns[i].HeaderText == "Util 5")
                        combo16.SelectedIndex = i + 1;
                combo17.Items.Add(dgvArchivo.Columns[i].HeaderText);
                    if (dgvArchivo.Columns[i].HeaderText.Contains(label18.Text))
                        combo17.SelectedIndex = i + 1;
                combo18.Items.Add(dgvArchivo.Columns[i].HeaderText);
                    if (dgvArchivo.Columns[i].HeaderText.Contains(label19.Text))
                        combo18.SelectedIndex = i + 1;
                combo19.Items.Add(dgvArchivo.Columns[i].HeaderText);
                    if (dgvArchivo.Columns[i].HeaderText.Contains(label20.Text))
                        combo19.SelectedIndex = i + 1;
                combo20.Items.Add(dgvArchivo.Columns[i].HeaderText);
                    if (dgvArchivo.Columns[i].HeaderText.Contains(label21.Text))
                        combo20.SelectedIndex = i + 1;
            }

            
        }

        private void restriccion(ComboBox combo, System.Windows.Forms.CheckBox chk)
        {
            if (combo.SelectedItem.ToString() == "")
            {
                chk.Enabled = false;
            }
            else
            {
                chk.Enabled = true;
            }
        }

        private void combo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            restriccion(combo2, chkNombre);
        }

        private void combo3_SelectedIndexChanged(object sender, EventArgs e)
        {
            restriccion(combo3, chkCosto);
        }

        private void combo18_SelectedIndexChanged(object sender, EventArgs e)
        {
            restriccion(combo18, chkExistencia);
        }

        private void combo19_SelectedIndexChanged(object sender, EventArgs e)
        {
            restriccion(combo19, chkIVA);
        }

        private void combo20_SelectedIndexChanged(object sender, EventArgs e)
        {
            restriccion(combo20, chkIEPS);
        }

        private void actualizar_Click(object sender, EventArgs e)
        {
            string a = "", b = "", c = "", d = "", f = "", g = "", h = "", ai = "", j = "", k = "", l = "", m = "", n = "", o = "", p = "";
            string idProd = "", nombre = "";
            float costo = -1, utilidad = -1, util2 = -1, util3 = -1, util4 = -1, util5 = -1, existencia = -1;
            int cant2 = -1, cant3 = -1, cant4 = -1, cant5 = -1, iva = -1, ieps = -1;
            int act = 0, inser = 0, err = 0;

            if (combo1.SelectedIndex != 0)
            {
                for (int i = 0; i < dgvArchivo.Rows.Count; i++)
                {
                    a = dgvArchivo.Rows[i].Cells[combo1.SelectedIndex - 1].Value.ToString();
                    if ((combo2.SelectedIndex - 1) > 0)
                        b = dgvArchivo.Rows[i].Cells[combo2.SelectedIndex - 1].Value.ToString();
                    if ((combo3.SelectedIndex - 1) > 0)
                        c = dgvArchivo.Rows[i].Cells[combo3.SelectedIndex - 1].Value.ToString();
                    if ((combo4.SelectedIndex - 1) > 0)
                        d = dgvArchivo.Rows[i].Cells[combo4.SelectedIndex - 1].Value.ToString();
                    if ((combo6.SelectedIndex - 1) > 0)
                        f = dgvArchivo.Rows[i].Cells[combo6.SelectedIndex - 1].Value.ToString();
                    if ((combo7.SelectedIndex - 1) > 0)
                        g = dgvArchivo.Rows[i].Cells[combo7.SelectedIndex - 1].Value.ToString();
                    if ((combo9.SelectedIndex - 1) > 0)
                        h = dgvArchivo.Rows[i].Cells[combo9.SelectedIndex - 1].Value.ToString();
                    if ((combo10.SelectedIndex - 1) > 0)
                        ai = dgvArchivo.Rows[i].Cells[combo10.SelectedIndex - 1].Value.ToString();
                    if ((combo12.SelectedIndex - 1) > 0)
                        j = dgvArchivo.Rows[i].Cells[combo12.SelectedIndex - 1].Value.ToString();
                    if ((combo13.SelectedIndex - 1) > 0)
                        k = dgvArchivo.Rows[i].Cells[combo13.SelectedIndex - 1].Value.ToString();
                    if ((combo15.SelectedIndex - 1) > 0)
                        l = dgvArchivo.Rows[i].Cells[combo15.SelectedIndex - 1].Value.ToString();
                    if ((combo16.SelectedIndex - 1) > 0)
                        m = dgvArchivo.Rows[i].Cells[combo16.SelectedIndex - 1].Value.ToString();
                    if ((combo18.SelectedIndex - 1) > 0)
                        n = dgvArchivo.Rows[i].Cells[combo18.SelectedIndex - 1].Value.ToString();
                    if ((combo19.SelectedIndex - 1) > 0)
                        o = dgvArchivo.Rows[i].Cells[combo19.SelectedIndex - 1].Value.ToString();
                    if ((combo20.SelectedIndex - 1) > 0)
                        p = dgvArchivo.Rows[i].Cells[combo20.SelectedIndex - 1].Value.ToString();

                    if (a != "")
                        idProd = a;

                    if (b != "")
                        nombre = b;

                    if (c != "")
                        costo = float.Parse(c);

                    if (d != "")
                        utilidad = float.Parse(d);

                    if (f != "")
                        cant2 = int.Parse(f);

                    if (g != "")
                        util2 = float.Parse(g);

                    if (h != "")
                        cant3 = int.Parse(h);

                    if (ai != "")
                        util3 = float.Parse(ai);

                    if (j != "")
                        cant4 = int.Parse(j);

                    if (k != "")
                        util4 = float.Parse(k);

                    if (l != "")
                        cant5 = int.Parse(l);

                    if (m != "")
                        util5 = float.Parse(m);

                    if (n != "")
                        existencia = float.Parse(n); ;

                    if (o != "")
                        iva = int.Parse(o);

                    if (p != "")
                        ieps = int.Parse(p);


                    if (!chkIVA.Checked)
                    {
                        iva = -1;
                    }
                    if (!chkIEPS.Checked)
                    {
                        ieps = -1;
                    }



                    string res = imp.ActualizarInformacionProducto(idProd, chkNombre.Checked, nombre, chkCosto.Checked, costo, chkExistencia.Checked, existencia,
                                                      3, 20, chkPrecios.Checked, utilidad, cant2, util2, cant3, util3, cant4, util4, cant5, util5, iva, ieps, chkActualizar.Checked);
                    if (res == "2")
                        act++;

                    if (res == "1")
                        inser++;

                    if (res == "-1")
                        err++;
                }
                MessageBox.Show("Actualizados: "+ act +"\n"+
                                "Insertados nuevos: "+ inser+"\n"+
                                "Error modificados: "+ err);
            }
            else
            {
                MessageBox.Show("El campo código es obligatorio favor de llenarlo","Error");
            }

        }
    }
}
