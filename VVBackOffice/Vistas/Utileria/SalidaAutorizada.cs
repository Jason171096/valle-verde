using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion.Utileria;

namespace ValleVerde.Vistas.Utileria
{
    public partial class SalidaAutorizada : Form
    {
        RegistroChecador obj = new RegistroChecador();
        System.Media.SoundPlayer snd;
        public SalidaAutorizada()
        {
            InitializeComponent();
            this.TransparencyKey = Color.Turquoise;
            this.BackColor = Color.Turquoise;

            FormBorderStyle = FormBorderStyle.None;

            this.Shown += new EventHandler(Checador_Shown);
        }

        private void SalidaAutorizada_Load(object sender, EventArgs e)
        {
            string comentario = "Salida/antes", mensaje;
            Boolean autorizacion = true;

            DateTime hora = obj.HoraServidor();//auxhora es la hora del servidor

            string fecha = hora.Date.ToString("yyyy/MM/dd");


            //Inicio Sesion 
            ValleVerdeComun.Vistas.InicioSesion.InicioSesion obi = new ValleVerdeComun.Vistas.InicioSesion.InicioSesion(false);
            obi.ShowDialog();

            //Huella
            ValleVerdeComun.Programacion.Huellas.ResultadoHuella usuario = obi.usuario;


            if (usuario != null)
            {
                obi.Close();
                                
                DialogResult dialogResult = MensajeBox("Autorización", "    Autoriza la Salida del empleado?");
                if (dialogResult == DialogResult.Yes)
                {
                    snd.Stop();
                    panel1.BackColor = Color.Yellow;
                    autorizacion = true;
                    mensaje = "Salida antes de su horario Autorizada";
                    string valor = "";
                    if (InputBox("Comentario", "Ingrese el comentario:", ref valor) == DialogResult.OK)
                    {
                        comentario = "\nSalida/Antes " + valor;
                    }
                    else
                    {
                        comentario = "\nSalida/Antes";
                    }
                    obj.UpdateCampo("Salida", "'" + hora.TimeOfDay.ToString() + "'", usuario.IDUsuario, fecha);
                    obj.UpdateCampo("Comentario", "CONCAT (Comentario, ' "+comentario+"')", usuario.IDUsuario, fecha);
                    string resultado = obj.Registro(usuario.IDUsuario, comentario, autorizacion);
                    if (resultado != "-1")
                    {
                        Bienvenido.Text = "Feliz día: " + usuario.Nombres;
                        Registro.Text = "Hora: " + hora;
                        labelMensaje.Text = mensaje;
                    }
                    else
                    {
                        Bienvenido.Text = "Usuario no valido ";
                        Registro.Text = " " + hora;
                    }
                    timer1.Enabled = true;
                    timer1.Start();

                }
                else if (dialogResult == DialogResult.No)
                {
                    snd.Stop();
                    panel1.BackColor = Color.Red;
                    autorizacion = false;
                    mensaje = "Salida";
                    comentario = "Salida/Antes sin autorizacion";
                    obj.UpdateCampo("Salida", "'" + hora.TimeOfDay.ToString() + "'", usuario.IDUsuario, fecha);
                    string resultado = obj.Registro(usuario.IDUsuario, comentario, autorizacion);
                    if (resultado != "-1")
                    {
                        Bienvenido.Text = "Feliz día: " + usuario.Nombres;
                        Registro.Text = "Hora: " + hora;
                        labelMensaje.Text = mensaje;
                    }
                    else
                    {
                        Bienvenido.Text = "Usuario no valido ";
                        Registro.Text = " " + hora;
                    }
                    timer1.Enabled = true;
                    timer1.Start();
                }

            }
            else
            {
                obi.Close();
                this.Close();
            }

        }

        private void Checador_Shown(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {           
            this.Close();   
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "Aceptar";
            buttonCancel.Text = "Cancelar";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        public DialogResult MensajeBox(string title, string promptText)
        {
            System.IO.Stream str = Properties.Resources.audio2;
            snd = new System.Media.SoundPlayer(str);
            snd.PlayLooping();

            Form form = new Form();
            Label label = new Label();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            form.BackColor = Color.Red;
            label.Text = promptText;

            buttonOk.Text = "Autorizar";
            buttonCancel.Text = "Cancelar";
            buttonOk.DialogResult = DialogResult.Yes;
            buttonCancel.DialogResult = DialogResult.No;

            label.SetBounds(9, 20, 372, 13);
            buttonOk.SetBounds(90, 52, 126, 36);
            buttonCancel.SetBounds(230, 52, 126, 36);

            label.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            buttonOk.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            buttonCancel.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            label.AutoSize = true;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.None;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;
            form.TransparencyKey = Color.Turquoise;


            DialogResult dialogResult = form.ShowDialog();
            return dialogResult;
        }
    }
}
