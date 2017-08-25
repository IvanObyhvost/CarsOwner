using System.Collections.Generic;
using CarsOwner.Core.DTO;

namespace CarsOwner.BLL.Interface
{
    public interface IOwnerService
    {
        IEnumerable<OwnerDTO> GetOwnersDtoList();
        OwnerDTO GetOwnerDto(int id);
        void AddOrUpdateOwnerDto(OwnerDTO ownerDto, int[] seleceedCars);
        void DeteleOwnerDto(int id);
    }
}