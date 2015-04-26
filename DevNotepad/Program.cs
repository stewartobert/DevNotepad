using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevNotepad.Config;
using DevNotepad.Debug;
using DevNotepad.GUI.Forms;
using DevNotepad.Models.Syntax;
using DevNotepad.Config;
using DevNotepad.Models.Themes;
using DevNotepad.Tools;

namespace DevNotepad
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] Args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Initialize();
            //UpdateStyles();
            
            Application.Run(new FormMain());
            
            Finalize();
        }

        #region Updating themes - Disabled

        static void UpdateStyles()
        {
            //Schemes.LoadHighlighters(@"C:\Users\Stewart\AppData\Local\DevNotepad_Old\Syntax\Schemes");
            //foreach(DevNotepad.Models.Scheme.Scheme scheme in Schemes.Highlighters){
            //    Scheme sc = new Scheme();
            //    sc.AutoCloseBraces = scheme.AutoCloseBraces;
            //    sc.AutoCloseStrings = true;
            //    sc.AutoCloseTags = scheme.AutoCloseTags;
            //    sc.Name = scheme.Name;
            //    sc.Folding = scheme.Folding;
            //    sc.FoldElse = scheme.FoldElse;
            //    sc.FoldComments = scheme.FoldComments;
            //    sc.FoldCompact = scheme.FoldCompact;
            //    sc.FoldPreprocessors = scheme.FoldPreproc;
            //    sc.Lexer = scheme.Lexer;
            //    sc.IndentType = scheme.IndentType;
                
            //    foreach (DevNotepad.Models.Scheme.Keyword keyword in scheme.Keywords)
            //    {
            //        sc.Keywords.Add(new Models.Syntax.Keyword()
            //        {
            //            Key = keyword.Key,
            //            Keywords = keyword.Keywords,
            //            Name = keyword.Name
            //        });
            //    }

            //    foreach (DevNotepad.Models.Scheme.Style style in scheme.Styles)
            //    {
            //        sc.Styles.Add(new Style()
            //        {
            //            Back = style.Back,
            //            Bold = style.Bold,
            //            Fore = style.Fore,
            //            Italic = style.Italic,
            //            Key = style.Key,
            //            Name = style.Name,
            //            Template = style.PresetClass,
            //            Underline = style.Underline,
            //            Font = style.Font,
            //            FontSize = 10
            //        });
            //    }

            //    switch (sc.Name.ToLowerInvariant())
            //    {
            //        case "web":
            //            sc.Extensions = new string[] {
            //                ".html",
            //                ".htm",
            //                ".php",
            //                ".php4",
            //                ".php5",
            //                ".php3",
            //                ".xhtml",
            //                ".shtml"
            //            };
            //            break;
            //        case "javascript":
            //            sc.Extensions = new string[] {
            //                ".js"
            //            };
            //            break;
            //        case "csharp":
            //            sc.Extensions = new string[] {
            //                ".cs"
            //            };
            //            break;
            //        case "css":
            //            sc.Extensions = new string[] {
            //                ".css"
            //            };
            //            break;
            //        case "java":
            //            sc.Extensions = new string[] {
            //                ".java"
            //            };
            //            break;
            //        case "batch":
            //            sc.Extensions = new string[] {
            //                ".bat"
            //            };
            //            break;
            //    }

            //    sc.Save();
            //}

            //Presets.LoadPresets(@"C:\Users\Stewart\AppData\Local\DevNotepad_Old\Syntax\Presets");
            //foreach (DevNotepad.Models.Scheme.Preset preset in Presets.PresetList)
            //{
            //    Preset pr = new Preset();
            //    pr.FoldBackground = preset.FoldBackground;
            //    pr.CursorColor = preset.CursorColor;
            //    pr.Name = preset.Name;
            //    pr.NumberBackground = preset.NumberBackground;
            //    pr.NumberForeground = preset.NumberBackground;
            //    foreach (DevNotepad.Models.Scheme.PresetStyle prn in preset.Presets)
            //    {
            //        if (!pr.Presets.ContainsKey(prn.Name))
            //        {
            //            pr.Presets.Add(prn.Name, new PresetStyle()
            //            {
            //                Back = prn.Back,
            //                Bold = prn.Bold,
            //                EOLFilled = prn.EOLFilled,
            //                Font = prn.Font,
            //                Fore = prn.Fore,
            //                Italic = prn.Italic,
            //                Name = prn.Name,
            //                Underline = prn.Underline,
            //                FontSize = 10
            //            });
            //        }
            //    }
            //    pr.Save();
            //}
        }

        #endregion

        #region Initialize application

        static void Initialize()
        {
            try
            {
                Paths.Initialize();
                PluginsManager.LoadPlugins(DocumentManager.PluginHost);
                PluginsManager.InitializePlugins();
                Log.Initialize();
                Themes.LoadPresets();
                LanguageManager.InitializeLanguages();
                Schemes.LoadHighlighters();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //LanguageManager.SaveLanguage(Path.Combine(Paths.LanguagePath, "en-us.xml"));
        }

        #endregion

        #region Application exiting

        static void Finalize()
        {
            Log.Finalize();
        }

        #endregion

    }
}
