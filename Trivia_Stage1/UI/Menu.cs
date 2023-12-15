using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia_Stage1.UI
{
    class MenuItem
    {
        public string MenuTitle { get; set; }
        public Screen Screen { get; set; }
        public MenuItem() { }
        public MenuItem(string title, Screen screen)
        {
            MenuTitle = title;
            Screen = screen;
        }
    }
    class Menu:Screen
    {
        //List contains all menu items
        private List<MenuItem> items;
        public Menu(string title):base(title) 
        {
            this.items = new List<MenuItem>();
        }
        //Use this methos to add an item to the menu
        public void AddItem(string title, Screen screen)
        {
            items.Add(new MenuItem(title, screen));
        }
        //Show the menu on screen!
        public override void Show()
        {
            bool exit = false;
            while (!exit) //Loop until user press the exit option (last option)
            {
                base.Show();
                Console.WriteLine("");
                int count = 1;
                foreach (MenuItem item in items)
                {
                    Console.WriteLine($"\t{count}.\t{item.MenuTitle}");
                    count++;
                }
                Console.WriteLine($"\t{count}.\tExit");
                Console.Write($"Please choose (1 - {count}):");
                int option = 0;
                int.TryParse(Console.ReadLine(), out option);
                if (option >= 1 && option <= count)
                {
                    if (option == count)//Exit
                        exit = true;
                    else
                        this.items[option - 1].Screen.Show(); //Show selected screen!
                }
            }
        }
    }
}
