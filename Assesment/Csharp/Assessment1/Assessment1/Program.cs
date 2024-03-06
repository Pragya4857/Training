using System;

namespace Assessment1 //6th March 2024
{
    abstract class Student
    {
        public string Name { get; set; }
        public int StudentId { get; set; }
        public double Grade { get; set; }

        public Student(string name, int studentId, double grade)
        {
            Name = name;
            StudentId = studentId;
            Grade = grade;
        }

        public abstract bool IsPassed(double grade);
    }

    class UG : Student
    {
        public UG(string name, int studentId, double grade) : base(name, studentId, grade)
        {
        }

        public override bool IsPassed(double grade)
        {
            return grade > 70.0;
        }
    }

    class Graduate : Student
    {
        public Graduate(string name, int studentId, double grade) : base(name, studentId, grade)
        {
        }

        public override bool IsPassed(double grade)
        {
            return grade > 80.0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // test ug class
            UG undergrad = CreateUG();
            Console.WriteLine($"Undergraduate Passed: {undergrad.IsPassed(undergrad.Grade)}");

            // test graduate class
            Graduate grad = CreateGraduate();
            Console.WriteLine($"Graduate Passed: {grad.IsPassed(grad.Grade)}");

            // test productsorter class
            ProductSorter.SortAndPresentProducts();
        }

        static UG CreateUG()
        {
            Console.WriteLine("Enter Undergraduate details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Student ID: ");
            int studentId = int.Parse(Console.ReadLine());
            Console.Write("Grade: ");
            double grade = double.Parse(Console.ReadLine());

            return new UG(name, studentId, grade);
        }

        static Graduate CreateGraduate()
        {
            Console.WriteLine("Enter Graduate details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Student ID: ");
            int studentId = int.Parse(Console.ReadLine());
            Console.Write("Grade: ");
            double grade = double.Parse(Console.ReadLine());

            return new Graduate(name, studentId, grade);
        }
    }

    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        public Product(int productId, string productName, double price)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
        }
    }

    class ProductSorter
    {
        public static void SortAndPresentProducts()
        {
            Product[] products = new Product[10];

            Console.WriteLine("Enter details for 10 products:");
            for (int i = 0; i < products.Length; i++)
            {
                Console.Write($"Product {i + 1} - ID: ");
                int productId = int.Parse(Console.ReadLine());
                Console.Write($"Product {i + 1} - Name: ");
                string productName = Console.ReadLine();
                Console.Write($"Product {i + 1} - Price: ");
                double price = double.Parse(Console.ReadLine());

                products[i] = new Product(productId, productName, price);
            }

            
            for (int i = 0; i < products.Length - 1; i++)//here I've used bubble sorting
            {
                for (int j = 0; j < products.Length - 1 - i; j++)
                {
                    if (products[j].Price > products[j + 1].Price)
                    {
                        Product temp = products[j];
                        products[j] = products[j + 1];
                        products[j + 1] = temp;
                    }
                }
            }

            // displaying the sorted products
            Console.WriteLine("Sorted Products based on Price:");
            foreach (Product product in products)
            {
                Console.WriteLine($"Product ID: {product.ProductId}, Name: {product.ProductName}, Price: {product.Price}");
            }
        }
    }
}
