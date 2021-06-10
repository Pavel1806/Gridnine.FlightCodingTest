using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Gridnine.FlightCodingTest;
using System;

namespace Gridnine.FlightCodingTestTests
{
    [TestClass]
    public class FilterTest
    {
        [TestMethod]
        public void DeparturesBeforeTime_CheckingNumberFlights()
        {
            IList<Flight> fl = new List<Flight>
            {
                new Flight
                {
                    Segments = new List<Segment>
                    { new Segment {DepartureDate = new DateTime(2021, 6, 13, 14, 5, 0), ArrivalDate = new DateTime(2021, 6, 13, 16, 5, 0)}}
                },
                new Flight
                {
                    Segments = new List<Segment>
                    {new Segment {DepartureDate = new DateTime(2021, 6, 13, 15, 5, 0), ArrivalDate = new DateTime(2021, 6, 13, 16, 5, 0)}}
                },
                new Flight
                {
                    Segments = new List<Segment>
                    {new Segment {DepartureDate = new DateTime(2021, 6, 13, 13, 5, 0), ArrivalDate = new DateTime(2021, 6, 13, 16, 5, 0)}}
                },
            };

            DateTime date = new DateTime(2021, 6, 13, 14, 0, 0);

            int flightCount = 2;

            Filter filter = new Filter(fl);

            IList<Flight> flight  = filter.DeparturesBeforeTime(date);

            Assert.AreEqual(flightCount, flight.Count);

            
        }
        [TestMethod]
        public void ArrivalDateBeforeDepartureDate_CheckingNumberFlights()
        {
            IList<Flight> fl = new List<Flight>
            {
                new Flight
                {
                    Segments = new List<Segment>
                    {new Segment {DepartureDate = new DateTime(2021, 6, 13, 14, 5, 0), ArrivalDate = new DateTime(2021, 6, 13, 16, 5, 0)},
                     new Segment {DepartureDate = new DateTime(2021, 6, 13, 17, 5, 0), ArrivalDate = new DateTime(2021, 6, 13, 17, 5, 0)}}
                },
                new Flight
                {
                    Segments = new List<Segment>
                    {new Segment {DepartureDate = new DateTime(2021, 6, 13, 15, 5, 0), ArrivalDate = new DateTime(2021, 6, 13, 16, 5, 0)}}
                },
                new Flight
                {
                    Segments = new List<Segment>
                    {new Segment {DepartureDate = new DateTime(2021, 6, 13, 13, 5, 0), ArrivalDate = new DateTime(2021, 6, 13, 16, 5, 0)},
                     new Segment{DepartureDate = new DateTime(2021, 6, 13, 17, 5, 0), ArrivalDate = new DateTime(2021, 6, 13, 17, 5, 0)}}
                },

            };

            DateTime date = new DateTime(2021, 6, 13, 14, 0, 0);

            int flightCount = 1;

            Filter filter = new Filter(fl);

            IList<Flight> flight = filter.ArrivalDateBeforeDepartureDate();

            Assert.AreEqual(flightCount, flight.Count);
        }
        [TestMethod]
        public void BreakBetweenPlanes_CheckingNumberFlights()
        {
            IList<Flight> fl = new List<Flight>
            {
                new Flight
                {
                    Segments = new List<Segment>
                    {new Segment {DepartureDate = new DateTime(2021, 6, 13, 14, 5, 0), ArrivalDate = new DateTime(2021, 6, 13, 16, 5, 0)},
                     new Segment {DepartureDate = new DateTime(2021, 6, 13, 19, 5, 0), ArrivalDate = new DateTime(2021, 6, 13, 20, 5, 0)}}
                },
                new Flight
                {
                    Segments = new List<Segment>
                    {new Segment {DepartureDate = new DateTime(2021, 6, 13, 15, 5, 0), ArrivalDate = new DateTime(2021, 6, 13, 16, 5, 0)}}
                },
                new Flight
                {
                    Segments = new List<Segment>
                    {new Segment {DepartureDate = new DateTime(2021, 6, 13, 13, 5, 0), ArrivalDate = new DateTime(2021, 6, 13, 16, 5, 0)},
                     new Segment{DepartureDate = new DateTime(2021, 6, 13, 17, 5, 0), ArrivalDate = new DateTime(2021, 6, 13, 17, 5, 0)}}
                },

            };

            DateTime date = new DateTime(2021, 6, 13, 14, 0, 0);

            int flightCount = 2;

            Filter filter = new Filter(fl);

            IList<Flight> flight = filter.BreakBetweenPlanes();

            Assert.AreEqual(flightCount, flight.Count);
        }
    }
}
