using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobFinder
{
    class IOHelper
    {
        public static string[] ReadFrame(string path)
        {
            return System.IO.File.ReadAllLines(path);
        }
    }
}
