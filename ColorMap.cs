using System;
using System.Drawing;

namespace TelCo.ColorCoder
{
    /// <summary>
    /// Handles color mapping and related functionalities
    /// </summary>
    public class ColorMap
    {
        private static readonly Color[] colorMapMajor;
        private static readonly Color[] colorMapMinor;

        static ColorMap()
        {
            colorMapMajor = new Color[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet };
            colorMapMinor = new Color[] { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };
        }

        public static ColorPair GetColorFromPairNumber(int pairNumber)
        {
            int minorSize = colorMapMinor.Length;
            int majorSize = colorMapMajor.Length;
            if (pairNumber < 1 || pairNumber > minorSize * majorSize)
            {
                throw new ArgumentOutOfRangeException($"Argument PairNumber:{pairNumber} is outside the allowed range");
            }

            int zeroBasedPairNumber = pairNumber - 1;
            int majorIndex = zeroBasedPairNumber / minorSize;
            int minorIndex = zeroBasedPairNumber % minorSize;

            return new ColorPair() { MajorColor = colorMapMajor[majorIndex], MinorColor = colorMapMinor[minorIndex] };
        }

        public static int GetPairNumberFromColor(ColorPair pair)
        {
            int majorIndex = Array.IndexOf(colorMapMajor, pair.MajorColor);
            int minorIndex = Array.IndexOf(colorMapMinor, pair.MinorColor);

            if (majorIndex == -1 || minorIndex == -1)
            {
                throw new ArgumentException($"Unknown Colors: {pair}");
            }

            return (majorIndex * colorMapMinor.Length) + (minorIndex + 1);
        }
    }

    public class ColorPair
    {
        public Color MajorColor { get; set; }
        public Color MinorColor { get; set; }

        public override string ToString()
        {
            return $"MajorColor:{MajorColor.Name}, MinorColor:{MinorColor.Name}";
        }
    }
}
