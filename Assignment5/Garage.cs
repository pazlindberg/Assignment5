using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
  
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] vehicles;
        
        public T GetVehicle(int pos)
        {
            T toReturn = null;
            if(vehicles[pos]!=null)
            {
                toReturn = vehicles[pos];
            }
            return (toReturn);
        }

        public Garage(int noVehicles)
        {
            vehicles = new T[noVehicles];
        }

        /// <summary>
        ///     
        /// </summary>
        /// <returns>int: negative value, if full</returns>
        public int FirstEmpty()
        {
            int emptyIndex = -1;
            for (int i = 0; i < vehicles.Length; i++) if (vehicles[i] == null) return (i);
            return (emptyIndex);
        }

        public bool Add(int pos, T toAdd)
        {
            bool success = false;
            if(vehicles[pos]==null)
            {
                vehicles[pos] = toAdd;
                success = true;
            }
            return success;
        }

        public bool Remove(int pos)
        {
            vehicles[pos] = null;
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var ch in vehicles) if (ch != null) yield return ch;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (this.GetEnumerator());
        }
    }
}
