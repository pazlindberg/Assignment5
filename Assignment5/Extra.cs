using System;
using System.Collections.Generic;
using System.Text;

//temp playground 

namespace Assignment5
{
    static class Extra
    {
        //public static Vehicle GetBoat1()
        //{
        //    return (new Boat(1.2, "abc111", "red", 0));
        //}
        
        //public static Vehicle GetBoat2()
        //{
        //    return (new Boat(2.3, "abc222", "chocking magenta", 0));
        //}

        public static IEnumerable<Vehicle> GetIteratorVehicles()
        {
            
            yield return (new Airplane("jjj233", "black", 3, 23.2));
            yield return (new Boat("dhj233", "white", 0,1.2));
            yield return (new Bus( "dwk120", "green", 29,3));
            yield return (new Car("bbb111", "yellow", 7,4));
            yield return (new Motorcycle("epp234", "amber", 2,345));

            yield return (new Airplane("jjj233", "black", 7,43323));
            yield return (new Boat("dhF233", "white", 0,4));
            yield return (new Bus("dwk12", "green", 29,12));
            yield return (new Car("Qbb111", "yellow", 2,34));
            yield return (new Motorcycle("epp204", "amber", 1,23));

            yield return (new Airplane("jjj233", "black", 3,3));
            yield return (new Boat("dhj233", "", 0,2));
            yield return (new Bus("dwk120", "green", 29,56));
            yield return (new Car("bbb181", "yellow", 7,54));
            yield return (new Motorcycle("", "amber", 2,11));

        }

        public static string NormalFormatting(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                s = s.Trim();
                var firstChar = s[0].ToString().ToUpper();
                var otherChars = s.Substring(1).ToLower();
                return $"{firstChar}{otherChars}";
            }
            else s = null;
            return s;
        }

        public static string CAPITALFormatting(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                s = s.Trim();
                s = s.ToUpper();
                return $"{s}";
            }
            else s = null;
            return s;
        }
    }
}
