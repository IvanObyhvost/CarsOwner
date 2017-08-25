using System.Collections.Generic;
using CarsOwner.BLL.Interface;
using CarsOwner.Core.DTO;
using CarsOwner.DAL.Interface;

namespace CarsOwner.BLL.Services
{
    public class OwnerService: IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        public IEnumerable<OwnerDTO> GetOwnersDtoList()
        {
            return _ownerRepository.GetOwnersList();
        }

        public OwnerDTO GetOwnerDto(int id)
        {
            return _ownerRepository.GetOwner(id);
        }

        public void AddOrUpdateOwnerDto(OwnerDTO ownerDto, int[] seleceedCars)
        {
            _ownerRepository.AddOrUpdateOwner(ownerDto, seleceedCars);
            _ownerRepository.Save();
        }

        public void DeteleOwnerDto(int id)
        {
            _ownerRepository.DeteleOwner(id);
            _ownerRepository.Save();
        }
    }
}
