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
    public partial class HorariosEmpleados : Form
    {
        VerEmpleado obj = new VerEmpleado();
        private string idusuario = "";
        public HorariosEmpleados()
        {
            List<string[]> res = obj.Usuarios();
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dataGridView1, true, false);
            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";
            foreach (string[] usuario in res)
            {
                comboBox1.Items.Add(new { Text = usuario[0], Value = usuario[1] });
            }
            comboBox1.SelectedIndex = 0;
            checkDescanso.Checked = true;
        }
        public void LlenadoTabla(string IDUsuario)
        {
            dataGridView1.Rows.Clear();

            List<String[]> res = obj.HorasEmpleado(IDUsuario);
            foreach (String[] fila in res)
            {
                dataGridView1.Rows.Add(fila[3], fila[0], DateTime.Parse(fila[1]).TimeOfDay + "", DateTime.Parse(fila[2]).TimeOfDay + "");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            idusuario = (comboBox1.SelectedItem as dynamic).Value + "";
            LlenadoTabla((comboBox1.SelectedItem as dynamic).Value + "");
            if (dataGridView1.CurrentRow == null)
            {
                groupDescanso.Visible = false;
            }
            else
            {
                groupDescanso.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string IDHorario = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DialogResult dialogResult = MessageBox.Show("Desea eliminar el horario de la tabla", "Eliminar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string res = obj.Eliminar(IDHorario, (comboBox1.SelectedItem as dynamic).Value + "");
                //MessageBox.Show("Borrado exitoso " + res);
                LlenadoTabla((comboBox1.SelectedItem as dynamic).Value + "");
            }
            else
            {
                LlenadoTabla((comboBox1.SelectedItem as dynamic).Value + "");
            }
        }

        private void Asignar_Click(object sender, EventArgs e)
        {
            string s = "";
            if (idusuario != "")
                s = idusuario;
            else
                s = (comboBox1.SelectedItem as dynamic).Value + "";
            Hora obh = new Hora(s);
            obh.Show();
            this.Close();
        }

        public void AsignarUsuario(string idusuario)
        {
            this.idusuario = idusuario;
            comboBox1.Visible = false;
            label1.Visible = false;
        }

        public void Recargar(string IDUsuario)
        {
            string nombre = obj.NombreEmpleado(IDUsuario);
            comboBox1.SelectedIndex = comboBox1.FindStringExact(nombre);
        }

        private void Descanso_Click(object sender, EventArgs e)
        {
            string res;
            string IDHorario = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            int tDesc = int.Parse(tiempoDescanso.Value.ToString());
            if (checkDescanso.Checked)
            {
                res = obj.AgregarTiempoDescanso(idusuario,IDHorario,tDesc,true);
            }
            else
            {
                res = obj.AgregarTiempoDescanso(idusuario, IDHorario, tDesc,false);
            }

            if (res == "-1")
            {
                MessageBox.Show("Tiempo de descanso asignado con exito" ,"Exito");
            }
            else
            {
                MessageBox.Show("Ocurrio un error", "Error");
            }
        }

        private void HorariosEmpleados_Load(object sender, EventArgs e)
        {
            if (dataGridView1 == null)
            {
                groupDescanso.Visible = false;
            }
            else
            {
                groupDescanso.Visible = true;
            }
        }
    }
}
