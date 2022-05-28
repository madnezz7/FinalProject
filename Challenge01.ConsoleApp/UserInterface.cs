using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge01.Repository;

namespace Challenge01.ConsoleApp
{
    public class UserInterface
    {

        MenuRepository _menuRepo = new MenuRepository();

        bool isRunning = true;

        public void Run()
        {
            _menuRepo.SeedMenuData();

            while (isRunning == true)
            {
                PrintMainMenu();

                string input = GetInputFromUser();

                UserInputSwitchCase(input);
            }
        }

        public string GetInputFromUser()
        {
            Console.WriteLine("Enter Selection... ");
            return Console.ReadLine();
        }

        private void PrintMainMenu()
        {
            Console.WriteLine(
                "1. *View Menu* \n" +
                "2. *Add Item to Menu* \n" +
                "3. *Delete Item from Menu* \n" +
                "4. *Exit Application* \n"
            );

        }

        private void UserInputSwitchCase(string input)
        {
            switch (input)
            {
                case "1":
                    ViewAllMenuItems();
                    break;
                case "2":
                    AddMenuItemToMenu();
                    break;
                case "3":
                    DeleteMenuItemFromMenu();
                    break;
                case "4":
                    isRunning = false;
                    ExitApplication();
                    break;
                default:
                    break;
            }
        }


        private void ExitApplication()
        {
            Console.WriteLine("We Hope to see you agin soon here at KOMODO CAFE!!! \n" + "Press any key...");
            Console.ReadKey();
        }

        private void ViewAllMenuItems()
        {
            List<MenuItem> allMenuItems = _menuRepo.GetAllMenuItemsFromList();

            foreach (MenuItem x in allMenuItems)
            {
                PrintMenuItem(x);
            }
            Console.WriteLine("Press enter when finished here");
            Console.ReadKey();
        }

        private void PrintMenuItem(MenuItem menuItem)
        {
            Console.WriteLine(
                $"#{menuItem.MealNumber}\n" +
                $"\n{menuItem.MealName}\n" +
                $"\n{menuItem.MealDescription}\n" +
                $"\nINGREDIENTS - {menuItem.MealIngredients}\n" +
                $"\nPRICE - ${menuItem.MealPrice}\n"
            );
        }

        private void DeleteMenuItemFromMenu()
        {
            Console.WriteLine("Enter the name of Dish to delete");
            string input = GetInputFromUser();

            bool success = _menuRepo.DeleteMenuItemByMealName(input);

            if (success)
            {
                Console.WriteLine("Item Deleted......Press enter when finished here.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Couldn't find that Komodo dish.......Press enter when finished here.");
                Console.ReadKey();
            }
        }


        private void AddMenuItemToMenu()
        {
            Console.WriteLine("To add a new dish to the menu, please enter the NAME OF THE DISH now.");
            string mealName = GetInputFromUser();

            Console.WriteLine("Now enter the DISH DESCRIPTION here.");
            string mealDescription = GetInputFromUser();

            Console.WriteLine("Now enter the list of INGREDIENTS here(separated by a comma ',')");
            string mealIngredients = GetInputFromUser();

            Console.WriteLine("Now enter the PRICE OF THE MEAL here.");
            decimal mealPrice = Convert.ToDecimal(GetInputFromUser());

            Console.WriteLine("To add a new dish to the menu, please enter the NUMBER OF THE DISH now.");
            int mealNumber = Convert.ToInt32(GetInputFromUser());


            MenuItem newMenuItem = new MenuItem(mealNumber, mealName, mealDescription, mealIngredients, mealPrice);

            _menuRepo.AddMenuItemToList(newMenuItem);
        }

    }
}