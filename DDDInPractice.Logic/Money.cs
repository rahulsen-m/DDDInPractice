namespace DDDInPractice.Logic;

// Which designing the snack machine class 
// we found that all the notion is related to money
// so we create abstraction for Money class
public sealed class Money
{
    public int OneCentCount { get; set; }
    public int TenCentCount { get; set; }
    public int QuarterCount { get; set; }
    public int OneDollerCount { get; set; }
    public int FiveDollerCount { get; set; }
    public int TwentyDollerCount { get; set; }

    /// <summary>
    /// Initializes money class using the constructor
    /// </summary>
    /// <param name="oneCentCount">The one cent count.</param>
    /// <param name="tenCentCount">The ten cent count.</param>
    /// <param name="quarterCount">The quarter count.</param>
    /// <param name="oneDollerCount">The one doller count.</param>
    /// <param name="fiveDollerCount">The five doller count.</param>
    /// <param name="twentyDollerCount">The twenty doller count.</param>
    public Money(int oneCentCount,
                 int tenCentCount,
                 int quarterCount,
                 int oneDollerCount,
                 int fiveDollerCount,
                 int twentyDollerCount)
    {
        // here we are tracking what money is the user is using in the transaction
        OneCentCount = oneCentCount;
        TenCentCount = tenCentCount;
        QuarterCount = quarterCount;
        OneDollerCount = oneDollerCount;
        FiveDollerCount = fiveDollerCount;
        TwentyDollerCount = twentyDollerCount;
    }

    /// <summary>
    /// Implements the operator +.
    /// </summary>
    /// <param name="money1">The money1.</param>
    /// <param name="money2">The money2.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static Money operator +(Money money1, Money money2)
    {
        Money sum = new Money(
            money1.OneCentCount + money2.OneCentCount,
            money1.TenCentCount + money2.TenCentCount,
            money1.QuarterCount + money2.QuarterCount,
            money1.OneDollerCount + money2.OneDollerCount,
            money1.FiveDollerCount + money2.FiveDollerCount,
            money1.TwentyDollerCount + money2.TwentyDollerCount);
        return sum;
    }
}
