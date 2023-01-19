using FoodBasketApp.Entities;

namespace FoodBasketApp.Services
{
    public class FoodService
    {
        public static string[] FoodCategories = new string[] { "Fruit", "Vegetable", "Meat", "Fish", "Poultry" };

        static FoodService()
        {
            _foodItems.Add(new FoodItem() { Id = GetNextId(), Category = "Fruit", Name = "Apples" });
            _foodItems.Add(new FoodItem() { Id = GetNextId(), Category = "Meat", Name = "Beef tenderloin" });
            _foodItems.Add(new FoodItem() { Id = GetNextId(), Category = "Fruit", Name = "Raspberries" });
            _foodItems.Add(new FoodItem() { Id = GetNextId(), Category = "Fish", Name = "Salmon" });
        }

        public static int GetNextId()
        {
            return _foodItems.Count + 1;
        }

        public int AddFoodItem(FoodItem foodItem)
        {
            int newId = GetNextId();
            foodItem.Id = newId;
            _foodItems.Add(foodItem);
            return newId;
        }

        public List<FoodItem> GetAllFoodItems()
        {
            return _foodItems;
        }

        public FoodItem GetFoodItemById(int foodItemId)
        {
            return _foodItems.FirstOrDefault(fi => fi.Id == foodItemId);
        }

        public void DeleteFoodItemById(int foodItemId)
        {
            var itemToDelete = _foodItems.FirstOrDefault(fi => fi.Id == foodItemId);
            _foodItems.Remove(itemToDelete);
        }

        public void UpdateFoodItem(FoodItem foodItem)
        {
            DeleteFoodItemById(foodItem.Id);
            _foodItems.Add(foodItem);
        }

        public List<FoodItem> GetFoodItemsByCategory(string category)
        {
            return _foodItems.Where(fi => fi.Category.ToLower() == category.ToLower()).ToList();
        }

        private static List<FoodItem> _foodItems = new List<FoodItem>();
    }
}
