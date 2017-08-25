using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
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
            //if (carsList.Count != 0)
            //{
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
                    foreach (var owner in carEntity.Find(car.IdCar).OwnerEntities)
                    {
                        car.OwnerList.Add(new OwnerDTO()
                        {
                            Name = owner.Name,
                            Surname = owner.Surname
                        });
                    }
                
                }
                return carsList;
            //}
            //else
            //{
            //    return null;
            //}
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

            return carDto;
        }

        public void AddOrUpdateCar(CarDTO car)
        {
            var carEntity = new CarEntity()
            {
                IdCar = car.IdCar,
                Model = car.Model,
                Price = car.Price,
                YearRelease = car.YearRelease,
                TypeCar = (byte)car.TypeCar,
                СarMake = car.СarMake
            };
            _carOwnerContext.Cars.AddOrUpdate(carEntity);
        }

        public void DeteleCar(int id)
        {
            var carEntity = _carOwnerContext.Cars.Find(id);
            _carOwnerContext.Cars.Remove(carEntity);
        }

        public void Save()
        {
            _carOwnerContext.SaveChanges();
        }
    }
}
