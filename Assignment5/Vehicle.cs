﻿namespace Assignment5
{
    public class Vehicle //först gjorde jag den abstrakt men sedan blev det smidigare att köra utan, även om det förmodligen beror på feltänk i design
    {

        //private string regNumber;
        public string RegNumber { get; set; }
        public string Color { get; set;  }
        public int NoWheels { get; set; }

        public Vehicle(string regnumber, string color, int numwheels)
        {
            RegNumber = regnumber;
            Color = color;
            NoWheels = numwheels;
        }

        public Vehicle(Vehicle v)
        {
            RegNumber = v.RegNumber;
            Color = v.Color;
            NoWheels = v.NoWheels;
        }

        public virtual string GetSpecific() { return null; }
    }
}