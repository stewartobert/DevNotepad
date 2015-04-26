using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevNotepad.PluginFramework.Interfaces
{
    /// <summary>
    /// Provides a public interface for plugins. Offers a number of tie ins to enable access
    /// to the application, main window, active document.
    /// 
    /// Also allows plugins to extend the document events to enhance various aspects such
    /// as formatting, etc
    /// 
    /// Support for adding docked windows.
    /// </summary>
    public interface IPlugin
    {
        void Initialize();

        IPluginHost Host { get; set; }
    }
}
