namespace Solid.Abstractions;

public interface IRandomGenerator
{
    int GenerateValue(int from, int to);
}