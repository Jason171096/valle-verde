using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Vistas.Configuracion;

namespace ValleVerde
{
    public partial class Metas : Form
    {
        Programacion.Configuracion.Metas obj = new Programacion.Configuracion.Metas();

        int numMes;
        int numano;
        string auxMes;
        string hoy;
        
        public Metas()
        {
            InitializeComponent();
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgvMes, true, false);
        }

        private void Metas_Load(object sender, EventArgs e)
        {
            variableComunes();
            Llenado();
            tabMetas.Appearance = TabAppearance.FlatButtons;
            tabMetas.ItemSize = new Size(0, 1);
            tabMetas.SizeMode = TabSizeMode.Fixed;            
            comboMes.SelectedIndex = numMes - 1;
        }

        private void variableComunes()
        {
            numMes = DateTime.Parse(obj.Fecha()).Month; //Numero del mes en el que estamos
            numano = DateTime.Parse(obj.Fecha()).Year; //Año en que estamos
            auxMes = DateTime.Parse(obj.Fecha()).ToString("MMMM"); //Mes con letra en este momento
            hoy = DateTime.Parse(obj.Fecha()).ToString("yyyy/MM/dd");
        }

        #region //buttons de la tab
        private void roundedButton1_Click(object sender, EventArgs e)
        {
            tabMetas.SelectedTab = metasMes;
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            tabMetas.SelectedTab = metasDiarias;
        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {            
            tabMetas.SelectedTab = grafica;
            graficaMes();
            graficaDia();
            graficaAno();
        }
        #endregion

        // Tab 1 Metas del mes
        private void Llenado()
        {
            List<String[]> res = new List<string[]>();
            int dAno = int.Parse(dateAno.Value.ToString("yyyy")); //año del numbox
            res = obj.CargarMetas(dAno);

            if (res.Count != 0)
            {
                foreach (string[] resultado in res)
                {
                    texBoxEne.Text = double.Parse(resultado[2]).ToString("N2");
                    texBoxFeb.Text = double.Parse(resultado[3]).ToString("N2");
                    texBoxMar.Text = double.Parse(resultado[4]).ToString("N2");
                    texBoxAbr.Text = double.Parse(resultado[5]).ToString("N2");
                    texBoxMay.Text = double.Parse(resultado[6]).ToString("N2");
                    texBoxJun.Text = double.Parse(resultado[7]).ToString("N2");
                    texBoxJul.Text = double.Parse(resultado[8]).ToString("N2");
                    texBoxAgo.Text = double.Parse(resultado[9]).ToString("N2");
                    texBoxSep.Text = double.Parse(resultado[10]).ToString("N2");
                    texBoxOct.Text = double.Parse(resultado[11]).ToString("N2");
                    texBoxNov.Text = double.Parse(resultado[12]).ToString("N2");
                    texBoxDic.Text = double.Parse(resultado[13]).ToString("N2");
                }
            }
            else
            {
                texBoxEne.Text = "0";
                texBoxFeb.Text = "0";
                texBoxMar.Text = "0";
                texBoxAbr.Text = "0";
                texBoxMay.Text = "0";
                texBoxJun.Text = "0";
                texBoxJul.Text = "0";
                texBoxAgo.Text = "0";
                texBoxSep.Text = "0";
                texBoxOct.Text = "0";
                texBoxNov.Text = "0";
                texBoxDic.Text = "0";
            }
        }

        private void butGua_Click(object sender, EventArgs e)
        {
            obj.GuardarMetas(Int16.Parse(dateAno.Value.ToString("yyyy")), decimal.Parse(texBoxEne.Text), decimal.Parse(texBoxFeb.Text), decimal.Parse(texBoxMar.Text), decimal.Parse(texBoxAbr.Text), decimal.Parse(texBoxMay.Text), decimal.Parse(texBoxJun.Text), decimal.Parse(texBoxJul.Text), decimal.Parse(texBoxAgo.Text), decimal.Parse(texBoxSep.Text), decimal.Parse(texBoxOct.Text), decimal.Parse(texBoxNov.Text), decimal.Parse(texBoxDic.Text), double.Parse(metAno.Text));
            //this.Close();
        }
        
        private void dateAno_ValueChanged(object sender, EventArgs e)
        {
            Llenado();
            LlenadoTabla();
        }

        #region //metodos textBox hacen la suma al cambiar los valores
        private void texBoxEne_TextChanged(object sender, EventArgs e)
        {
            suma(texBoxEne);
        }

        private void texBoxFeb_TextChanged(object sender, EventArgs e)
        {
            suma(texBoxFeb);
        }

        private void texBoxMar_TextChanged(object sender, EventArgs e)
        {
            suma(texBoxMar);
        }

        private void texBoxAbr_TextChanged(object sender, EventArgs e)
        {
            suma(texBoxAbr);
        }

        private void texBoxMay_TextChanged(object sender, EventArgs e)
        {
            suma(texBoxMay);
        }

        private void texBoxJun_TextChanged(object sender, EventArgs e)
        {
            suma(texBoxJun);
        }        

        private void texBoxJul_TextChanged(object sender, EventArgs e)
        {
            suma(texBoxJul);
        }

        private void texBoxAgo_TextChanged(object sender, EventArgs e)
        {
            suma(texBoxAgo);
        }

        private void texBoxSep_TextChanged(object sender, EventArgs e)
        {
            suma(texBoxSep);
        }

        private void texBoxOct_TextChanged(object sender, EventArgs e)
        {
            suma(texBoxOct);
        }

        private void texBoxNov_TextChanged(object sender, EventArgs e)
        {
            suma(texBoxNov);
        }

        private void texBoxDic_TextChanged(object sender, EventArgs e)
        {
            suma(texBoxDic);
        }
        #endregion

        //verificar suma 
        private void suma(TextBox textBox)
        {            
            double total = 0;
            if (textBox.Text != "")
            {
                double auxEne = double.Parse(texBoxEne.Text);
                double auxFeb = double.Parse(texBoxFeb.Text);
                double auxMar = double.Parse(texBoxMar.Text);
                double auxAbr = double.Parse(texBoxAbr.Text);
                double auxMay = double.Parse(texBoxMay.Text);
                double auxJun = double.Parse(texBoxJun.Text);
                double auxJul = double.Parse(texBoxJul.Text);
                double auxAgo = double.Parse(texBoxAgo.Text);
                double auxSep = double.Parse(texBoxSep.Text);
                double auxOct = double.Parse(texBoxOct.Text);
                double auxNov = double.Parse(texBoxNov.Text);
                double auxDic = double.Parse(texBoxDic.Text);

                total = auxEne + auxFeb + auxMar + auxAbr + auxMay + auxJun + auxJul + auxAgo + auxSep + auxOct + auxNov + auxDic;
            }

            metAno.Text = total.ToString("N2");
        }

        #region //Metodos label_click de los meses para llenar con la informacion correspondiente
        private void enero_Click(object sender, EventArgs e)
        {
            LlenadoTextBox(enero,1);
        }

        private void febrero_Click(object sender, EventArgs e)
        {
            LlenadoTextBox(febrero,2);
        }

        private void marzo_Click(object sender, EventArgs e)
        {
            LlenadoTextBox(marzo,3);
        }

        private void abril_Click(object sender, EventArgs e)
        {
            LlenadoTextBox(abril, 4);
        }

        private void mayo_Click(object sender, EventArgs e)
        {
            LlenadoTextBox(mayo, 5);            
        }

        private void junio_Click(object sender, EventArgs e)
        {
            LlenadoTextBox(junio, 6);
        }

        private void julio_Click(object sender, EventArgs e)
        {
            LlenadoTextBox(julio, 7);
        }

        private void agosto_Click(object sender, EventArgs e)
        {
            LlenadoTextBox(agosto, 8);
        }

        private void septiembre_Click(object sender, EventArgs e)
        {
            LlenadoTextBox(septiembre, 9);
        }

        private void octubre_Click(object sender, EventArgs e)
        {
            LlenadoTextBox(octubre, 10);
        }

        private void noviembre_Click(object sender, EventArgs e)
        {
            LlenadoTextBox(noviembre, 11);
        }

        private void diciembre_Click(object sender, EventArgs e)
        {
            LlenadoTextBox(diciembre, 12);
        }
        #endregion

        private void LlenadoTextBox(Label label, int numeroMes)
        {
            LimpiarLabel();
            label.BackColor = Color.LightGreen;
            float metames = float.Parse(obj.CargarMetasMes(int.Parse(dateAno.Value.ToString("yyyy")), label.Text));
            int diasmes = DateTime.DaysInMonth(int.Parse(dateAno.Value.ToString("yyyy")), numeroMes);

            DateTime fechaIni = new DateTime(int.Parse(dateAno.Value.ToString("yyyy")), numeroMes, 1); 
            DateTime fechaFin = fechaIni.AddMonths(1).AddSeconds(-1);

            double ventaMes = float.Parse(obj.TotalVentas(fechaIni,fechaFin));
            double sobranteMes = ventaMes - metames;
            double faltanteMes = metames - ventaMes;

            textBoxMes.Text = label.Text;
            textBoxMetaMes.Text = metames.ToString();
            textBoxMetaporDia.Text = (metames / diasmes).ToString();
            textBoxActualMes.Text = ventaMes.ToString();

            if (sobranteMes >= 0)
            {
                textBoxSobranteMes.Text = faltanteMes.ToString();
            }
            else
            {
                textBoxSobranteMes.Text = "0";
            }
            if (faltanteMes >= 0)
            {
                textBoxFaltanteMes.Text = faltanteMes.ToString();
            }
            else
            {
                textBoxFaltanteMes.Text = "0";
            }
            graficaxMes(label.Text,numeroMes, int.Parse(dateAno.Value.ToString("yyyy")));
        }

        public void graficaxMes(string strMes, int nMes, int nAno)
        {
            float porcentaje = 0;
            DateTime fechaIni = new DateTime(nAno, nMes, 1); //Fecha inicio, primer dia del mes 
            DateTime fechaFin = fechaIni.AddMonths(1).AddSeconds(-1); //Fecha final, ultimo dia del mes 11:59:59 pm

            string metaMes = obj.CargarMetasMes(nAno, strMes); // Obtiene las metas del mes
            float ventaMes = float.Parse(obj.TotalVentas(fechaIni, fechaFin)); //Obtiene las ventas totales del mes

            if (float.Parse(metaMes) > 0) 
            {
                porcentaje = (ventaMes * 100) / float.Parse(metaMes); //Calcula el porcentaje de las metas
            }
            controlmetas4.usarControl(strMes, porcentaje, "       Felicidades \nFamilia Valle Verde");
        }

        private void LimpiarLabel()
        {
            enero.BackColor = Color.Empty;
            febrero.BackColor = Color.Empty;
            marzo.BackColor = Color.Empty;
            abril.BackColor = Color.Empty;
            mayo.BackColor = Color.Empty;
            junio.BackColor = Color.Empty;
            julio.BackColor = Color.Empty;
            agosto.BackColor = Color.Empty;
            septiembre.BackColor = Color.Empty;
            octubre.BackColor = Color.Empty;
            noviembre.BackColor = Color.Empty;
            diciembre.BackColor = Color.Empty;
        }


        //Tab 2 Metas Diarias

        private List<DateTime> getFechasMes(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month)).Select(day => new DateTime(year, month, day)).ToList();
        }

        private void comboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenadoTabla();
        }

        private void LlenadoTabla()
        {
            dgvMes.Rows.Clear();
            float promedioDia = 0;
            int auxano = int.Parse(dateAno.Value.ToString("yyyy"));
            int auxmes = (comboMes.SelectedIndex + 1);

            string cMetaMes = obj.CargarMetasMes(auxano, comboMes.SelectedItem.ToString());
            List<DateTime> fechasMes = getFechasMes(auxano, auxmes);
            int diasmes = DateTime.DaysInMonth(auxano, auxmes);
            if (cMetaMes != "") 
            {
                promedioDia = float.Parse(cMetaMes) / diasmes;
            }
            System.Collections.IList fila = fechasMes;
            for (int i = 0; i < fila.Count; i++)
            {
                dgvMes.Rows.Add(DateTime.Parse(fila[i].ToString()).ToString("dddd"),DateTime.Parse(fila[i].ToString()).ToString("dd-MM-yyyy"), promedioDia);
            }
        }

        private void dgvMes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DateTime fechaInicio = DateTime.Parse(dgvMes.CurrentRow.Cells[1].Value.ToString());
            DateTime fechaFinal = DateTime.Parse(dgvMes.CurrentRow.Cells[1].Value.ToString()).AddDays(1).AddSeconds(-1);

            string ventaTotal = obj.TotalVentas(fechaInicio,fechaFinal);
            float metaDia = float.Parse(dgvMes.CurrentRow.Cells[2].Value.ToString());
            float sobrante = float.Parse(ventaTotal) - metaDia;
            float faltante = metaDia - float.Parse(ventaTotal);

            textBoxFecha.Text = dgvMes.CurrentRow.Cells[1].Value.ToString();
            textBoxMetaDia.Text = metaDia.ToString();
            textBoxVentaAcual.Text = ventaTotal;

            string dia = fechaInicio.ToString("dddd, dd");

            if (sobrante >=0)
            {
                textBoxSobrante.Text = sobrante.ToString();
            }
            else
            {
                textBoxSobrante.Text = "0";
            }
            if (faltante >=0)
            {
                textBoxFaltante.Text = faltante.ToString();
            }
            else
            {
                textBoxFaltante.Text = "0";
            }
            graficaxdia(ventaTotal,metaDia,dia);
        }

        private void graficaxdia(string venta, float meta, string strDia)
        {
            float porcentaje = 0;
            if (meta > 0) 
            {
                porcentaje = (float.Parse(venta) * 100) / meta;
            }
            controlmetas5.usarControl(strDia, porcentaje, "       Felicidades \nFamilia Valle Verde");
        }

        //Tab 3 Grafica de metas
        #region //graficas tab 3
        public void graficaMes()
        {
            controlmetas2.Mes();
        }

        public void graficaAno()
        {
            controlmetas3.ano();
        }

        public void graficaDia()
        {
            controlmetas1.Dia();
        }
        #endregion
    }
}
