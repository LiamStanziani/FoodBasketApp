using FoodBasketApp.Entities;

namespace FoodBasketApp.Models
{
    public class FoodItemsViewModel
    {
        // A list of FoodItem objects that represent the food items to be shown for the current tab
        public List<FoodItem> ListOfFoodItems { get; set; }

        // An array of strings that represents all the tab names
        public string[] TabNames { get; set; }

        // A string representing the currently active category (tab name)
        public string CurrentlyActive { get; set; }

        // A FoodItem object that represents the newly submitted food item when the user is adding a new food item using the form
        public FoodItem NewFoodItem { get; set; }


    }
}
