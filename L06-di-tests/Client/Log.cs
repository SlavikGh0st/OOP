namespace L06_di_tests.Client;

public interface ILog
{
    public void Info(string message);
    public void Warn(string message);
    public void Error(string message);
}

public class ParametrizedConsoleLog : ILog
{
    private readonly ConsoleColor warnForegroundColor;
    private readonly ConsoleColor errorForegroundColor;

    public ParametrizedConsoleLog(
        ConsoleColor warnForegroundColor,
        ConsoleColor errorForegroundColor
    )
    {
        this.warnForegroundColor = warnForegroundColor;
        this.errorForegroundColor = errorForegroundColor;
    }

    public void Info(string message) => Console.WriteLine(message);

    public void Warn(string message) => Log(message, warnForegroundColor);

    public void Error(string message) => Log(message, errorForegroundColor);

    private static void Log(string message, ConsoleColor foregroundColor)
    {
        Console.ForegroundColor = foregroundColor;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}

public class ConsoleLog : ParametrizedConsoleLog
{
    public ConsoleLog()
        : base(ConsoleColor.Yellow, ConsoleColor.Red) { }
}
