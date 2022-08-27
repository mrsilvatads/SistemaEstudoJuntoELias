using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEstudo.UTIL
{
    public static class ClsPathExe
    {
        public static string path = Path.GetDirectoryName(Application.ExecutablePath);
    }
}
