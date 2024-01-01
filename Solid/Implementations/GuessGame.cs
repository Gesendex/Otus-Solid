using Solid.Abstractions;

namespace Solid.Implementations;

public class GuessGame:IGame
{
    private const string ExitCode = "Exit";
    
    private readonly IRandomGenerator _randomGenerator;

    public GuessGame(IRandomGenerator randomGenerator)
    {
        _randomGenerator = randomGenerator;
    }

    public void Play()
    {
        Console.WriteLine($"Игра началась. Для выхода введите вместо загадываемого числа \"{ExitCode}\"");

        while (PlayRound())
        {
        }
    }

    /// <summary>
    /// Играет один игровой круг
    /// </summary>
    /// <returns>Возвращает true если продолжаем, false если пользователь захотел выйти из игры</returns>
    private bool PlayRound()
    {
        var gameGuess = _randomGenerator.GenerateValue(0, 10);

        Console.Write("Введите число: ");
        var stringGuess = Console.ReadLine();
        if (stringGuess == ExitCode)
        {
            Console.WriteLine($"Спасибо за игру!\n");
            return false;
        }
        
        var userGuess = int.Parse(stringGuess);

        if (gameGuess == userGuess)
        {
            Console.WriteLine("Вы победили, поздравляю.");
            Console.WriteLine($"Попробуйте еще раз!\n");
        }
        else
        {
            Console.WriteLine($"Вы проиграли, ваше число {userGuess}, число которое нужно было угадать {gameGuess}.");
            Console.WriteLine($"Попробуйте еще раз!\n");
        }

        return true;
    }
}