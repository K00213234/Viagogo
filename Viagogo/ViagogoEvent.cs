using System;
using System.Collections.Generic;
using System.Text;

namespace Viagogo
{
    class ViagogoEvent
    {
        private static int PreviousId;
        private int Id;
        private List<Ticket> TicketsList;

        public static int PreviousId1 { get => PreviousId; set => PreviousId = value; }
        public int Id1
        {
            get
            {
                return Id;
            }
            set
            {
                Id = PreviousId1 + 1;
                PreviousId1 = PreviousId1 + 1;
            }
        }
        internal List<Ticket> TicketsList1 { get => TicketsList; set => TicketsList = value; }

        public ViagogoEvent(List<Ticket> ticketsList1)
        {
            Id = Id1;
            TicketsList1 = ticketsList1;
        }
    }
}
