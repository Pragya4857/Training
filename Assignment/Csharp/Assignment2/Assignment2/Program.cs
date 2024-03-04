using System;

class Accounts
{
    public int AccountNo { get; set; }
    public string CustomerName { get; set; }
    public string AccountType { get; set; }
    public char TransactionType { get; set; }
    public double Amount { get; set; }
    public double Balance { get; set; }

    public Accounts(int accountNo, string customerName, string accountType, char transactionType, double amount)
    {
        AccountNo = accountNo;
        CustomerName = customerName;
        AccountType = accountType;
        TransactionType = transactionType;
        Amount = amount;
        Balance = 500; // I've set initial balance to 500
        UpdateBalance();
    }

    public void Credit(double amount)
    {
        Balance += amount;
    }

    public void Debit(double amount)
    {
        if (amount > Balance)
        {
            Console.WriteLine("Insufficient funds. Withdrawal not allowed.");
        }
        else
        {
            Balance -= amount;
        }
    }

    private void UpdateBalance()
    {
        if (char.ToUpper(TransactionType) == 'D')
        {
            Credit(Amount);
        }
        else if (char.ToUpper(TransactionType) == 'W')
        {
            Debit(Amount);
        }
    }

    public void ShowData()
    {
        Console.WriteLine(new string('-', 40));
        Console.WriteLine($"Account No: {AccountNo}");
        Console.WriteLine($"Customer Name: {CustomerName}");
        Console.WriteLine($"Account Type: {AccountType}");
        Console.WriteLine($"Transaction Type: {TransactionType}");
        Console.WriteLine($"Amount: {Amount}");
        Console.WriteLine($"Balance: {Balance}");
    }
}

class Student
{
    public int RollNo { get; set; }
    public string Name { get; set; }
    public string Class { get; set; }
    public string Semester { get; set; }
    public string Branch { get; set; }
    public int[] Marks { get; set; }

    public Student(int rollNo, string name, string studentClass, string semester, string branch)
    {
        RollNo = rollNo;
        Name = name;
        Class = studentClass;
        Semester = semester;
        Branch = branch;
        Marks = new int[5];
    }

    public void GetMarks()
    {
        Console.WriteLine($"Enter marks for {Name} (Roll No: {RollNo}) in 5 subjects:");
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Subject {i + 1}: ");
            Marks[i] = Convert.ToInt32(Console.ReadLine());
        }
    }

    public void DisplayResult()
    {
        int totalMarks = 0;
        foreach (var mark in Marks)
        {
            totalMarks += mark;
            if (mark < 35)
            {
                Console.WriteLine("Result: Failed (Marks in one or more subjects are less than 35)");
                return;
            }
        }

        double average = totalMarks / 5.0;

        if (average < 50)
        {
            Console.WriteLine("Result: Failed (Average marks are less than 50)");
        }
        else
        {
            Console.WriteLine("Result: Passed");
        }
    }

    public void DisplayData()
    {
        Console.WriteLine(new string('-', 40));
        Console.WriteLine($"Roll No: {RollNo}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Class: {Class}");
        Console.WriteLine($"Semester: {Semester}");
        Console.WriteLine($"Branch: {Branch}");
        Console.WriteLine($"Marks: {string.Join(", ", Marks)}");
    }
}

class Saledetails
{
    public int SalesNo { get; set; }
    public int ProductNo { get; set; }
    public double Price { get; set; }
    public DateTime DateOfSale { get; set; }
    public int Qty { get; set; }
    public double TotalAmount { get; set; }

    public Saledetails(int salesNo, int productNo, double price, DateTime dateOfSale, int qty)
    {
        SalesNo = salesNo;
        ProductNo = productNo;
        Price = price;
        DateOfSale = dateOfSale;
        Qty = qty;
        Sales();
    }

    public void Sales()
    {
        TotalAmount = Qty * Price;
    }

    public void ShowData()
    {
        Console.WriteLine(new string('-', 40));
        Console.WriteLine($"Sales No: {SalesNo}");
        Console.WriteLine($"Product No: {ProductNo}");
        Console.WriteLine($"Price: {Price}");
        Console.WriteLine($"Date of Sale: {DateOfSale}");
        Console.WriteLine($"Qty: {Qty}");
        Console.WriteLine($"Total Amount: {TotalAmount}");
    }
}

class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
    public string City { get; set; }

    // Constructor with no arguments
    public Customer()
    {
    }

    public Customer(int customerId, string name, int age, string phone, string city)
    {
        CustomerId = customerId;
        Name = name;
        Age = age;
        Phone = phone;
        City = city;
    }
//destructor
    ~Customer()
    {
        Console.WriteLine($"Destructor called for Customer {Name}");
    }

    public void DisplayCustomer()
    {
        Console.WriteLine($"Customer ID: {CustomerId}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Phone: {Phone}");
        Console.WriteLine($"City: {City}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter details for Account:");

        Console.Write("Account No: ");
        int accountNo = Convert.ToInt32(Console.ReadLine());

        Console.Write("Customer Name: ");
        string customerName = Console.ReadLine();

        Console.Write("Account Type: ");
        string accountType = Console.ReadLine();

        Console.Write("Transaction Type (D/W): ");
        char transactionType = Convert.ToChar(Console.ReadLine());

        Console.Write("Amount: ");
        double amount = Convert.ToDouble(Console.ReadLine());

        Accounts account = new Accounts(accountNo, customerName, accountType, transactionType, amount);

        account.ShowData();
        Console.WriteLine(new string('-', 40));

        // Student class
        Console.WriteLine("Enter details for Student:");
        Console.Write("Roll No: ");
        int rollNo = Convert.ToInt32(Console.ReadLine());
        Console.Write("Student Name: ");
        string studentName = Console.ReadLine(); 
        Console.Write("Class: ");
        string studentClass = Console.ReadLine();
        Console.Write("Semester: ");
        string semester = Console.ReadLine();
        Console.Write("Branch: ");
        string branch = Console.ReadLine();

        Student student = new Student(rollNo, studentName, studentClass, semester, branch);
        student.GetMarks();
        student.DisplayResult();
        student.DisplayData();
        Console.WriteLine(new string('-', 40));

        // Saledetails class
        Console.WriteLine("Enter details for Sale:");
        Console.Write("Sales No: ");
        int salesNo = Convert.ToInt32(Console.ReadLine());
        Console.Write("Product No: ");
        int productNo = Convert.ToInt32(Console.ReadLine());
        Console.Write("Price: ");
        double price = Convert.ToDouble(Console.ReadLine());
        Console.Write("Quantity: ");
        int qty = Convert.ToInt32(Console.ReadLine());

        Saledetails sale = new Saledetails(salesNo, productNo, price, DateTime.Now, qty);
        sale.ShowData();
        Console.WriteLine(new string('-', 40));

        // Customer class
        Console.WriteLine("Enter customer information:");

        Console.Write("Customer ID: ");
        int customerId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Customer Name: ");
        string customerNameInput = Console.ReadLine();

        Console.Write("Age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        Console.Write("Phone: ");
        string phone = Console.ReadLine();

        Console.Write("City: ");
        string city = Console.ReadLine();

        Customer cust = new Customer(customerId, customerNameInput, age, phone, city);

        cust.DisplayCustomer();
    }
}
