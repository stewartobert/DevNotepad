using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevNotepad.Tools;
using DevNotepad.Models.Themes;
using DevNotepad.Config;
using DevNotepad.Library.Extensions;
using DevNotepad.Debug;

namespace DevNotepad.GUI.Settings
{
    public partial class ThemeSettings : UserControl
    {
        private Theme _Theme = null;

        private PresetStyle _ActiveStyle = null;

        #region Store default colors for showing colors where not set.

        private string _DefaultFore;
        private string _DefaultBack;

        #endregion

        public ThemeSettings(Theme theme)
        {
            InitializeComponent();
            _Theme = theme;
        }

        /// <summary>
        /// Load initializes the language settings, colors, etc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThemeSettings_Load(object sender, EventArgs e)
        {
            LanguageManager.InitializeControl(this);

            try
            {
                PresetStyle presetStyle = _Theme.DefaultPreset; //.Presets.Where(m => m.Key.Equals("default", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().Value;
                if (presetStyle != null)
                {
                    _DefaultBack = presetStyle.Back;
                    _DefaultFore = presetStyle.Fore;
                }
            }
            catch { }

            foreach (string key in Themes._DisplayNames.Values)
            {
                ListStyles.Items.Add(key);
            }
 
            //foreach (string key in _Theme.Presets.Keys)
            //{
                
            //        ListStyles.Items.Add(_Theme.Presets[key]);
                
            //}
        }


        public void SetTheme(Theme theme)
        {

        }

        private void ListStyles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                PresetStyle preStyle = _Theme.GetPresetStyle(ListStyles.SelectedItem.ToString());
                    ColorFore.SelectedColor = preStyle.Fore.ToColor(_DefaultFore);
                    ColorBack.SelectedColor = preStyle.Back.ToColor(_DefaultBack);
                    CheckBold.Checked = preStyle.Bold;
                    CheckItalic.Checked = preStyle.Italic;
                    CheckUnderline.Checked = preStyle.Underline;
                    CheckEOLFilled.Checked = preStyle.EOLFilled;
                    _ActiveStyle = preStyle;
                
                    UpdateSample();
                
            } catch { }
        }

        private void ColorFore_ColorChanged(object sender, ColorComboTestApp.ColorChangeArgs e)
        {
            UpdateActiveStyle();
        }

        private void UpdateActiveStyle()
        {
            if (_ActiveStyle != null)
            {
                try
                {
                    _ActiveStyle.Fore = ColorFore.SelectedColor.ToHtml();
                    _ActiveStyle.Back = ColorBack.SelectedColor.ToHtml();
                    _ActiveStyle.Bold = CheckBold.Checked;
                    _ActiveStyle.EOLFilled = CheckEOLFilled.Checked;
                    _ActiveStyle.Italic = CheckItalic.Checked;
                    _ActiveStyle.Underline = CheckUnderline.Checked;
                    UpdateSample();
                }
                catch (Exception ex){
                    Log.Write(ex);
                }
            }
        }

        private void UpdateSample()
        {
            if (_ActiveStyle != null)
            {
                try
                {
                    LabelSample.BackColor = _ActiveStyle.Back.ToColor(_DefaultBack);
                    LabelSample.ForeColor = _ActiveStyle.Fore.ToColor(_DefaultFore);
                    FontStyle style = new FontStyle();
                    if (_ActiveStyle.Bold)
                        style = style | FontStyle.Bold;
                    if (_ActiveStyle.Italic)
                        style = style | FontStyle.Italic;
                    if (_ActiveStyle.Underline)
                        style = style | FontStyle.Underline;

                    LabelSample.Font = new Font("Courier New", (float)10, style);

                    LabelSample.Text = ListStyles.SelectedItem.ToString();
                    
                    LabelSample.Left = (PanelSample.ClientSize.Width - LabelSample.Size.Width) / 2;
                    LabelSample.Top = (PanelSample.ClientSize.Height - LabelSample.Size.Height) / 2;
                }
                catch { }
            }
        }

        private void CheckBold_Click(object sender, EventArgs e)
        {
            UpdateActiveStyle();
        }
    }
}
