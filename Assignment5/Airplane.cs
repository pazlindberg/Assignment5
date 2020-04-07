using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
    class Airplane : Vehicle
    {
        public double MaxAltitude { get; set;  }
        public Airplane(string reg, string col, int wheels, double maxalt) : base(reg, col, wheels)
        {
            MaxAltitude = maxalt;
        }
   
        public override string GetSpecific()
        {
            string ret;
            ret = MaxAltitude.ToString();
            return ret;
        }
    }
}
