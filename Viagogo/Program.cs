using System;
using System.Collections.Generic;

namespace Viagogo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing class Ticket
            Ticket Ticket = new Ticket(20.0);
            Ticket Ticket2 = new Ticket(25.0);
            Ticket Ticket3 = new Ticket(30.0);

            List<Ticket> TicketsList = new List<Ticket>();
            TicketsList.Add(Ticket);
            TicketsList.Add(Ticket2);
            TicketsList.Add(Ticket3);

            ViagogoEvent anEvent = new ViagogoEvent(TicketsList);

            foreach(var t in anEvent.TicketsList1)
            {
                Console.WriteLine("Ticket - {0}", t.Price1);
            }

            Console.WriteLine("Event Id: {0}", anEvent.Id1);


            Console.WriteLine("New Ticket - price: {0}", Ticket.Price1);
        }
    }
}
