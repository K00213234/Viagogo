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
        private static readonly int MinAxisX;
        private static readonly int MaxAxisX;
        private static readonly int MinAxisY;
        private static readonly int MaxAxisY;
        private static int MaxNumOfCoordinates;

        static DataSeed()
        {
            MaxTicketPrice = 300;
            MinTicketPrice = 0.01;
            MaxNumOfTicketsPerEvent = 2;
            MinAxisX = -1;
            MinAxisY = -1;
            MaxAxisX = 1;
            MaxAxisY = 1;
            MaxNumOfCoordinates = (Math.Abs(MinAxisX) + Math.Abs(MaxAxisX)) * (Math.Abs(MinAxisY) + Math.Abs(MaxAxisY));
        }

        public static List<Coordinate> GenerateData()
        {
            Console.WriteLine("Generate data...\n");

            // Generate List of Coordinates
            int PointX;
            int PointY;

            List<Coordinate> CoordinatesList = new List<Coordinate>();
            HashSet<Int64> CoordinatesSet = new HashSet<Int64>();

            for (var i = 0; i < MaxNumOfCoordinates; i++)
            {
                bool CoordinateCreated = false;

                do
                {
                    // Generate Unique Coordinate Points
                    Random Random = new Random();

                    PointX = Random.Next(MinAxisX, MaxAxisX);
                    PointY = Random.Next(MinAxisY, MaxAxisY);

                    Int64 uniq = ((PointY + 20) * 0x100000000) + (PointX + 20);
                    CoordinateCreated = CoordinatesSet.Add(uniq);
                } while (CoordinateCreated == false);

                // Generate List of Tickets
                List<Ticket> TicketsList = new List<Ticket>();
                for (var j = 0; j < MaxNumOfTicketsPerEvent; j++)
                {
                    Random Random3 = new Random();
                    double RPrice = Random3.NextDouble();
                    double RandomPrice = MinTicketPrice + (RPrice * (MaxTicketPrice - MinTicketPrice));
                    Ticket Ticket = new Ticket(RandomPrice);
                    TicketsList.Add(Ticket);
                }

                // Generate Event
                ViagogoEvent ViagogoEvent = new ViagogoEvent(TicketsList);

                Coordinate Coordinate = new Coordinate(PointX, PointY, ViagogoEvent);
                Console.WriteLine(" \t Add X({0}) Y({1})", Coordinate.PointX1, Coordinate.PointY1);
                CoordinatesList.Add(Coordinate);

            }
            return CoordinatesList;
        }

    }
}
