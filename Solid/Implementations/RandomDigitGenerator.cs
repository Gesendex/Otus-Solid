using Solid.Abstractions;

namespace Solid.Implementations;

public class RandomDigitGenerator : IRandomGenerator
{
    private readonly Random _random = new();

    public int GenerateValue(int from = 0, int to = 10)
    {
        if (from < 0 || to > 10)
        {
            Console.WriteLine("Введён недопустимый диапазон");
        }
        
        return _random.Next(from, to);
    }
}