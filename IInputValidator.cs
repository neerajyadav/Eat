namespace EatOrNot
{
    interface IInputValidator
    {
        bool AreNutritionsValid(int index);
        bool IsNumberOfFruitsValid();
        bool IsNutritionsRowsPresentForEachFruit();
    }
}