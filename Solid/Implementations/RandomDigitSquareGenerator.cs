using Solid.Abstractions;

namespace Solid.Implementations;

public class RandomDigitSquareGenerator : IRandomGenerator
{
    private readonly Random _random = new();

    public int GenerateValue(int from = 0, int to = 100)
    {
        if (from < 0 || to > 10)
        {
            Console.WriteLine("Введён недопустимый диапазон");
        }
        
        var num = _random.Next(from, to);
        return num * num;
    }
}