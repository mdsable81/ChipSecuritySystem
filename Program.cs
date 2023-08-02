using System;
using System.Collections.Generic;

namespace ChipSecuritySystem
{
    class Program
    {
        static void Main()
        {
            try
            {
                var chipsToDecode = new List<ColorChip>
            {
                new ColorChip(Color.Blue, Color.Red),
                new ColorChip(Color.Red, Color.Green),
                new ColorChip(Color.Red, Color.Yellow),
                new ColorChip(Color.Yellow, Color.Green),
                new ColorChip(Color.Yellow, Color.Orange),
                new ColorChip(Color.Orange, Color.Green),
                new ColorChip(Color.Red, Color.Purple),
                new ColorChip(Color.Purple, Color.Orange),
                new ColorChip(Color.Orange, Color.Yellow)
            };
                var chipProcessor = new ChipProcessor(chipsToDecode);
                var longestCombination = chipProcessor.GenerateLongestLink();

                Console.WriteLine(chipProcessor.PrintLink(longestCombination));
            }
            catch (Exception ex)
            {
                throw new Exception(Constants.ErrorMessage, ex.InnerException);
            }

            Console.ReadLine();
        }
    }
}