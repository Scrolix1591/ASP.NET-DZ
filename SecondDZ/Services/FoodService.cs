using SecondDZ.Interfaces;
using SecondDZ.Models;

namespace SecondDZ.Services
{
    public class FoodService : IFoodService
    {
        public List<Food> Meals { get; set; } = new List<Food>
        {
            new Food {Id = 0, Name = "Kurochka", Weight = 5, Cost = 150},
            new Food {Id = 1, Name = "Jablochko", Weight = 1, Cost = 10},
            new Food {Id = 2, Name = "Rybonka", Weight = 3, Cost = 500},
            new Food {Id = 3, Name = "SystemError", Weight = 999999999, Cost = 999999999},
        };

        public void AddFood(Food meal)
        {
            Meals.Add(meal);
        }

        public List<Food> GetFood()
        {
            return Meals;
        }

        public void RemoveFood(int id)
        {
            Meals.Remove(Meals.First(m => m.Id == id));
        }

        public void UpdateFood(Food meal)
        {
            int index = Meals.IndexOf(Meals.First(m => m.Id == meal.Id));
            Meals[index] = meal;
        }
    }
}
