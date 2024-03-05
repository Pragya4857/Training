using System;

namespace Assignment3
{
    // Exception class for insufficient balance during withdrawal
    public class InsufficientBalanceException : ApplicationException
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }

    public class BankingSystem
    {
        private decimal balance = 500; // Initial balance

        
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
               
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }

            balance += amount;
            Console.WriteLine($"Deposited: {amount}. Current Balance: {balance}");
        }

        // Method to withdraw money 
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                // ArgumentException
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }

            if (amount > balance)
            {
                // InsufficientBalanceException
                throw new InsufficientBalanceException("Insufficient balance for withdrawal.");
            }

            balance -= amount;
            Console.WriteLine($"Withdrawn: {amount}. Current Balance: {balance}");
        }

        // Method to check the balance in the account
        public decimal GetBalance()
        {
            return balance;
        }
    }

    public class Scholarship
    {
        public double CalculateScholarship(int marks, double fees)
        {
            double scholarshipAmount = 0;

            if (marks >= 70 && marks <= 80)
            {
                scholarshipAmount = 0.2 * fees;
            }
            else if (marks > 80 && marks <= 90)
            {
                scholarshipAmount = 0.3 * fees;
            }
            else if (marks > 90)
            {
                scholarshipAmount = 0.5 * fees;
            }

            return scholarshipAmount;
        }
    }

    public class Doctor
    {
        private int regnNo;
        private string name;
        private double feesCharged;

        public void SetValues(int regnNo, string name, double fees)
        {
            this.regnNo = regnNo;
            this.name = name;
            this.feesCharged = fees;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Registration Number: {regnNo}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Fees Charged: {feesCharged}");
        }
    }

    class Program
    {
        static void Main()
        {
            // Task 1
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            DisplayNames(firstName, lastName);

            // Task 2
            Console.Write("Enter a string: ");
            string inputString = Console.ReadLine();

            Console.Write("Enter the letter to count: ");
            char letterToCount = char.Parse(Console.ReadLine());

            int count = CountOccurrences(inputString, letterToCount);
            Console.WriteLine($"The letter '{letterToCount}' appears {count} times in the string.");

            // Task 4
            Scholarship scholarship = new Scholarship();

            Console.Write("Enter marks: ");
            int marks = int.Parse(Console.ReadLine());

            Console.Write("Enter fees: ");
            double fees = double.Parse(Console.ReadLine());

            double scholarshipAmount = scholarship.CalculateScholarship(marks, fees);
            Console.WriteLine($"Scholarship Amount: {scholarshipAmount}");

            // Task 5
            Doctor doctor = new Doctor();

            Console.Write("Enter Registration Number: ");
            int regnNo = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Fees Charged: ");
            double doctorFees = double.Parse(Console.ReadLine());

            doctor.SetValues(regnNo, name, doctorFees);
            doctor.DisplayDetails();

            // Banking Task
            try
            {
                // instance of the BankingSystem
                BankingSystem account = new BankingSystem();

                // Testing deposit method
                Console.Write("Enter deposit amount: ");
                decimal depositAmount = decimal.Parse(Console.ReadLine());
                account.Deposit(depositAmount);

                // Testing withdrawal method
                Console.Write("Enter withdrawal amount: ");
                decimal withdrawalAmount = decimal.Parse(Console.ReadLine());
                account.Withdraw(withdrawalAmount);

                // Testing balance check method
                Console.WriteLine($"Current Balance: {account.GetBalance()}");

                // Testing withdrawal with insufficient balance
                Console.Write("Enter withdrawal amount with insufficient balance: ");
                decimal insufficientWithdrawalAmount = decimal.Parse(Console.ReadLine());
                account.Withdraw(insufficientWithdrawalAmount); // throw InsufficientBalanceException
            }
            catch (ArgumentException ex)
            {
                // ArgumentException
                Console.WriteLine($"Argument Exception: {ex.Message}");
            }
            catch (InsufficientBalanceException ex)
            {
                // InsufficientBalanceException
                Console.WriteLine($"Insufficient Balance Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Exception
                Console.WriteLine($"Unhandled Exception: {ex.Message}");
            }
        }

        // Task 1
        static void DisplayNames(string firstName, string lastName)
        {
            Console.WriteLine($"First Name: {firstName.ToUpper()}");
            Console.WriteLine($"Last Name: {lastName.ToUpper()}");
        }

        // Task 2
        static int CountOccurrences(string inputString, char letter)
        {
            int count = 0;

            foreach (char c in inputString)
            {
                if (char.ToUpper(c) == char.ToUpper(letter))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
