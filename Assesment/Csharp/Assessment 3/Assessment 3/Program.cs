using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//14/03/2024

public delegate int Calculator(int num1, int num2);

class Employee
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
    public string DOB { get; set; } 
    public string DOJ { get; set; }
    public string City { get; set; }
}

class Program
{
    static void Main()
    {
        //have to created this Because I'm only using one program.cs so thru below options we can select whatever operation we want to perform
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Append text to a file");//ques 1
        Console.WriteLine("2. Perform calculator functionalities");//ques 2
        Console.WriteLine("3. Execute LINQ queries on employee data");//ques 3
        Console.Write("Enter your choice (1, 2, or 3): ");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                AppendText();
                break;
            case 2:
                PerformCalculator();
                break;
            case 3:
                LINQQueries();
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }

    static void AppendText()
    {
        Console.WriteLine("Enter the file name with extension:");
        string fileName = Console.ReadLine();

        Console.WriteLine("Enter the text to append:");
        string textToAppend = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(textToAppend);
            }

            Console.WriteLine("Text appended to the file successfully.");

 // we can check the changes in bin/debug folder
            Console.WriteLine($"Contents of {fileName} after appending:");
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    static void PerformCalculator()
    {
        int num1, num2;

        Console.WriteLine("Enter the first number:");
        num1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the second number:");
        num2 = Convert.ToInt32(Console.ReadLine());

        Calculator addition = (x, y) => x + y;
        Calculator subtraction = (x, y) => x - y;
        Calculator multiplication = (x, y) => x * y;

        Console.WriteLine($"Addition: {addition(num1, num2)}");
        Console.WriteLine($"Subtraction: {subtraction(num1, num2)}");
        Console.WriteLine($"Multiplication: {multiplication(num1, num2)}");
    }

    static void LINQQueries()
    {
        
        List<Employee> empList = new List<Employee>
        {
           new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = "16/11/1984", DOJ = "8/6/2011", City = "Mumbai" },
            new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = "20/08/1984", DOJ = "7/7/2012", City = "Mumbai" },
            new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = "14/11/1987", DOJ = "12/4/2015", City = "Pune" },
            new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = "3/6/1990", DOJ = "2/2/2016", City = "Pune" },
            new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = "8/3/1991", DOJ = "2/2/2016", City = "Mumbai" },
            new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = "7/11/1989", DOJ = "8/8/2014", City = "Chennai" },
            new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = "2/12/1989", DOJ = "1/6/2015", City = "Mumbai" },
            new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = "11/11/1993", DOJ = "6/11/2014", City = "Chennai" },
            new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = "12/8/1992", DOJ = "3/12/2014", City = "Chennai" },
            new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = "12/4/1991", DOJ = "2/1/2016", City = "Pune" }
        };

        // LINQ queries

        // a. Display detail of all the employees
        Console.WriteLine("a. Displaying detail of all the employees:");
        foreach (var emp in empList)
        {
            Console.WriteLine($"EmployeeID: {emp.EmployeeID}, FirstName: {emp.FirstName}, LastName: {emp.LastName}, Title: {emp.Title}, DOB: {emp.DOB}, DOJ: {emp.DOJ}, City: {emp.City}");
        }

        // b. Display details of all the employees whose location is not Mumbai
        Console.WriteLine("\nb. Displaying details of all the employees whose location is not Mumbai:");
        var employeesNotInMumbai = empList.Where(emp => emp.City != "Mumbai");
        foreach (var emp in employeesNotInMumbai)
        {
            Console.WriteLine($"EmployeeID: {emp.EmployeeID}, FirstName: {emp.FirstName}, LastName: {emp.LastName}, Title: {emp.Title}, DOB: {emp.DOB}, DOJ: {emp.DOJ}, City: {emp.City}");
        }

        // c. Display details of all the employees whose title is AsstManager
        Console.WriteLine("\nc. Displaying details of all the employees whose title is AsstManager:");
        var asstManagers = empList.Where(emp => emp.Title == "AsstManager");
        foreach (var emp in asstManagers)
        {
            Console.WriteLine($"EmployeeID: {emp.EmployeeID}, FirstName: {emp.FirstName}, LastName: {emp.LastName}, Title: {emp.Title}, DOB: {emp.DOB}, DOJ: {emp.DOJ}, City: {emp.City}");
        }

        // d. Display details of all the employees whose Last Name start with S
        Console.WriteLine("\nd. Displaying details of all the employees whose Last Name start with S:");
        var employeesWithSLastName = empList.Where(emp => emp.LastName.StartsWith("S"));
        foreach (var emp in employeesWithSLastName)
        {
            Console.WriteLine($"EmployeeID: {emp.EmployeeID}, FirstName: {emp.FirstName}, LastName: {emp.LastName}, Title: {emp.Title}, DOB: {emp.DOB}, DOJ: {emp.DOJ}, City: {emp.City}");
        }
    }
}
//we can also use "DateTime" built-in struct for representing date and time. this has also various methods and properties.