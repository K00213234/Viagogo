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
            MaxNumOfTicketsPerEvent = 5;
            MinAxisX = MinAxisY = -10;
            MaxAxisX = MaxAxisY = 10;
            MaxNumOfCoordinates = (Math.Abs(MinAxisX) + Math.Abs(MaxAxisX)) * (Math.Abs(MinAxisY) + Math.Abs(MaxAxisY));
        }

        public static List<Coordinate> GenerateData()
        {
            Random Random = new Random();



            // Generate List of Coordinates
            List<Coordinate> CoordinatesList = new List<Coordinate>();

            for (var i = 0; i < MaxNumOfCoordinates;i++)
            {
                // Generate Coordinate Points
                int PointX = Random.Next(MinAxisX, MaxAxisX);
                int PointY = Random.Next(MinAxisY, MaxAxisY);

                if (CoordinatesList.Count!=0)
                {
                                   
                    bool EmptyCoordinate = false;
                    // Check is location for new coordinate empty
                    do
                    {
                        foreach (var coordinate in CoordinatesList)
                        {
                            if (coordinate.IsEmpty(PointX, PointY) == false)
                            {
                                PointX = Random.Next(MinAxisX, MaxAxisX);
                                PointY = Random.Next(MinAxisY, MaxAxisY);
                            }
                            else
                            {
                                EmptyCoordinate = true;
                            }
                        }
                    } while(EmptyCoordinate == false);
                    
                }

                // Generate List of Tickets
                List<Ticket> TicketsList = new List<Ticket>();
                for (var j = 0; j < MaxNumOfTicketsPerEvent; j++)
                {
                    double RandomPrice = MinTicketPrice + (Random.NextDouble() * (MaxTicketPrice - MinTicketPrice));
                    Ticket Ticket = new Ticket(RandomPrice);
                    TicketsList.Add(Ticket);
                }

                // Generate Event
                ViagogoEvent ViagogoEvent = new ViagogoEvent(TicketsList);

                Coordinate Coordinate = new Coordinate(PointX, PointY, ViagogoEvent);
                CoordinatesList.Add(Coordinate);
            }

            return CoordinatesList;
        }

    }
}
