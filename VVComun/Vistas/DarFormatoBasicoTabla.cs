using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerdeComun.Vistas
{
    public class DarFormatoBasicoTabla
    {
        int indexOrden = -1;
        public DarFormatoBasicoTabla()
        {

        }
        public DarFormatoBasicoTabla(DataGridView dvg, bool alternarColorRenglon, bool maximizarTamanoCompleto)
        {
            _DarFormatoBasicoTabla(dvg, alternarColorRenglon, maximizarTamanoCompleto, 15, 15);

        }

        public DarFormatoBasicoTabla(DataGridView dvg, bool alternarColorRenglon, bool maximizarTamanoCompleto, float tamanoFuenteCabecera, float tamanoFuenteCeldas)
        {
            _DarFormatoBasicoTabla(dvg, alternarColorRenglon, maximizarTamanoCompleto, tamanoFuenteCabecera, tamanoFuenteCeldas);

        }

        private void _DarFormatoBasicoTabla(DataGridView dvg, bool alternarColorRenglon, bool maximizarTamanoCompleto, float tamanoFuenteCabecera, float tamanoFuenteCeldas)
        {
            dvg.BackgroundColor = Color.White;
            dvg.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(116, 196, 102);
            dvg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dvg.EnableHeadersVisualStyles = false;
            dvg.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", tamanoFuenteCabecera);
            dvg.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", tamanoFuenteCeldas);

            //Para que las celdas se adapten al texto de un producto
            dvg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dvg.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dvg.MultiSelect = false;
            dvg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (maximizarTamanoCompleto)
                dvg.Dock = DockStyle.Fill;
            dvg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dvg.ReadOnly = true;
            foreach (DataGridViewColumn dgvc in dvg.Columns)
            {
                dgvc.ReadOnly = true;
            }
            dvg.AllowUserToAddRows = false;
            dvg.AllowUserToDeleteRows = false;
            dvg.AllowUserToResizeRows = false;

            //Renglones alternados
            if (alternarColorRenglon)
            {
                //dvg.RowsDefaultCellStyle.BackColor = Color.Bisque;
                dvg.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(205, 242, 199);
            }
        }

        public void EstablecerColumnaOrden(DataGridView dgv,int columna,bool ascendente)
        {
            indexOrden = columna;

            if (indexOrden >= 0)
            {
                dgv.Columns[indexOrden].Visible = false;
                dgv.Columns[indexOrden].SortMode = DataGridViewColumnSortMode.Automatic;

                dgv.SortCompare += new DataGridViewSortCompareEventHandler(dataGridView1_SortCompare);
            }
        }

        private void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if(indexOrden>=0)
                //Suppose your interested column has index 1
                if (e.Column.Index == indexOrden)
                {
                    e.SortResult = int.Parse(e.CellValue1.ToString()).CompareTo(int.Parse(e.CellValue2.ToString()));
                    e.Handled = true;//pass by the default sorting
                }
        }
    }
}
