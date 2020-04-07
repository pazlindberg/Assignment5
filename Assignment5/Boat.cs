using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
    internal class Boat : Vehicle
    {
        public double Weight { get; set; }
        
        public Boat(string reg,string col, int wheels, double weight) : base(reg, col, wheels)
        {
            Weight = weight;
        }

        public override string GetSpecific()
        {
            string ret;
            ret = Weight.ToString();
            return ret;
        }
    }
}
