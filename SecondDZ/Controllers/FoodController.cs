using Microsoft.AspNetCore.Mvc;
using SecondDZ.Interfaces;
using SecondDZ.Models;

namespace SecondDZ.Controllers
{
    public class FoodController : Controller
    {
        private readonly IFoodService _service;

        public FoodController(IFoodService service)
        {
            _service = service;
        }

        public IActionResult GetFood()
        {
            return View(_service.GetFood());
        }
        public IActionResult AddFood()
        {
            return View();
        }
        public IActionResult UpdateFood(int id)
        {
            Food meal = _service.Meals.First(m => m.Id == id);
            return View(meal);
        }

        [HttpPost]
        public IActionResult RemoveFood(int id)
        {
            _service.RemoveFood(id);
            return RedirectToAction(nameof(GetFood));
        }
        [HttpPost]
        public IActionResult AddFood(Food meal)
        {
            _service.AddFood(meal);
            return RedirectToAction(nameof(GetFood));
        }
        [HttpPost]
        public IActionResult UpdateFood(Food meal)
        {
            _service.UpdateFood(meal);
            return RedirectToAction(nameof(GetFood));
        }
    }
}
