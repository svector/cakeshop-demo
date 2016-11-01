using System.Linq;
using CakeShopData;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CakeshopUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICakeRepository _cakeRepository;

        public HomeController(ICakeRepository cakeRepository)
        {
            _cakeRepository = cakeRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var cakes = _cakeRepository.GetCakes().ToArray();
            return View(new CakesViewModel() {Cakes = cakes });
        }
    }
}
