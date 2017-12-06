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

            List<Ticket> TicketsList = new List<Ticket>();
            TicketsList.Add(Ticket);

            ViagogoEvent anEvent = new ViagogoEvent(TicketsList);
            Console.WriteLine("New Ticket - price: {0}", Ticket.Price1);
        }
    }
}
