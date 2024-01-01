using Solid.Abstractions;

namespace Solid.Implementations;

public class GuessGame:IGame
{
    private const string ExitCode = "Exit";
    
    private readonly IRandomGenerator _randomGenerator;
    private int _gameValue;

    public GuessGame(IRandomGenerator randomGenerator)
    {
        _randomGenerator = randomGenerator;
    }

    public void Play(int retryCount)
    {
        _gameValue = _randomGenerator.GenerateValue(0, 10);
        Console.WriteLine($"Игра началась. Для выхода введите вместо загадываемого числа \"{ExitCode}\"");
        var state = GameRoundState.Lose;
        for (int i = 0; i < retryCount && state == GameRoundState.Lose; i++)
        {
            state = PlayRound();
        }

        switch (state)
        {
            case GameRoundState.Win:
                Console.WriteLine("Вы победили, поздравляю.");
                break;
            case GameRoundState.Lose:
                Console.WriteLine("Вы проиграли");
                break;
            case GameRoundState.Exit:
                Console.WriteLine($"Спасибо за игру!\n");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    /// <summary>
    /// Играет один игровой круг
    /// </summary>
    /// <returns>Возвращает true если продолжаем, false если пользователь захотел выйти из игры</returns>
    private GameRoundState PlayRound()
    {
        Console.Write("Введите число: ");
        var stringGuess = Console.ReadLine();
        if (stringGuess == ExitCode)
        {
            return GameRoundState.Exit;
        }
        
        var userGuess = int.Parse(stringGuess);

        if (_gameValue == userGuess)
        {
            return GameRoundState.Win;
        }
        else
        {
            var hintMessage = _gameValue > userGuess ? "меньше" : "больше";
            Console.WriteLine($"Ваше число {hintMessage} загаданного");
            return GameRoundState.Lose;
        }
    }
}