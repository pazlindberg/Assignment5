using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
    class MenuMap
    {
        public string Text { get; set; }
        public Action ToInvoke { get; set; }
        public MenuMap(string txt, Action toInvoke)
        {
            Text = txt;
            ToInvoke = toInvoke;
        }
    }

    class Menu
    {
        public string Name { get; set; }
        public Dictionary<char, MenuMap> menuOptions = new Dictionary<char, MenuMap>();

        public Menu(string name, Dictionary<char, MenuMap> mOpts)
        {
            this.Name = name;
            foreach(var ch in mOpts.Keys)
            {
                menuOptions.Add(ch, mOpts.GetValueOrDefault(ch));
            }
        }

        public void Print()
        {
            //Console.Clear();
            Console.WriteLine("\n\n\t{0}",Name);
            foreach(var ch in menuOptions.Keys)
            {
                Console.WriteLine($"{ch} - {menuOptions.GetValueOrDefault(ch).Text}");
            }
            
        }
    }

    class UI
    {
        Menu mainMenu;

        private void Init()
        {
            mainMenu = new Menu("main", new Dictionary<char, MenuMap>   {

                {'q', new MenuMap("End program", Quit) },
                {'a', new MenuMap("Dummy1", Quit) },
                {'d', new MenuMap("Dummy2", Quit)}
                
            });
            
                
        }

        public void Run()
        {
            Init();
            mainMenu.Print();
            //foreach (char ch in mainMenu.menuOptions.Keys)
            //{
            //    Console.WriteLine(ch + " -> " + mainMenu.menuOptions.GetValueOrDefault(ch).Method);
            //}
            //mainMenuOptions['q'].Invoke();
        }

        static void Quit()
        {
            Console.WriteLine("chao!");
        }
    }

    
}
 
//todo:     if time, write a generally usable menu interface that of a key-/value-combination
//              (char input-key <-> menu option[and delegate, so pref. own defined obj as value]

