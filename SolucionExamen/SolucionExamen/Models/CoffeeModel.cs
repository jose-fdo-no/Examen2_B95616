using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SolucionExamen.Models
{
    public class CoffeeModel
    {
        public int Id { get; set; }
        public int CoffeeQuantity { get; set; }
        public string CoffeeType { get; set; }
        public int CoffeePrice { get; set; }
    }
}
