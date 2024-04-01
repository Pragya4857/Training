using System;
using System.Data;
using System.Linq;

namespace Assignment_1
{
    class emp
    {
        public static DataTable FetchData()
        {
            DataTable empData = new DataTable();
            empData.Columns.Add("StaffID", typeof(int));
            empData.Columns.Add("First_Name", typeof(string));
            empData.Columns.Add("Last_Name", typeof(string));
            empData.Columns.Add("Position", typeof(string));
            empData.Columns.Add("Birth_Date", typeof(string)); 
            empData.Columns.Add("Joining_Date", typeof(string));
            empData.Columns.Add("City", typeof(string));
            return empData;
        }
    }
    class Homework
    {
        static void Main(string[] args)
        {
            DataTable staffTable = emp.FetchData();

            staffTable.Rows.Add(1001, "Malcolm", "Daruwalla", "Manager", "1984-11-16", "2011-06-08", "Mumbai");
            staffTable.Rows.Add(1002, "Asdin", "Dhalla", "AsstManager", "1984-08-20", "2012-07-07", "Mumbai");
            staffTable.Rows.Add(1003, "Madhavi", "Oza", "Consultant", "1987-11-14", "2015-04-12", "Pune");
            staffTable.Rows.Add(1004, "Saba", "Shaikh", "SE", "1990-06-03", "2016-02-02", "Pune");
            staffTable.Rows.Add(1005, "Nazia", "Shaikh", "SE", "1991-03-08", "2016-02-02", "Mumbai");
            staffTable.Rows.Add(1006, "Amit", "Pathak", "Consultant", "1989-11-07", "2014-08-08", "Chennai");
            staffTable.Rows.Add(1007, "Vijay", "Natrajan", "Consultant", "1989-12-02", "2015-06-01", "Mumbai");
            staffTable.Rows.Add(1008, "Rahul", "Dubey", "Associate", "1993-11-11", "2014-11-06", "Chennai");
            staffTable.Rows.Add(1009, "Suresh", "Mistry", "Associate", "1992-08-12", "2014-12-03", "Chennai");
            staffTable.Rows.Add(1010, "Sumit", "Shah", "Manager", "1991-04-12", "2016-01-02", "Pune");

            // 1. Display a list of all the employees who have joined before 1/1/2015
            Console.WriteLine("1. Employees who joined before 1/1/2015:");
            var beforeJoin = staffTable.AsEnumerable().Where(row => DateTime.Parse(row.Field<string>("Joining_Date")) < DateTime.Parse("2015-01-01"));

            foreach (var employee in beforeJoin)
            {
                Console.WriteLine($"{employee["StaffID"]} - {employee["First_Name"]} {employee["Last_Name"]}({employee["City"]})");
            }

//1001 - Malcolm Daruwalla(Mumbai)
//1002 - Asdin Dhalla(Mumbai)
//1006 - Amit Pathak(Chennai)
//1008 - Rahul Dubey(Chennai)
//1009 - Suresh Mistry(Chennai)

            // 2. Display a list of all the employees whose date of birth is after 1/1/1990.
            Console.WriteLine("2. Employees whose date of birth is after January 1, 1990:");
            var afterDOB = staffTable.AsEnumerable().Where(row => DateTime.Parse(row.Field<string>("Birth_Date")) > new DateTime(1990, 1, 1));

            foreach (var employee in afterDOB)
            {
                Console.WriteLine($"{employee["StaffID"]} - {employee["First_Name"]} {employee["Last_Name"]}({employee["City"]})");
            }
//1004 - Saba Shaikh(Pune)
//1005 - Nazia Shaikh(Mumbai)
//1008 - Rahul Dubey(Chennai)
//1009 - Suresh Mistry(Chennai)
//1010 - Sumit Shah(Pune)

            // 3. Display a list of all the employees whose designation is Consultant and Associate.
            Console.WriteLine("\n3. All employees whose designation is Consultant and Associate:  ");
            var designation = staffTable.AsEnumerable().Where(row => row.Field<string>("Position") == "Associate" || row.Field<string>("Position") == "Consultant");

            foreach (var employee in designation)
            {
                Console.WriteLine($"{employee["First_Name"]} {employee["Last_Name"]}");
            }
//Madhavi Oza
//Amit Pathak
//Vijay Natrajan
//Rahul Dubey
//Suresh Mistry


            // 4. Display total number of employees
            int total = staffTable.Rows.Count;
            Console.WriteLine($"\n4. Total number of employees: {total}");
            //Total number of employees: 10
            // 5. Display total number of employees belonging to “Chennai”
            int totalChennai = staffTable.AsEnumerable().Count(row => row.Field<string>("City") == "Chennai");
            Console.WriteLine($"\n5. Total number of employees belonging to Chennai: {totalChennai}");
            //Total number of employees belonging to Chennai: 3

            // 6. Display highest employee id from the list
            int maxID = staffTable.AsEnumerable().Max(row => row.Field<int>("StaffID"));
            Console.WriteLine($"\n6. Highest Staff ID: {maxID}");
            //Highest Staff ID: 1010

            // 7. Display total number of employee who have joined after 1/1/2015.
            int afterJoin = staffTable.AsEnumerable().Count(row => DateTime.Parse(row.Field<string>("Joining_Date")) > DateTime.Parse("2015-01-01"));
            Console.WriteLine($"\n7. Total number of employees who joined after 1/1/2015: {afterJoin}");
            //Total number of employees who joined after 1/1/2015: 5

            // 8. Display total number of employees whose designation is not “Associate”.
            int notAssociate = staffTable.AsEnumerable().Count(row => row.Field<string>("Position") != "Associate");
            Console.WriteLine($"\n8. Total number of employees whose designation is not Associate: {notAssociate}");
            // Total number of employees whose designation is not Associate: 8

            // 9. Display total number of employees based on City.
            var employeeCity = staffTable.AsEnumerable().GroupBy(row => row.Field<string>("City"));
            Console.WriteLine("\n9. Total number of employees based on City:");
            foreach (var cityGroup in employeeCity)
            {
                string city = cityGroup.Key;
                int count = cityGroup.Count();
                Console.WriteLine($"{city}: {count}");
            }
        //Total number of employees based on City:Mumbai: 4,Pune: 3,Chennai: 3
            // 10. Display total number of employees based on city and title.
            var empWithTitleCounts = staffTable.AsEnumerable().GroupBy(row => new { City = row.Field<string>("City"), Title = row.Field<string>("Position") })
                                      .Select(group => $"{group.Key.City} - {group.Key.Title}: {group.Count()}");

            Console.WriteLine("\n10. Total number of employees based on city and title");
            foreach (var count in empWithTitleCounts)
            {
                Console.WriteLine(count);
            }
            //Total number of employees based on city and title
//Mumbai - Manager: 1
//Mumbai - AsstManager: 1
//Pune - Consultant: 1
//Pune - SE: 1
//Mumbai - SE: 1
//Chennai - Consultant: 1
//Mumbai - Consultant: 1
//Chennai - Associate: 2
//Pune - Manager: 1

            // 11. Display total number of employee who is youngest in the list
            var getDOB = staffTable.AsEnumerable().Min(row => DateTime.Parse(row.Field<string>("Birth_Date")));
            var youngEmployee = staffTable.AsEnumerable().Where(row => DateTime.Parse(row.Field<string>("Birth_Date")) == getDOB);

            int totCount = staffTable.AsEnumerable().Count(row => DateTime.Parse(row.Field<string>("Birth_Date")) == getDOB);

            Console.WriteLine($"\n11. Total number of employees who are youngest in the list: {totCount}");
            
            //Total number of employees who are youngest in the list: 1
            //Asdin Dhalla

            Console.ReadLine();
        }
    }
}
