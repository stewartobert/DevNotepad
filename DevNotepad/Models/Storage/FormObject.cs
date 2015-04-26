using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevNotepad.UI.Controls;

namespace DevNotepad.Models.Storage
{

    public class FormObject
    {

        public string Name { get; set; }
        public bool Checked { get; set; }
        public string Text { get; set; }
        public int Item { get; set; }

        public bool ProcessObject(Object obj)
        {
            if (obj.GetType() == typeof(CheckBox))
            {
                Name = ((CheckBox)obj).Name;
                Checked = ((CheckBox)obj).Checked;
                Item = -1;
                Text = null;
                return true;
            }

            if (obj.GetType() == typeof(RadioButton))
            {
                Name = ((RadioButton)obj).Name;
                Checked = ((RadioButton)obj).Checked;
                Item = -1;
                Text = null;
                return true;
            }

            if (obj.GetType() == typeof(RadioGroup))
            {
                Name = ((RadioGroup)obj).Name;
                
                Item = ((RadioGroup)obj).SelectedItem;
                Text = null;
                return true;
            }


            return false;
        }

    }

    public class FormData
    {
        /// <summary>
        /// Width of the form
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Height of the form
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// The left position of the form.
        /// </summary>
        public int Left { get; set; }


        /// <summary>
        /// The top position of the form.
        /// </summary>
        public int Top { get; set; }

        /// <summary>
        /// Window state of the form
        /// </summary>
        public FormWindowState WindowState { get; set; }

        /// <summary>
        /// List of objects on the form.
        /// </summary>
        public List<FormObject> Objects { get; set; }

        public void ProcessForm(Form form)
        {
            Objects = new List<FormObject>();
            // Step 1 get the state
            WindowState = form.WindowState;
            if (WindowState != FormWindowState.Normal)
            {
                // Form window state isn't normal so it's necessary to revert it to normal
                // to get it's non maximized/minimized dimensions
                form.WindowState = FormWindowState.Normal;
            }
            Width = form.Width;
            Height = form.Height;
            Left = form.Left;
            Top = form.Top;
            ProcessObjects(form);
        }

        /// <summary>
        /// Process all child controls within the control. 
        /// </summary>
        /// <param name="obj"></param>
        public void ProcessObjects(Control obj)
        {
            foreach (Control nObj in obj.Controls)
            {
                FormObject formObject = new FormObject();
                if (formObject.ProcessObject(nObj))
                {
                    // Only add to the list if we can figure out what it was.
                    Objects.Add(formObject);
                }
                else
                {
                    ProcessObjects(nObj);
                }
            }
        }

        public void RestoreForm(Form form)
        {
            try
            {
                form.Width = Width;
                form.Height = Height;
                form.Left = Left;
                form.Top = Top;
                form.WindowState = WindowState;
            }
            catch { }
            foreach (FormObject obj in Objects)
            {
                RestoreObject(obj, form);
            }
        }

        private void RestoreObject(FormObject obj, Form form)
        {
            Control ctrl = GetControlByName(obj.Name, form);
            if (ctrl != null)
            {
                if (ctrl.GetType() == typeof(CheckBox))
                {
                    ((CheckBox)ctrl).Checked = obj.Checked;
                }

                if (ctrl.GetType() == typeof(RadioButton))
                {
                    ((RadioButton)ctrl).Checked = obj.Checked;
                }

                if (ctrl.GetType() == typeof(RadioGroup))
                {
                    ((RadioGroup)ctrl).SelectedItem = obj.Item;
                }
            }
        }

        Control GetControlByName(string Name, Control form)
        {
            foreach (Control c in form.Controls)
                if (c.Name == Name)
                    return c;
                else
                {
                    Control ctrl = GetControlByName(Name, c);
                    if (ctrl != null)
                        return ctrl;
                }

            return null;
        }


    }
}
