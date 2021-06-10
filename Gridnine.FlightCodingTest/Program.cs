using System;
using System.Collections.Generic;
using System.Linq;

namespace Gridnine.FlightCodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            FlightBuilder flightBuilder = new FlightBuilder();
            IList<Flight> flightAll = flightBuilder.GetFlights();

            Filter filter = new Filter(flightAll);
            DateTime date = new DateTime(2021, 6, 13, 14, 5, 0);
           
            Console.WriteLine("Вылеты после определенного времени");
            Console.WriteLine();
            filter.PrintFlight(filter.DeparturesBeforeTime(date));
            Console.WriteLine();
            Console.WriteLine("Вылеты исключающие, где дата прилёта раньше даты вылета");
            Console.WriteLine();
            filter.PrintFlight(filter.ArrivalDateBeforeDepartureDate());
            Console.WriteLine();
            Console.WriteLine("Проведенное время на земле между полетами не больше двух часов");
            Console.WriteLine();
            filter.PrintFlight(filter.BreakBetweenPlanes());
            Console.WriteLine();
        }
    }
}
