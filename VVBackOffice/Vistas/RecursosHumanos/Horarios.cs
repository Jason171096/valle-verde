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
using ValleVerde.Programacion.Reportes;

namespace ValleVerde.Vistas.RecursosHumanos
{
    public partial class Horarios : Form
    {
        VerEmpleado obj = new VerEmpleado();
        Horario ob = new Horario();
        public Horarios()
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dataGridView1, true, false);            
            LlenadoTabla();
            
        }


        private void LlenadoTabla()
        {
            dataGridView1.Rows.Clear();

            List<string[]> res = ob.Horas();
            foreach (string[] fila in res)
            {
                dataGridView1.Rows.Add(fila[3],fila[0],DateTime.Parse(fila[1]).TimeOfDay+"", DateTime.Parse(fila[2]).TimeOfDay + "");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dataGridView1.Rows.Clear();
            String nombre = "", horaEntrada,horaSalida;
            nombre = textBoxNom.Text;
            horaEntrada = textBoxHoraEn.Value.TimeOfDay+"";
            horaSalida = textBoxHoraSa.Value.TimeOfDay+"";
            
            if (nombre != "")
            {
                String res = ob.Insertar(nombre, horaEntrada, horaSalida);
                if (res == "-1")
                {
                    LlenadoTabla();
                    textBoxNom.Text = "";
                }
                else
                {
                    MessageBox.Show("Error en los campos");
                    LlenadoTabla();
                }
            }
            else
            {
                MessageBox.Show("El campo nombre esta vacio"+textBoxHoraEn.Value.TimeOfDay);
            }
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            string IDHorario = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DialogResult dialogResult = MessageBox.Show("Desea Modificar el horario de la tabla", "Modificar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ModificarHorario obm = new ModificarHorario(IDHorario);
                obm.Show();
                this.Close();
            }
            else
            {
                LlenadoTabla();
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            string IDHorario = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DialogResult dialogResult = MessageBox.Show("Desea eliminar el horario de la tabla","Eliminar",MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string res = ob.Eliminar(IDHorario);
                MessageBox.Show("Borrado exitoso "+res);
                LlenadoTabla();
            }
            else
            {
                LlenadoTabla();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HorariosEmpleados obh = new HorariosEmpleados();
            obh.Show();
            this.Close();
        }
    }
}
