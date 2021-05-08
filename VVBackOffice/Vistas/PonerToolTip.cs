using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Vistas.Reportes;

namespace ValleVerde.Vistas
{
    class PonerToolTip
    {
        string mensaje = "";
        ToolTip tt;
        List<EventHandler> eventHList = new List<EventHandler>();
        
        public PonerToolTip(ToolTip tt)
        {
            
            this.tt = tt;
            
        }

        public void SetToolTip(Control control, string mensaje)
        {
            //this.mensaje = mensaje;
            //control.GotFocus -= new EventHandler(ControlTieneFocoToolTip);
            //control.GotFocus += new EventHandler(ControlTieneFocoToolTip);

            EventHandler eventH = (sender2, e2) => ControlTieneFocoToolTip(sender2, e2, mensaje);
            eventHList.Add(eventH);

            //Quitando todos los que pudiera tener
            foreach(EventHandler eH in eventHList)
            {
                control.GotFocus -= eH;
            }

            control.GotFocus += eventH;
        }

        private void ControlTieneFocoToolTip(object sender, EventArgs e,String mensaje)
        {
            Control TB = (Control)sender;
           

            bool esCombo = false;

            try
            {
                ComboBox c = (ComboBox)sender;
                esCombo = true;
            }
            catch { }

            //Si es combo box ponerlo a su derecha
            if (esCombo)
                tt.Show(mensaje, TB, TB.Width, 0);
            else
                tt.Show(mensaje, TB, 0, TB.Height);

            //TB.LostFocus += (sender2, e2) => QuitarToolTip(sender2, e2, TB, tt);
            TB.LostFocus += new EventHandler(QuitarToolTip);
        }

        private void QuitarToolTip(object sender, EventArgs e)
        {
            tt.Hide((Control)sender);
        }
    }
}
