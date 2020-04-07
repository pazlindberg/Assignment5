using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
    class Bus : Vehicle
    {
        public int Passengers { get; set; }

        public Bus(string reg, string col, int wheels, int passengers) : base(reg, col, wheels)
        {
            Passengers = passengers;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public override string GetSpecific()
        {
            string ret;
            ret = Passengers.ToString();
            return ret;
        }
    }
}
