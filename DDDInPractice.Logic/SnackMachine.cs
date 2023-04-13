namespace DDDInPractice.Logic;

// creating a sealed class so that this class can not be inherited
public sealed class SnackMachine
{
    public int OneCentCount { get; private set; }
    public int TenCentCount { get; private set; }
    public int QuarterCount { get; private set; }
    public int OneDollerCount { get; private set; }
    public int FiveDollerCount { get; private set; }
    public int TwentyDollerCount { get; private set; }

    // here we are adding separate properties
    // as we need to somehow distinguish the money is in the snack machine 
    // and the money we need to return 
    // so one entity will take care of the money , which are in the machine
    // another properties will be used for maintain the return transaction property
    public int OneCentCountInTransaction { get; private set; }
    public int TenCentCountInTransaction { get; private set; }
    public int QuarterCountInTransaction { get; private set; }
    public int OneDollerCountInTransaction { get; private set; }
    public int FiveDollerCountInTransaction { get; private set; }
    public int TwentyDollerCountInTransaction { get; private set; }


    /// <summary>
    /// Inserts the money to the snack machine
    /// </summary>
    /// <param name="oneCentCount">The one cent count.</param>
    /// <param name="tenCentCount">The ten cent count.</param>
    /// <param name="quarterCount">The quarter count.</param>
    /// <param name="oneDollerCount">The one doller count.</param>
    /// <param name="fiveDollerCount">The five doller count.</param>
    /// <param name="twentityDollerCount">The twenty doller count.</param>
    public void InsertMoney(int oneCentCount, 
                        int tenCentCount, 
                        int quarterCount, 
                        int oneDollerCount, 
                        int fiveDollerCount, 
                        int twentyDollerCount)
    {
        // here we are tracking what money is the user is using in the transaction
        OneCentCountInTransaction += oneCentCount;
        TenCentCountInTransaction += tenCentCount;
        QuarterCountInTransaction += quarterCount;
        OneDollerCountInTransaction += oneDollerCount;
        FiveDollerCountInTransaction += fiveDollerCount;
        TwentyDollerCountInTransaction += twentyDollerCount;
    }

    /// <summary>
    /// Returns the money from the snack machine.
    /// </summary>
    public void ReturnMoney()
    {
        // when user will ask to return the money from the snack machine 
        // the all used transaction properties will be set to 0
        OneCentCountInTransaction = 0;
        TenCentCountInTransaction = 0;
        QuarterCountInTransaction = 0;
        OneDollerCountInTransaction = 0;
        FiveDollerCountInTransaction = 0;
        TwentyDollerCountInTransaction = 0;
    }

    /// <summary>
    /// Buys the snack.
    /// </summary>
    public void BuySnack()
    {
        //if the user confirms to buy the snack 
        // we will be store the money to machine
        // using the transaction amount
        OneCentCount += OneCentCountInTransaction;
        TenCentCount += TenCentCountInTransaction;
        QuarterCount += QuarterCountInTransaction;
        OneCentCount += OneCentCountInTransaction;
        FiveDollerCount += FiveDollerCountInTransaction;
        TwentyDollerCount += TwentyDollerCountInTransaction;

        // after adding the transaction value we need to reset the transaction value
        OneCentCountInTransaction = 0;
        TenCentCountInTransaction = 0;
        QuarterCountInTransaction = 0;
        OneDollerCountInTransaction = 0;
        FiveDollerCountInTransaction = 0;
        TwentyDollerCountInTransaction = 0;
    }
}
