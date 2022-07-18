using NetSwissTools.Exceptions;
using NetSwissTools.Validations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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

        #region Hex To Int
        /// <summary>
        /// Convert an Hexadecimal color to its int value
        /// </summary>
        /// <param name="hexColor">Color format in hexa (#FFFFFF or FFFFFF)</param>
        /// <returns></returns>
        /// <exception cref="NetToolException">Thrown exception when value can't be converted</exception>
        public static int HexToInt(string hexColor)
        {
            if (hexColor.IsEmpty())
                throw new NetToolException("HexColor must be informed");

            Guard.ArgumentNotNullOrEmpty(hexColor, nameof(hexColor));
            return int.Parse(
                hexColor.Replace("#", string.Empty),
                NumberStyles.HexNumber);
        }
        #endregion


        #region Int To Hex
        /// <summary>
        /// Convert an int color to its Hexadecimal value
        /// </summary>
        /// <param name="color"></param>
        /// <returns>An hex color without the hash, ex: FFFFFF</returns>
        public static string IntToHex(int color)
        {
            return color.ToString("X");
        }
        #endregion
    }
}
