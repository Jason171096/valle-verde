using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerde
{
    public partial class Tickets : Form
    {
        Programacion.Configuracion.Tickets obj = new Programacion.Configuracion.Tickets();
        List<String[]> pro;
        Int64 idTicSel;

        public Tickets()
        {
            InitializeComponent();
            comBoxDigBas.Items.Add(1);
            comBoxDigBas.Items.Add(2);
            comBoxDigBas.Items.Add(3);
        }

        private void butCre_Click(object sender, EventArgs e)
        {
            obj.crearTicket(texBoxNom.Text, texBoxMenCab.Text, texBoxMen1PiePag.Text, texBoxMen2PiePag.Text, texBoxMen3PiePag.Text, cheBoxLogo.Checked, cheBoxAho.Checked, cheBoxCli.Checked, cheBoxSuc.Checked, cheBoxCorEle.Checked, cheBoxDir.Checked, Int16.Parse(comBoxDigBas.SelectedItem.ToString()), cheBoxMenCab.Checked, cheBoxMen1PiePag.Checked, cheBoxMen2PiePag.Checked, cheBoxMen3PiePag.Checked, cheBoxTel.Checked, cheBoxRfc.Checked, cheBoxCaj.Checked, cheBoxEmp.Checked);
 
            ActualizarTabla();
            butLim_Click(sender, e);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tickets_Load(object sender, EventArgs e)
        {
            ActualizarTabla();
            datGriVieTic.ClearSelection();
        }

        private void ActualizarTabla()
        {
            pro = obj.ObtenerTickets();

            datGriVieTic.Rows.Clear();
            foreach(String[] proveedor in pro)
            {
                datGriVieTic.Rows.Add(proveedor[0], proveedor[1]);
            }

            datGriVieTic.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            datGriVieTic.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void datGriVieTic_SelectionChanged(object sender, EventArgs e)
        {
            // Update the labels to reflect changes to the selection.
            if(datGriVieTic.Focused)
            {
                butCre.Enabled = false;
                butAplCam.Enabled = true;
                butEliTicSel.Enabled = true;
                ActualizarControles(datGriVieTic.SelectedRows[0]);
            }
        }

        private void ActualizarControles(DataGridViewRow dataGridViewRow)
        {
            String [] conCon = pro[dataGridViewRow.Index];

            idTicSel = Int64.Parse(conCon[0]);
            texBoxNom.Text = conCon[1];
            texBoxMenCab.Text = conCon[2];
            texBoxMen1PiePag.Text = conCon[3];
            texBoxMen2PiePag.Text = conCon[4];
            texBoxMen3PiePag.Text = conCon[5];
            cheBoxLogo.Checked = Boolean.Parse(conCon[6]);
            cheBoxAho.Checked = Boolean.Parse(conCon[7]);
            cheBoxCli.Checked = Boolean.Parse(conCon[8]);
            cheBoxSuc.Checked = Boolean.Parse(conCon[9]);
            cheBoxCorEle.Checked = Boolean.Parse(conCon[10]);
            cheBoxDir.Checked = Boolean.Parse(conCon[11]);
            comBoxDigBas.SelectedItem = int.Parse(conCon[12]);
            cheBoxMenCab.Checked = Boolean.Parse(conCon[13]);
            cheBoxMen1PiePag.Checked = Boolean.Parse(conCon[14]);
            cheBoxMen2PiePag.Checked = Boolean.Parse(conCon[15]);
            cheBoxMen3PiePag.Checked = Boolean.Parse(conCon[16]);
            cheBoxTel.Checked = Boolean.Parse(conCon[17]);
            cheBoxRfc.Checked = Boolean.Parse(conCon[18]);
            cheBoxCaj.Checked = Boolean.Parse(conCon[19]);
            cheBoxEmp.Checked = Boolean.Parse(conCon[20]);
            //throw new NotImplementedException();
        }

        private void butLim_Click(object sender, EventArgs e)
        {
            texBoxNom.Text = "";
            texBoxMenCab.Text = "";
            texBoxMen1PiePag.Text = "";
            texBoxMen2PiePag.Text = "";
            texBoxMen3PiePag.Text = "";
            cheBoxLogo.Checked = false;
            cheBoxAho.Checked = false;
            cheBoxCli.Checked = false;
            cheBoxSuc.Checked = false;
            cheBoxCorEle.Checked = false;
            cheBoxDir.Checked = false;
            comBoxDigBas.SelectedItem = null;
            cheBoxMenCab.Checked = false;
            cheBoxMen1PiePag.Checked = false;
            cheBoxMen2PiePag.Checked = false;
            cheBoxMen3PiePag.Checked = false;
            cheBoxTel.Checked = false;
            cheBoxRfc.Checked = false;
            cheBoxCaj.Checked = false;
            cheBoxEmp.Checked = false;

            datGriVieTic.ClearSelection();
            butCre.Enabled = true;
            butAplCam.Enabled = false;
            butEliTicSel.Enabled = false;
        }

        private void butAplCam_Click(object sender, EventArgs e)
        {
            obj.ModificarTicket(idTicSel,
                                texBoxNom.Text,
                                texBoxMenCab.Text,
                                texBoxMen1PiePag.Text,
                                texBoxMen2PiePag.Text,
                                texBoxMen3PiePag.Text,
                                cheBoxLogo.Checked,
                                cheBoxAho.Checked,
                                cheBoxCli.Checked,
                                cheBoxSuc.Checked,
                                cheBoxCorEle.Checked,
                                cheBoxDir.Checked,
                                Int16.Parse(comBoxDigBas.SelectedItem.ToString()),
                                cheBoxMenCab.Checked,
                                cheBoxMen1PiePag.Checked,
                                cheBoxMen2PiePag.Checked,
                                cheBoxMen3PiePag.Checked,
                                cheBoxTel.Checked,
                                cheBoxRfc.Checked,
                                cheBoxCaj.Checked,
                                cheBoxEmp.Checked);
            ActualizarTabla();
            butLim_Click(sender, e);
        }

        private void butEliTicSel_Click(object sender, EventArgs e)
        {
            obj.EliminarTicket(idTicSel);
            ActualizarTabla();
            butLim_Click(sender, e);
        }
    }
}
