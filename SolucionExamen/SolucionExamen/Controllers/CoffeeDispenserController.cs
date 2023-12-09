using Microsoft.AspNetCore.Mvc;
using SolucionExamen.Models;

namespace SolucionExamen.Controllers
{
    public class CoffeeDispenserController : Controller
    {
        public IActionResult Index()
        {
            var coffeeList = GetListOfCoffees();
            ViewBag.MainTitle = "Lista de cafés disponibles";
            return View(coffeeList);
        }

        private List<CoffeeModel> GetListOfCoffees()
        {
            List<CoffeeModel> coffeeList = new List<CoffeeModel>();
            coffeeList.Add(new CoffeeModel { Id = 0, CoffeeQuantity = 10, CoffeeType = "Americano", CoffeePrice = 850 });
            coffeeList.Add(new CoffeeModel { Id = 1, CoffeeQuantity = 8, CoffeeType = "Capuchino", CoffeePrice = 950 });
            coffeeList.Add(new CoffeeModel { Id = 2, CoffeeQuantity = 10, CoffeeType = "Late", CoffeePrice = 1150 });
            coffeeList.Add(new CoffeeModel { Id = 3, CoffeeQuantity = 15, CoffeeType = "Mocachino", CoffeePrice = 1300 });

            return coffeeList;
        }
    }
}
