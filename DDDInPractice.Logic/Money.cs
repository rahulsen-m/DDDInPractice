﻿namespace DDDInPractice.Logic;

// Which designing the snack machine class 
// we found that all the notion is related to money
// so we create abstraction for Money class
public sealed class Money : ValueObject<Money>
{
    //instead of writing several time ( in test and other part of the application)
    // new Money(0, 0, 0, 0, 0, 0)
    // we can create a new read-only static field for that
    public static readonly Money None = new Money(0, 0, 0, 0, 0, 0);

    // here we are creating field for each coin and note
    public static readonly Money Cent = new Money(1, 0, 0, 0, 0, 0);
    public static readonly Money TenCent = new Money(0, 1, 0, 0, 0, 0);
    public static readonly Money Quarter = new Money(0, 0, 1, 0, 0, 0);
    public static readonly Money Dollar = new Money(0, 0, 0, 1, 0, 0);
    public static readonly Money FiveDollar = new Money(0, 0, 0, 0, 1, 0);
    public static readonly Money TwentyDollar = new Money(0, 0, 0, 0, 0, 1);

    public int OneCentCount { get; }
    public int TenCentCount { get; }
    public int QuarterCount { get; }
    public int OneDollarCount { get; }
    public int FiveDollarCount { get;}
    public int TwentyDollarCount { get; }

    public decimal Amount =>
        OneCentCount * 0.01m +
        TenCentCount * 0.10m +
        QuarterCount * 0.25m +
        OneDollarCount +
        FiveDollarCount * 5 +
        TwentyDollarCount * 20;

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
        // we are not allowing th negative money
        if(oneCentCount < 0 || tenCentCount < 0 || quarterCount < 0 || oneDollerCount < 0 || fiveDollerCount < 0 || twentyDollerCount < 0)
            throw new InvalidOperationException();
        // here we are tracking what money is the user is using in the transaction
        OneCentCount = oneCentCount;
        TenCentCount = tenCentCount;
        QuarterCount = quarterCount;
        OneDollarCount = oneDollerCount;
        FiveDollarCount = fiveDollerCount;
        TwentyDollarCount = twentyDollerCount;
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
            money1.OneDollarCount + money2.OneDollarCount,
            money1.FiveDollarCount + money2.FiveDollarCount,
            money1.TwentyDollarCount + money2.TwentyDollarCount);
        return sum;
    }

    public static Money operator -(Money money1, Money money2) =>
        new Money(
            money1.OneCentCount - money2.OneCentCount,
            money1.TenCentCount - money2.TenCentCount,
            money1.QuarterCount - money2.QuarterCount,
            money1.OneDollarCount - money2.OneDollarCount,
            money1.FiveDollarCount - money2.FiveDollarCount,
            money1.TwentyDollarCount - money2.TwentyDollarCount);

    protected override bool EqualCore(Money other) => 
        OneCentCount == other.OneCentCount 
        && TenCentCount == other.TenCentCount
        && QuarterCount == other.QuarterCount
        && OneDollarCount == other.OneDollarCount
        && FiveDollarCount == other.FiveDollarCount
        && TwentyDollarCount== other.TwentyDollarCount;

    protected override int GetHashCodeCore()
    {
        //The method then initializes an integer variable called "hashCode"
        //with the value of the "OneCentCount" property.
        //The following lines of code use a bitwise XOR operation to combine the hash code
        //with the values of the other properties, multiplying each value by
        //a prime number (397) before XOR-ing it with the hash code.
        //This is a common algorithm for generating hash codes in .NET.
        unchecked
        {
            int hashCode = OneCentCount;
            hashCode = (hashCode * 397) ^ TenCentCount;
            hashCode = (hashCode * 397) ^ QuarterCount;
            hashCode = (hashCode * 397) ^ OneDollarCount;
            hashCode = (hashCode * 397) ^ FiveDollarCount;
            hashCode = (hashCode * 397) ^ TwentyDollarCount;
            return hashCode;
        }
    }
}
