using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xamarin_MatchingGame
{
    public class RandomLetterGenerator
    {
        public List<string> Letters { get; }
        Random random = new Random();

        public RandomLetterGenerator()
        {
            Letters = GenerateLettersList();
        }

        private List<string> GenerateLettersList()
        {
            return new List<string>()
            {
                "Q",
                "W",
                "E",
                "R",
                "T",
                "Y",
                "U",
                "I",
                "O",
                "P",
                "S",
                "D",
                "F",
                "G",
                "H",
                "J",
                "K",
                "L",
                "Z",
                "X",
                "C",
                "V",
                "B",
                "N",
                "M",
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9"
            };
        }

        public string GetAndRemoveRandomLetter()
        {
            int index = random.Next(0, Letters.Count() - 1);
            string letter = Letters[index];
            Letters.RemoveAt(index);
            return letter;
        }
    }
}
