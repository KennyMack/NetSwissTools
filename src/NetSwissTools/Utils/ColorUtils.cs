using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace NetSwissTools.Utils
{
    public static class ColorUtils
    {
        #region Color description
        public static Color ColorDescription(this Color pColor)
        {
            double y = (299 * pColor.R + 587 * pColor.G + 114 * pColor.B) / 1000;
            return y >= 128 ? Color.Black : Color.White;
        }
        #endregion

        #region Reverse color
        public static Color ReverseColor(this Color pColor)
        {
            return Color.FromArgb(255 - pColor.R, 255 - pColor.G, 255 - pColor.B);
        }
        #endregion
    }
}
