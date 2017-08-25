using System.Linq;
using System.Web.Mvc;
using CarsOwner.BLL.Interface;
using CarsOwner.Core.DTO;
using CarsOwner.Models;
using CarsOwner.Resource;

namespace CarsOwner.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService _carService;
        private readonly IOwnerService _ownerService;
        public HomeController(ICarService carService ,IOwnerService ownerService)
        {
            _carService = carService;
            _ownerService = ownerService;
        }
        public ActionResult Index()
        {
            var cars = _carService.GetCarsDtoList();
            var carModel = new CarListViewModel();
            carModel.CarsList = _carService.GetCarsDtoList().ToList();
            return View(carModel);
        }

        public ActionResult ListOwner()
        {
            var ownersList = new OwnerListViewModel();
            var owners = _ownerService.GetOwnersDtoList();
            ownersList.OwnersList = owners.ToList();
            return View("OwnersList", ownersList);
        }

        public ActionResult CarsList()
        {
            var cars = _carService.GetCarsDtoList();
            var carModel = new CarListViewModel();
            carModel.CarsList = _carService.GetCarsDtoList().ToList();
            return View("CarsList", carModel);
        }
        public ActionResult AddOwner()
        {
            ViewBag.ListCar = _carService.GetCarsDtoList();
            return View(MethodName.AddOrUpdateOwner, new OwnerViewModel());
        }
        [HttpPost]
        public ActionResult AddOwner(OwnerViewModel ownerModel, int[] selectedCar)
        {
            OwnerDTO owner = ownerModel.Owner;

            if (ModelState.IsValid)
            {
                _ownerService.AddOrUpdateOwnerDto(owner, selectedCar);
                return RedirectToAction(MethodName.ListOwner);
            }
            ViewBag.ListCar = _carService.GetCarsDtoList();
            return View(MethodName.AddOrUpdateOwner, ownerModel);
        }
       
        public ActionResult EditOwner(int id)
        {
            var ownerModel = new OwnerViewModel();
            ownerModel.Owner = _ownerService.GetOwnerDto(id);

            ViewBag.ListCar = _carService.GetCarsDtoList();
            return View(MethodName.AddOrUpdateOwner, ownerModel);
        }
        [HttpPost]
        public ActionResult EditOwner(OwnerViewModel ownerModel, int[] selectedCar)
        {
            OwnerDTO owner = ownerModel.Owner;
            if (ModelState.IsValid)
            {
                _ownerService.AddOrUpdateOwnerDto(owner, selectedCar);
                return RedirectToAction(MethodName.ListOwner);
            }
            ViewBag.ListCar = _carService.GetCarsDtoList();
            return View(MethodName.AddOrUpdateOwner, ownerModel);
        }

        [HttpGet]
        public ActionResult DeleteOwner(int id)
        {
            _ownerService.DeteleOwnerDto(id);
            return RedirectToAction(MethodName.ListOwner);
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
                return RedirectToAction(MethodName.Index);
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
        public ActionResult EditCar(CarViewModel carModel)
        {
            CarDTO car = carModel.Car;
            if (ModelState.IsValid)
            {
                _carService.AddOrUpdateCarDto(car);
                return RedirectToAction(MethodName.Index);
            }
            return View(MethodName.AddOrUpdateCar, carModel);
            
        }

        [HttpGet]
        public ActionResult DeleteCar(int id)
        {
            _carService.DeteleCarDto(id);
            return RedirectToAction(MethodName.Index);
        }

        public PartialViewResult PartialViewCar(CarDTO carDTO)
        {
            CarViewModel carModel = new CarViewModel {Car = carDTO};
            return PartialView(carModel);
        }
    }
}