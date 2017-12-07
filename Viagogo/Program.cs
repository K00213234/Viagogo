using System;
using System.Collections.Generic;

namespace Viagogo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize world values
            DataSeed DataSeed = new DataSeed();

            // Generate Data
            List<Coordinate> CoordinatesList = new List<Coordinate>();
            CoordinatesList = DataSeed.GenerateData();

            // Get location points
            Console.Write("Please Input Coordinates:");
            string inputCoordinates = Console.ReadLine();
            string[] splitedCoordinates = inputCoordinates.Split(',');

            string PointX = (string)splitedCoordinates.GetValue(0);
            string PointY = (string)splitedCoordinates.GetValue(1);

            Console.WriteLine(PointX);
            Console.WriteLine(PointY);


            // Calculate distance between point of interest and other events
            if ((Int32.TryParse(PointX, out int TargetPointX)) && (Int32.TryParse(PointY, out int TargetPointY)))
                foreach (var coordinate in CoordinatesList)
                {
                    coordinate.CalculateDistance(TargetPointX, TargetPointY);
                }
            else
                Console.WriteLine("String could not be parsed.");

            // Sort Coordinates List
            CoordinatesList.Sort((p, q) => p.Distance1.CompareTo(q.Distance1));

            //Display All Data

            foreach (var coordinate in CoordinatesList)
            {
                Console.Write(" Coordinates: X({0}), Y({1})", coordinate.PointX1, coordinate.PointY1);

                Console.Write(" - Event No: {0}", coordinate.ViagogoEvent1.Id1);
                Console.WriteLine(" - Distance: {0}", coordinate.Distance1);
            }

        }
    }
}
