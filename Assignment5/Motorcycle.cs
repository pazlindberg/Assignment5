using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
    class Motorcycle : Vehicle
    {
        public double TopSpeed { get; set; }

        public Motorcycle(string reg, string col, int wheels, double topspeed) : base(reg, col, wheels)
        {
            TopSpeed = topspeed;
        }

        public override string GetSpecific()
        {
            string ret;
            ret = TopSpeed.ToString();
            return ret;
        }//todo: check format
    }
}
