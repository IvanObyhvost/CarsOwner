using System.Collections.Generic;
using CarsOwner.Core.DTO;

namespace CarsOwner.DAL.Interface
{
    public interface IOwnerRepository
    {
        IEnumerable<OwnerDTO> GetOwnersList();
        OwnerDTO GetOwner(int id);
        void AddOrUpdateOwner(OwnerDTO owner, int[] seleceedCars);
        void DeteleOwner(int id);
        void Save();
    }
}