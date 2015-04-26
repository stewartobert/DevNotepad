using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevNotepad.GUI.Forms;
using DevNotepad.GUI.Forms.Docking;

namespace DevNotepad.Models
{
    public class FindItem
    {

        public string Name { get; set; }
        public int StartPos { get; set; }
        public int EndPos { get; set; }
        public string Text { get; set; }
        public FormDocument Document { get; set; }
        public string FileName { get; set; }
        public int ColStart { get; set; }
        public int Length { get; set; }
        public int TabWidth { get; set; }

        public FindItem(string name, string text, FormDocument document, string fileName, int startPos, int endPos, int colStart, int tabWidth)
        {
            Name = name;
            StartPos = startPos;
            EndPos = endPos;
            Document = document;
            FileName = fileName;
            Length = text.Length;
            ColStart = colStart;
            Text = text;
            TabWidth = tabWidth;
        }

        public FindItem(string text, FormDocument document, string fileName, int startPos, int endPos, int colStart, int tabWidth)
        {
            Name = (document == null ? fileName : document.Text);
            StartPos = startPos;
            EndPos = endPos;
            ColStart = colStart;
            Document = document;
            FileName = fileName;
            Text = text;
            Length = text.Length;
            TabWidth = tabWidth;
        }
    }
    public class FindList
    {
        public string Find { get; set; }
        public List<FindItem> Items { get; set; }

        public FindList(string find)
        {
            Find = find;
            Items = new List<FindItem>();
        }

        public void AddItem(string text, FormDocument document, string fileName, int startPos, int endPos, int colStart, int tabWidth)
        {
            string name = (document != null ? document.BaseTabText : fileName);
            Items.Add(new FindItem(name, text, document, fileName, startPos, endPos, colStart, tabWidth));
        }
        
    }
}
