using System;
using System.IO;
using System.Collections.Generic;

class Bank_Account     // Base class
{
    protected int account_number;
    protected string account_holder_name;
    protected double balance;
    protected string path = "accounts.txt"; // Fixed file path issue

    public Bank_Account()     // Constructor
    {
        account_number = 0;
        account_holder_name = "";
        balance = 0.0;
    }

    public virtual void Set_Details()  // Assigning values
    {
        Console.Write("Enter the account number: ");
        account_number = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the name of the account holder: ");
        account_holder_name = Console.ReadLine();
        Console.WriteLine($"Your account has been created with a balance of {balance}");
    }

    public double Deposit(double old_balance)  // Money deposit method
    {
        Console.Write("Enter the amount you want to deposit: ");
        if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
        {
            balance = old_balance + amount;
            Console.WriteLine($"Amount deposited. New Balance: {balance}");
        }
        else
        {
            Console.WriteLine("Invalid amount entered.");
        }
        return balance;
    }

    public virtual double Withdraw(double old_balance, double withdrawAmount)  // Withdraw method
    {
        if (withdrawAmount <= old_balance)
        {
            balance = old_balance - withdrawAmount;
            Console.WriteLine($"Amount withdrawn. New Balance: {balance}");
        }
        else
        {
            Console.WriteLine($"Insufficient balance. Your current balance is {old_balance}.");
        }
        return balance;
    }

    public override string ToString()
    {
        return $"{account_number}, {account_holder_name}, {balance}";
    }
}

class Savings_Account : Bank_Account  // Derived class
{
    public Savings_Account() : base() { }

    public override void Set_Details()  // Overriding function
    {
        base.Set_Details();
        File.AppendAllText(path, ToString() + ", Savings" + Environment.NewLine);  // Fixed formatting
    }

    public double Withdraw(double original_bal)  // Overloaded Withdraw function
    {
        Console.Write("Enter the amount you want to withdraw: ");
        if (double.TryParse(Console.ReadLine(), out double withdraw))
        {
            if (withdraw <= 35000.00)
            {
                return base.Withdraw(original_bal, withdraw);
            }
            else
            {
                Console.WriteLine("You cannot withdraw more than 35000.00");
                return original_bal;
            }
        }
        else
        {
            Console.WriteLine("Invalid amount entered.");
            return original_bal;
        }
    }
}

class Current_Account : Bank_Account  // Derived class
{
    public Current_Account() : base() { }

    public override void Set_Details()  // Overriding function
    {
        base.Set_Details();
        File.AppendAllText(path, ToString() + ", Current" + Environment.NewLine);  // Fixed formatting
    }

    public double Withdraw(double original_bal)  // Overloaded Withdraw function
    {
        Console.Write("Enter the amount you want to withdraw: ");
        if (double.TryParse(Console.ReadLine(), out double withdraw))
        {
            if (withdraw <= 20000.00)
            {
                return base.Withdraw(original_bal, withdraw);
            }
            else
            {
                Console.WriteLine("You cannot withdraw more than 20000.00");
                return original_bal;
            }
        }
        else
        {
            Console.WriteLine("Invalid amount entered.");
            return original_bal;
        }
    }
}

class Program
{
    public static void Main()
    {
        Console.WriteLine("Welcome to Bank Account Management System.");
        Savings_Account S = new Savings_Account();
        Current_Account C = new Current_Account();
        string path = "accounts.txt";

        while (true)
        {
            Console.WriteLine("-------- Main Menu ----------");
            Console.WriteLine("1. Create an account.");
            Console.WriteLine("2. Cash Deposit");
            Console.WriteLine("3. Cash Withdraw");
            Console.WriteLine("4. Show Account Balance");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:  // Account Creation
                    Console.WriteLine("1. Savings Account\n2. Current Account");
                    Console.Write("Which account do you want to create? ");
                    int type = Convert.ToInt32(Console.ReadLine());
                    if (type == 1)
                        S.Set_Details();
                    else if (type == 2)
                        C.Set_Details();
                    else
                        Console.WriteLine("Invalid choice.");
                    break;

                case 2:  // Cash Deposit
                    Console.Write("Enter the account number: ");
                    string acc = Console.ReadLine();
                    UpdateAccountBalance(path, acc, true, S, C);
                    break;

                case 3:  // Cash Withdraw
                    Console.Write("Enter the account number: ");
                    acc = Console.ReadLine();
                    UpdateAccountBalance(path, acc, false, S, C);
                    break;

                case 4:  // Show Account Balance
                    Console.Write("Enter the account number: ");
                    acc = Console.ReadLine();
                    ShowAccountBalance(path, acc);
                    break;

                case 5:  // Exit
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
    //Deposit and Withdraw function
    static void UpdateAccountBalance(string path, string acc, bool isDeposit, Savings_Account S, Current_Account C)
    {
        List<string> lines = new List<string>(File.ReadAllLines(path));
        bool found = false;

        for (int i = 0; i < lines.Count; i++)
        {
            string[] words = lines[i].Split(", ");
            if (words.Length > 3 && words[0] == acc)
            {
                double oldBalance = Convert.ToDouble(words[2]);
                double newBalance;
                if (words[3] == "Savings")    //Savings Account
                {
                    if (isDeposit)
                        newBalance = S.Deposit(oldBalance);
                    else
                        newBalance = S.Withdraw(oldBalance);
                }
                else // Current Account
                {
                    if (isDeposit)
                        newBalance = C.Deposit(oldBalance);
                    else
                        newBalance = C.Withdraw(oldBalance);
                }


                lines[i] = $"{words[0]}, {words[1]}, {newBalance}, {words[3]}";
                File.WriteAllLines(path, lines);
                found = true;
                break;
            }
        }
        if (!found)
            Console.WriteLine("Account not found.");
    }

    static void ShowAccountBalance(string path, string acc)     //Show Account Balance
    {
        foreach (var line in File.ReadLines(path))
        {
            string[] words = line.Split(", ");
            if (words.Length > 2 && words[0] == acc)
            {
                Console.WriteLine($"Your balance is {words[2]}");
                return;
            }
        }
        Console.WriteLine("Account not found.");
    }
}