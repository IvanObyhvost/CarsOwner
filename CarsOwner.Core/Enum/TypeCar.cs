using System.ComponentModel.DataAnnotations;
using CarsOwner.Core.Resource;

namespace CarsOwner.Core.Enum
{
    public enum TypeCar
    {
        [Display(Name = "Легковая")]
        PassengerCar,
        [Display(Name = "Грузовая")]
        Truck
    }
}