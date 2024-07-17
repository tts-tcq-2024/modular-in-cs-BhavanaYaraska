using System;
using System.Diagnostics;

namespace TelCo.ColorCoder
{
    class Program
    {
        static void Main(string[] args)
        {
            TestColorCoding();
            TestAbnormalValues();
        }

        private static void TestColorCoding()
        {
            int pairNumber = 4;
            ColorPair testPair1 = ColorMap.GetColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber, testPair1);
            Debug.Assert(testPair1.MajorColor == Color.White);
            Debug.Assert(testPair1.MinorColor == Color.Brown);

            pairNumber = 5;
            testPair1 = ColorMap.GetColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber, testPair1);
            Debug.Assert(testPair1.MajorColor == Color.White);
            Debug.Assert(testPair1.MinorColor == Color.SlateGray);

            pairNumber = 23;
            testPair1 = ColorMap.GetColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber, testPair1);
            Debug.Assert(testPair1.MajorColor == Color.Violet);
            Debug.Assert(testPair1.MinorColor == Color.Green);

            ColorPair testPair2 = new ColorPair() { MajorColor = Color.Yellow, MinorColor = Color.Green };
            pairNumber = ColorMap.GetPairNumberFromColor(testPair2);
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}\n", testPair2, pairNumber);
            Debug.Assert(pairNumber == 18);

            testPair2 = new ColorPair() { MajorColor = Color.Red, MinorColor = Color.Blue };
            pairNumber = ColorMap.GetPairNumberFromColor(testPair2);
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}", testPair2, pairNumber);
            Debug.Assert(pairNumber == 6);
        }

        private static void TestAbnormalValues()
        {
            try
            {
                ColorMap.GetColorFromPairNumber(0);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                ColorMap.GetColorFromPairNumber(26);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                ColorPair unknownPair = new ColorPair() { MajorColor = Color.Pink, MinorColor = Color.Blue };
                ColorMap.GetPairNumberFromColor(unknownPair);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
