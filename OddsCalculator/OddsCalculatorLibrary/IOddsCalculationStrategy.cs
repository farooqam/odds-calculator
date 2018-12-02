namespace Techniqly.OddsCalculator
{
    public interface IOddsCalculationStrategy
    {
        decimal Calculate(decimal wager, int odds);
    }
}