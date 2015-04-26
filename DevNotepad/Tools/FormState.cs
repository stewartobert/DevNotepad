using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using DevNotepad.Config;
using DevNotepad.Debug;
using DevNotepad.Models.Storage;

namespace DevNotepad.Tools
{
    public static class FormState
    {
        /// <summary>
        /// Write the form state and all properties to XML file
        /// </summary>
        /// <param name="form"></param>
        /// <param name="fileName"></param>
        public static void WriteFormState(Form form)
        {
            FormData formData = new FormData();
            formData.ProcessForm(form);
            try
            {
                string fileName = Paths.GetFormPath(form.Name);
                if (File.Exists(fileName))
                {
                    try
                    {
                        // Delete to ensure were not writing over the existing stream with data
                        // that may be shorter causing malformed XML.
                        File.Delete(fileName);
                    }
                    catch { }
                }
                using (FileStream stream = File.OpenWrite(fileName))
                {
                    XmlSerializer serializer = new XmlSerializer(formData.GetType());
                    serializer.Serialize(stream, formData);
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }
        }

        public static void ReadFormState(Form form)
        {
            string fileName = Paths.GetFormPath(form.Name);
            XmlSerializer serializer = new XmlSerializer(typeof(FormData));
            try
            {
                using (FileStream stream = File.OpenRead(fileName))
                {
                    FormData formData = (FormData)serializer.Deserialize(stream);
                    if (formData != null)
                    {
                        formData.RestoreForm(form);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }
        }

    }
}
