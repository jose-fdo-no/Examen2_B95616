using Microsoft.AspNetCore.Mvc;
using SolucionExamen.Models;
using System.Collections.Generic;
using System.Linq;

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
            List<CoffeeModel> coffeeList = new List<CoffeeModel>
            {
                new CoffeeModel { Id = 0, CoffeeQuantity = 10, CoffeeType = "Americano", CoffeePrice = 850 },
                new CoffeeModel { Id = 1, CoffeeQuantity = 8, CoffeeType = "Capuchino", CoffeePrice = 950 },
                new CoffeeModel { Id = 2, CoffeeQuantity = 10, CoffeeType = "Latte", CoffeePrice = 1150 },
                new CoffeeModel { Id = 3, CoffeeQuantity = 15, CoffeeType = "Mocachino", CoffeePrice = 1300 }
            };

            return coffeeList;
        }

        [HttpPost]
        public IActionResult Ordenar(Dictionary<string, string> coffeeOrder)
        {
            var coffeeList = GetListOfCoffees();

            foreach (var entry in coffeeOrder)
            {
                int coffeeId;
                if (int.TryParse(entry.Key, out coffeeId))
                {
                    string quantityString = entry.Value;

                    if (!int.TryParse(quantityString, out int quantity))
                    {
                        return RedirectToAction("Error");
                    }
                    else
                    {
                        var cafe = coffeeList.FirstOrDefault(c => c.Id == coffeeId);
                        if (cafe != null)
                        {
                            cafe.CoffeeQuantity -= quantity;
                        }
                    }
                }
            }
            return RedirectToAction("Index", coffeeList);
        }
    }
}
