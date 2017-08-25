using System;
using System.Collections;
using System.Collections.Generic;
using CarsOwner.Core.DTO;

namespace CarsOwner.Models
{
    public class CarListViewModel
    {
        public IList<CarDTO> CarsList = new List<CarDTO>();
    }
}