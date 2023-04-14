using DDDInPractice.Logic;
using FluentAssertions;
using static DDDInPractice.Logic.Money;

namespace DDDInPractice.Test;

public class SnackMachineSpecs
{
    [Fact]
    public void Return_money_empties_money_in_transaction()
    {
        var snackMachine = new SnackMachine();
        snackMachine.InsertMoney(Dollar);

        snackMachine.ReturnMoney();

        snackMachine.MoneyInTransaction.Amount.Should().Be(0);
    }
}
