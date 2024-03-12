//Assignment4App/Program.cs

using Assignment4;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
  
        Console.WriteLine("Enter passenger details:");
        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Age: ");
        int age = GetUserInput<int>();

      
        TicketConcession passenger = new TicketConcession
        {
            Name = name,
            Age = age
        };

       
        passenger.CalculateConcession();

        // Lambda Queries
        Console.WriteLine("\nLambda Query: Numbers and their squares greater than 20");
        List<int> numbers = GetNumbersFromUser();
        var squaresGreaterThan20 = numbers.Select(x => x * x).Where(x => x > 20);

        // Display message and results
        Console.WriteLine("Numbers and their squares greater than 20:");
        Console.WriteLine(string.Join(",", squaresGreaterThan20));

        Console.WriteLine("\nLambda Query: Words starting with 'a' and ending with 'm'");
        List<string> words = GetWordsFromUser();
        var wordsStartingWithAAndEndingWithM = words.Where(word =>
            word.StartsWith("a", StringComparison.OrdinalIgnoreCase) &&
            word.EndsWith("m", StringComparison.OrdinalIgnoreCase));

        Console.WriteLine(string.Join(",", wordsStartingWithAAndEndingWithM));
    }

    static T GetUserInput<T>()
    {
        Console.Write("Enter value: ");
        string input = Console.ReadLine();

        try
        {
            return (T)Convert.ChangeType(input, typeof(T));
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid value.");
        }

        return default(T);
    }

    static List<int> GetNumbersFromUser()
    {
        Console.WriteLine("Enter numbers for Lambda Query (comma-separated): ");
        string input = Console.ReadLine();
        return input.Split(',').Select(int.Parse).ToList();
    }

    static List<string> GetWordsFromUser()
    {
        Console.WriteLine("Enter words for Lambda Query (comma-separated): ");
        string input = Console.ReadLine();
        return input.Split(',').Select(word => word.Trim()).ToList();
    }
}
