using System;
using System.Collections.Generic;
using System.Text;

namespace Viagogo
{
    class DataSeed
    {
        private static readonly double MaxTicketPrice;
        private static readonly double MinTicketPrice;
        private static readonly int MaxNumOfTicketsPerEvent;
        private static readonly int MinNumOfTicketsPerEvent;
        private static readonly int MinAxisX;
        private static readonly int MaxAxisX;
        private static readonly int MinAxisY;
        private static readonly int MaxAxisY;
        private static int MaxNumOfCoordinates;

        static DataSeed()
        {
            // Assumption: Highest price of ticket is 300 Dolars and lowest price is 1 cent
            MaxTicketPrice = 300;
            MinTicketPrice = 0.01;
            // Assumption: Maximum number of tickets per event is 5 and min is 0
            MaxNumOfTicketsPerEvent = 5;
            MinNumOfTicketsPerEvent = 0;
            // Given Size of the world
            MinAxisX = -10;
            MinAxisY = -10;
            MaxAxisX = 10;
            MaxAxisY = 10;
            // Assumption: Can't create more tickets that number of possible coordinates, coordinate has to be unique
            MaxNumOfCoordinates = (Math.Abs(MinAxisX) + Math.Abs(MaxAxisX)) * (Math.Abs(MinAxisY) + Math.Abs(MaxAxisY));
            // Assumption: Create 200 Coordinates
            MaxNumOfCoordinates = 200;
        }

        public static List<Coordinate> GenerateData()
        {
            Console.WriteLine("Generate data...\n");

            int PointX;
            int PointY;
            Random Random = new Random();

            List<Coordinate> CoordinatesList = new List<Coordinate>();
            HashSet<Int64> CoordinatesSet = new HashSet<Int64>();

            // Generate List of Unique Coordinates
            for (var i = 0; i < MaxNumOfCoordinates; i++)
            {
                bool CoordinateCreated = false;

                do
                {
                    // Generate Unique Coordinate Points
                    PointX = Random.Next(MinAxisX, MaxAxisX);
                    PointY = Random.Next(MinAxisY, MaxAxisY);

                    // Create uniq coordinate identifier 
                    Int64 Uniq = (PointY * 0x100000000) + PointX;
                    CoordinateCreated = CoordinatesSet.Add(Uniq);
                } while (CoordinateCreated == false);

                // Generate List of Tickets For Valid Points
                List<Ticket> TicketsList = new List<Ticket>();
                int NumberOfTickets = Random.Next(MinNumOfTicketsPerEvent,MaxNumOfTicketsPerEvent);
                for (var j = 0; j < NumberOfTickets; j++)
                {
                    Random RandomDouble = new Random();
                    double RPrice = RandomDouble.NextDouble();
                    double RandomPrice = MinTicketPrice + (RPrice * (MaxTicketPrice - MinTicketPrice));
                    Ticket Ticket = new Ticket(RandomPrice);
                    TicketsList.Add(Ticket);
                }

                // Generate Event
                ViagogoEvent ViagogoEvent = new ViagogoEvent(TicketsList);

                // Generate Coordinate and add to CoordinatesList
                Coordinate Coordinate = new Coordinate(PointX, PointY, ViagogoEvent);
                CoordinatesList.Add(Coordinate);

            }
            return CoordinatesList;
        }

    }
}
