using System;

namespace Task2
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Choose an operation:");//made this coz there are three operation in parallel we can choose whatever we want to perform/operate
            Console.WriteLine("1. Remove character at a given position");
            Console.WriteLine("2. Exchange first and last characters");
            Console.WriteLine("3. Find the largest number among three integers");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter a string:");
                        string inputString1 = Console.ReadLine();

                        Console.WriteLine("Enter the position to remove (0 to string length - 1):");
                        if (int.TryParse(Console.ReadLine(), out int position1))
                        {
                            string result1 = RemoveCharacterAtPosition(inputString1, position1);
                            Console.WriteLine("Result: " + result1);
                        }
                        else
                        {
                            Console.WriteLine("Invalid position. Please enter a valid integer.");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter a string:");
                        string inputString2 = Console.ReadLine();

                        string result2 = ExchangeFirstAndLastCharacters(inputString2);
                        Console.WriteLine("Result: " + result2);
                        break;

                    case 3:
                        Console.WriteLine("Enter three integers (comma-separated):");

                        string[] input = Console.ReadLine().Split(',');

                        if (input.Length == 3 &&
                            int.TryParse(input[0], out int num1) &&
                            int.TryParse(input[1], out int num2) &&
                            int.TryParse(input[2], out int num3))
                        {
                            int result3 = FindLargestNumber(num1, num2, num3);
                            Console.WriteLine("Largest Number: " + result3);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter three integers separated by commas.");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please choose a valid operation.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a valid integer.");
            }
        }
//first fun call
        static string RemoveCharacterAtPosition(string input, int position)
        {
            if (position < 0 || position >= input.Length)
            {
                Console.WriteLine("Invalid position");
                return input;
            }

            string result = input.Remove(position, 1);
            return result;
        }
//second fun call
        static string ExchangeFirstAndLastCharacters(string input)
        {
            if (input.Length < 2)
            {
                Console.WriteLine("String should have at least two characters");
                return input;
            }

            char[] charArray = input.ToCharArray();
            char firstChar = charArray[0];
            charArray[0] = charArray[input.Length - 1];
            charArray[input.Length - 1] = firstChar;

            string result = new string(charArray);
            return result;
        }
//third fun call
        static int FindLargestNumber(int a, int b, int c)
{
    if (a >= b && a >= c)
    {
        return a;
    }
    else if (b >= a && b >= c)
    {
        return b;
    }
    else
    {
        return c;
    }
}
