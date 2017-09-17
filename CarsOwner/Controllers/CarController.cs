using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarsOwner.BLL.Interface;
using CarsOwner.Core.DTO;
using CarsOwner.Models;
using CarsOwner.Resource;

namespace CarsOwner.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        public ActionResult CarsList()
        {
            var cars = _carService.GetCarsDtoList();
            var carModel = new CarListViewModel();
            carModel.CarsList = _carService.GetCarsDtoList().ToList();
            return View(MethodName.CarsList, carModel);
        }
        public ActionResult CarView(int id)
        {
            var carModel = new CarViewModel();
            carModel.Car = _carService.GetCarDto(id);
            return View(MethodName.CarView, carModel);
        }

        public FileContentResult GetImage(int id)
        {
            var image =  _carService.GetImage(id);
            if (image != null)
            {
                return File(image.ImageData, image.ImageMineType);
            }
            else
            {
                return null;
            }
        }

        public ActionResult AddCar()
        {
            return View(MethodName.AddOrUpdateCar, new CarViewModel());
        }

        [HttpPost]
        public ActionResult AddCar(CarViewModel carModel)
        {
            CarDTO car = carModel.Car;
            if (ModelState.IsValid)
            {
                _carService.AddOrUpdateCarDto(car);
                return RedirectToAction(MethodName.Index, ControllerName.Home);
            }
            return View(MethodName.AddOrUpdateCar, carModel);

        }
        [HttpGet]
        public ActionResult EditCar(int id)
        {
            var carModel = new CarViewModel();
            carModel.Car = _carService.GetCarDto(id);
            return View(MethodName.AddOrUpdateCar, carModel);
        }
        [HttpPost]
        public ActionResult EditCar(CarViewModel carModel, HttpPostedFileBase image)
        {
            CarDTO car = carModel.Car;
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    carModel.Car.DescriptionCar.ImageData = new byte[image.ContentLength];
                    carModel.Car.DescriptionCar.ImageMineType = image.ContentType;
                    image.InputStream.Read(carModel.Car.DescriptionCar.ImageData, 0, image.ContentLength);
                }
                _carService.AddOrUpdateCarDto(car);
                return RedirectToAction(MethodName.Index, ControllerName.Home);
            }
            return View(MethodName.AddOrUpdateCar, carModel);

        }
        [HttpGet]
        public ActionResult DeleteCar(int id)
        {
            _carService.DeteleCarDto(id);
            return RedirectToAction(MethodName.Index, ControllerName.Home);
        }
	}
}