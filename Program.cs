using System;
using System.IO;

namespace EatOrNot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (StreamReader reader = File.OpenText("input.txt"))
                {
                    Console.WriteLine("reading input text file....");

                    string[] content = reader.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    //For production code we should use dependency injection.
                    IInputValidator validator = new InputValidator(content);

                    if (!validator.AreNutritionsValid(0))
                    {
                        Console.Error.WriteLine("Line 1: expected nutritions are not valid. Nutrition should be between 10 to 1000.");
                        Console.WriteLine("Exiting application...");
                        goto exit;
                    }
                    if (!validator.IsNumberOfFruitsValid)
                    {
                        Console.Error.WriteLine("Line 2: Fruits count is not valid. Fruits count should be between 1 to 20.");
                        Console.WriteLine("Exiting application...");
                        goto exit;
                    }
                    if (!validator.IsNutritionsRowsPresentForEachFruit)
                    {
                        Console.Error.WriteLine("Line 2: Fruits count is not valid. Fruits count should be between 1 to 20.");
                        Console.WriteLine("Exiting application...");
                        goto exit;
                    }
                    int[] expectedNutritions = RowTransformer.ConvertToIntArray(content[0]);
                    int numberOfFruits = Convert.ToInt32(content[1]);
                    var fruitsMatrix = new string[numberOfFruits];
                    content.CopyTo(fruitsMatrix, 2);
                    var nutritionsArrays = RowTransformer.ConvertToNutritionsArrays(fruitsMatrix);
                    
                    int[] V = nutritionsArrays.Item1;
                    int[] C = nutritionsArrays.Item1;
                    int[] P = nutritionsArrays.Item1;
                    int[] F = nutritionsArrays.Item1;


                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Can not read the input file. Error:");
                Console.WriteLine(ex.Message);
                goto exit;
            }
        exit:
            {
                Console.WriteLine("****************************");
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }
    }
}
