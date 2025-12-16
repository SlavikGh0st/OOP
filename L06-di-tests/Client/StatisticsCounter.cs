namespace L06_di_tests.Client;

public interface IStatisticsCounter
{
    void Add(int count, int sum);
}

public class StatisticsCounter : IStatisticsCounter
{
    private readonly Dictionary<int, int> countCounter = new();
    private readonly ILog log;

    public StatisticsCounter(ILog log)
    {
        this.log = log;
    }

    public void Add(int count, int sum)
    {
        if (countCounter.TryAdd(count, sum))
        {
            log.Info($"Init new stat for {count}: {sum}");
            return;
        }

        log.Info($"Set new stat for {count}: {countCounter[count]} + {sum}");
        countCounter[count] += sum;
    }
}