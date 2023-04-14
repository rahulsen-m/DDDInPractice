using DDDInPractice.Logic;
using FluentAssertions;
using Xunit;

namespace DDDInPractice.Tests;

public class MoneySpecs
{
    [Fact]
    public void Sum_of_two_money_produce_correct_result()
    {
        Money money1 = new Money(1, 2, 3, 4, 5, 6);
        Money money2 = new Money(1, 2, 3, 4, 5, 6);

        Money sum = money1 + money2;

        sum.OneCentCount.Should().Be(2);
        sum.TenCentCount.Should().Be(4);
        sum.QuarterCount.Should().Be(6);
        sum.OneDollerCount.Should().Be(8);
        sum.FiveDollerCount.Should().Be(10);
        sum.TwentyDollerCount.Should().Be(12);
    }
}