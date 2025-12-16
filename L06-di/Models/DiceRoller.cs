namespace L06_di.Models;

public class DiceRoller
{
    private readonly Random rand = new();

    public Guid DiceId { get; } = Guid.NewGuid();

    public int Roll() => rand.Next(1, 7);
}