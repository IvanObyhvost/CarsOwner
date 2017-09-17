using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsOwner.BLL.Interface;
using CarsOwner.Core.DTO;
using CarsOwner.DAL.Interface;

namespace CarsOwner.BLL.Services
{
    public class CarService: ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public IEnumerable<CarDTO> GetCarsDtoList()
        {
            return _carRepository.GetCarsList();
        }

        public CarDTO GetCarDto(int id)
        {
            return _carRepository.GetCar(id);
        }

        public void AddOrUpdateCarDto(CarDTO carDto)
        {
            _carRepository.AddOrUpdateCar(carDto);
            _carRepository.Save();
        }

        public DescriptionCarDTO GetImage(int id)
        {
            return _carRepository.GetImage(id);
        }
        public void DeteleCarDto(int id)
        {
            _carRepository.DeteleCar(id);
            _carRepository.Save();
        }
    }
}
