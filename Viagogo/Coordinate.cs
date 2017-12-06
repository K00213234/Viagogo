using System;
using System.Collections.Generic;
using System.Text;

namespace Viagogo
{
    class Coordinate
    {
        private int PointX;
        private int PointY;
        private ViagogoEvent VEvent;

        public int PointX1 { get => PointX; set => PointX = value; }
        public int PointY1 { get => PointY; set => PointY = value; }
        internal ViagogoEvent VEvent1 { get => VEvent; set => VEvent = value; }

        public Coordinate(int pointX1, int pointY1, ViagogoEvent vEvent1)
        {
            PointX1 = pointX1;
            PointY1 = pointY1;
            VEvent1 = vEvent1;
        }
    }
}
