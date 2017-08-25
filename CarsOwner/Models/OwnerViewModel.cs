using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CarsOwner.Core.DTO;
using CarsOwner.Resource;

namespace CarsOwner.Models
{
    public class OwnerViewModel: IValidatableObject 
    {
        public OwnerDTO Owner { get; set; }

        public IList<CarDTO> CarsList { get; set; }

        public OwnerViewModel()
        {
            Owner = new OwnerDTO();
            CarsList = new List<CarDTO>();
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> error = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Owner.Name))
            {
                error.Add(new ValidationResult(ConstantNames.RequiredName));
            }

            if (string.IsNullOrEmpty(Owner.Surname))
            {
                error.Add(new ValidationResult(ConstantNames.RequiredSurname));
            }

            if (Owner.BirthDate <= 0)
            {
                error.Add(new ValidationResult(ConstantNames.RequiredBirthDate));
            }

            if (Owner.DrivingExperience < 0)
            {
                error.Add(new ValidationResult(ConstantNames.RequiredDrivingExperience));
            }

            return error;
        }
    }
}