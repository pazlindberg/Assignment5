using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
  
    internal class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] vehicles;

        public Garage(int noVehicles)
        {
            vehicles = new T[noVehicles];
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

}
