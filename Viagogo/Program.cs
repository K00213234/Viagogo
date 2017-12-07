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
            int NumOfNearestEvents = 5;
            DataSeed DataSeed = new DataSeed();

            // Generate Data
            List<Coordinate> CoordinatesList = new List<Coordinate>();
            CoordinatesList = DataSeed.GenerateData();

            // Get location points
            Console.Write("Please Input Coordinates:");
            string inputCoordinates = Console.ReadLine();

            // Parse location
            string[] splitedCoordinates = inputCoordinates.Split(',');
            string PointX = (string)splitedCoordinates.GetValue(0);
            string PointY = (string)splitedCoordinates.GetValue(1);

            // Calculate distance between point of interest and other events
            if ((Int32.TryParse(PointX, out int TargetPointX)) && (Int32.TryParse(PointY, out int TargetPointY)))
                foreach (var coordinate in CoordinatesList)
                {
                    coordinate.CalculateDistance(TargetPointX, TargetPointY);
                }
            else
                Console.WriteLine("String could not be parsed.");

            // Sort Coordinates List in DESC order by Distance
            CoordinatesList.Sort((p, q) => p.Distance1.CompareTo(q.Distance1));

            //Display A Data

            List<Coordinate> NearestCoordinates = CoordinatesList.GetRange(0,NumOfNearestEvents);


            foreach (var nearestCoordinate in NearestCoordinates)
            {   
                // Get all tickets for the event
                List<Ticket> Tickets = nearestCoordinate.ViagogoEvent1.TicketsList1;
                // Sort Tickets in ASCENDING ORDER
                Tickets.Sort((p, q) => -1 * p.Price1.CompareTo(q.Price1));
          
                // Display Event Id
                Console.Write(" Event {0:000} - ", nearestCoordinate.ViagogoEvent1.Id1);
                //Display Cheapest Ticket
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
