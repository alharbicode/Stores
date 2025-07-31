using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace CLINT.Models
{
    public class multiplemodel : Controller
    {
        /*public IActionResult Index()
 {
     return View();
 }*/
        public Item? Store { get; set; }
        public IEnumerable IEnumerable { get; set; }
    }
}
