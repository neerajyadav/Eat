using System;
using System.Linq;

namespace EatOrNot
{
    class InputValidator : IInputValidator
    {
        private readonly string[] input;
        public InputValidator(string[] _input) => input = _input;

        public bool AreNutritionsValid(int index)
        {
            string row = input[index].Trim();

            if (row.Replace(" ", "").All(char.IsDigit))
            {
                var nutritions = row.Split(' ').Select<string, int>(int.Parse);
                foreach (var nutrition in nutritions)
                {
                    if (nutrition < 1 || nutrition > 1000)
                        return false;
                }
                return true;
            }
            return false;
        }

        public bool IsNumberOfFruitsValid
        {
            get
            {
                if (int.TryParse(input[1].Trim(), out int numberOfFruits))
                {
                    if (1 <= numberOfFruits && numberOfFruits <= 20)
                        return true;
                }
                return false;
            }
        }

        public bool IsNutritionsRowsPresentForEachFruit
        {
            get
            {
                var numberOfFruits = Convert.ToInt32(input[1]);
                if (input.Length == numberOfFruits + 2)
                    return true;
                else
                    return false;
            }
        }
    }
}