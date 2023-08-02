using System;
using System.Collections.Generic;
using System.Linq;

namespace ChipSecuritySystem
{
    public class ChipProcessorRecursive
    {
        private List<ColorChip> _best;

        public void LinkChips(List<ColorChip> chipsToDecode)
        {
            if (!chipsToDecode.Any() || !chipsToDecode.Any(x=>x.StartColor == Color.Blue) || !chipsToDecode.Any(x=>x.EndColor == Color.Green))
                 Console.WriteLine(Constants.ErrorMessage.ToString());

            var usedChips = new List<ColorChip>();
            _best = new List<ColorChip>();

            // let's assume there is only 1 blue for right now (might be able to iterate over all possible start locations later)
            var startChip = chipsToDecode.First(x=>x.StartColor == Color.Blue);
            usedChips.Add(startChip);
            chipsToDecode.Remove(startChip);

            foo(usedChips, chipsToDecode, null);
            foreach (var chip in usedChips) 
            {
                Console.Write($"[{chip}] ");
            }
        }

        private void foo(List<ColorChip> usedChips, List<ColorChip> remainingChips, ColorChip previousEnd)
        {
            while (remainingChips.Any())
            {
                var nextChip = remainingChips.FirstOrDefault(c => c.StartColor == usedChips.Last().EndColor);
                
                if (previousEnd != null)
                    remainingChips.Add(previousEnd);  // we've now run another check on the un-used collection WITHOUT the previous end so we can re-add it to check against later

                if (nextChip != null)
                {
                    usedChips.Add(nextChip);
                    remainingChips.Remove(nextChip);
                    foo(usedChips, remainingChips, null);
                }
                else
                {
                    if (usedChips.Count > _best.Count)
                        _best = usedChips.ToList();

                    previousEnd = usedChips.Last();
                    usedChips.Remove(previousEnd);
                    foo(usedChips, remainingChips, previousEnd);
                }
            }
        }
    }
}
