using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerde.Programacion.Utileria
{
    class CopiaryPegarDocWord
    {
        public void CopiarDocumentosWord(string directoryWord, string nombreWord)
        {
            string directoryCreate = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\TemplatesWord");
            if (Directory.Exists(directoryCreate))
            {
                string directory = directoryCreate + $@"\{nombreWord}";
                File.Copy(directoryWord, directory, true);
            }
            else
            {
                Directory.CreateDirectory(directoryCreate);
                string directory = directoryCreate + $@"\{nombreWord}";
                File.Copy(directoryWord, directory, true);
            }      
        }
    }
}
