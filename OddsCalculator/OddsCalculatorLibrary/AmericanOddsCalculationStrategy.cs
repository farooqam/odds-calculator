using System.Linq;

namespace Techniqly.OddsCalculator
{
    public class AmericanOddsCalculationStrategy : IOddsCalculationStrategy
    {
        public decimal Calculate(decimal wager, int odds)
        {
            var decimalOdds = ConvertToDecimalOdds(odds);
            return wager * (decimalOdds - 1m);
        }

        public decimal Calculate(decimal wager, params int[] odds)
        {
            var multiplier = odds.Aggregate(1m, (current, odd) => current * ConvertToDecimalOdds(odd));
            return (multiplier - 1m) * wager;
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