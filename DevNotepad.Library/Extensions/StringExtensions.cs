using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevNotepad.Library.Extensions
{
    public static class StringExtensions
    {
        private static string _WordChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        /// <summary>
        /// Format html color to ensure proper structure
        /// </summary>
        /// <param name="val"></param>
        /// <param name="baseColor"></param>
        /// <returns></returns>
        public static string FormatColor(this string val, string baseColor = "#000000")
        {
            if (String.IsNullOrEmpty(val))
            {
                return baseColor;
            }
            //else
            //{
            //    if (val[0] != '#')
            //    {
            //        return "#" + val;
            //    }

            //}
            return val;
        }

        /// <summary>
        /// Convert html code to color
        /// </summary>
        /// <param name="val"></param>
        /// <param name="baseColor"></param>
        /// <returns></returns>
        public static Color ToColor(this string val, string baseColor = "#000000")
        {
            try
            {
                Color color = ColorTranslator.FromHtml(val.FormatColor(baseColor));
                if (color != null)
                    return color;
                else
                    return ColorTranslator.FromHtml(baseColor);
            }
            catch
            {
                try
                {
                    if (val.Length > 0 && val[0] != '#')
                    {
                        val = "#" + val;
                        return ColorTranslator.FromHtml(val);
                    }


                }
                catch { }
                return ColorTranslator.FromHtml(baseColor);
            }
        }

        /// <summary>
        /// Returns a string with escapes processed
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string Escapes(this string val)
        {
            return val.Replace("\\n", "\n").Replace("\\r", "\r").Replace("\\t", "\t").Replace("\\0", "\0");
        }

        public static bool IsWordChar(this char val)
        {
            return _WordChars.Contains(val);
        }
    }
}
