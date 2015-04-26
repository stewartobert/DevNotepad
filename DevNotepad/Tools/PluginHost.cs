using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevNotepad.PluginFramework.Interfaces;

namespace DevNotepad.Tools
{
    public class PluginHost : IPluginHost
    {

        #region Plugin interface methods

        public void AddMenu(MenuItem newMenuItem, string TopMenuItem = null)
        {

        }

        public void Register(IPlugin plugin)
        {
            PluginsManager.Plugins.Add(plugin);
        }


        //public void AddDockWindow(DockPosition position, DockContent dockForm)
        //{
        //    if (DockingManager.WasFormProcessed(dockForm.GetType().ToString()))
        //        return;
        //    switch (position)
        //    {
        //        case DockPosition.Right:
        //            dockForm.Show(DockingPanel, DockState.DockRight);
        //            break;

        //    }
        //}

        public void AddMenuBefore(MenuItem newMenuItem, string FindMenuItem)
        {
        }

        public void AddMenuAfter(MenuItem newMenuItem, string FindMenuItem)
        {

        }

        public event DocumentCreatedEvent DocumentCreated;


        public void OnDocumentCreated(ScintillaNET.Scintilla Editor)
        {
            if (DocumentCreated != null)
            {
                DocumentCreated(Editor);
            }
        }


        #endregion


    }
}
