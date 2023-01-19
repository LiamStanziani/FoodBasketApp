using Microsoft.AspNetCore.Mvc;

using FoodBasketApp.Entities;
using FoodBasketApp.Models;
using FoodBasketApp.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography.X509Certificates;

namespace FoodBasketApp.Controllers
{
    public class FoodController : Controller
    {
        public FoodItem emptyFood;
        public string[] arrayCategories = new string[4];

        public FoodController(FoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet("/food-items/{category?}")]
        public IActionResult Items(string category)
        {
            List<FoodItem> foodItems;

            if (string.IsNullOrEmpty(category) || category == "All") 
            {
                foodItems = _foodService.GetAllFoodItems();
            }
            else
            {
                foodItems = _foodService.GetFoodItemsByCategory(category);
            }
                
            // Create & initialize a view model:
            FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel()
            {
                ListOfFoodItems = foodItems,
                CurrentlyActive =  category,
                TabNames = FoodService.FoodCategories,
                NewFoodItem = emptyFood
            };

            return View("Items", foodItemsViewModel);
        }

        [HttpPost("/food-items")]
        public IActionResult AddNewFoodItem(FoodItemsViewModel viewModel)
        {
            _foodService.AddFoodItem(viewModel.NewFoodItem);

            return RedirectToAction("Items", viewModel);
        }

        private FoodService _foodService;
    }
}
