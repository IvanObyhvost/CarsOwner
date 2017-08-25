using System.Collections.Generic;
using CarsOwner.Core.DTO;

namespace CarsOwner.BLL.Interface
{
    public interface ICarService
    {
        IEnumerable<CarDTO> GetCarsDtoList();
        CarDTO GetCarDto(int id);
        void AddOrUpdateCarDto(CarDTO carDto);
        void DeteleCarDto(int id);
    }
}