namespace EatOrNot
{
    interface IInputValidator
    {
        bool AreNutritionsValid(int index);
        bool IsNumberOfFruitsValid { get; }
        bool IsNutritionsRowsPresentForEachFruit { get; }
    }
}