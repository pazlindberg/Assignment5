﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
    class UI
    {
        private Menu mainMenu;
        public bool running = true; //todo: well..
        public GarageHandler theGarage = new GarageHandler();
        
        private void Init()
        {
                mainMenu = new Menu(Extra.NormalFormatting("main"), new Dictionary<char, MenuMap>   {

                {'q', new MenuMap("End program", Quit) },
                {'a', new MenuMap("List all parked", theGarage.ListAll) },
                {'t', new MenuMap("List types and quantity", theGarage.ListAllTypes)},
                {'c', new MenuMap("Add/remove vehicles", AddRemove)}, 
                {'s', new MenuMap("Search by reg", SearchReg)},
                {'p', new MenuMap("Search by propertie(s)", SearchProperties)} //sedan: hantera tomma fält som alla träffar
            });

            theGarage.AddDummys();
        }

        public void Run()
        {
            Init();
            
            string input;
            do
            {
                mainMenu.Print();
                input = Console.ReadLine().ToLower();
                MenuInput(input); //för stunden .. running blir false i Quit()
            } while (running);
        }

        private bool MenuInput(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                char ikey = input[0];

                if (mainMenu.menuOptions.ContainsKey(ikey))
                {
                    MenuMap m = mainMenu.menuOptions.GetValueOrDefault(ikey);
                    if (m != null)
                    {
                        m.ToInvoke.Invoke();
                        return (true);
                    }
                }
            }

            if (!running) return false;
            else return (true);
        }

            //public string AskForType()
            //{
            //    Console.Write("\nType (valid types:  ");
            //    foreach (var ch in theGarage.types)
            //    {
            //        Console.Write($" {ch.Name} ");
            //    }
            //    Console.Write("): ");
            //    string type = Console.ReadLine();
            //    type = Extra.NormalFormatting(type);

            //    //todo: format and check chars

            //    foreach (var ch in theGarage.types)
            //    {
            //        if (type == ch.Name)
            //        {
            //            return (type);
            //        }
            //    }
            //    Console.WriteLine("invalid type!");
            //    return (null);
            //}

            //private string AskForReg()
            //{
            //    //todo: formatting and checking
            //    Console.Write("\nReg number: ");
            //    string regnr = Console.ReadLine();
            //    regnr = Extra.CAPITALFormatting(regnr);
            //    if (theGarage.Lookup(regnr) < 0)
            //        return (regnr);
            //    else return null;
            ////return Extra.CAPITALFormatting(regnr);
            //}

            //private string AskForColor()
            //{
            //    //todo: formatting and checking
            //    Console.Write("\nColor: ");
            //    string color = Console.ReadLine();
            //    return Extra.CAPITALFormatting(color);
            //}

            //int AskForWheels() //boat
            //{
            //    int toReturn;
            //    Console.WriteLine("Number of wheels: ");
            //    string input = Console.ReadLine();
            //    if (Int32.TryParse(input, out toReturn))
            //    { }
            //    else
            //    {
            //        Console.WriteLine("erratic number");
            //    }

            //    return (toReturn);
            //}

            //double AskForMaxAltitude() 
            //{
            //    double toReturn = -1;

            //    Console.WriteLine("Max altitude: ");
            //    string input = Console.ReadLine(); //repeating too much
            //    if (Double.TryParse(input, out toReturn))
            //    { }
            //    else
            //    {
            //        Console.WriteLine("erratic number");
            //    }

            //    return (toReturn);
            //}

            //double AskForWeight() //boat
            //{
            //    double toReturn = -1;

            //    Console.WriteLine("Weight: ");
            //    string input = Console.ReadLine(); //repeating too much
            //    if (Double.TryParse(input, out toReturn))
            //    { }
            //    else
            //    {
            //        Console.WriteLine("erratic number");
            //    }
            //    return (toReturn);
            //}

            //int AskForPassengers() //bus
            //{

            //    int toReturn = -1;

            //    Console.WriteLine("Passengers: ");
            //    string input = Console.ReadLine(); //repeating too much
            //    if (Int32.TryParse(input, out toReturn))
            //    { }
            //    else
            //    {
            //        Console.WriteLine("erratic number");
            //    }
            //    return (toReturn);
            //}

            //double AskForGasolineConsumption() //car
            //{
            //    double toReturn = -1;
            //    Console.WriteLine("Gasoline: ");
            //    string input = Console.ReadLine(); //repeating too much
            //    if (Double.TryParse(input, out toReturn))
            //    { }
            //    else
            //    {
            //        Console.WriteLine("erratic number");
            //    }
            //    return (toReturn);
            //}

            //double AskForTopSpeed() //motorcycle
            //{
            //    double toReturn = -1;

            //    Console.WriteLine("Top speed: ");
            //    string input = Console.ReadLine(); //repeating too much
            //    if (Double.TryParse(input, out toReturn))
            //    { }
            //    else
            //    {
            //        Console.WriteLine("erratic number");
            //    }

            //    return (toReturn);
            //}

        void AddRemove()
        {
            Console.WriteLine("[a]dd/[r]emove?");
            
            string input = Console.ReadLine();
            if(input[0]=='a'||input[0] == 'A')
            {
                Add();
            }
            else if(input[0] == 'r' || input[0] == 'R')
            {
               Remove();
            }
            else Console.WriteLine("invalid, 'a' or 'r'!");
        }

        private void Remove()
        {
            Console.Write("\r\nReg number: ");
            string input = Console.ReadLine();
            int pos = theGarage.Lookup(input);
            if (pos>=0) //formatting in called method
            {
                Console.WriteLine("removing...");
                theGarage.Remove(pos);
                //remove position
            }
            else
            {
                Console.WriteLine("not found!");
            }
        }

            private bool Add()
            {
                //theGarage.Add();
                string type = theGarage.AskForType();
                if (string.IsNullOrEmpty(type))
                {
                    Console.WriteLine("write correct type next time!");
                    return (false);
                }
                string reg = theGarage.AskForReg();
                if(reg==null)
                {
                    Console.WriteLine("already exists!");
                    return false;
                }
                string color = theGarage.AskForColor();
                int nowheels = theGarage.AskForWheels();

                Vehicle toAdd;
                if (type == "Airplane")
                {
                    double maxalt = theGarage.AskForMaxAltitude();
                    toAdd = new Airplane(reg, color, nowheels, maxalt); //todo: add with proper layering
                }
                else if (type == "Boat")
                {
                    double weight = theGarage.AskForWeight();
                    toAdd = new Boat(reg, color, nowheels, weight);
                }
                else if (type == "Bus")
                {
                    int passengers = theGarage.AskForPassengers();
                    toAdd = new Bus(reg, color, nowheels, passengers);
                }
                else if (type == "Car")
                {
                    double gasolineconsumption = theGarage.AskForGasolineConsumption();
                    toAdd = new Car(reg, color, nowheels, gasolineconsumption);
                }
                else if (type == "Motorcycle")
                {
                    double topspeed = theGarage.AskForTopSpeed();
                    toAdd = new Motorcycle(reg, color, nowheels, topspeed);
                }
                else return(false); //todo: fix bool error return
                theGarage.Add(toAdd);
            return (true);
            }
                
            void Quit()
            {
                Console.WriteLine("chao!");
                running = false;
            }
        
        void SearchReg()
        {
            Console.Write("\r\n\r\nReg number: ");
            string reg = Console.ReadLine().ToUpper();
            int lookup=theGarage.RegLookup(reg);
            if (lookup < 0) Console.WriteLine("not found!");
            else Console.WriteLine("found at pos: " + lookup);
        }

        void SearchProperties()
        {
            Vehicle toSearch=null;
            Console.WriteLine("\r\n\r\nFill the fields you wanna search, leave rest empty... ");
            Console.Write("type: ");
            string type = Extra.NormalFormatting(Console.ReadLine()); //todo: make formatting correct
            Console.Write("regnr: ");
            string reg = Extra.CAPITALFormatting(Console.ReadLine()); //todo: check formatting
            Console.Write("color: ");
            string color= Extra.CAPITALFormatting(Console.ReadLine().ToUpper()); //todo: check formatting
            Console.Write("number of wheels: ");
            string wheels = Console.ReadLine(); //todo: fix checking
            int nowheels = -1;
            
            if (!string.IsNullOrEmpty(wheels))  //nowheels = Int32.tr(wheels); //todo:  formatting
            {
                if(!Int32.TryParse(wheels, out nowheels))
                {
                    Console.WriteLine("unable to parse");
                }
            }

            if (type == "Airplane") //jag gillar inte den här specifika koden ..
            {
                double maxalt = theGarage.AskForMaxAltitude();
                toSearch = new Airplane(reg, color, nowheels, maxalt); //todo: add with proper layering
            }
            else if (type == "Boat")
            {
                double weight = theGarage.AskForWeight();
                toSearch = new Boat(reg, color, nowheels, weight);
            }
            else if (type == "Bus")
            {
                int passengers = theGarage.AskForPassengers();
                toSearch = new Bus(reg, color, nowheels, passengers);
            }
            else if (type == "Car")
            {
                double gasolineconsumption = theGarage.AskForGasolineConsumption();
                toSearch = new Car(reg, color, nowheels, gasolineconsumption);
            }
            else if (type == "Motorcycle")
            {
                double topspeed = theGarage.AskForTopSpeed();
                toSearch = new Motorcycle(reg, color, nowheels, topspeed);
            }
            else
            {
                toSearch = new Vehicle(reg,color,nowheels);
            }
            
            var searchItems=new Queue<Vehicle>(theGarage.Lookup(toSearch.GetType().Name,
                toSearch.RegNumber,
                toSearch.Color,
                toSearch.NoWheels));

            while(searchItems.Count>0)
            {
                var t = searchItems.Dequeue();
                Console.WriteLine("found: " + t.Color);
            }            
        }
    }   
}