using System;
using System.Collections.Generic;

namespace Viagogo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Tickets
            Ticket Ticket = new Ticket(20.0);
            Ticket Ticket2 = new Ticket(25.0);
            Ticket Ticket3 = new Ticket(30.0);

            // Create List of Tickets
            List<Ticket> TicketsList = new List<Ticket>();
            TicketsList.Add(Ticket);
            TicketsList.Add(Ticket2);
            TicketsList.Add(Ticket3);

            // Create Event
            ViagogoEvent anEvent = new ViagogoEvent(TicketsList);

            // Create Coordinate
            // check does is coordinate empty
            Coordinate aCoordinate = new Coordinate(3, 4, anEvent);

            // Display Test Data 
            foreach(var t in anEvent.TicketsList1)
            {
                Console.WriteLine("Ticket - {0}", t.Price1);
            }

            Console.WriteLine("Event Id: {0}", anEvent.Id1);


           



        }
    }
}
