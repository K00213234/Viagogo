using System;
using System.Collections.Generic;
using System.Globalization;

namespace Viagogo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize values
            // Assumption look for 5 nearest coordinates/events
            int NumOfNearestEvents = 5;
            DataSeed DataSeed = new DataSeed();

            // Generate Data
            List<Coordinate> CoordinatesList = new List<Coordinate>();
            CoordinatesList = DataSeed.GenerateData();

            // Get location points
            Console.Write("Please Input Coordinates:");
            string inputCoordinates = Console.ReadLine();

            // Parse location

            string PointX  = null;
            string PointY = null;
            int TargetPointX = 0;
            int TargetPointY = 0;

            try {
                string[] splitedCoordinates = inputCoordinates.Split(',');
                PointX = (string)splitedCoordinates.GetValue(0);
                PointY = (string)splitedCoordinates.GetValue(1);
                TargetPointX = Int32.Parse(PointX);
                TargetPointY = Int32.Parse(PointY);

                if (CoordinatesList.Count != 0)
                    foreach (var coordinate in CoordinatesList)
                    {
                        coordinate.CalculateDistance(TargetPointX, TargetPointY);
                    }
                else
                    Console.WriteLine("String could not be parsed.");
            }

            catch (Exception)
            {
                Console.WriteLine("Wrong data or data format.\n Use format: 7,1");
                Console.WriteLine("Using default values for coordinates " +
                    "x:{0} and y:{1}", TargetPointX, TargetPointY);
            }



            // Sort Coordinates
            CoordinatesList.Sort((p, q) => p.Distance1.CompareTo(q.Distance1));

            // Get nearest Coordinates
            List<Coordinate> NearestCoordinates = CoordinatesList.GetRange(0,NumOfNearestEvents);

            foreach (var nearestCoordinate in NearestCoordinates)
            {   
                // Get all tickets for the event
                List<Ticket> Tickets = nearestCoordinate.ViagogoEvent1.TicketsList1;
                // Sort Tickets
                Tickets.Sort((p, q) => p.Price1.CompareTo(q.Price1));
                // Display Event Id
                Console.Write(" Event {0:000} - ", nearestCoordinate.ViagogoEvent1.Id1);
                // Display Cheapest Ticket
                if(Tickets.Count == 0)
                {
                    Console.Write("No tickets for the event");
                }
                else
                {
                    Console.Write(Tickets[0].Price1.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                }

                //Display Distance
                Console.WriteLine(", Distance {0}", nearestCoordinate.Distance1);
            }

        }
    }
}
