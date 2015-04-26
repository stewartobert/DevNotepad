using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace WeifenLuo.WinFormsUI.Docking.Extensions
{
    public static class ColorExtensions
    {
        /// <summary>
        /// Invert a color
        /// </summary>
        /// <param name="ColourToInvert"></param>
        /// <returns></returns>
        public static Color Invert(this Color ColourToInvert)
        {
            return Color.FromArgb((byte)~ColourToInvert.R, (byte)~ColourToInvert.G, (byte)~ColourToInvert.B);
        }

        public static float Lerp(this float start, float end, float amount)
        {
            float difference = end - start;
            float adjusted = difference * amount;
            return start + adjusted;
        }

        public static Color Lerp(this Color colour, Color to, float amount)
        {
            // start colours as lerp-able floats
            float sr = colour.R, sg = colour.G, sb = colour.B;

            // end colours as lerp-able floats
            float er = to.R, eg = to.G, eb = to.B;

            // lerp the colours to get the difference
            byte r = (byte)sr.Lerp(er, amount),
                 g = (byte)sg.Lerp(eg, amount),
                 b = (byte)sb.Lerp(eb, amount);

            // return the new colour
            return Color.FromArgb(r, g, b);
        }
    }
}
