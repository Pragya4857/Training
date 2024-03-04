using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Answer 1
        Console.Write("Input 1st number: ");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Input 2nd number: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        if (num1 == num2)
        {
            Console.WriteLine($"{num1} and {num2} are equal");
        }
        else
        {
            Console.WriteLine($"{num1} and {num2} are not equal");
        }

        // Answer 2
        Console.Write("Enter a number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        if (num > 0)
        {
            Console.WriteLine($"{num} is a positive number");
        }
        else if (num < 0)
        {
            Console.WriteLine($"{num} is a negative number");
        }
        else
        {
            Console.WriteLine($"{num} is zero");
        }

        // Answer 3
        Console.Write("Input first number: ");
        double n1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Input operation (+, -, *, /): ");
        char operation = Convert.ToChar(Console.ReadLine());

        Console.Write("Input second number: ");
        double n2 = Convert.ToDouble(Console.ReadLine());

        double result = 0;

        switch (operation)
        {
            case '+':
                result = n1 + n2;
                break;
            case '-':
                result = n1 - n2;
                break;
            case '*':
                result = n1 * n2;
                break;
            case '/':
                if (n2 != 0)
                {
                    result = n1 / n2;
                }
                else
                {
                    Console.WriteLine("Error: Division by zero is not allowed.");
                    return;
                }
                break;
            default:
                Console.WriteLine("Error: Invalid operation");
                return;
        }

        Console.WriteLine($"{n1} {operation} {n2} = {result}");

        // Answer 4
        Console.Write("Enter the number: ");
        int numTable = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Multiplication table of {numTable}:");
        for (int i = 0; i <= 10; i++)
        {
            int tableResult = numTable * i;
            Console.WriteLine($"{numTable} * {i} = {tableResult}");
        }

        // Answer 5
        Console.Write("Enter the first integer: ");
        int num3 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the second integer: ");
        int num4 = Convert.ToInt32(Console.ReadLine());

        int sum = num3 + num4;

        if (num3 == num4)
        {
            int result5 = 3 * sum;
            Console.WriteLine($"The values are the same. Triple of their sum: {result5}");
        }
        else
        {
            Console.WriteLine($"Sum of the two integers: {sum}");
        }

        // Answer 6
        Console.Write("Enter the day number: ");
        int dayNumber = Convert.ToInt32(Console.ReadLine());

        switch (dayNumber)
        {
            case 1:
                Console.WriteLine("Sunday");
                break;
            case 2:
                Console.WriteLine("Monday");
                break;
            case 3:
                Console.WriteLine("Tuesday");
                break;
            case 4:
                Console.WriteLine("Wednesday");
                break;
            case 5:
                Console.WriteLine("Thursday");
                break;
            case 6:
                Console.WriteLine("Friday");
                break;
            case 7:
                Console.WriteLine("Saturday");
                break;
            default:
                Console.WriteLine("Invalid day number. Please enter a number between 1 and 7.");
                break;
        }

        // Arrays
        int[] numbers = new int[] { 5, 8, 3, 2, 7 };

        double average = numbers.Average();
        int minimum = numbers.Min();
        int maximum = numbers.Max();

        Console.WriteLine($"Average: {average}");
        Console.WriteLine($"Minimum: {minimum}");
        Console.WriteLine($"Maximum: {maximum}");

        const int NumberOfMarks = 10;
        int[] marks = new int[NumberOfMarks];

        Console.WriteLine($"Enter {NumberOfMarks} marks:");

        for (int i = 0; i < NumberOfMarks; i++)
        {
            Console.Write($"Enter mark {i + 1}: ");
            marks[i] = Convert.ToInt32(Console.ReadLine());
        }

        int total = 0;
        foreach (int mark in marks)
        {
            total += mark;
        }

        double averageMarks = (double)total / NumberOfMarks;

        int minimumMarks = marks.Min();
        int maximumMarks = marks.Max();

        Console.WriteLine($"Total marks: {total}");
        Console.WriteLine($"Average marks: {averageMarks:F2}");
        Console.WriteLine($"Minimum marks: {minimumMarks}");
        Console.WriteLine($"Maximum marks: {maximumMarks}");

        Array.Sort(marks);
        Console.WriteLine("Marks in ascending order:");
        foreach (int mark in marks)
        {
            Console.Write($"{mark} ");
        }
        Console.WriteLine();

        Array.Reverse(marks);
        Console.WriteLine("Marks in descending order:");
        foreach (int mark in marks)
        {
            Console.Write($"{mark} ");
        }

        // String Assignment 1
        Console.Write("Enter a word: ");
        string word = Console.ReadLine();

        int length = GetWordLength(word);
        Console.WriteLine($"Length of the word: {length}");

        // String Assignment 2
        Console.Write("Enter a name: ");
        string name = Console.ReadLine();

        string reversedWord = GetReverseWord(name);
        Console.WriteLine($"Reverse of the name: {reversedWord}");

        // String Assignment 3
        Console.Write("Enter the first word: ");
        string word1 = Console.ReadLine();

        Console.Write("Enter the second word: ");
        string word2 = Console.ReadLine();

        if (AreWordsEqual(word1, word2))
        {
            Console.WriteLine("The two words are the same.");
        }
        else
        {
            Console.WriteLine("The two words are different.");
        }
    }

    // String Assignment 1 Func
    static int GetWordLength(string input)
    {
        return input.Length;
    }

    // String Assignment 2 Func
    static string GetReverseWord(string input)
    {
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    // String Assignment 3 Func
    static bool AreWordsEqual(string input1, string input2)
    {
        return input1.Equals(input2, StringComparison.OrdinalIgnoreCase);
    }
}
