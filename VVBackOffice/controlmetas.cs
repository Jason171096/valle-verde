using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerde
{
    class controlmetas : Panel
    {
        Programacion.Configuracion.Metas obj = new Programacion.Configuracion.Metas();
        

        public controlmetas() 
        {
            this.Size = new Size(200, 400);
        }

        public controlmetas(string etiqueta, float valor, string felicitacion)
        {
            Label labelTitulo = new Label();
            Label labelPorcentaje = new Label();
            Label labelFelicitacion = new Label();
            PictureBox trofeo = new PictureBox();
            PictureBox pictureRanita = new PictureBox();
            PictureBox fondo = new PictureBox();
            PictureBox bar = new PictureBox();
            ValleVerde.RoundedPanel roundedPanel1  = new ValleVerde.RoundedPanel();

            roundedPanel1.SuspendLayout();
            this.Size = new Size(200, 400);
            this.Controls.Add(labelFelicitacion);
            this.Controls.Add(trofeo);
            this.Controls.Add(labelTitulo);
            this.Controls.Add(labelPorcentaje);        
            this.Controls.Add(roundedPanel1);
            this.Controls.Add(pictureRanita);

            pictureRanita.Image = global::ValleVerde.Properties.Resources.ranita;
            pictureRanita.Location = new System.Drawing.Point(20, 280);
            pictureRanita.Name = "pictureRanita";
            pictureRanita.Size = new System.Drawing.Size(120, 120);
            pictureRanita.TabIndex = 0;
            pictureRanita.TabStop = false;

            trofeo.Image = global::ValleVerde.Properties.Resources.trofeo_80x80;
            trofeo.Location = new System.Drawing.Point(60, 28);
            trofeo.Name = "pictureRanita";
            trofeo.Size = new System.Drawing.Size(80, 80);
            trofeo.TabIndex = 0;
            trofeo.TabStop = false;

            fondo.Image = global::ValleVerde.Properties.Resources.verticalBar;
            fondo.Location = new System.Drawing.Point(0,0);
            fondo.Name = "pictureRanita";
            fondo.Size = new System.Drawing.Size(48, 261);
            fondo.TabIndex = 0;
            fondo.TabStop = false;

            bar.Image = global::ValleVerde.Properties.Resources.bar_Verde;
            bar.Location = new System.Drawing.Point(0,0);
            bar.Name = "pictureRanita";
            bar.Size = new System.Drawing.Size(48, 261);
            bar.TabIndex = 0;
            bar.TabStop = false;

            roundedPanel1.BorderColor = System.Drawing.Color.Empty;
            roundedPanel1.Controls.Add(fondo);
            roundedPanel1.Controls.Add(bar);
            roundedPanel1.Location = new System.Drawing.Point(120, 139);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Radius = 30;
            roundedPanel1.Size = new System.Drawing.Size(49, 262);
            roundedPanel1.Thickness = 5F;

            labelPorcentaje.AutoSize = true;
            labelPorcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelPorcentaje.ForeColor = System.Drawing.Color.FromArgb(25,160,60);
            labelPorcentaje.Location = new System.Drawing.Point(20, 164);
            labelPorcentaje.Name = "labelPorcentaje";
            labelPorcentaje.Size = new System.Drawing.Size(53, 26);
            labelPorcentaje.TabIndex = 0;
            labelPorcentaje.Text = valor.ToString("N2") + " %";

            labelTitulo.AutoSize = true;
            labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelTitulo.ForeColor = System.Drawing.Color.FromArgb(25, 160, 60);
            labelTitulo.Location = new System.Drawing.Point(50, 110);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new System.Drawing.Size(56, 26);
            labelTitulo.TabIndex = 4;
            labelTitulo.Text = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(etiqueta);

            labelFelicitacion.AutoSize = true;
            labelFelicitacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelFelicitacion.ForeColor = System.Drawing.Color.FromArgb(25, 160, 60);
            labelFelicitacion.Location = new System.Drawing.Point(10, 0);
            labelFelicitacion.Name = "labelFelicitacion";
            labelFelicitacion.Size = new System.Drawing.Size(56, 26);
            labelFelicitacion.TabIndex = 4;
            labelFelicitacion.Text = felicitacion;

            float valor2 = valor;

            // Valida el porcentaje que no sobepase el 100% si lo pasa lo muestra en la etiqueta pero no en la grafica
            if (valor >= 100)
            {
                valor2 = 100;
                labelPorcentaje.Text = valor.ToString("N1") + " %";
                bar.Image = global::ValleVerde.Properties.Resources.bar_Verde;

                labelFelicitacion.Visible = true;
                trofeo.Visible = true;
            }
            else if (valor >= 65 && valor < 100)
            {
                bar.Image = global::ValleVerde.Properties.Resources.bar_Verde;
                labelFelicitacion.Visible = false;
                trofeo.Visible = false;
            }
            else if (valor >= 35 && valor < 65)
            {
                bar.Image = global::ValleVerde.Properties.Resources.bar_Amarillo;
                labelFelicitacion.Visible = false;
                trofeo.Visible = false;
            }
            else
            {
                bar.Image = global::ValleVerde.Properties.Resources.bar_Rojo;
                labelFelicitacion.Visible = false;
                trofeo.Visible = false;
            }

            double aux = valor2 * 2.6;
            int y = int.Parse(aux.ToString("N0"));

            fondo.Location = new System.Drawing.Point(0, -y);
        }

        public void usarControl(string etiqueta, float valor, string felicitacion)
        {
            this.Controls.Clear();
            this.Controls.Add(new controlmetas(etiqueta, valor, felicitacion));
        }
        
        public void Mes()
        {
            int numMes = DateTime.Parse(obj.Fecha()).Month; //Numero del mes en el que estamos
            int numano = DateTime.Parse(obj.Fecha()).Year; //Año en que estamos
            string auxMes = DateTime.Parse(obj.Fecha()).ToString("MMMM", CultureInfo.CreateSpecificCulture("es-ES")); //Mes con letra en este momento            

            DateTime fechaIni = new DateTime(numano, numMes, 1); //Fecha inicio, primer dia del mes 
            DateTime fechaFin = fechaIni.AddMonths(1).AddSeconds(-1); //Fecha final, ultimo dia del mes 11:59:59 pm

            string metaMes = obj.CargarMetasMes(numano, auxMes); // Obtiene las metas del mes
            float ventaMes = float.Parse(obj.TotalVentas(fechaIni, fechaFin)); //Obtiene las ventas totales del mes

            if (metaMes != "0")
            {
                float porcentaje = (ventaMes * 100) / float.Parse(metaMes); //Calcula el porcentaje de las metas
                this.Controls.Clear();
                this.Controls.Add(new controlmetas(auxMes, porcentaje, "       Felicidades \nFamilia Valle Verde"));
            }
        }
        
        public void Dia()
        {
            string hoy = DateTime.Parse(obj.Fecha()).ToString("yyyy/MM/dd");
            string auxMes = DateTime.Parse(obj.Fecha()).ToString("MMMM", CultureInfo.CreateSpecificCulture("es-ES")); //Mes con letra en este momento 
            int numMes = DateTime.Parse(obj.Fecha()).Month; //Numero del mes en el que estamos
            int numano = DateTime.Parse(obj.Fecha()).Year; //Año en que estamos             

            DateTime fechaIni = DateTime.Parse(hoy);
            DateTime fechaFin = DateTime.Parse(hoy).AddDays(1).AddSeconds(-1);
            string etiqueta = fechaIni.ToString("dddd, dd", CultureInfo.CreateSpecificCulture("es-ES"));

            string metaMes = obj.CargarMetasMes(numano, auxMes); // Obtiene las metas del mes
            int diasmes = DateTime.DaysInMonth(numano, numMes);
            float metaDia = float.Parse(metaMes)/diasmes;
            float ventaDia = float.Parse(obj.TotalVentas(fechaIni, fechaFin)); //Obtiene las ventas totales del mes

            if (metaDia > 0)
            {
                float porcentaje = (ventaDia * 100) / metaDia; //Calcula el porcentaje de las metas
                this.Controls.Clear();
                this.Controls.Add(new controlmetas(etiqueta, porcentaje, "       Felicidades \nFamilia Valle Verde"));
            }
        }

        public void ano()
        {
            int numano = DateTime.Parse(obj.Fecha()).Year; //Año en que estamos

            DateTime fechaIni = new DateTime(numano, 1, 1);
            DateTime fechaFin = fechaIni.AddYears(1).AddSeconds(-1);

            string metAno = obj.CargarMetasMes(numano, "TotalAno"); // Obtiene las metas del año
            float ventAno = float.Parse(obj.TotalVentas(fechaIni, fechaFin));

            float porcentaje = (ventAno*100)/float.Parse(metAno);
            this.Controls.Clear();
            this.Controls.Add(new controlmetas(numano.ToString(), porcentaje, "       Felicidades \nFamilia Valle Verde"));
        }
    }   
}
