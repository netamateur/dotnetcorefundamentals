using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        public IActionResult Index()
        {
            var model = _restaurantData.GetAll();

            //returns object in json
            //return new ObjectResult(model);

            return View(model);

            //return Content("Hello from the Home Controller");
        }
    }
}
