using FluentAssertions;
using Xunit;

namespace Techniqly.OddsCalculator
{
    public class AmericanOddsCalculationStrategyTests
    {
        [Theory]
        [InlineData(100.0, -1000, 10.0)]
        [InlineData(100.0, -3000, 3.33)]
        [InlineData(100.0, 120, 120)]
        [InlineData(43.99, -1000, 4.40)]
        [InlineData(43.99, -3000, 1.47)]
        [InlineData(43.99, 120, 52.79)]
        public void Calculate_ReturnsTotalReward(decimal wager, int odds, decimal expectedReward)
        {
            // Arrange
            var strategy = new AmericanOddsCalculationStrategy();

            // Act
            var actualReward = strategy.Calculate(wager, odds);

            // Assert
            actualReward.Should().BeApproximately(expectedReward, 2);
        }

        [Theory]
        [InlineData(100, 145, 150, 512.50)]
        [InlineData(100, -1000, -3000, 13.67)]
        [InlineData(100, -1000, 145, 169.5)]
        public void Calculate_CalculatesParlay(decimal wager, int odds1, int odds2, decimal expectedReward)
        {
            // Arrange
            var strategy = new AmericanOddsCalculationStrategy();

            // Act
            var actualReward = strategy.Calculate(wager, odds1, odds2);

            // Assert
            actualReward.Should().BeApproximately(expectedReward, 2);
        }
    }
}
