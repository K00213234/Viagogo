using System;
using System.Collections.Generic;
using System.Text;

namespace Viagogo
{
    class Ticket
    {
        private double Price;

        public double Price1
        {
            get
            {
                return Price;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} must be bigger than 0.");

                Price = value; 
            }
        }

        public Ticket(double price)
        {
            Price1 = price;
        }
    }
}
