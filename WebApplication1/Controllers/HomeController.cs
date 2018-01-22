using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData,
                               IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }
        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greeter.GetMessageOftheDay();

            //returns object in json
            //return new ObjectResult(model);

            return View(model);

            //return Content("Hello from the Home Controller");
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);

            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);

        }
    }
}
