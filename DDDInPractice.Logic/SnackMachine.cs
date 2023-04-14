using static DDDInPractice.Logic.Money;
namespace DDDInPractice.Logic;

// creating a sealed class so that this class can not be inherited
public sealed class SnackMachine : Entity
{
    public Money MoneyInside { get; private set; }
    public Money MoneyInTransaction { get; private set; }

    // we need to initialize the MoneyInside, MoneyInTransaction before using that
    public SnackMachine()
    {
        MoneyInside = None;
        MoneyInTransaction = None;
    }

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
    
    public void InsertMoney(Money money)
    {
        // here we are tracking what money is the user is using in the transaction
        MoneyInTransaction += money;
    }

    /// <summary>
    /// Returns the money from the snack machine.
    /// </summary>
    public void ReturnMoney()
    {
        // when user will ask to return the money from the snack machine 
        // the all used transaction properties will be set to 0
        //MoneyInTransaction = 0;
        MoneyInTransaction = None;
    }

    /// <summary>
    /// Buys the snack.
    /// </summary>
    public void BuySnack()
    {
        //if the user confirms to buy the snack 
        // we will be store the money to machine
        // using the transaction amount
        MoneyInside += MoneyInTransaction;

        // after adding the transaction value we need to reset the transaction value
        //MoneyInTransaction = 0;
    }
}
