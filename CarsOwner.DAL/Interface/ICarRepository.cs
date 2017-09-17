using System.Collections.Generic;
using CarsOwner.Core.DTO;

namespace CarsOwner.DAL.Interface
{
    public interface ICarRepository
    {
        IEnumerable<CarDTO> GetCarsList();
        CarDTO GetCar(int id);
        void AddOrUpdateCar(CarDTO car);
        void DeteleCar(int id);
        DescriptionCarDTO GetImage(int id);
        void Save(); 
    }
}