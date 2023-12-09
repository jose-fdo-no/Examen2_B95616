using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SolucionExamen.Models
{
    public class CoffeeModel : Controller
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La cantidad es requerida.")]
        public int CoffeeQuantity { get; set; }
        public string CoffeeType { get; set; }
        public int CoffeePrice { get; set; }
        
        public IActionResult Index(List<CoffeeModel> cofeeList)
        {
            return View(cofeeList);
        }
    }
}
