using System.Web.Mvc;
using CarsOwner.BLL.Interface;
using CarsOwner.Models;
using CarsOwner.Resource;

namespace CarsOwner.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly IOwnerService _ownerService;

        public CarController(ICarService carService, IOwnerService ownerService)
        {
            _carService = carService;
            _ownerService = ownerService;
        }
        public ActionResult CarView(int id)
        {
            var carModel = new CarViewModel();
            carModel.Car = _carService.GetCarDto(id);
            return View(MethodName.CarView, carModel);
        }
	}
}