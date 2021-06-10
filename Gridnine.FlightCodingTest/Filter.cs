using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Gridnine.FlightCodingTest
{
    public class Filter
    {
        IList<Flight> flightAll;

        public Filter(IList<Flight> flightAll)
        {
            this.flightAll = flightAll;
        }

        public IList<Flight> DeparturesBeforeTime(DateTime date)
        {
            var departures = flightAll.Where(x => x.Segments[0].DepartureDate >= date).ToList();
            return departures;
        }

        public IList<Flight> ArrivalDateBeforeDepartureDate()
        {
            List<Flight> flights = new List<Flight>();
            List<Segment> segments = new List<Segment>();

            foreach (var item1 in flightAll)
            {
                flights.Add(item1);
                
                foreach (var item in item1.Segments)
                {
                    if (item.ArrivalDate.CompareTo(item.DepartureDate) > 0)
                    {
                        segments.Add(item);
                    }
                    else
                    {
                        flights.Remove(item1);
                        break;
                    }
                }
            }
             return flights;

        }

        public IList<Flight> BreakBetweenPlanes()
        {
            List<Flight> flights = new List<Flight>();
            List<Segment> segments = new List<Segment>();

            foreach (var item1 in flightAll)
            {
                flights.Add(item1);
                if(item1.Segments.Count > 1)
                {
                    for (int i = 1; i < item1.Segments.Count; i++)
                    {
                        if(item1.Segments[i-1].ArrivalDate.AddHours(2) >= item1.Segments[i].DepartureDate)
                        {
                            segments.Add(item1.Segments[i-1]);
                            if(i == item1.Segments.Count)
                            {
                                segments.Add(item1.Segments[i]);
                            }
                        }
                        else
                        {
                            flights.Remove(item1);
                            break;
                        }
                    }
                }
                
            }
            return flights;

        }
       public void PrintFlight(IList<Flight> flights)
        {
            int i = 1;
            foreach (var item1 in flights)
            {
                Console.WriteLine($"Возможные варианты перелета {i++}");
                foreach (var item in item1.Segments)
                {

                    Console.WriteLine($"Время вылета: {item.DepartureDate} - время прилета: {item.ArrivalDate}");
                }
            }
        }
    }
}
