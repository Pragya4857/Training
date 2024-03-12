using System;

namespace Assignment5
{
    // Question 1: Books class
    public class Books
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        public Books(string bookName, string authorName)
        {
            BookName = bookName;
            AuthorName = authorName;
        }

        public void Display()
        {
            Console.WriteLine($"Book: {BookName}, Author: {AuthorName}");
        }
    }

    // Question 1: BookShelf class
    public class BookShelf
    {
        private Books[] books = new Books[5];

        public Books this[int index]
        {
            get { return books[index]; }
            set { books[index] = value; }
        }
    }

    // Question 2: Box class
    public class Box
    {
        public double Length { get; set; }
        public double Breadth { get; set; }

        public static Box Add(Box box1, Box box2)
        {
            Box resultBox = new Box
            {
                Length = box1.Length + box2.Length,
                Breadth = box1.Breadth + box2.Breadth
            };
            return resultBox;
        }

        public void Display()
        {
            Console.WriteLine($"Box - Length: {Length}, Breadth: {Breadth}");
        }
    }

    // Remaining classes: Employee, ParttimeEmployee, IStudent, Dayscholar, Resident

    public class Employee
    {
        public int Empid { get; set; }
        public string Empname { get; set; }
        public float Salary { get; set; }

        public Employee(int empid, string empname, float salary)
        {
            Empid = empid;
            Empname = empname;
            Salary = salary;
        }

        public void Display()
        {
            Console.WriteLine($"Employee - Empid: {Empid}, Empname: {Empname}, Salary: {Salary}");
        }
    }

    public class ParttimeEmployee : Employee
    {
        public float Wages { get; set; }

        public ParttimeEmployee(int empid, string empname, float salary, float wages)
            : base(empid, empname, salary)
        {
            Wages = wages;
        }

        public new void Display()
        {
            base.Display();
            Console.WriteLine($"Part-time Employee - Wages: {Wages}");
        }
    }

    public interface IStudent
    {
        int StudentId { get; set; }
        string Name { get; set; }

        void ShowDetails();
    }

    public class Dayscholar : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        public void ShowDetails()
        {
            Console.WriteLine($"Dayscholar - StudentId: {StudentId}, Name: {Name}");
        }
    }

    public class Resident : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        public void ShowDetails()
        {
            Console.WriteLine($"Resident - StudentId: {StudentId}, Name: {Name}");
        }
    }

    // Main test class
    public class TestStudents
    {
        public static void Main()
        {
            
            Dayscholar dayscholarStudent = CreateDayscholar();
            Resident residentStudent = CreateResident();

           
            Console.WriteLine("\nStudent Details:");
            dayscholarStudent.ShowDetails();
            residentStudent.ShowDetails();
            
            Console.WriteLine("\nBook Details:");
            BookShelf bookShelf = CreateBookShelf();
            DisplayBooks(bookShelf);

           
            Console.WriteLine("\nEmployee Details:");
            Employee fullTimeEmployee = CreateFullTimeEmployee();
            ParttimeEmployee partTimeEmployee = CreatePartTimeEmployee();
            fullTimeEmployee.Display();
            partTimeEmployee.Display();

           
            Console.WriteLine("\nBox Details:");
            Box box1 = CreateBox();
            Box box2 = CreateBox();
            Box resultBox = Box.Add(box1, box2);
            resultBox.Display();
        }

        // Helper methods for creating objects

        private static Dayscholar CreateDayscholar()
        {
            Console.WriteLine("Enter details for Dayscholar:");
            Console.Write("StudentId: ");
            int studentId = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();

            return new Dayscholar { StudentId = studentId, Name = name };
        }

        private static Resident CreateResident()
        {
            Console.WriteLine("\nEnter details for Resident:");
            Console.Write("StudentId: ");
            int studentId = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();

            return new Resident { StudentId = studentId, Name = name };
        }

        private static BookShelf CreateBookShelf()
        {
            BookShelf bookShelf = new BookShelf();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Enter details for Book {i + 1}:");
                Console.Write("Book Name: ");
                string bookName = Console.ReadLine();

                Console.Write("Author Name: ");
                string authorName = Console.ReadLine();

                Books book = new Books(bookName, authorName);
                bookShelf[i] = book;
            }

            return bookShelf;
        }

        private static void DisplayBooks(BookShelf bookShelf)
        {
            Console.WriteLine("\nBook details on the Bookshelf:");
            for (int i = 0; i < 5; i++)
            {
                bookShelf[i].Display();
            }
        }

        private static Employee CreateFullTimeEmployee()
        {
            Console.WriteLine("\nEnter details for Full-time Employee:");
            Console.Write("Empid: ");
            int fullTimeEmpid = int.Parse(Console.ReadLine());

            Console.Write("Empname: ");
            string fullTimeEmpname = Console.ReadLine();

            Console.Write("Salary: ");
            float fullTimeSalary = float.Parse(Console.ReadLine());

            return new Employee(fullTimeEmpid, fullTimeEmpname, fullTimeSalary);
        }

        private static ParttimeEmployee CreatePartTimeEmployee()
        {
            Console.WriteLine("\nEnter details for Part-time Employee:");
            Console.Write("Empid: ");
            int partTimeEmpid = int.Parse(Console.ReadLine());

            Console.Write("Empname: ");
            string partTimeEmpname = Console.ReadLine();

            Console.Write("Salary: ");
            float partTimeSalary = float.Parse(Console.ReadLine());

            Console.Write("Wages: ");
            float partTimeWages = float.Parse(Console.ReadLine());

            return new ParttimeEmployee(partTimeEmpid, partTimeEmpname, partTimeSalary, partTimeWages);
        }

        private static Box CreateBox()
        {
            Console.WriteLine("\nEnter details for Box:");
            Console.Write("Length: ");
            double length = double.Parse(Console.ReadLine());

            Console.Write("Breadth: ");
            double breadth = double.Parse(Console.ReadLine());

            return new Box { Length = length, Breadth = breadth };
        }
    }
}
