using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion.RecursosHumanos;

namespace ValleVerde.Vistas.RecursosHumanos
{
    public partial class ModificarHorario : Form
    {
        Horario obj = new Horario();
        string ID = "";
        public ModificarHorario(string IDHorario)
        {
            InitializeComponent();
            ID = IDHorario;
            string[] res = obj.Busqueda(IDHorario);

            textBoxNom.Text = res[0];
            textBoxHoraEn.Value = DateTime.Parse(res[1]);
            textBoxHoraSa.Value = DateTime.Parse(res[2]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //label3.Text = textBoxNom.Text +" " + textBoxHoraEn.Value.TimeOfDay.ToString() +" "+ textBoxHoraSa.Value.TimeOfDay.ToString() + " " + ID;
            if (textBoxNom.Text != "")
            {
                String res = obj.Modificar(textBoxNom.Text, textBoxHoraEn.Value.TimeOfDay.ToString(), textBoxHoraSa.Value.TimeOfDay.ToString(), ID);
                if (res == "-1")
                {
                    MessageBox.Show("Horario modificado con exito");
                    Horarios ob = new Horarios();
                    ob.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error con la modificacion "+res);
                }
            }
            else
            {
                MessageBox.Show("El campo nombre esta vacio");
            }
        }
    }
}
