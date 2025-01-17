public class BankAccount
{
    private decimal _balance; 
    private string _accountOwner; 

    // Constructor to initialize the balance and account owner
    public BankAccount(string accountOwner, decimal startingBalance = 0)
    {
        _accountOwner = accountOwner;
        _balance = startingBalance;
    }

    // Deposit money into the account
    public bool Deposit(decimal moneyDeposit)
    {
        if (moneyDeposit <= 0)
        {
            return false; // Deposit amount must be positive
        }

        _balance += moneyDeposit;
        return true;  // Deposit successful
    }

    // Withdraw money from the account
    public bool Withdraw(decimal moneyWithdraw)
    {
        if (moneyWithdraw <= 0)
        {
            return false; // Withdrawal amount must be positive
        }

        if (moneyWithdraw > _balance)
        {
            return false; // Insufficient funds
        }

        _balance -= moneyWithdraw;
        return true; // Withdrawal successful
    }

    // View the current balance
    public decimal ViewBalance()
    {
        return _balance;
    }

    // Check if the account is overdrawn
    public bool IsOverdrawn()
    {
        return _balance < 0; // Account is overdrawn if balance is negative
    }

    // Get the account owner's name
    public string GetAccountOwner()
    {
        return _accountOwner;
    }

    public bool Transfer(BankAccount targetAccount, decimal amount)
    {
        if (amount <= 0)
        {
            return false; // Transfer amount must be positive
        }

        if (amount > _balance)
        {
            return false; // Insufficient funds
        }

        _balance -= amount;
        targetAccount.Deposit(amount);
        return true; // Transfer successful
    }

    public static void Main(string[] args)
    {
        BankAccount account1 = new BankAccount("Jared Smith", 10000);
        BankAccount account2 = new BankAccount("Tom Anderson", 5000);

        Console.WriteLine($"Account owner: {account1.GetAccountOwner()}");
        Console.WriteLine($"Initial balance: ${account1.ViewBalance()}");

        account1.Deposit(650);
        Console.WriteLine($"Balance was successfully deposited. Your balance is: ${account1.ViewBalance()}");

        account1.Withdraw(299);
        Console.WriteLine($"Balance was successfully withdrawn. Your balance is: ${account1.ViewBalance()}");

        account1.Transfer(account2, 1000);
        Console.WriteLine($"Transfer successful. Your balance is: ${account1.ViewBalance()}");
        Console.WriteLine($"Recipient's balance is: ${account2.ViewBalance()}");
    }
}