using System;
using System.Collections.Generic;
using System.Text;

namespace Viagogo
{
    class Coordinate
    {
        private int PointX;
        private int PointY;
        private ViagogoEvent ViagogoEvent;
        private int Distance;

        public int PointX1 { get => PointX; set => PointX = value; }
        public int PointY1 { get => PointY; set => PointY = value; }
        internal ViagogoEvent ViagogoEvent1 { get => ViagogoEvent; set => ViagogoEvent = value; }
        public int Distance1 { get => Distance; set => Distance = value; }

        public Coordinate()
        {
        }

        public Coordinate(int pointX1, int pointY1, ViagogoEvent viagogoEvent)
        {
            PointX1 = pointX1;
            PointY1 = pointY1;
            ViagogoEvent1 = viagogoEvent;
            Distance1 = 0;
        }

        public void CalculateDistance(int targetX, int targetY)
        {
           // Distance is calculated as Manhattan Distance
           Distance1 = Math.Abs(PointX1 - targetX) + Math.Abs(PointY1 - targetY);
        }
    }
}
