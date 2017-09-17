using System.Linq;
using System.Web.Mvc;
using CarsOwner.BLL.Interface;
using CarsOwner.Core.DTO;
using CarsOwner.Models;
using CarsOwner.Models.Enum;
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
        public ActionResult Index(int page = 1, int pageSize = 6)
        {
            var carModel = new CarListViewModel();
            var carsTotal = _carService.GetCarsDtoList().ToList();
            carModel.CarsList = carsTotal.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            carModel.PageInfo = new PageInfo() { PageNumber = page, PageSize = pageSize, TotalItems = carsTotal.Count() };
            carModel.PageSizeEnum = pageSize == ConstantNames.PageSizeSix ? 
                EnumPageSize.PageSizeSix : EnumPageSize.PageSizeTwelve;
            
            if (Request.IsAjaxRequest())
            {
                return PartialView(MethodName.PartialViewCar, carModel);
            }
            return View(carModel);
        }

        public ActionResult ListOwner()
        {
            var ownersList = new OwnerListViewModel();
            var owners = _ownerService.GetOwnersDtoList();
            ownersList.OwnersList = owners.ToList();
            return View(MethodName.OwnersList, ownersList);
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
                return RedirectToAction(MethodName.OwnersList);
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
                return RedirectToAction(MethodName.OwnersList);
            }
            ViewBag.ListCar = _carService.GetCarsDtoList();
            return View(MethodName.AddOrUpdateOwner, ownerModel);
        }

        [HttpGet]
        public ActionResult DeleteOwner(int id)
        {
            _ownerService.DeteleOwnerDto(id);
            return RedirectToAction(MethodName.OwnersList);
        }

        public PartialViewResult PartialViewCar(CarListViewModel carListViewModel)
        {
            return PartialView(carListViewModel);
        }

        public ActionResult WhatNew()
        {
            return View();
        }
    }
}