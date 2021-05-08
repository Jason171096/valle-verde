using System;
using System.Drawing;
using System.Windows.Forms;

namespace ValleVerde.Vistas.Compras
{
    public partial class VistaPreviaCompra : Form
    {
        object[] datCom;
        object[,] datFac, prod;
        public string filename;
        public bool usuCon = false, sepPorFac;
        public VistaPreviaCompra(object[] datCom, object[,] datFac, object[,] prod, bool sepPorFac)
        {
            InitializeComponent();
            this.datCom = datCom;
            this.datFac = datFac;
            this.prod = prod;
            this.sepPorFac = sepPorFac;
            //DataGridViewCell celda;
            //foreach (DataGridViewRow renglon in dgv.Rows)
            //{
            //    foreach(DataGridViewCell columna in renglon.Cells)
            //    {
            //        celda = dgv.Rows[renglon.Index].Cells[columna.ColumnIndex];
            //        if(celda.Tag != null || !celda.Tag.ToString().Equals("-1") && !celda.Tag.ToString().Equals(""))
            //            Console.WriteLine("[ " + renglon.Index + ", " + columna.ColumnIndex + "]: " + celda.Value);
            //        else
            //            Console.WriteLine("[ " + renglon.Index + ", " + columna.ColumnIndex + "]: " + celda.Tag);
            //    }
            //    Console.WriteLine("\n");
            //}
            FormClosing += new FormClosingEventHandler(CerrandoVentana);
        }

        private void CerrandoVentana(object sender, FormClosingEventArgs e)
        {
            
        }

        private void VistaPreviaCompra_Load(object sender, EventArgs e)
        {
            PDFCompra pdf = new PDFCompra(sepPorFac, true, datCom, datFac, prod);
            filename = pdf.filename;
            preFlo.Location = new Point((Width / 2) - (preFlo.Width / 2), Height - 100 - 75);

            pdfVie.Location = new Point(1, -1);
            pdfVie.Height = Height;
            pdfVie.Width = Width;
            pdfVie.setZoom(100);
            pdfVie.LoadFile(pdf.filename);
        }

        private void si_Click(object sender, EventArgs e)
        {
            usuCon = true;
            Close();
        }

        private void no_Click(object sender, EventArgs e)
        {
            usuCon = false;
            Close();
        }
    }
}
