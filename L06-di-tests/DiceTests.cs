using FluentAssertions;
using L06_di_tests.Client;
using L06_di;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace L06_di_tests;

public class DiceTests
{
    private static void ConfigureContainer(IServiceCollection container)
    {
        container.AddSingleton<ILog, ConsoleLog>();
        container.AddSingleton<DiceClient>(sp =>
        {
            var logger = sp.GetRequiredService<ILog>();
            return new DiceClient(Consts.ServiceAddress, logger);
        });
    }

    [TestCase(1)]
    [TestCase(100)]
    public async Task Dice_Roll_ReturnSuccess(int count)
    {
        var container = new ServiceCollection();
        ConfigureContainer(container);
        var serviceProvider = container.BuildServiceProvider();

        var client = serviceProvider.GetRequiredService<DiceClient>();
        var result = await client.Sum(count);

        result.Should().NotBeNull();
    }
    
    [TestCase(-1)]
    [TestCase(101)]
    public async Task Dice_Roll_ReturnBadRequest(int count)
    {
        var container = new ServiceCollection();
        ConfigureContainer(container);
        var serviceProvider = container.BuildServiceProvider();

        var client = serviceProvider.GetRequiredService<DiceClient>();
        var result = await client.Sum(count);

        result.Should().BeNull();
    }
}