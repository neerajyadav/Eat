using System;
using System.Linq;

namespace EatOrNot
{
    class RowTransformer
    {
        public static int[] ConvertToIntArray(string intput)
        {
            return intput.Split(' ').Select<string, int>(int.Parse).ToArray();
        }

        public static Tuple<int[], int[], int[], int[]> ConvertToNutritionsArrays(string[] intput)
        {
            var numberOfRows = intput.Length;
            int[] V = new int[numberOfRows];
            int[] C = new int[numberOfRows];
            int[] P = new int[numberOfRows];
            int[] F = new int[numberOfRows];
            //int[,] fruitNutritionsMatrix = new int[numberOfFruits, 4];
            for (int i = 0; i <= numberOfRows; i++)
            {
                var nutritions = ConvertToIntArray(intput[i]);
                V[i] = nutritions[0];
                C[i] = nutritions[1];
                P[i] = nutritions[2];
                F[i] = nutritions[3];
            }

            return Tuple.Create(V, C, P, F);
        }
    }
}