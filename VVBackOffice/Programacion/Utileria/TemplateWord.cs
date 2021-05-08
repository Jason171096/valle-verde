using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;


namespace ValleVerde.Programacion.RecursosHumanos
{
    class TemplateWord
    {
        public void DocumentoWord(string nombreWord, string pnombres, string papellidos)
        {
            try
            {
                foreach (Process proc in Process.GetProcessesByName("WINWORD"))
                {
                    proc.Kill();
                }
                object fecha = "Fecha", nombre = "Nombre", apellidos = "Apellidos";
                object objMiss = Missing.Value;
                object directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $@"\TemplatesWord\{nombreWord}");
                Word.Application application = new Word.Application();
                Word.Document document = application.Documents.Open(directory, objMiss);
                Word.Range fec = document.Bookmarks.get_Item(ref fecha).Range;
                fec.Text = DateTime.Now.ToString("dd/MM/yyyy");
                Word.Range nom = document.Bookmarks.get_Item(ref nombre).Range;
                nom.Text = pnombres;
                Word.Range ape = document.Bookmarks.get_Item(ref apellidos).Range;
                ape.Text = papellidos;
                object RanFecha = fec, RanNombre = nom, RanApellidos = ape;
                document.Bookmarks.Add("Fecha", ref RanFecha);
                document.Bookmarks.Add("Nombre", ref RanNombre);
                document.Bookmarks.Add("Apellidos", ref RanApellidos);
                application.Visible = true;
            //Process.Start("WINWORD.EXE", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\ConstanciaTrabajo.docx"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Por favor de guardar y cerrar el documento Word", "¡ADVERTENCIA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
}
    }
}
