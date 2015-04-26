using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevNotepad.PluginFramework.Interfaces
{
    public interface IDocument
    {

        /// <summary>
        /// Filename
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// Modified status of the document.
        /// </summary>
        bool Modified { get; set; }

        /// <summary>
        /// Unmodified tab text
        /// </summary>
        string BaseTabText { get; set; }
       
    }
}
