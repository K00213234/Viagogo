using System;
using System.Collections.Generic;
using System.Text;

namespace Viagogo
{
    class ViagogoEvent
    {
        private static int PreviousId = 0;
        private int Id = 0;
        private List<Ticket> TicketsList;

        public static int PreviousId1 { get => PreviousId; set => PreviousId = value; }

        internal List<Ticket> TicketsList1 { get => TicketsList; set => TicketsList = value; }
        public int Id1 { get => Id; set => Id = value; }

        public ViagogoEvent()
        {
            PreviousId++;
            Id = PreviousId;
        }

        public ViagogoEvent(List<Ticket> ticketsList1)
        {
            PreviousId++;
            Id = PreviousId;
            TicketsList1 = ticketsList1;
        }
    }
}
