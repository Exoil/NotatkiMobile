using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NotatnikMobile.Core
{
    public class NoteFile
    {
        

        public string fileName;
        public bool ChecSourceDirectory()
        {

            var test = DirectoryPath();
            bool test2 = Directory.Exists(test);
            if (Directory.Exists(this.DirectoryPath()))
            {
                return true;
            }
            else
            return false;
        }

        public void CreateSourceDirectory()
        {
          
                Directory.CreateDirectory(DirectoryPath());
          
        }

        public List<Notes> LoadFilesToList()
        {
            if(ChecSourceDirectory() == false)
            return null;
            else
            {
                var fileTable = Directory.GetFiles(DirectoryPath());
                var list = new List<Notes>();

                foreach(var text in fileTable)
                {
                    
                    var splited = text.Split('/');
                    var fileName = splited[splited.Length - 1].Split('.');
                    var notatki = new Notes(text, fileName[0]);
                    list.Add(notatki);
                }

                return list;
            }
        }

        public string DirectoryPath()
        {
            
             return  Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "MyNotesProj");
        }

        public bool SavedNotes()
        {
            return false;
        }

        public void SaveNote(string path, string source)
        {
            if (ChecSourceDirectory() == false)
            {
                CreateSourceDirectory();
            }
            else
            {
                File.WriteAllText(path, source);
            }
            
        }


    }
}
