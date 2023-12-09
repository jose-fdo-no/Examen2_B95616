using Microsoft.AspNetCore.Mvc;
using SolucionExamen.Models;
using System.Collections.Generic;
using System.Linq;

namespace SolucionExamen.Controllers
{
    public class CoffeeDispenserController : Controller
    {
        private List<CoffeeModel> coffeeList;
        private int totalOrderCost;

        public CoffeeDispenserController()
        {
            // Inicializa la lista de cafés en el constructor
            coffeeList = GetCoffeeList();
            totalOrderCost = 0;
        }

        private List<CoffeeModel> GetCoffeeList()
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

        private List<MoneyModel> GetMoneyList()
        {
            List<MoneyModel> moneyList = new List<MoneyModel>
            {
                new MoneyModel { Id = 0, MoneyValue = 500, MachineQuantity = 20 },
                new MoneyModel { Id = 1, MoneyValue = 100, MachineQuantity = 30 },
                new MoneyModel { Id = 2, MoneyValue = 50, MachineQuantity = 50 },
                new MoneyModel { Id = 3, MoneyValue = 25, MachineQuantity = 25 }
            };
            return moneyList;
        }

        public IActionResult Index()
        {
            ViewBag.MainTitle = "Lista de cafés disponibles";
            return View(coffeeList);
        }

        [HttpPost]
        public IActionResult Ordenar(Dictionary<string, string> coffeeOrder)
        {
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
                            totalOrderCost += quantity * cafe.CoffeePrice;
                        }
                    }
                }
            }
            return RedirectToAction("Index", coffeeList);
        }
    }
}
