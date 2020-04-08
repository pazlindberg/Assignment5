using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
    public class MenuMap
    {
        public string Text { get; set; }
        public Action ToInvoke { get; set; }

        public MenuMap(string txt, Action toInvoke)
        {
            Text = txt;
            ToInvoke = toInvoke;
        }
    }

    public class Menu
    {
        public string Name { get; set; }
        public Dictionary<char, MenuMap> menuOptions = new Dictionary<char, MenuMap>();
        public int Count { get; set; }


        public Menu(string name, Dictionary<char, MenuMap> mOpts)
        {
            this.Name = name;
            foreach (var ch in mOpts.Keys)
            {
                menuOptions.Add(ch, mOpts.GetValueOrDefault(ch));
            }
            this.Count = menuOptions.Count; //get/set?
        }

        public void Print()
        {
            //Console.Clear();
            Console.WriteLine("\n\n\t{0}", Name);
            foreach (var ch in menuOptions.Keys)
            {
                Console.WriteLine($"{ch} - {menuOptions.GetValueOrDefault(ch).Text}");
            }
        }
    }
}