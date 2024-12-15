using System.Collections;
using System.ComponentModel;
using SecondDZ.Models;

namespace SecondDZ.Interfaces
{
    public interface IFoodService
    {
        List<Food> Meals { get; set; }
        public List<Food> GetFood();
        public void AddFood(Food meal);
        public void UpdateFood(Food meal);
        public void RemoveFood(int id);
    }
}
