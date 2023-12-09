using Microsoft.AspNetCore.Mvc;

namespace SolucionExamen.Models
{
    public class CoffeeModel : Controller
    {
        public int Id { get; set; } 
        public int CoffeeQuantity { get; set; }
        public string CoffeeType { get; set; }
        public int CoffeePrice { get; set; }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
