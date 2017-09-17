using System.Collections.Generic;
using CarsOwner.Core.DTO;

namespace CarsOwner.BLL.Interface
{
    public interface ICarService
    {
        IEnumerable<CarDTO> GetCarsDtoList();
        CarDTO GetCarDto(int id);
        void AddOrUpdateCarDto(CarDTO carDto);
        DescriptionCarDTO GetImage(int id);
        void DeteleCarDto(int id);
    }
}