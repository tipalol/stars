namespace Stars.Console.Utils;

public static class Input
{
    /// <summary>
    /// Получает строку от пользователя в консоли
    /// </summary>
    public static string Get()
    {
        var input = System.Console.ReadLine();

        while (string.IsNullOrEmpty(input))
        {
            Print("Получена пустая строка, попробуйте еще раз");
            input = System.Console.ReadLine();
        }

        return input;
    }

    /// <summary>
    /// Выводит пользователю сообщение
    /// </summary>
    /// <param name="message">Выводимое сообщение</param>
    public static void Print(string message)
        => System.Console.WriteLine(message);

    /// <summary>
    /// Спрашивает пользователя и возвращает ответ
    /// </summary>
    /// <param name="message">Выводимый вопрос</param>
    public static string Ask(string message)
    {
        Print(message);

        var answer = Get();

        return answer;
    }
    
    /// <summary>
    /// Спрашивает пользователя и возвращает ответ
    /// </summary>
    /// <param name="message">Выводимый вопрос</param>
    public static int AskNumber(string message)
    {
        var input = Ask(message);
        int number;

        while (int.TryParse(input, out number) == false)
        {
            Print("Вам необходимо ввести число, капитан");
            input = Ask(message);
        }

        return number;
    }
    
    /// <summary>
    /// Спрашивает пользователя и возвращает ответ
    /// </summary>
    /// <param name="message">Выводимый вопрос</param>
    public static int AskNumber(string message, int min, int max)
    {
        var number = AskNumber(message);

        while (number < min || number > max)
        {
            Print($"Вам нужно выбрать от {min} до {max}");
            number = AskNumber(message);
        }

        return number;
    }

    public static void WaitKeyPress()
        => System.Console.ReadKey();

    public static void Clear()
        => System.Console.Clear();

    public static void Line()
        => System.Console.WriteLine();

}