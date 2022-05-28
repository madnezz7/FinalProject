using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge01.Repository;


namespace Challenge01.Repository
{
    public class MenuRepository
    {
        // Fake Database
        private List<MenuItem> _menuItemList = new List<MenuItem>();


        //CRUD
        // CREATE / READ / UPDATE(not for this one) / DELETE


        // CREATE
        public void AddMenuItemToList(MenuItem menuItem)
        {
            _menuItemList.Add(menuItem);
        }


        // READ
        public List<MenuItem> GetAllMenuItemsFromList()
        {
            return _menuItemList;
        }

        // public MenuItem GetMenuItemFromListByName(string userInputMealNameSearch)
        // {
        //     foreach (MenuItem menuItem in _menuItemList)
        //     {
        //         if (menuItem.MealName.ToUpper() == userInputMealNameSearch.ToUpper())
        //         {
        //             return menuItem;
        //         }
        //     }
        //     return null;
        // }

        // public MenuItem GetMenuItemFromListByMealNumber(int userInputMealNumberSearch)
        // {
        //     foreach (MenuItem menuItem in _menuItemList)
        //     {
        //         if (menuItem.MealNumber == userInputMealNumberSearch)
        //         {
        //             return menuItem;
        //         }
        //     }
        //     return null;
        // }


        // UPDATE(not for this one)


        // DELETE
        public bool DeleteMenuItemByMealName(string userInputMealNameSearch)
        {
            foreach (MenuItem menuItem in _menuItemList)
            {
                if (menuItem.MealName.ToUpper() == userInputMealNameSearch.ToUpper())
                {
                    _menuItemList.Remove(menuItem);
                    return true;
                }
            }
            return false;
        }


        // SEED DATA

        public void SeedMenuData()
        {
            MenuItem komodoTacos = new MenuItem(1, "KOMODO TACOS", "Ground beef or chicken served inside a crispy hard shell with all the fixings!", ("Chicken or Beef, Hard or Soft Shells, Lettuce, Pico de Gallo, Sour Cream1"), 9.99m);
            MenuItem dragonBurger = new MenuItem(2, "DRAGON BURGER", "Angus beef burger topped with lettuce, red onion, tomato, and our special fiery dragon sauce!", ("Beef, Lettuce, Tomatoe, Red Onion, Fire Sauce"), 12.49m);
            MenuItem sushiCastle = new MenuItem(3, "SUSHI CASTLE", "A Tower of our Special Dragon Rolls", ("Rice, Seaweed, Dragon Sauce, Salmon, Avacado"), 17.99m);
            MenuItem komodoLoadedFries = new MenuItem(4, "KOMODO LOADED FRIES", "A specially hand crafted mix of fiery ingredients atop a tower of sweet potatoe waffle fries!", ("Sweet Potatoe Waffle Fries, Fire Sauce, Applewood Smoked Bacon, Chives, Jalapenos, Queso Cheese"), 9.99m);
            MenuItem fireSalad = new MenuItem(5, "FIRE SALAD", "Fire grilled chicken cooked to perfection atop a sea of mixed greens and special fiery ingredients!", ("Grilled Chicken, Mixed Greens, Red Onions, Grape Tomatoes, Muenster Cheese, Sweet Fiery Dressing"), 11.99m);


            MenuItem[] menuArr = { komodoTacos, dragonBurger, sushiCastle, komodoLoadedFries, fireSalad };

            foreach (MenuItem x in menuArr)
            {
                AddMenuItemToList(x);
            }
        }

    }
}