using ChipSecuritySystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void OneValidPath()
        {
            var chipsToDecode = new List<ColorChip>
            {
                new ColorChip(Color.Blue, Color.Yellow),
                new ColorChip(Color.Yellow, Color.Red),
                new ColorChip(Color.Red, Color.Green),
                new ColorChip(Color.Orange, Color.Purple)
            };

            var chipProcessor = new ChipProcessor(chipsToDecode);
            var link = chipProcessor.GenerateLongestLink();
            var result = chipProcessor.PrintLink(link);
            Assert.AreEqual($"Blue [Blue, Yellow] [Yellow, Red] [Red, Green] Green", result);
        }

        [TestMethod]
        public void MultipleValidPaths()
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
            var link = chipProcessor.GenerateLongestLink();
            var result = chipProcessor.PrintLink(link);
            Assert.AreEqual($"Blue [Blue, Red] [Red, Yellow] [Yellow, Orange] [Orange, Green] Green", result);
        }

        [TestMethod]
        public void NoValidPath()
        {
            var chipsToDecode = new List<ColorChip>
            {
                new ColorChip(Color.Blue, Color.Red),
                new ColorChip(Color.Yellow, Color.Green)
            };

            var chipProcessor = new ChipProcessor(chipsToDecode);
            var link = chipProcessor.GenerateLongestLink();
            var result = chipProcessor.PrintLink(link);
            Assert.AreEqual(Constants.ErrorMessage, result);
        }

        [TestMethod]
        public void NoChips()
        {
            var chipsToDecode = new List<ColorChip>();

            var chipProcessor = new ChipProcessor(chipsToDecode);
            var link = chipProcessor.GenerateLongestLink();
            var result = chipProcessor.PrintLink(link);
            Assert.AreEqual(Constants.ErrorMessage, result);
        }

        [TestMethod]
        public void OneChip()
        {
            var chipsToDecode = new List<ColorChip>
            {
                new ColorChip(Color.Blue, Color.Green)
            };

            var chipProcessor = new ChipProcessor(chipsToDecode);
            var link = chipProcessor.GenerateLongestLink();
            var result = chipProcessor.PrintLink(link);
            Assert.AreEqual($"Blue [Blue, Green] Green", result);
        }

        [TestMethod]
        public void ChipWithAStartColorOfGreen()
        {
            var chipsToDecode = new List<ColorChip>
            {
                new ColorChip(Color.Blue, Color.Green),
                new ColorChip(Color.Green, Color.Red),
                new ColorChip(Color.Red, Color.Green)
            };

            var chipProcessor = new ChipProcessor(chipsToDecode);
            var link = chipProcessor.GenerateLongestLink();
            var result = chipProcessor.PrintLink(link);
            Assert.AreEqual($"Blue [Blue, Green] [Green, Red] [Red, Green] Green", result);
        }

        [TestMethod]
        public void ChipWithAnEndColorOfBlue()
        {
            var chipsToDecode = new List<ColorChip>
            {
                new ColorChip(Color.Blue, Color.Red),
                new ColorChip(Color.Red, Color.Blue),
                new ColorChip(Color.Blue, Color.Yellow),
                new ColorChip(Color.Yellow, Color.Green)
            };

            var chipProcessor = new ChipProcessor(chipsToDecode);
            var link = chipProcessor.GenerateLongestLink();
            var result = chipProcessor.PrintLink(link);
            Assert.AreEqual($"Blue [Blue, Red] [Red, Blue] [Blue, Yellow] [Yellow, Green] Green", result);
        }

        [TestMethod]
        public void ChipWithSameColorOnBothEnds()
        {
            var chipsToDecode = new List<ColorChip>
            {
                new ColorChip(Color.Blue, Color.Red),
                new ColorChip(Color.Red, Color.Red),
                new ColorChip(Color.Red, Color.Green)
            };

            var chipProcessor = new ChipProcessor(chipsToDecode);
            var link = chipProcessor.GenerateLongestLink();
            var result = chipProcessor.PrintLink(link);
            Assert.AreEqual($"Blue [Blue, Red] [Red, Red] [Red, Green] Green", result);
        }
    }
}
