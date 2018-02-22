using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Viagogo
{
    class Coordinate
    {
        private ViagogoEvent ViagogoEvent;
        private int Distance;
        public Point Coordinates { get; set; }


        internal ViagogoEvent ViagogoEvent1 { get => ViagogoEvent; set => ViagogoEvent = value; }
        public int Distance1 { get => Distance; set => Distance = value; }

        public Coordinate()
        {
        }

        public Coordinate(int pointX1, int pointY1, ViagogoEvent viagogoEvent)
        {
            this.Coordinates = new Point(pointX1, pointY1);
            ViagogoEvent1 = viagogoEvent;
            Distance1 = 0;
        }

        public void CalculateDistance(int targetX, int targetY)
        {
            // Distance is calculated as Manhattan Distance
            Distance1 = Math.Abs(this.Coordinates.X - targetX) + Math.Abs(this.Coordinates.Y - targetY);
        }

        public int CalculateDistanceTo(Point target)
        {
            int d = CalculateDistanceTo(this.Coordinates, target);
            this.Distance1 = d;
            return d;
        }

        public static int CalculateDistanceTo(Point lhsPoint, Point rhsPoint)
        {
            // Distance is calculated as Manhattan Distance
            return  Math.Abs(lhsPoint.X - rhsPoint.X) + Math.Abs(lhsPoint.Y - rhsPoint.Y);
        }
    }
}
