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
            coffeeList = GetCoffeeList();
            totalOrderCost = 0;
        }

        /// <summary>
        /// Crea la lista de cafés con los valores dados en el enunciado
        /// </summary>
        /// <returns>La lista de cafés creada</returns>
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

        /// <summary>
        /// Crea la lista del dinero disponible para vuelto
        /// con los valores dados en el enunciado
        /// </summary>
        /// <returns>La lista del dinero para vueltos</returns>
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

        /// <summary>
        /// Vista de la página del sistema web
        /// </summary>
        /// <returns>Regresa a la misma vista</returns>
        public IActionResult Index()
        {
            ViewBag.MainTitle = "Lista de cafés disponibles";
            ViewBag.TotalOrderCost = 0;
            return View(coffeeList);
        }

        /// <summary>
        /// Acción de realizar una orden en el sistema web
        /// </summary>
        /// <param name="coffeeOrder">Diccionario hecho al momento de realizar la orden</param>
        /// <returns>Redirige a la página del inicio nuevamente</returns>
        [HttpPost]
        public IActionResult MakeShopOrder(Dictionary<string, string> coffeeOrder)
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
            ViewBag.TotalOrderCost = totalOrderCost;
            return RedirectToAction("Index", coffeeList);
        }
    }
}
