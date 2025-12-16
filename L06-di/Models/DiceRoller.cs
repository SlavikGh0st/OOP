namespace L06_di.Models;

public class DiceRoller
{
    private static int instanceCounter;
    private readonly Random rand = new();

    public DiceRoller()
    {
        instanceCounter++;
        DiceId = instanceCounter;
    }

    public int DiceId { get; }

    public int Roll() => rand.Next(1, 7);
}