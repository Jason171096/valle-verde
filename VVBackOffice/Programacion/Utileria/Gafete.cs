using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion.Reportes;
using ValleVerde.Vistas;
using Word = Microsoft.Office.Interop.Word;
using ValleVerdeComun.Programacion;

namespace ValleVerde.Programacion.Utileria
{
    class Gafete
    {
        BuscarEmpleado be = new BuscarEmpleado();
        CopiaryPegarDocWord copiar = new CopiaryPegarDocWord();
       
        public void ImprimirGafete(Usuario datosUsuario, Usuario datosUsuarioFoto)
        {
            try
            {
                foreach (Process proc in Process.GetProcessesByName("WINWORD"))
                {
                    proc.Kill();
                }
                string appPath = Path.GetDirectoryName(Application.StartupPath) + $@"\{datosUsuario.idUsuario}.jpg";
                datosUsuarioFoto.foto.Save(appPath);              
                string WordGafete = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Word\Gafete.docx";
                copiar.CopiarDocumentosWord(WordGafete, "Gafete.docx");
                object directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\TemplatesWord\Gafete.docx");
                Word.Application application = new Word.Application();
                Word.Document document = application.Documents.Open(directory, Missing.Value);
                Word.Range nom = document.Bookmarks.get_Item("Nombre").Range;
                nom.Text = datosUsuario.nombres;
                Word.Range ape = document.Bookmarks.get_Item("Apellidos").Range;
                ape.Text = datosUsuario.apellidos;
                Word.Range pues = document.Bookmarks.get_Item("Puesto").Range;
                pues.Text = datosUsuario.rol;
                object RanPues = pues, RanNombre = nom, RanApellidos = ape;
                document.Bookmarks.Add("Nombre", ref RanNombre);
                document.Bookmarks.Add("Apellidos", ref RanApellidos);
                document.Bookmarks.Add("Puesto", ref RanPues);
                if(datosUsuario.foto == null)
                {
                    object a = "120", b = "150", c = "150", d = "150";
                    var varPhoto = document.Bookmarks["Foto"].Range.InlineShapes.Application.ActiveDocument.Shapes.AddPicture(appPath, false, true, ref a, b, c, d);
                    varPhoto.Width = 150;
                    varPhoto.Height = 180;
                    //varPhoto.PictureFormat.Crop
                }
                application.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Por favor de guardar y cerrar todos los documentos Word", "¡ADVERTENCIA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
}
    }

}
