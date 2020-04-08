using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment5
{
    class GarageHandler
    {
        public const int sizeOfGarage=64;

        public readonly IEnumerable<Type> types = System.Reflection.Assembly.GetExecutingAssembly().GetTypes().Where(x => x.BaseType == typeof(Vehicle));

        private Garage<Vehicle> garage = new Garage<Vehicle>(sizeOfGarage);

        public void ListAll()
        {
            foreach(var ch in garage)
            {
                string toPrint = $"{ch.RegNumber}\t{ch.Color}\t{ch.NoWheels}";
                if (ch is Boat) toPrint += $"\tBoat";
                else if (ch is Airplane) toPrint += $"\tAirplane";
                else if (ch is Bus) toPrint += $"\tBus";
                else if (ch is Car) toPrint += $"\tCar";
                else if (ch is Motorcycle) toPrint += $"\tMotorcycle";
                else toPrint += "\tUNKNOWN TYPE!";
                toPrint += $" specific proterty: {ch.GetSpecific()}"; //todo: bättre output så man fattar vilken egenskap det rör sig om, men det är nog rätt oviktigt i denna övning
                Console.WriteLine(toPrint);
            }
        }

        public void Remove(int pos)
        {
            garage.Remove(pos);
        }

        public void ListAllTypes()
        {
            var availTypes = new Dictionary<string, int>();

            foreach (var ch in types) availTypes.Add(ch.Name, 0); //over-kill kanske, men tycker det är logiskt ändå
            
            foreach (var ch in garage)
            {
                string thisType = ch.GetType().Name;
                if(availTypes.ContainsKey(thisType)) 
                {
                    int i = availTypes[thisType];
                    ++i;
                    availTypes[thisType] = i;
                }
            }

            foreach (var ch in availTypes.Keys) Console.WriteLine($"{ch} - {availTypes[ch]}");
        }

        public void Add(Vehicle toAdd)
        {
            int empty = garage.FirstEmpty();
            if (empty >= 0)
            {
                Console.WriteLine("added " + toAdd.RegNumber);
                garage.Add(empty, toAdd);
            }
            else
            {
                Console.WriteLine("unable to add!");
            } 
        }

        public void AddDummys() //denna är inte så noga, men den avslöjar ett tankefel med att lägga till poster (dubletter kollas på fel nivå)
        {
            foreach (var i in Extra.GetIteratorVehicles())
            {
                string typeToAdd = i.GetType().Name;
                typeToAdd = Extra.NormalFormatting(typeToAdd);

                Console.WriteLine(typeToAdd);

                string foundType = null;

                foreach (var ch in types)
                {
                    if (typeToAdd == ch.Name)
                    {
                        foundType = ch.Name;
                    }
                }

                if (foundType == null)
                {
                    //TODO: loop again 
                    Console.WriteLine("non existant type or no input!");
                }
                else
                {
                    Console.WriteLine(foundType);
                    //TODO: add type specifics and then the shared stuff and then add
                    int empty = garage.FirstEmpty();
                    if (empty >= 0)
                    {
                        Vehicle t = i;
                        t.RegNumber = t.RegNumber.ToUpper();
                        t.Color = t.Color.ToUpper();
                        Console.WriteLine("adding " + t.RegNumber + ". //foundtype: " + foundType);
                        garage.Add(garage.FirstEmpty(), t);
                    }
                    else
                    {
                        Console.WriteLine("garage full");
                    }
                }
            }
        }

        public int RegLookup(string searchReg)
        {
            int found = -1;
            int count = 0;

            searchReg = Extra.CAPITALFormatting(searchReg);

            foreach (var ch in garage)
            {
                if(searchReg==ch.RegNumber) return (count);
                count++;
            }
            return (found);
        }

        public int Lookup(string reg)
        {
            int pos = 0;
            reg = reg.ToUpper();
            foreach(var ch in garage)
            {
                if(ch.RegNumber==reg)
                {
                    return pos;
                }
                pos++;
            }
            pos = -1;
            return pos;
        }

        public Queue<Vehicle> Lookup(string type, string reg, string color, int nowheels)
        {
            var lookedUp = new Queue<Vehicle>();

            //check if type exists in structure first
            //todo: format type properly
            bool validType = false;
            foreach (var ch in types)
            {
                if (type == ch.Name)
                    validType = true;
            }
            if (!validType) type = "";

            //todo: better formatting check
            if (string.IsNullOrEmpty(reg)) reg = "";
            if (string.IsNullOrEmpty(color)) reg = "";
            
            string wheels; //kan inte komma ihåg varför jag gjorde denna till string - möjligen hjärnsläpp
            if (nowheels > 0) wheels = nowheels.ToString();

            foreach (var ch in garage)
            {
                string searchType, searchReg, searchColor, searchWheels;
                
                if (type == "") searchType = ch.GetType().Name;
                else searchType = type;

                if (reg == "") searchReg = ch.RegNumber;
                else searchReg = reg;

                if (color == "") searchColor = ch.Color;
                else searchColor = color;

                if (nowheels <= 0) searchWheels = ch.NoWheels.ToString();
                else
                {
                    //todo: formatting
                    searchWheels = nowheels.ToString(); //?
                }

                if((ch.GetType().Name==searchType) &&
                    (ch.RegNumber==searchReg) &&
                    (ch.Color==searchColor) &&
                    (ch.NoWheels.ToString()==searchWheels))
                {
                    Vehicle forReturn;
                    switch (searchType) //could be generalised but time flies
                    {
                        case "Airplane":
                            //maxalt = double.Parse(toLookup.GetSpecific());//todo: formatting
                            forReturn = new Airplane(searchReg, searchColor, Int32.Parse(searchWheels), 0); //todo: fix parse
                            break;
                        case "Boat":
                            //weight = double.Parse(toLookup.GetSpecific());
                            forReturn = new Boat(searchReg, searchColor, Int32.Parse(searchWheels), 0); //todo: fix parse
                            break;
                        case "Bus":
                            //passengers = Int32.Parse(toLookup.GetSpecific());
                            forReturn = new Bus(searchReg, searchColor, Int32.Parse(searchWheels), 0); //todo: fix parse
                            break;
                        case "Car":
                            //gasolineconsumption = Int32.Parse(toLookup.GetSpecific());
                            forReturn = new Car(searchReg, searchColor, Int32.Parse(searchWheels), 0); //todo: fix parse
                            break;
                        case "Motorcycle":
                            //topspeed = Int32.Parse(toLookup.GetSpecific());
                            forReturn = new Motorcycle(searchReg, searchColor, Int32.Parse(searchWheels), 0); //todo: fix parse
                            break;
                        default:
                            forReturn = new Vehicle(searchReg, searchColor, Int32.Parse(searchWheels)); //todo: fix parse
                            break;
                    }
                    //todo: implement all specific (as searchable) if time ...
                    if(forReturn!=null)
                    {
                        lookedUp.Enqueue(forReturn);
                        Console.WriteLine("adding to search-result..." + forReturn.RegNumber);
                    }
                }
            }
            return lookedUp;
        }
        //public Queue<Vehicle> Lookup(Vehicle toLookup)
        //{
        //    var lookedUp = new Queue<Vehicle>();

        //    /*
        //     * 
        //     *   Vehicle toSearch;
        //    Console.WriteLine("\r\n\r\nFill the fields you wanna search, leave rest empty... ");
        //    Console.Write("type: ");
        //    string type = Console.ReadLine(); //todo: make formatting correct
        //    Console.Write("regnr: ");
        //    string reg = Console.ReadLine().ToUpper(); //todo: check formatting
        //    Console.Write("color: ");
        //    string color= Console.ReadLine().ToUpper(); //todo: check formatting
        //    Console.Write("number of wheels: ");
        //    string wheels = Console.ReadLine(); //todo: fix checking
        //    int nowheels = Int32.Parse(wheels);
            
        //    Console.Write("max altitude: "); //plane - todo: maybe an abstract function that handles all specific input
        //                                        //the same in each derived
        //    Console.Write("weight: "); //boat
        //    Console.Write("max number of passengers: "); //bus
        //    Console.Write("gasoline consumption: "); //car
        //    Console.Write("top speed"); //motorcycle

            
        //    if (type == "Airplane")
        //    {
        //        double maxalt = AskForMaxAltitude();
        //        toSearch = new Airplane(reg, color, nowheels, maxalt); //todo: add with proper layering
        //    }
        //    else if (type == "Boat")
        //    {
        //        double weight = AskForWeight();
        //        toSearch = new Boat(reg, color, nowheels, weight);
        //    }
        //    else if (type == "Bus")
        //    {
        //        int passengers = AskForPassengers();
        //        toSearch = new Bus(reg, color, nowheels, passengers);
        //    }
        //    else if (type == "Car")
        //    {
        //        double gasolineconsumption = AskForGasolineConsumption();
        //        toSearch = new Car(reg, color, nowheels, gasolineconsumption);
        //    }
        //    else if (type == "Motorcycle")
        //    {
        //        double topspeed = AskForTopSpeed();
        //        toSearch = new Motorcycle(reg, color, nowheels, topspeed);
        //    }
        //    else return; //todo: fix bool error return
        //    //theGarage.Add(toAdd);
          
        //     */


        //    /*
            
        //    string type = toLookup.GetType().Name;
        //    string regnr = toLookup.RegNumber;
        //    string color = toLookup.Color;
        //    int nowheels = toLookup.NoWheels;
        //    double maxalt=-1;
        //    double weight=-1;
        //    int passengers=-1;
        //    double gasolineconsumption=-1;
        //    double topspeed=-1;
        //    Vehicle searchObject;
        //    switch(type) //could be generalised but time flies
        //    {
        //        case "Airplane":
        //            maxalt = double.Parse(toLookup.GetSpecific());//todo: formatting
        //            searchObject = new Airplane(regnr, color, nowheels, maxalt);
        //            break;
        //        case "Boat":
        //            weight = double.Parse(toLookup.GetSpecific());
        //            break;
        //        case "Bus":
        //            passengers = Int32.Parse(toLookup.GetSpecific());
        //            break;
        //        case "Car":
        //            gasolineconsumption = Int32.Parse(toLookup.GetSpecific());
        //            break;
        //        case "Motorcycle":
        //            topspeed = Int32.Parse(toLookup.GetSpecific());
        //            break;
        //        default:
        //            break;
        //    }  todo: implement all posibilty to search all fields later */
        //    string searchType = toLookup.GetType().Name; //todo: formatting
        //    string searchReg = toLookup.RegNumber;
        //    string searchColor = toLookup.Color;
        //    int searchWheels = toLookup.NoWheels;
            
        //    foreach (var ch in garage)
        //    {
        //        string parkedTyped = ch.GetType().Name;
        //        string parkedReg = ch.RegNumber;
        //        string parkedColor = ch.Color;
        //        int parkedWheels = ch.NoWheels;
        //        if (string.IsNullOrEmpty(searchType)) searchType = parkedTyped;
        //        if (string.IsNullOrEmpty(searchReg)) searchReg = parkedReg;
        //        if (string.IsNullOrEmpty(searchColor)) searchColor = parkedColor;
        //    }
        //    return (lookedUp);
        //}
    }
}
