using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion.Configuracion;

namespace ValleVerde.Vistas.Configuracion
{
    public partial class Dolar : Form
    {
        Programacion.Configuracion.Dolar obj = new Programacion.Configuracion.Dolar();
        ConsultaDolar obcd = new ConsultaDolar();
        public Dolar()
        {
            InitializeComponent();
            ValidarToggle();
        }

        private void Dolar_Load(object sender, EventArgs e)
        {
            decimal dolarTienda = obj.DolarBase();
            dolarBaseTienda.Value = dolarTienda;
            VerDolar();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            string res = obj.ActualizarDolar(dolarBaseTienda.Value.ToString());
            if (res == "-1")
            {
                MessageBox.Show("Se actualizo el precio del dolar","Exito");
            }
            else
            {
                MessageBox.Show("Ocurrio un problema","Error");
            }
        }

        private void toggle1_Click(object sender, EventArgs e)
        {
            ValidarToggle();
        }

        private void ValidarToggle()
        {
            if (toggle1.IsOn)
            {
                dolarBaseTienda.Enabled = true;
                actualizar.Enabled = true;
            }
            else
            {
                dolarBaseTienda.Enabled = false;
                actualizar.Enabled = false;
            }
        }

        private void VerDolar()
        {
            string fechaServidor = obj.FechaHoy();
            string fecha1, fecha2, token;
            fecha1 = DateTime.Parse(fechaServidor).AddDays(-1).ToString("yyyy-MM-dd");
            fecha2 = DateTime.Parse(fechaServidor).ToString("yyyy-MM-dd");
            string fecha = fecha1+"/"+fecha2;
            token = "7cb77589cad9c58c794f4bc8c3b5dfff1c27a178e053c9dd0ace6635cbbcd600";
            
            Response response = obcd.ReadSerie(fecha, token);
            if (response != null)
            {
                Serie serie = response.seriesResponse.series[0];
                if (serie.Data != null)
                {
                    foreach (DataSerie dataSerie in serie.Data)
                    {
                        if (dataSerie.Data.Equals("N/E")) continue;
                        label4.Text = dataSerie.Date;
                        label5.Text = dataSerie.Data;
                    }
                }
            }
            else
            {
                label4.Text = "";
                label5.Text = "Error en la consulta";
            }
        }        
    }
}
