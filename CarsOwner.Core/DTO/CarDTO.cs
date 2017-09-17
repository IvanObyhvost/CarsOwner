using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CarsOwner.Core.Enum;
using CarsOwner.Core.Resource;

namespace CarsOwner.Core.DTO
{
    public class CarDTO
    {
        [HiddenInput(DisplayValue = false)]
        public int IdCar { get; set; }
        [Display(Name = DisplayName.Model)]
        public string Model { get; set; }
        [Display(Name = DisplayName.СarMake)]
        public string СarMake { get; set; }
        [Display(Name = DisplayName.TypeCar)]
        public TypeCar TypeCar { get; set; }
        [Display(Name = DisplayName.Price)]
        public decimal Price { get; set; }
        [Display(Name = DisplayName.YearRelease)]
        public int YearRelease { get; set; }
        public DescriptionCarDTO DescriptionCar { get; set; }
        public List<OwnerDTO> OwnerList { get; set; }

        public CarDTO()
        {
            OwnerList = new List<OwnerDTO>();
            DescriptionCar = new DescriptionCarDTO();
        }
        
    }
}
