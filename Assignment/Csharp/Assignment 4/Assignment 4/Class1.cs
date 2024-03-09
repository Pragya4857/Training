

using System;

namespace Assignment4
{
    public class TicketConcession
    {
        public const double TotalFareConstant = 500;

        public string Name { get; set; }
        public int Age { get; set; }

        public void CalculateConcession()
        {
            if (Age <= 5)
            {
                Console.WriteLine($"Little Champs - Free Ticket for {Name} ({Age} years old)");
            }
            else if (Age > 60)
            {
                double concessionPercentage = 0.3;
                double concessionAmount = concessionPercentage * TotalFareConstant;
                double discountedFare = TotalFareConstant - concessionAmount;
                Console.WriteLine($"Senior Citizen - {discountedFare:C} for {Name} ({Age} years old)");
            }
            else
            {
                Console.WriteLine($"Ticket Booked - {TotalFareConstant:C} for {Name} ({Age} years old)");
            }
        }
    }
}
