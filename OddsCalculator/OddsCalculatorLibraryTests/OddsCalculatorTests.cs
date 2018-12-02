using FluentAssertions;
using Moq;
using Xunit;

namespace Techniqly.OddsCalculator
{
    public class OddsCalculatorTests
    {
        [Fact]
        public void Calculate_ReturnsTotalReward()
        {
            // Arrange
            
            var mockStrategy = new Mock<IOddsCalculationStrategy>();
            var wager = 100m;
            var odds = 120;
            var expectedReward = 120m;

            mockStrategy.Setup(s => s.Calculate(wager, odds)).Returns(expectedReward);

            var calculator = new OddsCalculatorService(mockStrategy.Object);

            // Act
            var actualReward = calculator.Calculate(wager, odds);

            // Assert
            actualReward.Should().Be(expectedReward);
        }
    }
}
