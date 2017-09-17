using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using CarsOwner.Core.DTO;
using CarsOwner.Core.Enum;
using CarsOwner.DAL.EF;
using CarsOwner.DAL.Entites;
using CarsOwner.DAL.Interface;

namespace CarsOwner.DAL.Repository
{
    public class CarRepository: ICarRepository
    {
        private readonly CarOwnerContext _carOwnerContext;

        public CarRepository(CarOwnerContext carOwnerContext)
        {
            _carOwnerContext = carOwnerContext;
        }
        public IEnumerable<CarDTO> GetCarsList()
        {
            var carEntity = _carOwnerContext.Cars;
            var carsList = new List<CarDTO>();
            foreach (var car in carEntity)
            {
                carsList.Add(new CarDTO()
                {
                    IdCar = car.IdCar,
                    Model = car.Model,
                    Price = car.Price,
                    YearRelease = car.YearRelease,
                    TypeCar = (TypeCar)car.TypeCar,
                    СarMake = car.СarMake
                });
            }
            

            foreach (var car in carsList)
            {
                var owers = carEntity.Find(car.IdCar).OwnerEntities;
                if(owers != null)
                {
                    foreach (var owner in owers)
                    {
                        car.OwnerList.Add(new OwnerDTO()
                        {
                            Name = owner.Name,
                            Surname = owner.Surname
                        });
                    }
                }

                var description = carEntity.Find(car.IdCar).DescriptionCar;
                car.DescriptionCar.Description = description.Description;
                car.DescriptionCar.ImageData = description.ImageData;

            }
            return carsList;
        }

        public CarDTO GetCar(int id)
        {
            var carEntity = _carOwnerContext.Cars.Find(id);
            var carDto = new CarDTO()
            {
                IdCar = carEntity.IdCar,
                Model = carEntity.Model,
                Price = carEntity.Price,
                YearRelease = carEntity.YearRelease,
                TypeCar = (TypeCar)carEntity.TypeCar,
                СarMake = carEntity.СarMake,
            };

            foreach (var owner in carEntity.OwnerEntities)
            {
                carDto.OwnerList.Add(new OwnerDTO()
                {
                    Name = owner.Name,
                    Surname = owner.Surname
                });
                
                
            }
            carDto.DescriptionCar.ImageData = carEntity.DescriptionCar.ImageData;
            //carDto.DescriptionCar.ImageMineType = carEntity.DescriptionCar.ImageMineType;
            carDto.DescriptionCar.Description = carEntity.DescriptionCar.Description;
            return carDto;
        }

        public void AddOrUpdateCar(CarDTO car)
        {
            var carEntity = new CarEntity();

            if (car.IdCar != 0)
            {
                carEntity = _carOwnerContext.Cars.Find(car.IdCar);
                carEntity.DescriptionCar.Description = car.DescriptionCar.Description;
            }
            else
            {  
                carEntity.DescriptionCar = new DescriptionCarEntity()
                {
                    Description = car.DescriptionCar.Description,
                    ImageData = car.DescriptionCar.ImageData,
                    ImageMineType = car.DescriptionCar.ImageMineType
                }; 
            }

            if (car.DescriptionCar.ImageData != null)
            {
                carEntity.DescriptionCar.ImageData = car.DescriptionCar.ImageData;
                carEntity.DescriptionCar.ImageMineType = car.DescriptionCar.ImageMineType;
            }

            carEntity.IdCar = car.IdCar;
            carEntity.Model = car.Model;
            carEntity.Price = car.Price;
            carEntity.YearRelease = car.YearRelease;
            carEntity.TypeCar = (byte)car.TypeCar;
            carEntity.СarMake = car.СarMake;
            
           _carOwnerContext.Cars.AddOrUpdate(carEntity);
        }

        public void DeteleCar(int id)
        {
            var carEntity = _carOwnerContext.Cars.Find(id);
            _carOwnerContext.Cars.Remove(carEntity);
        }

        public DescriptionCarDTO GetImage(int id)
        {
            var descriptionDto = new DescriptionCarDTO();
            var descriptionEntity = _carOwnerContext.DescriptionCars.Find(id);
            if (descriptionEntity != null)
            {
                descriptionDto.ImageData = descriptionEntity.ImageData;
                descriptionDto.ImageMineType = descriptionEntity.ImageMineType;
            }
            return descriptionDto;
        }
        public void Save()
        {
            _carOwnerContext.SaveChanges();
        }
    }
}
