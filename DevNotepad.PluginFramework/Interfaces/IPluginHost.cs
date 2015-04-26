using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace DevNotepad.PluginFramework.Interfaces
{
    public enum DockPosition
    {
        Left = 0,
        Top = 1,
        Right = 2,
        Bottom = 3
    }

    public delegate void DocumentCreatedEvent(ScintillaNET.Scintilla Editor);

    public interface IPluginHost
    {

        void Register(IPlugin plugin);

        /// <summary>
        /// Add menu to an existing menu at end.
        /// </summary>
        /// <param name="newMenuItem"></param>
        /// <param name="TopMenuItem"></param>
        void AddMenu(MenuItem newMenuItem, string TopMenuItem = null);

        /// <summary>
        /// Add menu item before existing menu item.
        /// </summary>
        /// <param name="newMenuItem"></param>
        /// <param name="FindMenuItem"></param>
        void AddMenuBefore(MenuItem newMenuItem, string FindMenuItem);

        /// <summary>
        /// Add menu item after existing menu item.
        /// </summary>
        /// <param name="newMenuItem"></param>
        /// <param name="FindMenuItem"></param>
        void AddMenuAfter(MenuItem newMenuItem, string FindMenuItem);

        /// <summary>
        /// Adds a docking window to the main form. Currently not implemented.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="dockForm"></param>
        // void AddDockWindow(DockPosition position, DockContent dockForm);

        event DocumentCreatedEvent DocumentCreated;
    }
}
