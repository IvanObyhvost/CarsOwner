using System;
using System.Collections;
using System.Collections.Generic;
using CarsOwner.Core.DTO;
using CarsOwner.Models.Enum;

namespace CarsOwner.Models
{
    public class CarListViewModel
    {
        public IList<CarDTO> CarsList = new List<CarDTO>();
        public PageInfo PageInfo { get; set; }
        public EnumPageSize PageSizeEnum { get; set; }
    }
}