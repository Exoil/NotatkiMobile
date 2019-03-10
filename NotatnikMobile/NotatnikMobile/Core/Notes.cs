using System;
using System.Collections.Generic;
using System.Text;

namespace NotatnikMobile.Core
{
    public class Notes
    {
        public string path, fileName;

        public Notes(string path, string fileName)
        {
            this.path = path;
            this.fileName = fileName;
        }

        public override string ToString()
        {
            return fileName;
        }
    }
}
