using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CarsOwner.Core.DTO;
using CarsOwner.Resource;

namespace CarsOwner.Models
{
    public class CarViewModel: IValidatableObject
    {
        public CarDTO Car { get; set; }

        public CarViewModel()
        {
            Car = new CarDTO();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> error = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Car.Model))
            {
                error.Add(new ValidationResult(ConstantNames.RequiredModelCar));
            }

            if (string.IsNullOrEmpty(Car.СarMake))
            {
                error.Add(new ValidationResult(ConstantNames.RequiredСarMake));
            }

            if (Car.Price <= 0)
            {
                error.Add(new ValidationResult(ConstantNames.RequiredPriceCar));
            }

            if (Car.YearRelease <= 0)
            {
                error.Add(new ValidationResult(ConstantNames.RequiredYearRelease));
            }

            return error;
        }
    }
}