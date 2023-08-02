using System.Collections.Generic;
using System.Linq;

namespace ChipSecuritySystem
{
    public class ChipProcessor
    {
        private readonly List<ColorChip> _chipsToDecode;

        public ChipProcessor(IEnumerable<ColorChip> chipsToDecode) 
        {
            _chipsToDecode = chipsToDecode.ToList();
        }

        public IList<ColorChip> GenerateLongestLink()
        {
            var allCombinations = GetAllPossibleCombinations();
            var allBlueToGreenCombinations = allCombinations.Where(x => x.Any(y=>y.StartColor == Color.Blue) && x.Any(y=>y.EndColor == Color.Green));
            var validCombinations = new List<IList<ColorChip>>();
            foreach (var combination in allBlueToGreenCombinations)
            {
                var isValid = true;
                for (var i = 0; i < combination.Count; i++)
                {
                    if (i != 0)  // null check
                    {
                        if (combination[i - 1].EndColor != combination[i].StartColor)  // not a valid link
                        {
                            isValid = false;
                            break;
                        }
                    }
                }
                if (isValid)
                    validCombinations.Add(combination);
            }

            return validCombinations.OrderByDescending(x => x.Count).FirstOrDefault();
        }

        public string PrintLink(IList<ColorChip> link)
        {
            if (link == null || !link.Any())
                return Constants.ErrorMessage;

            var linkstring = "Blue ";
            foreach (var item in link)
            {
                linkstring += $"[{item}] ";
            }
            linkstring += $"Green";
            return linkstring;
        }

        private IEnumerable<IList<ColorChip>> GetAllPossibleCombinations()
        {
            return Enumerable
                             .Range(1, (1 << (_chipsToDecode.Count)) - 1)
                             .Select(index => _chipsToDecode
                             .Where((v, i) => (index & (1 << i)) != 0).ToList()
                            );
        }
    }
}