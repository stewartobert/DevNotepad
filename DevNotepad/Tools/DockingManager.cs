using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevNotepad.Debug;
using DevNotepad.GUI.Forms;
using DevNotepad.GUI.Forms.Docking;
using WeifenLuo.WinFormsUI.Docking;

namespace DevNotepad.Tools
{
    public static class DockingManager
    {

        // Using a dictionary as apposed to a list because it's faster lookups.
        private static Dictionary<string, IDockContent> DockableForms = new Dictionary<string, IDockContent>();

        /// <summary>
        /// Used to store a list of objects loaded in from the xml. Allows a quick lookup
        /// on plugins to prevent insertion if they were hidden by the user. Alternatively
        /// if not the plugin is docked in by it's own settings.
        /// </summary>
        /// <param name="dockableForm"></param>
        private static void AddDockableForm(string dockableForm, IDockContent dockContent)
        {
            if (dockableForm != null)
            {
                DockableForms.Add(dockableForm, dockContent);
            }
        }

        public static IDockContent GetContentFromPersistString(string persistString)
        {
            try
            {
                if (!persistString.ToLowerInvariant().Contains("formdocument"))
                {
                    
                    Type nObject = PluginsManager.GetTypeFromName(persistString);
                    if (nObject != null)
                    {
                        IDockContent dockForm = (IDockContent)Activator.CreateInstance(nObject);// typeof(persistString));
                        AddDockableForm(persistString, dockForm);
                        if (dockForm != null)
                        {
                            return dockForm;
                        }
                    }
                }
                
                
            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }
            return null;
        }

        public static bool WasFormProcessed(string FormName)
        {
            return (DockableForms.ContainsKey(FormName));
        }

        private static FormFindInFiles _FindInFiles = null;
        public static FormFindInFiles FindInFiles
        {
            get
            {
                if (_FindInFiles == null)
                    if (DockableForms.ContainsKey("DevNotepad.GUI.Forms.Docking.FormFindInFiles"))
                    {
                        _FindInFiles = (FormFindInFiles)DockableForms["DevNotepad.GUI.Forms.Docking.FormFindInFiles"];
                    }

                return _FindInFiles;
            }
            set
            {
                _FindInFiles = value;
            }
        }
    }
}
