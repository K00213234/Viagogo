using System;
using System.Collections.Generic;
using System.Text;

namespace Viagogo
{
    class Ticket
    {
        private double price;

        public double myexample
        {
            get;
            set;
        }
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value; 
            }
        }

        public Ticket(double price)
        {
            Price = price;
        }

        public static Boolean IsValidPrice(Ticket ticket)
        {
            return (ticket.Price <= 0);
        }

        public static String Report(Ticket ticket)
        {
            if (!IsValidPrice(ticket))
                return $"{nameof(ticket.Price)} must be bigger than 0.";
            else
                return $"It's grand!";
        }
    }
}
