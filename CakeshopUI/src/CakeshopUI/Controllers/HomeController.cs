using System.Linq;
using CakeShopData;
using Microsoft.AspNetCore.Mvc;
using CakeShopData.Model;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CakeshopUI.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ICakeRepository _cakeRepository;

        public HomeController()
        {
            
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var cakes = new Cake[]
            {
                new Cake() { Id=1, Description="Cake1", Price=9.99m}
            };
            return View(new CakesViewModel() {Cakes = cakes });
        }
    }
}
