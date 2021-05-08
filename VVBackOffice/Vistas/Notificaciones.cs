using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerde
{
    public partial class Notificaciones : Form
    {
        public string Texto { get; set; }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        
        public Notificaciones()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            Opacity = .75;
        }

        public enum MyEnum
        {
            wait, star, close
        }

        private Notificaciones.MyEnum Enum;
        private int x, y;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //timer1.Interval = 1;
            //Enum = MyEnum.close;
            Notificaciones_FormClosing(sender, e);
        }

        private void Timer1_Tick(object sender, EventArgs e)//Metodo del timer al iniciar
        {
            switch(Enum)
            {
                case MyEnum.wait:
                    timer1.Interval = 10000;
                    Enum = MyEnum.close;
                    break;
                case MyEnum.star:
                    timer1.Interval = 1;
                    Opacity += 0.1;
                    if (x < Location.X)
                        Left--;
                    else
                        if (Opacity == 1)
                            Enum = MyEnum.wait;
                    break;
                case MyEnum.close:
                    timer1.Interval = 1;
                    Opacity -= 0.1;
                    Left -= 3;
                    if (Opacity == 0)
                        base.Close();
                    break;
            }
        }

        public void ShowAlert()//Metodo para mostrar la notificacion con boton
        {
            StartPosition = FormStartPosition.Manual;
            string fname;
            for (int i = 1; i <= 5; i++)
            {
                fname = "Alerta" + i.ToString();
                Notificaciones notificaciones = (Notificaciones)Application.OpenForms[fname];
                if (notificaciones == null)
                {
                    Name = fname;
                    x = Screen.PrimaryScreen.WorkingArea.Width - Width + 15;
                    y = Screen.PrimaryScreen.WorkingArea.Height - Height * i;
                    Location = new Point(x, y);
                    break;
                }
            }
            x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;
            Show();
            Enum = MyEnum.star;
            timer1.Interval = 1;
            timer1.Start();
        }
        private void Notificaciones_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.Manual;
            for (int i = 1; i <= 5; i++)
            {
                Notificaciones notificaciones = (Notificaciones)Application.OpenForms[Texto];
                if (notificaciones == null)
                {
                    x = Screen.PrimaryScreen.WorkingArea.Width - Width + 15;
                    y = Screen.PrimaryScreen.WorkingArea.Height - Height * i;
                    Location = new Point(x, y);
                    break;
                }
            }
            x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            Timer timer = new Timer();
            timer.Interval = 100000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Close();
        }
        private void TimeOut_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.05;
            if (this.Opacity <= 0.05)
            {
                this.Opacity = 0;
                Application.ExitThread();
            }
        }
        private void Notificaciones_FormClosing(object sender, EventArgs e)
        {
            TimeOut.Enabled = true;  
        }
        #region Evento de Opacidad
        private void Notificaciones_MouseEnter(object sender, EventArgs e)
        {
            Opacity = 1;
        }

        private void Notificaciones_MouseLeave(object sender, EventArgs e)
        {
            Opacity = .75;
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            Opacity = 1;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            Opacity = .75;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            Opacity = 1;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            Opacity = .75;
        }

        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            Opacity = 1;
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            Opacity = .75;
        }
        #endregion
    }
}
