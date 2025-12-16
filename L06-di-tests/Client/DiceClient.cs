using System.Net.Http.Json;

namespace L06_di_tests.Client;

public class DiceClient
{
    private readonly HttpClient client;
    private readonly IStatisticsCounter statisticsCounter;
    private readonly ILog log;

    public DiceClient(string address, IStatisticsCounter statisticsCounter, ILog log)
    {
        this.log = log;
        this.statisticsCounter = statisticsCounter;
        client = new HttpClient { BaseAddress = new Uri(address) };
    }

    public async Task<int?> Sum(int count = 1)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"dice/sum/{count}");
        log.Info($"Sending {request.Method} '{request.RequestUri}'");

        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            log.Error($"Failed {request.Method} '{request.RequestUri}': {response.StatusCode}");
            return null;
        }

        log.Info($"Successful {request.Method} '{request.RequestUri}'");
        var responseContent = await response.Content.ReadAsStringAsync();
        if (!int.TryParse(responseContent, out var result))
        {
            log.Warn($"Failed to parse response: {responseContent}");
            return null;
        }

        statisticsCounter.Add(count, result);
        return result;
    }
}
