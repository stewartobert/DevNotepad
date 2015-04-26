using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevNotepad.Library.Tools
{
    /// <summary>
    /// Some simple tools for working with .NET assembly data.
    /// </summary>
    public static class AssemblyTools
    {

        /// <summary>
        /// Returns a formatted string containing the version information of an assembly.
        /// </summary>
        /// <param name="assembly">Required - Assembly to get version of</param>
        /// <param name="format">Optional - Format requires {0}, {1}, {2} but can be formatted 
        /// as desired. Default is {0}.{1}.{2}</param>
        /// <returns>String</returns>
        public static string Version(Assembly assembly, string format = null)
        {
            try
            {
                if (String.IsNullOrEmpty(format))
                {
                    format = "{0}.{1}.{2}";
                    FileVersionInfo fileVersion = FileVersionInfo.GetVersionInfo(assembly.Location);
                    return String.Format(format, fileVersion.FileMajorPart, fileVersion.FileMinorPart, fileVersion.FileBuildPart);
                }
            }
            catch { }
            return String.Empty;
        }


    }
}
