using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
    class Car : Vehicle
    {
        public double GasolineConsumption { get; set; }
        public Car(string reg,string col,int wheels, double gasconsm) : base(reg, col, wheels)
        {
            GasolineConsumption = gasconsm;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public override string GetSpecific()
        {
            string ret;
            ret = GasolineConsumption.ToString();
            return ret;
        }
    }
}
