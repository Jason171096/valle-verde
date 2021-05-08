using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerde.Vistas
{
    public partial class ConfigurarPrograma : Form
    {
        ValleVerdeComun.Programacion.ConfiguracionBO settings;
        public ConfigurarPrograma(ValleVerdeComun.Programacion.ConfiguracionBO settings)
        {
            this.settings = settings;
            InitializeComponent();
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
        }

        private void ConfigurarCaja_Load(object sender, EventArgs e)
        {
           

        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = tabControl1.SelectedIndex - 1;
        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            if (ProbarConexion(true))
            {
                tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;
                CargarListaAlmacenes();
                txtNombreCaja.Text = Environment.MachineName;
            }
        }

        private void CargarListaAlmacenes()
        {
            /*Programacion.Almacenes ob = new Programacion.Almacenes(cbServidor.Text);

            List<String[]> res = ob.ObtenerAlmacenes();

            cbAlmacen.DisplayMember = "Text";
            cbAlmacen.ValueMember = "Value";

            List<Object> items = new List<Object>();

            /*foreach (String[] almacen in res)
            {
                items.Add(new { Text = almacen[1], Value = almacen[0] });
            }
            items.Add(new { Text = "Tienda", Value = '3' });
            cbAlmacen.DataSource = items;*/
        }

        private void roundedButton5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = tabControl1.SelectedIndex - 1;
        }

        private void roundedButton4_Click(object sender, EventArgs e)
        {
            this.settings.Servidor = cbServidor.Text;

            //Copiar LumiAPI.dll a ubicacion del programa
            Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string strCurDir = Environment.CurrentDirectory;
            //strCurDir += "\\";

            //File.Copy(Properties.Resources.SDK_L.ToString, @strCurDir+"\\SDK-L.rar");
            File.WriteAllBytes(@strCurDir+"\\SDK-L.rar", Properties.Resources.SDK_L);
            
            UnRar(strCurDir, strCurDir+"\\SDK-L.rar");

            this.Close();
        }

        

        private static void UnRar(string WorkingDirectory, string filepath)
        {

            // Microsoft.Win32 and System.Diagnostics namespaces are imported

            //Dim objRegKey As RegistryKey
            RegistryKey objRegKey;
            objRegKey = Registry.ClassesRoot.OpenSubKey("WinRAR\\Shell\\Open\\Command");
            // Windows 7 Registry entry for WinRAR Open Command

            // Dim obj As Object = objRegKey.GetValue("");
            Object obj = objRegKey.GetValue("");

            //Dim objRarPath As String = obj.ToString()
            string objRarPath = obj.ToString();
            objRarPath = objRarPath.Substring(1, objRarPath.Length - 7);

            objRegKey.Close();

            //Dim objArguments As String
            string objArguments;
            // in the following format
            // " X G:\Downloads\samplefile.rar G:\Downloads\sampleextractfolder\"
            objArguments = " X " + " \"" + filepath + "\" " + " \"" + WorkingDirectory+ "\"";

            // Dim objStartInfo As New ProcessStartInfo()
            ProcessStartInfo objStartInfo = new ProcessStartInfo();

            // Set the UseShellExecute property of StartInfo object to FALSE
            //Otherwise the we can get the following error message
            //The Process object must have the UseShellExecute property set to false in order to use environment variables.
            objStartInfo.UseShellExecute = false;
            objStartInfo.FileName = objRarPath;
            objStartInfo.Arguments = objArguments;
            objStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            objStartInfo.WorkingDirectory = WorkingDirectory + "\\";

            //   Dim objProcess As New Process()
            Process objProcess = new Process();
            objProcess.StartInfo = objStartInfo;
            objProcess.Start();
            objProcess.WaitForExit();


            try
            {
                FileInfo file = new FileInfo(filepath);
                file.Delete();
            }
            catch (FileNotFoundException e)
            {
                throw e;
            }



        }

        private void roundedButton6_Click(object sender, EventArgs e)
        {
            DataTable dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            foreach (System.Data.DataRow row in dt.Rows)
            {
                foreach (System.Data.DataColumn col in dt.Columns)
                {
                    Console.WriteLine("{ 0} = {1}", col.ColumnName, row[col]);
                    cbServidor.Items.Add(col.ColumnName + " " + row[col]);
                }
            }
        }

        private void roundedButton7_Click(object sender, EventArgs e)
        {
            ProbarConexion(false);
        }

        private bool ProbarConexion(bool btnSiguiente)
        {
            string connetionString = "Data Source=" + cbServidor.Text +";Initial Catalog=valleverde;User Id=usuario1;Password=cotija20";
            //connetionString = "Data Source=JORGEGABRIEAFFC;Initial Catalog=valleverde;Trusted_Connection=True;";
            //connetionString = "Data Source=192.168.1.1,1400;Initial Catalog=valleverde;User Id=usuario1;Password=valleverde";
            SqlConnection cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                if(!btnSiguiente)
                MessageBox.Show("Conexion exitosa");
                cnn.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar con el servidor.");
                return false;
            }
        }

        private void roundedButton10_Click(object sender, EventArgs e)
        {
            if(panelError.Visible == false)
             tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;
        }

        private void roundedButton11_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = tabControl1.SelectedIndex - 1;
        }

        private void txtNombreCaja_TextChanged(object sender, EventArgs e)
        {
            if(txtNombreCaja.Text != "")
            {
               /* Programacion.Cajas ob = new Programacion.Cajas();

                if (ob.ExisteCajaConNombre(txtNombreCaja.Text) == true)
                {
                    panelError.Visible = true;
                }
                else
                {
                    panelError.Visible = false;
                }*/
            }
        }

        private void cbServidor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
