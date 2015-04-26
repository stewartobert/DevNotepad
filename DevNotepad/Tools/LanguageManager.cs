using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using DevNotepad.Config;
using DevNotepad.Debug;
using DevNotepad.Models.Languages;
using DevNotepad.Models.Languages;

namespace DevNotepad.Tools
{
    public static class LanguageManager
    {
        /// <summary>
        /// Store the language settings
        /// </summary>
        public static Dictionary<string, Language> Languages = null;

        public static Language ActiveLanguage = null;

        /// <summary>
        /// Initialize the languages within the languages directory.
        /// </summary>
        public static void InitializeLanguages()
        {
            Languages = new Dictionary<string, Language>(StringComparer.InvariantCultureIgnoreCase);
            string[] files = Directory.GetFiles(Paths.LanguagePath, "*.txt");
            foreach(string file in files){
                Language language = new Language();
                if (language.LoadFile(file))
                {
                    string name = Path.GetFileName(file).Replace(".txt", "");
                    Languages.Add(name, language);
                }
            }
            ActiveLanguage = Languages["english"];
        }

        /// <summary>
        /// Process a menu strip
        /// </summary>
        /// <param name="item"></param>
        private static void ProcessMenuStrip(ToolStripMenuItem item)
        {
            for (int i = 0; i < item.DropDownItems.Count; i++)
            {
                
                if (item.DropDownItems[i].Text.StartsWith("{") && item.DropDownItems[i].Text.EndsWith("}"))
                {

                    LanguageItem result = ActiveLanguage.GetItem(item.DropDownItems[i].Text);
                    if (result != null)
                    {
                        item.DropDownItems[i].Text = result.Text;
                        item.DropDownItems[i].ToolTipText = result.Tip;
                        if (!String.IsNullOrEmpty(result.Tip))
                        {
                            item.DropDownItems[i].AutoToolTip = true;
                        }

                    }
                }
                if (item.DropDownItems[i].GetType() == typeof(ToolStripMenuItem))
                    ProcessMenuStrip((ToolStripMenuItem)item.DropDownItems[i]);
            }
        }

        /// <summary>
        /// Initialize control
        /// </summary>
        /// <param name="control"></param>
        public static void InitializeControl(Control control)
        {

            foreach (Control ctrl in control.Controls)
            {

                if (ctrl.GetType() == typeof(MenuStrip))
                {
                    
                    MenuStrip menuStrip = (MenuStrip)ctrl;
                    for (int i = 0; i < menuStrip.Items.Count; i++)
                    {

                        if (menuStrip.Items[i].Text.StartsWith("{") && menuStrip.Items[i].Text.EndsWith("}"))
                        {

                            LanguageItem result = ActiveLanguage.GetItem(menuStrip.Items[i].Text);
                            if (result != null)
                            {
                                menuStrip.Items[i].Text = result.Text;
                                menuStrip.Items[i].ToolTipText = result.Tip;
                            }


                        }
                        if (menuStrip.Items[i].GetType() == typeof(ToolStripMenuItem))
                            ProcessMenuStrip((ToolStripMenuItem)menuStrip.Items[i]);
                    }
                    
                    
                }
                else
                {
                    if (ctrl.Text.StartsWith("{") && ctrl.Text.EndsWith("}"))
                    {

                        LanguageItem result = ActiveLanguage.GetItem(ctrl.Text);
                        if (result != null)
                        {
                            ctrl.Text = result.Text;
                        }


                    }
                }
                // Loop thorugh any children of the control.
                InitializeControl(ctrl);
            }
        }

        public static string GetText(string key, bool trimAmp = false)
        {
            LanguageItem item = ActiveLanguage.GetItem(key);

            if (item != null)
            {
                if (!trimAmp)
                    return item.Text;
                else
                    return item.Text.Replace("&", "");
            }
            return null;
        }



    }
}
