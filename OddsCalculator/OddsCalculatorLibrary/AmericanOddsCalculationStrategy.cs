namespace Techniqly.OddsCalculator
{
    public class AmericanOddsCalculationStrategy : IOddsCalculationStrategy
    {
        public decimal Calculate(decimal wager, int odds)
        {
            var decimalOdds = ConvertToDecimalOdds(odds);
            return wager * (decimalOdds - 1m);
        }

        private decimal ConvertToDecimalOdds(int odds)
        {
            if (odds > 0)
            {
                return 1m + ((decimal)odds / 100m);
            }

            return 1m + (100m / (decimal) odds * -1m);
        }
    }
}