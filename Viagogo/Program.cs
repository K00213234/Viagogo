using System;
using System.Collections.Generic;

namespace Viagogo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize world values
            DataSeed DataSeed = new DataSeed();

            // Generate Data
            List<Coordinate> CoordinatesList = new List<Coordinate>();
            CoordinatesList = DataSeed.GenerateData();

            
            // Display All Data
            foreach (var coordinate in CoordinatesList)
            {
                Console.WriteLine("Event No: {0}", coordinate.ViagogoEvent1.Id1);
                foreach(var ticket in coordinate.ViagogoEvent1.TicketsList1)
                {
                    Console.WriteLine("Ticket Price: {0}", ticket.Price1);
                }
            }



        }
    }
}
