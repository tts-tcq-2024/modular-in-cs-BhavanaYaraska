using System;
using System.Drawing;

namespace TelCo.ColorCoder
{
    /// <summary>
    /// Handles color mapping and related functionalities
    /// </summary>
    public static class ColorMap
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
            ValidatePairNumber(pairNumber);

            int zeroBasedPairNumber = pairNumber - 1;
            int majorIndex = zeroBasedPairNumber / colorMapMinor.Length;
            int minorIndex = zeroBasedPairNumber % colorMapMinor.Length;

            return new ColorPair(colorMapMajor[majorIndex], colorMapMinor[minorIndex]);
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

        private static void ValidatePairNumber(int pairNumber)
        {
            int maxPairNumber = colorMapMajor.Length * colorMapMinor.Length;
            if (pairNumber < 1 || pairNumber > maxPairNumber)
            {
                throw new ArgumentOutOfRangeException($"Argument PairNumber:{pairNumber} is outside the allowed range");
            }
        }
    }

    public class ColorPair
    {
        public Color MajorColor { get; }
        public Color MinorColor { get; }

        public ColorPair(Color majorColor, Color minorColor)
        {
            MajorColor = majorColor;
            MinorColor = minorColor;
        }

        public override string ToString()
        {
            return $"MajorColor:{MajorColor.Name}, MinorColor:{MinorColor.Name}";
        }
    }
}
