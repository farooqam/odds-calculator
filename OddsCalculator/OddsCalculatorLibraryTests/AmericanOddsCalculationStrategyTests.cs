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
        [InlineData(100, 145, -250, -450, )]
        public void Calculate_CalculatesThreeTeamParlay(decimal wager, int odds1, int odds2, int odds3, decimal expectedReward)
        {

        }
    }
}
