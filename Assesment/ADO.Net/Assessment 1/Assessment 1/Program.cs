using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Server=ICS-LT-4P2X7G3\\SQLEXPRESS;Database=EmployeeeEngagement;Integrated Security=True;";

        Console.WriteLine("Enter employee name:");
        string empName = Console.ReadLine();

        Console.WriteLine("Enter employee salary:");
        decimal empSal = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Enter employee type (P or C):");
        string empType = Console.ReadLine().ToUpper();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("AddEmployee", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@EName", empName);
            command.Parameters.AddWithValue("@ESal", empSal);
            command.Parameters.AddWithValue("@EType", empType);

            command.ExecuteNonQuery();

            // Display all employee rows with design
            Console.WriteLine("\nAll employee rows:");

            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("| Employee ID |   Name         |   Salary  |   Type   |");
            Console.WriteLine("-----------------------------------------------------------");

            SqlCommand selectCommand = new SqlCommand("SELECT * FROM EDetails", connection);
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"| {reader["Eno"],-12} | {reader["EName"],-15} | {reader["ESal"],-9} | {reader["EType"],-8} |");
            }

            Console.WriteLine("-----------------------------------------------------------");
            reader.Close();
            connection.Close();
        }

        Console.WriteLine("\nEmployee details inserted successfully and displayed.");
        Console.Read();
    }
}
