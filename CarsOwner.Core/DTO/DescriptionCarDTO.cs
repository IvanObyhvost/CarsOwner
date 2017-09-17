using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CarsOwner.Core.Resource;

namespace CarsOwner.Core.DTO
{
    public class DescriptionCarDTO
    {
        [HiddenInput(DisplayValue = false)]
        public int IdCar { get; set; }
        [Display(Name = DisplayName.Description)]
        public string Description { get; set; }
        public byte[] ImageData { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string ImageMineType { get; set; }
    }
}
