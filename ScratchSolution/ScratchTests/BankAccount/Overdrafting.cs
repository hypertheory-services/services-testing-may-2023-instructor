


namespace ScratchTests.BankAccount;

public class Overdrafting
{
    [Fact]
    public void OverdraftDoesNotDecreaseBalance()
    {
        var account = new Account();
        var openingBalance = account.GetBalance();

        account.Withdraw(openingBalance + 0.01M);

        Assert.Equal(openingBalance, account.GetBalance());
    }

    [Fact]
    public void BehaviorBeforeChange()
    {
        var account = new Account();
        var openingBalance = account.GetBalance();
        var amountToWithdraw = 0.01M;

        account.Withdraw(openingBalance + amountToWithdraw);

        Assert.Equal(openingBalance - (openingBalance + amountToWithdraw), account.GetBalance());
    }
}
