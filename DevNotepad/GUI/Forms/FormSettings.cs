using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevNotepad.Config;
using DevNotepad.GUI.Settings;
using DevNotepad.Models.Themes;
using DevNotepad.Tools;
using DevNotepad.Library.Extensions;

namespace DevNotepad.GUI.Forms
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            InitializeSettings();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            LanguageManager.InitializeControl(this);
        }

        private void InitializeSettings()
        {
            TreeNode general = new TreeNode(LanguageManager.GetText("GENERALSETTINGS", true));
            TreeSettings.Nodes.Add(general);

            TreeNode themes = new TreeNode(LanguageManager.GetText("THEMES", true));
            foreach (Theme theme in Themes.PresetList)
            {
                TreeNode node = new TreeNode(theme.Name);
                node.Tag = theme;
                themes.Nodes.Add(node);
            }
            TreeSettings.Nodes.Add(themes);
            TreeSettings.ExpandAll();
        }

        private void SettingsLayout_Click(object sender, EventArgs e)
        {

        }

        private void TreeSettings_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                PanelSettings.Suspend();
                if (e.Node != null)
                {
                    if (e.Node.Tag.GetType() == typeof(Theme))
                    {
                        
                        ThemeSettings settings = new ThemeSettings((Theme)e.Node.Tag);
                        PanelSettings.Controls.Clear();
                        settings.Dock = DockStyle.Fill;
                        PanelSettings.Controls.Add(settings);
                        settings.Visible = true;
                    }
                }
            }
            catch { }
            finally
            {
                PanelSettings.Resume();
            }
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Theme theme in Themes.PresetList)
            {
                theme.Save();
            }
        }
    }
}
