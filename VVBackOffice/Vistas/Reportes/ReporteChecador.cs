using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion.Reportes;
using ValleVerde.Vistas.RecursosHumanos;
using ValleVerdeComun.Programacion.Huellas;

namespace ValleVerde.Vistas.Reportes
{
    public partial class ReporteChecador : Form
    {
        VerEmpleado obj = new VerEmpleado();

        string id, fInicio, fFin;

        public ReporteChecador()
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvChecador, true, false);
            dgvChecador.ClearSelection();

            List<string[]> res = obj.Usuarios();

            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";
            foreach (string[] usuario in res)
            {
                comboBox1.Items.Add(new { Text = usuario[0], Value = usuario[1] });
            }
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IDUsuario = (comboBox1.SelectedItem as dynamic).Value + "";
            string fechaInicio = Desde.Value.Date.ToString("yyyy/MM/dd");
            string fechaFin = Hasta.Value.Date.ToString("yyyy/MM/dd");

            llenarTabla(IDUsuario, fechaInicio, fechaFin);
            id = IDUsuario;
            fInicio = fechaInicio;
            fFin = fechaFin;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string IDUsuario = (comboBox1.SelectedItem as dynamic).Value + "";
            string fechaInicio = Desde.Value.Date.ToString("yyyy/MM/dd");
            string fechaFin = Hasta.Value.Date.ToString("yyyy/MM/dd");

            llenarTabla(IDUsuario, fechaInicio, fechaFin);
            id = IDUsuario;
            fInicio = fechaInicio;
            fFin = fechaFin;
        }

        public void llenarTabla(string IDUsuario, string fechaInicio, string fechaFin)
        {
            string entrada, inicioDescanso, finDescanso, salida, autorizacion, comentario, horarioEntrada;
            string auxFila, auxFecha;
            string[] horas;
            float horasTotales=0;
            int i = 0, dt = 0, dr = 0, minutosTarde = 0;

            dgvChecador.Rows.Clear();

            List<string> res = obj.FechaChecador(IDUsuario, fechaInicio, fechaFin);
            foreach (string fila in res)
            {
                auxFecha = DateTime.Parse(fila).ToString("dddd, dd/MM/yyyy", new CultureInfo("es-ES"));
                auxFila = DateTime.Parse(fila).Date.ToString("yyyy/MM/dd");

                List<string[]> tabla = obj.TablaChecador(IDUsuario, auxFila);
                foreach (string[] contenido in tabla)
                {
                    entrada = contenido[0];
                    inicioDescanso = contenido[1];
                    finDescanso = contenido[2];
                    salida = contenido[3];
                    comentario = contenido[4];
                    autorizacion = contenido[5];
                    horarioEntrada = contenido[7];

                    horas = CalcularHoras(IDUsuario, entrada, salida, inicioDescanso, finDescanso, autorizacion, comentario, horarioEntrada,i);
                    horasTotales += SumaHoras(horas[0]);
                    minutosTarde += CalcularMinutosT(entrada,autorizacion,horarioEntrada);

                    dgvChecador.Rows.Add(new object[] {contenido[6], auxFecha, entrada, inicioDescanso, finDescanso, salida, horas[0], comentario });
                    dgvChecador.ClearSelection();

                    if (comentario.Length >= 5)
                    {
                        if (comentario.Substring(0, 5).Equals("Tarde") && autorizacion.Equals("False"))
                        {
                            dgvChecador.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            dt++;
                        }
                        else if (comentario.Substring(0, 5).Equals("Tarde") && autorizacion.Equals("True"))
                        {
                            dgvChecador.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                            dr++;
                        }
                    }

                    if (horas[1]!="-1")
                    {
                        int f = int.Parse(horas[1]);
                        dgvChecador.Rows[f].Cells[4].Style.BackColor = Color.Orange;
                    }
                    i++;
                }
            }
            horasT.Text = "Horas Totales: " + horasTotales.ToString("N2");
            diasT.Text = "Días Tarde: " + dt;
            diasR.Text = "Días Retardo: "+ dr;
            minutosT.Text = "Minutos Tarde: " + minutosTarde; ;
        }

        private string[] CalcularHoras(string IDUsuario, string entrada, string salida, string inicio, string fin,string autorizacion, string comentario, string horarioEntrada, int i)
        {
            string auxTiempoDes = DateTime.Parse(horarioEntrada).TimeOfDay.ToString();
            string descanso = obj.TiempoDescanso(IDUsuario,auxTiempoDes);
            string[] horasTotales = { "00:00:00","-1"}; 
            string horaDescanso,tarde;
            DateTime auxDescanso = new DateTime(2020, 01, 01, 0, 0, 0);

            if (comentario.Length >= 5)
            {
                tarde = comentario.Substring(0, 5);
                if (salida != "00:00:00" && entrada != "00:00:00")
                {
                    if (tarde.Equals("Tarde") && autorizacion.Equals("False"))
                    {
                        horasTotales[0] = "00:00:00";
                        horasTotales[1] = "-1";
                    }
                    else
                    {
                        horaDescanso = (DateTime.Parse(fin).TimeOfDay - DateTime.Parse(inicio).TimeOfDay) + "";
                  
                        if (DateTime.Parse(horaDescanso).TimeOfDay > auxDescanso.AddMinutes(int.Parse(descanso)).TimeOfDay)
                        {
                            horasTotales[0] = ((DateTime.Parse(salida).TimeOfDay - DateTime.Parse(entrada).TimeOfDay) - DateTime.Parse(horaDescanso).TimeOfDay) + "";
                            horasTotales[1] = i+"";                            
                        }
                        else
                        {
                            horasTotales[0] = ((DateTime.Parse(salida).TimeOfDay - DateTime.Parse(entrada).TimeOfDay) - auxDescanso.AddMinutes(int.Parse(descanso)).TimeOfDay) + "";
                            horasTotales[1] = "-1";
                        }
                    }
                }
            }
            return horasTotales;
        }

        private void dgvChecador_DoubleClick(object sender, EventArgs e)
        {
            int fila = dgvChecador.CurrentRow.Index;
            string fecha = DateTime.Parse(dgvChecador.CurrentRow.Cells[1].Value.ToString()).ToString("yyyy-MM-dd");
            ActualizarPago(id, fecha, fila);            
        }

        private void pagar_Click(object sender, EventArgs e)
        {
            int i = dgvChecador.Rows.Count;
            for (int pos = 0; pos < i; pos++) {
                dgvChecador.Rows[pos].SetValues(true);
                string res = obj.Pagar("1",id, DateTime.Parse(dgvChecador.Rows[pos].Cells[1].Value.ToString()).ToString("yyyy-MM-dd"));
                if (res != "-1")
                {
                    MessageBox.Show("Ocurrio un error", "Error");
                }
            }
        }

        private float SumaHoras(string horas)
        {
            int hora=0;
            float res, minuto=0;
            if (horas.Substring(0, 1) != "-")
            {
                hora = int.Parse(horas.Substring(0, 2));

                minuto = int.Parse(horas.Substring(3, 2));
                minuto /= 60;
            }
            res = hora+minuto;
            return res;
        }

        private int CalcularMinutosT(string entrada, string autorizacion, string horarioEntrada)
        {
            int res = 0, hora=0, minutos=0;
            if (autorizacion == "True")
            {
                string tiempo = (DateTime.Parse(entrada).TimeOfDay - DateTime.Parse(horarioEntrada).TimeOfDay).ToString();
                if (tiempo.Substring(0, 1) != "-")
                {
                    hora = int.Parse(tiempo.Substring(0, 2)) * 60;
                    minutos = int.Parse(tiempo.Substring(3, 2));
                }
                res = hora + minutos;
            }
            return res;
        }

        private void registros_Click(object sender, EventArgs e)
        {
            RegistrosChecador rc = new RegistrosChecador(); 
            rc.llenarTabla(id,fInicio,fFin);
            rc.Show();
            this.Visible = false;
        }
        
        private void ActualizarPago(string IDUsuario, string fecha, int fila)
        {
            string res = "-1";
            if (dgvChecador.CurrentRow.Cells[0].Value.ToString().Equals("False") || dgvChecador.CurrentRow.Cells[0].Value.ToString().Equals("false"))
            {
                dgvChecador.Rows[fila].SetValues(true);                
                res = obj.Pagar("1", IDUsuario, fecha);
            }
            else if (dgvChecador.CurrentRow.Cells[0].Value.ToString().Equals("True") || dgvChecador.CurrentRow.Cells[0].Value.ToString().Equals("true"))
            {
                DialogResult result =  MessageBox.Show("Seguro de cambiar el status de pago?","!!Advertencia¡¡",MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) 
                {
                    dgvChecador.Rows[fila].SetValues(false);
                    res = obj.Pagar("0", IDUsuario, fecha);
                }
            }
            
            if (res != "-1")
            {
                MessageBox.Show("Ocurrio un error", "Error");
            }
        }
    }
}
