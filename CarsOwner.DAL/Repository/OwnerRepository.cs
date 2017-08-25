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
    public class OwnerRepository: IOwnerRepository
    {
        private readonly CarOwnerContext _carOwnerContext;

        public OwnerRepository(CarOwnerContext carOwnerContext)
        {
            _carOwnerContext = carOwnerContext;
        }
        public IEnumerable<OwnerDTO> GetOwnersList()
        {
            var ownerEntity = _carOwnerContext.Owners;
            var ownersList = new List<OwnerDTO>();

            foreach (var owner in ownerEntity)
            {
                ownersList.Add(new OwnerDTO()
                {
                    IdOwner = owner.IdOwner,
                    Name = owner.Name,
                    Surname = owner.Surname,
                    BirthDate = owner.BirthDate,
                    DrivingExperience = owner.DrivingExperience
                });
            }

            foreach (var owner in ownersList)
            {
                foreach (var car in ownerEntity.Find(owner.IdOwner).CarEntities)
                {
                    owner.CarList.Add(new CarDTO()
                    {
                        IdCar = car.IdCar,
                        Model = car.Model,
                        СarMake = car.СarMake
                    });
                }
            }
            return ownersList;
        }

        public OwnerDTO GetOwner(int id)
        {
            var ownerEntity = _carOwnerContext.Owners.Find(id);
            var ownerDto = new OwnerDTO()
            {
                IdOwner = ownerEntity.IdOwner,
                Name = ownerEntity.Name,
                Surname = ownerEntity.Surname,
                BirthDate = ownerEntity.BirthDate,
                DrivingExperience = ownerEntity.DrivingExperience,
            };

            var carsOwner = ownerEntity.CarEntities;
            foreach (var car in carsOwner)
            {
                ownerDto.CarList.Add(new CarDTO()
                {
                    IdCar = car.IdCar,
                    Model = car.Model,
                    СarMake = car.СarMake,
                });
            }

            return ownerDto;
        }

        public void AddOrUpdateOwner(OwnerDTO owner, int[] seleceedCars)
        {
            var carsEntity = _carOwnerContext.Cars;
            var ownerEntity = new OwnerEntity();

            if (owner.IdOwner != 0)
            {
                ownerEntity = _carOwnerContext.Owners.Find(owner.IdOwner);
            }
           
            ownerEntity.Name = owner.Name;
            ownerEntity.Surname = owner.Surname;
            ownerEntity.BirthDate = owner.BirthDate;
            ownerEntity.DrivingExperience = owner.DrivingExperience;

            ownerEntity.CarEntities.Clear();

            if (seleceedCars != null)
            {
                foreach (var car in carsEntity.Where(c => seleceedCars.Contains(c.IdCar)))
                {
                    ownerEntity.CarEntities.Add(car);
                }
            }
           
            _carOwnerContext.Owners.AddOrUpdate(ownerEntity);
        }

        public void DeteleOwner(int id)
        {
            var ownerEntity = _carOwnerContext.Owners.Find(id);
            _carOwnerContext.Owners.Remove(ownerEntity);
        }

        public void Save()
        {
            _carOwnerContext.SaveChanges();
        }

    }
}
