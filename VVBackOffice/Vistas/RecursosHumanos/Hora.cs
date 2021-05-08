using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion.RecursosHumanos;
using ValleVerde.Programacion.Reportes;

namespace ValleVerde.Vistas.RecursosHumanos
{
    public partial class Hora : Form
    {
        Horario ob = new Horario();
        VerEmpleado obj = new VerEmpleado();
        HorariosEmpleados obh = new HorariosEmpleados();
        string IDHorario, idUsuario;

        public Hora(string IDUsuario)
        {
            idUsuario = IDUsuario;
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
                dataGridView1.Rows.Add(fila[3], fila[0], DateTime.Parse(fila[1]).TimeOfDay + "", DateTime.Parse(fila[2]).TimeOfDay + "");
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            obh.Recargar(idUsuario);
            obh.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IDHorario = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            obj.InsertarHoraEmp(IDHorario, idUsuario);
            obh.Recargar(idUsuario);
            obh.Show();
            this.Close();
        }
    }
}
