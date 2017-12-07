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

        public int PointX1 { get => PointX; set => PointX = value; }
        public int PointY1 { get => PointY; set => PointY = value; }
        internal ViagogoEvent ViagogoEvent1 { get => ViagogoEvent; set => ViagogoEvent = value; }

        public Coordinate(int pointX1, int pointY1, ViagogoEvent viagogoEvent)
        {
            PointX1 = pointX1;
            PointY1 = pointY1;
            ViagogoEvent1 = viagogoEvent;
        }

        public bool IsEmpty(int pointX, int pointY)
        {
            if ((PointX1 == pointX) && (PointY1 == pointY))
                return false;
            return true;
        }
    }
}
