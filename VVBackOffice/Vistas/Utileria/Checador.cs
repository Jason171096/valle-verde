using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using ValleVerde.Programacion.Utileria;

namespace ValleVerde.Vistas.Utileria
{
    public partial class Checador : Form
    {
        RegistroChecador obj = new RegistroChecador();
        bool autorizacion = true;
        System.Media.SoundPlayer snd;

        public Checador()
        {
            InitializeComponent();

            this.TransparencyKey = Color.Turquoise;
            this.BackColor = Color.Turquoise;

            FormBorderStyle = FormBorderStyle.None;

            this.Shown += new EventHandler(Checador_Shown);  
        }

        private void Checador_Load(object sender, EventArgs e)
        {
            Checar();
        }

        private void Checar()
        {
            string comentario = "", mensaje = "";
            int j = 1, margenEntrada = -15, toleranciaEntrada = 5, margenSalida = -15, tiempoDescanso = 60;

            DateTime hora = obj.HoraServidor();//hora es la hora del servidor
            DateTime entrada, salida;

            string fecha = hora.Date.ToString("yyyy/MM/dd");

            //Inicio Sesion 
            ValleVerdeComun.Vistas.InicioSesion.InicioSesion obi = new ValleVerdeComun.Vistas.InicioSesion.InicioSesion(false);
            obi.ShowDialog();

            //Huella
            ValleVerdeComun.Programacion.Huellas.ResultadoHuella usuario = obi.usuario;

            if (usuario != null)
            {
                obi.Close();
                string registro = obj.ValidacionChecador(usuario.IDUsuario, fecha);

                List<string[]> res = obj.Horario(usuario.IDUsuario);
                //valida que el empleado tenga asignado horarios
                if (res.Count == 0)
                {
                    labelMensaje.Text = "El empleado " + usuario.Nombres;
                    Bienvenido.Text = "no tiene horarios registrados";
                    Registro.Text = hora.ToString();

                    timer1.Enabled = true;
                    timer1.Start();
                }

                foreach (string[] horario in res)
                {
                    entrada = DateTime.Parse(horario[0]);
                    salida = DateTime.Parse(horario[1]);
                    //entrada nueva
                    if (registro == "0")
                    {
                        //A tiempo
                        if (hora.TimeOfDay >= entrada.AddMinutes(margenEntrada).TimeOfDay && (hora.TimeOfDay <= entrada.AddMinutes(toleranciaEntrada).TimeOfDay))
                        {
                            mensaje = "Entrada a Tiempo";
                            InsertarRegistro(usuario.IDUsuario, comentario, autorizacion, usuario.Nombres, mensaje);
                            InsertarTablaChecador(usuario.IDUsuario, fecha, hora.TimeOfDay.ToString(), "", "", "", comentario, autorizacion,(fecha+" "+entrada.TimeOfDay.ToString()));                            
                            break;
                        }
                        //Entrada Tarde
                        else if (hora.TimeOfDay > entrada.AddMinutes(toleranciaEntrada).TimeOfDay && res.Count == j)
                        {
                            //Entrada Tarde pide el comentario de por que llego tarde
                            string valor = "";
                            if (InputBox("Comentario", "Ingrese el motivo del retardo:", ref valor) == DialogResult.OK)
                            {
                                comentario = valor;
                            }
                            else
                            {
                                comentario = "Tarde ";
                            }

                            //Tarde pregunta autorizacion
                            DialogResult dialogResult = MensajeBox("Autorización", "Autoriza la entrada tarde del empleado?");
                            if (dialogResult == DialogResult.Yes)
                            {
                                snd.Stop();
                                panel1.BackColor = Color.Yellow;
                                autorizacion = true;
                                mensaje = "Entrada Tarde Autorizada";
                                comentario = "Tarde/Autorizado "+comentario;                                
                                
                                InsertarRegistro(usuario.IDUsuario, comentario, autorizacion, usuario.Nombres, mensaje);
                                InsertarTablaChecador(usuario.IDUsuario, fecha, hora.TimeOfDay.ToString(), "", "", "", comentario, autorizacion, (fecha + " " + entrada.TimeOfDay.ToString()));                                
                            }

                            else if (dialogResult == DialogResult.No)
                            {
                                snd.Stop();
                                panel1.BackColor = Color.Red;
                                autorizacion = false;
                                mensaje = "Entrada Tarde";
                                comentario = "Tarde sin autorizacion "+comentario;

                                InsertarRegistro(usuario.IDUsuario, comentario, autorizacion, usuario.Nombres, mensaje);
                                InsertarRegistroTarde(usuario.IDUsuario, hora.AddHours(4), "Check automatico", autorizacion);
                                InsertarRegistroTarde(usuario.IDUsuario, hora.AddHours(5), "Check automatico", autorizacion);
                                InsertarRegistroTarde(usuario.IDUsuario, salida, "Check automatico", autorizacion);

                                InsertarTablaChecador(usuario.IDUsuario, fecha, hora.TimeOfDay.ToString(), hora.AddHours(4).TimeOfDay.ToString(), hora.AddHours(5).TimeOfDay.ToString(), salida.TimeOfDay.ToString(), comentario, autorizacion, (fecha + " " + entrada.TimeOfDay.ToString()));
                                //obj.InsertarHorarioChecar(usuario.IDUsuario, fecha, hora.TimeOfDay.ToString(), hora.AddHours(4).TimeOfDay.ToString(), hora.AddHours(5).TimeOfDay.ToString(), salida.TimeOfDay.ToString(), comentario, autorizacion);
                            }
                            break;
                        }
                    }
                    // Ya registro en esa fecha duplicadas, descanso o salida
                    else
                    {
                        //entradas duplicadas A tiempo
                        if (hora.TimeOfDay >= entrada.AddMinutes(margenEntrada).TimeOfDay && hora.TimeOfDay <= entrada.AddMinutes(toleranciaEntrada).TimeOfDay)
                        {                            
                            mensaje = "Entrada a Tiempo";
                            InsertarRegistro(usuario.IDUsuario, comentario, autorizacion, usuario.Nombres, mensaje);
                            //obj.UpdateCampo("Entrada","'"+hora.TimeOfDay.ToString()+"'",usuario.IDUsuario,fecha);
                            break;
                        }
                        //Esta dentro del horario almuerzo
                        else if ((hora.TimeOfDay > entrada.AddMinutes(toleranciaEntrada).TimeOfDay) && (hora.TimeOfDay < salida.AddMinutes(margenSalida).TimeOfDay))
                        {
                            //inicio del descanso
                            string iniciodescanso = obj.BusquedaDesacanso(usuario.IDUsuario, fecha);                            
                            if (iniciodescanso == "00:00:00")
                            {                                
                                mensaje = "Inicio del descanso";
                                InsertarRegistro(usuario.IDUsuario, comentario, autorizacion, usuario.Nombres, mensaje);
                                obj.UpdateCampo("InicioDescanso", "'" + hora.TimeOfDay.ToString() + "'", usuario.IDUsuario, fecha);
                                break;
                            }
                            //fin del descanso
                            else
                            {
                                //Entrada del descanso tarde
                                if (hora.TimeOfDay >= DateTime.Parse(iniciodescanso).AddMinutes(tiempoDescanso).TimeOfDay)
                                {
                                    mensaje = " regitro Tarde";
                                    panel1.BackColor = Color.Red;
                                    obj.UpdateCampo("Comentario", "CONCAT(Comentario, ' Descanso Tarde')", usuario.IDUsuario, fecha);
                                }
                                //Entrada del descanso a tiempo
                                else
                                {
                                    mensaje = "Fin del descanso" + mensaje;
                                    InsertarRegistro(usuario.IDUsuario, comentario, autorizacion, usuario.Nombres, mensaje);
                                    obj.UpdateCampo("FinDescanso", "'" + hora.TimeOfDay.ToString() + "'", usuario.IDUsuario, fecha);
                                }
                                break;
                            }
                        }
                        //Salida
                        else if (hora.TimeOfDay >= salida.AddMinutes(margenSalida).TimeOfDay)//Salida 15 min antes de margen
                        {                            
                            mensaje = "Salida. Buen dia :)";
                            InsertarRegistro(usuario.IDUsuario, comentario, autorizacion, usuario.Nombres, mensaje);
                            obj.UpdateCampo("Salida", "'" + hora.TimeOfDay.ToString() + "'", usuario.IDUsuario, fecha);
                            break;
                        }
                    }
                    j++;
                }
            }
            else
            {
                obi.Close();
                this.Close();
            }
        }

        private void InsertarRegistro(string IDUsuario, string comentario, bool autorizacion, string nombres, string mensaje)
        {
            string fecha = obj.Registro(IDUsuario, comentario, autorizacion);
            if (fecha != "-1")
            {
                Bienvenido.Text = "Bienvenido " + nombres;
                Registro.Text = "Hora: " + fecha;
                labelMensaje.Text = mensaje;
            }
            else
            {
                Bienvenido.Text = "Usuario no valido ";
                Registro.Text = " " + fecha;
            }
            timer1.Enabled = true;
            timer1.Start();
        }

        private void InsertarRegistroTarde(string IDUsuario, DateTime registro, string comentario, bool autorizacion)
        {
            string fecha = obj.RegistroTarde(IDUsuario, registro, comentario, autorizacion);
            if (fecha == "-1")
            {
            }
            else
            {
                MessageBox.Show("Error al insertar");
            }
        }
           
        private void InsertarTablaChecador(string IDUsuario, string fecha, string check, string iDesc, string fDesc, string salida, string comentario, bool autorizacion, string horarioEntrada)
        {
            string res = obj.InsertarHorarioChecar(IDUsuario, fecha, check, iDesc, fDesc, salida, comentario, autorizacion, horarioEntrada);
            if (res == "-1")
            {
            }
            else
            {
                MessageBox.Show("Error al insertar");
            }
        }

        public static DialogResult InputBox(string title, string promptText,ref string value)
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
            buttonOk.SetBounds(60, 52, 126, 36);
            buttonCancel.SetBounds(230, 52, 126, 36);

            label.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            buttonOk.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular,GraphicsUnit.Point, ((byte)(0)));
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

        private void Checador_Shown(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    
    }
}
