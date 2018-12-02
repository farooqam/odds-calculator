namespace Techniqly.OddsCalculator
{
    public class OddsCalculatorService
    {
        private readonly IOddsCalculationStrategy _strategy;

        public OddsCalculatorService(IOddsCalculationStrategy strategy)
        {
            _strategy = strategy;
        }

        public decimal Calculate(decimal wager, int odds)
        {
            return _strategy.Calculate(wager, odds);
        }
    }
}