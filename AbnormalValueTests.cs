using System;

namespace TelCo.ColorCoder
{
    public static class AbnormalValueTests
    {
        public static void RunTests()
        {
            ValidateAbnormalPairNumber(0);
            ValidateAbnormalPairNumber(26);
            ValidateAbnormalColors(new ColorPair(System.Drawing.Color.Pink, System.Drawing.Color.Blue));
        }
        private static void ValidateAbnormalPairNumber(int pairNumber)
        {
            try
            {
                ColorMap.GetColorFromPairNumber(pairNumber);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void ValidateAbnormalColors(ColorPair pair)
        {
            try
            {
                ColorMap.GetPairNumberFromColor(pair);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
